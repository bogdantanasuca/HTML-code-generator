namespace FirstApp
{
    public class BrTag : Tag
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
