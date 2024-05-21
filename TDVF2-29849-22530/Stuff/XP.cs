using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project002;
using TDVF2_29849_22530.Stuff.Base;

namespace TDVF2_29849_22530.Stuff
{
    public class XP : Sprite
    {
        public float Lifespan { get; private set; } = LIFE;
        private const float LIFE = 5f;

        public XP(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
        }

        public void Update()
        {
            Lifespan -= Globals.TotalSeconds;
            Scale = 0.33f + (Lifespan / LIFE * 0.66f);
        }

        public void Collect()
        {
            Lifespan = 0;
        }
    }
}
