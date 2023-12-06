using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ProjectEthereal.GameContent.Simulation;

namespace ProjectEthereal.GameContent.Utils {
    class Pass {
        List<Algo> Algos { get; set; }
        List<HeightCell> Cells { get; set; }
        public Pass() {
            Algos = new List<Algo>();
            Cells = new List<HeightCell>();
        }

        public WorldCell[,] Apply(WorldCell[,] map) {
            float[,] valMap = new float[map.GetLength(0), map.GetLength(1)];
            Algos.ForEach((algo) => {
                switch(algo.Type) {
                    case "simplex":
                        valMap = ApplySimplex(algo, valMap);
                        break;
                    case "worley":
                        valMap = ApplyWorley(algo, valMap);
                        break;
                    case "square":
                        valMap = ApplySquare(algo, valMap);
                        break;
                }
            });

            map = MapHeightToCell(map, valMap);

            return map;
        }

        WorldCell[,] MapHeightToCell(WorldCell[,] map, float[,] valMap) {
            for (int i = 0; i < map.GetLength(0); i++) {
                for (int j = 0; j < map.GetLength(1); j++) {
                    WorldCell worldCell = map[i,j];
                    foreach(var cell in Cells) {
                        if (cell.OnLand) {
                            if (valMap[i,j] <= cell.Cutoff && map[i,j].OnLand) { 
                                worldCell = WorldCellConfig.Get(cell.Name);
                            }
                        } else {
                            if (valMap[i,j] <= cell.Cutoff) { 
                                worldCell = WorldCellConfig.Get(cell.Name);
                            }
                        }
                        
                    }

                    if (worldCell == null) {
                        // do something;
                    }

                    map[i,j] = worldCell;
                }
            }

            return map;
        }

        float[,] ApplySimplex(Algo algo, float[,] map) {
            Noise noise = new Noise();
            var center = new Vector3((float)Generator.NextDouble(), (float)Generator.NextDouble(), 1) * algo.Scale;
            
            for (int i = 0; i < map.GetLength(0); i++) {
                for (int j = 0; j < map.GetLength(1); j++) {
                    float value = noise.Evaluate(new Vector3(i, j, 1) * algo.Roughness + center) * algo.Strength;
                    map[i,j] += AdaptValue(algo, value);
                }
            }

            return map;
        }

        float[,] ApplySquare(Algo algo, float[,] map) {
            var width = map.GetLength(0);
            var height = map.GetLength(1);
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    float value = SquareGradient.GetValue(new Point(i, j), width, height, algo.Scale) * algo.Strength;
                    map[i,j] += AdaptValue(algo, value);
                }
            }

            return map;
        }

        float[,] ApplyWorley(Algo algo, float[,] map) {
            var width = map.GetLength(0);
            var height = map.GetLength(1);

            WorleyNoise noise = new WorleyNoise(width, height, (int) algo.Scale);

            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    float value = noise.GetValue(i, j) * algo.Strength;
                    map[i,j] += AdaptValue(algo, value);
                }
            }

            return map;
        }

        float AdaptValue(Algo algo, float value) {
            if (algo.OneMinus) value = 1 - value;
            if (algo.Minus) value = -value;

            return value;
        }

        public void AddAlgo(Algo algo) { Algos.Add(algo); }
        public void AddCell(HeightCell cell) { Cells.Add(cell); }
    }
}