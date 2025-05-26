namespace ShapesLibrary.Tests;

public class ShapesTests
{
    [Fact]
    public void CircleAreaTest()
    {
        IShape circle = new Circle(5);
        const double expected = Math.PI * 25;
        Assert.Equal(expected, circle.CalculateArea(), 10);
    }

    [Fact]
    public void CircleNegativeRadiusTest()
    {
        Assert.Throws<ArgumentException>(() => new Circle(-1));
    }

    [Fact]
    public void TriangleAreaTest()
    {
        IShape triangle = new Triangle(3, 4, 5);
        Assert.Equal(6, triangle.CalculateArea(), 10);
    }

    [Fact]
    public void TriangleRightAngledTest()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.True(triangle.IsRightAngled());
    }

    [Fact]
    public void TriangleNotRightAngledTest()
    {
        var triangle = new Triangle(2, 3, 4);
        Assert.False(triangle.IsRightAngled());
    }

    [Fact]
    public void TriangleInvalidSidesTest()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 3));
    }

    [Fact]
    public void TriangleNegativeSideTest()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(-1, 2, 2));
    }
}