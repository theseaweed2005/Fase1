﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDVF2_29849_22530.Manager
{
    public static class InputManager
    {
        private static MouseState _lastMouseState;
        private static KeyboardState _lastKeyboardState;
        private static Vector2 _direction;

        public static Vector2 Direction => _direction;
        public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
        public static bool MouseClicked { get; private set; }
        public static bool MouseRightClicked { get; private set; }
        public static bool MouseLeftDown { get; private set; }
        public static bool SpacePressed { get; private set; }

        public static void Update()
        {
            var keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();

            _direction = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.W)) _direction.Y--;
            if (keyboardState.IsKeyDown(Keys.S)) _direction.Y++;
            if (keyboardState.IsKeyDown(Keys.A)) _direction.X--;
            if (keyboardState.IsKeyDown(Keys.D)) _direction.X++;

            MouseLeftDown = mouseState.LeftButton == ButtonState.Pressed;
            MouseClicked = MouseLeftDown && (_lastMouseState.LeftButton == ButtonState.Released);
            MouseRightClicked = mouseState.RightButton == ButtonState.Pressed
                                && (_lastMouseState.RightButton == ButtonState.Released);

            SpacePressed = _lastKeyboardState.IsKeyUp(Keys.Space) && keyboardState.IsKeyDown(Keys.Space);

            _lastMouseState = mouseState;
            _lastKeyboardState = keyboardState;
        }
    }
}
