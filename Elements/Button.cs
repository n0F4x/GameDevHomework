using Homework.Interfaces;
using Homework.Mixins;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Homework.Elements;

public class Button : ShapeGroup, IElement
{
    public delegate void HandleClick();

    private readonly IElement _defaultElement;
    private readonly IElement _pressedElement;

    private bool _pressed;

    public event HandleClick OnClick;


    public Button(IShape shape, IElement defaultElement, IElement pressedElement = null)
        : base(shape, pressedElement != null ? new List<IShape> { defaultElement, pressedElement } : new List<IShape> { defaultElement })
    {
        _defaultElement = defaultElement;
        _pressedElement = pressedElement ?? defaultElement;
    }

    public void Update(GameTime gameTime)
    {
        var mouseState = Mouse.GetState();

        var previousPressed = _pressed;
        var mousePressed = mouseState.LeftButton == ButtonState.Pressed;
        var mouseHovers = this.Bounds().Contains(mouseState.Position);
        _pressed = mousePressed && mouseHovers;

        if (previousPressed && !mousePressed)
        {
            OnClick?.Invoke();
        }
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (_pressed)
        {
            _pressedElement.Draw(gameTime, spriteBatch);
        }
        else
        {
            _defaultElement.Draw(gameTime, spriteBatch);
        }
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}
