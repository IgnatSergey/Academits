using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits
{
    class Program
    {
        public static IShape GetMaxAreaShape(IShape[] array)
        {
            Array.Sort(array, new ShapeCompareArea());
            return array[array.Length - 1];
        }

        public static IShape GetSecondMaxPerimeterShape(IShape[] array)
        {
            Array.Sort(array, new ShapeComparePerimeter());
            return array[array.Length - 2];
        }

        static void Main(string[] args)
        {
            IShape[] array = new IShape[8];
            array[0] = new Square(5);
            array[1] = new Square(5.5);
            array[2] = new Rectangle(1, 2);
            array[3] = new Rectangle(1, 2);
            array[4] = new Circle(5.5);
            array[5] = new Circle(5);
            array[6] = new Triangle(0, 1, 2, 4, 4, 5);
            array[7] = new Triangle(0, 1, 2, 4, 4, 5);

            IShape maxAreaShape = GetMaxAreaShape(array);
            Console.WriteLine("Фигура с максимальной площадью:");
            Console.WriteLine(maxAreaShape);
            Console.WriteLine("Площадь: {0:f2}", maxAreaShape.GetArea());
            Console.WriteLine("Периметр: {0:f2}", maxAreaShape.GetPerimeter());

            IShape secondMaxPerimeterShape = GetSecondMaxPerimeterShape(array);
            Console.WriteLine("Фигура со вторым по велечине периметром:");
            Console.WriteLine(secondMaxPerimeterShape);
            Console.WriteLine("Площадь круга: {0:f2}", secondMaxPerimeterShape.GetArea());
            Console.WriteLine("Периметр круга: {0:f2}", secondMaxPerimeterShape.GetPerimeter());
        }
    }
}
