namespace AreaCalculator.Figures;

public class Circle : IFigure
{
    private readonly double _radius;

    /// <summary>
    ///     Circle constructor.
    ///     Zero radius is acceptable, the point is an exceptional case of a circle.
    /// </summary>
    /// <exception cref="ArgumentException">Radius of circle cannot be less than zero.</exception>
    public Circle(double radius)
    {
        _radius = radius;

        if (radius < 0)
            throw new ArgumentException(new string(ExceptionMessages.RadiusLessThanZero + $"{radius}"));
    }

    /// <summary>
    ///     Calculate area of a circle based on the radius passed to the constructor.
    ///     Simple multiply is faster than Math.Pow(.., 2)
    /// </summary>
    /// <returns>Area of a circle.</returns>
    public double GetArea()
    {
        return _radius * _radius * Math.PI;
    }
}