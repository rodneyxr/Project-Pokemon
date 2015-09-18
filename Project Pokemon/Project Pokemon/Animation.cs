using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Pokemon {
    class Animation {

        int frameCounter;
        int switchFrame;
        int baseFrame;
        int next;

        bool active;

        Vector2 position;
        Vector2 amountOfFrames;
        Vector2 currentFrame;

        Texture2D Image;
        Rectangle sourceRect;

        public bool Active {
            get { return active; }
            set { active = value; }
        }

        public int Timer {
            get { return switchFrame; }
            set { switchFrame = value; }
        }

        public Vector2 CurrentFrame {
            get { return currentFrame; }
            set { currentFrame = value; }
        }

        public Vector2 Position {
            get { return position; }
            set { position = value; }
        }

        public Texture2D AnimationImage {
            set { Image = value; }
        }

        public int FrameWidth {
            get { return Image.Width / (int) amountOfFrames.X; }
        }

        public int FrameHeight {
            get { return Image.Height / (int) amountOfFrames.Y; }
        }

        public int BaseFrame {
            get { return baseFrame; }
            set { baseFrame = value * 32; }
        }

        public void Initialize(Vector2 position, Vector2 Frames) {
            active = false;
            switchFrame = 167; // walking speed

            //baseframe
            BaseFrame = 1;
            next = 32;

            this.position = position;
            this.amountOfFrames = Frames;
        }

        public void Update(GameTime gameTime) {
            if (active)
                frameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            else {
                frameCounter = 0;
                currentFrame.X = baseFrame;
            }
            if (frameCounter >= switchFrame) {
                frameCounter = 0;
                if (amountOfFrames.X == 3) {
                    if (currentFrame.X < baseFrame)
                        next = FrameWidth;
                    else if (currentFrame.X > baseFrame)
                        next = -FrameWidth;
                    currentFrame.X += next;
                } else {
                    currentFrame.X += FrameWidth;
                    if (currentFrame.X > Image.Width)
                        currentFrame.X = baseFrame;
                }
            }
            sourceRect = new Rectangle(
                (int) currentFrame.X, (int) currentFrame.Y * FrameHeight, FrameWidth, FrameHeight);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Image, position, sourceRect, Color.White);
        }

    }
}
