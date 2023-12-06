using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEthereal.Engine.Interfaces {
    interface IImplementsUpdate {
        /// <summary>
        /// Update the class every frame
        /// </summary>
        /// <param name="gameTime">dt</param>
        void Update(GameTime gameTime);
    }
}
