using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list that can hold different kinds of shapes
        List<Shape> shapes = new List<Shape>();

        // Add different shapes
        shapes.Add(new Square("Red", 4));
        shapes.Add(new Rectangle("Blue", 5, 3));
        shapes.Add(new Circle("Green", 2.5));

        // Loop through each shape and display info
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea():0.00}");
        }
    }
}
