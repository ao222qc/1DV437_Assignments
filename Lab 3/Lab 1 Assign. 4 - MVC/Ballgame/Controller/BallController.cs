using Ballgame.Model;
using Ballgame.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ballgame.Controller
{
    class BallController
    {
        Texture2D box;
        Camera camera;
        Texture2D globe;
        BallSimulation m_ballSimulation;


        public BallController(GraphicsDeviceManager graphics, ContentManager content, BallSimulation ballSimulation)
        {
            box = new Texture2D(graphics.GraphicsDevice, 1, 1);
            box.SetData<Color>(new Color[]
                {
                    Color.White
                });
            camera = new Camera(graphics.GraphicsDevice.Viewport);
            globe = content.Load<Texture2D>("globe.png");
            m_ballSimulation = ballSimulation;
        }

        public void Update(float totalSeconds)
        {
            m_ballSimulation.Move(totalSeconds);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(box, camera.GetGameWindow(), Color.BlanchedAlmond);
            spriteBatch.Draw(globe, camera.scaleBallPosition(m_ballSimulation.GetBall().position.X - m_ballSimulation.GetBall().Radius,
                m_ballSimulation.GetBall().position.Y - m_ballSimulation.GetBall().Radius),
                null, Color.White, 0f, Vector2.Zero, m_ballSimulation.GetBall().Radius, SpriteEffects.None, 0f);
            spriteBatch.End();
        }
    }
}
