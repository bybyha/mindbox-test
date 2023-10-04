namespace Figures;

abstract class Figure // абстрактный класс фигуры
{
    public abstract double Area(); // абстрактный метод для реализации в наследуемых классах
}
class Triangle : Figure // класс треугольника 
{
    public double side_a, side_b, side_c;
    public Triangle(double side_a, double side_b, double side_c)
    {
        this.side_a = side_a;
        this.side_b = side_b;
        this.side_c = side_c;
    }
    public override double Area()
    {
        var s = GetSemiperimeter();
        return Math.Sqrt(s * (s - side_a) * (s - side_b) * (s - side_c));
    }
    public bool IsRight() // метод проверки на прямоугольность
    {
        return (side_a * side_a + side_b * side_b == side_c * side_c) || (side_a * side_a + side_c * side_c == side_b * side_b) || (side_c * side_c + side_b * side_b == side_a * side_a); 
    }
    private double GetSemiperimeter()
    {
        return (side_a + side_b + side_c) / 2;
    }
}
class Circle : Figure // класс круга
{
    public const double pi = 3.141592;
    public double radius;
    public Circle(double radius) { this.radius = radius; }
    public override double Area()
    {
        return Math.Round(pi * (radius * radius),2);
    }
}


