using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEthereal.Engine.Interfaces {
    interface IImplementsDraw {
        /// <summary>
        /// Draw the class every game frame
        /// </summary>
        /// <param name="gameTime">dt</param>
        void Draw(GameTime gameTime);
    }
}
