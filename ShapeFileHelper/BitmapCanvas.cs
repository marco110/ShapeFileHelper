using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapeFileHelper {
    public class BitmapCanvas : Canvas {
        public Bitmap Bitmap { get; set; }

        public BitmapCanvas(int width, int height) {
            this.Height = height;
            this.Width = width;
        }

        public Bitmap GetBitmap() {
            this.Bitmap = new Bitmap(Width, Height);
            return Bitmap;
        }
    }
}
