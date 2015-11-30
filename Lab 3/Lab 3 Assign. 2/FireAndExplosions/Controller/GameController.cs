using FireAndExplosions.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FireAndExplosions.Controller
{
    class GameController
    {
        SoundEffect explosionSound;
        Texture2D spark;
        Texture2D smoke;
        Texture2D explosion;
        Rectangle gameWindow;
        Vector2 startPosition;
        float time;
        SparkSystem sparkSystem;
        SmokeSystem smokeSystem;
        ExplosionSystem explosionSystem;
        SpriteBatch spriteBatch;
        Camera camera;
        Vector2 lastMouseClickPosition;
        List<ExplosionSystem> explosions = new List<ExplosionSystem>();
        List<SparkSystem> sparks = new List<SparkSystem>();
        List<SmokeSystem> smokes = new List<SmokeSystem>();


        public GameController(Texture2D spark, Texture2D smoke, Texture2D explosion, Rectangle gameWindow,
            Vector2 startPosition, SpriteBatch spriteBatch, Camera camera, SoundEffect explosionSound)
        {
            this.spark = spark;
            this.smoke = smoke;
            this.explosion = explosion;
            this.gameWindow = gameWindow;
            this.startPosition = startPosition;
            this.spriteBatch = spriteBatch;
            this.camera = camera;
            this.explosionSound = explosionSound;
            sparkSystem = new SparkSystem(startPosition);
            smokeSystem = new SmokeSystem(startPosition);
            explosionSystem = new ExplosionSystem(startPosition, explosionSound);
        }

        public void OnMouseClick(float totalSeconds, Vector2 mouseClickPosition)
        {
            lastMouseClickPosition = camera.GetMouseInputToLogical(mouseClickPosition.X, mouseClickPosition.Y);
            startPosition = lastMouseClickPosition;
            explosions.Add(new ExplosionSystem(startPosition, explosionSound));
            sparks.Add(new SparkSystem(startPosition));
            smokes.Add(new SmokeSystem(startPosition));
            explosionSystem.PlayExplosionSound();
        }

        public void UpdateSmoke()
        {
            foreach (SmokeSystem smokeSystem in smokes)
            {
                smokeSystem.AddSmoke();
            }
        }

        public void UpdateExplosion(float totalSeconds)
        {
            foreach (ExplosionSystem es in explosions)
            {
                es.Update(totalSeconds);
            }
        }

        public void Draw(SpriteBatch spriteBatch, float totalSeconds, Camera camera)
        {
            time += totalSeconds;



            spriteBatch.Begin();
            foreach (ExplosionSystem es in explosions)
            {
                es.Draw(spriteBatch, explosion, camera);
            }
            foreach (SparkSystem ss in sparks)
            {
                ss.Update(totalSeconds);
                ss.Draw(spriteBatch, camera, spark);
            }

            foreach (SmokeSystem smokeSystem in smokes)
            {
                smokeSystem.DrawAndUpdate(spriteBatch, camera, smoke, totalSeconds);
            }

            spriteBatch.End();
        }
    }
}
