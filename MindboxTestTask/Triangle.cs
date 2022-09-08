namespace MindboxTestTask;

public class Triangle : IFigure
{
    public FloatPoint2d[] Vertices { get; } = new FloatPoint2d[3];

    // Так как в условиях не описано требований к поведению, когда все точки лежат на одной прямой, я решил возвращать 0.
    // Как вариант можно было генерировать исключение, если выражение в скобках равно 0.
    public float Area => 0.5f * MathF.Abs((Vertices[1].X - Vertices[0].X) * (Vertices[2].Y - Vertices[0].Y) -
                                          (Vertices[2].X - Vertices[0].X) * (Vertices[1].Y - Vertices[0].Y));

    public Triangle()
    {
    }

    public Triangle(FloatPoint2d vertexA, FloatPoint2d vertexB, FloatPoint2d vertexC)
    {
        Vertices = new FloatPoint2d[] {vertexA, vertexB, vertexC};
    }

    public Triangle(ValueTuple<float, float> vertexA, ValueTuple<float, float> vertexB,
        ValueTuple<float, float> vertexC)
    {
        Vertices = new FloatPoint2d[]
        {
            new(vertexA.Item1, vertexA.Item2),
            new(vertexB.Item1, vertexB.Item2),
            new(vertexC.Item1, vertexC.Item2)
        };
    }

    public bool IsRightTriangle()
    {
        // Площадь равна нулю только когда все точки лежат на одной прямой.
        // Не будем считать такой "треугольник" прямоугольным.
        if (Area.Equals(0f))
            return false;

        var edgesLengthSquared = new float[3];
        for (var delta = 0; delta < 3; ++delta)
            edgesLengthSquared[delta] = FloatPoint2d.DistanceSquared(Vertices[delta], Vertices[(delta + 1) % 3]);

        for (var edgeLikeHypotenuseIndex = 0; edgeLikeHypotenuseIndex < 3; ++edgeLikeHypotenuseIndex)
        {
            float hypotenuseLengthSquared = edgesLengthSquared[edgeLikeHypotenuseIndex],
                firstLegLengthSquared = edgesLengthSquared[(edgeLikeHypotenuseIndex + 1) % 3],
                secondLegLengthSquared = edgesLengthSquared[(edgeLikeHypotenuseIndex + 2) % 3];

            if ((hypotenuseLengthSquared).Equals(firstLegLengthSquared + secondLegLengthSquared))
                return true;
        }

        return false;
    }
}