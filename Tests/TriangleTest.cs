using TestMindbox.Geometry;

namespace Tests
{
    [TestClass]
    public class TriangleTest
    {
        [DataTestMethod]
        [DataRow(6, 8, 30)]
        [DataRow(5, 3, 14)]
        [DataRow(10, 10, 20)]
        public void BiggestEdgeTest(double a, double b, double c)
        {
            try
            {
                Triangle test = new Triangle(a, b, c);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, "The biggest side is bigger then sum of two others.");
            }
        }

        [DataTestMethod]
        [DataRow(6, 8, 30)]
        [DataRow(5, 3, 14)]
        [DataRow(10, 10, 20)]
        public void BiggestListEdgeTest(double a, double b, double c)
        {
            double[] edges = { a, b, c };
            // checks on different constructors
            try
            {
                Triangle test = new Triangle(edges);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, "The biggest side is bigger then sum of two others.");
            }
        }

        [DataTestMethod]
        [DataRow(-6, 8, 10)]
        [DataRow(5, -3, 4)]
        [DataRow(28, 35, -21)]
        public void NegativeEdgeTest(double a, double b, double c)
        {
            double negativeEdge = Math.Min(a, Math.Min(b, c));
            try
            {
                Triangle test = new Triangle(a, b, c);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, string.Format("Edges must have positive value, got {0}", negativeEdge));
            }
        }

        [DataTestMethod]
        [DataRow(-6, 8, 10)]
        [DataRow(5, -3, 4)]
        [DataRow(28, 35, -21)]
        public void NegativeListEdgeTest(double a, double b, double c)
        {
            double[] edges = { a, b, c };
            double localMin = edges.Min();
            try
            {
                Triangle test = new Triangle(edges);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, string.Format("Edges must have positive value, got {0}", localMin));
            }
        }

        [DataTestMethod]
        [DataRow(new double[] { 1, 2, 3, 4 })]
        [DataRow(new double[] { 5, 3 })]
        [DataRow(new double[] { 5, 6, 7, 8, 10 })]
        public void ExceededEdgesLimit(double[] edges)
        {
            try
            {
                Triangle test = new Triangle(edges);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, string.Format("Triangle takes only 3 edges, got {0} instead", edges.Count()));
            }
        }

        [DataTestMethod]
        [DataRow(6, 8, 10)]
        [DataRow(5, 3, 4)]
        [DataRow(5, 4, 3)]
        [DataRow(10, 6, 8)]
        [DataRow(3, 4, 5)]
        [DataRow(28, 35, 21)]
        public void IsRightAngled(double a, double b, double c)
        {
            double[] edges = { a, b, c };

            Triangle test = new Triangle(edges);

            Assert.IsTrue(test.IsRightAngled);
            
        }

        [DataTestMethod]
        [DataRow(12, 13, 8)]
        [DataRow(12, 12, 6)]
        [DataRow(12, 14, 13)]
        [DataRow(7, 7, 7)]
        public void IsNotRightAngled(double a, double b, double c)
        {
            double[] edges = { a, b, c };

            Triangle test = new Triangle(edges);

            Assert.IsTrue(!test.IsRightAngled);
        }

        [TestMethod]
        public void AreaValueTestExpectConst()
        {
            double a = 16, b = 16, c = 16;
            double[] edges = { a, b, c };
            double expected = Math.Sqrt(3) * 64;

            Triangle test = new Triangle(edges);

            Assert.AreEqual(expected, test.Area);
        }


        [DataTestMethod]
        [DataRow(12, 13, 8)]
        [DataRow(12, 12, 6)]
        [DataRow(12, 14, 13)]
        [DataRow(7, 7, 7)]
        public void AreaValueTestExpectFormula(double a, double b, double c)
        {
            double[] edges = { a, b, c };
            double p = edges.Sum() / 2;
            double expected = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            Triangle test = new Triangle(edges);

            Assert.AreEqual(expected, test.Area);
        }
    }
}
