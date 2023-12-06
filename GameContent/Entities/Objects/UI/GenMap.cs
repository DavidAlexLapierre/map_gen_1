using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectEthereal.Engine.Components;
using ProjectEthereal.Engine.Events;
using ProjectEthereal.Engine.Utils;
using ProjectEthereal.GameContent.Components;
using ProjectEthereal.GameContent.Utils;
using ProjectEthereal.GameContent.Simulation;

namespace ProjectEthereal.GameContent.Entities {
    class GenMap : Entity {
        const float SCALE = 0.25f;
        WorldCell[,] Map { get; set; }
        SpriteBatch _spriteBatch { get; set; }
        int MapWidth { get; set; }
        int MapHeight { get; set; }
        public ScreenPositionComponent Position { get; private set; }

        public GenMap(Game game, SceneEvents events) : base(game, events) {
            _spriteBatch = (SpriteBatch)game.Services.GetService<SpriteBatch>();
            InitMap();
            Position = new ScreenPositionComponent(game);
            AddComponent(Position);
        }

        public void InitMap() {
            Map = WorldConfig.GetWorldData();
            MapWidth = WorldConfig.Width;
            MapHeight = WorldConfig.Height;
        }

        public override void Draw(GameTime gameTime) {
            for (int i = 0; i < MapWidth; i++) {
                for (int j = 0; j < MapHeight; j++) {
                    var xx = Position.Position.X + i * SCALE * Params.CELL_DIM;
                    var yy = Position.Position.Y + j * SCALE * Params.CELL_DIM;
                    var pos = new Vector2(xx, yy);
                    WorldCell cell = Map[i,j];
                    var texture = TextureLoader.GetTexture(cell.Texture);
                    _spriteBatch.Draw(texture, pos, cell.Sprite, cell.Color , 0, Vector2.Zero, SCALE, SpriteEffects.None, 1f);
                }
            }
        }
    }
}