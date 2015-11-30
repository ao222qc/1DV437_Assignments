
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game2.View
{
    class Camera
    {
        public int sizeOfTile = 64;
        int borderSize = 64;
        GraphicsDeviceManager Graphics;
        public float Scale;
        // 320 * 240.

        public Camera(GraphicsDeviceManager graphics)
        {
            Graphics = graphics;
        }

        public float ScaleImageToTileSize(float height, float width)
        {
            float scale = (sizeOfTile / (float)height) + (sizeOfTile / (float)width);

            scale = scale / 2;

            return scale;
        }
        public Vector2 LogicToVisualCoordinates(int x, int y)
        {
           float visualX = borderSize + x * sizeOfTile;
            float visualY = borderSize + y * sizeOfTile;

            return new Vector2(visualX, visualY);
        }

        public void ScaleWindow()
        {
            float scaleX = (float)Graphics.GraphicsDevice.Viewport.Width / (sizeOfTile * 8 + borderSize * 2);
            float scaleY = (float)Graphics.GraphicsDevice.Viewport.Height / (sizeOfTile * 8 + borderSize * 2);
            if (scaleX < scaleY)
            {
                Scale = scaleX;
            }
            else
            {
                Scale = scaleY;
            }
            sizeOfTile = Convert.ToInt32(Math.Round(sizeOfTile * Scale));
            borderSize = Convert.ToInt32(Math.Round(borderSize * Scale));
        }
        public Vector2 LogicToVisualCoordinatesFlipped(int x, int y)
        {
            float visualX = (sizeOfTile * 8 + borderSize - sizeOfTile) - (x * sizeOfTile);
            float visualY = (sizeOfTile * 8 + borderSize - sizeOfTile) - (y * sizeOfTile);

            return new Vector2(visualX, visualY); 
        }

    }
}
