﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid
{
    public class Congrats : Scene
    {
        private int count = 0;
        private const int MAX = 100;

        Background background { get; set; }

        public Congrats(Game game)
            : base(game)
        {
            this.background = new Background(Vector2.Zero, Game.Content.Load<Texture2D>(@"Images/bgCongrats"));
        }

        public override void Update(GameTime gameTime)
        {
            if (count++ >= MAX)
                SceneManager.ChangeScene(Game);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            this.background.Draw(spriteBatch, new Rectangle(0, 0, GlobalInfo.WIDTH, GlobalInfo.HEIGHT));

            spriteBatch.End();
        }
    }
}
