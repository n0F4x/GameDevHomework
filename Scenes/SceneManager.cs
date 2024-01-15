using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Homework.Interfaces;

namespace Homework.Scenes;

public class SceneManager
{
    private readonly Dictionary<string, IScene> _scenes = new();
    private readonly Stack<IScene> _history = new();
    private IScene _activeScene;
    
    public void Add(IScene scene, string name)
    {
        _scenes.Add(name, scene);
    }

    public void ActivateScene(string sceneName)
    {
        _history.Push(_activeScene);
        _scenes.TryGetValue(sceneName, out _activeScene);
        _activeScene?.Init();
    }

    public void DeactivateScene()
    {
        _activeScene = _history.Pop();
    }

    public void Update(GameTime gameTime)
    {
        _activeScene?.Update(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        _activeScene?.Draw(gameTime, spriteBatch);
    }
}
