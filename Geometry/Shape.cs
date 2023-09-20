using System;

namespace TestMindbox.Geometry
{
    /// <remarks>
    /// DISCLAIMER 
    /// artificially increasing the complexity of the code using manually implemented Lazy double
    /// serves as a justification for abstraction and comes solely from the author's idea of ​​metaphysics 
    /// </remarks>
    public abstract class Shape
    {
        private double _area = -1;  // this is an impossible value

        /// <returns>
        /// Area of a shape.
        /// </returns>
        /// <remarks>
        /// Return value is not negative.
        /// </remarks>
        public double Area
        { 
            get 
            { 
                if (_area < 0)
                    _area = CalculateArea();

                if (_area < 0)
                    throw new ArgumentOutOfRangeException(string.Format("Calculated area is lesser than 0 ({0})", _area));
                
                return _area;
            }
        }


        /// <summary>
        /// Calculates area of a shape.
        /// </summary>
        /// <remarks>
        /// Return value must be not negative.
        /// </remarks>
        protected abstract double CalculateArea();
    }
}
