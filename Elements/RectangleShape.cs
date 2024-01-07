using Homework.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Elements;

public class RectangleShape : Sprite
{
    private static Texture2D CreateTexture(GraphicsDevice graphicsDevice)
    {
        var texture = new Texture2D(graphicsDevice, 2, 2);
        texture.SetData(new[] { Color.White, Color.White, Color.White, Color.White });
        return texture;
    }

    public RectangleShape(GraphicsDevice graphicsDevice, IShape shape)
        : base(shape, CreateTexture(graphicsDevice)) { }
}
