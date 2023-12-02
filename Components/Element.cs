using Microsoft.Xna.Framework;

namespace Homework.Components;

public class Element : IElement
{
    private Point _position;
    private Vector2 _size;

    public virtual int X
    {
        get => _position.X; set => _position.X = value;
    }
    public virtual int Y
    {
        get => _position.Y; set => _position.Y = value;
    }
    public virtual Point Position
    {
        get => _position; set => _position = value;
    }

    public virtual float Width
    {
        get => _size.X; set => _size.X = value;
    }
    public virtual float Height
    {
        get => _size.Y; set => _size.Y = value;
    }
    public virtual Vector2 Size
    {
        get => _size; set => _size = value;
    }

    public virtual Vector2 Origin { get; set; }

    public Element(Point position, Vector2 size) : this(position, size, new Vector2(0, 0)) { }

    public Element(Point position, Vector2 size, Vector2 origin)
    {
        Position = position;
        Size = size;
        Origin = origin;
    }

    public Element(IElement shape) : this(shape.Position, shape.Size, shape.Origin) { }
}
