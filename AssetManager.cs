using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Homework;

public static class AssetManager
{
    private static readonly Dictionary<string, Texture2D> textures = new();
    private static readonly Dictionary<string, SpriteFont> fonts= new();

    public static Texture2D LoadTexture(ContentManager content, string path)
    {
        if (textures.TryGetValue(path, out var texture))
        {
            return texture;
        }

        textures.Add(path, content.Load<Texture2D>(path));
        return textures[path];
    }

    public static Texture2D GetTexture(string path)
    {
        return textures[path];
    }

    public static SpriteFont LoadFont(ContentManager content, string path)
    {
        if (fonts.TryGetValue(path, out SpriteFont font))
        {
            return font;
        }

        fonts.Add(path, content.Load<SpriteFont>(path));
        return fonts[path];
    }

    public static SpriteFont GetFont(string path)
    {
        return fonts[path];
    }
}
