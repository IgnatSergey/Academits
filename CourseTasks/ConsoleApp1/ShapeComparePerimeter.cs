using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits
{
    class ShapeComparePerimeter : IComparer<IShape>
    {
        public int Compare(IShape one, IShape two)
        {
            if (one.GetPerimeter() > two.GetPerimeter())
            {
                return 1;
            }
            else if (one.GetPerimeter() < two.GetPerimeter())
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
