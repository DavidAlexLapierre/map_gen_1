using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectEthereal.Engine.Components;
using ProjectEthereal.Engine.Events;
using ProjectEthereal.Engine.Utils;
using ProjectEthereal.GameContent.Utils;

namespace ProjectEthereal.GameContent.Entities {
    class OptionScroller : Entity {
        List<TextOption> Options { get; set; }
        int CurrentIndex { get; set; }
        public OptionScroller(Game game, SceneEvents events) : base(game, events) {
            CurrentIndex = 0;
            Options = new List<TextOption>();
        }

        public void AddOption(TextOption option) { 
            Options.Add(option);
            AddChild(option);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (InputHelper.KeyPressed(Keys.Down)) {
                Options[CurrentIndex].Text.SetColor(ColorPalette.GetColor("subtext"));
                if (CurrentIndex == 0) {
                    CurrentIndex = Options.Count - 1;
                } else { 
                    CurrentIndex--; 
                }
                Options[CurrentIndex].Text.SetColor(ColorPalette.GetColor("text"));
            }
            if (InputHelper.KeyPressed(Keys.Up)) {
                Options[CurrentIndex].Text.SetColor(ColorPalette.GetColor("subtext"));
                if (CurrentIndex == Options.Count - 1) {
                    CurrentIndex = 0;
                } else {
                    CurrentIndex++;
                }
                Options[CurrentIndex].Text.SetColor(ColorPalette.GetColor("text"));
            }
            if (InputHelper.KeyPressed(Keys.Enter)) {
                Options[CurrentIndex].Action.Execute();
            }
        }
    }
}