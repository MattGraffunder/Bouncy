using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouncy.Input
{
    class MouseInput : GameInput
    {
        MouseState currentMouseState;
        MouseState priorState;

        public MouseInput(float xScale, float yScale) : base(xScale, yScale) { }

        public override void Update(GameTime gametime)
        {
            //Reset
            Click = false;
            Clear = false;

            priorState = currentMouseState;
            currentMouseState = Mouse.GetState();

            if (priorState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
            {
                Click = true;
            }

            if (priorState.RightButton == ButtonState.Released && currentMouseState.RightButton == ButtonState.Pressed)
            {
                Clear = true;
            }

            XDirection = (int)(currentMouseState.X / _xScale);
            YDirection = (int)(currentMouseState.Y / _yScale);
        }
    }
}