using FireAndExplosions.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FireAndExplosions
{
    class SparkSystem
    {
            public Spark[] sparkParticles;
            private const int MaxParticles = 100;
            bool explosionDone;
            int count;
            Rectangle gameWindow;

            public SparkSystem(Vector2 startPosition)
            {
                sparkParticles = new Spark[MaxParticles];
                //this.gameWindow = gameWindow;

                for (int i = 0; i < MaxParticles; i++)
                {
                    sparkParticles[i] = new Spark(i, startPosition); //seed i och startposition vector2
                }
            }

            public bool CheckIfDone()
            {
                for (int i = 0; i < MaxParticles; i++)
                {
                    if(sparkParticles[i].CheckIfParticlesGone())
                    {
                        return true;
                    }
                }
                return false;
            }

            public void Update(float elapsedSeconds) //float elapsedtime
            {
                for (int i = 0; i < MaxParticles; i++)
                {
                    sparkParticles[i].Update(elapsedSeconds);//float elapsedtime
                }
            }

            public void Draw(SpriteBatch spriteBatch, Camera cam, Texture2D texture)
            {
                for (int i = 0; i < MaxParticles; i++)
                {
                    sparkParticles[i].Draw(spriteBatch, cam, texture, gameWindow);
                }
            }
        }
    }

