using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;

namespace Bouncy.Input
{
    abstract class GameInput
    {
        protected float _xScale;
        protected float _yScale;

        //Movement Direction
        public int XDirection { get; protected set; }
        public int YDirection { get; protected set; }

        //Fire Weapon
        public bool Click { get; protected set; }

        //Clear
        public bool Clear { get; protected set; }

        //Exit Game
        public bool Exit { get; protected set; }

        //Pause 
        public bool Pause { get; protected set; }

        public GameInput(float xScale, float yScale)
        {
            _xScale = xScale;
            _yScale = yScale;
        }

        public abstract void Update(GameTime gametime); 
    }
}