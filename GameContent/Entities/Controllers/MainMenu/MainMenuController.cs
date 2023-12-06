using System;
using Microsoft.Xna.Framework;
using ProjectEthereal.Engine.Components;
using ProjectEthereal.Engine.Events;

namespace ProjectEthereal.GameContent.Entities {
    class MainMenuController : Entity {
        OptionScroller Options { get; set; }
        TextOption Title { get; set; }
        TextOption CreateWorld { get; set; }
        TextOption Exit { get; set; }
        public MainMenuController(Game game, SceneEvents events) : base(game, events) {
            Options = new OptionScroller(game, events);
            AddChild(Options);
            InitTitle();
            InitCreateWorldOption();
            InitExitOption();
        }

        void InitTitle() {
            Title = new TextOption(_game, _events);
            // Text
            Title.Text.SetText("ETHEREAL");
            Title.Text.SetColor(Utils.ColorPalette.GetColor("title"));
            Title.Text.SetSize(20);
            // Position
            Title.Position.SetPosition(new Vector2(0, 24));
            Title.Position.CenterHorizontal(Title.Text.wDim);
            AddChild(Title);
        }

        void InitCreateWorldOption() {
            CreateWorld = new TextOption(_game, _events);
            // Text
            CreateWorld.Text.SetText("Create new world");
            CreateWorld.Text.SetColor(Utils.ColorPalette.GetColor("text"));
            CreateWorld.Text.SetSize(6);
            // Position
            CreateWorld.Position.SetPosition(new Vector2(0, 112));
            CreateWorld.Position.CenterHorizontal(CreateWorld.Text.wDim);
            // Action
            CreateWorld.Action.Handler += GoToMapGen;
            Options.AddOption(CreateWorld);
        }

        void InitExitOption() {
            Exit = new TextOption(_game, _events);
            // Text
            Exit.Text.SetText("Exit");
            Exit.Text.SetColor(Utils.ColorPalette.GetColor("subtext"));
            Exit.Text.SetSize(6);
            // Position
            Exit.Position.SetPosition(new Vector2(0, 132));
            Exit.Position.CenterHorizontal(Exit.Text.wDim);
            //Action
            Exit.Action.Handler += ExitEvent;
            Options.AddOption(Exit);
        }

        void GoToMapGen(object sender, EventArgs args) {
            AddEntity(new MenuMapGenController(_game, _events));
            Discard();
        }

        void ExitEvent(object sender, EventArgs args) {
            _game.Exit();
        }
    }
}