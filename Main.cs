using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectEthereal.Engine.Managers;
using ProjectEthereal.Engine.Components;
using ProjectEthereal.Engine.Utils;
using ProjectEthereal.GameContent.Scenes;

namespace ProjectEthereal
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SceneManager _sceneManager;
        private GameScenes _gameScenes;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.GraphicsProfile = GraphicsProfile.HiDef;
            _sceneManager = new SceneManager(this);
            Components.Add(_sceneManager);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            RegisterServices();
            InputHelper.SetVisualManager(this);
            _gameScenes = new GameScenes(this);
            _sceneManager.Init(this, _gameScenes.Scenes, _gameScenes.StartingScene);
            base.Initialize();
        }

        private void RegisterServices()
        {
            Services.AddService(typeof(GraphicsDeviceManager), _graphics);
            Services.AddService(typeof(SpriteBatch), _spriteBatch);
            Services.AddService(typeof(Camera), new Camera(this));
            Services.AddService(typeof(SceneManager), _sceneManager);
        }
    }
}
