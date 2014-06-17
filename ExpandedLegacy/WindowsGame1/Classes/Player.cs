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
        private float ANIMATIONCHANGE_BASEINTERVAL_MS = 200;
        private float ANIMATIONCHANGE_INTERVAL_MS = 200;
        private int ANIMATION_WRAP_COUNT = 0; // Zero-based
        private double currentFrameTimeElapsed = 0;
        private SpriteHandler spriteHandler;
        private int currentAnimationState = 0;

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
            ANIMATION_WRAP_COUNT = spriteHandler.GetAnimationUpperBound();
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

            ANIMATIONCHANGE_INTERVAL_MS = ANIMATIONCHANGE_BASEINTERVAL_MS / Speed;
        }

        private void updateAnimationState(GameTime gameTime)
        {
            if (CurrentAction == Enum.Actions.MoveState.Standing)
            {
                // Just go with the still animation and abort
                currentAnimationState = 0;
                return;
            }
            
            currentFrameTimeElapsed += gameTime.ElapsedGameTime.TotalMilliseconds;

            if(currentFrameTimeElapsed >= ANIMATIONCHANGE_INTERVAL_MS)
            {
                currentFrameTimeElapsed = 0;

                if(currentAnimationState < ANIMATION_WRAP_COUNT)
                    currentAnimationState++;
                else
                    currentAnimationState = 0;
            }
        }

        public override void PerformActions(GameTime gameTime, Vector2 leftMouseClickPosition)
        {
            handleModifiers();
            updateAnimationState(gameTime);

            base.PerformActions(gameTime, leftMouseClickPosition);
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            spriteHandler.DrawSprite(this, spriteBatch, currentAnimationState, CurrentAngle);
            //spriteBatch.Draw(Sprite, Position, GetRectangle(), Color);
        }
    }
}
