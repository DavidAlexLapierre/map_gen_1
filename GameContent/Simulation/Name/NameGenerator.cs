using System;

namespace ProjectEthereal.GameContent.Simulation {
    class NameGenerator {
        public static string GetName() {
            // TODO: Implement a proper way of doing this
            return Guid.NewGuid().ToString();
        }
    }
}