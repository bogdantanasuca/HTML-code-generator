using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp
{
    class TitleTag : Tag
    {
        public TitleTag() : base(TagType.title)
        {
            IsSelfClosing = false;
            Children = new List<Element>();
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
