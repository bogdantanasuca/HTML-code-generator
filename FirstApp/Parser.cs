using System;
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
            for (int i = 0; i < text.Length; i++)
            {
                int j = i + 1;
                //Obtain name of tag
                if (text[i] == '<' && text[i + 1] != '/')
                {
                    while (text[j] != '>' && text[j] != ' ' && text[j] != '/')
                    {
                        TagName += text[j];
                        j++;
                    }
                    i = j;
                    if (Root == null)
                    {
                        Root = CreateTag(TagName);
                        CurrentTag = Root;
                    }
                    else if (text[i] != '/')
                    {
                        ParseTag(TagName);
                    }
                    else
                    {
                        CurrentTag.AddTag(CreateTag(TagName));
                        i++;
                    }
                    if (text[i] == ' ')
                    {
                        while (text[i] != '>')
                        {
                            var part = text.Substring(i + 1, text.IndexOfAny(new char[] { ' ', '>' }, i + 1) - i - 1);
                            var attributes = part.Split("=");
                            attributes[1] = attributes[1].Substring(1, attributes[1].Length - 2);
                            CurrentTag.AddAttribute(attributes[0], attributes[1]);
                            i = text.IndexOfAny(new char[] { ' ', '>' }, i + 1);
                        }
                    }
                }
                else if (text[i] == '<' && text[i + 1] == '/')
                {
                    i += CurrentTag.Type.ToString().Length + 2;
                    CurrentTag = CurrentTag.GetFather();
                    if (ParrentTag != null)
                    {
                        ParrentTag = ParrentTag.GetFather();
                    }
                }
                else
                {
                    string content = "";
                    j = i;
                    while (text[j] != '<')
                    {
                        content += text[j];
                        j++;
                    }
                    i = j - 1;
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
