﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TDVF2
{
    public static class InputManager
    {
        private static Vector2 _direction;
        public static Vector2 Direction => _direction;
        public static bool Jump { get; private set; }
        private static KeyboardState _lastKeyboardState;

        public static void Update()
        {
            var keyboardState = Keyboard.GetState();
            _direction = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.A)) _direction.X--;
            if (keyboardState.IsKeyDown(Keys.D)) _direction.X++;
            if (keyboardState.IsKeyDown(Keys.W)) _direction.Y--;
            if (keyboardState.IsKeyDown(Keys.S)) _direction.Y++;

            Jump = keyboardState.IsKeyDown(Keys.Space) && !_lastKeyboardState.IsKeyDown(Keys.Space);

            _lastKeyboardState = keyboardState;
        }
    }
}
