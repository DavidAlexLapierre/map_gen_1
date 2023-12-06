using Microsoft.Xna.Framework;
using ProjectEthereal.Engine.Components;
using ProjectEthereal.Engine.Utils;
using ProjectEthereal.GameContent.Entities;
using ProjectEthereal.GameContent.Utils;

namespace ProjectEthereal.GameContent.Scenes {
    class WorldScene : Scene {
        public WorldScene(Game game) : base() {
            BackgroundColor = ColorPalette.GetColor("background");
            Initialize(game);
        }

        public override void Init() {
            //var terrain = new Terrain(_game, _events);
            //AddEntity(terrain);
        }
    }
}
