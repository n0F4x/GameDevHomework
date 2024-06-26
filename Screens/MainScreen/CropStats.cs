﻿using Homework.Elements;
using Homework.Interfaces;
using Homework.Mixins;
using Homework.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Screens.MainScreen;

public class CropStats : IUpdatable
{
    private readonly GameState _gameState;

    private Button _wheatButton;
    private Button _potatoButton;
    private Button _carrotButton;

    private Label _wheatCounter;
    private Label _potatoCounter;
    private Label _carrotCounter;

    public CropStats(IShape shape, Game game, GameState gameState)
    {
        _gameState = gameState;
        var margin = shape.Width / 8;

        InitButtons(shape, game, margin);
        InitCounters(shape, game, margin);
    }

    public void Update(GameTime gameTime)
    {
        ((Sprite)_wheatButton.DefaultDrawable).Color =
            _gameState.SelectedCropType == CropType.Wheat ? Color.CornflowerBlue : Color.White;
        ((Sprite)_potatoButton.DefaultDrawable).Color =
            _gameState.SelectedCropType == CropType.Potato ? Color.CornflowerBlue : Color.White;
        ((Sprite)_carrotButton.DefaultDrawable).Color =
            _gameState.SelectedCropType == CropType.Carrot ? Color.CornflowerBlue : Color.White;

        _wheatButton.Update(gameTime);
        _potatoButton.Update(gameTime);
        _carrotButton.Update(gameTime);

        _wheatCounter.Text = _gameState.CropStats[CropType.Wheat].ToString();
        _potatoCounter.Text = _gameState.CropStats[CropType.Potato].ToString();
        _carrotCounter.Text = _gameState.CropStats[CropType.Carrot].ToString();
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
        _wheatButton = new Button(
            new Shape(shape.Position, new Vector2(shape.Width / 8, shape.Height), shape.Origin),
            new Sprite(Shape.Zero, AssetManager.LoadTexture(game.Content, "wheat")),
            new Sprite(Shape.Zero, AssetManager.LoadTexture(game.Content, "wheat")) { Color = Color.LawnGreen }
        );
        _wheatButton.OnClick += () => _gameState.SelectedCropType = CropType.Wheat;

        _potatoButton = new Button(
            new Shape(
                new Point((int)(shape.X + margin * 3), shape.Y),
                new Vector2(shape.Width / 8, shape.Height),
                shape.Origin
            ),
            new Sprite(Shape.Zero, AssetManager.LoadTexture(game.Content, "potato")),
            new Sprite(Shape.Zero, AssetManager.LoadTexture(game.Content, "potato")) { Color = Color.LawnGreen }
        );
        _potatoButton.OnClick += () => _gameState.SelectedCropType = CropType.Potato;

        _carrotButton = new Button(
            new Shape(
                new Point((int)(shape.X + margin * 6), shape.Y),
                new Vector2(shape.Width / 8, shape.Height),
                shape.Origin
            ),
            new Sprite(Shape.Zero, AssetManager.LoadTexture(game.Content, "carrot")),
            new Sprite(Shape.Zero, AssetManager.LoadTexture(game.Content, "carrot")) { Color = Color.LawnGreen }
        );
        _carrotButton.OnClick += () => _gameState.SelectedCropType = CropType.Carrot;
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
            _gameState.CropStats[CropType.Wheat].ToString()
        );
        _potatoCounter = new Label(
            new Shape(
                new Point((int)(shape.X + margin * 4), shape.Y),
                new Vector2(shape.Width / 8, shape.Height),
                shape.Origin
            ),
            AssetManager.LoadFont(game.Content, "DancingScript"),
            _gameState.CropStats[CropType.Potato].ToString()
        );
        _carrotCounter = new Label(
            new Shape(
                new Point((int)(shape.X + margin * 7), shape.Y),
                new Vector2(shape.Width / 8, shape.Height),
                shape.Origin
            ),
            AssetManager.LoadFont(game.Content, "DancingScript"),
            _gameState.CropStats[CropType.Carrot].ToString()
        );
    }
}
