using Microsoft.Xna.Framework;

namespace Homework.Interfaces;

public interface IShape
{
    public int X { get; set; }
    public int Y { get; set; }
    public Point Position { get; set; }

    public float Width { get; set; }
    public float Height { get; set; }
    public Vector2 Size { get; set; }

    public Vector2 Origin { get; set; }
}

public static class ShapeExtensions
{
    public static Rectangle Bounds(this IShape shape)
        => new(
            shape.Position - (shape.Size / 2 + shape.Size / 2 * shape.Origin).ToPoint(),
            shape.Size.ToPoint()
        );

    public static void Reshape(this IShape shape, IShape other)
    {
        shape.Position = other.Position;
        shape.Size = other.Size;
        shape.Origin = other.Origin;
    }
}
