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

    private TextBox _textBox;
    private RectangleShape _rectangleShape;
    private Button _loginButton;


    public LoginScene(App app, SceneManager sceneManager)
    {
        _app = app;
        _sceneManager = sceneManager;
    }

    public void Init()
    {
        _rectangleShape = new RectangleShape(
            new Shape(
                new Point(5, 5),
                new Vector2(100, 100),
                new Vector2(-1, -1)
            ),
            _app.GraphicsDevice
        )
        {
            Color = Color.MediumVioletRed
        };

        _loginButton = new Button(
            new Shape(
                new Point(_app.GraphicsDevice.Viewport.Width / 2, _app.GraphicsDevice.Viewport.Height / 2) +
                new Point(300, 0),
                new Vector2(300, 100)
            ),
            new Sprite(
                new Shape(
                    Point.Zero,
                    Vector2.Zero
                ),
                AssetManager.LoadTexture(_app.Content, "login_btn")
            )
        );

        _textBox = new TextBox(
            new Shape(
                new Point(_app.GraphicsDevice.Viewport.Width / 2, _app.GraphicsDevice.Viewport.Height / 2),
                new Vector2(300, 100)
            ),
            _app.Window,
            _app.GraphicsDevice,
            AssetManager.LoadFont(_app.Content, "DancingScript"),
            "Name",
            new TextBox.BorderOptions()
        );
    }

    public void Update(GameTime gameTime)
    {
        _textBox.Update(gameTime);
        _loginButton.Update(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        new Sprite(
            new Shape(
                new Point(_app.GraphicsDevice.Viewport.Width / 2, _app.GraphicsDevice.Viewport.Height / 2) -
                new Point(0, 150),
                new Vector2(600, 300)
            ),
            AssetManager.LoadTexture(_app.Content, "logo")
        ).Draw(gameTime, spriteBatch);

        _rectangleShape.Draw(gameTime, spriteBatch);

        _textBox.Draw(gameTime, spriteBatch);

        _loginButton.Draw(gameTime, spriteBatch);
    }
}
