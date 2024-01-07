using Homework.Interfaces;

namespace Homework.Scenes;

public interface IScene : IUpdateable, IDrawable
{
    void Init();
}
