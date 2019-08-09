using System;

namespace Shape.Shapes
{
    class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

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
            return Width == p.Width && Height == p.Height;
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
