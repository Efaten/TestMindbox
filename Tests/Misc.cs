using TestMindbox.Geometry;

namespace Tests
{
    [TestClass]
    public class Misc
    {
        [TestMethod]
        public void RuntimeAreaCalculationTest()
        {
            // > Вычисление площади фигуры без знания типа фигуры в compile-time
            // ? Force runtime calculation ?
            int[] cases = { 1, 2 };
            Random random = new Random();
            int r = random.Next(cases.Length);
            Shape s;

            switch (r)
            {
                case 1:
                    s = new Triangle(3, 3, 3);
                    break; 
                case 2:
                    s = new Circle(3);
                    break;
                default:
                    s = new Circle(5); break;

            }
            Assert.IsTrue(s.Area != 0);
        }

    }
}
