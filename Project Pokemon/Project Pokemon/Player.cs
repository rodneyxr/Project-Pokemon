using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Project_Pokemon {
    class Player {

        int spriteWidth = 32;
        int spriteHeight = 32;

        // Input
        KeyboardState ks; // keystate
        float speed = 100.0f;
        float[] speeds = { 100.0f, 200.0f, 350.0f };
        float moveSpeed;

        // Animation
        bool onBicycle;
        Animation playerAnimation = new Animation();
        Texture2D[] playerImage = new Texture2D[3];
        int[] animSpeed = { 167, 120, 100 };
        Vector2 playerPosition;
        Vector2 spritePosition;
        Vector2 tempFrame;


        public Vector2 SpritePosition {
            get { return spritePosition; }
            set { spritePosition = value; }
        }

        public int SpriteWidth {
            get { return spriteWidth; }
        }

        public int SpriteHeight {
            get { return spriteHeight; }
        }

        public Vector2 PlayerPosition {
            get { return playerPosition; }
            set { playerPosition = value; }
        }

        public void Initialize(Camera camera) {
            spritePosition = camera.CenterTile;
            playerPosition = new Vector2(0, 0);
            playerAnimation.Initialize(spritePosition, new Vector2(3, 4));
            tempFrame = Vector2.Zero;
        }

        public void LoadContent(ContentManager Content) {
            playerImage[0] = Content.Load<Texture2D>(@"Textures\Sprites\Player\player_walk_sprite"); // 0 - walk
            playerImage[1] = Content.Load<Texture2D>(@"Textures\Sprites\Player\player_run_sprite"); // 1 - run
            playerImage[2] = Content.Load<Texture2D>(@"Textures\Sprites\Player\player_bicycle_sprite"); // 2 - bicycle
            playerAnimation.AnimationImage = playerImage[0];
        }

        public void Update(GameTime gameTime) {
            ks = Engine.ks; // get keystate
            playerAnimation.Active = true; // assume player is moving
            moveSpeed = speed * (float)gameTime.ElapsedGameTime.TotalSeconds; // caculate movespeed
            spritePosition = playerAnimation.Position; // set where the player should be drawn (always center)

            // Update way of travel
            if (Engine.KeyToggled(Keys.B)) { // if user toggles bike
                if (onBicycle) {
                    onBicycle = false;
                } else {
                    onBicycle = true;
                    ChangeTravel(2);
                }
            } else if (!onBicycle) {
                if (ks.IsKeyDown(Keys.LeftAlt))
                    ChangeTravel(1);
                else {
                    ChangeTravel(0);
                }
            }

            // Move Player
            if (ks.IsKeyDown(Keys.Up) || ks.IsKeyDown(Keys.W)) { // UP
                playerPosition.Y -= moveSpeed;
                tempFrame.Y = 0;
            } else if (ks.IsKeyDown(Keys.Down) || ks.IsKeyDown(Keys.S)) { // DOWN
                playerPosition.Y += moveSpeed;
                tempFrame.Y = 1;
            } else if (ks.IsKeyDown(Keys.Right) || ks.IsKeyDown(Keys.D)) { // LEFT
                playerPosition.X += moveSpeed;
                tempFrame.Y = 3;
            } else if (ks.IsKeyDown(Keys.Left) || ks.IsKeyDown(Keys.A)) { // RIGHT
                playerPosition.X -= moveSpeed;
                tempFrame.Y = 2;
            } else {
                playerAnimation.Active = false;
                if (!onBicycle) // prevent t-bagging lol
                   ChangeTravel(0);
            }

            playerPosition.X = MathHelper.Clamp(playerPosition.X, 0, (50 - SpritePosition.X / 16) * Tile.TileWidth); // Update playerposition for camera
            playerPosition.Y = MathHelper.Clamp(playerPosition.Y, 0, (50 - SpritePosition.Y / 16) * Tile.TileWidth); // Update playerposition for camera

            playerAnimation.Position = SpritePosition; // update sprite position (always center)
            tempFrame.X = playerAnimation.CurrentFrame.X; // hold the frame.X
            playerAnimation.CurrentFrame = tempFrame; // next frame

            playerAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            playerAnimation.Draw(spriteBatch);
        }

        void ChangeTravel(int id) {
            playerAnimation.AnimationImage = playerImage[id];
            playerAnimation.Timer = animSpeed[id];
            speed = speeds[id];
        }
    }
}
