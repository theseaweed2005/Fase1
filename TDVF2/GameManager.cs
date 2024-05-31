using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TDVF2
{
    public class GameManager
    {
        private Hero _hero;
        private Platform _platform;

        public void Init()
        {
            _platform = new Platform(Globals.Content.Load<Texture2D>("platform"), new Vector2(100, 400));
            _hero = new Hero(Globals.Content.Load<Texture2D>("idledir"), new Vector2(100, 300));
        }

        public void Update()
        {
            InputManager.Update();
            _hero.Update();
            _hero.CheckCollision(_platform);
        }

        public void Draw()
        {
            _platform.Draw();
            _hero.Draw();
        }
    }
}
