using System;

namespace Range
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = -15;

            Range range1 = new Range(-3, 0);
            Range range2 = new Range(-9, -3);

            Range rangeCross = range1.GetCrossing(range2);
            Range[] rangesUnion = range1.GetUnion(range2);
            Range[] rangesResidual = range1.GetResidual(range2);

            Console.Write("Длина интервала ");
            range1.PrintRange();
            Console.WriteLine(range1.GetLength());
            Console.WriteLine(new string('-', 50));

            if (range1.IsInside(number))
            {
                Console.WriteLine("Точка {0} принадлежит интервалу [{1};{2}]", number, range1.From, range1.To);
            }
            else
            {
                Console.WriteLine("Точка {0} не принадлежит интервалу [{1};{2}]", number, range1.From, range1.To);
            }
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Пересечение интервала [{0};{1}] и интервала [{2};{3}]:", range1.From, range1.To, range2.From, range2.To);
            if (rangeCross == null)
            {
                Console.WriteLine("пустое множество");
            }
            else
            {
                rangeCross.PrintRange();
            }
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Объединение интервала [{0};{1}] и интервала [{2};{3}]:", range1.From, range1.To, range2.From, range2.To);
            foreach (Range e in rangesUnion)
            {
                e.PrintRange();
            }
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Разность интервала [{0};{1}] и интервала [{2};{3}]:", range1.From, range1.To, range2.From, range2.To);
            foreach (Range e in rangesResidual)
            {
                e.PrintRange();
            }
            Console.WriteLine(new string('-', 50));
        }
    }
}
