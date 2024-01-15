using System.Collections.Generic;
using Homework.Interfaces;
using Homework.Mixins;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IUpdateable = Homework.Interfaces.IUpdateable;

namespace Homework.Screens.MainScreen;

public class Farm : IUpdateable
{
    private readonly List<Ground> _grounds = new();

    public Farm(IShape shape, Game game)
    {
        _grounds.AddRange(
            MakeQuarter(
                shape.Position,
                new Vector2(shape.Width / 2,
                    shape.Height
                ),
                game
            )
        );
        _grounds.AddRange(
            MakeQuarter(
                shape.Position + new Point((int)shape.Width / 2, 0
                ),
                new Vector2(shape.Width / 2, shape.Height),
                game
            )
        );
    }

    private static IEnumerable<Ground> MakeQuarter(Point position, Vector2 size, Game game)
    {
        var width = size.X;
        var height = size.Y;
        var margin = width / 3 / 6;
        return new[]
        {
            new Ground(
                new Shape(position + new Point((int)(width / 3 - margin), (int)(height / 3 - margin)),
                    new Vector2(width / 3, height / 3)),
                game),
            new Ground(
                new Shape(position + new Point((int)(width * 2 / 3 + margin), (int)(height / 3 - margin)),
                    new Vector2(width / 3, height / 3)),
                game),
            new Ground(
                new Shape(position + new Point((int)(width / 3 - margin), (int)(height * 2 / 3 + margin)),
                    new Vector2(width / 3, height / 3)),
                game),
            new Ground(
                new Shape(position + new Point((int)(width * 2 / 3 + margin), (int)(height * 2 / 3 + margin)),
                    new Vector2(width / 3, height / 3)),
                game),
        };
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
}
