using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Homework.Interfaces;

namespace Homework.Scenes;

internal class SceneManager
{
    private readonly Dictionary<string, IScene> _scenes = new();
    private readonly Stack<IScene> _history = new();
    private IScene _active_scene;

    public void Add(IScene scene, string name)
    {
        _scenes.Add(name, scene);
        scene.Init();
    }

    public void ActivateScene(string sceneName)
    {
        _history.Push(_active_scene);
        _scenes.TryGetValue(sceneName, out _active_scene);
    }

    public void DeactivateScene()
    {
        _active_scene = _history.Pop();
    }

    public void Update(GameTime gameTime)
    {
        _active_scene?.Update(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        _active_scene?.Draw(gameTime, spriteBatch);
    }
}
