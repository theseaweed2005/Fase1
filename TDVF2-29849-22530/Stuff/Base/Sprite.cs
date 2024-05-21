using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TDVF2_29849_22530.Stuff.Base
{
    public class Sprite
    {
        protected readonly Texture2D texture;
        protected readonly Vector2 origin;
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public float Scale { get; set; } = 1f;
        public Color Color { get; set; } = Color.White;

        public Sprite(Texture2D tex, Vector2 pos)
        {
            texture = tex;
            origin = new Vector2(tex.Width / 2, tex.Height / 2);
            Position = pos;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color, Rotation, origin, Scale, SpriteEffects.None, 1);
        }
    }
}
