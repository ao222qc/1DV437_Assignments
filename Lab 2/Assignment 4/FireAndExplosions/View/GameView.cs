using FireAndExplosions.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FireAndExplosions
{
    class GameView
    {
        Texture2D spark;
        Texture2D smoke;
        Texture2D explosion;
        Rectangle gameWindow;
        Vector2 startPosition;
        float time;
        float smokeTimer;
        SparkSystem sparkSystem;
        SmokeSystem smokeSystem;
        ExplosionSystem explosionSystem;
        bool drawSmoke;

        public GameView(Texture2D spark, Texture2D smoke, Texture2D explosion, Rectangle gameWindow, Vector2 startPosition)
        {
            this.spark = spark;
            this.smoke = smoke;
            this.explosion = explosion;
            this.gameWindow = gameWindow;
            this.startPosition = startPosition;
            sparkSystem = new SparkSystem(startPosition);
            smokeSystem = new SmokeSystem(startPosition);
            explosionSystem = new ExplosionSystem(startPosition);
        }

        public void Initiate()
        {
            sparkSystem = new SparkSystem(startPosition);
            smokeSystem = new SmokeSystem(startPosition);
            explosionSystem = new ExplosionSystem(startPosition);
        }

        public void UpdateSmoke(float totalSeconds)
        {
           
                smokeSystem.AddSmoke();
        }

        public void UpdateExplosion(float totalSeconds)
        {
            explosionSystem.Update(totalSeconds);
        }

        public void Draw(SpriteBatch spriteBatch, float totalSeconds, Camera camera)
        {
            time += totalSeconds;

            explosionSystem.Draw(spriteBatch, explosion, camera);

            spriteBatch.Begin();

            sparkSystem.Draw(spriteBatch, camera, spark);
            sparkSystem.Update(totalSeconds);

            if (sparkSystem.CheckIfDone())
            {
                smokeSystem.DrawAndUpdate(spriteBatch, camera, smoke, totalSeconds);
            }

            spriteBatch.End();
        }
    }
}
