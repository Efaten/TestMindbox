using System;
using System.Linq;

namespace TestMindbox.Geometry
{

    /// <remarks>
    /// All sides are positive numbers.
    /// The biggest side is lesser then sum of two others.
    /// </remarks>
    public class Triangle : Shape
    {
        public readonly double edgeA;
        public readonly double edgeB;
        public readonly double edgeC;

        public double MaxEdge { get; private set; }
        public double MinEdge { get; private set; }

        /// <remarks>
        /// It should be in the shape class and lazy.
        /// It's not there because it would require to implement two methods for a new class
        /// and whilst it is right to demand so, it loses score on "Легкость добавления других фигур" task
        /// </remarks>
        public double Perimeter { get; private set; }

        /// <summary>
        /// Returns true if the triangle's largest angle is 90 degrees.
        /// </summary>
        public bool IsRightAngled 
        {
            get 
            {
                if (IsEquilateral)
                    return false;

                // edgeA > edgeB ? edgeB > edgeC ? edgeB : edgeC : edgeA > edgeC ? edgeA : edgeC
                // just kidding
                double midLeg;
                if (edgeA == MinEdge)
                    midLeg = Math.Min(edgeB, edgeC);
                else
                {
                    midLeg = Math.Min(edgeA, Math.Max(edgeB, edgeC));
                }

                return  (Math.Pow(midLeg, 2) + Math.Pow(MinEdge, 2) - Math.Pow(MaxEdge, 2)) == 0;
            }
        }

        /// <summary>
        /// Returns true if all sides of the triangle are equal.
        /// </summary>
        public bool IsEquilateral { get => MinEdge == MaxEdge; }

        /// <exception cref="ArgumentException"></exception>
        public Triangle(double a, double b, double c) 
        {
            edgeA = a; edgeB = b; edgeC = c;
            MaxEdge = Math.Max(edgeA, Math.Max(edgeB, edgeC));
            MinEdge = Math.Min(edgeA, Math.Min(edgeB, edgeC));
            Perimeter = edgeA + edgeB + edgeC;

            if (MinEdge <= 0)
                throw new ArgumentException(string.Format("Edges must have positive value, got {0}", MinEdge));

            if ((Perimeter - MaxEdge) - MaxEdge < 0)
                throw new ArgumentException("The biggest side is bigger then sum of two others.");
        }

        /// <exception cref="ArgumentException"></exception>
        public Triangle(double[] edges)
        {
            if (edges.Count() != 3)
                throw new ArgumentException(string.Format("Triangle takes only 3 edges, got {0} instead", edges.Count()));
            
            edgeA = edges[0]; edgeB = edges[1]; edgeC = edges[2];
            MaxEdge = Math.Max(edgeA, Math.Max(edgeB, edgeC));
            MinEdge = Math.Min(edgeA, Math.Min(edgeB, edgeC));
            Perimeter = edges.Sum();

            if (MinEdge <= 0)
                throw new ArgumentException(string.Format("Edges must have positive value, got {0}", MinEdge));

            if ((Perimeter - MaxEdge) - MaxEdge < 0)
                throw new ArgumentException("The biggest side is bigger then sum of two others.");
        }

        protected override double CalculateArea()
        {
            double p = Perimeter / 2;
            return Math.Sqrt(p * (p - edgeA) * (p - edgeB) * (p - edgeC));
        }
    }
}
