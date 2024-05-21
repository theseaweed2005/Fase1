using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project002;
using System;
using TDVF2_29849_22530.Stuff;

namespace TDVF2_29849_22530.Manager
{
    public static class UIManager
    {
        private static SpriteFont _font;

        public static void Init(SpriteFont font)
        {
            _font = font;
        }

        public static void Draw()
        {
            Globals.SpriteBatch.DrawString(_font, "Health: ", new Vector2(10, 10), Color.White);
            Globals.SpriteBatch.DrawString(_font, "XP: ", new Vector2(10, 30), Color.White);
        }

        public static void DrawPlayerInfo(Player player)
        {
            Globals.SpriteBatch.DrawString(_font, player.HP.ToString(), new Vector2(90, 10), Color.White);
            Globals.SpriteBatch.DrawString(_font, player.XP.ToString(), new Vector2(90, 30), Color.White);
        }
    }
}
