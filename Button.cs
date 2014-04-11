using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MenuSystem.Helper; 

namespace MenuSystem.Menu
{
    public class Button
    {
        private string label = "";
        public string Labal { get { return label; } set { label = value; } } 
        private Rectangle pos;

        private Texture2D text;
        private Texture2D pressedtext; 

        public Rectangle Bounds { get { return pos; } } 

        public bool isPressed;
        private bool isHovered;


        public Button(string text, Rectangle pos)
        {
            this.label = text;
            this.pos = pos;

            this.text = SpriteSheet.Menu.Buttons.Button_texture; 
            this.pressedtext = SpriteSheet.Menu.Buttons.ButtonPressed_texture; 
        }

        public Button(string text, Rectangle pos, Texture2D texture, Texture2D pressedtexture)
        {
            this.label = text;
            this.pos = pos;
            this.text = texture;
            this.pressedtext = pressedtexture; 
        }

        public event EventHandler onClick;
        private void Click()
        {
            if (onClick != null)
            {
                onClick(this, EventArgs.Empty);
                SoundManager.Play_Click(); 
            }

                isPressed = true;
        }

        public virtual void Mouse_Check(TouchCollection TC)
        {
            foreach (TouchLocation TL in TC)
            {
                if (pos.Contains((int)TL.Position.X, (int)TL.Position.Y) && TL.State == TouchLocationState.Pressed)
                    Click(); //isPressed = true; 
                else if (pos.Contains((int)TL.Position.X, (int)TL.Position.Y)) { isHovered = true; isPressed = false;  }
                else { isHovered = false; isPressed = false; }
            }
        }

        public void Draw(SpriteBatch sbatch)
        {
            if (isHovered && pressedtext != null) sbatch.Draw(pressedtext, pos, Color.White);
            else sbatch.Draw(text, pos, Color.White);

            if (isHovered) sbatch.DrawString(Fonts.ButtonFont, label, new Vector2(pos.X + 10, pos.Y + (pos.Height / 3) + 1), Color.White);
            else sbatch.DrawString(Fonts.ButtonFont, label, new Vector2(pos.X + 10, pos.Y + (pos.Height / 3)), Color.White);
        }
    }
}
