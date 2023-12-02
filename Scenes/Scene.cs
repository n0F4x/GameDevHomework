using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Scenes;

interface IScene
{
    void Init();
    void Update(GameTime gameTime);
    void Draw(GameTime gameTime, SpriteBatch spriteBatch);
}
