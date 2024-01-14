using Homework.Elements;
using Homework.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Screens.LoginScreen;

public class QuitButton : Button
{
    public QuitButton(IShape shape, SpriteFont font, HandleClick onClick)
        : base(
            shape,
            new Label(shape, font, "Quit"),
            new Label(shape, font, "Quit") { Color = Color.DarkRed }
        )
    {
        OnClick += onClick;
    }
}
