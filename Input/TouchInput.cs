using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouncy.Input
{
    class TouchInput : GameInput
    {
        public TouchInput(float xScale, float yScale) : base(xScale, yScale) { }

        public override void Update(GameTime gametime)
        {
            //while (TouchPanel.IsGestureAvailable)
            //{
            //    GestureSample gesture = TouchPanel.ReadGesture();

            //    if (gesture.GestureType == GestureType.FreeDrag)
            //    {
            //        player.Position += gesture.Delta;
            //    }
            //}
        }
    }
}