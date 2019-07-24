using System;

namespace Shape
{
    class Square : IShape
    {
        private static readonly double epsilon;

        public double Width { get; set; }

        public Square(double width)
        {
            Width = width;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetHeight()
        {
            return Width;
        }

        public double GetArea()
        {
            return Math.Pow(Width, 2);
        }

        public double GetPerimeter()
        {
            return Width * 4;
        }

        public override string ToString()
        {
            return "Сторона квадрата: " + Width;
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
            Square p = (Square)obj;
            return Width == p.Width;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            return prime * hash + Width.GetHashCode();
        }
    }
}
