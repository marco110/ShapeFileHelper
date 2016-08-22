using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileHelper
{
    public enum ShapeType
    {
        NullShape=0,
        Point=1,
        Polyline=3,
        Polygon=5,
        MultiPoint=7
    }
}
