using System.Collections.Generic;
using System.Xml;
using ProjectEthereal.GameContent.Utils;

namespace ProjectEthereal.GameContent.Simulation {
    class WorldConfig {
        static List<Pass> Passes { get; set; }
        public static int Width { get; private set; }
        public static int Height { get; private set; }
        const string FILE_LOCATION = "Content/Configs/World.xml";

        static WorldConfig() { Passes = new List<Pass>(); }

        public static WorldCell[,] GetWorldData() {
            var data = new WorldCell[Width, Height];

            Passes.ForEach(pass => {
                data = pass.Apply(data);
            });

            return data;
        }

        public static void LoadWorldData() {
            XmlDocument doc = new XmlDocument();
            doc.Load(FILE_LOCATION);

            XmlNode world = doc.DocumentElement;
            Width = int.Parse(world.Attributes["width"].InnerText);
            Height = int.Parse(world.Attributes["height"].InnerText);

            XmlNode passes = world.SelectSingleNode("passes");
            
            foreach(XmlNode passData in passes.ChildNodes) {
                var pass = new Pass();
                var algos = passData.SelectSingleNode("algos");
                var cells = passData.SelectSingleNode("cells");

                foreach(XmlNode algoData in algos.ChildNodes) {
                    var type = algoData.Attributes["type"].InnerText;
                    var roughness = float.Parse(algoData.Attributes["roughness"].InnerText);
                    var strength = float.Parse(algoData.Attributes["strength"].InnerText);
                    var scale = float.Parse(algoData.Attributes["scale"].InnerText);

                    var oneMinus = (algoData.Attributes["one_minus"]?.InnerText == null) ? false : true;
                    var minus = (algoData.Attributes["minus"]?.InnerText == null) ? false : true;

                    pass.AddAlgo(new Algo(type, roughness, strength, scale, oneMinus, minus));
                }

                foreach(XmlNode cellData in cells.ChildNodes) {
                    var name = cellData.Attributes["name"].InnerText;
                    var cutoff = float.Parse(cellData.Attributes["cutoff"].InnerText);

                    var onLand = (cellData.Attributes["check_land"]?.InnerText == null) ? false : true;

                    pass.AddCell(new HeightCell(name, cutoff, onLand));
                }

                Passes.Add(pass);
            }
        }
    }
}