using System.Drawing;

namespace ShapeFileHelper {
    public class Style {
        public int PenWidth { get; set; }

        public Color PenColor { get; set; }

        public Style(int penWidth, Color penColor) {
            this.PenWidth = penWidth;
            this.PenColor = penColor;
        }
    }
}
