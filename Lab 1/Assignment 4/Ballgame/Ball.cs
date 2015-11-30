using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ballgame
{
    class Ball
    {
        public Vector2 position;
        public Vector2 speed = new Vector2(0.4f, 0.3f);
        float radius = 0.05f;
       // float rotation = 0f;
        

        public Ball()
        {  
            position = new Vector2(0.5f, 0.5f);
        }

        public void SetBallPosition(float time)
        {
            position += speed * time;
        }
        public void SetHorizontalSpeed()
        {
            speed.X = -speed.X;
        }
        public void SetVerticalSpeed()
        {
            speed.Y = -speed.Y;
        }

       /* public float SetRotation()
        {
            return rotation += 0.1f;
        }*/

        public float Radius
        {
            get { return radius; }
        }

    }
}
