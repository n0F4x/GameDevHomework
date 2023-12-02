using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Homework.Components;

public class Button : IElement
{
    public delegate void HandleClick();

    private readonly IElement _defaultElement;
    private readonly IElement _pressedElement;

    private Point _position;
    private Vector2 _size;
    private Vector2 _origin;

    private bool _pressed = false;

    public event HandleClick OnClick;

    int IElement.X
    {
        get => _position.X;
        set
        {
            _position.X = value;
            _defaultElement.X = _position.X;
            _pressedElement.X = _position.X;
        }
    }
    int IElement.Y
    {
        get => _position.Y;
        set
        {
            _position.Y = value;
            _defaultElement.Y = _position.Y;
            _pressedElement.Y = _position.Y;
        }
    }
    Point IElement.Position
    {
        get => _position;
        set
        {
            _position = value;
            _defaultElement.Position = _position;
            _pressedElement.Position = _position;
        }
    }

    float IElement.Width
    {
        get => _size.X;
        set
        {
            _size.X = value;
            _defaultElement.Width = _size.X;
            _pressedElement.Width = _size.X;
        }
    }
    float IElement.Height
    {
        get => _size.Y;
        set
        {
            _size.Y = value;
            _defaultElement.Height = _size.Y;
            _pressedElement.Height = _size.Y;
        }
    }
    Vector2 IElement.Size
    {
        get => _size;
        set
        {
            _size = value;
            _defaultElement.Size = _size;
            _pressedElement.Size = _size;
        }
    }

    Vector2 IElement.Origin
    {
        get => _origin;
        set
        {
            _origin = value;
            _defaultElement.Origin = _origin;
            _pressedElement.Origin = _origin;
        }
    }

    public Button(IElement shape, IElement defaultElement, IElement pressedElement = null)
    {
        _defaultElement = defaultElement;
        _pressedElement = pressedElement ?? defaultElement;

        _defaultElement.ReShape(shape);
        _pressedElement.ReShape(shape);
    }

    void IElement.Update(GameTime gameTime)
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

    void IElement.Draw(GameTime gameTime, SpriteBatch spriteBatch)
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
