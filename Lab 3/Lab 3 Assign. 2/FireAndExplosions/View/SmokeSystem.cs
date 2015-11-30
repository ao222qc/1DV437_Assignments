using FireAndExplosions.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FireAndExplosions.View
{
    class SmokeSystem
    {
        List<Smoke> smokes = new List<Smoke>();
        Smoke smoke;
        public float MaxParticles = 75;
        public float ParticleLifeTime = 3f;
        Random rand = new Random();
        Vector2 startPosition;


        //Initiates object in constructor that creates and places smoke sprites.
        public SmokeSystem(Vector2 startPosition)
        {
            this.startPosition = startPosition;
            smoke = new Smoke();
            ParticleLifeTime = smoke.MaxTimeToLive;
        }
        //just initiates smoke object in 0 argument constructor to gain access to properties of Smoke.
        public SmokeSystem()
        { 
        }

        public void AddSmoke()
        {
            if (smokes.Count < MaxParticles)
            {
                smoke = new Smoke(rand, startPosition);
                smokes.Add(smoke);
            }
        }

        public void DrawAndUpdate(SpriteBatch spriteBatch, Camera cam, Texture2D smokeSprite, float totalSeconds)
        {
            foreach (Smoke smoke in smokes)
            {
                smoke.Update(totalSeconds);

                if (smoke.IsParticleAlive())
                {
                    smoke.Draw(spriteBatch, cam, smokeSprite);
                }  
            }        
        }
    }
}
