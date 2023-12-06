using Microsoft.Xna.Framework;
using ProjectEthereal.Engine.Components;
using ProjectEthereal.Engine.Events;
using ProjectEthereal.GameContent.Components;

namespace ProjectEthereal.GameContent.Entities {
    class TextOption : Entity {
        public ActionComponent Action { get; set; }
        public ScreenPositionComponent Position { get; private set; }
        public TextComponent Text { get; private set; }
        public TextOption(Game game, SceneEvents events) : base(game, events) {
            Action = new ActionComponent();
            Position = new ScreenPositionComponent(game);
            Text = new TextComponent(game);
            AddComponent(Action);
            AddComponent(Position);
            AddComponent(Text);
        }
    }
}