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
        private Checkpoints _checkpoints = new Checkpoints();
        public MathTools.Angles.Angle CurrentAngle;
        public Enum.Actions.MoveState CurrentAction;

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
            var nextCheckpoint = _checkpoints.GetNextCheckpoint(this);
            if (nextCheckpoint == null)
            {
                Direction.X = 0;
                Direction.Y = 0;
                CurrentAction = Enum.Actions.MoveState.Standing;
                return;
            }

            CurrentAction = Enum.Actions.MoveState.Walking;
            CurrentAngle = MathTools.Angles.GetAngleDescription(MathTools.Angles.GetAngle(this.Position, nextCheckpoint.Position));
            Direction.X = nextCheckpoint.Position.X - Position.X;
            Direction.Y = nextCheckpoint.Position.Y - Position.Y;
        }

        private void HandleEvents(Vector2 leftMouseClickedPosition)
        {
            if(leftMouseClickedPosition != Vector2.Zero)
                _checkpoints.AddCheckpoint(leftMouseClickedPosition);
        }

        public override void PerformActions(GameTime gameTime, Vector2 leftMouseClickPosition)
        {
            HandleEvents(leftMouseClickPosition);
            ModifyDirection();
            Move();

            base.PerformActions(gameTime, leftMouseClickPosition);
        }

        public void SetSpeed(float speed)
        {
            Speed = speed;
        }
    }
}
