using Homework.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Homework.Mixins;

public class ShapeGroup : IShape
{
    private readonly IShape _shape;
    private readonly List<IShape> _shapes;

    public virtual int X
    {
        get => _shape.X; set
        {
            _shape.X = value;
            foreach (var shape in _shapes)
            {
                shape.X = value;
            }
        }
    }
    public virtual int Y
    {
        get => _shape.Y; set
        {
            _shape.Y = value;
            foreach (var shape in _shapes)
            {
                shape.Y = value;
            }
        }
    }
    public virtual Point Position
    {
        get => new(X, Y); set { X = value.X; Y = value.Y; }
    }

    public virtual float Width
    {
        get => _shape.Width; set
        {
            _shape.Width = value;
            foreach (var shape in _shapes)
            {
                shape.Width = value;
            }
        }
    }
    public virtual float Height
    {
        get => _shape.Height; set
        {
            _shape.Height = value;
            foreach (var shape in _shapes)
            {
                shape.Height = value;
            }
        }
    }
    public virtual Vector2 Size
    {
        get => new(Width, Height); set { Width = value.X; Height = value.Y; }
    }

    public virtual Vector2 Origin
    {
        get => _shape.Origin; set
        {
            _shape.Origin = value;
            foreach (var shape in _shapes)
            {
                shape.Origin = value;
            }
        }
    }

    public ShapeGroup(IShape shape, List<IShape> shapes)
    {
        _shape = shape;
        _shapes = shapes;
        this.Reshape(shape);
    }
}
