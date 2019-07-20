using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits
{
    class Circle : IShape
    {
        private static readonly double epsilon;

        public double Radius { get; set; }

        static Circle()
        {
            epsilon = 1.0e-10;
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetWidth()
        {
            return Radius * 2;
        }

        public double GetHeight()
        {
            return Radius * 2;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return "Радиус круга: " + Radius;
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
            Circle p = (Circle)obj;
            return Math.Abs(this.Radius - p.Radius) <= epsilon;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            return prime * hash + Radius.GetHashCode();
        }
    }
}
