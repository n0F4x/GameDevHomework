using Homework.Interfaces;

namespace Homework.Screens.MainScreen;

public class MainScene : IScene
{
    private readonly GameState _gameState;
    
    public MainScene(GameState gameState)
    {
        _gameState = gameState;
    }
}
