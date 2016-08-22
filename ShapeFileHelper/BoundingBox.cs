namespace ShapeFileHelper
{
    public class BoundingBox
    {
        private double xMin, xMax, yMin, yMax;

        public double XMin
        {
            get { return xMin; }
            set { xMin = value; }
        }

        public double XMax
        {
            get { return xMax; }
            set { xMax = value; }
        }

        public double YMin
        {
            get { return yMin; }
            set { yMin = value; }
        }

        public double YMax
        {
            get { return yMax; }
            set { yMax = value; }
        }

        public BoundingBox(double xMin, double xMax, double yMin, double yMax)
        {
            this.XMin = xMin;
            this.XMax = xMax;
            this.YMin = yMin;
            this.YMax = yMax;
        }
    }
}
