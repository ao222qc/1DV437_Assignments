using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeExample.View
{
    class Smoke
    {
        Vector2 acceleration = new Vector2(0f, -0.3f);
        Vector2 systemStartPosition = new Vector2(0.8f, 0.89f);
        private float minSize = 0f;
        private float maxSize = 10f;
        float maxTimeTolive = 2.5f;
        float fade = 1f;
        float rotation = 0f;

        Vector2 randomDirection;
        Vector2 position;
        Vector2 velocity;
        private float size;
        Random rand;
        float timeLived;
        float lifePercent;

        public Smoke(Random random)
        {
            rand = random;
            ReuseParticle();
        }
        public Smoke()
        {
 
        }

        public float MaxTimeToLive
        {
            get { return maxTimeTolive; }
        }
        public void ReuseParticle()
        {
            timeLived = 0f;
            fade = 1f;
            size = minSize;
            randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, -0.1f);//(float)rand.NextDouble() - 0.5f);
            randomDirection.Normalize();
            randomDirection = randomDirection * ((float)rand.NextDouble() * 0.15f);
            position = new Vector2(systemStartPosition.X, systemStartPosition.Y);
            velocity = randomDirection;
        }

        public void Update(float timeElapsed)
        {     
            rotation += timeElapsed / maxTimeTolive;
            fade -= timeElapsed / maxTimeTolive;

            timeLived += timeElapsed;
            lifePercent = timeLived / maxTimeTolive;
            size = minSize + lifePercent * maxSize;

            position = position + velocity * timeElapsed;
            velocity = velocity + acceleration * timeElapsed;

            if (timeLived >= maxTimeTolive)
            {
                ReuseParticle();
            }
        }

        public bool IsParticleAlive()
        {
            return timeLived < maxTimeTolive;
        }

        public void Draw(SpriteBatch spriteBatch, Camera cam, Texture2D smokeSprite)
        {
            Color color = new Color(fade, fade, fade, fade);
            Vector2 vec = cam.scaleSmoke(position.X, position.Y);
            spriteBatch.Draw(smokeSprite, vec,
            null, color, rotation, Vector2.Zero, this.size, SpriteEffects.None, 0f);
        }
    }
}
