namespace ShapeFileHelper
{
    public class BoundingBox : PolygonShape
    {
        private double xMin;
        private double yMin;
        private double xMax;
        private double yMax;

        public double XMin
        {
            get { return xMin; }
            set { xMin = value; }
        }

        public double YMin
        {
            get { return yMin; }
            set { yMin = value; }
        }

        public double XMax
        {
            get { return xMax; }
            set { xMax = value; }
        }

        public double YMax
        {
            get { return yMax; }
            set { yMax = value; }
        }

        public double Width
        {
            get { return xMax - xMin; }
        }

        public double Height
        {
            get { return yMax - yMin; }
        }

        public BoundingBox(double xMin, double yMin, double xMax, double yMax)
        {
            this.xMin = xMin;
            this.xMax = xMax;
            this.yMin = yMin;
            this.yMax = yMax;
        }
    }
}
