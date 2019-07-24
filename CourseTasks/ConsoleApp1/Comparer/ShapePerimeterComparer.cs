using System.Collections.Generic;

namespace Shape.Comparer
{
    class ShapePerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape one, IShape two)
        {
            return one.GetPerimeter().CompareTo(two.GetPerimeter());
        }
    }
}
