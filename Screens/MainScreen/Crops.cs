using Homework.Elements;
using Homework.Interfaces;
using Homework.Mixins;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IUpdateable = Homework.Interfaces.IUpdateable;

namespace Homework.Screens.MainScreen;

public class Crops : IUpdateable
{
    private readonly GameState _gameState;

    private Sprite _wheatSprite;
    private Sprite _potatoSprite;
    private Sprite _carrotSprite;

    private Button _wheatButton;
    private Button _potatoButton;
    private Button _carrotButton;

    private Label _wheatCounter;
    private Label _potatoCounter;
    private Label _carrotCounter;

    public Crops(IShape shape, Game game, GameState gameState)
    {
        _gameState = gameState;
        var margin = shape.Width / 8;

        InitButtons(shape, game, margin);
        InitCounters(shape, game, margin);
    }

    public void Update(GameTime gameTime)
    {
        _wheatSprite.Color = _gameState.SelectedCrop == Crop.Wheat ? Color.CornflowerBlue : Color.White;
        _potatoSprite.Color = _gameState.SelectedCrop == Crop.Potato ? Color.CornflowerBlue : Color.White;
        _carrotSprite.Color = _gameState.SelectedCrop == Crop.Carrot ? Color.CornflowerBlue : Color.White;

        _wheatButton.Update(gameTime);
        _potatoButton.Update(gameTime);
        _carrotButton.Update(gameTime);

        _wheatCounter.Text = _gameState.CropStats[Crop.Wheat].ToString();
        _potatoCounter.Text = _gameState.CropStats[Crop.Potato].ToString();
        _carrotCounter.Text = _gameState.CropStats[Crop.Carrot].ToString();
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        _wheatButton.Draw(gameTime, spriteBatch);
        _potatoButton.Draw(gameTime, spriteBatch);
        _carrotButton.Draw(gameTime, spriteBatch);

        _wheatCounter.Draw(gameTime, spriteBatch);
        _potatoCounter.Draw(gameTime, spriteBatch);
        _carrotCounter.Draw(gameTime, spriteBatch);
    }

    private void InitButtons(IShape shape, Game game, float margin)
    {
        _wheatSprite = new Sprite(
            new Shape(shape.Position, new Vector2(shape.Width / 8, shape.Height), shape.Origin),
            AssetManager.LoadTexture(game.Content, "wheat")
        );
        _wheatButton = new Button(
            _wheatSprite,
            _wheatSprite,
            new Sprite(Shape.Zero, AssetManager.LoadTexture(game.Content, "wheat")) { Color = Color.LawnGreen }
        );
        _wheatButton.OnClick += () => _gameState.SelectedCrop = Crop.Wheat;

        _potatoSprite = new Sprite(
            new Shape(
                new Point((int)(shape.X + margin * 3), shape.Y),
                new Vector2(shape.Width / 8, shape.Height),
                shape.Origin
            ),
            AssetManager.LoadTexture(game.Content, "potato")
        );
        _potatoButton = new Button(
            _potatoSprite,
            _potatoSprite,
            new Sprite(Shape.Zero, AssetManager.LoadTexture(game.Content, "potato")) { Color = Color.LawnGreen }
        );
        _potatoButton.OnClick += () => _gameState.SelectedCrop = Crop.Potato;

        _carrotSprite = new Sprite(
            new Shape(
                new Point((int)(shape.X + margin * 6), shape.Y),
                new Vector2(shape.Width / 8, shape.Height),
                shape.Origin
            ),
            AssetManager.LoadTexture(game.Content, "carrot")
        );
        _carrotButton = new Button(
            _carrotSprite,
            _carrotSprite,
            new Sprite(Shape.Zero, AssetManager.LoadTexture(game.Content, "carrot")) { Color = Color.LawnGreen }
        );
        _carrotButton.OnClick += () => _gameState.SelectedCrop = Crop.Carrot;
    }

    private void InitCounters(IShape shape, Game game, float margin)
    {
        _wheatCounter = new Label(
            new Shape(
                new Point((int)(shape.X + margin * 1), shape.Y),
                new Vector2(shape.Width / 8, shape.Height),
                shape.Origin
            ),
            AssetManager.LoadFont(game.Content, "DancingScript"),
            _gameState.CropStats[Crop.Wheat].ToString()
        );
        _potatoCounter = new Label(
            new Shape(
                new Point((int)(shape.X + margin * 4), shape.Y),
                new Vector2(shape.Width / 8, shape.Height),
                shape.Origin
            ),
            AssetManager.LoadFont(game.Content, "DancingScript"),
            _gameState.CropStats[Crop.Potato].ToString()
        );
        _carrotCounter = new Label(
            new Shape(
                new Point((int)(shape.X + margin * 7), shape.Y),
                new Vector2(shape.Width / 8, shape.Height),
                shape.Origin
            ),
            AssetManager.LoadFont(game.Content, "DancingScript"),
            _gameState.CropStats[Crop.Carrot].ToString()
        );
    }
}
