using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Interfaces;

public interface IScene : IUpdatable
{
    public void Init() {}
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch);
}
