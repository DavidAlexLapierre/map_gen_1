using Microsoft.Xna.Framework;
using ProjectEthereal.Engine.Components;
using System.Collections.Generic;

namespace ProjectEthereal.GameContent.Scenes {
    class GameScenes {
        public Scene StartingScene { get; private set; }
        public List<Scene> Scenes { get; private set; }

        public GameScenes(Game game) {
            Scenes = new List<Scene>();
            InitScenes(game);
        }

        /// <summary>
        /// Add new game scene here
        /// </summary>
        private void InitScenes(Game game) {
            StartingScene = new MainMenuScene(game);
            Scenes.Add(StartingScene);
            Scenes.Add(new WorldScene(game));
            StartingScene.Init();
        }
    }
}
