using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ExpandedLegacy.Classes
{
    class SpriteHandler
    {
        public Texture2D spriteMap;

        public SpriteHandler() { }
        
        public virtual void LoadSpriteMap(ContentManager content)
        {
            //spriteMap = content.Load<Texture2D>("Alundra");
        }

        public virtual void DrawSprite(Classes.WorldItem item, SpriteBatch spriteBatch, int animationState, MathTools.Angles.Angle eightDirectionAngle)
        {
            var sourceRect = new Rectangle(0, 0, 20, 20);
            spriteBatch.Draw(spriteMap, item.GetRectangle(), sourceRect, Color.White,  0f, new Vector2(0, 0), SpriteEffects.None, 0);
        }

        public virtual int GetAnimationUpperBound()
        {
            return 0;
        }
    }
}
