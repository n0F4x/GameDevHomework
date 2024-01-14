using Homework.Elements;
using Homework.Interfaces;
using Homework.Mixins;
using Microsoft.Xna.Framework;

namespace Homework.Screens.LoginScreen;

public class Logo : Sprite
{
    public Logo(Game app, IShape shape) : base(
        shape,
        AssetManager.LoadTexture(app.Content, "logo"))
    {
    }
}
