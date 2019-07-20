using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits
{
    class ShapeCompareArea : IComparer<IShape>
    {
        public int Compare(IShape one, IShape two)
        {
            if (one.GetArea() > two.GetArea())
            {
                return 1;
            }
            else if (one.GetArea() < two.GetArea())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
