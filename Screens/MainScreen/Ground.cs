#nullable enable
using System;
using Homework.Elements;
using Homework.Interfaces;
using Homework.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Screens.MainScreen;

public class Ground : Button
{
    private Crop? _crop;
    private readonly Random _random = new();

    public bool IsActive { get; set; } = true;

    public Crop? Crop
    {
        get => _crop;
        set
        {
            _crop = value;
            _crop.Reshape(this);
        }
    }

    public Ground(IShape shape, Game game, GameState gameState)
        : base(
            shape,
            new Sprite(shape, AssetManager.LoadTexture(game.Content, "plot")),
            new Sprite(shape, AssetManager.LoadTexture(game.Content, "plot")) { Color = Color.LawnGreen }
        )
    {
        OnClick += () =>
        {
            if (Crop != null || gameState.CropStats[gameState.SelectedCropType] <= 0) return;
            Crop = Crop.MakeCrop(gameState.SelectedCropType, this, game);
            gameState.CropStats[gameState.SelectedCropType]--;
        };
        OnClick += () =>
        {
            if (Crop is not { IsFullyGrown: true }) return;
            gameState.CropStats[Crop.Type] += 1 + RandomFactor();
            _crop = null;
        };
    }

    public override void Update(GameTime gameTime)
    {
        if (IsActive)
        {
            base.Update(gameTime);
        }

        Crop?.Update(gameTime);
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        base.Draw(gameTime, spriteBatch);

        Crop?.Draw(gameTime, spriteBatch);
    }

    private int RandomFactor()
    {
        return _random.Next(10) == 0 ? 1 : 0;
    }
}
