using System.Collections.Generic;

namespace Shape.Comparer
{
    class ShapeAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape one, IShape two)
        {
            return one.GetArea().CompareTo(two.GetArea());
        }
    }
}
