﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1.Loaders
{
    class Preload
    {
        public Preload(ContentManager content, List<Classes.WorldItem> worldItems)
        {
            AddTiles(content, worldItems);

            var item1 = new Classes.Player(new Vector2(100f, 100f), new Vector2(11f, 11f), content.Load<Texture2D>("pixel"), new Vector2(0, 0), 1.0f);
            item1.SetColor(Color.Black);
            worldItems.Add(item1);
        }

        private void AddTiles(ContentManager content, List<Classes.WorldItem> worldItems)
        {            
            var tile = content.Load<Texture2D>("grassmedi");
            for (int xTiles = 0; xTiles < 10;xTiles++ )
            {
                for (int yTiles = 0; yTiles < 10;yTiles++ )
                {
                    var position = new Vector2(xTiles * tile.Width, yTiles * tile.Height);
                    var worldTileItem = new Classes.WorldItem(position, tile);
                    worldItems.Add(worldTileItem);
                }
            }
            
        }
    }
}
