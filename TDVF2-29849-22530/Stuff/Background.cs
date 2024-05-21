using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Project002;
using TDVF2_29849_22530.Stuff.Base;

namespace TDVF2_29849_22530.Stuff
{
    public class Background
    {
        private readonly Point _mapTileSize = new Point(6, 4);
        private readonly Sprite[,] _tiles;

        public Background()
        {
            _tiles = new Sprite[_mapTileSize.X, _mapTileSize.Y];

            List<Texture2D> textures = new List<Texture2D>(5);
            for (int i = 1; i < 6; i++) textures.Add(Globals.Content.Load<Texture2D>($"tile{i}"));

            Point tileSize = new Point(textures[0].Width, textures[0].Height);
            Random random = new Random();
            for (int y = 0; y < _mapTileSize.Y; y++)
            {
                for (int x = 0; x < _mapTileSize.X; x++)
                {
                    int r = random.Next(0, textures.Count);
                    _tiles[x, y] = new Sprite(textures[r], new Vector2((x + 0.5f) * tileSize.X, (y + 0.5f) * tileSize.Y));
                }
            }
        }

        public void Draw()
        {
            for (int y = 0; y < _mapTileSize.Y; y++)
            {
                for (int x = 0; x < _mapTileSize.X; x++) _tiles[x, y].Draw();
            }
        }
    }
}
