namespace GraphicEditor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IShape shape = new Circle();
            GraphicEditor ge = new GraphicEditor();

            ge.Draw(shape);
        }
    }
}
