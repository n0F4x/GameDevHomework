using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Homework.Components;

public interface IElement
{
    public int X { get; set; }
    public int Y { get; set; }
    public Point Position { get; set; }

    public float Width { get; set; }
    public float Height { get; set; }
    public Vector2 Size { get; set; }

    public Vector2 Origin { get; set; }

    public void ReShape(IElement shape)
    {
        Position = shape.Position;
        Size = shape.Size;
    }

    public virtual void Update(GameTime gameTime) { }
    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
}

public static class IElementExtensions
{
    public static Rectangle Bounds(this IElement element) => new(element.Position, element.Size.ToPoint());
}
