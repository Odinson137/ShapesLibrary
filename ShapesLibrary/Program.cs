namespace ShapesLibrary;

public interface IShape
{
    double CalculateArea();
}

public class Circle : IShape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius must be positive");
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Triangle : IShape
{
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            throw new ArgumentException("Sides must be positive");
        if (sideA + sideB <= sideC || sideB + sideC <= sideA || sideA + sideC <= sideB)
            throw new ArgumentException("Invalid triangle");

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double CalculateArea()
    {
        var s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    public bool IsRightAngled()
    {
        double[] sides = [SideA, SideB, SideC];
        Array.Sort(sides);
        double a = sides[0], b = sides[1], c = sides[2];
        return Math.Abs(a * a + b * b - c * c) < 1e-10; // 1e-10 - чтоб избегать погрешности
    }
}