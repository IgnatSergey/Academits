using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits
{
    class Range
    {
        public double From
        {
            get;
            set;
        }

        public double To
        {
            get;
            set;
        }

        public void PrintRange()
        {
            Console.WriteLine("[{0};{1}]", From, To);
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            if (number > From && number < To)
            {
                return true;
            }
            return false;
        }

        public static int GetTypeCrossin(Range x, Range y)
        {
            int typeCrossing = 0;
            double a = x.From;
            double b = x.To;
            double c = y.From;
            double d = y.To;

            if (c >= a && c <= b && b <= d)
            {
                typeCrossing = 1;
            }
            else if (a >= c && a <= d && d <= b)
            {
                typeCrossing = 2;
            }
            else if (c >= a && d <= b)
            {
                typeCrossing = 3;
            }
            else if (a >= c && b <= d)
            {
                typeCrossing = 4;
            }
            return typeCrossing;
        }

        public static Range GetCrossing(Range x, Range y)
        {
            double fromCrossing;
            double toCrossing;
            double a = x.From;
            double b = x.To;
            double c = y.From;
            double d = y.To;

            int typeCrossing = GetTypeCrossin(x, y);
            if (typeCrossing == 1)
            {
                fromCrossing = c;
                toCrossing = b;
            }
            else if (typeCrossing == 2)
            {
                fromCrossing = a;
                toCrossing = d;
            }
            else if (typeCrossing == 3)
            {
                fromCrossing = c;
                toCrossing = d;
            }
            else if (typeCrossing == 4)
            {
                fromCrossing = a;
                toCrossing = b;
            }
            else
            {
                return null;
            }
            Range rangeCross = new Range();
            rangeCross.From = fromCrossing;
            rangeCross.To = toCrossing;
            return rangeCross;
        }

        public static Range[] GetUnion(Range x, Range y)
        {
            Range[] arrayRangesUnion = new Range[2];
            arrayRangesUnion[0] = new Range();
            arrayRangesUnion[1] = new Range();
            if (GetCrossing(x, y) == null)
            {
                arrayRangesUnion[0] = x;
                arrayRangesUnion[1] = y;
            }
            else
            {
                double minFrom = x.From;
                double maxTo = x.To;
                if (minFrom > y.From)
                {
                    minFrom = y.From;
                }
                if (maxTo < y.To)
                {
                    maxTo = y.To;
                }
                arrayRangesUnion[0].From = minFrom;
                arrayRangesUnion[0].To = maxTo;
                arrayRangesUnion[1] = null;
            }
            return arrayRangesUnion;
        }

        public static Range[] GetResidual(Range x, Range y)
        {
            double a = x.From;
            double b = x.To;
            double c = y.From;
            double d = y.To;
            Range[] arrayRangesResidual = new Range[2];
            arrayRangesResidual[0] = new Range();
            arrayRangesResidual[1] = new Range();

            int typeCrossing = GetTypeCrossin(x, y);
            if (typeCrossing == 0)
            {
                arrayRangesResidual[0] = x;
                arrayRangesResidual[1] = null;
            }
            else if (typeCrossing == 1)
            {
                arrayRangesResidual[0].From = a;
                arrayRangesResidual[0].To = c;
                arrayRangesResidual[1] = null;
            }
            else if (typeCrossing == 2)
            {
                arrayRangesResidual[0].From = a;
                arrayRangesResidual[0].To = d;
                arrayRangesResidual[1] = null;
            }
            else if (typeCrossing == 3)
            {
                arrayRangesResidual[0].From = a;
                arrayRangesResidual[0].To = c;
                arrayRangesResidual[1].From = d;
                arrayRangesResidual[1].To = b;
            }
            else
            {
                arrayRangesResidual[0] = null;
                arrayRangesResidual[1] = null;
            }
            return arrayRangesResidual;
        }
    }
}

