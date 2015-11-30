using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleEffects.View
{
    class GameView
    {
        Texture2D level;
        Texture2D sprite;
        Camera camera;
        SplitterSystem splitterSystem;
        float gameSeconds;

        public GameView(GraphicsDeviceManager graphics, ContentManager content)
        {
            gameSeconds = 0;
            level = new Texture2D(graphics.GraphicsDevice, 1, 1);
            level.SetData<Color>(new Color[]
                {
                    Color.White
                });
            camera = new Camera(graphics.GraphicsDevice.Viewport);

            sprite = content.Load<Texture2D>("spark"); 

            InitiateParticleSystem();


        }

        public void InitiateParticleSystem()
        {
            Vector2 startPosition = new Vector2(0.5f, 0.5f);

            splitterSystem = new SplitterSystem(startPosition);
        }

        public void Draw(SpriteBatch spriteBatch, float seconds)
        {
            gameSeconds += seconds;

            if (gameSeconds > 3f)
            {
                InitiateParticleSystem();
                gameSeconds = 0;
            }
            splitterSystem.Update(seconds);
            spriteBatch.Begin();
            spriteBatch.Draw(level, camera.GetGameWindow(), Color.Black);
            splitterSystem.Draw(spriteBatch, camera, sprite);
            spriteBatch.End();
        }
    }
}
