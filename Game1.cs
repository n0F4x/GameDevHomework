using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Homework;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D ballTexture;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        Window.AllowUserResizing = true;
        Window.ClientSizeChanged += OnResize;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        var w = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width * 3 / 4;
        var h = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 3 / 4;

        _graphics.PreferredBackBufferWidth = w;
        _graphics.PreferredBackBufferHeight = h;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Create a new SpriteBatch, which can be used to draw textures.
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        ballTexture = Content.Load<Texture2D>("icons/farm_icon");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _spriteBatch.Draw(
            ballTexture,
            new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2),
            null,
            Color.White,
            0f,
            new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    public void OnResize(Object sender, EventArgs e)
    {
        // Additional code to execute when the user drags the window
        // or in the case you programmatically change the screen or windows client screen size.
        // code that might directly change the backbuffer width height calling apply changes.
        // or passing changes that must occur in other classes or even calling there OnResize methods
        // though those methods can simply be added to the Windows event caller

    }
}
