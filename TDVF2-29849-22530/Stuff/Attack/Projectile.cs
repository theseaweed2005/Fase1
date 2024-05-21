using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project002;
using System;
using System.Collections.Generic;
using TDVF2_29849_22530.Stuff;

namespace TDVF2_29849_22530.Stuff.Attack
{
    public class Projectile
    {
        private const float MaxLifespan = 5f;
        private const float Speed = 500f;
        private readonly Vector2 _direction;
        private readonly float _damage;
        private float _lifespan;

        private Texture2D _texture;
        public Vector2 Position { get; private set; }

        public Projectile(Texture2D texture, ProjectileData data)
        {
            _texture = texture;
            Position = data.Position;
            _lifespan = MaxLifespan;
            _direction = new Vector2((float)Math.Cos(data.Rotation), (float)Math.Sin(data.Rotation));
            _damage = data.Damage;
        }

        public void Update()
        {
            Position += _direction * Speed * Globals.TotalSeconds;
            _lifespan -= Globals.TotalSeconds;
        }

        public bool IsOutOfBounds()
        {
            return _lifespan <= 0 || Position.X < 0 || Position.X > Globals.Bounds.X || Position.Y < 0 || Position.Y > Globals.Bounds.Y;
        }

        public bool CheckCollision(List<Monster> monsters)
        {
            foreach (var monster in monsters)
            {
                if (Vector2.Distance(Position, monster.Position) < 20) // Adjust the collision radius as needed
                {
                    monster.TakeDamage((int)_damage);
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(_texture, Position, null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);
        }
    }
}
