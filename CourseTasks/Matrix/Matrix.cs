using System;
using System.Text;
using Vectors;

namespace Matrix
{
    class Matrix
    {
        private Vector[] matrix;

        public Matrix(int n, int m)
        {
            if (n <= 0 || m <= 0)
            {
                throw new ArgumentException("Размеры матрицы должны быть больше 0");
            }

            matrix = new Vector[n];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new Vector(m);
            }
        }

        public Matrix(double[,] array)
        {
            if (array.GetLength(0) == 0 || array.GetLength(1) == 0)
            {
                throw new ArgumentOutOfRangeException("Размеры матрицы должны быть больше 0");
            }

            matrix = new Vector[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                double[] arrayVector = new double[array.GetLength(1)];
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    arrayVector[j] = array[i, j];
                }
                matrix[i] = new Vector(arrayVector);
            }
        }

        public Matrix(Vector[] array)
        {
            if (array.Length == 0 || array[0].GetSize() == 0)
            {
                throw new ArgumentOutOfRangeException("Размеры матрицы должны быть больше 0");
            }

            int maxVectorDimension = array[0].GetSize();
            for (int i = 1; i < array.Length; i++)
            {
                if (maxVectorDimension < array[i].GetSize())
                {
                    maxVectorDimension = array[i].GetSize();
                }
            }

            matrix = new Vector[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                double[] arrayVector = new double[array[i].GetSize()];
                for (int j = 0; j < array[i].GetSize(); j++)
                {
                    arrayVector[j] = array[i].GetComponent(j);
                }
                matrix[i] = new Vector(maxVectorDimension, arrayVector);
            }
        }

        public Matrix(Matrix userMatrix)
        {
            matrix = new Vector[userMatrix.matrix.Length];
            for (int i = 0; i < userMatrix.matrix.Length; i++)
            {
                matrix[i] = new Vector(userMatrix.matrix[i]);
            }
        }

        public override string ToString()
        {
            StringBuilder lineMatrix = new StringBuilder("{");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                lineMatrix.Append(matrix[i] + ",");
            }

            return lineMatrix.ToString().Remove(lineMatrix.Length - 1, 1) + "}";
        }

        public int GetColumnSize()
        {
            return matrix.Length;
        }

        public int GetLineSize()
        {
            return matrix[0].GetSize();
        }

        public Vector GetLineVector(int index)
        {
            if (index < 0 || index >= GetColumnSize())
            {
                throw new IndexOutOfRangeException("Вектора-строки с таким индексом нет");
            }

            return new Vector(matrix[index]);
        }

        public void SetLineVector(int index, Vector userVector)
        {
            if (index < 0 || index >= GetColumnSize())
            {
                throw new IndexOutOfRangeException("Вектора-строки с таким индексом нет");
            }

            if (userVector.GetSize() != GetLineSize())
            {
                throw new ArgumentOutOfRangeException("Размер вектора-строки должен совпадать с размером матрицы");
            }

            matrix[index] = new Vector(userVector);
        }

        public Vector GetColumnVector(int index)
        {
            if (index < 0 || index >= GetLineSize())
            {
                throw new IndexOutOfRangeException("Вектора-столбца с таким индексом нет");
            }

            double[] arrayColumnVector = new double[GetColumnSize()];
            for (int i = 0; i < GetColumnSize(); i++)
            {
                arrayColumnVector[i] = matrix[i].GetComponent(index);
            }

            return new Vector(arrayColumnVector);
        }

        public void Transpose()
        {
            Matrix copyUserMatrix = new Matrix(this);
            int newLineSize = GetLineSize();
            Array.Resize(ref matrix, newLineSize);

            for (int i = 0; i < newLineSize; i++)
            {
                matrix[i] = new Vector(copyUserMatrix.GetColumnVector(i));
            }
        }

        public void MultiplicationByNumber(double scalar)
        {
            for (int i = 0; i < GetColumnSize(); i++)
            {
                matrix[i].MultiplicationByNumber(scalar);
            }
        }

        public double GetDeterminant()
        {
            if (GetColumnSize() != GetLineSize())
            {
                throw new ArgumentOutOfRangeException("Матрица не квадратная");
            }

            if (GetLineSize() == 1)
            {
                return matrix[0].GetComponent(0);
            }
            else if (GetLineSize() == 2)
            {
                return matrix[0].GetComponent(0) * matrix[1].GetComponent(1) - matrix[1].GetComponent(0) * matrix[0].GetComponent(1);
            }

            double determinant = 0;
            for (int i = 0; i < GetColumnSize(); i++)
            {
                double[,] minor = new double[GetColumnSize() - 1, GetColumnSize() - 1];
                for (int j = 0; j < GetColumnSize() - 1; ++j)
                {
                    for (int k = 0; k < GetColumnSize() - 1; ++k)
                    {
                        if (k >= i)
                        {
                            minor[j, k] = matrix[j + 1].GetComponent(k + 1);
                        }
                        else
                        {
                            minor[j, k] = matrix[j + 1].GetComponent(k);
                        }
                    }
                }
                determinant += Math.Pow(-1, i) * matrix[0].GetComponent(i) * new Matrix(minor).GetDeterminant();
            }

            return determinant;
        }

        public void MultiplicationByColumnVector(Vector userVector)
        {
            if (GetLineSize() != userVector.GetSize())
            {
                throw new ArgumentOutOfRangeException("Число сталбцов в матрице должно совпадать с числом строк в вектор-столбце");
            }

            Matrix copyMatrix = new Matrix(this);
            Array.Resize(ref matrix, GetColumnSize());
            for (int i = 0; i < GetColumnSize(); i++)
            {
                double elementColumnVector = 0;
                for (int j = 0; j < userVector.GetSize(); j++)
                {
                    elementColumnVector += copyMatrix.matrix[i].GetComponent(j) * userVector.GetComponent(j);
                }
                matrix[i] = new Vector(elementColumnVector);
            }
        }

        public void Sum(Matrix userMatrix)
        {
            if (GetLineSize() != userMatrix.GetLineSize() || GetColumnSize() != userMatrix.GetColumnSize())
            {
                throw new ArgumentOutOfRangeException("Матрицы должны быть одиакого размера");
            }

            for (int i = 0; i < GetColumnSize(); i++)
            {
                matrix[i].Sum(userMatrix.matrix[i]);
            }
        }

        public void Subtract(Matrix userMatrix)
        {
            if (GetLineSize() != userMatrix.GetLineSize() || GetColumnSize() != userMatrix.GetColumnSize())
            {
                throw new ArgumentOutOfRangeException("Матрицы должны быть одиакого размера");
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i].Subtract(userMatrix.matrix[i]);
            }
        }

        public static Matrix GetSum(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix copyFirstMatrix = new Matrix(firstMatrix);
            copyFirstMatrix.Sum(secondMatrix);
            return copyFirstMatrix;
        }

        public static Matrix GetResidual(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix copyFirstMatrix = new Matrix(firstMatrix);
            copyFirstMatrix.Subtract(secondMatrix);
            return copyFirstMatrix;
        }

        public static Matrix GetMultiplication(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.GetLineSize() != secondMatrix.GetColumnSize())
            {
                throw new ArgumentOutOfRangeException("Первая матрица должна иметь столько же столбцов сколько строк во второй");
            }

            Matrix result = new Matrix(firstMatrix.GetColumnSize(), secondMatrix.GetLineSize());
            for (int i = 0; i < firstMatrix.GetColumnSize(); i++)
            {
                double[] arrayVector = new double[secondMatrix.GetLineSize()];
                for (int j = 0; j < secondMatrix.GetLineSize(); j++)
                {
                    arrayVector[j] = Vector.GetScalarMultiplication(firstMatrix.GetLineVector(i), secondMatrix.GetColumnVector(j)); ;
                }
                result.matrix[i] = new Vector(arrayVector);
            }

            return result;
        }
    }
}
