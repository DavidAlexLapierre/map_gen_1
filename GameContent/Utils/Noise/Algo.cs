namespace ProjectEthereal.GameContent.Utils {
    class Algo {
        public string Type { get; private set; }
        public float Roughness { get; private set; }
        public float Strength { get; private set; }
        public float Scale { get; private set; }
        public bool OneMinus { get; private set; }
        public bool Minus { get; private set; }
        
        public Algo(string type, float roughness, float strength, float scale, bool  oneMinus, bool minus) {
            Type = type;
            Roughness = roughness;
            Strength = strength;
            Scale = scale;
            OneMinus = oneMinus;
            Minus = minus;
        }
    }
}