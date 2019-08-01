using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix zerowMatrix = new Matrix(2, 4);
            Console.WriteLine("zerowMatrix = " + zerowMatrix);
            Console.WriteLine(new string('-', 100));

            double[,] array =
            {
                {2, 3, 4 },
                {3, 4, 3 }
            };
            Matrix arrayMatrix = new Matrix(array);
            Console.WriteLine("arrayMatrix = " + arrayMatrix);
            Console.WriteLine(new string('-', 100));

            Vector[] arrayVector =
            {
                new Vector(1),
                new Vector(3, 4, 5, 5, 7, 10),
                new Vector(3, 7, 45)
            };
            Matrix arrayVectorMatrix = new Matrix(arrayVector);
            Console.WriteLine("arrayVectorMatrix = " + arrayVectorMatrix);
            Matrix copyArrayVectorMatrix = new Matrix(arrayVectorMatrix);
            Console.WriteLine("copyArrayVectorMatrix = " + copyArrayVectorMatrix);
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Размеры матрицы {0}: ({1}*{2})", arrayVectorMatrix, arrayVectorMatrix.GetSize(Dimention.ColumnDimention), arrayVectorMatrix.GetSize(Dimention.LineDimention));
            Console.WriteLine(new string('-', 100));

            int index = 2;
            Console.WriteLine("Вектор-строка матрицы {0} под индексом {1}: {2}", arrayVectorMatrix, index, arrayVectorMatrix.GetLineVector(index));
            Vector userVector = new Vector(3, 4, 2, 55, 77, 0);
            arrayVectorMatrix.SetLineVector(index, userVector);
            Console.WriteLine("Вектор-строка матрицы {0} под индексом {1}: {2}", arrayVectorMatrix, index, arrayVectorMatrix.GetLineVector(index));
            int indexColumnVector = 4;
            Console.WriteLine("Вектор-столбец матрицы {0} под индексом {1}: {2}", arrayVectorMatrix, indexColumnVector, arrayVectorMatrix.GetColumnVector(indexColumnVector));
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("arrayVectorMatrix = {0}", arrayVectorMatrix);
            arrayVectorMatrix.TransposeMatrix();
            Console.WriteLine("Транспонированная arrayVectorMatrix = {0}", arrayVectorMatrix);
            Console.WriteLine(new string('-', 100));

            arrayVectorMatrix.TransposeMatrix();
            double scalar = 2;
            Console.WriteLine("Произведение матрицы {0} на скаляр {1} = ", arrayVectorMatrix, scalar);
            arrayVectorMatrix.GetScalarMultiplication(scalar);
            Console.WriteLine(arrayVectorMatrix);
            Console.WriteLine(new string('-', 100));

            Vector[] arrayTestVector =
            {
                new Vector(1 , 3, 3.4, 6),
                new Vector(3, 4, 5, 5),
                new Vector(3, 7, 45, 100),
                new Vector(1, 3.4, 55, 4)
            };
            Matrix arrayTestVectorMatrix = new Matrix(arrayTestVector);
            Console.WriteLine("Определитель матрицы {0} : {1}", arrayTestVectorMatrix, arrayTestVectorMatrix.GetDeterminant());
            Console.WriteLine(new string('-', 100));

            Vector columnVector = new Vector(3, 5, 4, 6);
            Console.WriteLine("Результат умножения матрицы {0} на вектор-столбец {1}:", arrayTestVectorMatrix, columnVector);
            arrayTestVectorMatrix.MultiplicationByColumnVector(columnVector);
            Console.WriteLine(arrayTestVectorMatrix);
            Console.WriteLine(new string('-', 100));

            Vector[] firstArrayVector =
            {
                new Vector(1 , 3, 3.4, 6),
                new Vector(3, 4, 5, 5),
                new Vector(3, 7, 45, 100),
            };
            Vector[] secondArrayVector =
 {
                new Vector(-1, 6, 8, -10),
                new Vector(3, 4, 5, 5),
                new Vector(44, 3.4, -5, 8),
            };
            Matrix firstArrayVectorMatrix = new Matrix(firstArrayVector);
            Matrix secondArrayVectorMatrix = new Matrix(secondArrayVector);
            Console.WriteLine("Результат сложения матрицы {0} и матрицы {1}:", firstArrayVectorMatrix, secondArrayVectorMatrix);
            firstArrayVectorMatrix.SumMatrix(secondArrayVectorMatrix);
            Console.WriteLine(firstArrayVectorMatrix);

            Console.WriteLine("Результат вычитания матрицы {0} из матрицы {1}:", secondArrayVector, firstArrayVectorMatrix);
            firstArrayVectorMatrix.SubtractMatrix(secondArrayVectorMatrix);
            Console.WriteLine(firstArrayVectorMatrix);
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Результат сложения матрицы {0} и матрицы {1}: {2}", firstArrayVectorMatrix, secondArrayVectorMatrix, Matrix.GetSum(firstArrayVectorMatrix, secondArrayVectorMatrix));
            Console.WriteLine("Результат вычитания матрицы {0} из матрицы {1}: {2}", firstArrayVectorMatrix, secondArrayVectorMatrix, Matrix.GetResidual(firstArrayVectorMatrix, secondArrayVectorMatrix));
            Console.WriteLine(new string('-', 100));

            Vector[] firstTestArrayVector =
            {
                new Vector(1 , 3, 3.4, 6),
                new Vector(3, 4, 5, 5),
                new Vector(3, 7, 45, 100),
            };
            Vector[] secondTestArrayVector =
 {
                new Vector(-1, 6, 8, -10),
                new Vector(3, 4, 5, 5),
                new Vector(44, 3.4, -5, 8),
                new Vector(3, 7, 5, 6)
            };
            Matrix firstTestArrayVectorMatrix = new Matrix(firstTestArrayVector);
            Matrix secondTestArrayVectorMatrix = new Matrix(secondTestArrayVector);
            Console.WriteLine("Результат умножения матрицы {0} на матрицу {1}: {2}", firstTestArrayVectorMatrix, secondTestArrayVectorMatrix, Matrix.GetMultiplication(firstTestArrayVectorMatrix, secondTestArrayVectorMatrix));
        }
    }
}
