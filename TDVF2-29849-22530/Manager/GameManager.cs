using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TDVF2_29849_22530.Manager;
using TDVF2_29849_22530.Stuff;

namespace TDVF2_29849_22530
{
    public class GameManager
    {
        private Player _player;
        private List<Monsters> _monsters;

        public GameManager()
        {
            _player = new Player(Globals.Content.Load<Texture2D>("posição3"));
            _monsters = new List<Monsters>();
            _monsters.Add(new Monsters(Globals.Content.Load<Texture2D>("1"), new Vector2(100, 100))); 
        }

        public void Update()
        {
            _player.Update(_monsters);

            foreach (var monster in _monsters)
            {
                monster.Update(_player);
            }

            ProjectileManager.Update(_monsters);
            XPManager.Update();
        }

        public void Draw()
        {
            _player.Draw();

            foreach (var monster in _monsters)
            {
                monster.Draw();
            }

            ProjectileManager.Draw();
            XPManager.Draw();
        }
    }
}
