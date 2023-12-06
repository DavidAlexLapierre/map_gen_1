using Microsoft.Xna.Framework;
using ProjectEthereal.Engine.Components;
using ProjectEthereal.Engine.Utils;
using ProjectEthereal.GameContent.Entities;
using ProjectEthereal.GameContent.Utils;

namespace ProjectEthereal.GameContent.Scenes {
    class MainMenuScene : Scene {
        public MainMenuScene(Game game) : base() {
            BackgroundColor = ColorPalette.GetColor("background");
            Initialize(game);
        }

        public override void Init() {
            AddEntity(new MainMenuController(_game, _events));
        }
    }
}
