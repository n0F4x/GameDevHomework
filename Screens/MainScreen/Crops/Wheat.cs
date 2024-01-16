using System;
using Homework.Interfaces;
using Homework.States;
using Microsoft.Xna.Framework;

namespace Homework.Screens.MainScreen.Crops;

public class Wheat : Crop
{
    public Wheat(IShape shape, Game game)
        : base(
            shape,
            AssetManager.LoadTexture(game.Content, "wheat"),
            new TimeSpan(0, 0, 2),
            CropType.Wheat
        )
    {
    }
}
