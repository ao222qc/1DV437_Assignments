using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleEffects.View
{
    class SplitterParticle
    {
        Vector2 randomDirection; 
        private float radius = 0.08f;
        private int seed;
        Vector2 startPosition;
        Vector2 position;
        Vector2 velocity;
        Vector2 acceleration;
        Random rand;

        public SplitterParticle(int seed, Vector2 systemStartPosition)
        {
            rand = new Random(seed);
            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            randomDirection.Normalize();
            randomDirection = randomDirection * ((float)rand.NextDouble() * 0.5f);
            this.seed = seed;
            startPosition = systemStartPosition;
            position = new Vector2(startPosition.X, StartPosition.Y);
            velocity = randomDirection;
            acceleration = new Vector2(0f, 1f);
        }

        public Vector2 StartPosition
        {
            get { return startPosition; }
        }
        public Vector2 Velocity
        {
            get { return velocity; }
        }

        public void Update(float elapsedSeconds)
        {
            position = position + velocity * elapsedSeconds;
            velocity = velocity + acceleration * elapsedSeconds;
            if (position.X >= 1|| position.X <= 0)
            {
                velocity.X = -velocity.X;
            }
            if (position.Y <= 0)
            {
                velocity.Y = -velocity.Y;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera cam, Texture2D texture)
        {
            Vector2 vec = cam.scaleParticle(position.X, position.Y);
            spriteBatch.Draw(texture, vec,
            null, Color.White, 0f, Vector2.Zero, this.radius, SpriteEffects.None, 0f);
        }
    }
}
