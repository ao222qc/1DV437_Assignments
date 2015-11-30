using FireAndExplosions.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FireAndExplosions.Controller
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MasterController : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D spark;
        Texture2D smoke;
        Texture2D explosion;
        GameController gameView;
        Rectangle gameWindow;
        Camera camera;
        SoundEffect fireSound;
        SmokeSystem smokeSystem;
        private MouseState oldMouseState;
        public const int maxTime = 6;
        private float time;

        public MasterController()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 1080 / 2;
            graphics.PreferredBackBufferWidth = 1920 / 2;
            IsMouseVisible = true;
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
            spark = Content.Load<Texture2D>("spark");
            smoke = Content.Load<Texture2D>("particlesmoke");
            explosion = Content.Load<Texture2D>("explosion");
            fireSound = Content.Load<SoundEffect>("firesound.wav");
            camera = new Camera(graphics.GraphicsDevice.Viewport);
            Vector2 startPosition = new Vector2(0.5f, 0.5f);
            gameWindow = camera.GetGameWindow();
            gameView = new GameController(spark, smoke, explosion, gameWindow, startPosition, spriteBatch, camera, fireSound);
            smokeSystem = new SmokeSystem();

            // TODO: use this.Content to load your game content here
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

            MouseState newState = Mouse.GetState();

            if (newState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                gameView.OnMouseClick((float)gameTime.ElapsedGameTime.TotalSeconds, new Vector2(newState.X, newState.Y));

            }

            oldMouseState = newState;
          
            gameView.UpdateExplosion((float)gameTime.ElapsedGameTime.TotalSeconds);

            time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (time >= (float)smokeSystem.ParticleLifeTime / (float)smokeSystem.MaxParticles)
            {
                gameView.UpdateSmoke();
                time = 0;
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

            gameView.Draw(spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds, camera);


            base.Draw(gameTime);
        }
    }
}
