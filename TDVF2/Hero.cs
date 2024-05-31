using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TDVF2
{
    public class Hero
    {
        private readonly Texture2D _texture;
        private Vector2 _position;
        private Vector2 _velocity;
        private bool _isJumping;

        public Hero(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
            _velocity = Vector2.Zero;
        }

        public void Update()
        {
            _velocity.X = InputManager.Direction.X * 5f;

            if (_isJumping)
            {
                _velocity.Y += 0.5f; // Gravity
                if (_position.Y >= 300) // Ground level
                {
                    _position.Y = 300;
                    _velocity.Y = 0;
                    _isJumping = false;
                }
            }
            else if (InputManager.Jump)
            {
                _isJumping = true;
                _velocity.Y = -10f; // Jump force
            }

            _position += _velocity;
        }

        public void CheckCollision(Platform platform)
        {
            if (_position.Y + _texture.Height >= platform.Position.Y &&
                _position.X + _texture.Width > platform.Position.X &&
                _position.X < platform.Position.X + platform.Texture.Width)
            {
                _position.Y = platform.Position.Y - _texture.Height;
                _velocity.Y = 0;
                _isJumping = false;
            }
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
