using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FirstApp
{
    public class Tag : Element
    {
        public List<Element> Children { get; set; }
        public bool IsSelfClosing { get; set; }
        public TagType Type { get; set; }
        public IDictionary<string, string> Attributes { get; set; }
        public Tag Father { get; set; }
        public Tag() { }

        public Tag(TagType type)
        {
            Type = type;
            Content = "";
            Father = null;
        }

        public Tag GetFather()
        {
            return Father;
        }

        public virtual void AddTag(Tag child)
        {
            Children.Add(child);
            child.Father = this;
        }

        public void AddElement(Element Temp)
        {
            Children.Add(Temp);
        }

        public void AddAttribute(string attribute, string value)
        {
            //value = '"' + value + '"';
            Attributes.Add(attribute, value);
        }

        public void Render()
        {
            Console.WriteLine("Render of the Html file:");
            Console.WriteLine(CreateString(0));
            File.WriteAllText("index.html", CreateString(0).ToString());
        }

        public StringBuilder CreateString(int Depth)
        {
            var text = new StringBuilder("");
            text = AddTabs(Depth, text);
            text.Append("<" + Type);
            if (Attributes != null)
            {
                foreach (var kvp in Attributes)
                {
                    text.Append(" " + kvp.Key + "=\"" + kvp.Value + '"');
                }
            }
            if (IsSelfClosing)
            {
                text.Append("/>\n");
            }
            else
            {
                text.Append(">\n");
                foreach (var child in Children)
                {
                    if (child is Tag)
                    {
                        var temp = child as Tag;
                        text.Append(temp.CreateString(Depth + 1));
                    }
                    else
                    {
                        text = AddTabs(Depth + 1, text);
                        text.Append(child.Content + "\n");
                    }
                }
                text = AddTabs(Depth, text);
                text.Append("</" + Type + ">\n");
            }
            return text;
        }

        private StringBuilder AddTabs(int times, StringBuilder text)
        {
            for (var index = 0; index < times; index++)
            {
                text.Append("\t");
            }
            return text;
        }
        public void PrintTag()
        {
            Console.WriteLine("Tag:");
            Console.WriteLine(Type);
            if (Attributes != null)
            {
                Console.WriteLine("Attributes:");
                foreach (var att in Attributes)
                {
                    Console.WriteLine(att);
                }
            }
            if (Children != null)
            {
                Console.WriteLine("Children:");
                foreach (var child in Children)
                {
                    if (child is Tag)
                    {
                        Console.WriteLine(child.GetType());
                        var temp = child as Tag;
                    }
                    else
                    {
                        Console.WriteLine(child.Content);
                    }
                }
                foreach (var child in Children)
                {
                    if (child is Tag)
                    {
                        var temp = child as Tag;
                        temp.PrintTag();
                    }
                }
            }

        }
    }
}
