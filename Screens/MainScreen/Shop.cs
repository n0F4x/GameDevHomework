using Homework.Elements;
using Homework.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Screens.MainScreen;

public class Shop : Sprite
{
    public bool Hidden { get; set; } = true;

    public Shop(IShape shape, Game game) : base(shape, AssetManager.LoadTexture(game.Content, "bolt"))
    {
    }

    public void Update(GameTime gameTime)
    {
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (!Hidden)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
