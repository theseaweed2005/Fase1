using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TDVF2_29849_22530.Stuff.Base
{
    public class MovingSprite : Sprite
    {
        public int Speed { get; set; } = 300;

        public MovingSprite(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            // Constructor logic if needed
        }
    }
}
