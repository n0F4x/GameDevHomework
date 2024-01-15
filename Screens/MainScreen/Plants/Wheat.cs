using System;
using Homework.Interfaces;
using Microsoft.Xna.Framework;

namespace Homework.Screens.MainScreen.Plants;

public class Wheat : Plant
{
    public Wheat(IShape shape, Game game)
        : base(
            shape,
            AssetManager.LoadTexture(game.Content, "wheat"),
            new TimeSpan(0, 0, 2)
        )
    {
    }
}
