using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;

namespace ProjectEthereal.GameContent.Utils {
    class WorleyNoise {
        List<Vector2> Nodes { get; set; }
        float ScaleX { get; set; }
        float ScaleY { get; set; }
        public WorleyNoise(int width, int height, int nbCell) {
            ScaleX = 1/(float)width;
            ScaleY = 1/(float)height;
            Nodes = new List<Vector2>();
            var rand = new Random();
            while (Nodes.Count < nbCell) {
                var xx = rand.Next(width) * ScaleX;
                var yy = rand.Next(height) * ScaleY;
                Nodes.Add(new Vector2(xx, yy));
            }

            //DEBUG
            //GetImage(width, height);
        }

        async void GetImage(int w, int h) {
            using StreamWriter file = new StreamWriter("Test/img_data.txt");
            for (int i = 0; i < w; i++) {
                for (int j = 0; j < h; j++) {
                    var val = GetValue(i, j);
                    var splitter = (j == h-1) ? "" : ",";
                    await file.WriteAsync(val.ToString() + splitter);
                }
                await file.WriteLineAsync();
            }
            file.Close();
        }

        public float GetValue(int i, int j) {
            var pos = new Vector2(i * ScaleX, j * ScaleY);
            float minDist = int.MaxValue;
            Nodes.ForEach(node => {
                var dist = Vector2.Distance(pos, node);
                if (dist < minDist) {
                    minDist = dist;
                }
            });
            return (float)Math.Pow(1-minDist,9);
        }
    }
}