using Homework.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Screens.MainScreen;

public class MainScene : IScene
{
    private readonly GameState _gameState;

    public MainScene(GameState gameState)
    {
        _gameState = gameState;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
    }
}
