using System.Collections.Generic;
using Homework.Interfaces;
using Homework.Mixins;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Homework.Elements;

public class TextBox : Label, IElement
{
    public class BorderOptions
    {
        public int Width = 2;
        public int Margin = 2;
        public Color Color = Color.White;
        public Color ActiveColor = Color.White;
    }

    private readonly GraphicsDevice _graphicsDevice;
    private readonly BorderOptions _borderOptions;
    private List<RectangleShape> _borders;
    private bool _selected;

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
            _selected = this.Bounds().Contains(mouseState.Position);
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
    }

    private void RecalculateBorders()
    {
        var offset = (Size / 2 * Origin * -1).ToPoint();
        _borders = new List<RectangleShape>
        {
            new(
                new Shape(
                    Position - new Point(0, (int)(Height / 2)) + offset,
                    new Vector2(Width + 2, _borderOptions.Width)),
                _graphicsDevice),
            new(
                new Shape(Position - new Point((int)(Width / 2), 0) + offset,
                    new Vector2(_borderOptions.Width, Height + 2)),
                _graphicsDevice),
            new(
                new Shape(
                    Position + new Point(0, (int)(Height / 2)) + offset,
                    new Vector2(Width + 2, _borderOptions.Width)),
                _graphicsDevice),
            new(
                new Shape(Position + new Point((int)(Width / 2), 0) + offset,
                    new Vector2(_borderOptions.Width, Height + 2)),
                _graphicsDevice)
        };
    }
}
