using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project002;
using System;
using TDVF2_29849_22530.Manager;
using TDVF2_29849_22530.Stuff.Base;

namespace TDVF2_29849_22530.Stuff
{
    public class Monster : Sprite
    {
        public int HP { get; private set; } = 2;
        public float Speed { get; private set; } = 100;

        public Monster(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            Speed = 100;
            HP = 2;
        }

        public void TakeDamage(int dmg)
        {
            HP -= dmg;
            if (HP <= 0) XPManager.AddXP(Position);
        }

        public void Update(Player player)
        {
            var toPlayer = player.Position - Position;
            Rotation = (float)Math.Atan2(toPlayer.Y, toPlayer.X);

            if (toPlayer.Length() > 4)
            {
                var dir = Vector2.Normalize(toPlayer);
                Position += dir * Speed * Globals.TotalSeconds;
            }
        }
    }
}
