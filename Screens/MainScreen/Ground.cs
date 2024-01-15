#nullable enable
using System.Collections.Generic;
using Homework.Elements;
using Homework.Interfaces;
using Homework.Mixins;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using IDrawable = Homework.Interfaces.IDrawable;

namespace Homework.Screens.MainScreen;

public class Ground : ShapeGroup, IElement
{
    private bool _hovered;

    public Plant? Plant { get; set; }

    public Ground(IShape shape, Game game) : base(shape, new List<IShape> { MakePlot(shape, game) })
    {
    }

    private static Sprite MakePlot(IShape shape, Game game)
    {
        return new Sprite(shape, AssetManager.LoadTexture(game.Content, "plot"));
    }

    public void Update(GameTime gameTime)
    {
        var mouseState = Mouse.GetState();
        _hovered = this.Bounds().Contains(mouseState.Position);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        ((Sprite)Shapes[0]).Color = _hovered ? Color.LawnGreen : Color.White;
        
        foreach (var shape in Shapes)
        {
            ((IDrawable)shape).Draw(gameTime, spriteBatch);
        }

        Plant?.Draw(gameTime, spriteBatch);
    }
}
