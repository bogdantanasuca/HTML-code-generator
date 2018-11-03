using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp
{
    class BrTag : Tag
    {
        public BrTag() : base(TagType.br)
        {
            IsSelfClosing = true;
        }
        public override void AddTag(Tag child)
        {
        }
    }
}
