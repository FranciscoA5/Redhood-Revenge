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
    class Wolf 
    {
        enum Wolfmovements{
            idle,
            idleLeft,
            run,
            runLeft,
            attack,
            attackLeft,
            
        }

        public static List<Wolf> wolves = new List<Wolf>();

        private Vector2 position = new Vector2(100,  0);
        private int speed = 150;
        public SpriteAnimation wolfAnimation;
        public SpriteAnimation[] wolfAnimations = new SpriteAnimation[6];
        //public Array[] wolf = new Array[8];
        private Wolfmovements wolfMovements;
        static Random rand = new Random();
        private double spawTime = rand.Next(1,  10);
        GameTime gameTime = new GameTime();

        //wolf
        Texture2D wolfIdle;
        Texture2D wolfIdleLeft;
        Texture2D wolfRun;
        Texture2D wolfRunLeft;
        Texture2D wolfAttack;
        Texture2D wolfAttackLeft;
       



        public Wolf(Vector2 newPos ) 
        {
            position = newPos;
            

        }

        public Vector2 Position
        {
            get {return position ;}

        }

        public void Update(GameTime gameTime , Vector2 playerPos , int playerLives)
        {
            Movement(gameTime, playerPos, playerLives);
           
        }


        public void Movement(GameTime gameTime, Vector2 playerPos, int playerLives)
        {
            if (playerLives!=0 )
            {


                Vector2 moveDirection = playerPos - position; //criamos um vetor que vai da posicao do inimigo ate a posicao do jogador
                float lenght = moveDirection.Length();
                if (lenght < 10000)//precisamos do valor absoluto do vetor
                {
                    moveDirection.Normalize(); //normalizar um vetor mantêm a mesma direção mas reduz a magnitude/comprimeto para 1. So queremos a direcao , o comprimento do vetor nao interessa e assim nao fica tao grande
                    if (moveDirection.X > 0)
                    {
                        position.X += moveDirection.X;
                        wolfMovements = Wolfmovements.run;
                       if (lenght < 100)
                       {
                           wolfMovements = Wolfmovements.attack;
                       
                       }

                    }
                    else
                    {
                        position.X += moveDirection.X;
                        wolfMovements = Wolfmovements.runLeft;
                        if (lenght < 100)
                        {
                            wolfMovements = Wolfmovements.attackLeft;

                        }
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


        public void wolfLoad(Game1 game )
        {

            wolfIdle = game.Content.Load<Texture2D>("Wolf/idle");
            wolfIdleLeft = game.Content.Load<Texture2D>("Wolf/idleLeft");
            wolfRun = game.Content.Load<Texture2D>("Wolf/runLoop");
            wolfRunLeft = game.Content.Load<Texture2D>("Wolf/runLoopLeft");
            wolfAttack = game.Content.Load<Texture2D>("Wolf/attack1");
            wolfAttackLeft = game.Content.Load<Texture2D>("Wolf/attackLeft");

            wolves.Add(new Wolf(new Vector2(rand.Next(-500, -50), 677)));

            //for(int i = 0; i<rand.Next(10,15); i++)
            //{   
            //  wolves.Add(new Wolf(new Vector2(rand.Next(-500,-50), 668)));
            //  wolves.Add(new Wolf(new Vector2(rand.Next(1200, 2000),668)));
            //}


            for (int i = 0; i < Wolf.wolves.Count; i++)
            {

                wolves[i].wolfAnimations[0] = new SpriteAnimation(wolfIdle, 6, 10);
                wolves[i].wolfAnimations[1] = new SpriteAnimation(wolfIdleLeft, 6, 10);
                wolves[i].wolfAnimations[2] = new SpriteAnimation(wolfRun, 8, 11);
                wolves[i].wolfAnimations[3] = new SpriteAnimation(wolfRunLeft, 8, 11);
                wolves[i].wolfAnimations[4] = new SpriteAnimation(wolfAttack, 14, 16);
                wolves[i].wolfAnimations[5] = new SpriteAnimation(wolfAttackLeft, 14, 16);
               
            }






        }



    }
}
