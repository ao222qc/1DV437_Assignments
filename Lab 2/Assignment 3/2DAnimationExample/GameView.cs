using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DAnimationExample
{
    class GameView
    {
        ExplosionHandler explosionHandler;
        Texture2D explosion;
 
        public GameView(Texture2D texture, Vector2 position)
        {
            explosion = texture;
            explosionHandler = new ExplosionHandler(position);       
        }

        public void Update(float totalSeconds)
        {

            explosionHandler.Update(totalSeconds);
        }

        public void Draw(SpriteBatch spriteBatch, float totalSeconds)
        {
            explosionHandler.Draw(spriteBatch, explosion);
        }
    }
}
