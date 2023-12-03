using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Homework.Components;

public class TextBox : Label, IElement
{
    private bool _selected = false;

    public TextBox(IElement shape, GameWindow window, SpriteFont font, string text) : base(shape, font, text)
    {
        window.TextInput += TextInputHandler;
    }

    public virtual void Update(GameTime gameTime)
    {
        var mouseState = Mouse.GetState();

        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            if (this.Bounds().Contains(mouseState.Position))
            {
                _selected = true;
            }
            else
            {
                _selected = false;
            }
        }
    }

    private void TextInputHandler(object sender, TextInputEventArgs args)
    {
        if (_selected)
        {
            if (char.IsAscii(args.Character) && char.IsLetter(args.Character))
            {
                Text += args.Character;
            }
            if (args.Key == Keys.Back)
            {
                if (Text.Length > 0)
                {
                    Text = Text.Remove(Text.Length - 1, 1);
                }
            }
        }
    }
}
