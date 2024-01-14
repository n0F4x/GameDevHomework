using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Interfaces;

public interface IDrawable : IShape
{
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
}
