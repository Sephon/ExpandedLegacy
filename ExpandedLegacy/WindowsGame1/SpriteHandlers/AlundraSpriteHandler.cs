using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ExpandedLegacy.Loaders
{
    class AlundraSpriteHandler : Classes.SpriteHandler
    {
        private Dictionary<MathTools.Angles.Angle, Dictionary<int, Rectangle>> spriteMapRectangles = new Dictionary<MathTools.Angles.Angle,Dictionary<int,Rectangle>>();
        private int _maxNumberOfFrames = 0;

        public AlundraSpriteHandler(ContentManager content)
        {
            spriteMap = content.Load<Texture2D>("Alundra");

            PopulateSprites();
        }

        private void PopulateSprites()
        {
            var animationCount = 0;
            AddSpriteMapRectangle(MathTools.Angles.Angle.North, animationCount, new Rectangle(212, 891, 21, 36));
            AddSpriteMapRectangle(MathTools.Angles.Angle.NorthEast, animationCount, new Rectangle(313, 889, 22, 37));
            AddSpriteMapRectangle(MathTools.Angles.Angle.East, animationCount, new Rectangle(313, 889, 22, 37));
            AddSpriteMapRectangle(MathTools.Angles.Angle.SouthEast, animationCount, new Rectangle(313, 889, 22, 37));
            AddSpriteMapRectangle(MathTools.Angles.Angle.South, animationCount, new Rectangle(110, 887, 25, 41));
            AddSpriteMapRectangle(MathTools.Angles.Angle.SouthWest, animationCount, new Rectangle(20, 888, 18, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.West, animationCount, new Rectangle(20, 888, 18, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.NorthWest, animationCount, new Rectangle(20, 888, 18, 38));

            animationCount++;
            AddSpriteMapRectangle(MathTools.Angles.Angle.North, animationCount, new Rectangle(235, 889, 22, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.NorthEast, animationCount, new Rectangle(336, 888, 18, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.East, animationCount, new Rectangle(336, 888, 18, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.SouthEast, animationCount, new Rectangle(336, 888, 18, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.South, animationCount, new Rectangle(136, 889, 22, 39));
            AddSpriteMapRectangle(MathTools.Angles.Angle.SouthWest, animationCount, new Rectangle(39, 888, 22, 37));
            AddSpriteMapRectangle(MathTools.Angles.Angle.West, animationCount, new Rectangle(39, 888, 22, 37));
            AddSpriteMapRectangle(MathTools.Angles.Angle.NorthWest, animationCount, new Rectangle(39, 888, 22, 37));

            animationCount++;
            AddSpriteMapRectangle(MathTools.Angles.Angle.North, animationCount, new Rectangle(259, 891, 21, 36));
            AddSpriteMapRectangle(MathTools.Angles.Angle.NorthEast, animationCount, new Rectangle(355, 889, 24, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.East, animationCount, new Rectangle(355, 889, 24, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.SouthEast, animationCount, new Rectangle(355, 889, 24, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.South, animationCount, new Rectangle(159, 888, 22, 40));
            AddSpriteMapRectangle(MathTools.Angles.Angle.SouthWest, animationCount, new Rectangle(62, 888, 18, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.West, animationCount, new Rectangle(62, 888, 18, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.NorthWest, animationCount, new Rectangle(62, 888, 18, 38));

            animationCount++;
            AddSpriteMapRectangle(MathTools.Angles.Angle.North, animationCount, new Rectangle(283, 889, 22, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.NorthEast, animationCount, new Rectangle(380, 888, 18, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.East, animationCount, new Rectangle(380, 888, 18, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.SouthEast, animationCount, new Rectangle(380, 888, 18, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.South, animationCount, new Rectangle(182, 889, 22, 39));
            AddSpriteMapRectangle(MathTools.Angles.Angle.SouthWest, animationCount, new Rectangle(81, 889, 24, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.West, animationCount, new Rectangle(81, 889, 24, 38));
            AddSpriteMapRectangle(MathTools.Angles.Angle.NorthWest, animationCount, new Rectangle(81, 889, 24, 38));
        }

        public override int GetAnimationUpperBound()
        {
            return _maxNumberOfFrames;
        }

        private void AddSpriteMapRectangle(MathTools.Angles.Angle angle, int animationFrame, Rectangle rectangle)
        {
            if(!spriteMapRectangles.ContainsKey(angle))
            {
                var animationDic = new Dictionary<int, Rectangle>();
                animationDic.Add(animationFrame, rectangle);
                spriteMapRectangles.Add(angle, animationDic);
            }
            if(!spriteMapRectangles[angle].ContainsKey(animationFrame))
            {
                var animationDic = spriteMapRectangles[angle];
                animationDic.Add(animationFrame, rectangle);
            }

            _maxNumberOfFrames = Math.Max(_maxNumberOfFrames, animationFrame);
        }

        public Rectangle GetSourceRectangle(int animationState, MathTools.Angles.Angle angle)
        {
            return new Rectangle(0, 0, 0, 0);
        }

        public override void DrawSprite(Classes.WorldItem item, SpriteBatch spriteBatch, int animationState, MathTools.Angles.Angle eightDirectionAngle)
        {
            var sourceRect = spriteMapRectangles[eightDirectionAngle][animationState];
            var targetRect = new Rectangle((int)item.Position.X, (int) item.Position.Y, sourceRect.Width, sourceRect.Height);

            spriteBatch.Draw(spriteMap, targetRect, sourceRect, Color.White, 0f, new Vector2(0,0), SpriteEffects.None, 0);            
        }
    }
}
