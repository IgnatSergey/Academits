using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matrix
    {
        private Vector[] matrix;

        public Matrix(int n, int m)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размер столбца должен быть больше 0");
            }

            matrix = new Vector[n];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new Vector(m);
            }
        }

        public Matrix(double[,] array)
        {
            if (array.GetLength(0) == 0)
            {
                throw new ArgumentOutOfRangeException("Размер столбца должен быть больше 0");
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
            if (array.Length == 0)
            {
                throw new ArgumentOutOfRangeException("Размер столбца должен быть больше 0");
            }

            int maxVectorDimention = array[0].GetSize();
            for (int i = 1; i < array.Length; i++)
            {
                if (maxVectorDimention < array[i].GetSize())
                {
                    maxVectorDimention = array[i].GetSize();
                }
            }

            matrix = new Vector[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                double[] arrayVector = new double[maxVectorDimention];
                for (int j = 0; j < array[i].GetSize(); j++)
                {
                    arrayVector[j] = array[i].GetComponent(j);
                }
                matrix[i] = new Vector(maxVectorDimention, arrayVector);
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

        public int GetSize(Dimention directionDimention)
        {
            if (directionDimention == 0)
            {
                return matrix.Length;
            }

            return matrix[0].GetSize();
        }

        public Vector GetLineVector(int index)
        {
            if (index < 0 || index >= matrix.Length)
            {
                throw new IndexOutOfRangeException("Вектора-строки с таким индексом нет");
            }

            return new Vector(matrix[index]);
        }

        public void SetLineVector(int index, Vector userVector)
        {
            if (index < 0 || index >= matrix.Length)
            {
                throw new IndexOutOfRangeException("Вектора-строки с таким индексом нет");
            }
            if (userVector.GetSize() != GetSize(Dimention.LineDimention))
            {
                throw new ArgumentOutOfRangeException("Размер вектора-строки должен совпадать с размером матрицы");
            }

            matrix[index] = new Vector(userVector);
        }

        public Vector GetColumnVector(int index)
        {
            if (index < 0 || index >= matrix[0].GetSize())
            {
                throw new IndexOutOfRangeException("Вектора-столбца с таким индексом нет");
            }

            double[] arrayColumnVector = new double[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                arrayColumnVector[i] = matrix[i].GetComponent(index);
            }

            return new Vector(arrayColumnVector);
        }

        public void TransposeMatrix()
        {
            Matrix copyUserMatrix = new Matrix(this);
            int newLineDimention = GetSize(Dimention.LineDimention);
            Array.Resize(ref matrix, newLineDimention);
            for (int i = 0; i < newLineDimention; i++)
            {
                matrix[i] = new Vector(copyUserMatrix.GetColumnVector(i));
            }
        }

        public void GetScalarMultiplication(double scalar)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i].GetScalarMultiplication(scalar);
            }
        }

        public double GetDeterminant()
        {
            if (GetSize(Dimention.ColumnDimention) != GetSize(Dimention.LineDimention))
            {
                throw new ArgumentOutOfRangeException("Матрица не квадратная");
            }

            if (GetSize(Dimention.LineDimention) == 1)
            {
                return matrix[0].GetComponent(0);
            }
            else if (GetSize(Dimention.LineDimention) == 2)
            {
                return matrix[0].GetComponent(0) * matrix[1].GetComponent(1) - matrix[1].GetComponent(0) * matrix[0].GetComponent(1);
            }

            double determinant = 0;
            for (int i = 0; i < GetSize(Dimention.ColumnDimention); i++)
            {
                double[,] minor = new double[GetSize(Dimention.ColumnDimention) - 1, GetSize(Dimention.ColumnDimention) - 1];
                for (int j = 0; j < GetSize(Dimention.ColumnDimention) - 1; ++j)
                {
                    for (int k = 0; k < GetSize(Dimention.ColumnDimention) - 1; ++k)
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
            if (GetSize(Dimention.LineDimention) != userVector.GetSize())
            {
                throw new ArgumentOutOfRangeException("Число сталбцов в матрице должно совпадать с числом строк в вектор-столбце");
            }

            Matrix copyMatrix = new Matrix(this);
            Array.Resize(ref matrix, userVector.GetSize());
            for (int i = 0; i < userVector.GetSize(); i++)
            {
                double elementResultColumnVector = 0;
                for (int j = 0; j < userVector.GetSize(); j++)
                {
                    elementResultColumnVector += copyMatrix.matrix[i].GetComponent(j) * userVector.GetComponent(j);
                }
                matrix[i] = new Vector(elementResultColumnVector);
            }
        }

        public void SumMatrix(Matrix userMatrix)
        {
            if (GetSize(Dimention.LineDimention) != userMatrix.GetSize(Dimention.LineDimention) || GetSize(Dimention.ColumnDimention) != userMatrix.GetSize(Dimention.ColumnDimention))
            {
                throw new ArgumentOutOfRangeException("Матрицы должны быть одиакого размера");
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i].GetSum(userMatrix.matrix[i]);
            }
        }

        public void SubtractMatrix(Matrix userMatrix)
        {
            if (GetSize(Dimention.LineDimention) != userMatrix.GetSize(Dimention.LineDimention) || GetSize(Dimention.ColumnDimention) != userMatrix.GetSize(Dimention.ColumnDimention))
            {
                throw new ArgumentOutOfRangeException("Матрицы должны быть одиакого размера");
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i].GetResidual(userMatrix.matrix[i]);
            }
        }

        public static Matrix GetSum(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix copyFirstMatrix = new Matrix(firstMatrix);
            copyFirstMatrix.SumMatrix(secondMatrix);
            return copyFirstMatrix;
        }

        public static Matrix GetResidual(Matrix firstMatrix, Matrix secondMatrix)
        {
            Matrix copyFirstMatrix = new Matrix(firstMatrix);
            copyFirstMatrix.SubtractMatrix(secondMatrix);
            return copyFirstMatrix;
        }

        public static Matrix GetMultiplication(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.GetSize(Dimention.LineDimention) != secondMatrix.GetSize(Dimention.ColumnDimention))
            {
                throw new ArgumentOutOfRangeException("Первая матрица должна иметь столько же столбцов сколько строк во второй");
            }

            Matrix result = new Matrix(firstMatrix.GetSize(Dimention.ColumnDimention), secondMatrix.GetSize(Dimention.ColumnDimention));
            for (int k = 0; k < firstMatrix.GetSize(Dimention.ColumnDimention); k++)
            {
                double[] arrayVector = new double[secondMatrix.GetSize(Dimention.LineDimention)];
                Vector multiplicationVectors = new Vector(firstMatrix.GetSize(Dimention.LineDimention));
                for (int j = 0; j < secondMatrix.GetSize(Dimention.LineDimention); j++)
                {
                    multiplicationVectors = Vector.GetScalarMultiplication(firstMatrix.GetLineVector(k), secondMatrix.GetColumnVector(j));
                    double vectorElement = 0;
                    for (int m = 0; m < multiplicationVectors.GetSize(); m++)
                    {
                        vectorElement += multiplicationVectors.GetComponent(m);
                    }
                    arrayVector[j] = vectorElement;
                }
                result.matrix[k] = new Vector(arrayVector);
            }

            return result;
        }
    }
}
