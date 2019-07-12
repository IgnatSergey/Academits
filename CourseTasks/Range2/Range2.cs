using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range2
{
    namespace Range
    {
        class Range
        {
            private double from;
            private double to;
            public static readonly double epsilon = 1.0e-15;

            public Range()
            {
            }

            public Range(double from, double to)
            {
                this.from = from;
                this.to = to;
            }

            public double From
            {
                get
                {
                    return from;
                }
                set
                {
                    from = value;
                }
            }

            public double To
            {
                get
                {
                    return to;
                }
                set
                {
                    to = value;
                }

            }

            public double GetDistance(Range x)
            {
                return Math.Abs(to - from);
            }

            public bool IsInside(double number)
            {
                if (number - from > -epsilon && number - to < epsilon)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public static int GetTypeCrossin(Range x, Range y)
            {
                int typeCrossing = 0;
                double a = x.from;
                double b = x.to;
                double c = y.from;
                double d = y.to;

                if (a <= c && c <= b && b >= c && b <= d)
                {
                    typeCrossing = 1;
                }
                else if (c >= a && d <= b)
                {
                    typeCrossing = 2;
                }
                else if (a >= c && b <= d)
                {
                    typeCrossing = 3;
                }
                return typeCrossing;
            }

            public static Range GetCrossing(Range x, Range y)
            {
                double fromCrossing;
                double toCrossing;
                double a = x.from;
                double b = x.to;
                double c = y.from;
                double d = y.to;

                int typeCrossing = GetTypeCrossin(x, y);
                if (typeCrossing == 1)
                {
                    fromCrossing = c;
                    toCrossing = b;
                }
                else if (typeCrossing == 2)
                {
                    fromCrossing = c;
                    toCrossing = d;
                }
                else if (typeCrossing == 3)
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
                if (GetCrossing(x, y) == null)
                {
                    arrayRangesUnion[0] = x;
                    arrayRangesUnion[1] = y;
                }
                else
                {
                    double minFrom = x.from;
                    double maxTo = x.to;
                    if (minFrom > y.from)
                    {
                        minFrom = y.from;
                    }
                    if (maxTo < y.to)
                    {
                        maxTo = y.to;
                    }
                    arrayRangesUnion[0] = new Range();
                    arrayRangesUnion[0].From = minFrom;
                    arrayRangesUnion[0].To = maxTo;
                }
                return arrayRangesUnion;
            }

            public static Range[] GetResidual(Range x, Range y)
            {
                double a = x.from;
                double b = x.to;
                double c = y.from;
                double d = y.to;
                Range[] arrayRangesResidual = new Range[2];
                arrayRangesResidual[0] = new Range();
                arrayRangesResidual[1] = new Range();

                int typeCrossing = GetTypeCrossin(x, y);
                if (typeCrossing == 0)
                {
                    arrayRangesResidual[0] = x;
                }
                else if (typeCrossing == 1)
                {
                    arrayRangesResidual[0].From = a;
                    arrayRangesResidual[0].To = c;
                }
                else if (typeCrossing == 2)
                {
                    arrayRangesResidual[0].From = a;
                    arrayRangesResidual[0].To = c;
                    arrayRangesResidual[1].From = d;
                    arrayRangesResidual[1].To = b;
                }
                return arrayRangesResidual;
            }

        }


        class Program
        {
            static void Main(string[] args)
            {
                double from1 = -5;
                double to1 = 15;
                double from2 = -1;
                double to2 = 3;

                Range range1 = new Range();
                Range range2 = new Range();
                range1.From = from1;
                range1.To = to1;
                range2.From = from2;
                range2.To = to2;

                Range rangeCross = Range.GetCrossing(range1, range2);
                Range[] rangesUnion = Range.GetUnion(range1, range2);
                Range[] rangesResidual = Range.GetResidual(range1, range2);
                int typeCrossing = Range.GetTypeCrossin(range1, range2);

                if (rangeCross == null)
                {
                    Console.WriteLine("Пересечение интервала [{0};{1}] и интервала [{2};{3}] нет", from1, to1, from2, to2);
                    Console.WriteLine("Объединение интервала [{0};{1}] и интервала [{2};{3}] - [{4},{5}] и [{6},{7}]", from1, to1, from2, to2, rangesUnion[0].From, rangesUnion[0].To, rangesUnion[1].From, rangesUnion[1].To);
                }
                else
                {
                    Console.WriteLine("Пересечение интервала [{0};{1}] и интервала [{2};{3}] - [{4},{5}]", from1, to1, from2, to2, rangeCross.From, rangeCross.To);
                    Console.WriteLine("Объединение интервала [{0};{1}] и интервала [{2};{3}] - [{4},{5}]", from1, to1, from2, to2, rangesUnion[0].From, rangesUnion[0].To);
                }

                if (typeCrossing == 3)
                {
                    Console.WriteLine("Разность интервала [{0};{1}] и интервала [{2};{3}] является пустым множеством", from1, to1, from2, to2);
                }
                else if (typeCrossing == 0 || typeCrossing == 1)
                {
                    Console.WriteLine("Разность интервала [{0};{1}] и интервала [{2};{3}] - [{4},{5}]", from1, to1, from2, to2, rangesResidual[0].From, rangesResidual[0].To);
                }
                else
                {
                    Console.WriteLine("Разность интервала [{0};{1}] и интервала [{2};{3}] - [{4},{5}] и [{6},{7}]", from1, to1, from2, to2, rangesResidual[0].From, rangesResidual[0].To, rangesResidual[1].From, rangesResidual[1].To);
                }
            }
        }
    }
}
