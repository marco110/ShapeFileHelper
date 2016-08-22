using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapeFileHelper
{
    public class BitmapCanvas:Canvas
    {
        private Bitmap bitmap;

        public Bitmap Bitmap
        {
            get { return bitmap; }
            set { bitmap = value; }
        }
        
        public BitmapCanvas(int width,int height)
        {
            this.Height = height;
            this.Width = width;
        }
       
        public Bitmap GetBitmap()
        {
            this.Bitmap = new Bitmap(Width, Height);
            return Bitmap;
        }
    }
}
