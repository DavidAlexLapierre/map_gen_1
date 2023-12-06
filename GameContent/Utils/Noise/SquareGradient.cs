using System;
using System.IO;
using Microsoft.Xna.Framework;

namespace ProjectEthereal.GameContent.Utils {
    class SquareGradient {
        public static float GetValue(Point coords, int width, int height, float scale) {
            int halfWidth = width / 2;
            int halfHeight = height / 2;

            int x = coords.X;
            int y = coords.Y;

            Vector2 cv = new Vector2();

            cv = (x < halfWidth) ? new Vector2(width - x, cv.Y) : new Vector2(x, cv.Y);
            cv = (y < halfHeight) ? new Vector2(cv.X, height - y) : new Vector2(cv.X, y);

            var colVal = Math.Max(cv.X, cv.Y);
            var divider = (cv.X > cv.Y) ? width : height;

            var val = colVal / (float)divider;
            val *= (float)Math.Pow(val, scale);

            return val;
        }
    }
}