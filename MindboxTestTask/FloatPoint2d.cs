namespace MindboxTestTask;

public struct FloatPoint2d
{
    public float X { get; set; } = 0f;
    public float Y { get; set; } = 0f;

    public FloatPoint2d()
    {
    }

    public FloatPoint2d(float x, float y)
    {
        X = x;
        Y = y;
    }
    
    public static FloatPoint2d operator +(FloatPoint2d rhs) => rhs;

    public static FloatPoint2d operator -(FloatPoint2d rhs) => new FloatPoint2d(-rhs.X, -rhs.Y);

    public static FloatPoint2d operator +(FloatPoint2d lhs, FloatPoint2d rhs) =>
        new FloatPoint2d(lhs.X - rhs.X, lhs.Y - rhs.Y);

    public static FloatPoint2d operator -(FloatPoint2d lhs, FloatPoint2d rhs) =>
        new FloatPoint2d(lhs.X - rhs.X, lhs.Y - rhs.Y);

    public static float DistanceSquared(FloatPoint2d firstPoint, FloatPoint2d secondPoint)
    {
        var vector = firstPoint - secondPoint;
        return vector.X * vector.X + vector.Y * vector.Y;
    }

    public bool Equals(FloatPoint2d other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y);
    }

    public override bool Equals(object? obj)
    {
        if (obj is FloatPoint2d castedObj)
            return Equals(castedObj);

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}