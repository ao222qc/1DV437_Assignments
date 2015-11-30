using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeExample.View
{
    class SmokeHandler
    {
        List<Smoke> smokes = new List<Smoke>();
        Smoke smoke;
        public float MaxParticles = 50;
        public float ParticleLifeTime;
        Random rand = new Random();

        //just initiates smoke object in 0 argument constructor to gain access to properties of Smoke.
        public SmokeHandler()
        {
            smoke = new Smoke();
            ParticleLifeTime = smoke.MaxTimeToLive;
        }

        //Initiates object in constructor that creates and places smoke sprites.
        public void AddSmoke()
        {
            if (smokes.Count <= MaxParticles)
            {
                smoke = new Smoke(rand);
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
