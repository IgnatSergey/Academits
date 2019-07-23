using System;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Vector zerowVector = new Vector(6);
                Console.WriteLine("zerowVector = " + zerowVector);

                double[] array = { 3, 3.75, 2, 44, -5 };
                Vector testVector = new Vector(array);
                Vector copyTestVector = new Vector(testVector);
                Console.WriteLine("testVector = " + testVector);
                Console.WriteLine("copyTestVector = " + copyTestVector);

                Vector partialTestVector = new Vector(15, array);
                Console.WriteLine("partialTestVector = " + partialTestVector);
                Console.WriteLine("Размерность partialTesVector = " + partialTestVector.GetSize());

                Vector firstVector = new Vector(new double[] { 3, 3, 4, 4 });
                Console.WriteLine("Сумма векторов {0} и {1} равна: {2}", firstVector, testVector, firstVector.GetSum(testVector));
                Console.WriteLine("Разность векторов {0} и {1} равна: {2}", firstVector.GetSum(testVector), testVector, firstVector.GetSum(testVector).GetResidual(testVector));
                Console.WriteLine("Результат умножения вектора {0} на скаляр {1}: {2}", firstVector, 3, firstVector.GetScalarMultiplication(3));

                Console.Write("Вектор обратный вектору {0}:", firstVector);
                firstVector.GetOpposite();
                Console.WriteLine(firstVector);

                Console.WriteLine("Длина вектора {0} : {1:f2}", firstVector, firstVector.GetLength());

                Console.WriteLine("Компонента вектора {0} по индексу {1} : {2}", firstVector, 3, firstVector.GetComponent(3));
                firstVector.SetComponent(3, 55.6);
                Console.WriteLine("Компонента вектора {0} по индексу {1} : {2}", firstVector, 3, firstVector.GetComponent(3));

                Vector secondVector = new Vector(new double[] { -3, -3, -4, -5, 0, 0 });
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


                Console.WriteLine("Сумма векторов {0} и {1} равна: {2}", firstVector, secondVector, Vector.GetSum(firstVector, secondVector));
                Console.WriteLine("Разность векторов {0} и {1} равна: {2}", Vector.GetSum(firstVector, secondVector), firstVector, Vector.GetResidual(Vector.GetSum(firstVector, secondVector), firstVector));
                Console.WriteLine("Результат умножения вектора {0} на скаляр {1}: {2}", firstVector, 3, Vector.GetScalarMultiplication(firstVector, 3));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
