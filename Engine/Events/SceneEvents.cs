using System;
using System.Collections.Generic;
using System.Text;
using ProjectEthereal.Engine.Components;

namespace ProjectEthereal.Engine.Events {
    class SceneEvents {
        public Scene Scene { get; private set; }
        public EventHandler AddEntity { get; set; }
        public EventHandler RemoveEntity { get; set; }
        public EventHandler GetEntity { get; set; }

        public SceneEvents(Scene scene) {
            Scene = scene;
        }
    }
}
