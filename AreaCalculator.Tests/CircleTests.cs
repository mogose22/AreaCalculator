using System;
using AreaCalculator.Figures;
using NUnit.Framework;

namespace AreaCalculator.Tests;

public class CircleTests
{
    [TestCase(-1)]
    [TestCase(-0.01)]
    public void RadiusLessThanZeroTest(double radius)
    {
        var ex = Assert.Throws<ArgumentException>(() => { _ = new Circle(radius); });
        Assert.That(ex?.Message, Is.EqualTo(ExceptionMessages.RadiusLessThanZero + $"{radius}"));
    }
    
    [TestCase(0, 0)]
    [TestCase(1, Math.PI)]
    [TestCase(2, Math.PI * 4)]
    [TestCase(50, Math.PI * 2500)]
    public void AreaOfCircleTest(double radius, double expectedArea)
    {
        var area = new Circle(radius).GetArea();
        Assert.That(area, Is.EqualTo(expectedArea));
    }
}