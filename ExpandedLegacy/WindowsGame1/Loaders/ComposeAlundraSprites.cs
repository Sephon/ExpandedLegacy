using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1.Loaders
{
    class ComposeAlundraSprites
    {
        Texture2D spriteMap;

        public ComposeAlundraSprites(ContentManager content)
        {
            spriteMap = content.Load<Texture2D>("Alundra");
        }   
     
        public void ReadDefaultSprite()
        {
            
        }
    }
}
