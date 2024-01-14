using Homework.Interfaces;
using Homework.Mixins;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using IDrawable = Homework.Interfaces.IDrawable;

namespace Homework.Elements;

public class Button : ShapeGroup, IElement
{
    public delegate void HandleClick();

    private readonly IDrawable _defaultDrawable;
    private readonly IDrawable _hoveredDrawable;

    private bool _pressed;
    private bool _hovered;

    public event HandleClick OnClick;


    public Button(IShape shape, IDrawable defaultDrawable, IDrawable hoveredDrawable = null)
        : base(shape, hoveredDrawable != null ? new List<IShape> { defaultDrawable, hoveredDrawable } : new List<IShape> { defaultDrawable })
    {
        _defaultDrawable = defaultDrawable;
        _hoveredDrawable = hoveredDrawable ?? defaultDrawable;
    }

    public void Update(GameTime gameTime)
    {
        var mouseState = Mouse.GetState();

        var previousPressed = _pressed;
        var mousePressed = mouseState.LeftButton == ButtonState.Pressed;
        var mouseHovers = this.Bounds().Contains(mouseState.Position);
        _pressed = mousePressed && mouseHovers;
        _hovered = mouseHovers;

        if (previousPressed && !mousePressed)
        {
            OnClick?.Invoke();
        }
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (_hovered)
        {
            _hoveredDrawable.Draw(gameTime, spriteBatch);
        }
        else
        {
            _defaultDrawable.Draw(gameTime, spriteBatch);
        }
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}
