namespace FirstApp
{
    public class Element
    {
        private string Content { get; set; }

        public void SetContent(string content)
        {
            Content = content;
        }
        public string GetContent()
        {
            return Content;
        }
    }
}
