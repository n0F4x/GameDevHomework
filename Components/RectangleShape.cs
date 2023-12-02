using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Components;

public class RectangleShape : Element, IElement
{
    private readonly GraphicsDevice _graphicsDevice;
    private readonly Texture2D _texture;

    public Color Color { get; set; } = Color.White;

    public RectangleShape(GraphicsDevice graphicsDevice, IElement shape) : base(shape)
    {
        _graphicsDevice = graphicsDevice;
        _texture = new Texture2D(_graphicsDevice, 1, 1);
        _texture.SetData(new[] { Color.White });
    }

    void IElement.Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, this.Bounds(), Color);
    }
}
