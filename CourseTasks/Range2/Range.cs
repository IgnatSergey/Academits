using System;

namespace Academits
{
    class Range
    {
        public double From { get; set; }
        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
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
            return number > From && number < To;
        }

        public enum CrossingType
        {
            CrossingThisRangeRight = 0,
            CrossingThisRangeLeft = 1,
            ContainingRange = 2,
            ContainingThisRange = 3,
            NotCrossing = 4
        }

        public CrossingType GetCrossingType(Range range)
        {
            double startThisRange = From;
            double endThisRange = To;
            double startRange = range.From;
            double endRange = range.To;

            if (startRange >= startThisRange && startRange <= endThisRange && endThisRange <= endRange)
            {
                return CrossingType.CrossingThisRangeRight;
            }
            else if (startThisRange >= startRange && startThisRange <= endRange && endRange <= endThisRange)
            {
                return CrossingType.CrossingThisRangeLeft;
            }
            else if (startRange >= startThisRange && endRange <= endThisRange)
            {
                return CrossingType.ContainingRange;
            }
            else if (startThisRange >= startRange && endThisRange <= endRange)
            {
                return CrossingType.ContainingThisRange;
            }
            return CrossingType.NotCrossing;
        }

        public Range GetCrossing(Range range)
        {
            double startThisRange = From;
            double endThisRange = To;
            double startRange = range.From;
            double endRange = range.To;

            CrossingType typeCrossing = GetCrossingType(range);
            if ((int)typeCrossing == 0)
            {
                return new Range(startRange, endThisRange);
            }
            else if ((int)typeCrossing == 1)
            {
                return new Range(startThisRange, endRange);
            }
            else if ((int)typeCrossing == 2)
            {
                return new Range(startRange, endRange);
            }
            else if ((int)typeCrossing == 3)
            {
                return new Range(startThisRange, endThisRange);
            }
            else
            {
                return null;
            }
        }

        public Range[] GetUnion(Range range)
        {
            double startThisRange = From;
            double endThisRange = To;
            double startRange = range.From;
            double endRange = range.To;

            if (endThisRange < startRange || startThisRange > endRange)
            {
                Range[] arrayRangesUnion = new Range[2];
                arrayRangesUnion[0] = new Range(startThisRange, endThisRange);
                arrayRangesUnion[1] = new Range(startRange, endRange);
                return arrayRangesUnion;
            }
            else
            {
                Range[] arrayRangesUnion = new Range[1];
                arrayRangesUnion[0] = new Range(Math.Min(startThisRange, startRange), Math.Max(endThisRange, endRange));
                return arrayRangesUnion;
            }
        }

        public Range[] GetResidual(Range range)
        {
            double startThisRange = From;
            double endThisRange = To;
            double startRange = range.From;
            double endRange = range.To;

            if (endThisRange < startRange || startThisRange > endRange)
            {
                Range[] arrayRangesResidual = new Range[1];
                arrayRangesResidual[0] = new Range(startThisRange, endThisRange);
                return arrayRangesResidual;
            }
            else if (startRange < startThisRange && endThisRange < endRange)
            {
                return null;
            }
            else if (startRange < startThisRange)
            {
                Range[] arrayRangesResidual = new Range[1];
                arrayRangesResidual[0] = new Range(endRange, endThisRange);
                return arrayRangesResidual;
            }
            else if (startThisRange < startRange && endThisRange > endRange)
            {
                Range[] arrayRangesResidual = new Range[2];
                arrayRangesResidual[0] = new Range(startThisRange, startRange);
                arrayRangesResidual[1] = new Range(endRange, endThisRange);
                return arrayRangesResidual;
            }
            else
            {
                Range[] arrayRangesResidual = new Range[1];
                arrayRangesResidual[0] = new Range(startThisRange, startRange);
                return arrayRangesResidual;
            }
        }
    }
}

