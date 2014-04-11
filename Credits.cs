using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

using MenuSystem.Helper; 

namespace MenuSystem.Menu
{
    public class Credits : Menu
    {
        private const string Credit = "Programming, Art, and Design \n         by Josh Siegl" +
           "\n\nGeneral play testing\n         by Harry Albright\n\nFor you Shelly <3"; 

        public Credits(GraphicsDevice device) 
            : base(device) 
        { 
        }

        protected override void BackHandler(object sender, EventArgs e)
        {
            isActive = false; 
        }

        protected override void Initialize()
        {
            base.Initialize(); 
            Add_Button("Back", new Button("Back", new Rectangle(MenuCenterX - 100, MenuCenterY + 310, 200, 50)), BackHandler);
        }

        public override void Draw(SpriteBatch sbatch)
        {
            sbatch.DrawString(Fonts.ButtonFont, Credit, new Vector2(MenuCenterX - 125, MenuCenterY + 100), Color.Black);

            foreach (Button button in Buttons.Values)
                button.Draw(sbatch); 

            base.Draw(sbatch);
        }
    }
}
