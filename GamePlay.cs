using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input; 

using MenuSystem.Helper;
using MenuSystem.Game; 

namespace MenuSystem.Menu
{
    public class GamePlay : Menu
    {

        public GamePlay(GraphicsDevice device) 
            : base(device) 
        {
            SubMenu.Add("Pause", new Pause(device)); 
        }

        protected override void Initialize()
        {
            base.Initialize();

            Add_Button("Pause", new Button("", new Rectangle(10,10,50, 45), SpriteSheet.Menu.Buttons.PauseButton_texture, SpriteSheet.Menu.Buttons.PauseButton_texture), PauseHandler); 
        }

        private void PauseHandler(object sender, EventArgs e)
        {
            GlobalOptions.SetState(GlobalOptions.GameState.None);
            SubMenu.SetActive("Pause");
        }

        protected override void BackHandler(object sender, EventArgs e)
        {
            GlobalOptions.SetState(GlobalOptions.GameState.None);
            isActive = false; 
        }

        public override void Update(GameTime gametime, Microsoft.Xna.Framework.Input.Touch.TouchCollection TC)
        {

            if (GlobalOptions.State == GlobalOptions.GameState.None)
                if (!SubMenu.isActive)
                    isActive = false;

            base.Update(gametime, TC);
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
