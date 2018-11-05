using System;
using System.Collections.Generic;

namespace FirstApp
{
    public class H1Tag : Tag
    {
        public H1Tag() : base(TagType.h1)
        {
            IsSelfClosing = false;
            Children = new List<Element>();
            Attributes = new Dictionary<string, string>();
        }
        public override void AddTag(Tag child)
        {
            if (child.Type != TagType.head
                && child.Type != TagType.body
                && child.Type != TagType.html
                && child.Type != TagType.title)
            {
                Children.Add(child);
                child.Father = this;
            }
            else
            {
                throw new Exception("Invalid tag ");
            }
        }
    }
}
