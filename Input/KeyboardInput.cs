using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Bouncy.Input
{
    class KeyboardInput : GameInput
    {
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        public KeyboardInput(float xScale, float yScale) : base(xScale, yScale) { }

        public override void Update(GameTime gametime)
        {
            //ResetDirections();

            XDirection = 0;
            YDirection = 0;

            Click = false;

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            if(previousKeyboardState.IsKeyUp(Keys.Up) && currentKeyboardState.IsKeyDown(Keys.Up))
            {
                Click = true;
            }

            // Keyboard and GamePad Dpad Controls
            if (currentKeyboardState.IsKeyDown(Keys.Left))
            {
                XDirection += -1;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Right))
            {
                XDirection += 1;
            }

            //if (currentKeyboardState.IsKeyDown(Keys.Up))
            //{
            //    YDirection += -1;
            //}

            //if (currentKeyboardState.IsKeyDown(Keys.Down))
            //{
            //    YDirection += 1;
            //}

            //Fire = currentKeyboardState.IsKeyDown(Keys.Space);
            Exit = currentKeyboardState.IsKeyDown(Keys.Escape);

            //Pause is when Left Control is Pressed currently, and was not pressed before
            Pause = currentKeyboardState.IsKeyDown(Keys.LeftControl) 
                && previousKeyboardState.IsKeyUp(Keys.LeftControl);
        }
    }
}