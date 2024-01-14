using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Interfaces;

public interface IScene : IUpdateable
{
    public void Init() {}
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch);
}
