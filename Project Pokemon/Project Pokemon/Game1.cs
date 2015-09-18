using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Project_Pokemon {

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // Camera
        Camera camera = new Camera();

        // Player
        Player player = new Player();

        // Map
        TileMap myMap = new TileMap();

        // Music
        Song BGM;

        // Dev Tools
        DebugGui debug = new DebugGui();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {
            this.IsMouseVisible = true;
            camera.Initialize();
            player.Initialize(camera);
            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // Load Map
            Tile.TileSetTexture = Content.Load<Texture2D>(@"Textures\TileSets\GameMapTiles");

            // Load Player
            player.LoadContent(Content);

            // Load Debug
            debug.LoadContent(Content);

            // Load Music
            BGM = Content.Load<Song>(@"Sounds\Music\RS3_James_Hannigan"); // RS3_James_Hannigan //Har'Money_Remix
            
            // Load Cursor
            Cursor.Image = Content.Load<Texture2D>(@"Textures\Cursors\tile");
        }

        protected override void UnloadContent() {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime) {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            player.Update(gameTime);
            camera.Update(player.PlayerPosition);

            // Update Cursor
            Cursor.Location = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            Engine.Update(gameTime);

            // Debug
            debug.Update(gameTime, camera.Location);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.ViewMatrix);

            // Camera
            camera.Draw(spriteBatch, myMap); //TODO : pass myMap??

            // Draw Player
            player.Draw(spriteBatch);

            spriteBatch.End(); // end Matrix SpriteBatch

            spriteBatch.Begin();
            
            //Draw Debug
            debug.Draw(spriteBatch);

            // square cursor
            spriteBatch.Draw(Cursor.Image, new Rectangle((int)Cursor.Location.X * Tile.TileWidth, (int)Cursor.Location.Y * Tile.TileHeight, Tile.TileWidth, Tile.TileHeight), Color.White);

            spriteBatch.End();

            // Music
            if (MediaPlayer.State != MediaState.Playing)
                MediaPlayer.Play(BGM);

            base.Draw(gameTime);
        }
    }

} // END NAMESPACE
