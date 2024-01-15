using Homework.Elements;
using Homework.Interfaces;
using Homework.Mixins;
using Homework.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Screens.MainScreen;

public class PlayerUi
{
    private readonly Sprite _icon;
    private readonly Label _label;

    public PlayerUi(Game game, IShape shape, GameState gameState)
    {
        _icon = MakePlayerIcon(game, shape);
        _label = MakePlayerLabel(game, shape, gameState.PlayerName);
    }

    private static Sprite MakePlayerIcon(Game game, IShape shape)
    {
        return new Sprite(
            new Shape(Point.Zero, new Vector2(shape.Height, shape.Height), shape.Origin),
            AssetManager.LoadTexture(game.Content, "player")
        );
    }

    private static Label MakePlayerLabel(Game game, IShape shape, string playerName)
    {
        return new Label(
            new Shape(
                new Point((int)shape.Height + 10, 0),
                new Vector2(shape.Width - shape.Height, shape.Height),
                shape.Origin
            ),
            AssetManager.LoadFont(game.Content, "DancingScript"),
            playerName
        );
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        _icon.Draw(gameTime, spriteBatch);
        _label.Draw(gameTime, spriteBatch);
    }
}
