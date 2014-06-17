using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExpandedLegacy.Classes 
{
    class Player : Character
    {
        private const float DEFAULTSPEED = 1;
        private const float MAXSPEED = 15;
        private SpriteHandler spriteHandler;

        public Player(Vector2 position, Vector2 size, Texture2D sprite, Vector2 direction, float speed)
        {
            Sprite = sprite;
            Position = position;
            Direction = direction;
            Speed = speed;
            Size = size;
        }

        public void LoadSpriteHandler(SpriteHandler spriteHandler)
        {
            this.spriteHandler = spriteHandler;
        }

        private void handleModifiers()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if(Speed <= MAXSPEED) 
                    Speed *= 1.05f;
            } 
            else
            {
                if(Speed > DEFAULTSPEED)
                Speed *= 0.95f;
            }
        }

        public override void PerformActions()
        {
            handleModifiers();

            base.PerformActions();
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            spriteHandler.DrawSprite(this, spriteBatch, 1);
            //spriteBatch.Draw(Sprite, Position, GetRectangle(), Color);
        }
    }
}
