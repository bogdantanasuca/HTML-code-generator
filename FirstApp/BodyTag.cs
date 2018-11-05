using System;
using System.Collections.Generic;

namespace FirstApp
{
    public class BodyTag : Tag
    {
        public BodyTag() : base(TagType.body)
        {
            IsSelfClosing = false;
            Children = new List<Element>();
            Attributes = new Dictionary<string, string>();
        }
        public override void AddTag(Tag child)
        {
            try
            {
                if (child.Type != TagType.head
                && child.Type != TagType.body
                && child.Type != TagType.html
                && child.Type != TagType.title)
                {
                    Children.Add(child);
                    child.Father = this;
                }
            }
            catch (Exception)
            {
                throw new Exception("Invalid tag ");
            }
        }
    }
}
