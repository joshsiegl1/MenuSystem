using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch; 

namespace MenuSystem.Menu
{
    public class SubMenuManager
    {
        private GraphicsDevice device;
        private Dictionary<string, Menu> Menus;

        public bool isActive
        {
            get
            {
                foreach (Menu menu in Menus.Values)
                    if (menu.isActive)
                        return true;
                return false;
            }
        }

        public bool ContainsKey(string key)
        {
            foreach (string s in Menus.Keys)
                if (Menus.ContainsKey(s))
                    return true; 

            return false; 
        }

        public SubMenuManager(GraphicsDevice device) 
        {
            this.device = device;
            Menus = new Dictionary<string, Menu>(); 
        }

        public SubMenuManager(GraphicsDevice device, Dictionary<string, Menu> dict)
        {
            this.device = device;
            this.Menus = dict;
        }

        public void Update(GameTime gametime, TouchCollection TC)
        {
            foreach (Menu menu in Menus.Values)
                menu.Update(gametime, TC); 
        }

        public void SetActive(string key)
        {
                for (int i = 0; i < Menus.Count; i++)
                {
                    if (Menus.ElementAt(i).Key == key)
                        Menus.ElementAt(i).Value.Reset(true);
                    else Menus.ElementAt(i).Value.Reset(false);
                }
        }

        public void Exit()
        {
            SetActive("None"); 
        }

        public void Add(string key, Menu value)
        {
            if (!Keys.Contains(key))
            {
                if (!Menus.Contains(new KeyValuePair<string, Menu>(key, value)))
                    Menus.Add(key, value);
            }
        }

        public IEnumerable<string> Keys
        {
            get
            {
                foreach (string key in Menus.Keys)
                    yield return key;

                yield return "None";
            }
        }

        public void Draw(SpriteBatch sbatch)
        {
            foreach (Menu menu in Menus.Values)
            {
                if (menu.isActive)
                    menu.Draw(sbatch);
            }
        }
    }
}
