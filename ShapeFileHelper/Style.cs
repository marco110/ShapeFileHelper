using System.Drawing;

namespace ShapeFileHelper
{
    public class Style
    {
        public int BorderWidth{get;set;}       

        public Color BorderColor{get;set;}

        public Color PenColor { get; set; }

        public Style(Color penColor)
        {
            this.PenColor = penColor;
        }

        public Style(int borderWidth, Color borderColor)
        {
            this.BorderColor = borderColor;
            this.BorderWidth = borderWidth;           
        }

        public Style(int borderWidth, Color borderColor,Color penColor)
        {
            this.BorderColor = borderColor;
            this.BorderWidth = borderWidth;
            this.PenColor = penColor;
        }
    }
}
