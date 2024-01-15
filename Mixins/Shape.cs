using Homework.Interfaces;
using Microsoft.Xna.Framework;

namespace Homework.Mixins;

public class Shape : IShape
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point Position
    {
        get => new(X, Y);
        set
        {
            X = value.X;
            Y = value.Y;
        }
    }

    public float Width { get; set; }
    public float Height { get; set; }

    public Vector2 Size
    {
        get => new(Width, Height);
        set
        {
            Width = value.X;
            Height = value.Y;
        }
    }

    public Vector2 Origin { get; set; }

    public Shape(Point position, Vector2 size) : this(position, size, new Vector2(0, 0))
    {
    }

    public Shape(Point position, Vector2 size, Vector2 origin)
    {
        Position = position;
        Size = size;
        Origin = origin;
    }

    public Shape(IShape shape) : this(shape.Position, shape.Size, shape.Origin)
    {
    }

    public static Shape Zero { get; } = new Shape(Point.Zero, Vector2.Zero);
}
