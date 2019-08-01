using System;

namespace Range
{
    public class Range
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
            return number >= From && number <= To;
        }

        public Range GetCrossing(Range range)
        {
            if (To <= range.From || From >= range.To)
            {
                return null;
            }

            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }

        public Range[] GetUnion(Range range)
        {
            if (To < range.From || From > range.To)
            {
                return new Range[]
                {
                    new Range(From, To),
                    new Range(range.From, range.To)
                };
            }

            return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
        }

        public Range[] GetResidual(Range range)
        {
            if (To <= range.From || From >= range.To)
            {
                return new Range[] { new Range(From, To) };
            }
            if (range.From <= From && To <= range.To)
            {
                return new Range[] { };
            }
            if (From < range.From && To > range.To)
            {
                return new Range[]
                {
                new Range(From, range.From),
                new Range(range.To, To)
                };
            }
            if (range.From < From)
            {
                return new Range[] { new Range(range.To, To) };
            }

            return new Range[] { new Range(From, range.From) };
        }
    }
}

