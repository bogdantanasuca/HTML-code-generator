using System;
using System.Collections.Generic;

namespace FirstApp
{
   class Tag : BaseClass
    {
        private int Depth;
        List<Tag> Children = new List<Tag>();
        private Tag() { }
        public Tag(TagType Type)
        {
            this.Type = Type;
            this.Content = "";
            this.Depth = 0;
        }
        public void AddChild(Tag child)
        {
            this.Children.Add(child);
            child.Depth = this.Depth + 1;
            //Console.WriteLine(child.Depth + " " + child.Type);
        }
        public void AddAttribute(string attribute,string value)
        {
            this.Attributes.Add(attribute, value);
        }
        public void SetContent(string content)
        {
            this.Content = content;
        }
        public void print()
        {
            foreach (KeyValuePair<string, string> kvp in this.Attributes)
            {
                Console.WriteLine("Key = {0}, Value = {1}",kvp.Key, kvp.Value);
            }
        }
        public void Render()
        {

            string TagLine = "<" + this.Type;
            foreach (KeyValuePair<string, string> kvp in this.Attributes)
            {
                TagLine += " " + kvp.Key + "=" + kvp.Value;
            }
            TagLine += ">";

            System.IO.File.AppendAllText("index.html", TagLine + Environment.NewLine);
            if (this.Content != "")
            {
                for (int i = 0; i < this.Depth+1; i++)
                {
                    System.IO.File.AppendAllText("index.html", "\t");
                }
                System.IO.File.AppendAllText("index.html", this.Content + Environment.NewLine);
            }
            
            foreach (var child in this.Children)
            {
                for(int i=0;i<=this.Depth;i++)
                {
                    System.IO.File.AppendAllText("index.html", "\t");
                }
                child.Render();
                System.IO.File.AppendAllText("index.html",Environment.NewLine);
            }
            for (int i = 0; i < this.Depth; i++)
            {
                System.IO.File.AppendAllText("index.html", "\t");
            }
            TagLine = "</" + this.Type + ">";
            System.IO.File.AppendAllText("index.html", TagLine);
        }
    }
}
