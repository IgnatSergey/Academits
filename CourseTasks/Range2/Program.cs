using System;

namespace Academits
{
    class Program
    {
        static void Main(string[] args)
        {
            double from1 = -8;
            double to1 = 15;
            double from2 = -16;
            double to2 = -9;
            double number = 20;

            Range range1 = new Range(from1, to1);
            Range range2 = new Range(from2, to2);

            Range rangeCross = range1.GetCrossing(range2);
            Range[] rangesUnion = range1.GetUnion(range2);
            Range[] rangesResidual = range1.GetResidual(range2);

            Console.WriteLine("Длина интервала [{0};{1}] : ", from1, to1);
            Console.WriteLine(range1.GetLength());
            Console.WriteLine(new string('-', 50));

            if (range1.IsInside(number))
            {
                Console.WriteLine("Точка {0} принадлежит интервалу [{1};{2}]", number, from1, to1);
            }
            else
            {
                Console.WriteLine("Точка {0} не принадлежит интервалу [{1};{2}]", number, from1, to1);
            }
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Пересечение интервала [{0};{1}] и интервала [{2};{3}]:", from1, to1, from2, to2);
            if (rangeCross == null)
            {
                Console.WriteLine("пустое множество");
            }
            else
            {
                rangeCross.PrintRange();
            }
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Объединение интервала [{0};{1}] и интервала [{2};{3}]:", from1, to1, from2, to2);
            foreach (Range e in rangesUnion)
            {
                e.PrintRange();
            }
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Разность интервала [{0};{1}] и интервала [{2};{3}]:", from1, to1, from2, to2);
            if (rangesResidual == null)
            {
                Console.WriteLine("пустое множество");
            }
            else
            {
                foreach (Range e in rangesResidual)
                {
                    e.PrintRange();
                }
            }
            Console.WriteLine(new string('-', 50));
        }
    }
}
