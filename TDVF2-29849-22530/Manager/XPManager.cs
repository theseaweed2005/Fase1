using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project002;
using System;
using System.Collections.Generic;
using TDVF2_29849_22530.Stuff;

namespace TDVF2_29849_22530.Manager
{
    public static class XPManager
    {
        private static Texture2D _texture;
        private static List<XP> _xps = new List<XP>();

        public static void Init(Texture2D texture)
        {
            _texture = texture;
        }

        public static void Reset()
        {
            _xps.Clear();
        }

        public static void AddXP(Vector2 pos)
        {
            _xps.Add(new XP(_texture, pos));
        }

        public static void Update()
        {
            for (int i = _xps.Count - 1; i >= 0; i--)
            {
                _xps[i].Update();
                if (_xps[i].Lifespan <= 0)
                {
                    _xps.RemoveAt(i);
                }
            }
        }

        public static void Draw()
        {
            foreach (var xp in _xps)
            {
                xp.Draw();
            }
        }
    }
}
