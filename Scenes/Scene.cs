using Microsoft.Xna.Framework;

namespace Homework.Scenes;

interface IScene
{
    void Init();
    void Update(GameTime gameTime);
    void Draw(GameTime gameTime);
}
