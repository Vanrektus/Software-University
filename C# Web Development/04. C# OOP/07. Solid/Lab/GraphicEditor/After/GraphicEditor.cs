using System;

namespace GraphicEditor
{
    public class GraphicEditor
    {
        //---------------------------Constructors---------------------------
        public GraphicEditor()
        {

        }

        //---------------------------Methods---------------------------
        public void Draw(IShape shape)
        {
            Type classType = shape.GetType();
            Shape instance = Activator.CreateInstance(classType) as Shape;

            Console.WriteLine(instance.Draw());
        }
    }
}
