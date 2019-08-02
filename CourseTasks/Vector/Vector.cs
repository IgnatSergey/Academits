using System;

namespace Vectors
{
    public class Vector
    {
        private double[] components;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должа быть больше 0");
            }

            components = new double[n];
        }

        public Vector(Vector secondVector)
            : this(secondVector.components)
        {
        }

        public Vector(params double[] array)
        {
            components = new double[array.Length];
            Array.Copy(array, components, array.Length);
        }

        public Vector(int n, double[] array)
        {
            components = new double[n];
            int minDimension = Math.Min(n, array.Length);
            Array.Copy(array, components, minDimension);
        }

        public int GetSize()
        {
            return components.Length;
        }

        public void Sum(Vector secondVector)
        {
            int maxDimension = Math.Max(GetSize(), secondVector.GetSize());
            Array.Resize(ref components, maxDimension);
            for (int i = 0; i < secondVector.GetSize(); i++)
            {
                components[i] += secondVector.components[i];
            }
        }

        public void Subtract(Vector secondVector)
        {
            int maxDimension = Math.Max(GetSize(), secondVector.GetSize());
            Array.Resize(ref components, maxDimension);
            for (int i = 0; i < secondVector.GetSize(); i++)
            {
                components[i] -= secondVector.components[i];
            }
        }

        public void MultiplicationByNumber(double scalar)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                components[i] *= scalar;
            }
        }

        public void Turn()
        {
            MultiplicationByNumber(-1);
        }

        public double GetLength()
        {
            double sumSquares = 0;
            foreach (double e in components)
            {
                sumSquares += Math.Pow(e, 2);
            }

            return Math.Sqrt(sumSquares);
        }

        public double GetComponent(int i)
        {
            if (i < 0 || i >= GetSize())
            {
                throw new IndexOutOfRangeException("Компоненты с таким индексом нет");
            }

            return components[i];
        }

        public void SetComponent(int i, double component)
        {
            if (i < 0 || i >= GetSize())
            {
                throw new IndexOutOfRangeException("Компоненты с таким индексом нет");
            }

            components[i] = component;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Vector p = (Vector)obj;
            if (GetSize() == p.GetSize())
            {
                for (int i = 0; i < GetSize(); i++)
                {
                    if (components[i] != p.components[i])
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int prime = 13;
            int hash = 1;

            foreach (double e in components)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }

        public override string ToString()
        {
            return "{" + string.Join(" ; ", components) + "}";
        }

        public static Vector GetSum(Vector firstVector, Vector secondVector)
        {
            Vector result = new Vector(firstVector);
            result.Sum(secondVector);
            return result;
        }

        public static Vector GetResidual(Vector firstVector, Vector secondVector)
        {
            Vector result = new Vector(firstVector);
            result.Subtract(secondVector);
            return result;
        }

        public static double GetScalarMultiplication(Vector firstVector, Vector secondVector)
        {
            int minDimension = Math.Min(firstVector.GetSize(), secondVector.GetSize());
            double result = 0;

            for (int i = 0; i < minDimension; i++)
            {
                result += firstVector.components[i] * secondVector.components[i];
            }

            return result;
        }
    }
}
