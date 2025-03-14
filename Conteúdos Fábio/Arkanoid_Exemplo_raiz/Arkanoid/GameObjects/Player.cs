﻿#define AUTOMATIC

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arkanoid
{
    public class Player : GameObject
    {
        private Vector2 Speed { get; set; }

        public Player(Vector2 position, Texture2D texture, Vector2 speed)
            : base(position, texture)
        {
            this.Speed = speed;
        }

        public override void Update(Rectangle clientBounds)
        {
#if AUTOMATIC
#else
            this.Input();
#endif
            if (Position.X < 0)
                Position = new Vector2(0, Position.Y);
            else if (Position.X > GlobalInfo.WIDTH - 200 - this.Texture.Width)
                Position = new Vector2(GlobalInfo.WIDTH - 200 - this.Texture.Width, Position.Y);

            base.Update(clientBounds);
        }

        public void UpdatePosition(GameObject gameObject)
        {
#if AUTOMATIC
            this.Position = new Vector2(gameObject.Position.X - 34, Position.Y);
#endif
        }

        private void Input()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                this.Position -= this.Speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                this.Position += this.Speed;

            /*
            if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
            {
                this.Position -= this.Speed;
            }
            else if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
            {
                this.Position += this.Speed;
            }
            else
            {
                if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X != 0)
                {
                    this.Position += new Vector2(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X, 0) * this.Speed;
                }
                else
                {
                    if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X != 0)
                        this.Position += new Vector2(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X, 0) * this.Speed;
                }
            }
             * */

        }
    }
}
