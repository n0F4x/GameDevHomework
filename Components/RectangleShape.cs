using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Components;

public class RectangleShape : Sprite, IElement
{
    private static Texture2D CreateTexture(GraphicsDevice graphicsDevice)
    {
        var texture = new Texture2D(graphicsDevice, 2, 2);
        texture.SetData(new[] { Color.White, Color.White, Color.White, Color.White });
        return texture;
    }

    public RectangleShape(GraphicsDevice graphicsDevice, IElement shape)
        : base(shape, CreateTexture(graphicsDevice)) { }
}
