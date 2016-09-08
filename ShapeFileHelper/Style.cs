using System.Drawing;

namespace ShapeFileHelper
{

    public class Style
    {

        public int LineWidth { get; set; }

        public Color PenColor { get; set; }

        public Style(int penWidth, Color penColor)
        {
            this.LineWidth = penWidth;
            this.PenColor = penColor;
        }
    }
}
