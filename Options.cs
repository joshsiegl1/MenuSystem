using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MenuSystem.Game;
using MenuSystem.Helper;  

namespace MenuSystem.Menu
{
    public class Options : Menu
    {
        public Options(GraphicsDevice device)
            : base(device)
        {
        }

        protected override void BackHandler(object sender, EventArgs e)
        {
            isActive = false;
        }

        private void soundHandler(object sender, EventArgs e)
        {
            if (!GlobalOptions.hasSound)
            {
                Buttons["Sound"] = new Button("Sound: On", Buttons["Sound"].Bounds);
                Buttons["Sound"].onClick += soundHandler;
                GlobalOptions.hasSound = true;
            }
            else
            {
                Buttons["Sound"] = new Button("Sound: Off", Buttons["Sound"].Bounds);
                Buttons["Sound"].onClick += soundHandler;
                GlobalOptions.hasSound = false;
            }
        }

        private void difficultyHandler(object sender, EventArgs e)
        {
            switch (GlobalOptions.GameDifficulty)
            {
                case GlobalOptions.Difficulty.Easy:
                    GlobalOptions.GameDifficulty = GlobalOptions.Difficulty.Medium;
                    Replace_Button("Difficulty", "Difficulty: Medium", difficultyHandler);
                    break;
                case GlobalOptions.Difficulty.Medium:
                    GlobalOptions.GameDifficulty = GlobalOptions.Difficulty.Hard;
                    Replace_Button("Difficulty", "Difficulty: Hard", difficultyHandler);
                    break;
                case GlobalOptions.Difficulty.Hard:
                    GlobalOptions.GameDifficulty = GlobalOptions.Difficulty.Easy;
                    Replace_Button("Difficulty", "Difficulty: Easy", difficultyHandler);
                    break;
            }
        }

        protected override void Initialize()
        {
            base.Initialize();

            Add_Button("Sound", new Button("Sound: On", new Rectangle(MenuCenterX - 100, MenuCenterY + 100, 200, 50)), soundHandler);
            Add_Button("Difficulty", new Button("Difficulty: Easy", new Rectangle(MenuCenterX - 100, MenuCenterY + 170, 200, 50)), difficultyHandler); 
            Add_Button("Back", new Button("Back", new Rectangle(MenuCenterX - 100, MenuCenterY + 310, 200, 50)), BackHandler);
        }

        public override void Draw(SpriteBatch sbatch)
        {
            if (isActive)
            {
                foreach (Button button in Buttons.Values)
                {
                    button.Draw(sbatch);
                }
            }

            base.Draw(sbatch);
        }

    }
}
