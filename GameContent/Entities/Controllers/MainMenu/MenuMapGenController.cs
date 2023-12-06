using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectEthereal.Engine.Components;
using ProjectEthereal.Engine.Events;
using ProjectEthereal.Engine.Utils;
using ProjectEthereal.GameContent.Simulation;
using ProjectEthereal.GameContent.Utils;

namespace ProjectEthereal.GameContent.Entities {
    class MenuMapGenController : Entity {
        InfoText NameInfo { get; set; }
        InfoText YearInfo { get; set; }
        InfoText PopulationInfo { get; set; }
        InfoText SeedInfo { get; set; }
        InfoText Cancel { get; set; }
        InfoText NewMap { get; set; }
        InfoText Accept { get; set; }
        const int LEFT_OFFSET = 12;
        const int Y_OFFSET = 20;
        const int MAP_TOP_OFFSET = 16;
        const float TEXT_SIZE = 3.5f;
        GenMap Map { get; set; }

        public MenuMapGenController(Game game, SceneEvents events) : base(game, events) {
            // TODO: Move to init file?
            WorldCellConfig.LoadCellData(game.GraphicsDevice);
            WorldConfig.LoadWorldData();
            InitNameInfo();
            InitYearInfo();
            InitPopulationInfo();
            InitSeedInfo();
            InitGenerationMap();
            InitCancelAction();
            InitNewMapAction();
            InitAcceptAction();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (InputHelper.KeyPressed(Keys.Escape)) {
                AddEntity(new MainMenuController(_game, _events));
                Discard();
            }

            // reset map
            if (InputHelper.KeyPressed(Keys.R)) {
                ResetMap();
            }
        }

        void ResetMap() {
            Map.InitMap();
            Generator.Init();
            SeedInfo.SetText(Generator.Seed.ToString());
        }

        void InitNameInfo() {
            NameInfo = new InfoText(_game, _events);
            // Text
            NameInfo.SetInfo("Name");
            NameInfo.SetText(NameGenerator.GetName());
            NameInfo.Text.SetSize(TEXT_SIZE);
            NameInfo.Text.SetColor(ColorPalette.GetColor("text"));
            // Position
            NameInfo.Position.SetPosition(new Vector2(LEFT_OFFSET, Y_OFFSET));
            AddChild(NameInfo);
        }

        void InitYearInfo() {
            YearInfo = new InfoText(_game, _events);
            // Text
            YearInfo.SetInfo("Year");
            YearInfo.SetText("0");
            YearInfo.Text.SetSize(TEXT_SIZE);
            YearInfo.Text.SetColor(ColorPalette.GetColor("text"));
            // Position
            YearInfo.Position.SetPosition(new Vector2(LEFT_OFFSET, 2*Y_OFFSET));
            AddChild(YearInfo);
        }

        void InitPopulationInfo() {
            PopulationInfo = new InfoText(_game, _events);
            // Text
            PopulationInfo.SetInfo("Population");
            PopulationInfo.SetText("0");
            PopulationInfo.Text.SetSize(TEXT_SIZE);
            PopulationInfo.Text.SetColor(ColorPalette.GetColor("text"));
            // Position
            PopulationInfo.Position.SetPosition(new Vector2(LEFT_OFFSET, 3*Y_OFFSET));
            AddChild(PopulationInfo);
        }

        void InitSeedInfo() {
            SeedInfo = new InfoText(_game, _events);
            // Text
            SeedInfo.SetInfo("Seed");
            SeedInfo.SetText(Generator.Seed.ToString());
            SeedInfo.Text.SetSize(TEXT_SIZE);
            SeedInfo.Text.SetColor(ColorPalette.GetColor("text"));
            // Position
            SeedInfo.Position.SetPosition(new Vector2(LEFT_OFFSET, 4*Y_OFFSET));
            AddChild(SeedInfo);
        }

        void InitGenerationMap() {
            Map = new GenMap(_game, _events);
            var xPos = Camera.VIEW_WIDTH - 272;
            Map.Position.SetPosition(new Vector2(xPos, MAP_TOP_OFFSET));
            AddChild(Map);
        }

        void InitCancelAction() {
            Cancel = new InfoText(_game, _events);
            // Text
            Cancel.SetInfo("Cancel");
            Cancel.SetText("[ESC]");
            Cancel.Text.SetSize(TEXT_SIZE);
            Cancel.Text.SetColor(ColorPalette.GetColor("subtext"));
            // Position
            var yy = Camera.VIEW_HEIGHT - Cancel.Text.hDim - Y_OFFSET;
            Cancel.Position.SetPosition(new Vector2(LEFT_OFFSET, yy));

            AddChild(Cancel);
        }

        void InitNewMapAction() {
            NewMap = new InfoText(_game, _events);
            // Text
            NewMap.SetInfo("New Map");
            NewMap.SetText("[R]");
            NewMap.Text.SetSize(TEXT_SIZE);
            NewMap.Text.SetColor(ColorPalette.GetColor("subtext"));
            // Position
            var yy = Camera.VIEW_HEIGHT - NewMap.Text.hDim - Y_OFFSET;
            var offset = 2*LEFT_OFFSET + Cancel.Text.wDim;
            NewMap.Position.SetPosition(new Vector2(offset, yy));

            AddChild(NewMap);
        }

        void InitAcceptAction() {
            Accept = new InfoText(_game, _events);
            // Text
            Accept.SetInfo("Accept");
            Accept.SetText("[ENTER]");
            Accept.Text.SetSize(TEXT_SIZE);
            Accept.Text.SetColor(ColorPalette.GetColor("subtext"));
            // Position
            var yy = Camera.VIEW_HEIGHT - Accept.Text.hDim - Y_OFFSET;
            var offset = 3*LEFT_OFFSET + Cancel.Text.wDim + NewMap.Text.wDim;
            Accept.Position.SetPosition(new Vector2(offset, yy));

            AddChild(Accept);
        }
    }
}