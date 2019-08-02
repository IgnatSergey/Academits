using System;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector zerowVector = new Vector(3);
            Console.WriteLine("zerowVector = " + zerowVector);
            Console.WriteLine(new string('-', 100));

            double[] array = { 3, 3.75, 2, 44, -5, 54 };
            Vector arrayVector = new Vector(array);
            Vector copyArrayVector = new Vector(arrayVector);
            Console.WriteLine("arrayVector = " + arrayVector);
            Console.WriteLine("copyArrayVector = " + copyArrayVector);
            Console.WriteLine(new string('-', 100));

            Vector partialArrayVector = new Vector(8, array);
            Console.WriteLine("partialTestVector = " + partialArrayVector);
            Console.WriteLine("Размерность partialTesVector = " + partialArrayVector.GetSize());
            Console.WriteLine(new string('-', 100));

            Vector firstVector = new Vector(new double[] { 3, 3, 4, 4 });
            Vector secondVector = new Vector(new double[] { 1, 3, 7, 8, 8, 8, 4 });
            Console.WriteLine("Сумма векторов {0} и {1} равна:", firstVector, secondVector);
            firstVector.Sum(secondVector);
            Console.WriteLine(firstVector);
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Разность векторов {0} и {1} равна:", firstVector, secondVector);
            firstVector.Subtract(secondVector);
            Console.WriteLine(firstVector);
            Console.WriteLine(new string('-', 100));

            double scalar = 3;
            Console.WriteLine("Результат умножения вектора {0} на скаляр {1}: ", firstVector, scalar);
            firstVector.MultiplicationByNumber(scalar);
            Console.WriteLine(firstVector);
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Вектор обратный вектору {0}:", firstVector);
            firstVector.Turn();
            Console.WriteLine(firstVector);
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Длина вектора {0} : {1:f2}", firstVector, firstVector.GetLength());
            int componentIndex = 3;
            Console.WriteLine("Компонента вектора {0} по индексу {1} : {2}", firstVector, componentIndex, firstVector.GetComponent(componentIndex));
            double newComponent = 55.6;
            firstVector.SetComponent(componentIndex, newComponent);
            Console.WriteLine("Компонента вектора {0} по индексу {1} : {2}", firstVector, componentIndex, firstVector.GetComponent(componentIndex));
            Console.WriteLine(new string('-', 100));

            if (firstVector.Equals(secondVector))
            {
                Console.WriteLine("Вектор {0} равен вектору {1}", firstVector, secondVector);
            }
            else
            {
                Console.WriteLine("Вектор {0} не равен вектору {1}", firstVector, secondVector);
            }
            Console.WriteLine("hashCode вектора {0}: {1}", firstVector, firstVector.GetHashCode());
            Console.WriteLine("hashCode вектора {0}: {1}", secondVector, secondVector.GetHashCode());
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Сумма векторов {0} и {1} равна: {2}", firstVector, secondVector, Vector.GetSum(firstVector, secondVector));
            Console.WriteLine("Разность векторов {0} и {1} равна: {2}", Vector.GetSum(firstVector, secondVector), firstVector, Vector.GetResidual(Vector.GetSum(firstVector, secondVector), firstVector));
            Console.WriteLine("Скалярное произведение векторов {0} и {1}: {2}", firstVector, secondVector, Vector.GetScalarMultiplication(firstVector, secondVector));
        }
    }
}
