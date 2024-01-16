using System.Collections.Generic;
using Homework.Interfaces;
using Homework.Mixins;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Homework.Elements;

public class TextBox : Label, IElement
{
    public delegate void HandleEnter();

    public class BorderOptions
    {
        public int Width = 5;
        public int Margin = 10;
    }

    private readonly GraphicsDevice _graphicsDevice;
    private readonly BorderOptions _borderOptions;
    private List<RectangleShape> _borders;
    private bool _selected;

    public event HandleEnter OnEnter;

    public TextBox(IShape shape, GameWindow window, GraphicsDevice graphicsDevice, SpriteFont font, string text,
        BorderOptions borderOptions) : base(
        shape, font, text)
    {
        _graphicsDevice = graphicsDevice;
        _borderOptions = borderOptions;
        RecalculateBorders();

        window.TextInput += TextInputHandler!;
    }

    public void Update(GameTime gameTime)
    {
        RecalculateBorders();
        var mouseState = Mouse.GetState();

        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            _selected = ContentBorder().Contains(mouseState.Position);
            Color = _selected ? Color.Gray : Color.White;
        }
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        base.Draw(gameTime, spriteBatch);
        foreach (var border in _borders)
        {
            border.Draw(gameTime, spriteBatch);
        }
    }

    private Rectangle ContentBorder() => new(
        Position - (Size / 2 + Size / 2 * Origin).ToPoint() - new Point(_borderOptions.Margin),
        Size.ToPoint() + new Point(_borderOptions.Margin * 2)
    );

    private void TextInputHandler(object sender, TextInputEventArgs args)
    {
        if (!_selected) return;

        if (char.IsAscii(args.Character) && char.IsLetter(args.Character))
        {
            Text += args.Character;
        }

        if (args.Key == Keys.Back && Text.Length > 0)
        {
            Text = Text.Remove(Text.Length - 1, 1);
        }

        if (args.Key == Keys.Enter)
        {
            OnEnter?.Invoke();
        }
    }

    private void RecalculateBorders()
    {
        var offset = (Size / 2 * Origin * -1).ToPoint();
        _borders = new List<RectangleShape>
        {
            new(
                new Shape(
                    Position - new Point(0, (int)(Height / 2)) + offset - new Point(0, _borderOptions.Margin),
                    new Vector2(Width + _borderOptions.Width * 2 + _borderOptions.Margin * 2, _borderOptions.Width),
                    new Vector2(0, 1)
                ),
                _graphicsDevice),
            new(
                new Shape(Position - new Point((int)(Width / 2), 0) + offset - new Point(_borderOptions.Margin, 0),
                    new Vector2(_borderOptions.Width, Height + _borderOptions.Width * 2 + _borderOptions.Margin * 2),
                    new Vector2(1, 0)),
                _graphicsDevice),
            new(
                new Shape(
                    Position + new Point(0, (int)(Height / 2)) + offset + new Point(0, _borderOptions.Margin),
                    new Vector2(Width + _borderOptions.Width * 2 + _borderOptions.Margin * 2, _borderOptions.Width),
                    new Vector2(0, -1)),
                _graphicsDevice),
            new(
                new Shape(Position + new Point((int)(Width / 2), 0) + offset + new Point(_borderOptions.Margin, 0),
                    new Vector2(_borderOptions.Width, Height + _borderOptions.Width * 2 + _borderOptions.Margin * 2),
                    new Vector2(-1, 0)),
                _graphicsDevice)
        };
    }
}
