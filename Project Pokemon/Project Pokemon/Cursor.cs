using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project_Pokemon {
    static class Cursor {

        static public Texture2D Image;
        static public Vector2 location = Vector2.Zero;
        static private int width = 32;
        static private int height = 32;

        static public Vector2 Location {
            get { return location; }
            set { location = new Vector2(Engine.ms.X / Tile.TileWidth, Engine.ms.Y / Tile.TileHeight); }
        }

        static public Rectangle GetSourceRectangle(int tileIndex) {
            return new Rectangle(tileIndex * width, 0, width, height);
        }

    }
}
