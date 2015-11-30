using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleEffects
{
    class SplitterSystem
    {
        public SplitterParticle[] splitterParticles;
        private const int MaxParticles = 100;

        public SplitterSystem(Vector2 startPosition)
        {
            splitterParticles = new SplitterParticle[MaxParticles];

            for (int i = 0; i < MaxParticles; i++)
            {
                splitterParticles[i] = new SplitterParticle(i, startPosition); //seed i och startposition vector2
            }
        }

        public void Update(float elapsedSeconds) 
        {
            for (int i = 0; i < MaxParticles; i++)
            {
                splitterParticles[i].Update(elapsedSeconds);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera cam, Texture2D texture)
        {
            for (int i = 0; i < MaxParticles; i++)
            {
                splitterParticles[i].Draw(spriteBatch, cam, texture);
            }
        }
    }
}
