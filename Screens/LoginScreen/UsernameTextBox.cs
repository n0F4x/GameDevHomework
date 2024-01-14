using Homework.Elements;
using Homework.Interfaces;
using Microsoft.Xna.Framework;

namespace Homework.Screens.LoginScreen;

public class UsernameTextBox : TextBox
{
    public UsernameTextBox(Game app, IShape shape) : base(
        shape,
        app.Window,
        app.GraphicsDevice,
        AssetManager.LoadFont(app.Content, "DancingScript"),
        "",
        new BorderOptions { Width = 3, Margin = 15})
    {
    }
}
