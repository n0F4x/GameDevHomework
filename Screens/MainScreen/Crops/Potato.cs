using System;
using Homework.Interfaces;
using Homework.States;
using Microsoft.Xna.Framework;

namespace Homework.Screens.MainScreen.Crops;

public class Potato : Crop
{
    public Potato(IShape shape, Game game)
        : base(
            shape,
            AssetManager.LoadTexture(game.Content, "potato"),
            new TimeSpan(0, 0, 5),
            CropType.Potato
        )
    {
    }
}
