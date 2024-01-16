using Homework.Elements;
using Homework.Interfaces;
using Homework.Mixins;
using Homework.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework.Screens.MainScreen;

public class Shop : Sprite
{
    private Sprite _Nene;
    private Sprite _Bastya;

    private Label _sellLabel;
    private Label _buyLabel;

    private Sprite _wheatIcon;
    private Sprite _potatoIcon;
    private Sprite _carrotIcon;

    private Button _wheatSellingPrice;
    private Button _potatoSellingPrice;
    private Button _carrotSellingPrice;

    private Button _wheatBuyingPrice;
    private Button _potatoBuyingPrice;
    private Button _carrotBuyingPrice;


    public bool Hidden { get; set; } = true;

    public Shop(IShape shape, Game game, GameState gameState) : base(shape,
        AssetManager.LoadTexture(game.Content, "bolt"))
    {
        InitElements(shape, game, gameState);
    }

    public void Update(GameTime gameTime)
    {
        _wheatSellingPrice.Update(gameTime);
        _potatoSellingPrice.Update(gameTime);
        _carrotSellingPrice.Update(gameTime);

        _wheatBuyingPrice.Update(gameTime);
        _potatoBuyingPrice.Update(gameTime);
        _carrotBuyingPrice.Update(gameTime);
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (Hidden) return;

        base.Draw(gameTime, spriteBatch);

        _Nene.Draw(gameTime, spriteBatch);
        _Bastya.Draw(gameTime, spriteBatch);

        _sellLabel.Draw(gameTime, spriteBatch);
        _buyLabel.Draw(gameTime, spriteBatch);

        _wheatIcon.Draw(gameTime, spriteBatch);
        _potatoIcon.Draw(gameTime, spriteBatch);
        _carrotIcon.Draw(gameTime, spriteBatch);

        _wheatSellingPrice.Draw(gameTime, spriteBatch);
        _potatoSellingPrice.Draw(gameTime, spriteBatch);
        _carrotSellingPrice.Draw(gameTime, spriteBatch);

        _wheatBuyingPrice.Draw(gameTime, spriteBatch);
        _potatoBuyingPrice.Draw(gameTime, spriteBatch);
        _carrotBuyingPrice.Draw(gameTime, spriteBatch);
    }

    private void InitElements(IShape shape, Game game, GameState gameState)
    {
        InitCharacters(shape, game);
        InitLabels(shape, game);
        InitCropIcons(shape, game);
        InitSellingPrices(shape, game, gameState);
        InitBuyingPrices(shape, game, gameState);
    }

    private void InitCharacters(IShape shape, Game game)
    {
        _Nene = new Sprite(
            new Shape(
                shape.Position + new Point((int)(shape.Width / 10), 0),
                shape.Size / 2,
                Vector2.One
            ),
            AssetManager.LoadTexture(game.Content, "Nene")
        );
        _Bastya = new Sprite(
            new Shape(
                shape.Position - new Point((int)(shape.Width / 10), 0),
                shape.Size / 2,
                new Vector2(-1, 1)
            ),
            AssetManager.LoadTexture(game.Content, "Bastya")
        );
    }

    private void InitLabels(IShape shape, Game game)
    {
        _sellLabel = new Label(
            new Shape(
                new Point((int)(shape.Position.X - shape.Width / 4 + shape.Width / 10), shape.Y),
                new Vector2(shape.Width / 8, 55F),
                new Vector2(0, 1)
            ),
            AssetManager.LoadFont(game.Content, "DancingScript"),
            "Sell"
        );
        _buyLabel = new Label(
            new Shape(
                new Point((int)(shape.Position.X + shape.Width / 4 - shape.Width / 10), shape.Y),
                new Vector2(shape.Width / 8, 55F),
                new Vector2(0, 1)
            ),
            AssetManager.LoadFont(game.Content, "DancingScript"),
            "Buy"
        );
    }

    private void InitCropIcons(IShape shape, Game game)
    {
        const int lineHeight = 110;

        _wheatIcon = new Sprite(
            new Shape(
                new Point((int)(shape.X - shape.Width / 2 + shape.Width / 20), (int)(shape.Y + shape.Height / 8)),
                new Vector2(lineHeight, lineHeight),
                new Vector2(-1, 0)
            ),
            AssetManager.LoadTexture(game.Content, "wheat")
        );
        _potatoIcon = new Sprite(
            new Shape(
                new Point((int)(shape.X - shape.Width / 2 + shape.Width / 20), (int)(shape.Y + shape.Height / 8 * 2)),
                new Vector2(lineHeight, lineHeight),
                new Vector2(-1, 0)
            ),
            AssetManager.LoadTexture(game.Content, "potato")
        );
        _carrotIcon = new Sprite(
            new Shape(
                new Point((int)(shape.X - shape.Width / 2 + shape.Width / 20), (int)(shape.Y + shape.Height / 8 * 3)),
                new Vector2(lineHeight, lineHeight),
                new Vector2(-1, 0)
            ),
            AssetManager.LoadTexture(game.Content, "carrot")
        );
    }

    private void InitSellingPrices(IShape shape, Game game, GameState gameState)
    {
        _wheatSellingPrice = new Button(
            new Shape(
                new Point(
                    (int)(shape.Position.X - shape.Width / 4 + shape.Width / 10),
                    (int)(shape.Y + shape.Height / 8)
                ),
                new Vector2(shape.Width / 8, 55F)
            ),
            new Label(
                Zero,
                AssetManager.LoadFont(game.Content, "DancingScript"),
                GameState.SellingPrices[CropType.Wheat].ToString()
            ),
            new Label(
                Zero,
                AssetManager.LoadFont(game.Content, "DancingScript"),
                GameState.SellingPrices[CropType.Wheat].ToString()
            ) { Color = Color.LawnGreen }
        );
        _wheatSellingPrice.OnClick += () =>
        {
            if (
                gameState.CropStats[CropType.Wheat] <= 0
            ) return;

            gameState.Money += GameState.SellingPrices[CropType.Wheat];
            gameState.CropStats[CropType.Wheat]--;
        };
        _potatoSellingPrice = new Button(
            new Shape(
                new Point(
                    (int)(shape.Position.X - shape.Width / 4 + shape.Width / 10),
                    (int)(shape.Y + shape.Height / 8 * 2)
                ),
                new Vector2(shape.Width / 8, 55F)
            ),
            new Label(
                Zero,
                AssetManager.LoadFont(game.Content, "DancingScript"),
                GameState.SellingPrices[CropType.Potato].ToString()
            ),
            new Label(
                Zero,
                AssetManager.LoadFont(game.Content, "DancingScript"),
                GameState.SellingPrices[CropType.Potato].ToString()
            ) { Color = Color.LawnGreen }
        );
        _potatoSellingPrice.OnClick += () =>
        {
            if (
                gameState.CropStats[CropType.Potato] <= 0
            ) return;

            gameState.Money += GameState.SellingPrices[CropType.Potato];
            gameState.CropStats[CropType.Potato]--;
        };
        _carrotSellingPrice = new Button(
            new Shape(
                new Point(
                    (int)(shape.Position.X - shape.Width / 4 + shape.Width / 10),
                    (int)(shape.Y + shape.Height / 8 * 3)
                ),
                new Vector2(shape.Width / 8, 55F)
            ),
            new Label(
                Zero,
                AssetManager.LoadFont(game.Content, "DancingScript"),
                GameState.SellingPrices[CropType.Carrot].ToString()
            ),
            new Label(
                Zero,
                AssetManager.LoadFont(game.Content, "DancingScript"),
                GameState.SellingPrices[CropType.Carrot].ToString()
            ) { Color = Color.LawnGreen }
        );
        _carrotSellingPrice.OnClick += () =>
        {
            if (
                gameState.CropStats[CropType.Carrot] <= 0
            ) return;

            gameState.Money += GameState.SellingPrices[CropType.Carrot];
            gameState.CropStats[CropType.Carrot]--;
        };
    }

    private void InitBuyingPrices(IShape shape, Game game, GameState gameState)
    {
        _wheatBuyingPrice = new Button(
            new Shape(
                new Point(
                    (int)(shape.Position.X + shape.Width / 4 - shape.Width / 10),
                    (int)(shape.Y + shape.Height / 8)
                ),
                new Vector2(shape.Width / 8, 55F)
            ),
            new Label(
                Zero,
                AssetManager.LoadFont(game.Content, "DancingScript"),
                GameState.BuyingPrices[CropType.Wheat].ToString()
            ),
            new Label(
                Zero,
                AssetManager.LoadFont(game.Content, "DancingScript"),
                GameState.BuyingPrices[CropType.Wheat].ToString()
            ) { Color = Color.LawnGreen }
        );
        _wheatBuyingPrice.OnClick += () =>
        {
            if (
                gameState.Money < GameState.BuyingPrices[CropType.Wheat]
            ) return;

            gameState.Money -= GameState.BuyingPrices[CropType.Wheat];
            gameState.CropStats[CropType.Wheat]++;
        };
        _potatoBuyingPrice = new Button(
            new Shape(
                new Point(
                    (int)(shape.Position.X + shape.Width / 4 - shape.Width / 10),
                    (int)(shape.Y + shape.Height / 8 * 2)
                ),
                new Vector2(shape.Width / 8, 55F)
            ),
            new Label(
                Zero,
                AssetManager.LoadFont(game.Content, "DancingScript"),
                GameState.BuyingPrices[CropType.Potato].ToString()
            ),
            new Label(
                Zero,
                AssetManager.LoadFont(game.Content, "DancingScript"),
                GameState.BuyingPrices[CropType.Potato].ToString()
            ) { Color = Color.LawnGreen }
        );
        _potatoBuyingPrice.OnClick += () =>
        {
            if (
                gameState.Money < GameState.BuyingPrices[CropType.Potato]
            ) return;

            gameState.Money -= GameState.BuyingPrices[CropType.Potato];
            gameState.CropStats[CropType.Potato]++;
        };
        _carrotBuyingPrice = new Button(
            new Shape(
                new Point(
                    (int)(shape.Position.X + shape.Width / 4 - shape.Width / 10),
                    (int)(shape.Y + shape.Height / 8 * 3)
                ),
                new Vector2(shape.Width / 8, 55F)
            ),
            new Label(
                Zero,
                AssetManager.LoadFont(game.Content, "DancingScript"),
                GameState.BuyingPrices[CropType.Carrot].ToString()
            ),
            new Label(
                Zero,
                AssetManager.LoadFont(game.Content, "DancingScript"),
                GameState.BuyingPrices[CropType.Carrot].ToString()
            ) { Color = Color.LawnGreen }
        );
        _carrotBuyingPrice.OnClick += () =>
        {
            if (
                gameState.Money < GameState.BuyingPrices[CropType.Carrot]
            ) return;

            gameState.Money -= GameState.BuyingPrices[CropType.Carrot];
            gameState.CropStats[CropType.Carrot]++;
        };
    }
}
