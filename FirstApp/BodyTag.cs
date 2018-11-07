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
        public override void AddElement(Element temp)
        {
        }
        public override void AddTag(Tag child)
        {
            var childTagType = child.GetTagType();

            try
            {
                if (childTagType != TagType.head
                && childTagType != TagType.body
                && childTagType != TagType.html
                && childTagType != TagType.title)
                {
                    Children.Add(child);
                    child.SetFather(this);
                }
            }
            catch (Exception)
            {
                throw new Exception("Invalid tag ");
            }
        }
    }
}
