using System;
using Homework.Interfaces;
using Microsoft.Xna.Framework;

namespace Homework.Screens.MainScreen.Plants;

public class Carrot : Plant
{
    public Carrot(IShape shape, Game game)
        : base(
            shape,
            AssetManager.LoadTexture(game.Content, "carrot"),
            new TimeSpan(0, 0, 10)
        )
    {
    }
}
