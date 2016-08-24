namespace ShapeFileHelper {
    public class BoundingBox {
        public double XMin { get; set; }

        public double XMax { get; set; }

        public double YMin { get; set; }

        public double YMax { get; set; }

        public BoundingBox(double xMin, double xMax, double yMin, double yMax) {
            this.XMin = xMin;
            this.XMax = xMax;
            this.YMin = yMin;
            this.YMax = yMax;
        }
    }
}
