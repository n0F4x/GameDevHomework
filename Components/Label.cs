using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Components;

public class Label : Element, IElement
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

    public Label(IElement shape, SpriteFont font, string text) : base(shape)
    {
        _font = font;
        Text = text;
    }

    void IElement.Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        Vector2 scale = Vector2.One;
        if (_textSize.X > Width)
        {
            scale.X = Width / _textSize.X;
        }
        if (_textSize.Y > Height)
        {
            scale.Y = Height / _textSize.Y;
        }

        spriteBatch.DrawString(
            spriteFont: _font,
            text: _text,
            position: Position.ToVector2(),
            color: Color,
            rotation: 0f,
            origin: Origin,
            scale: scale,
            effects: SpriteEffects.None,
            layerDepth: 0f
        );
    }
}
