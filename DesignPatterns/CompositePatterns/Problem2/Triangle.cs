using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CompositePatterns.Problem2
{
    public class Triangle : IShape
    {
        private double baseLength;
        private double height;
        public Triangle(double baseLength, double height)
        {
            this.baseLength = baseLength;
            this.height = height;
        }

        public double getArea()
        {
            return 0.5 * baseLength * height;
        }

        public double getPerimeter()
        {
          double h = Math.Sqrt(baseLength*baseLength + height*height);

          return baseLength + height + h;
        }
    }
}
