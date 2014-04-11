using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch; 

using MenuSystem.Helper;
using MenuSystem.Game; 

namespace MenuSystem.Menu
{
    public class Play : Menu
    {

        public Play(GraphicsDevice device)
            : base(device)
        {
            SubMenu.Add("GamePlay", new GamePlay(device)); 
        }

        private void ClassicHandler(object sender, EventArgs e)
        {
            GlobalOptions.SetState(GlobalOptions.GameState.Classic);
            SubMenu.SetActive("GamePlay");
            Block_Buttons(250f); 
        }

        private void ExtremeHandler(object sender, EventArgs e)
        {
            GlobalOptions.SetState(GlobalOptions.GameState.Extreme);
            SubMenu.SetActive("GamePlay");
            Block_Buttons(250f); 
        }

        protected override void BackHandler(object sender, EventArgs e)
        {
            isActive = false; 
        }

        

        protected override void Initialize()
        {
            base.Initialize();

            Add_Button("Classic", new Button("Classic", new Rectangle(MenuCenterX - 100, MenuCenterY + 100, 200, 50)), ClassicHandler);
            Add_Button("Extreme", new Button("Extreme", new Rectangle(MenuCenterX - 100, MenuCenterY + 170, 200, 50)), ExtremeHandler);
            Add_Button("Back", new Button("Back", new Rectangle(MenuCenterX - 100, MenuCenterY + 310, 200, 50)), BackHandler);
        }

        public override void Draw(SpriteBatch sbatch)
        {
            if (isActive)
            {

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
