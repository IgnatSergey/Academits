using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class Range
    {
        private double from;
        private double to;
        public static readonly double epsilon = 1.0e-15;

        public Range(double from, double to)
        {
            this.from = from;
            this.to = to;
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
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую точку интервала: ");
            double from = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите вторую точку интервала: ");
            double to = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите число: ");
            double number = Convert.ToDouble(Console.ReadLine());

            if (to < from)
            {
                double temp = to;
                to = from;
                from = temp;
            }

            Range range = new Range(from, to);
            Console.WriteLine("Длина интервала [{0};{1}] = {2}", from, to, range.GetDistance(range));
            if (range.IsInside(number))
            {
                Console.WriteLine("Число {0} принадлежит интервалу", number);
            }
            else
            {
                Console.WriteLine("Число {0} не принадлежит интервалу", number);
            }
        }
    }
}
