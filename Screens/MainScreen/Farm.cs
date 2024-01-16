using System.Collections.Generic;
using Homework.Interfaces;
using Homework.Mixins;
using Homework.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Screens.MainScreen;

public class Farm : IUpdatable
{
    private readonly List<Ground> _grounds = new();
    private bool _active = true;

    public bool Active
    {
        get => _active;
        set
        {
            _active = value;
            foreach (var ground in _grounds)
            {
                ground.IsActive = _active;
            }
        }
    }

    public Farm(IShape shape, Game game, GameState gameState)
    {
        _grounds.AddRange(
            MakeQuarter(
                shape.Position,
                new Vector2(shape.Width / 2,
                    shape.Height
                ),
                game,
                gameState
            )
        );
        _grounds.AddRange(
            MakeQuarter(
                shape.Position + new Point((int)shape.Width / 2, 0
                ),
                new Vector2(shape.Width / 2, shape.Height),
                game,
                gameState
            )
        );

        for (var i = 0; i < 8; i++)
        {
            if (gameState.Farms[i] == null) continue;
            _grounds[i].Crop = Crop.MakeCrop((CropType)gameState.Farms[i], shape, game);
            _grounds[i].Crop?.Grow();
        }
    }

    public void Update(GameTime gameTime)
    {
        foreach (var ground in _grounds)
        {
            ground.Update(gameTime);
        }
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        foreach (var ground in _grounds)
        {
            ground.Draw(gameTime, spriteBatch);
        }
    }

    private static IEnumerable<Ground> MakeQuarter(Point position, Vector2 size, Game game, GameState gameState)
    {
        var width = size.X;
        var height = size.Y;
        var margin = width / 3 / 6;
        return new[]
        {
            new Ground(
                new Shape(position + new Point((int)(width / 3 - margin), (int)(height / 3 - margin)),
                    new Vector2(width / 3, height / 3)),
                game,
                gameState),
            new Ground(
                new Shape(position + new Point((int)(width * 2 / 3 + margin), (int)(height / 3 - margin)),
                    new Vector2(width / 3, height / 3)),
                game,
                gameState),
            new Ground(
                new Shape(position + new Point((int)(width / 3 - margin), (int)(height * 2 / 3 + margin)),
                    new Vector2(width / 3, height / 3)),
                game,
                gameState),
            new Ground(
                new Shape(position + new Point((int)(width * 2 / 3 + margin), (int)(height * 2 / 3 + margin)),
                    new Vector2(width / 3, height / 3)),
                game,
                gameState)
        };
    }
}
