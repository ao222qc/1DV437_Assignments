using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DAnimationExample.View
{
    class ExplosionHandler
    {
        const int frames = 40;
        float frameTime = 0.1f;
        int frameHeight = 128;
        int frameWidth = 128;
        int frameX = 4;    
        int x;
        int y;
        Vector2 position;
        Vector2 origin;
        Rectangle rect;
        int frameIndex;
        float time;
        int frame;

        public ExplosionHandler(Vector2 position)
        {
            origin = new Vector2(frameWidth / 2.0f, frameHeight);
            this.position = position;        
        }
        public void Update(float totalSeconds)
        {
            time += totalSeconds;

            float percentAnimated = time / frameTime;
            frame = (int)(percentAnimated * frames);

            while (time > frameTime)
            {
                frameIndex++;
                time = 0f;
            }

            if (frameIndex >= frames)
            {
                ResetExplosion();
            }
        }

        public void ResetExplosion()
        {
            frameIndex = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        { 
            x = frameIndex % frameX;
            y = frameIndex / frameX;
           
            rect = new Rectangle(x*frameWidth, y*frameWidth, frameHeight, frameWidth);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, rect, Color.White, 0.0f, origin, 1.0f, SpriteEffects.None, 0.0f);
            spriteBatch.End();
        }
    }
}
