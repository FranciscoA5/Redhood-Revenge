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
    class Warewolf
    {
        enum Wareolfmovements
        {
            attack,
            attackLeft,
            run,
            runLeft,
        }

        private Vector2 position = new Vector2(960, 665); //private values só podem ser acedidos dentro da classe , temos de usar accessors 
        private int speed = 300;
        private Wareolfmovements wareolfmovements;


        public SpriteAnimation animation;
        public SpriteAnimation[] animations = new SpriteAnimation[4];

        Texture2D warewolfAttack;
        Texture2D warewolfAttackL;
        Texture2D warewolfRun;
        Texture2D warewolfRunLeft;

        public void Update(GameTime gametime, Vector2 playerPos)
        {
            Movement(gametime, playerPos);


        }

        public Vector2 Position //fazer um setter para um Vector2 é um bocado mais complexo , no exemplo usamos int
        {
            get { return position; }

        }

        public void Movement(GameTime gameTime, Vector2 playerPos)
        {

            Vector2 moveDirection = playerPos - position; //criamos um vetor que vai da posicao do inimigo ate a posicao do jogador
            float lenght = moveDirection.Length();
            if (lenght < 10000)//precisamos do valor absoluto do vetor
            {
                moveDirection.Normalize(); //normalizar um vetor mantêm a mesma direção mas reduz a magnitude/comprimeto para 1. So queremos a direcao , o comprimento do vetor nao interessa e assim nao fica tao grande
                if (moveDirection.X > 0)
                {
                    position.X += moveDirection.X;
                    wareolfmovements = Wareolfmovements.run;
                    if (lenght < 100)
                    {
                        wareolfmovements = Wareolfmovements.attack;

                    }
                }

                else
                {
                    position.X += moveDirection.X;
                    wareolfmovements = Wareolfmovements.runLeft;
                    if (lenght < 100)
                    {
                        wareolfmovements = Wareolfmovements.attackLeft;

                    }
                }
                animation = animations[(int)wareolfmovements];
                animation.Position = position;
                animation.Update(gameTime);

            }
        }

        public void LoadWarewolf(Game1 game)
        {
            warewolfAttack = game.Content.Load<Texture2D>("Warewolf/attack");
            warewolfAttackL = game.Content.Load<Texture2D>("Warewolf/attackLeft");
            warewolfRun = game.Content.Load<Texture2D>("Warewolf/run");
            warewolfRunLeft = game.Content.Load<Texture2D>("Warewolf/runLeft");
            animations[0] = new SpriteAnimation(warewolfAttack, 3, 5);
            animations[1] = new SpriteAnimation(warewolfAttackL, 3, 5);
            animations[2] = new SpriteAnimation(warewolfRun, 4, 6);
            animations[3] = new SpriteAnimation(warewolfRunLeft, 4, 6);
        }
    }
}
