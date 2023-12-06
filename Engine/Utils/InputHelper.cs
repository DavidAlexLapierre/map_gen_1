using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectEthereal.Engine.Components;
using ProjectEthereal.Engine.Managers;

namespace ProjectEthereal.Engine.Utils {
    class InputHelper {
        static Camera _camera { get; set; }
        public static KeyboardState currentState { get; private set; }
        public static MouseState currentMouseState { get; private set; }
        static KeyboardState previousState;
        static bool CanLeftClick { get; set; }
        static bool CanRightClick { get; set; }

        public static void SetVisualManager(Game game) {
            _camera = game.Services.GetService<Camera>();
        }

        static InputHelper() {
            currentState = Keyboard.GetState();
            CanLeftClick = true;
            CanRightClick = true;
        }

        public static bool KeyPressed(Keys key) {
            currentState = Keyboard.GetState();
            if (previousState != currentState && currentState.IsKeyDown(key)) {
                return currentState.IsKeyDown(key);
            }

            return false;
        }

        public static bool KeyDown(Keys key) {
            currentState = Keyboard.GetState();
            return currentState.IsKeyDown(key);
        }

        public static bool KeyReleased(Keys key) {
            previousState = currentState;
            currentState = Keyboard.GetState();
            return (currentState.IsKeyUp(key) && previousState.IsKeyDown(key));
        }

        public static bool LeftButtonPressed() {
            currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Pressed && CanLeftClick) {
                CanLeftClick = false;
                return true;
            }
            return false;
        }

        public static bool RightButtonPressed() {
            currentMouseState = Mouse.GetState();
            if (currentMouseState.RightButton == ButtonState.Pressed && CanRightClick) {
                CanRightClick = false;
                return true;
            }
            return false;
        }

        public static bool LeftButtonReleased() {
            currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Released) {
                CanLeftClick = true;
                return true;
            }
            return false;
        }

        public static bool RightButtonReleased() {
            currentMouseState = Mouse.GetState();
            if (currentMouseState.RightButton == ButtonState.Released) {
                CanRightClick = true;
                return true;
            }
            return false;
        }

        public static Vector2 GetMousePosition() {
            currentMouseState = Mouse.GetState();
            var position = new Vector2(currentMouseState.X, currentMouseState.Y);
            var scaledPosition = _camera.ScalePosition(position);
            return scaledPosition;
        }

        public static void Update(GameTime gameTime) {
            previousState = currentState;
            LeftButtonReleased();
            RightButtonReleased();
        }
    }
}
