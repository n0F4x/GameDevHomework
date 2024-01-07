using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Interfaces;

public interface IDrawable
{
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }
}
