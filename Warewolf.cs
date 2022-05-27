using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tdjgame
{
    class Warewolf 
    {
        enum Wareolfmovements
        {
            attack,
            attackLeft,
            death,
            deathLeft,
            run,
            runLeft,
            shooting,
        }

        private Vector2 position = new Vector2(500, 500); //private values só podem ser acedidos dentro da classe , temos de usar accessors 
        private int speed = 300;
        private Wareolfmovements wareolfmovements;


        public SpriteAnimation animation;
        public SpriteAnimation[] animations = new SpriteAnimation[7];

        

        public void Update(GameTime gametime , Vector2 playerPos)
        {
            Movement(gametime, playerPos);


        }

        public void Movement(GameTime gameTime , Vector2 playerPos)
        {
            
            


                Vector2 moveDirection = playerPos - position; //criamos um vetor que vai da posicao do inimigo ate a posicao do jogador
                float lenght = moveDirection.Length();
                if (lenght < 200)//precisamos do valor absoluto do vetor
                {
                    moveDirection.Normalize(); //normalizar um vetor mantêm a mesma direção mas reduz a magnitude/comprimeto para 1. So queremos a direcao , o comprimento do vetor nao interessa e assim nao fica tao grande
                    if (moveDirection.X > 0)
                    {
                        position.X += moveDirection.X;
                        wareolfmovements = Wareolfmovements.run;
                    }
                    else
                    {
                        position.X += moveDirection.X;
                        wareolfmovements = Wareolfmovements.runLeft;
                    }
                }

                else
                {
                    if (moveDirection.X > 0)
                    {
                        wareolfmovements = Wareolfmovements.shooting;
                    }

                    else
                    {
                        wareolfmovements = Wareolfmovements.shooting;
                    }
                }
                animation = animations[(int)wareolfmovements];
                animation.Position = position;
                animation.Update(gameTime);


            



        }

        


    }
}
