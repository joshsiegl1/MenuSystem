using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Input; 

using MenuSystem.Helper;
using MenuSystem.Game; 

namespace MenuSystem.Menu
{
    public class Main : Menu
    {
        public Main(GraphicsDevice device)
            : base(device)
        {
            SubMenu.Add("Credits", new Credits(device));
            SubMenu.Add("Play", new Play(device));
            SubMenu.Add("Options", new Options(device)); 
        }

        private void PlayClassicHandler(object sender, EventArgs e)
        {
            SubMenu.SetActive("Play");
            Block_Buttons(250f); 
        }

        private void OptionsHandler(object sender, EventArgs e)
        {
            SubMenu.SetActive("Options");
            Block_Buttons(250f); 
        }

        private void CredtisHandler(object sender, EventArgs e)
        {
            SubMenu.SetActive("Credits");
            Block_Buttons(250f); //Block buttons so user doesn't hit them by accident coming back
        }

        private void ExitHandler(object sender, EventArgs e)
        {
            Game.GlobalOptions.Exit = true;
            return;
        }

        protected override void BackHandler(object sender, EventArgs e)
        {
            GlobalOptions.Exit = true; 
        }

        protected override void Initialize()
        {
            base.Initialize(); 

            Add_Button("Play", new Button("Play", new Rectangle(MenuCenterX - 100, MenuCenterY + 100, 200, 50)), PlayClassicHandler);
            Add_Button("Options", new Button("Options", new Rectangle(MenuCenterX - 100, MenuCenterY + 170, 200, 50)), OptionsHandler);
            Add_Button("Credits", new Button("Credits", new Rectangle(MenuCenterX - 100, MenuCenterY + 240, 200, 50)), CredtisHandler);
            Add_Button("Exit", new Button("Exit", new Rectangle(MenuCenterX - 100, MenuCenterY + 310, 200, 50)), ExitHandler);
        }

        public override void Draw(SpriteBatch sbatch)
        {
            if (isActive)
            {
                if (Game.GlobalOptions.State == Game.GlobalOptions.GameState.None) //Used to display Logo only on the Menu
                    sbatch.Draw(SpriteSheet.Menu.Logo, new Vector2(MenuCenterX - 250, MenuCenterY - 100), Color.White);

                if (!SubMenu.isActive)
                    foreach (Button button in Buttons.Values)
                        button.Draw(sbatch);

                if (SubMenu.isActive)
                    SubMenu.Draw(sbatch); 
            }

            base.Draw(sbatch);
        }
    }
}
