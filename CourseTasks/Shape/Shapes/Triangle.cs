using System;

namespace Shape.Shape
{
    class Triangle : IShape
    {
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double X3 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }

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

        private static double GetSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        public double GetArea()
        {
            double halfPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - GetSideLength(X1, Y1, X2, Y2))
                * (halfPerimeter - GetSideLength(X2, Y2, X3, Y3))
                * (halfPerimeter - GetSideLength(X1, Y1, X3, Y3)));
        }

        public double GetPerimeter()
        {
            return GetSideLength(X1, Y1, X2, Y2) + GetSideLength(X2, Y2, X3, Y3) + GetSideLength(X1, Y1, X3, Y3);
        }

        public override string ToString()
        {
            return $"Координаты первой точки треугольника: [{X1};{Y1}]" + Environment.NewLine
                + $"Координаты второй точки треугольника: [{X2};{Y2}]" + Environment.NewLine
                + $"Координаты третьей точки треугольника: [{X3};{Y3}]";
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
            return X1 == p.X1 && X2 == p.X2 && X3 == p.X3 && Y1 == p.Y1 && Y2 == p.Y2 && Y3 == p.Y3;
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
