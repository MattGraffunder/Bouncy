using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouncy.Input
{
    static class InputFactory
    {
        public static GameInput GetInput(float xScale, float yScale)
        {
            return new MouseInput(xScale, yScale);
            //return new KeyboardInput();
            //return new GamePadInput();
        }
    }
}