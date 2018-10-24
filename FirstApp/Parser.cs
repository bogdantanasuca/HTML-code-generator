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

            //System.Console.Write(text);
            string TagName = "";
            TreeNode Root = new TreeNode(null, "ROOT");
            TreeNode Parrent = Root;
            TreeNode CurrentNode = null;
            //TreeNode Child;
            for (int i = 0; i < text.Length; i++)
            {
                TagName = "";
                //System.Console.Write(text[i]);
                int j = i + 1;
                //Obtain name of tag
                if (text[i] == '<' && text[i + 1] != '/')
                {

                    while (text[j] != '>')
                    {
                        TagName += text[j];
                        j++;
                    }
                    //System.Console.Write(TagName + '\n');
                    TagName = TagName.ToLower();
                    TreeNode Node = new TreeNode(Parrent, TagName);
                    CurrentNode = Node;
                    Parrent.AddChildren(Node);
                    Parrent = Node;
                    Node.PrintName();
                    System.Console.Write(" is opened \n");
                    Parrent.PrintName();
                    System.Console.Write(" is the parent \n");
                }
                else if (text[i] == '<' && text[i + 1] == '/')
                {
                    CurrentNode = Parrent;
                    CurrentNode.PrintName();
                    System.Console.Write(" is closed \n");
                    Parrent = Parrent.GetFather();
                    Parrent.PrintName();
                    System.Console.Write(" is the parent \n");
                }
            }
        }
        private Tag CreateTag(TreeNode Node)
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
