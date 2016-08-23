using System.Drawing;

namespace ShapeFileHelper
{
    public abstract class Canvas
    {
      
        public int Width { get; set; }

        public int Height { get; set; }

        public Canvas() { }

        public Canvas(int width,int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
