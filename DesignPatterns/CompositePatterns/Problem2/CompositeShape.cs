using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CompositePatterns.Problem2
{
    public class CompositeShape : IShape
    {
        private IList<IShape> shapes;
        public CompositeShape()
        {
            this.shapes = new List<IShape>();   
        }
        public double getArea()
        {
            double area = 0;
            foreach(var shape in this.shapes) {
                area += shape.getArea();
            }
            return area;
        }
        public double getPerimeter()
        {
            double perimeter = 0;
            foreach (var shape in this.shapes)
            {
               perimeter += shape.getPerimeter();
            }
            return perimeter;
        }
        public void Add(IShape shape)
        {
            this.shapes.Add(shape);
        }
        public void Remove(IShape shape)
        {
            this.shapes.Remove(shape);
        }
    }
}
