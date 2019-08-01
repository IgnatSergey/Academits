using System;

namespace Matrix
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
            : this(array.Length)
        {
            Array.Copy(array, components, array.Length);
        }

        public Vector(int n, double[] array)
            : this(n)
        {
            if (n > array.Length)
            {
                Array.Copy(array, components, array.Length);
            }
            else
            {
                Array.Copy(array, components, n);
            }
        }

        public int GetSize()
        {
            return components.Length;
        }

        public void GetSum(Vector secondVector)
        {
            int maxDimension = Math.Max(GetSize(), secondVector.GetSize());
            Array.Resize(ref components, maxDimension);
            for (int i = 0; i < maxDimension; i++)
            {
                components[i] = components[i] + secondVector.components[i];
            }
        }

        public void GetResidual(Vector secondVector)
        {
            int maxDimension = Math.Max(GetSize(), secondVector.GetSize());
            Array.Resize(ref components, maxDimension);
            for (int i = 0; i < maxDimension; i++)
            {
                components[i] = components[i] - secondVector.components[i];
            }
        }

        public void GetScalarMultiplication(double scalar)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                components[i] = components[i] * scalar;
            }
        }

        public void TurnVector()
        {
            GetScalarMultiplication(-1);
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
            result.GetSum(secondVector);
            return result;
        }

        public static Vector GetResidual(Vector firstVector, Vector secondVector)
        {
            Vector result = new Vector(firstVector);
            result.GetResidual(secondVector);
            return result;
        }

        public static Vector GetScalarMultiplication(Vector firstVector, Vector secondVector)
        {
            int maxDimension = Math.Max(firstVector.GetSize(), secondVector.GetSize());
            int minDimention = Math.Min(firstVector.GetSize(), secondVector.GetSize());
            Vector resultVector = new Vector(maxDimension);

            for (int i = 0; i < minDimention; i++)
            {
                resultVector.components[i] = firstVector.components[i] * secondVector.components[i];
            }

            return resultVector;
        }
    }
}
