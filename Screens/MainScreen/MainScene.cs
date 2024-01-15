﻿using Homework.Interfaces;
using Homework.Mixins;
using Homework.Screens.LoginScreen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Screens.MainScreen;

public class MainScene : IScene
{
    private readonly App _app;
    private readonly GameState _gameState;

    private PlayerUi _playerUi;
    private Crops _crops;
    private QuitButton _quitButton;

    private House _house;
    private Farm _farm;

    public MainScene(App app, GameState gameState)
    {
        _app = app;
        _gameState = gameState;
    }

    public void Init()
    {
        var width = _app.GraphicsDevice.Viewport.Width;
        var height = _app.GraphicsDevice.Viewport.Height;
        const int lineHeight = 110;

        _playerUi = new PlayerUi(
            _app,
            new Shape(Point.Zero, new Vector2(width / 4, lineHeight), new Vector2(-1, -1)),
            _gameState
        );

        _quitButton = new QuitButton(new Shape(
                new Point(width, 0),
                new Vector2(width / 15, height / 15),
                new Vector2(1, -1)
            ), AssetManager.LoadFont(_app.Content, "DancingScript"),
            () => _app.Exit());

        _house = new House(
            new Shape(new Point((int)(width / 2 - _quitButton.Width / 2), 0), new Vector2(width / 3, height / 4), new Vector2(0, -1)),
            _app,
            () => { }
        );

        _crops = new Crops(
            new Shape(
                _house.Position + new Point((int)_house.Width / 2, 0),
                new Vector2((width - _house.Width) / 2 - _quitButton.Width, lineHeight),
                -Vector2.One
            ),
            _app,
            _app.GameState
        );

        _farm = new Farm(new Shape(new Point(0, height / 3), new Vector2(width, height * 2 / 3)), _app);
    }

    public void Update(GameTime gameTime)
    {
        _quitButton.Update(gameTime);
        _house.Update(gameTime);
        _crops.Update(gameTime);
        _farm.Update(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        _playerUi.Draw(gameTime, spriteBatch);
        _quitButton.Draw(gameTime, spriteBatch);
        _house.Draw(gameTime, spriteBatch);
        _crops.Draw(gameTime, spriteBatch);
        _farm.Draw(gameTime, spriteBatch);
    }
}
