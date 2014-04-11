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
    public class Pause : Menu
    {
        public Pause(GraphicsDevice device) :
            base(device)
        {

        }

        private void soundHandler(object sender, EventArgs e)
        {
            if (!GlobalOptions.hasSound)
            {
                GlobalOptions.hasSound = true;
            }
            else
            {
                GlobalOptions.hasSound = false;
            }
        }

        protected override void BackHandler(object sender, EventArgs e)
        {
            isActive = false;
            GlobalOptions.SetState(GlobalOptions.PreviousState); 
        }

        public override void Update(GameTime gametime, Microsoft.Xna.Framework.Input.Touch.TouchCollection TC)
        {
            if (GlobalOptions.hasSound)
                Buttons["Sound"].Labal = "Sound: On";
            else Buttons["Sound"].Labal = "Sound: Off";

            base.Update(gametime, TC);
        }

        private void quitHandler(object sender, EventArgs e)
        {
            RevertBy(5);
            GlobalOptions.HardReset = true; 
            isActive = false; 
        }

        protected override void Initialize()
        {
            base.Initialize(); 

            Add_Button("Resume", new Button("Resume", new Rectangle(MenuCenterX - 100, 100 + MenuCenterY, 200, 50)), BackHandler);
            Add_Button("Sound", new Button("Sound: On", new Rectangle(MenuCenterX - 100, 170 + MenuCenterY, 200, 50)), soundHandler); 
            Add_Button("Quit", new Button("Quit", new Rectangle(MenuCenterX - 100, 310 + MenuCenterY, 200, 50)), quitHandler);
        }

        public override void Draw(SpriteBatch sbatch)
        {
            if (isActive)
            {
                //sbatch.Draw(SpriteSheet.Menu.paused, new Vector2(MenuCenterX - 66, MenuCenterY + 20), Color.White);

                foreach (Button button in Buttons.Values)
                    button.Draw(sbatch);
            }

            base.Draw(sbatch);
        }
    }
}
