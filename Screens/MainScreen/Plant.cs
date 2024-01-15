using System;
using Homework.Elements;
using Homework.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Screens.MainScreen;

public class Plant : Sprite
{
    private readonly TimeSpan _fullGrowTime;
    private TimeSpan _growTime;

    public bool IsFullyGrown => _growTime >= _fullGrowTime;

    protected Plant(IShape shape, Texture2D texture, TimeSpan fullGrowTime) : base(shape, texture)
    {
        _fullGrowTime = fullGrowTime;
    }

    public void Update(GameTime gameTime)
    {
        _growTime = new TimeSpan(Math.Min((gameTime.ElapsedGameTime + _growTime).Ticks,
            _fullGrowTime.Ticks));
    }
}
