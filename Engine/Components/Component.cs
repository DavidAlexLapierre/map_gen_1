using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ProjectEthereal.Engine.Components {
    abstract class Component {
        public string Type { get; set; }
        public Entity Parent { get; set; }
        public Component() {}
        public virtual void Update(GameTime gameTime) {}
        public virtual void Draw(GameTime gameTime) {}
    }
}
