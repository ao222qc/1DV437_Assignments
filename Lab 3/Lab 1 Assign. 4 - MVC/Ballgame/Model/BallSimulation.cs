using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ballgame.Model
{
    class BallSimulation
    {
        Ball m_ball;

        public BallSimulation()
        {
            m_ball = new Ball();
        }
        public void Move(float time)
        {
            m_ball.SetBallPosition(time);
            Collision();  
        }

        public void Collision()
        {
            if (m_ball.position.X >= 1 - m_ball.Radius || m_ball.position.X <=0 + m_ball.Radius)
            {
                m_ball.SetHorizontalSpeed();
            }
            if (m_ball.position.Y >= 1 - m_ball.Radius || m_ball.position.Y <= 0 + m_ball.Radius)
            {
                m_ball.SetVerticalSpeed();
            }
        }


        public Ball GetBall()
        {
            return m_ball;
        }

       

    }
}
