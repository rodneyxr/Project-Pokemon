using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Project_Pokemon {
    class Camera {

        // Matrix
        Vector2 position;
        Matrix viewMatrix;
        float scale = 1.0f;

        // Dimentions
        Vector2 centerTile;
        int width;// = 26; // Must be even
        int height;// = width * 9 / 16 + 2;
        Vector2 location;// = Vector2.Zero;

        // Smooth Camera
        bool isMoving;
        float speed;// = 120.0f;
        float friction;// = 0.9f;
        Vector2 velocity;// = Vector2.Zero;
        float stop;// = .001f;

        public Matrix ViewMatrix {
            get { return viewMatrix; }
        }

        public Vector2 CenterTile {
            get { return centerTile; }
            set { centerTile = value; }
        }

        public int ScreenWidth {
            get { return GraphicsDeviceManager.DefaultBackBufferWidth; }
        }

        public int ScreenHeight {
            get { return GraphicsDeviceManager.DefaultBackBufferHeight; }
        }

        public int Width {
            get { return width; }
            set { width = value; }
        }

        public int Height {
            get { return height; }
            set { height = value; }
        }

        public Vector2 Location {
            get { return location; }
            set { location = value; }
        }

        public void Initialize() {
            width = ScreenWidth / Tile.TileWidth + 1;
            height = ScreenHeight /  Tile.TileHeight + 1;
            location = Vector2.Zero;
            CenterTile = new Vector2((width - 1) / 2 * Tile.TileWidth, (height-1) / 2 * Tile.TileHeight);
        }

        public void LoadContent(ContentManager Content) { 
            
        }

        public void Update(Vector2 playerPosition) {

            position.X = ((centerTile.X + 16) - (ScreenWidth / 2) / scale);
            position.Y = ((centerTile.Y + 16) - (ScreenHeight / 2) / scale);

            if (position.X < 0)
                position.X = 0;
            if (position.Y < 0)
                position.Y = 0;
            
            Move(playerPosition);

            if (Keyboard.GetState().IsKeyDown(Keys.Z)) {
                if (scale < 3.0f)
                    scale += 0.01f;
            } else if (Keyboard.GetState().IsKeyDown(Keys.X)) {
                if (scale > 1.0f)
                    scale -= 0.01f;
            }

            viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0)) * Matrix.CreateScale(scale);
        }

        public void Draw(SpriteBatch spriteBatch, TileMap myMap) {

            Vector2 firstSquare = new Vector2(Location.X / Tile.TileWidth, Location.Y / Tile.TileHeight);
            int firstX = (int)firstSquare.X;
            int firstY = (int)firstSquare.Y;

            Vector2 squareOffset = new Vector2(Location.X % Tile.TileWidth, Location.Y % Tile.TileHeight);
            int offsetX = (int)squareOffset.X;
            int offsetY = (int)squareOffset.Y;

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {

                    foreach (int tileID in myMap.Rows[y + firstY].Columns[x + firstX].BaseTiles) {
                        spriteBatch.Draw(
                            Tile.TileSetTexture,
                            new Rectangle(
                                (x * Tile.TileWidth) - offsetX, (y * Tile.TileHeight) - offsetY,
                                Tile.TileWidth, Tile.TileHeight),
                            Tile.GetSourceRectangle(tileID),
                            Color.White);
                    }

                }
            }

        }
        
        public void Move(Vector2 playerPosition) {

            //if (location.Y < playerPosition.Y) {
            location.Y = MathHelper.Clamp(playerPosition.Y, 0, (50 - Height) * Tile.TileHeight);
            location.X = MathHelper.Clamp(playerPosition.X, 0, (50 - Width) * Tile.TileWidth);
           /*
            if (dir == 0) {
                location.Y = MathHelper.Clamp(Location.Y - speed, 0, (myMap.MapWidth - Height) * Tile.TileHeight);
                velocity.Y = -1 * (velocity.Y * friction);
            } else if (dir == 1) {
                location.Y = MathHelper.Clamp(Location.Y + speed, 0, (myMap.MapWidth - Height) * Tile.TileHeight);
                velocity.Y *= friction;
            } else if (dir == 2) {
                location.X = MathHelper.Clamp(Location.X - speed, 0, (myMap.MapHeight - Width) * Tile.TileWidth);
                velocity.X = -1 * (velocity.X * friction);
            } else if (dir == 3) {
                location.X = MathHelper.Clamp(Location.X + speed, 0, (myMap.MapHeight - Width) * Tile.TileWidth);
                velocity.X *= friction;
            }

            if (Math.Abs(velocity.X) < stop || Math.Abs(velocity.Y) < stop) {
                velocity = Vector2.Zero;
            }
            */
        }

    }
}
