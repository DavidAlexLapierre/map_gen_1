using Microsoft.Xna.Framework;
using ProjectEthereal.Engine.Components;

namespace ProjectEthereal.GameContent.Components {

    class ScreenPositionComponent : Component {
        public Vector2 Position { get; private set; }
        Camera _camera { get; set; }
        public ScreenPositionComponent(Game game) : base() {
            Type = "ScreenPositionComponent";
            _camera = (Camera)game.Services.GetService<Camera>();
        }

        public void SetPosition(Vector2 pos) { Position = pos; }
        
        public void CenterHorizontal(float width) {
            var camW = _camera.Width / _camera.ScaleX;
            var xx = (camW / 2.0f) - (width / 2.0f);
            Position = new Vector2(xx, Position.Y);
        }

        public void CenterVertical(float height) {
            var camH = _camera.Height / _camera.ScaleY;
            var yy = (camH / 2.0f) - (height / 2.0f);
            Position = new Vector2(Position.X, yy);
        }

        public void Center(int width, int height) { CenterHorizontal(width); CenterVertical(height); }
    }
}