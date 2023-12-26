using System;
using AreaCalculator.Figures;
using NUnit.Framework;

namespace AreaCalculator.Tests;

public class TriangleTests
{
    [TestCase(1, 2, 3)]
    [TestCase(5, 10, 100)]
    public void TriangleDoesntExistTest(double firstSide, double secondSide, double thirdSide)
    {
        var ex = Assert.Throws<ArgumentException>(() => { _ = new Triangle(firstSide, secondSide, thirdSide); });
        Assert.That(ex?.Message, Is.EqualTo(ExceptionMessages.TriangleDoesntExist 
                                            + $"{firstSide}, {secondSide}, {thirdSide}"));
    }
    
    [TestCase(-1, 0, 1)]
    [TestCase(1, -1, 0)]
    [TestCase(0, 1, -1)]
    public void TriangleSideLessThanZeroTest(double firstSide, double secondSide, double thirdSide)
    {
        var ex = Assert.Throws<ArgumentException>(() => { _ = new Triangle(firstSide, secondSide, thirdSide); });
        Assert.That(ex?.Message, Is.EqualTo(ExceptionMessages.SideOfTriangleLessThanZero 
                                            + $"{firstSide}, {secondSide}, {thirdSide}"));
    }

    [TestCase(0, 0, 0, 0)]
    [TestCase(0, 1, 1, 0)]
    [TestCase(1, 0, 1, 0)]
    [TestCase(1, 1, 0, 0)]
    [TestCase(3, 4, 5, 6)]
    [TestCase(13.5, 111.25,120.1,  588.6187405)]
    public void AreaOfTriangleTest(double firstSide, double secondSide, double thirdSide, double expectedArea)
    {
        var area = new Triangle(firstSide, secondSide, thirdSide).GetArea();
        Assert.That(Math.Abs(area - expectedArea), Is.LessThan(1e-3));
    }
    
    
    [TestCase(1, 0, 1, false)]
    [TestCase(1, 1, 1, false)]
    [TestCase(3, 4, 5, true)]
    [TestCase(36, 41.5692193816531, 20.7846096908265, true)]
    public void IsRightTriangleTest(double firstSide, double secondSide, double thirdSide, bool expectedIsRight)
    {
        var isRight = new Triangle(firstSide, secondSide, thirdSide).IsRightTriangle();
        Assert.That(isRight, Is.EqualTo(expectedIsRight));
    }
}