using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bouncy
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Disc _disc;

        Renderer renderer;

        private int _gameWorldWidth = 100;
        private int _gameWorldHeight = 100;

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
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 500;
            graphics.ApplyChanges();

            renderer.Initialize(GraphicsDevice, _gameWorldWidth, _gameWorldHeight);

            _disc = new Disc(new Vector2(_gameWorldWidth / 2, _gameWorldHeight / 2), 5);
                        
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

            renderer.AddRenderItem(_disc, circleTexture);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _disc.Update(gameTime);

            //Check if ball hit wall
            if (_disc.Position.X - _disc.Radius < 0)
            {
                _disc.SetXPosition(0 + _disc.Radius);
                _disc.ReverseXVelocity();
            }

            if (_disc.Position.X + _disc.Radius >= _gameWorldWidth)
            {
                _disc.SetXPosition(_gameWorldWidth - _disc.Radius);
                _disc.ReverseXVelocity();
            }

            //Check if ball hit ceiling
            if (_disc.Position.Y - _disc.Radius < 0)
            {
                _disc.SetYPosition(0 + _disc.Radius);
                _disc.ReverseYVelocity();
            }

            if (_disc.Position.Y + _disc.Radius >= _gameWorldHeight)
            {
                _disc.SetYPosition(_gameWorldHeight - _disc.Radius);
                _disc.ReverseYVelocity();
            }

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