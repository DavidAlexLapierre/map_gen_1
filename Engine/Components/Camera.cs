using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectEthereal.Engine.Components {
    class Camera {
        public const int VIEW_WIDTH = 512;
        public const int VIEW_HEIGHT = 288;
        public const int RENDER_WIDTH = 1280;
        public const int RENDER_HEIGHT = 720;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public float ScaleX { get; private set; }
        public float ScaleY { get; private set; }

        GraphicsDeviceManager _graphics { get; set; }
        GraphicsDevice _graphicsDevice { get; set; }
        public Matrix Scale {get; private set;}


        public Camera(Game game) {
            Width = RENDER_WIDTH;
            Height = RENDER_HEIGHT;
            _graphics = (GraphicsDeviceManager)game.Services.GetService(typeof(GraphicsDeviceManager));
            _graphicsDevice = game.GraphicsDevice;
            game.IsMouseVisible = true;
            _graphics.HardwareModeSwitch = false;
            game.Window.AllowUserResizing = true;
            game.Window.ClientSizeChanged += OnResize;
            if (_graphics.IsFullScreen) { SetFullscreenResolution(); }
            SetResolution(Width, Height);
        }

        void SetFullscreenResolution() {
            Width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        void OnResize(object sender, EventArgs args) {
            GetCurrentDimensions();
            SetResolution(Width, Height);
        }

        public Vector2 ScalePosition(Vector2 position) {
            return new Vector2(position.X / ScaleX, position.Y / ScaleY);
        }

        void GetCurrentDimensions() {
            Width = _graphics.PreferredBackBufferWidth;
            Height = _graphics.PreferredBackBufferHeight;
        }

        public void SetResolution(int width, int height)
        {
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
            _graphics.ApplyChanges();
            SetScaling();
        }

        /// This method will set the scaling of the UI based on the resolution
        void SetScaling() {
            ScaleX = Width / (float) VIEW_WIDTH;
            ScaleY = Height / (float) VIEW_HEIGHT;
            var scaleVector = new Vector3(ScaleX, ScaleY, 1);
            Scale = Matrix.CreateScale(scaleVector);
        }
    }
}
