﻿using Homework.Interfaces;
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

    public IDrawable DefaultDrawable { get; }
    public IDrawable HoveredDrawable { get; }

    private bool _pressed;
    private bool _hovered;

    public event HandleClick OnClick;


    public Button(IShape shape, IDrawable defaultDrawable, IDrawable hoveredDrawable = null)
        : base(shape, hoveredDrawable != null ? new List<IShape> { defaultDrawable, hoveredDrawable } : new List<IShape> { defaultDrawable })
    {
        DefaultDrawable = defaultDrawable;
        HoveredDrawable = hoveredDrawable ?? defaultDrawable;
    }

    public virtual void Update(GameTime gameTime)
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

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (_hovered)
        {
            HoveredDrawable.Draw(gameTime, spriteBatch);
        }
        else
        {
            DefaultDrawable.Draw(gameTime, spriteBatch);
        }
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}
