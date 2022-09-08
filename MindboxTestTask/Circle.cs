namespace MindboxTestTask;

public class Circle : IFigure
{
    private float _radius;

    public float Radius
    {
        get => _radius;
        set => _radius = (value < 0) ? _radius : value;
    }

    public float Area => MathF.PI * _radius * _radius;

    public Circle(float radius)
    {
        _radius = radius < 0 ? 0 : radius;
    }
}