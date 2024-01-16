using Homework.Elements;
using Homework.Interfaces;
using Homework.Mixins;
using Homework.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Screens.MainScreen;

public class PlayerUi
{
    private readonly GameState _gameState;

    private readonly Sprite _icon;
    private readonly Label _label;
    private readonly Sprite _moneyIcon;
    private readonly Label _moneyLabel;

    public PlayerUi(Game game, IShape shape, GameState gameState)
    {
        _gameState = gameState;

        _icon = MakePlayerIcon(game, shape);
        _label = MakePlayerLabel(game, shape, gameState.PlayerName);
        _moneyIcon = MakeMoneyIcon(game, shape);
        _moneyLabel = MakeMoneyLabel(game, shape, gameState.Money);
    }

    public void Update(GameTime gameTime)
    {
        _moneyLabel.Text = _gameState.Money.ToString();
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        _icon.Draw(gameTime, spriteBatch);
        _label.Draw(gameTime, spriteBatch);
        _moneyIcon.Draw(gameTime, spriteBatch);
        _moneyLabel.Draw(gameTime, spriteBatch);
    }

    private static Sprite MakePlayerIcon(Game game, IShape shape)
    {
        return new Sprite(
            new Shape(Point.Zero, new Vector2(shape.Height / 2, shape.Height / 2), shape.Origin),
            AssetManager.LoadTexture(game.Content, "player")
        );
    }

    private static Label MakePlayerLabel(Game game, IShape shape, string playerName)
    {
        return new Label(
            new Shape(
                new Point((int)shape.Height / 2 + 10, 0),
                new Vector2(shape.Width - shape.Height / 2, shape.Height / 2),
                shape.Origin
            ),
            AssetManager.LoadFont(game.Content, "DancingScript"),
            playerName
        );
    }

    private static Sprite MakeMoneyIcon(Game game, IShape shape)
    {
        return new Sprite(
            new Shape(
                new Point(0, (int)(shape.Height / 2)),
                new Vector2(shape.Height / 2, shape.Height / 2),
                shape.Origin
            ),
            AssetManager.LoadTexture(game.Content, "CsP")
        );
    }

    private static Label MakeMoneyLabel(Game game, IShape shape, int money)
    {
        return new Label(
            new Shape(
                new Point((int)shape.Height / 2 + 10, (int)shape.Height / 2),
                new Vector2(shape.Height / 2, shape.Height / 2),
                shape.Origin
            ),
            AssetManager.LoadFont(game.Content, "DancingScript"),
            money.ToString()
        );
    }
}
