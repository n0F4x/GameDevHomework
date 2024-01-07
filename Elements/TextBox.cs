using Homework.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Homework.Elements;

public class TextBox : Label, IElement
{
    private bool _selected;

    public TextBox(IShape shape, GameWindow window, SpriteFont font, string text) : base(shape, font, text)
    {
        window.TextInput += TextInputHandler;
    }

    public void Update(GameTime gameTime)
    {
        var mouseState = Mouse.GetState();

        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            _selected = this.Bounds().Contains(mouseState.Position);
        }
    }

    private void TextInputHandler(object sender, TextInputEventArgs args)
    {
        if (!_selected) return;
        
        if (char.IsAscii(args.Character) && char.IsLetter(args.Character))
        {
            Text += args.Character;
        }
        if (args.Key == Keys.Back && Text.Length > 0)
        {
            Text = Text.Remove(Text.Length - 1, 1);
        }
    }
}
