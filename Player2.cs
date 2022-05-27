using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tdjgame
{
    class Player2
    {
        private Vector2 position = new Vector2(500, 0); //private values só podem ser acedidos dentro da classe , temos de usar accessors 
        private int speed = 300;
        private Direction direction;
        private bool isMoving = false;
        private int directionVerify;
        public bool dead = false;


        private bool jumping = false; //Is the character jumping?
        private float jumpspeed = 0, startY = 500;


        public SpriteAnimation animation;
        public SpriteAnimation[] animations = new SpriteAnimation[6];

        private KeyboardState kStateOld = Keyboard.GetState();
        public KeyboardState kState = Keyboard.GetState();

        private int attackTime = 10;
        private bool attack = false;



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


            if (kState.IsKeyDown(Keys.Right))
            {
                direction = Direction.Right;
                directionVerify = 0;
                isMoving = true;
            }

            if (kState.IsKeyDown(Keys.Left))
            {
                direction = Direction.Left;
                directionVerify = 1;
                isMoving = true;
            }


            if (kState.IsKeyDown(Keys.Up))
            {
                direction = Direction.Up;
                isMoving = true;


            }

            if (kState.IsKeyDown(Keys.Space))
            {
                direction = Direction.attack;
                isMoving = true;
                attack = true;

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

                if (dead) //impedir o movimento do jogador se este morrer
                {
                    isMoving = false;
                }

                if (isMoving)
                {
                    switch (direction)
                    {
                        case Direction.Right:

                            position.X += speed * dt;
                            break;


                        case Direction.Left:

                            position.X -= speed * dt;
                            break;


                        case Direction.Up:



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



            }

           
            }











        }












