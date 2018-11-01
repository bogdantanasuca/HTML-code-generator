﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp
{
    class HeadTag : Tag
    {
        public HeadTag() : base(TagType.head)
        {
            IsSelfClosing = false;
            Children = new List<Element>();
        }
        public override void AddTag(Tag child)
        {
            if (child.Type != TagType.head
                && child.Type != TagType.body
                && child.Type != TagType.html)
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