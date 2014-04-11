using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch; 

namespace MenuSystem.Menu
{
    public class MenuManager
    {
        private Dictionary<string, Menu> Menus;

        public MenuManager(GraphicsDevice device)
        {
            Menus = new Dictionary<string, Menu>();

            Menus.Add("Splash", new Splash(device));
            Menus.Add("Main", new Main(device)); 
        }

        public void Update(GameTime gametime, TouchCollection TC)
        {
            if (!Menus["Splash"].isActive)
                SetActive("Main"); 

            foreach (Menu menu in Menus.Values)
            {
                menu.Update(gametime, TC); 
            }
        }

        private void SetActive(string key)
        {
            for (int i = 0; i < Menus.Count; i++)
            {
                if (Menus.ElementAt(i).Key == key)
                    Menus.ElementAt(i).Value.Reset(true); 
                else Menus.ElementAt(i).Value.Reset(false); 
            }
        }

        public void Draw(SpriteBatch sbatch)
        {
            foreach (Menu menu in Menus.Values)
            {
                menu.Draw(sbatch); 
            }
        }
    }
}
