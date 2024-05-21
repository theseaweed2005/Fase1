using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project002;
using System.Collections.Generic;
using TDVF2_29849_22530.Stuff;
using TDVF2_29849_22530.Stuff.Attack;

namespace TDVF2_29849_22530.Manager
{
    public static class ProjectileManager
    {
        private static Texture2D _texture;
        public static List<Projectile> Projectiles { get; } = new List<Projectile>();

        public static void Init(Texture2D tex)
        {
            _texture = tex;
        }

        public static void Reset()
        {
            Projectiles.Clear();
        }

        public static void AddProjectile(ProjectileData data)
        {
            Projectiles.Add(new Projectile(_texture, data));
        }

        public static void Update(List<Monster> monsters)
        {
            for (int i = Projectiles.Count - 1; i >= 0; i--)
            {
                Projectiles[i].Update();
                if (Projectiles[i].IsOutOfBounds() || Projectiles[i].CheckCollision(monsters))
                {
                    Projectiles.RemoveAt(i);
                }
            }
        }

        public static void Draw()
        {
            foreach (var projectile in Projectiles)
            {
                projectile.Draw();
            }
        }
    }
}
