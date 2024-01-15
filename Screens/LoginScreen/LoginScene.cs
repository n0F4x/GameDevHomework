using System;
using Homework.Elements;
using Homework.Interfaces;
using Homework.Mixins;
using Homework.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Screens.LoginScreen;

public class LoginScene : IScene
{
    private readonly App _app;

    private readonly SceneManager _sceneManager;

    private Logo _logo;
    private UsernameTextBox _textBox;
    private Label _label;
    private LoginButton _loginButton;
    private QuitButton _quitButton;


    public LoginScene(App app, SceneManager sceneManager)
    {
        _app = app;
        _sceneManager = sceneManager;
    }

    public void Init()
    {
        var width = _app.GraphicsDevice.Viewport.Width;
        var height = _app.GraphicsDevice.Viewport.Height;

        const int margin = -50;
        const int lineHeight = 110;

        _logo = new Logo(_app, new Shape(
            new Point(width / 2, height / 2 + 100),
            new Vector2(width * 2 / 3, height / 2),
            new Vector2(0, 1)
        ));

        _textBox = new UsernameTextBox(_app, new Shape(
            new Point(width / 2, height / 2 + 100),
            new Vector2(width / 5, lineHeight),
            new Vector2(0, -1)
        ));

        _label = new Label(
            new Shape(
                _textBox.Position - new Point((int)_textBox.Width + margin, 0),
                new Vector2(150, _textBox.Height),
                _textBox.Origin
            ),
            AssetManager.LoadFont(_app.Content, "DancingScript"),
            "Name:"
        );

        _loginButton = new LoginButton(_app, new Shape(
            _textBox.Position + new Point((int)_textBox.Width + margin, 0),
            new Vector2(150, _textBox.Height),
            _textBox.Origin
        ), () =>
        {
            _app.GameState.PlayerName = _textBox.Text;
            _sceneManager.ActivateScene("main");
        });

        _quitButton = new QuitButton(new Shape(
                new Point(width, 0),
                new Vector2(width / 15, height / 15),
                new Vector2(1, -1)
            ), AssetManager.LoadFont(_app.Content, "DancingScript"),
            () => _app.Exit());
    }

    public void Update(GameTime gameTime)
    {
        _textBox.Update(gameTime);
        _loginButton.Update(gameTime);
        _quitButton.Update(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        _logo.Draw(gameTime, spriteBatch);
        _textBox.Draw(gameTime, spriteBatch);
        _label.Draw(gameTime, spriteBatch);
        _loginButton.Draw(gameTime, spriteBatch);
        _quitButton.Draw(gameTime, spriteBatch);
    }
}
