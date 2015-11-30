using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SmokeExample.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmokeExample.View;

namespace SmokeExample.Controller
{
    class GameController
    {
        SmokeHandler smokeHandler;
        public static Vector2 screenSize;
        
        public GameController(SmokeHandler smokeHandler, GraphicsDeviceManager graphics)
        {
            screenSize = new Vector2(graphics.GraphicsDevice.Viewport.X, graphics.GraphicsDevice.Viewport.Y);
            smokeHandler = new SmokeHandler();
            this.smokeHandler = smokeHandler;
        }

        public void Update()
        {
            this.smokeHandler.AddSmoke();
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D gameArea, Texture2D smokeSprite, float totalSeconds)
        {
            //smokeHandler.Update(totalSeconds);
            spriteBatch.Begin();
            spriteBatch.Draw(gameArea, camera.GetGameWindow(), Color.Transparent);
            smokeHandler.DrawAndUpdate(spriteBatch, camera, smokeSprite, totalSeconds);
            spriteBatch.End();
        }
    }
}
