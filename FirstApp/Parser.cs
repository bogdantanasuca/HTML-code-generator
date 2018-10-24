using System;
using System.Text.RegularExpressions;

namespace FirstApp
{
    class Parser
    {
        public static void ParserFile(string FileLocation)
        {
            string text = System.IO.File.ReadAllText(FileLocation);
            text = Regex.Replace(text, @"\t|\n|\r", "");

            string TagName = "";
            TreeNode Root = new TreeNode(null, "ROOT");
            TreeNode ParrentNode = Root;
            TreeNode CurrentNode = null;
            Tag ParrentTag = null;
            for (int i = 0; i < text.Length; i++)
            {
                TagName = "";
                int j = i + 1;
                //Obtain name of tag
                if (text[i] == '<' && text[i + 1] != '/')
                {

                    while (text[j] != '>')
                    {
                        TagName += text[j];
                        j++;
                    }
                    TagName = TagName.ToLower();
                    TreeNode Node = new TreeNode(ParrentNode, TagName);
                    CurrentNode = Node;
                    Tag tag = CreateTag(CurrentNode);
                    ParrentNode.AddChildren(Node);
                    ParrentNode = Node;
                    ParrentTag = tag;
                }
                else if (text[i] == '<' && text[i + 1] == '/')
                {
                    CurrentNode = ParrentNode;
                    ParrentNode = ParrentNode.GetFather();
                }
            }
        }
        private static Tag CreateTag(TreeNode Node)
        {
            Tag NewTag = null;
            switch (Node.GetName())
            {
                case "html":
                    NewTag = new Tag(TagType.Html);
                    break;
                case "body":
                    NewTag = new Tag(TagType.Body);
                    break;
                case "head":
                    NewTag = new Tag(TagType.Head);
                    break;
                case "div":
                    NewTag = new Tag(TagType.Div);
                    break;
                case "h1":
                    NewTag = new Tag(TagType.H1);
                    break;
                case "title":
                    NewTag = new Tag(TagType.Title);
                    break;
            }
            return NewTag;
        }
    }
}
