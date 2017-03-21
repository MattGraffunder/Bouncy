using Bouncy.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Bouncy
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Disc> _discs = new List<Disc>();

        Renderer renderer;

        private int _gameWorldWidth = 100;
        private int _gameWorldHeight = 100;

        private int _renderedWidth = 500;
        private int _renderedHeight = 500;

        GameInput _input;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            renderer = new Renderer();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = _renderedWidth;
            graphics.PreferredBackBufferHeight = _renderedHeight;
            graphics.ApplyChanges();

            IsMouseVisible = true;

            renderer.Initialize(GraphicsDevice, _gameWorldWidth, _gameWorldHeight, _discs);

            _input = InputFactory.GetInput(_renderedWidth / _gameWorldWidth, _renderedHeight / _gameWorldHeight);

            _discs.Add(new Disc(5, new Vector2(_gameWorldWidth / 2, _gameWorldHeight / 2), new Vector2(.5f, 1)));
            _discs.Add(new Disc(5, new Vector2(_gameWorldWidth / 4, _gameWorldHeight / 4), new Vector2(1, 1.5f)));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content hereS
            Texture2D circleTexture = Content.Load<Texture2D>("Graphics/Circle");

            renderer.AddRenderItem(typeof(Disc), circleTexture);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _input.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (_input.Clear)
            {
                _discs.Clear();
            }

            if (_input.Click)
            {
                float xVelocity = 2 * _input.XDirection / (float)_gameWorldWidth;
                float yVelocity = 2 * _input.YDirection / (float)_gameWorldHeight;

                _discs.Add(new Disc(5, new Vector2(_input.XDirection, _input.YDirection), new Vector2(xVelocity, yVelocity)));
            }
            
            foreach (var disc in _discs)
            {
                // TODO: Add your update logic here
                disc.Update(gameTime);

                //Check if ball hit wall
                if (disc.Position.X - disc.Radius < 0)
                {
                    disc.SetXPosition(0 + disc.Radius);
                    disc.ReverseXVelocity();
                }

                if (disc.Position.X + disc.Radius >= _gameWorldWidth)
                {
                    disc.SetXPosition(_gameWorldWidth - disc.Radius);
                    disc.ReverseXVelocity();
                }

                //Check if ball hit ceiling
                if (disc.Position.Y - disc.Radius < 0)
                {
                    disc.SetYPosition(0 + disc.Radius);
                    disc.ReverseYVelocity();
                }

                if (disc.Position.Y + disc.Radius >= _gameWorldHeight)
                {
                    disc.SetYPosition(_gameWorldHeight - disc.Radius);
                    disc.ReverseYVelocity();
                }
            }

            List<Disc> removeDiscs = new List<Disc>();

            //Check collisions
            foreach (var disc in _discs)
            {
                foreach (var otherDisc in _discs)
                {
                    if (disc == otherDisc) continue;

                    var dist = Math.Pow((disc.Position.X - otherDisc.Position.X), 2) + Math.Pow((disc.Position.Y - otherDisc.Position.Y), 2);

                    if (dist < Math.Pow(disc.Radius + otherDisc.Radius, 2))
                    {
                        //Is collision
                        removeDiscs.Add(disc);
                        removeDiscs.Add(otherDisc);
                    }
                }
            }

            removeDiscs.ForEach(d => _discs.Remove(d));

            //Find distance between two disc centers
                //If less than twice the sum of the radii, they collide

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            renderer.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}