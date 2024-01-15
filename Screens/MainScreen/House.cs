using Homework.Elements;
using Homework.Interfaces;
using Microsoft.Xna.Framework;

namespace Homework.Screens.MainScreen;

public class House : Button
{
    public House(IShape shape, Game game, HandleClick onClick) : base(shape,
        new Sprite(shape, AssetManager.LoadTexture(game.Content, "farmhouse")),
        new Sprite(shape, AssetManager.LoadTexture(game.Content, "farmhouse")) { Color = Color.LawnGreen })
    {
        OnClick += onClick;
    }
}
