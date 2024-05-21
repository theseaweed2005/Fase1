using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project002;
using System;
using System.Collections.Generic;
using TDVF2_29849_22530.Manager;
using TDVF2_29849_22530.Stuff.Attack;
using TDVF2_29849_22530.Stuff.Base;

namespace TDVF2_29849_22530.Stuff
{
    public class Player : MovingSprite
    {
        private Weapon _weapon1;
        private Weapon _weapon2;
        public bool Dead { get; private set; }
        public int XP { get; private set; }

        public Player(Texture2D tex) : base(tex, GetStartPosition())
        {
            Reset();
        }

        private static Vector2 GetStartPosition()
        {
            return new Vector2(Globals.Bounds.X / 2, Globals.Bounds.Y / 2);
        }

        public void GetXP(int exp)
        {
            XP += exp;
        }

        public void Reset()
        {
            _weapon1 = new MachineGun(); // Assuming MachineGun and Shotgun classes are defined
            _weapon2 = new Shotgun(); // Assuming MachineGun and Shotgun classes are defined
            Dead = false;
            Weapon = _weapon1;
            Position = GetStartPosition();
            XP = 0;
        }

        public void SwapWeapon()
        {
            Weapon = (Weapon == _weapon1) ? _weapon2 : _weapon1;
        }

        public void Update(List<Monsters> monsters)
        {
            if (InputManager.Direction != Vector2.Zero)
            {
                var dir = Vector2.Normalize(InputManager.Direction);
                Position = new Vector2(
                    MathHelper.Clamp(Position.X + (dir.X * Speed * Globals.TotalSeconds), 0, Globals.Bounds.X),
                    MathHelper.Clamp(Position.Y + (dir.Y * Speed * Globals.TotalSeconds), 0, Globals.Bounds.Y)
                );
            }

            var toMouse = InputManager.MousePosition - Position;
            Rotation = (float)Math.Atan2(toMouse.Y, toMouse.X);

            Weapon.Update();

            if (InputManager.SpacePressed)
            {
                SwapWeapon();
            }

            if (InputManager.MouseLeftDown)
            {
                Weapon.Fire(this);
            }

            if (InputManager.MouseRightClicked)
            {
                Weapon.Reload();
            }

            CheckDeath(monsters);
        }

        private void CheckDeath(List<Monsters> monsters)
        {
            foreach (var m in monsters)
            {
                if ((Position - m.Position).Length() < 50)
                {
                    Dead = true;
                    break;
                }
            }
        }
    }
}
