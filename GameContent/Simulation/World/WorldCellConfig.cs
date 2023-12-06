using System.Collections.Generic;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectEthereal.Engine.Utils;

namespace ProjectEthereal.GameContent.Simulation {
    class WorldCellConfig {
        static Dictionary<string, WorldCell> WorldCellData { get; set; }
        const string FILE_LOCATION = "Content/Configs/WorldCells.xml";

        static WorldCellConfig() { WorldCellData = new Dictionary<string, WorldCell>(); }

        public static WorldCell Get(string name) {
            if (WorldCellData.ContainsKey(name)) return WorldCellData[name].Get();

            return null;
        }
        public static void LoadCellData(GraphicsDevice _graphicsDevice) {
            XmlDocument doc = new XmlDocument();
            doc.Load(FILE_LOCATION);

            foreach(XmlNode cellData in doc.DocumentElement.ChildNodes) {
                var cell = new WorldCell();
                var sprites = new List<Rectangle>();

                var name = cellData.Attributes["name"].InnerText;
                var tileset = cellData.Attributes["tileset"].InnerText;
                var onLand = cellData.Attributes["on_land"]?.InnerText;
                if (onLand != null) { cell.SetOnLandState(bool.Parse(onLand)); }
                TextureLoader.LoadTexture(_graphicsDevice, tileset);

                foreach(XmlNode spriteData in cellData) {
                    var x = int.Parse(spriteData.Attributes["x"].InnerText);
                    var y = int.Parse(spriteData.Attributes["y"].InnerText);
                    var w = int.Parse(spriteData.Attributes["w"].InnerText);
                    var h = int.Parse(spriteData.Attributes["h"].InnerText);
                    sprites.Add(new Rectangle(x, y, w, h));
                }

                cell.SetSpriteTable(sprites);
                cell.SetColor(cellData.Attributes["color"].InnerText);
                cell.SetTexture(tileset);

                WorldCellData.Add(name, cell);
            }
        }
    }
}