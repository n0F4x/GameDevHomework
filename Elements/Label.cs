using Homework.Interfaces;
using Homework.Mixins;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Elements;

public class Label : Shape, IElement
{
    private readonly SpriteFont _font;
    private string _text;
    private Vector2 _textSize;

    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            _textSize = _font.MeasureString(_text);
        }
    }

    public Color Color { get; set; } = Color.White;

    public Label(IShape shape, SpriteFont font, string text) : base(shape)
    {
        _font = font;
        Text = text;
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        Vector2 scale = new(Width / _textSize.X, 1.5f * Height / _textSize.Y);
        var origin = _textSize / 2 + _textSize / 2 * Origin;

        spriteBatch.DrawString(
            spriteFont: _font,
            text: _text,
            position: Position.ToVector2(),
            color: Color,
            rotation: 0f,
            origin: origin,
            scale: scale,
            effects: SpriteEffects.None,
            layerDepth: 0f
        );
    }
}
