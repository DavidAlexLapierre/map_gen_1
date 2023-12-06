using System;
using Microsoft.Xna.Framework;
using ProjectEthereal.Engine.Components;

namespace ProjectEthereal.GameContent.Components {

    class ActionComponent : Component {
        public EventHandler Handler { get; set; }
        public ActionComponent() : base() {
            Type = "ActionComponent";
        }

        public void Execute() {
            // TODO: Add args?
            Handler?.Invoke(this, EventArgs.Empty);
        }
    }
}