using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Homework;

public class AssetManager
{
    private static readonly Dictionary<string, Texture2D> _textures = new();

    public static Texture2D LoadTexture(ContentManager content, string path)
    {
        if (_textures.TryGetValue(path, out Texture2D texture))
        {
            return texture;
        }

        _textures.Add(path, content.Load<Texture2D>(path));
        return _textures[path];
    }

    public static Texture2D GetTexture(string path)
    {
        return _textures[path];
    }
}
