using System;
using System.Collections.Generic;
using System.Linq; 

using Microsoft.Xna.Framework; 

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Input; 

namespace MenuSystem.Menu
{
    public abstract class Menu //Maybe give Menu it's own SubMenu
    {
        protected GraphicsDevice device;

        protected SubMenuManager SubMenu;

        private static int RevertCount = 0;
        private void CheckforRevert()
        {
            if (RevertCount > 0)
            {
                isActive = false;
                RevertCount--; 
            }
        }

        protected void RevertBy(int count)
        {
            RevertCount = count; 
        }


        protected int MenuCenterX, MenuCenterY;

        protected Dictionary<string, Button> Buttons;

        public bool isActive;

        protected bool Show_Buttons = true;

        private float BlockButtonTimer = 0f;
        private float Time = 0f;
        protected bool BlockButtons = false; 

        public Menu(GraphicsDevice device) {
            this.device = device;
            this.MenuCenterX = device.Viewport.Width / 2;
            this.MenuCenterY = 100;

            SubMenu = new SubMenuManager(device);

            Initialize(); 
        }

        protected void Replace_Button(string key, string name, EventHandler handler)
        {
            Buttons[key] = new Button(name, Buttons[key].Bounds);
            Buttons[key].onClick += handler; 
        }

        protected void Replace_Button(string key, string name, int width, EventHandler handler)
        {
            Rectangle bounds = new Rectangle(Buttons[key].Bounds.X, Buttons[key].Bounds.Y, width, Buttons[key].Bounds.Height); 
            Buttons[key] = new Button(name, bounds);
            Buttons[key].onClick += handler;
        }

        protected void Block_Buttons(float time)
        {
            BlockButtonTimer = 0f;
            Time = time;
            BlockButtons = true; 
        }

        protected void Add_Button(string name, Button button, EventHandler handler)
        {
            button.onClick += handler; 
            Buttons.Add(name, button); 
        }

        protected void Add_Menu(string name, Menu menu)
        {
            SubMenu.Add(name, menu); 
        }

        protected virtual void Initialize()
        {
            Buttons = new Dictionary<string, Button>();
            onBack += BackHandler; 
        }

        public void Reset(bool isActive)
        {
            this.isActive = isActive;
            Initialize(); 
        }

        protected event EventHandler onBack; 
        private void Back()
        {
            if (onBack != null)
                onBack(this, EventArgs.Empty); 
        }

        protected virtual void BackHandler(object sender, EventArgs e)
        {
             
        }

        public virtual void Update(GameTime gametime, TouchCollection TC)
        {
            if (isActive)
            {
                //if (Game.GlobalOptions.State == Game.GlobalOptions.GameState.None)
                //{
                //    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                //        RevertBy(1);
                //}
                //else
                //{
                //    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                //    {
                //        if (SubMenu.ContainsKey("Pause"))
                //        {
                //            SubMenu.SetActive("Pause");
                //            Game.GlobalOptions.SetState(Game.GlobalOptions.GameState.None); 
                //        }
                //    }
                //}
                    

                SubMenu.Update(gametime, TC);
                CheckforRevert(); 
            }

            if (!SubMenu.isActive)
            {
                if (BlockButtons)
                {
                    BlockButtonTimer += (float)gametime.ElapsedGameTime.TotalMilliseconds;
                    if (BlockButtonTimer >= Time)
                        BlockButtons = false;
                }

                if (!BlockButtons && isActive)
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                        Back();

                if (isActive && Show_Buttons && !BlockButtons)
                {
                    for (int i = 0; i < Buttons.Count; i++)
                    {
                        Buttons.ElementAt(i).Value.Mouse_Check(TC);
                    }
                }
            }
        }

        public virtual void Draw(SpriteBatch sbatch)
        {

        }
    }
}
