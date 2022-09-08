using MindboxTestTask;

namespace TestMindboxTestTask;

public class CircleTests
{
    [TestFixture]
    public class CircleAreaCalculationTests
    {
        [Test]
        public void RadiusLessZero()
        {
            var circle = new Circle(-1f);

            var area = circle.Area;

            Assert.That(area, Is.EqualTo(0f));
        }

        [Test]
        public void RadiusEqualsToZero()
        {
            var circle = new Circle(0f);

            var area = circle.Area;

            Assert.That(area, Is.EqualTo(0f));
        }

        [TestCase(1f, MathF.PI)]
        [TestCase(0.5f, MathF.PI * 0.25f)]
        [TestCase(2f, MathF.PI * 4f)]
        public void AreaCalculation(float radius, float assertArea)
        {
            var circle = new Circle(radius);

            var area = circle.Area;

            Assert.That(area, Is.EqualTo(assertArea));
        }
    }
}