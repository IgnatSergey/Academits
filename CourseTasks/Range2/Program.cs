using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits
{
    class Program
    {
        static void Main(string[] args)
        {
            double from1 = -8;
            double to1 = 15;
            double from2 = 17;
            double to2 = 27;
            double number = 20;

            Range range1 = new Range();
            Range range2 = new Range();
            range1.From = from1;
            range1.To = to1;
            range2.From = from2;
            range2.To = to2;

            Range rangeCross = Range.GetCrossing(range1, range2);
            Range[] rangesUnion = Range.GetUnion(range1, range2);
            Range[] rangesResidual = Range.GetResidual(range1, range2);

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
            if (rangesUnion[1] == null)
            {
                rangesUnion[0].PrintRange();
            }
            else
            {
                rangesUnion[0].PrintRange();
                rangesUnion[1].PrintRange();
            }
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Разность интервала [{0};{1}] и интервала [{2};{3}]:", from1, to1, from2, to2);
            if (rangesResidual[0] == null)
            {
                Console.WriteLine("пустое множество");
            }
            else if (rangesResidual[1] == null)
            {
                rangesResidual[0].PrintRange();
            }
            else
            {
                rangesResidual[0].PrintRange();
                rangesResidual[1].PrintRange();
            }
        }
    }
}
