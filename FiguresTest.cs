using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;

namespace FiguresTest;

[TestClass]
public class FigureTest
{
    [TestMethod]
    public void Triangle_Area_ValidCalc() // Тест на площадь треугольника
    {
        double side_a = 3;
        double side_b = 4;
        double side_c = 5;
        Triangle triangle = new(side_a, side_b, side_c);

        double area = triangle.Area();

        Assert.AreEqual(area, 6, "Incorrect triangle area");
    }

    [TestMethod]
    public void Triangle_IsRight_Valid() // Тест на прямоугольность
    {

        Triangle triangle = new(3, 4, 5);
        Triangle triangle2 = new(3, 7, 5);


        double area = triangle.Area();

        Assert.IsTrue(triangle.IsRight()); // передаем прямоугольный
        Assert.IsFalse(triangle2.IsRight()); // передаем не прямоугольный
    }

    [TestMethod]
    public void Circle_Area_ValidCalc() // Тест на площадь круга
    {
        double radius = 7;
        Circle circle = new(radius);

        double area = circle.Area();

        Assert.AreEqual(area, 153.94, "Incorrect circle area");
    }
} 
