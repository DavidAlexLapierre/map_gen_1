using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ProjectEthereal.GameContent.Utils;

namespace ProjectEthereal.GameContent.Simulation {
    class WorldCell {
        public string Texture { get; set; }
        public List<Rectangle> Sprites { get; private set; }
        public Rectangle Sprite { get; private set; }
        public Color Color { get; private set; }
        public bool OnLand { get; private set; }
        public WorldCell() {
            OnLand = true;
            Sprites = new List<Rectangle>();
            Color = ColorPalette.GetColor("default");
        }

        public void SetOnLandState(bool onLand) { OnLand = onLand; }

        public void SetTexture(string texture) { Texture = texture; }

        public void SetSpriteTable(List<Rectangle> sprites) { Sprites = sprites; }
        public void SetSprite(Rectangle sprite) { Sprite = sprite; }
        private Rectangle GetRandomSprite() {
            var index = Generator.Next(Sprites.Count);
            return Sprites[index];
        }

        public void SetColor(string color) { Color = ColorPalette.GetColor(color); }

        public WorldCell Get() {
            var cell = (WorldCell)this.MemberwiseClone();
            var texture = GetRandomSprite();
            cell.SetSprite(texture);

            return cell;
        }
    }
}