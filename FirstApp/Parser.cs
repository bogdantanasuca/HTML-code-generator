using System;
using System.Text.RegularExpressions;

namespace FirstApp
{
    class Parser
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
                    while (text[j] != '>' && text[j] != ' ')
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
                    else
                    {
                        ParseTag(TagName);
                    }
                }
                else if (text[i] == '<' && text[i + 1] == '/')
                {
                    CurrentTag = CurrentTag.GetFather();
                    if (ParrentTag != null)
                    {
                        ParrentTag = ParrentTag.GetFather();
                    }
                    while (text[i] != '>')
                    {
                        i++;
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
                default:
                    return null;
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
