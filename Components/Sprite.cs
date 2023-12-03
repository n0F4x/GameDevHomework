using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Components;

public class Sprite : Element, IElement
{
    private readonly Texture2D _texture;

    public Color Color { get; set; } = Color.White;

    public Sprite(IElement shape, Texture2D texture) : base(shape)
    {
        _texture = texture;
    }

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        var textureSize = new Vector2(_texture.Width, _texture.Height);
        var scale = Size / textureSize;
        var origin = textureSize / 2 + textureSize / 2 * Origin;

        spriteBatch.Draw(
            texture: _texture,
            position: Position.ToVector2(),
            sourceRectangle: null,
            color: Color,
            rotation: 0f,
            origin: origin,
            scale: scale,
            effects: SpriteEffects.None,
            layerDepth: 0f
        );
    }
}
