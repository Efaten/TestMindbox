using System;

namespace TestMindbox.Geometry
{
    public class Circle : Shape
    {
        private readonly double _radius;
        public double Radius => _radius;

        /// <remarks>
        /// Radius is a positive number.
        /// </remarks>
        /// <exception cref="ArgumentException"></exception>
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException(string.Format("Radius is a positive number, entered {0}", radius));

            _radius = radius;
        }

        protected override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
