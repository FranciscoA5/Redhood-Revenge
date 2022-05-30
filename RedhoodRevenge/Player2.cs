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
    class Player2
    {
        private Vector2 position = new Vector2(0,665); //private values só podem ser acedidos dentro da classe , temos de usar accessors 
        private int speed = 150;
        private Direction direction;
        private bool isMoving = false;
        private int directionVerify;
        public int lives = 3;


        private bool jumping = false; //Is the character jumping?
        private float jumpspeed = 0, startY = 665;


        public SpriteAnimation animation;
        public SpriteAnimation[] animations = new SpriteAnimation[6];

        public KeyboardState kStateOld = Keyboard.GetState();
      
        private double attackTime = 10;
        private bool attack = false;

        //player

        Texture2D hurt;
        Texture2D idle;
        Texture2D jump;
        Texture2D lightattack;
        Texture2D run;
        Texture2D runLeft;
        Texture2D idleLeft;


        public Vector2 Position //fazer um setter para um Vector2 é um bocado mais complexo , no exemplo usamos int
        {
            get { return position; }

        }

        public void setX(float newX)//setter para mudar a posicao X
        {
            position.X = newX;

        }


        public void setY(float newY)//setter para mudar a posicao Y
        {
            position.Y = newY;

        }

        public void Update(GameTime gameTime)
        {
            KeyboardState kState = Keyboard.GetState();

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            isMoving = false;


            if (kState.IsKeyDown(Keys.D))
            {
                direction = Direction.Right;
                directionVerify = 0;
                isMoving = true;
            }

            if (kState.IsKeyDown(Keys.A))
            {
                direction = Direction.Left;
                directionVerify = 1;
                isMoving = true;
            }



            if (kState.IsKeyDown(Keys.Enter))
            {
                //MySounds.swordsound.Play();
                for(int i =0; i<20; i++)
                {
                    direction = Direction.attack;
                    isMoving = true;

                }
               

                
             
            }

                if (jumping)
                {
                    position.Y += jumpspeed;//Making it go up
                    jumpspeed += 1;//Some math (explained later)
                    if (position.Y >= startY)
                    //If it's farther than ground
                    {
                        position.Y = startY;//Then set it on
                        jumping = false;
                    }
                }
                else
                {
                    if (kState.IsKeyDown(Keys.W))
                    {
                        jumping = true;
                        jumpspeed = -14;//Give it upward thrust


                    }
                }

                if (lives == 0) //impedir o movimento do jogador se este morrer
                {
                    isMoving = false;
                }

            if (isMoving)
            {
                switch (direction)
                {
                    case Direction.Right:

                        if(position.X < 880) //impede que passe o ecrã à direita
                        {
                            position.X += speed * dt;
                            

                        }

                        break;

                    case Direction.Left:
                        
                        if (position.X > -40)
                        {
                            position.X -= speed * dt;
                            
                        }
                        break;

                    case Direction.attack:
                         
                        


                        

                        //position.Y -= speed * dt;




                        break;

                }

            }
            else
            {

                if (kState.IsKeyUp(Keys.Right) && directionVerify == 0)
                {
                    direction = Direction.Stop;
                }
                if (kState.IsKeyUp(Keys.Left) && directionVerify == 1)
                {
                    direction = Direction.StopLeft;
                }

            }
                
               
             
            animation = animations[(int)direction];
            animation.Position = position;//a posicao da animacao nao estava centrada com a do jogador , por isso se faz isto
            animation.Update(gameTime);

               
                kStateOld = kState;

        }


        public void loadPlayer(Game1 game)
        {
            hurt = game.Content.Load<Texture2D>("Player/hurt");
            idle = game.Content.Load<Texture2D>("Player/idle");
            idleLeft = game.Content.Load<Texture2D>("Player/idleLeft");
            lightattack = game.Content.Load<Texture2D>("Player/lightattack");
            run = game.Content.Load<Texture2D>("Player/run");
            runLeft = game.Content.Load<Texture2D>("Player/runLeft");

            animations[0] = new SpriteAnimation(run, 24, 26);
            animations[1] = new SpriteAnimation(runLeft, 24, 26);
            animations[2] = new SpriteAnimation(hurt, 7, 10);
            animations[3] = new SpriteAnimation(idle, 18, 20);
            animations[4] = new SpriteAnimation(idleLeft, 18, 20);
            animations[5] = new SpriteAnimation(lightattack, 26, 30);


        }








    }










}












