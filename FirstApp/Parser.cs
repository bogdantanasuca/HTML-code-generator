using System;
using System.Text;
using System.Text.RegularExpressions;

namespace FirstApp
{
    public static class Parser
    {
        private static Tag ParrentTag;
        private static Tag CurrentTag;
        private static Tag Root;


        public static void ParseFile(string FileLocation)
        {
            string text = System.IO.File.ReadAllText(FileLocation);
            text = Regex.Replace(text, @"\t|\n|\r", "");
            string TagName = "";
            for (int index = 0; index < text.Length; index++)
            {
                int tempIndex = index + 1;
                //Obtain name of tag
                if (text[index] == '<' && text[index + 1] != '/')
                {
                    while (text[tempIndex] != '>' && (text[tempIndex] != ' ' || text[tempIndex + 1] == ' ') && text[tempIndex] != '/')
                    {
                        TagName += text[tempIndex];
                        tempIndex++;
                    }
                    index = tempIndex;
                    if (text[index] == ' ')
                    {
                        TagName = TagName.Trim();
                        index++;
                    }
                    if (Root == null)
                    {
                        //html tag
                        Root = CreateTag(TagName);
                        CurrentTag = Root;
                    }
                    else if (text[index] != '/')
                    {
                        //normal tag
                        ParseTag(TagName);
                    }
                    else
                    {
                        //self-closing tag
                        CurrentTag.AddTag(CreateTag(TagName));
                        index = text.IndexOf('>', index + 1);
                    }
                    if (text[index-1] == ' ' && text[index]!='>')
                    {
                        var attributes = new StringBuilder();
                        while (text[index] != '>')
                        {
                            attributes.Append(text[index]);
                            index++;
                        }
                        attributes.Replace("=\"","*");
                        attributes.Replace(" ","");
                        attributes.Length--;
                        var attribute = attributes.ToString().Split('"');
                        foreach(var tempAtt in attribute)
                        {
                            var keyValue = tempAtt.Split('*');
                            CurrentTag.AddAttribute(keyValue[0], keyValue[1]);
                        }
                    }
                }
                else if (text[index] == '<' && text[index + 1] == '/')
                {
                    index += CurrentTag.GetTagType().ToString().Length + 2;
                    CurrentTag = CurrentTag.GetFather();
                    if (ParrentTag != null)
                    {
                        ParrentTag = ParrentTag.GetFather();
                    }
                }
                else
                {
                    string content = "";
                    tempIndex = index;
                    while (text[tempIndex] != '<')
                    {
                        content += text[tempIndex];
                        tempIndex++;
                    }
                    index = tempIndex - 1;
                    Element temp = new Element();
                    temp.SetContent(content);
                    CurrentTag.AddElement(temp);
                }
                TagName = "";
            }
            Console.WriteLine("Render of the Tree:");
            Console.WriteLine(Root.CreateString(0));
            Root.PrintTag();
        }
        private static Tag CreateTag(string name)
        {
            switch (name)
            {
                case "html":
                    return new HtmlTag();
                case "body":
                    return new BodyTag();
                case "head":
                    return new HeadTag();
                case "div":
                    return new DivTag();
                case "h1":
                    return new H1Tag();
                case "title":
                    return new TitleTag();
                case "br":
                    return new BrTag();
                default:
                    return new Tag();
            }
        }
        private static void ParseTag(string tagName)
        {
            ParrentTag = CurrentTag;
            CurrentTag = CreateTag(tagName);
            ParrentTag.AddTag(CurrentTag);
        }

    }
}
