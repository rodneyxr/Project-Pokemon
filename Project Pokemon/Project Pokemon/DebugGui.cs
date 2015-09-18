using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project_Pokemon {
    class DebugGui {

        SpriteFont DebugFont;
        Texture2D line;

        Vector2 camLocation;

        public void LoadContent(ContentManager Content) {
            DebugFont = Content.Load<SpriteFont>(@"Fonts\Debug");
            line = Content.Load<Texture2D>(@"line");
        }

        public void Update(GameTime gameTime, Vector2 cameraLocation) {
            camLocation = cameraLocation;
        }

        public void Draw(SpriteBatch spriteBatch) {
            // grid lines
            for (int x = 0; x < GraphicsDeviceManager.DefaultBackBufferWidth; x += 32)
                for (int y = 0; y < GraphicsDeviceManager.DefaultBackBufferHeight; y += 32)
                    spriteBatch.Draw(line, new Rectangle(x, y, 32, 32), Color.White);

            // Upperleft Info
            spriteBatch.DrawString(DebugFont, 
                "FPS: " + Engine.fps
                //+ "\nvelocityx: " + Camera.velocity.X
                //+ "\nvelocityy: " + Camera.velocity.Y
                + "\nMouse X: " + (int)Cursor.Location.X
                + "\nMouse Y: " + (int)Cursor.Location.Y
                + "\nCam X: " + (int)camLocation.X / Tile.TileWidth
                + "\nCam Y: " + (int)camLocation.Y / Tile.TileHeight
                + "\n\nCONTROLS: "
                + "\nRun -> Alt"
                + "\nBicycle -> B"
                + "\nZoom In -> Z"
                + "\nZoom Out -> X"
                , Vector2.Zero, Color.Purple);
        }

    }
}
