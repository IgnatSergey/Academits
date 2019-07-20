using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits
{
    class Square : IShape
    {
        private static readonly double epsilon;

        public double Width { get; set; }

        static Square()
        {
            epsilon = 1.0e-10;
        }

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
            return Width * 2;
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
            return Math.Abs(this.Width - p.Width) <= epsilon;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            return prime * hash + Width.GetHashCode();
        }
    }
}
