using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Components;

abstract class IElement
{
    public abstract int X { get; set; }
    public abstract int Y { get; set; }
    public abstract Point Position { get; set; }

    public abstract float Width { get; set; }
    public abstract float Height { get; set; }
    public abstract Vector2 Size { get; set; }

    public abstract Vector2 Offset { get; set; }

    public virtual Rectangle Bounds
    {
        get
        {
            return new Rectangle(Position, Size.ToPoint());
        }
        set
        {
            Position = value.Location;
            Size = value.Size.ToVector2();
        }
    }

    public virtual void Update(GameTime gameTime) { }
    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
}
