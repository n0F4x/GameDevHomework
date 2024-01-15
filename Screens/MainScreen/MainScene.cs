using Homework.Interfaces;
using Homework.Mixins;
using Homework.Screens.LoginScreen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Screens.MainScreen;

public class MainScene : IScene
{
    private readonly App _app;
    private readonly GameState _gameState;

    private PlayerUi _playerUi;
    private QuitButton _quitButton;

    public MainScene(App app, GameState gameState)
    {
        _app = app;
        _gameState = gameState;
    }

    public void Init()
    {
        var width = _app.GraphicsDevice.Viewport.Width;
        var height = _app.GraphicsDevice.Viewport.Height;
        const int lineHeight = 110;

        _playerUi = new PlayerUi(
            _app,
            new Shape(Point.Zero, new Vector2(width / 5 + lineHeight + 10, lineHeight), new Vector2(-1, -1)),
            _gameState
        );

        _quitButton = new QuitButton(new Shape(
                new Point(width, 0),
                new Vector2(100, 75),
                new Vector2(1, -1)
            ), AssetManager.LoadFont(_app.Content, "DancingScript"),
            () => _app.Exit());
    }

    public void Update(GameTime gameTime)
    {
        _quitButton.Update(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        _playerUi.Draw(gameTime, spriteBatch);
        _quitButton.Draw(gameTime, spriteBatch);
    }
}
