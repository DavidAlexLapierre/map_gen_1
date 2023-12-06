using System;

namespace ProjectEthereal.GameContent.Utils {
    class Generator {
        public static int Seed { get; private set; }
        static Random Random { get; set; }
        static Generator() { Init(); }

        public static double NextDouble() { return Random.NextDouble(); }
        public static int Next() { return Random.Next(); }
        public static int Next(int max) { return Random.Next(max); }
        public static int Next(int min, int max) { return Random.Next(min, max); }

        public static void Init() {
            var seedGen = new Random();
            Seed = seedGen.Next(int.MaxValue);
            Random = new Random(Seed);
        }

        public static void Init(int seed) {
            Seed = seed;
            Random = new Random(Seed);
        }
    }
}