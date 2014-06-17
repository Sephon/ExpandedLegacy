using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ExpandedLegacy.Classes
{
    partial class WorldItem
    {
        public Vector2 Position;
        public Texture2D Sprite;
        public Vector2 Size = Vector2.Zero;
        public Color Color = Color.White;

        public WorldItem() { }


        public WorldItem(Vector2 position, Texture2D sprite)
        {
            Position = position;
            Sprite = sprite;
        }

        public void SetColor(Color color)
        {
            Color = color;
        }
        
        public WorldItem(Vector2 position, Vector2 size, Texture2D sprite)
        {
            Position = position;
            Sprite = sprite;
            Size = size;
        }


        public Rectangle GetRectangle()
        {
            var useSizeX = this.Sprite.Height;
                var useSizeY = this.Sprite.Width;
                if (this.Size != Vector2.Zero)
                {
                    useSizeX = (int) this.Size.X;
                    useSizeY = (int )  this.Size.Y;
                }
            return new Rectangle((int) Position.X, (int) Position.Y, (int) useSizeX, (int) useSizeY);
        }

        public virtual void PerformActions()
        {
            
        }

        public virtual void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Position, GetRectangle(), Color);
        }
    }
}
