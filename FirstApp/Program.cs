namespace FirstApp
{

    public static class Program
    {
        static void Main(string[] args)
        {
            Tag html = new HtmlTag();
            Tag body = new BodyTag();
            Tag head = new HeadTag();
            Tag title = new TitleTag();
            Tag div = new DivTag();
            Element elem1 = new Element();
            Element elem2 = new Element();
            Element elem3 = new Element();
            Tag brr = new BrTag();

            //Tag h1 = new Tag(TagType.h1);

            elem1.SetContent("titlu");
            elem2.SetContent("giele");
            elem3.SetContent("gielesss");
            html.AddTag(head);
            html.AddTag(body);
            head.AddElement(elem1);
            head.AddTag(brr);
            head.AddTag(title);
            head.AddElement(elem2);
            head.AddTag(title);
            head.AddElement(elem3);
            body.AddTag(div);
            //div.AddTag(h1);
            div.AddAttribute("color", "blue");
            div.AddAttribute("color1", "red");
            //title.SetContent("Gigi 4 the WIN!!");
            //head.SetContent("gigel");
            html.Render();
            Parser.ParseFile("index.html");
        }
    }


}
