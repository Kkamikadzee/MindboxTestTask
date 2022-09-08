using MindboxTestTask;

namespace TestMindboxTestTask;

public class TriangleTests
{
    [TestFixture]
    public class TriangleAreaCalculationTests
    {
        [Test]
        public void AllPointsIsEquals()
        {
            var triangle = new Triangle();

            var area = triangle.Area;

            Assert.That(area, Is.EqualTo(0f));
        }

        [Test]
        public void AllPointsBelongLine()
        {
            var triangle = new Triangle((1, 2), (2, 4), (3, 6));

            var area = triangle.Area;

            Assert.That(area, Is.EqualTo(0f));
        }

        [TestCase(0f, 0f, 0f, 1f, 1f, 0f, 0.5f)]
        [TestCase(1f, 1f, 1f, 2f, 3f, 4f, 1f)]
        public void AreaCalculation(float xVertexA, float yVertexA, 
            float xVertexB, float yVertexB, 
            float xVertexC, float yVertexC, 
            float assertArea)
        {
            var triangle = new Triangle((xVertexA, yVertexA), (xVertexB, yVertexB), (xVertexC, yVertexC));

            var area = triangle.Area;

            Assert.That(area, Is.EqualTo(assertArea));
        }
    }

    [TestFixture]
    public class TriangleCheckRightTriangleTests
    {
        [TestCase(0f, 0f, 0f, 1f, 1f, 0f, true)]
        [TestCase(1f, 1f, 2f, 0f, 3f, 3f, true)]
        [TestCase(1f, 1f, 2f, 0f, 0f, 0f, true)]
        [TestCase(1f, 1f, 0f, 2f, 0f, 0f, true)]
        [TestCase(1f, 1f, 0f, 2f, 2f, 2f, true)]
        [TestCase(1f, 1f, 1f, 2f, 3f, 4f, false)]
        [TestCase(1f, 2f, 2f, 4f, 3f, 6f, false)]
        [TestCase(0f, 0f, 0f, 0f, 0f, 0f, false)]
        public void CheckRightTriangle(float xVertexA, float yVertexA, 
            float xVertexB, float yVertexB, 
            float xVertexC, float yVertexC, 
            bool assertValue)
        {
            var triangle = new Triangle((xVertexA, yVertexA), (xVertexB, yVertexB), (xVertexC, yVertexC));

            var checkResult = triangle.IsRightTriangle();

            Assert.That(checkResult, Is.EqualTo(assertValue));
        }
    }
}