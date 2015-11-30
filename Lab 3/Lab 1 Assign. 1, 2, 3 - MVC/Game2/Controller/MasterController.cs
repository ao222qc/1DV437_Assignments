using Game2.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2.Controller
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MasterController : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera camera;
        Texture2D chesspiece;

        public MasterController()
        {
            graphics = new GraphicsDeviceManager(this);
            camera = new Camera(graphics);
            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
            graphics.PreferredBackBufferHeight = 620;
            graphics.PreferredBackBufferWidth = 480;  
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

            // TODO: use this.Content to load your game content here
            chesspiece = Content.Load<Texture2D>("chesspiece.png");
            camera.ScaleWindow();
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

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            Texture2D rect = new Texture2D(graphics.GraphicsDevice, camera.sizeOfTile, camera.sizeOfTile);
            Texture2D rect2 = new Texture2D(graphics.GraphicsDevice, camera.sizeOfTile, camera.sizeOfTile);

            Color[] data = new Color[camera.sizeOfTile * camera.sizeOfTile];
            int j = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (j % 2 == 0)
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            data[i] = Color.White;
                        }
                        rect.SetData(data);
                        spriteBatch.Draw(rect, camera.LogicToVisualCoordinatesFlipped(x, y), 
                            null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                    else
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            data[i] = Color.Black;
                        }
                        rect2.SetData(data);
                        spriteBatch.Draw(rect2, camera.LogicToVisualCoordinatesFlipped(x, y), 
                            null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                    j++;   
                }
                j++; 
            }

            float scale = camera.ScaleImageToTileSize(chesspiece.Bounds.Height, chesspiece.Bounds.Width);
            spriteBatch.Draw(chesspiece, camera.LogicToVisualCoordinatesFlipped(2, 3), 
                null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

