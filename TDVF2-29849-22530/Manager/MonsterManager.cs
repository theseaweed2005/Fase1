using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project002;
using System.Collections.Generic;
using System;
using TDVF2_29849_22530.Stuff;

namespace TDVF2_29849_22530.Manager
{
    public static class MonsterManager
    {
        public static List<Monster> Monsters { get; } = new List<Monster>();
        private static Texture2D _texture;
        private static float _spawnCooldown;
        private static float _spawnTime;
        private static Random _random;
        private static int _padding;

        public static void Init()
        {
            _texture = Globals.Content.Load<Texture2D>("monster");
            _spawnCooldown = 0.33f;
            _spawnTime = _spawnCooldown;
            _random = new Random();
            _padding = _texture.Width / 2;
        }

        public static void Reset()
        {
            Monsters.Clear();
            _spawnTime = _spawnCooldown;
        }

        private static Vector2 RandomPosition()
        {
            float w = Globals.Bounds.X;
            float h = Globals.Bounds.Y;
            Vector2 pos = new Vector2();

            if (_random.NextDouble() < w / (w + h))
            {
                pos.X = (int)(_random.NextDouble() * w);
                pos.Y = (int)(_random.NextDouble() < 0.5 ? -_padding : h + _padding);
            }
            else
            {
                pos.Y = (int)(_random.NextDouble() * h);
                pos.X = (int)(_random.NextDouble() < 0.5 ? -_padding : w + _padding);
            }

            return pos;
        }

        public static void AddMonster()
        {
            Monsters.Add(new Monster(_texture, RandomPosition()));
        }

        public static void Update(Player player)
        {
            _spawnTime -= Globals.TotalSeconds;
            while (_spawnTime <= 0)
            {
                _spawnTime += _spawnCooldown;
                AddMonster();
            }

            foreach (var m in Monsters)
            {
                m.Update(player);
            }
            Monsters.RemoveAll(m => m.HP <= 0);
        }

        public static void Draw()
        {
            foreach (var m in Monsters)
            {
                m.Draw();
            }
        }
    }
}
