using System.Drawing;

namespace ShapeFileHelper
{
    public abstract class Canvas
    {
        private int width, height;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public Canvas() { }

        public Canvas(int width,int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
