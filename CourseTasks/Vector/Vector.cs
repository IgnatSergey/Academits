using System;

namespace Vector
{
    class Vector
    {
        public double[] Components { get; set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должа быть больше 0");
            }
            Components = new double[n];
            for (int i = 0; i < n; i++)
            {
                Components[i] = 0;
            }
        }

        public Vector(Vector secondVector)
        {
            Components = new double[secondVector.Components.Length];
            for (int i = 0; i < secondVector.Components.Length; i++)
            {
                Components[i] = secondVector.Components[i];
            }
        }

        public Vector(double[] array)
        {
            Components = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                Components[i] = array[i];
            }
        }

        public Vector(int n, double[] array)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должа быть больше 0");
            }
            Components = new double[n];
            if (n > array.Length)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Components[i] = array[i];
                }
                for (int i = array.Length + 1; i < n; i++)
                {
                    Components[i] = 0;
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Components[i] = array[i];
                }
            }
        }

        public int GetSize()
        {
            return Components.Length;
        }

        public Vector GetSum(Vector secondVector)
        {
            int maxDimension = GetSize();
            if (maxDimension < secondVector.GetSize())
            {
                maxDimension = secondVector.GetSize();
            }
            Vector copySecondVector = new Vector(maxDimension, secondVector.Components);
            Vector copyFirstVector = new Vector(maxDimension, Components);
            Vector sumVector = new Vector(maxDimension);
            for (int i = 0; i < maxDimension; i++)
            {
                sumVector.Components[i] = copyFirstVector.Components[i] + copySecondVector.Components[i];
            }
            return sumVector;
        }

        public Vector GetResidual(Vector secondVector)
        {
            int maxDimension = GetSize();
            if (maxDimension < secondVector.GetSize())
            {
                maxDimension = secondVector.GetSize();
            }
            Vector copySecondVector = new Vector(maxDimension, secondVector.Components);
            Vector copyFirstVector = new Vector(maxDimension, Components);
            Vector sumVector = new Vector(maxDimension);
            for (int i = 0; i < maxDimension; i++)
            {
                sumVector.Components[i] = copyFirstVector.Components[i] - copySecondVector.Components[i];
            }
            return sumVector;
        }

        public Vector GetScalarMultiplication(double scalar)
        {
            Vector resultVector = new Vector(GetSize());
            for (int i = 0; i < GetSize(); i++)
            {
                resultVector.Components[i] = Components[i] * scalar;
            }
            return resultVector;
        }

        public void GetOpposite()
        {
            for (int i = 0; i < GetSize(); i++)
            {
                Components[i] = Components[i] * (-1);
            }
        }

        public double GetLength()
        {
            double sumSquares = 0;
            for (int i = 0; i < GetSize(); i++)
            {
                sumSquares += Math.Pow(Components[i], 2);
            }
            return Math.Sqrt(sumSquares);
        }

        public double GetComponent(int i)
        {
            if (i < 0 || i >= GetSize())
            {
                throw new ArgumentException("Компоненты с таким индексом нет");
            }
            return Components[i];
        }

        public void SetComponent(int i, double component)
        {
            if (i < 0 || i >= GetSize())
            {
                throw new ArgumentException("Компоненты с таким индексом нет");
            }
            Components[i] = component;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            if (ReferenceEquals(obj, null) || obj.GetType() != this.GetType())
            {
                return false;
            }
            Vector p = (Vector)obj;
            bool IsVectorsEquals = false;
            if (GetSize() == p.GetSize())
            {
                IsVectorsEquals = true;
                for (int i = 0; i < GetSize(); i++)
                {
                    if (Components[i] != p.Components[i])
                    {
                        IsVectorsEquals = false;
                        break;
                    }
                }
            }
            return IsVectorsEquals;
        }

        public override int GetHashCode()
        {
            int prime = 13;
            int hash = 1;
            for (int i = 0; i < GetSize(); i++)
            {
                hash = prime * hash + Components[i].GetHashCode();
            }
            return hash;
        }

        public override string ToString()
        {
            return "{" + string.Join(" ; ", Components) + "}";
        }

        public static Vector GetSum(Vector firstVector, Vector secondVector)
        {
            int maxDimension = firstVector.GetSize();
            if (maxDimension < secondVector.GetSize())
            {
                maxDimension = secondVector.GetSize();
            }
            Vector copySecondVector = new Vector(maxDimension, secondVector.Components);
            Vector copyFirstVector = new Vector(maxDimension, firstVector.Components);
            Vector sumVector = new Vector(maxDimension);
            for (int i = 0; i < maxDimension; i++)
            {
                sumVector.Components[i] = copyFirstVector.Components[i] + copySecondVector.Components[i];
            }
            return sumVector;
        }

        public static Vector GetResidual(Vector firstVector, Vector secondVector)
        {
            int maxDimension = firstVector.GetSize();
            if (maxDimension < secondVector.GetSize())
            {
                maxDimension = secondVector.GetSize();
            }
            Vector copySecondVector = new Vector(maxDimension, secondVector.Components);
            Vector copyFirstVector = new Vector(maxDimension, firstVector.Components);
            Vector sumVector = new Vector(maxDimension);
            for (int i = 0; i < maxDimension; i++)
            {
                sumVector.Components[i] = copyFirstVector.Components[i] - copySecondVector.Components[i];
            }
            return sumVector;
        }

        public static Vector GetScalarMultiplication(Vector firstVector, double scalar)
        {
            Vector resultVector = new Vector(firstVector.GetSize());
            for (int i = 0; i < firstVector.GetSize(); i++)
            {
                resultVector.Components[i] = firstVector.Components[i] * scalar;
            }
            return resultVector;
        }
    }
}
