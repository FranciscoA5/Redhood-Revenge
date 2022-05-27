using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tdjgame
{
    class Wolf 
    {
        enum Wolfmovements{
            idle,
            idleLeft,
            run,
            runLeft,
            attack,
            attackLeft,
            death,
            deathLeft,
        }

        public static List<Wolf> wolves = new List<Wolf>();

        private Vector2 position = new Vector2(100,  0);
        private int speed = 150;
        public SpriteAnimation wolfAnimation;
        public SpriteAnimation[] wolfAnimations = new SpriteAnimation[8];
        //public Array[] wolf = new Array[8];
        private Wolfmovements wolfMovements;
       

        public Wolf(Vector2 newPos , Texture2D spriteSheet) 
        {
            position = newPos;
            wolfAnimation = new SpriteAnimation(spriteSheet,  6,  5);

        }

        public Vector2 Position
        {
            get {return position ;}

        }

        public void Update(GameTime gameTime , Vector2 playerPos , bool playerDead)
        {
            Movement(gameTime, playerPos,  playerDead);
           
        }


        public void Movement(GameTime gameTime, Vector2 playerPos, bool playerDead)
        {
            if (!playerDead)
            {


                Vector2 moveDirection = playerPos - position; //criamos um vetor que vai da posicao do inimigo ate a posicao do jogador
                float lenght = moveDirection.Length();
                if (lenght < 200)//precisamos do valor absoluto do vetor
                {
                    moveDirection.Normalize(); //normalizar um vetor mantêm a mesma direção mas reduz a magnitude/comprimeto para 1. So queremos a direcao , o comprimento do vetor nao interessa e assim nao fica tao grande
                    if (moveDirection.X > 0)
                    {
                        position.X += moveDirection.X;
                        wolfMovements = Wolfmovements.run;
                    }
                    else
                    {
                        position.X += moveDirection.X;
                        wolfMovements = Wolfmovements.runLeft;
                    }
                }

                else
                {
                    if (moveDirection.X > 0)
                    {
                        wolfMovements = Wolfmovements.idle;
                    }

                    else
                    {
                        wolfMovements = Wolfmovements.idleLeft;
                    }
                }
                wolfAnimation = wolfAnimations[(int)wolfMovements];
                wolfAnimation.Position = position;
                wolfAnimation.Update(gameTime);

            }

        }






    }
}
