using System;

public class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    // Virtual method so derived classes can override it
    public virtual double GetArea()
    {
        return 0;
    }
}
