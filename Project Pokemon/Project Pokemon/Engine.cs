using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Project_Pokemon {

    class Engine {

        // FPS
        static public int tSec = DateTime.Now.Second;
        static public int ticks = 0;
        static public int fps = 0;

        // Keyboard
        static public KeyboardState pks;
        static public KeyboardState ks;

        // Mouse
        static public MouseState pms;
        static public MouseState ms;


        public static void FpsCounter() {
            if (tSec == DateTime.Now.Second)
                ticks += 1;
            else {
                fps = ticks;
                ticks = 0;
                tSec = DateTime.Now.Second;
            }
        }

        public static bool KeyToggled(Keys key) {
            if (ks.IsKeyDown(key) && pks.IsKeyUp(key))
                return true;
            return false;
        }

        public static void Update(GameTime gameTime) {
            // Update Keystates
            pks = ks;
            ks = Keyboard.GetState();

            // Update Mousestates
            pms = ms;
            ms = Mouse.GetState();

            // Update FPS
            FpsCounter();
        }
    }
}
