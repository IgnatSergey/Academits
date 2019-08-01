using System;
using Shape.Comparer;

namespace Shape
{
    class Program
    {
        public static IShape GetMaxAreaShape(IShape[] array)
        {
            Array.Sort(array, new ShapeAreaComparer());
            return array[array.Length - 1];
        }

        public static IShape GetSecondMaxPerimeterShape(IShape[] array)
        {
            Array.Sort(array, new ShapePerimeterComparer());
            return array[array.Length - 2];
        }

        static void Main(string[] args)
        {
            IShape[] array =
            {
                new Square(10),
                new Square(5.5),
                new Rectangle(1, 2),
                new Rectangle(1, 2),
                new Circle(6),
                new Circle(5),
                new Triangle(0, 1, 2, 4, 4, 5),
                new Triangle(0, 1, 2, 4, 4, 50)
            };
            IShape maxAreaShape = GetMaxAreaShape(array);
            Console.WriteLine("Фигура с максимальной площадью:");
            Console.WriteLine(maxAreaShape);
            Console.WriteLine("Площадь: {0:f2}", maxAreaShape.GetArea());
            Console.WriteLine("Периметр: {0:f2}", maxAreaShape.GetPerimeter());

            IShape secondMaxPerimeterShape = GetSecondMaxPerimeterShape(array);
            Console.WriteLine("Фигура со вторым по велечине периметром:");
            Console.WriteLine(secondMaxPerimeterShape);
            Console.WriteLine("Площадь: {0:f2}", secondMaxPerimeterShape.GetArea());
            Console.WriteLine("Периметр: {0:f2}", secondMaxPerimeterShape.GetPerimeter());
        }
    }
}
