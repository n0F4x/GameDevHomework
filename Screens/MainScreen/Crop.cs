using System;
using Homework.Elements;
using Homework.Interfaces;
using Homework.Screens.MainScreen.Crops;
using Homework.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Screens.MainScreen;

public class Crop : Sprite
{
    public CropType Type { get; }
    private readonly TimeSpan _fullGrowTime;
    private TimeSpan _growTime;

    public bool IsFullyGrown => _growTime >= _fullGrowTime;

    protected Crop(IShape shape, Texture2D texture, TimeSpan fullGrowTime, CropType type) : base(shape,
        texture)
    {
        Type = type;
        _fullGrowTime = fullGrowTime;
        Color = new Color(Color.Gray, 120);
    }

    public void Update(GameTime gameTime)
    {
        _growTime = new TimeSpan(Math.Min((gameTime.ElapsedGameTime + _growTime).Ticks,
            _fullGrowTime.Ticks));

        if (IsFullyGrown)
        {
            Color = new Color(Color.LimeGreen, 120);
        }
    }

    public void Grow()
    {
        _growTime = _fullGrowTime;
    }
    
    public static Crop MakeCrop(CropType type, IShape shape, Game game) => type switch
    {
        CropType.Wheat => new Wheat(shape, game),
        CropType.Potato => new Potato(shape, game),
        CropType.Carrot => new Carrot(shape, game),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };
}
