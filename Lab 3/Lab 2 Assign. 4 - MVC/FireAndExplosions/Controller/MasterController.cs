using FireAndExplosions.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        SmokeSystem ss;
        float time;
        float drawTime;
        public const int maxTime = 6;

        public MasterController()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 1080/2;
            graphics.PreferredBackBufferWidth = 1920/2;
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
            //Vector2 startPosition = new Vector2(graphics.GraphicsDevice.Viewport.Bounds.Width / 2.0f, graphics.GraphicsDevice.Viewport.Bounds.Height / 2.0f);
            camera = new Camera(graphics.GraphicsDevice.Viewport);
            Vector2 startPosition = new Vector2(0.5f, 0.5f);
            gameWindow = camera.GetGameWindow();
            gameView = new GameController(spark, smoke, explosion, gameWindow, startPosition);
             ss = new SmokeSystem();
             gameView.Initiate();
            

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


            drawTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (drawTime <= maxTime)
            {
                gameView.UpdateExplosion((float)gameTime.ElapsedGameTime.TotalSeconds);
                time += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (time >= (float)ss.ParticleLifeTime / (float)ss.MaxParticles)
                {
                    //gameView.UpdateSmoke((float)gameTime.ElapsedGameTime.TotalSeconds);
                    gameView.UpdateSmoke(drawTime);
                    time = 0;
                }
            }
            else 
            {
                drawTime = 0;
                gameView.Initiate();
            }

            
            // TODO: Add your update logic here

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
