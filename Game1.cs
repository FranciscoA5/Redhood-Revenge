using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tdjgame
{
    enum Direction
    {
        Right,
        Left,
        Up,
        Stop,
        StopLeft,
        attack,

    }


    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public bool dead = false;
        //KeyboardState keyState = Keyboard.GetState(); 

        //player
        
        Texture2D hurt;
        Texture2D idle;
        Texture2D jump;
        Texture2D lightattack;
        Texture2D run;
        Texture2D runLeft;
        Texture2D idleLeft;

       
        Player2 player2 = new Player2();

        //wolf
        Texture2D wolfIdle;
        Texture2D wolfIdleLeft;
        Texture2D wolfRun;
        Texture2D wolfRunLeft;
        Texture2D wolfAttack;
        Texture2D wolfAttackLeft;
        Texture2D wolfDeath;
        Texture2D wolfDeathLeft;

        //Warewolf

        Warewolf warewolf = new Warewolf();
        Texture2D warewolfAttack;
        Texture2D warewolfAttackL;
        Texture2D warewolfDeath;
        Texture2D warewolfDeathL;
        Texture2D warewolfRun;
        Texture2D warewolfRunLeft;
        Texture2D warewolfShooting;

        //Background

        Backgroud backGround = new Backgroud();
        Backgroud backGround2 = new Backgroud();

        //Texture2D newBackGround;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 928;
            _graphics.PreferredBackBufferHeight = 793;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //player
            
            hurt = Content.Load<Texture2D>("Player/hurt");
            idle = Content.Load<Texture2D>("Player/idle");
            idleLeft = Content.Load<Texture2D>("Player/idleLeft");
            jump = Content.Load<Texture2D>("Player/jump");
            lightattack = Content.Load<Texture2D>("Player/lightattack");
            run = Content.Load<Texture2D>("Player/run");
            runLeft = Content.Load<Texture2D>("Player/runLeft");

            //player.animations[0] = new SpriteAnimation(idle, 18, 20);

            ////player.anim = player.animations[0];
            //player.playerAnimation = player.animations[0];

            player2.animations[0] = new SpriteAnimation(run, 24, 26);
            player2.animations[1] = new SpriteAnimation(runLeft, 24, 26);
            player2.animations[2] = new SpriteAnimation(jump, 19, 20);
            player2.animations[3] = new SpriteAnimation(idle, 18, 20);
            player2.animations[4] = new SpriteAnimation(idleLeft, 18, 20);

            player2.animations[5] = new SpriteAnimation(lightattack, 26, 30);


            //player2.animation = player2.animations[0];//podiamos igualar a quaçquer sprite , tinhamos de atribuir valor à animcao do jogador
            //wolf
            wolfIdle = Content.Load<Texture2D>("Wolf/idle");
            wolfIdleLeft = Content.Load<Texture2D>("Wolf/idleLeft");
            wolfRun = Content.Load<Texture2D>("Wolf/runLoop");
            wolfRunLeft = Content.Load<Texture2D>("Wolf/attackLeft2");
            wolfAttack = Content.Load<Texture2D>("Wolf/attack");
            // wolfAttackLeft = Content.Load<Texture2D>("Wolf/idle");
            wolfDeath = Content.Load<Texture2D>("Wolf/death");
            // wolfDdeathLeft = Content.Load<Texture2D>("Wolf/idle");

            Wolf.wolves.Add(new Wolf(new Vector2(200, 500), wolfIdle));
            Wolf.wolves[0].wolfAnimations[0] = new SpriteAnimation(wolfIdle, 6, 10);
            Wolf.wolves[0].wolfAnimations[1] = new SpriteAnimation(wolfIdleLeft, 6, 10);
            Wolf.wolves[0].wolfAnimations[2] = new SpriteAnimation(wolfRun, 8, 11);
            Wolf.wolves[0].wolfAnimations[3] = new SpriteAnimation(wolfRunLeft, 14, 16);
            Wolf.wolves[0].wolfAnimations[4] = new SpriteAnimation(wolfAttack, 22, 25);
            //Wolf.wolves[0].wolfAnimations[5] = new SpriteAnimation(wolfAttackLeft,22, 25);
            //Wolf.wolves[0].wolfAnimations[6] = new SpriteAnimation(wolfDeath, 6, 10);
            //Wolf.wolves[0].wolfAnimations[7] = new SpriteAnimation(wolfDeathLeft, 6, 10);


            warewolfAttack = Content.Load<Texture2D>("Warewolf/attack");
            warewolfAttackL = Content.Load<Texture2D>("Warewolf/attackLeft");
            warewolfDeath = Content.Load<Texture2D>("Warewolf/death");
            warewolfDeathL = Content.Load<Texture2D>("Warewolf/deathLeft");
            warewolfRun = Content.Load<Texture2D>("Warewolf/run");
            warewolfRunLeft = Content.Load<Texture2D>("Warewolf/runLeft");
            warewolfShooting = Content.Load<Texture2D>("Warewolf/shooting");

            warewolf.animations[0] = new SpriteAnimation(warewolfAttack, 7, 10);
            warewolf.animations[1] = new SpriteAnimation(warewolfAttackL, 7, 10);
            warewolf.animations[2] = new SpriteAnimation(warewolfDeath, 8, 11);
            warewolf.animations[3] = new SpriteAnimation(warewolfDeathL, 8, 11);
            warewolf.animations[4] = new SpriteAnimation(warewolfRun, 10, 20);
            warewolf.animations[5] = new SpriteAnimation(warewolfRunLeft, 10, 14);
            warewolf.animations[6] = new SpriteAnimation(warewolfShooting, 7, 9);

            //BackGround
            backGround.Scrolling(Content.Load<Texture2D>("BackGround/Background"), new Rectangle(0, 0, 928, 793));
            backGround2.Scrolling(Content.Load<Texture2D>("BackGround/Background"), new Rectangle(928, 0, 928, 793));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //player.Update(gameTime);
            player2.Update(gameTime);


            foreach (Wolf wolf in Wolf.wolves)
            {
                wolf.Update(gameTime, player2.Position,player2.dead);

                
                if (Vector2.Distance(player2.Position, wolf.Position) < 20)
                {
                    player2.dead = true;

                }

            }

            warewolf.Update(gameTime, player2.Position);

           
            
            if (backGround.rectangle.X + backGround.texture.Width <= 0)
            {
                backGround.rectangle.X = backGround2.rectangle.X + backGround2.texture.Width;
            }

            if (backGround2.rectangle.X + backGround2.texture.Width <= 0)
            {
                backGround2.rectangle.X = backGround.rectangle.X + backGround.texture.Width;
            }

            
            if (player2.Position.X > 464 && player2.kState.IsKeyDown(Keys.Right))
            {
                backGround.Update(3);
                backGround2.Update(3);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            backGround.Draw(_spriteBatch);
            backGround2.Draw(_spriteBatch);




            foreach (Wolf wolf in Wolf.wolves)
            {
                wolf.wolfAnimation.Draw(_spriteBatch);
            }

            if (!player2.dead)
            {   
                
                player2.animation.Draw(_spriteBatch);
            }
            

            warewolf.animation.Draw(_spriteBatch);



            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}


