using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits
{
    class Triangle : IShape
    {
        private static readonly double epsilon;

        public double X1 { get; set; }
        public double X2 { get; set; }
        public double X3 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }

        static Triangle()
        {
            epsilon = 1.0e-10;
        }

        public Triangle(double x1, double x2, double x3, double y1, double y2, double y3)
        {
            X1 = x1;
            X2 = x2;
            X3 = x3;
            Y1 = y1;
            Y2 = y2;
            Y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(Y1, Y2), Y3) - Math.Min(Math.Min(Y1, Y2), Y3);
        }

        public double GetArea()
        {
            double sideALength = Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));
            double sideBLength = Math.Sqrt(Math.Pow(X2 - X3, 2) + Math.Pow(Y2 - Y3, 2));
            double sideCLength = Math.Sqrt(Math.Pow(X1 - X3, 2) + Math.Pow(Y1 - Y3, 2));
            double halfPerimeter = (sideALength + sideBLength + sideCLength) / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - sideALength) * (halfPerimeter - sideBLength) * (halfPerimeter - sideCLength));
        }

        public double GetPerimeter()
        {
            double sideALength = Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));
            double sideBLength = Math.Sqrt(Math.Pow(X2 - X3, 2) + Math.Pow(Y2 - Y3, 2));
            double sideCLength = Math.Sqrt(Math.Pow(X1 - X3, 2) + Math.Pow(Y1 - Y3, 2));
            return sideALength + sideBLength + sideCLength;
        }

        public override string ToString()
        {
            return $"Координаты первой точки треугольника: [{X1};{Y1}]" + Environment.NewLine + $"Координаты второй точки треугольника: [{X2};{Y2}]" + Environment.NewLine + $"Координаты третьей точки треугольника: [{X3};{Y3}]";
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
            Triangle p = (Triangle)obj;
            return Math.Abs(this.X1 - p.X1) <= epsilon && Math.Abs(this.X2 - p.X2) <= epsilon && Math.Abs(this.X3 - p.X3) <= epsilon && Math.Abs(this.Y1 - p.Y1) <= epsilon && Math.Abs(this.Y2 - p.Y2) <= epsilon && Math.Abs(this.Y3 - p.Y3) <= epsilon;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            return prime * hash + Y3.GetHashCode();
        }
    }
}
