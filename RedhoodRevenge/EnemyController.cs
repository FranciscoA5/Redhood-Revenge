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
    class EnemyController
    {

        public static double timer = 2D;
        public static double maxTime = 2D;

        public static void Update(GameTime gameTime , Texture2D spriteSheet)
        {
            //timer -= gameTime.ElapsedGameTime.TotalSeconds;

            if(timer > 0)
            {
                Wolf.wolves.Add(new Wolf(new Vector2(100,  100)));
                timer -= 1D;

                if(maxTime > 0.5)
                {
                    maxTime -= 0.05D;
                }


            }


        }



    }
}
