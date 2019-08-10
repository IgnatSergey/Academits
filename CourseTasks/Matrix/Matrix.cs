using System;
using System.Text;
using Vectors;

namespace Matrix
{
    class Matrix
    {
        private Vector[] vectorsArray;

        public Matrix(int rowsAmount, int columnsAmount)
        {
            if (rowsAmount <= 0 || columnsAmount <= 0)
            {
                throw new ArgumentException("Размеры матрицы должны быть больше 0");
            }

            vectorsArray = new Vector[rowsAmount];
            for (int i = 0; i < rowsAmount; i++)
            {
                vectorsArray[i] = new Vector(columnsAmount);
            }
        }

        public Matrix(double[,] array)
        {
            if (array.GetLength(0) == 0 || array.GetLength(1) == 0)
            {
                throw new ArgumentOutOfRangeException("Размеры матрицы должны быть больше 0");
            }

            vectorsArray = new Vector[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                double[] arrayVector = new double[array.GetLength(1)];
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    arrayVector[j] = array[i, j];
                }
                vectorsArray[i] = new Vector(arrayVector);
            }
        }

        public Matrix(Vector[] array)
        {
            if (array.Length == 0)
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

            vectorsArray = new Vector[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                double[] arrayVector = new double[array[i].GetSize()];
                for (int j = 0; j < array[i].GetSize(); j++)
                {
                    arrayVector[j] = array[i].GetComponent(j);
                }
                vectorsArray[i] = new Vector(maxVectorDimension, arrayVector);
            }
        }

        public Matrix(Matrix userMatrix)
        {
            vectorsArray = new Vector[userMatrix.vectorsArray.Length];
            for (int i = 0; i < userMatrix.vectorsArray.Length; i++)
            {
                vectorsArray[i] = new Vector(userMatrix.vectorsArray[i]);
            }
        }

        public override string ToString()
        {
            StringBuilder linesMatrix = new StringBuilder();
            string firstLineMatrix = "{" + vectorsArray[0].ToString() + ",";
            string lastLineMatrix = vectorsArray[GetRowsAmount() - 1].ToString() + "}";

            linesMatrix.Append(firstLineMatrix);
            for (int i = 1; i < GetRowsAmount() - 1; i++)
            {
                linesMatrix.Append(vectorsArray[i])
                .Append(",");
            }

            return linesMatrix.Append(lastLineMatrix).ToString();
        }

        public int GetRowsAmount()
        {
            return vectorsArray.Length;
        }

        public int GetColumnsAmount()
        {
            return vectorsArray[0].GetSize();
        }

        public Vector GetRow(int index)
        {
            if (index < 0 || index >= GetRowsAmount())
            {
                throw new IndexOutOfRangeException("Вектора-строки с таким индексом нет");
            }

            return new Vector(vectorsArray[index]);
        }

        public void SetRow(int index, Vector userVector)
        {
            if (index < 0 || index >= GetRowsAmount())
            {
                throw new IndexOutOfRangeException("Вектора-строки с таким индексом нет");
            }

            if (userVector.GetSize() != GetColumnsAmount())
            {
                throw new ArgumentOutOfRangeException("Размер вектора-строки должен совпадать с размером матрицы");
            }

            vectorsArray[index] = new Vector(userVector);
        }

        public Vector GetColumn(int index)
        {
            if (index < 0 || index >= GetColumnsAmount())
            {
                throw new IndexOutOfRangeException("Вектора-столбца с таким индексом нет");
            }

            double[] arrayColumnVector = new double[GetRowsAmount()];
            for (int i = 0; i < GetRowsAmount(); i++)
            {
                arrayColumnVector[i] = vectorsArray[i].GetComponent(index);
            }

            return new Vector(arrayColumnVector);
        }

        public void Transpose()
        {
            Matrix copyUserMatrix = new Matrix(this);
            int newRowSize = GetColumnsAmount();
            Array.Resize(ref vectorsArray, newRowSize);

            for (int i = 0; i < newRowSize; i++)
            {
                vectorsArray[i] = new Vector(copyUserMatrix.GetColumn(i));
            }
        }

        public void MultiplicationByNumber(double scalar)
        {
            foreach (Vector e in vectorsArray)
            {
                e.MultiplicationByNumber(scalar);
            }
        }

        public double GetDeterminant()
        {
            if (GetRowsAmount() != GetColumnsAmount())
            {
                throw new ArgumentOutOfRangeException("Матрица не квадратная");
            }

            if (GetColumnsAmount() == 1)
            {
                return vectorsArray[0].GetComponent(0);
            }
            else if (GetColumnsAmount() == 2)
            {
                return vectorsArray[0].GetComponent(0) * vectorsArray[1].GetComponent(1) - vectorsArray[1].GetComponent(0) * vectorsArray[0].GetComponent(1);
            }

            double determinant = 0;
            for (int i = 0; i < GetRowsAmount(); i++)
            {
                double[,] minor = new double[GetRowsAmount() - 1, GetRowsAmount() - 1];
                for (int j = 0; j < GetRowsAmount() - 1; ++j)
                {
                    for (int k = 0; k < GetRowsAmount() - 1; ++k)
                    {
                        if (k >= i)
                        {
                            minor[j, k] = vectorsArray[j + 1].GetComponent(k + 1);
                        }
                        else
                        {
                            minor[j, k] = vectorsArray[j + 1].GetComponent(k);
                        }
                    }
                }
                determinant += Math.Pow(-1, i) * vectorsArray[0].GetComponent(i) * new Matrix(minor).GetDeterminant();
            }

            return determinant;
        }

        public Vector MultiplicationByColumnVector(Vector userVector)
        {
            if (GetColumnsAmount() != userVector.GetSize())
            {
                throw new ArgumentOutOfRangeException("Число сталбцов в матрице должно совпадать с числом строк в вектор-столбце");
            }

            double[] arrayVector = new double[GetRowsAmount()];
            for (int i = 0; i < GetRowsAmount(); i++)
            {
                arrayVector[i] = Vector.GetScalarMultiplication(GetRow(i), userVector);
            }

            return new Vector(arrayVector);
        }

        public void Sum(Matrix userMatrix)
        {
            if (GetColumnsAmount() != userMatrix.GetColumnsAmount() || GetRowsAmount() != userMatrix.GetRowsAmount())
            {
                throw new ArgumentOutOfRangeException("Матрицы должны быть одиакого размера");
            }

            for (int i = 0; i < GetRowsAmount(); i++)
            {
                vectorsArray[i].Sum(userMatrix.vectorsArray[i]);
            }
        }

        public void Subtract(Matrix userMatrix)
        {
            if (GetColumnsAmount() != userMatrix.GetColumnsAmount() || GetRowsAmount() != userMatrix.GetRowsAmount())
            {
                throw new ArgumentOutOfRangeException("Матрицы должны быть одиакого размера");
            }

            for (int i = 0; i < vectorsArray.Length; i++)
            {
                vectorsArray[i].Subtract(userMatrix.vectorsArray[i]);
            }
        }

        public static Matrix GetSum(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.GetColumnsAmount() != secondMatrix.GetColumnsAmount() || firstMatrix.GetRowsAmount() != secondMatrix.GetRowsAmount())
            {
                throw new ArgumentOutOfRangeException("Матрицы должны быть одиакого размера");
            }

            Matrix copyFirstMatrix = new Matrix(firstMatrix);
            copyFirstMatrix.Sum(secondMatrix);
            return copyFirstMatrix;
        }

        public static Matrix GetResidual(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.GetColumnsAmount() != secondMatrix.GetColumnsAmount() || firstMatrix.GetRowsAmount() != secondMatrix.GetRowsAmount())
            {
                throw new ArgumentOutOfRangeException("Матрицы должны быть одиакого размера");
            }

            Matrix copyFirstMatrix = new Matrix(firstMatrix);
            copyFirstMatrix.Subtract(secondMatrix);
            return copyFirstMatrix;
        }

        public static Matrix GetMultiplication(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.GetColumnsAmount() != secondMatrix.GetRowsAmount())
            {
                throw new ArgumentOutOfRangeException("Первая матрица должна иметь столько же столбцов сколько строк во второй");
            }

            Matrix result = new Matrix(firstMatrix.GetRowsAmount(), secondMatrix.GetColumnsAmount());
            for (int i = 0; i < firstMatrix.GetRowsAmount(); i++)
            {
                double[] arrayVector = new double[secondMatrix.GetColumnsAmount()];
                for (int j = 0; j < secondMatrix.GetColumnsAmount(); j++)
                {
                    arrayVector[j] = Vector.GetScalarMultiplication(firstMatrix.GetRow(i), secondMatrix.GetColumn(j)); ;
                }
                result.vectorsArray[i] = new Vector(arrayVector);
            }

            return result;
        }
    }
}
