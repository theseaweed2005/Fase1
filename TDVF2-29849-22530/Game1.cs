﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project002;
using TDVF2_29849_22530.Manager;
using TDVF2_29849_22530.Stuff;

namespace Project002
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager _gameManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Globals.Bounds = new Vector2(1536, 1024);
            _graphics.PreferredBackBufferWidth = (int)Globals.Bounds.X;
            _graphics.PreferredBackBufferHeight = (int)Globals.Bounds.Y;
            _graphics.ApplyChanges();

            Globals.Content = Content;
            _gameManager = new GameManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = _spriteBatch;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.Update(gameTime);
            _gameManager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            _spriteBatch.Begin();
            _gameManager.Draw();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
