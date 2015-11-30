using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleEffects.View
{
    class Camera
    {
        int borderSize = 10;
        public int scaleHeight;
        public int scaleWidth;
        int height;
        int width;

        public Camera(Viewport graphics)
        {
            height = graphics.Height;
            width = graphics.Width;

            if (height < width)
            {
                width = height;
            }
            else if (width < height)
            {
                height = width;
            }

            float scaleH = height - borderSize * 2;
            float scaleW = width - borderSize * 2;

            scaleHeight = (int)scaleH;
            scaleWidth = (int)scaleW;
        }

        public Rectangle GetGameWindow()
        {
            return new Rectangle(borderSize, borderSize, scaleWidth, scaleHeight);
        }

        public Vector2 scaleParticle(float x, float y)
        {
            float visualX = x * scaleHeight + borderSize;
            float visualY = y * scaleWidth + borderSize;

            return new Vector2(visualX, visualY);
        }

    }
}
