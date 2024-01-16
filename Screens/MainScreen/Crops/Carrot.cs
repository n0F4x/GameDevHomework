using System;
using Homework.Interfaces;
using Homework.States;
using Microsoft.Xna.Framework;

namespace Homework.Screens.MainScreen.Crops;

public class Carrot : Crop
{
    public Carrot(IShape shape, Game game)
        : base(
            shape,
            AssetManager.LoadTexture(game.Content, "carrot"),
            new TimeSpan(0, 0, 10),
            CropType.Carrot
        )
    {
    }
}
