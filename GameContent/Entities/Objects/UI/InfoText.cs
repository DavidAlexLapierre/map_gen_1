using Microsoft.Xna.Framework;
using ProjectEthereal.Engine.Components;
using ProjectEthereal.Engine.Events;
using ProjectEthereal.GameContent.Components;

namespace ProjectEthereal.GameContent.Entities {
    class InfoText : Entity {
        string Info { get; set; }
        public TextComponent Text { get; private set; }
        public ScreenPositionComponent Position { get; private set; }
        public InfoText(Game game, SceneEvents events) : base(game, events) {
            Text = new TextComponent(game);
            Position = new ScreenPositionComponent(game);
            AddComponent(Text);
            AddComponent(Position);
        }

        public void SetInfo(string info) {
            Info = info + ": ";
        }

        public void SetText(string data) {
            Text.SetText(Info + data);
        }
    }
}