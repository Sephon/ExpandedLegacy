using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ExpandedLegacy.Loaders
{
    class Preload
    {
        public Preload(ContentManager content, List<Classes.WorldItem> worldItems)
        {
            AddTiles(content, worldItems);

            var item1 = new Classes.Player(new Vector2(100f, 100f), new Vector2(11f, 11f), content.Load<Texture2D>("pixel"), new Vector2(0, 0), 1.0f);
            item1.LoadSpriteHandler(new AlundraSpriteHandler(content));
            item1.SetColor(Color.Black);
            worldItems.Add(item1);
        }

        private void AddTiles(ContentManager content, List<Classes.WorldItem> worldItems)
        {
            for (int xTiles = 0; xTiles < 10; xTiles++)
            {
                for (int yTiles = 0; yTiles < 10;yTiles++ )
                {
                    var tile = content.Load<Texture2D>("grassmini");
                    var position = new Vector2(xTiles * tile.Width, yTiles * tile.Height);
                    var worldTileItem = new Classes.WorldItem(position, tile);
                    worldItems.Add(worldTileItem);
                }
            }           
        }
    }
}
