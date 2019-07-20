using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits
{
    class Rectangle : IShape
    {
        private static readonly double epsilon;

        public double Width { get; set; }
        public double Height { get; set; }

        static Rectangle()
        {
            epsilon = 1.0e-10;
        }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public double GetPerimeter()
        {
            return Width * 2 + Height * 2;
        }

        public override string ToString()
        {
            return "Ширина прямлугольника: " + Width + Environment.NewLine + "Высота прямлугольника: " + Height;
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
            Rectangle p = (Rectangle)obj;
            return Math.Abs(this.Width - p.Width) <= epsilon && Math.Abs(this.Height - p.Height) <= epsilon;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + Width.GetHashCode();
            return prime * hash + Height.GetHashCode();
        }
    }
}
