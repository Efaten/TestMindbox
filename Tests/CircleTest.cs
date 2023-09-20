
using TestMindbox.Geometry;

namespace Tests
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void ZeroRadiusTest()
        {
            double radius = 0;
            try
            {
                Circle test = new Circle(radius);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, string.Format("Radius is a positive number, entered {0}", radius));
            }
        }

        [TestMethod]
        public void NegativeRadiusTest()
        {
            double radius = -1;
            try
            {
                Circle test = new Circle(radius);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, string.Format("Radius is a positive number, entered {0}", radius));
            }
        }

        [TestMethod]
        public void AreaValueTest()
        {
            double radius = 5;
            Circle circle = new Circle(radius);
            double expectedValue = Math.PI * Math.Pow(radius, 2d);

            double square = circle.Area;

            Assert.AreEqual(0, Math.Abs(square - expectedValue));
        }

        [TestMethod]
        public void HugeAreaValueTest()
        {
            double radius = Math.Pow(37, 73);
            Circle circle = new Circle(radius);
            double expectedValue = Math.PI * Math.Pow(radius, 2);

            double square = circle.Area;

            Assert.AreEqual(0, Math.Abs(square - expectedValue));
        }
    }
}