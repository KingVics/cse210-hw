using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Yellow", 2);

        Rectangle rectangle = new Rectangle("Red", 5.4, 9.5);

        Circle circle = new Circle("Black", 43.0);

        List<Shape> shapes = new List<Shape>();

        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()}");
            Console.WriteLine($"{shape.GetArea()}");

        }
    }
}