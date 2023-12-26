namespace AreaCalculator.Figures;

public class Triangle : IFigure
{
    private readonly double _firstSideLength;
    private readonly double _secondSideLength;
    private readonly double _thirdSideLength;

    /// <summary>
    ///     Triangle constructor.
    ///     One or more sides of length 0 are allowed. A line or point is an exceptional case of a triangle.
    /// </summary>
    /// <exception cref="ArgumentException">The length of a side of a triangle cannot be less than zero.</exception>
    /// <exception cref="ArgumentException">
    ///     There is no triangle. The sum of the lengths of the two sides must be greater than
    ///     the length of the third side.
    /// </exception>
    public Triangle(double firstSideLength, double secondSideLength, double thirdSideLength)
    {
        if (OneOfSidesLessThanZero)
            throw new ArgumentException(ExceptionMessages.SideOfTriangleLessThanZero
                                        + $"{firstSideLength}, {secondSideLength}, {thirdSideLength}");

        if (AllSidesGreaterThanZero && (firstSideLength + secondSideLength <= thirdSideLength ||
                                        firstSideLength + thirdSideLength <= secondSideLength ||
                                        secondSideLength + thirdSideLength <= firstSideLength))
            throw new ArgumentException(ExceptionMessages.TriangleDoesntExist
                                        + $"{firstSideLength}, {secondSideLength}, {thirdSideLength}");

        _firstSideLength = firstSideLength;
        _secondSideLength = secondSideLength;
        _thirdSideLength = thirdSideLength;
    }

    private bool OneOfSidesLessThanZero => _firstSideLength < 0 || _secondSideLength < 0 || _thirdSideLength < 0;
    private bool AllSidesGreaterThanZero => _firstSideLength > 0 && _secondSideLength > 0 && _thirdSideLength > 0;

    /// <summary>
    ///     Calculate the area of the triangle based on the lengths of the three sides.
    /// </summary>
    /// <returns>Area of a triangle.</returns>
    public double GetArea()
    {
        var halfPerimeter = (_firstSideLength + _secondSideLength + _thirdSideLength) / 2;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - _firstSideLength)
                                       * (halfPerimeter - _secondSideLength)
                                       * (halfPerimeter - _thirdSideLength));
    }

    /// <summary>
    ///     Checking if a triangle has a 90 degree angle.
    /// </summary>
    /// <returns>All sides of a triangle are greater than zero. A triangle has an angle of 90 degrees.</returns>
    public bool IsRightTriangle()
    {
        if (!AllSidesGreaterThanZero)
            return false;

        var firstSideSquare = _firstSideLength * _firstSideLength;
        var secondSideSquare = _secondSideLength * _secondSideLength;
        var thirdSideSquare = _thirdSideLength * _thirdSideLength;

        return Math.Abs(firstSideSquare + secondSideSquare - thirdSideSquare) < 1e-3 ||
               Math.Abs(firstSideSquare + thirdSideSquare - secondSideSquare) < 1e-3 ||
               Math.Abs(secondSideSquare + thirdSideSquare - firstSideSquare) < 1e-3;
    }
}