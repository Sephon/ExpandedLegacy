using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ExpandedLegacy.Loaders
{
    class ComposeAlundraSprites : Classes.SpriteHandler
    {
        public ComposeAlundraSprites(ContentManager content)
        {
            spriteMap = content.Load<Texture2D>("Alundra");
        }

        public override void DrawSprite(Classes.WorldItem item, SpriteBatch spriteBatch, int state)
        {
            switch(state)
            {
                case 1:
                    var sourceRect = new Rectangle(110,887,25,41);
                    var targetRect = new Rectangle((int)item.Position.X, (int) item.Position.Y, 25, 41);
                    spriteBatch.Draw(spriteMap, targetRect, sourceRect, Color.White, 0f, new Vector2(0,0), SpriteEffects.None, 0);
                    break;
            }              
        }

        Color[] GetImageData(Color[] colorData, int width, Rectangle rectangle)
        {
            Color[] color = new Color[rectangle.Width * rectangle.Height];
            for (int x = 0; x < rectangle.Width; x++)
                for (int y = 0; y < rectangle.Height; y++)
                    color[x + y * rectangle.Width] = colorData[x + rectangle.X + (y + rectangle.Y) * width];
            return color;
        }
    }
}
