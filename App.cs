using Homework.Scenes;
using Homework.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Homework;

public class App : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private readonly SceneManager _sceneManager = new();
    private SpriteBatch _spriteBatch;

    public StateManager StateManager { get; } = new();
    public GameState GameState => StateManager.CurrentState;

    public App()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.IsBorderless = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        _graphics.IsFullScreen = true;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _sceneManager.Add(new Screens.LoginScreen.LoginScene(this, _sceneManager), "login");
        _sceneManager.ActivateScene("login");
    }

    protected override void Update(GameTime gameTime)
    {
        _sceneManager.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();

        _sceneManager.Draw(gameTime, _spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
