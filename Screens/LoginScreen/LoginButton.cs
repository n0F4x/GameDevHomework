using Homework.Elements;
using Homework.Interfaces;
using Homework.Mixins;
using Microsoft.Xna.Framework;

namespace Homework.Screens.LoginScreen;

public class LoginButton : Button
{
    public LoginButton(Game app, IShape shape, HandleClick onClick) : base(
        shape,
        new Sprite(
            new Shape(
                Point.Zero,
                Vector2.Zero
            ),
            AssetManager.LoadTexture(app.Content, "login_btn")
        ))
    {
        OnClick += onClick;
    }
}
