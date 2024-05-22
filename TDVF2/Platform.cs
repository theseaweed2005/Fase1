using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TDVF2
{
    public class Platform
    {
        public Texture2D Texture { get; private set; }
        public Vector2 Position { get; private set; }

        public Platform(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
