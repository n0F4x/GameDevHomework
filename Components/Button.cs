using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Homework.Components;

internal class Button : IElement
{
    public delegate void HandleClick();

    private readonly IElement _defaultElement;
    private readonly IElement _pressedElement;

    private Point _position;
    private Vector2 _size;
    private Vector2 _offset;

    private bool _pressed = false;

    public event HandleClick OnClick;

    public override int X
    {
        get => _position.X;
        set
        {
            _position.X = value;
            _defaultElement.X = _position.X;
            _pressedElement.X = _position.X;
        }
    }
    public override int Y
    {
        get => _position.Y;
        set
        {
            _position.Y = value;
            _defaultElement.Y = _position.Y;
            _pressedElement.Y = _position.Y;
        }
    }
    public override Point Position
    {
        get => _position;
        set
        {
            _position = value;
            _defaultElement.Position = _position;
            _pressedElement.Position = _position;
        }
    }

    public override float Width
    {
        get => _size.X;
        set
        {
            _size.X = value;
            _defaultElement.Width = _size.X;
            _pressedElement.Width = _size.X;
        }
    }
    public override float Height
    {
        get => _size.Y;
        set
        {
            _size.Y = value;
            _defaultElement.Height = _size.Y;
            _pressedElement.Height = _size.Y;
        }
    }
    public override Vector2 Size
    {
        get => _size;
        set
        {
            _size = value;
            _defaultElement.Size = _size;
            _pressedElement.Size = _size;
        }
    }

    public override Vector2 Offset
    {
        get => _offset;
        set
        {
            _offset = value;
            _defaultElement.Offset = _offset;
            _pressedElement.Offset = _offset;
        }
    }

    public Button(IElement defaultElement, IElement pressedElement = null)
    {
        _defaultElement = defaultElement;
        _pressedElement = pressedElement ?? defaultElement;
    }

    public override void Update(GameTime gameTime)
    {
        var mouseState = Mouse.GetState();

        var previousPressed = _pressed;
        var mousePressed = mouseState.LeftButton == ButtonState.Pressed;
        var mouseHovers = Bounds.Contains(mouseState.Position);
        _pressed = mousePressed && mouseHovers;

        if (previousPressed && !mousePressed)
        {
            OnClick?.Invoke();
        }
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
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
}
