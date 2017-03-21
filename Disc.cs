using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouncy
{
    public class Disc
    {
        public int Radius { get; private set; }

        /// <summary>
        /// Center Position
        /// </summary>
        public Vector2 Position { get; private set; }

        public Vector2 Velocity { get; private set; }

        public Disc(int radius, Vector2 startingPosition, Vector2 startingVelocity )
        {
            Position = startingPosition;
            Radius = radius;
            Velocity = startingVelocity;
        }

        public void Update(GameTime gameTime)
        {
            Position += Velocity;
        }

        public void SetXPosition(int xPos)
        {
            Position = new Vector2(xPos, Position.Y);
        }

        public void SetYPosition(int yPos)
        {
            Position = new Vector2(Position.X, yPos);
        }

        public void ReverseXVelocity()
        {
            Velocity *= new Vector2(-1, 1);
        }

        public void ReverseYVelocity()
        {
            Velocity *= new Vector2(1, -1);
        }
    }
}