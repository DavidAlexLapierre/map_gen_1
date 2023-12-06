using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectEthereal.Engine.Components;
using ProjectEthereal.GameContent.Utils;

namespace ProjectEthereal.GameContent.Components {
    class TextComponent : Component {
        bool IsVisible { get; set; }
        public const float DEFAULT_SIZE = 12f;
        string Text { get; set; }
        float Size { get; set; }
        SpriteFont Font { get; set; }
        Color TextColor { get; set; }
        public Vector2 Dim { get; private set; }
        public float wDim { get; private set; }
        public float hDim { get; private set; }
        SpriteBatch _spriteBatch { get; set; }
        
        public TextComponent(Game game) : base() {
            Type = "TextComponent";
            Size = DEFAULT_SIZE/DEFAULT_SIZE;
            Font = game.Content.Load<SpriteFont>("Fonts/MainFont");
            _spriteBatch = (SpriteBatch)game.Services.GetService<SpriteBatch>();
            TextColor = ColorPalette.GetColor("text");
            IsVisible = true;
            Text = "";
            UpdateDim();
        }

        public void Show() {
            IsVisible = true;
        }

        public void Hide() {
            IsVisible = false;
        }

        void UpdateDim() {
            Dim = Font.MeasureString(Text) * Size;
            wDim = (int)Dim.X;
            hDim = (int)Dim.Y;
        }

        public void SetColor(Color color) {
            TextColor = color;
        }

        public void SetText(string text) {
            Text = text;
            UpdateDim();
        }

        public void SetSize(float size) {
            Size = size/DEFAULT_SIZE;
            UpdateDim();
        }

        public override void Draw(GameTime gameTime) {
            if (IsVisible) {
                var position = Parent.GetComponent<ScreenPositionComponent>("ScreenPositionComponent").Position;
                _spriteBatch.DrawString(Font, Text, position, TextColor, 0, Vector2.Zero, Size, SpriteEffects.None, 1f);
            }
        }
    }
}