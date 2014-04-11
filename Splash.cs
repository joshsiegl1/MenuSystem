using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MenuSystem.Helper; 

namespace MenuSystem.Menu
{
    public class Splash : Menu
    {
        private float SplashTimer = 0f; 

        public Splash(GraphicsDevice device) 
            : base(device) 
        {
            isActive = true; 
        }

        public override void Update(GameTime gametime, Microsoft.Xna.Framework.Input.Touch.TouchCollection TC)
        {
            if (isActive)
            {
                SplashTimer += (float)gametime.ElapsedGameTime.TotalMilliseconds;
                if (SplashTimer >= 3000)
                    isActive = false;
            }
            base.Update(gametime, TC);
        }

        public override void Draw(SpriteBatch sbatch)
        {
            if (isActive)
                sbatch.Draw(SpriteSheet.Menu.Splash_texture, new Rectangle(0, 0, device.Viewport.Width, device.Viewport.Height), Color.White); 
            base.Draw(sbatch);
        }
    }
}
