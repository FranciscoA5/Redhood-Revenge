using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.Media;
namespace Tdjgame
{
    class Portal
    {
        public  Vector2 position = new Vector2(500, 0);
        public  SpriteAnimation portalAnimation;

        public void Update(GameTime gameTime)
        {
            portalAnimation.Position = position;
            portalAnimation.Update(gameTime);
        }

      



    }
}
