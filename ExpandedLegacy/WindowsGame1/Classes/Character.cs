using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExpandedLegacy.Classes
{
    class Character : WorldItem
    {
        public Vector2 Direction;
        public float Speed;

        public Character() { }

        public Character(Vector2 position, Vector2 size, Texture2D sprite, Vector2 direction, float speed)
        {
            Sprite = sprite;
            Position = position;
            Direction = direction;
            Speed = speed;
            Size = size;
        }

        public void Move() 
        {
            if (Direction != Vector2.Zero)
            {
                Direction.Normalize();
            }
            
            Position += Direction * Speed;
        }

        private void ModifyDirection()
        {
            Direction.X = Mouse.GetState().X - Position.X;
            Direction.Y = Mouse.GetState().Y - Position.Y;
        }

        public override void PerformActions()
        {
            ModifyDirection();
            Move();

            base.PerformActions();
        }

        public void SetSpeed(float speed)
        {
            Speed = speed;
        }
    }
}
