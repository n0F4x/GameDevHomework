using System;
using Homework.Interfaces;
using Microsoft.Xna.Framework;

namespace Homework.Screens.MainScreen.Plants;

public class Potato : Plant
{
    public Potato(IShape shape, Game game)
        : base(
            shape,
            AssetManager.LoadTexture(game.Content, "potato"),
            new TimeSpan(0, 0, 5)
        )
    {
    }
}
