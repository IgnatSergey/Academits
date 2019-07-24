using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits
{
    public enum CrossingType
    {
        CrossingThisRangeRight = 0,
        CrossingThisRangeLeft = 1,
        ContainingRange = 2,
        ContainingThisRange = 3,
        NotCrossing = 4
    }

    partial class Range
    {
        public CrossingType GetCrossingType(Range range)
        {
            if (range.From >= From && range.From <= To && To <= range.To)
            {
                return CrossingType.CrossingThisRangeRight;
            }
            if (From >= range.From && From <= range.To && range.To <= To)
            {
                return CrossingType.CrossingThisRangeLeft;
            }
            if (range.From >= From && range.To <= To)
            {
                return CrossingType.ContainingRange;
            }
            if (From >= range.From && To <= range.To)
            {
                return CrossingType.ContainingThisRange;
            }
            return CrossingType.NotCrossing;
        }
    }

}
