using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
//using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.Media;
namespace Tdjgame
{
    enum Direction
    {
        Right,
        Left,
        Hurt,
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
        MouseState mState;
        bool mReleased = true;
        bool gameStart = false;
        int warewolfLife = 30;
        Random rand = new Random();




        Player2 player2 = new Player2();
        Wolf wolf = new Wolf(new Vector2(500, 500));
        Portal portal = new Portal();
        Menu menu = new Menu();
        LevelManager levelManager = new LevelManager();



        //Warewolf

        Warewolf warewolf = new Warewolf();
        

        //Background
        Backgroud backGround = new Backgroud();
        Backgroud backGround2 = new Backgroud();
        Backgroud backGround3 = new Backgroud();
        Backgroud backGround4 = new Backgroud();
        Backgroud backGround5 = new Backgroud();
        Backgroud backGround6 = new Backgroud();
        Backgroud backGroundStart = new Backgroud();

      

        //Game

        SpriteFont gameFont; //fonte da letra
        Texture2D wolfIcon;


        //Portal
        Texture2D portal1;

        public double timer = 30;


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



            gameFont = Content.Load<SpriteFont>("Game/gameFont");
            wolfIcon = Content.Load<Texture2D>("Game/wolfIcon");

            //player


            player2.loadPlayer(this);
            wolf.wolfLoad(this);
            menu.LoadMenu(this);



            //Portal
            portal1 = Content.Load<Texture2D>("Portal/portal3_spritesheet");
            portal.portalAnimation = new SpriteAnimation(portal1, 7, 10);
           

            //BackGround
            backGround.Scrolling(Content.Load<Texture2D>("BackGround/Background"), new Rectangle(0, 0, 928, 793));
            backGround2.Scrolling(Content.Load<Texture2D>("BackGround/Background"), new Rectangle(928, 0, 928, 793));

            //Song
           //MySounds.bgSong = Content.Load<Song>("Sounds/nature");
           //MediaPlayer.Play(MySounds.bgSong);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            player2.Update(gameTime);
            mState = Mouse.GetState();

            if (levelManager.level == 1)
            {
                if (levelManager.loaded2 == false)
                {
                    backGround.Scrolling(Content.Load<Texture2D>("BackGround/Background"), new Rectangle(0, 0, 928, 793));
                    backGround2.Scrolling(Content.Load<Texture2D>("BackGround/Background"), new Rectangle(928, 0, 928, 793));
                    levelManager.loaded2 = true;
                }
                backGround.CreateBackGround(player2, backGround, backGround2);
            }

            if (Wolf.wolves.Count == 0 || player2.lives == 0)
            {
                portal.position.X = 600;
                portal.position.Y = 695;
                levelManager.Level1Unload(player2.lives, portal.position, player2.Position, this);
            }

            if (levelManager.level == 2 && timer > 0 && levelManager.loaded == false)
            {
                portal1 = Content.Load<Texture2D>("Portal/portal3_spritesheet");
                portal.portalAnimation = new SpriteAnimation(portal1, 7, 10);
                portal.position.X = 0;
                portal.position.Y = 500;
                levelManager.Level2Load(this, player2);
                backGround3.Scrolling(Content.Load<Texture2D>("BackGround/background2"), new Rectangle(0, 0, 928, 793));
                backGround4.Scrolling(Content.Load<Texture2D>("BackGround/background2"), new Rectangle(928, 0, 928, 793));
                levelManager.loaded = true;
            }

            if (levelManager.level == 2)
            {
                backGround.CreateBackGround(player2, backGround3, backGround4);
                timer -= gameTime.ElapsedGameTime.TotalSeconds;
                if (Wolf.wolves.Count == 0 || player2.lives == 0)
                {
                    portal.position.X = 600;
                    portal.position.Y = 700;
      
                }
                levelManager.Level2Unload(this, player2 , portal.position , player2.Position);

            }

            if (levelManager.level == 3 && levelManager.loaded3 == false)
            {
                portal1 = Content.Load<Texture2D>("Portal/portal3_spritesheet");
                portal.portalAnimation = new SpriteAnimation(portal1, 7, 10);
                portal.position.X = 0;
                portal.position.Y = 500;
                levelManager.Level3Load(this, player2);
                warewolf.LoadWarewolf(this);
                backGround5.Scrolling(Content.Load<Texture2D>("BackGround/Background3"), new Rectangle(0, 0, 928, 793));
                backGround6.Scrolling(Content.Load<Texture2D>("BackGround/Background3"), new Rectangle(928, 0, 928, 793));
                levelManager.loaded3 = true;
            }

           
            if (levelManager.level == 3)
            {
                backGround.CreateBackGround(player2, backGround5, backGround6);
                if (Wolf.wolves.Count == 0 || player2.lives == 0)
                {
                    portal.position.X = 600;
                    portal.position.Y = 700;
                }
                //levelManager.Level2Unload(this, player2, portal.position, player2.Position);
            }


            for (int i = 0; i < Wolf.wolves.Count; i++)
            {
                Wolf.wolves[i].Update(gameTime, player2.Position, player2.lives);


                if (Vector2.Distance(player2.Position, Wolf.wolves[i].Position) < 20) // se colidir com o lobo leva dano
                {
                    player2.lives--;
                    if (player2.kStateOld.IsKeyDown(Keys.D))
                    {
                        player2.animation = player2.animations[2];
                        player2.setX(player2.Position.X - 80f);
                    }
                    else if (player2.kStateOld.IsKeyDown(Keys.A))
                    {
                        player2.setX(player2.Position.X + 80f);
                    }
                    else
                    {
                        player2.setX(player2.Position.X + 80f);
                    }

                }

                if (Vector2.Distance(player2.Position, Wolf.wolves[i].Position) < 25 && player2.kStateOld.IsKeyDown(Keys.Enter) && player2.lives != 0)
                {


                    Wolf.wolves.Remove(Wolf.wolves[i]);

                }




            }

            if (levelManager.level == 3)
            {
                if (Vector2.Distance(player2.Position, warewolf.Position) < 15) // se colidir com o lobisomem leva dano
                {
                    player2.lives--;
                    if (player2.kStateOld.IsKeyDown(Keys.D))
                    {
                        player2.animation = player2.animations[2];
                        player2.setX(player2.Position.X - 80f);
                    }
                    else if (player2.kStateOld.IsKeyDown(Keys.A))
                    {
                        player2.setX(player2.Position.X + 80f);
                    }
                    else
                    {
                        player2.setX(player2.Position.X + 80f);
                    }

                }

                if (Vector2.Distance(player2.Position, warewolf.Position) < 25 && player2.kStateOld.IsKeyDown(Keys.Enter) && player2.lives != 0)
                {
                    if(warewolfLife > 0)
                    {
                        warewolfLife -= rand.Next(5, 15);
                    }
                    


                }
            }

            portal.Update(gameTime);
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            if (levelManager.level == 1)
            {
                backGround.Draw(_spriteBatch);
                backGround2.Draw(_spriteBatch);
                _spriteBatch.DrawString(gameFont, "Wolf : " + (Wolf.wolves.Count).ToString(), new Vector2(0, 0), Color.White);
                _spriteBatch.DrawString(gameFont, "Lives : " + player2.lives.ToString(), new Vector2(0, 50), Color.White);
                if (Wolf.wolves.Count == 0)
                {
                    portal.portalAnimation.Draw(_spriteBatch);
                }
            }

            if (levelManager.level == 2)
            {
                backGround3.Draw(_spriteBatch);
                backGround4.Draw(_spriteBatch);
                _spriteBatch.DrawString(levelManager.gameFont, "Wolf : " + (Wolf.wolves.Count).ToString(), new Vector2(0, 0), Color.White); 
                _spriteBatch.DrawString(levelManager.gameFont, "Timer : " + Math.Floor(timer).ToString(), new Vector2(0, 50), Color.White);
                if (Wolf.wolves.Count == 0)
                {
                    portal.portalAnimation.Draw(_spriteBatch);
                }
            }

            if (levelManager.level == 3)
            {
                backGround5.Draw(_spriteBatch);
                backGround6.Draw(_spriteBatch);
                _spriteBatch.DrawString(levelManager.gameFont, "Life: " + player2.lives, new Vector2(0, 0), Color.White);
                _spriteBatch.DrawString(levelManager.gameFont, "Warewolf : " + warewolfLife, new Vector2(0, 50), Color.White);
                warewolf.Update(gameTime, player2.Position);
                if(warewolfLife > 0)
                {
                    warewolf.animation.Draw(_spriteBatch);
                }
                
            }

            foreach (Wolf wolf in Wolf.wolves)
            {
                wolf.wolfAnimation.Draw(_spriteBatch);
                
            }

            if (player2.lives > 0)
            {
                player2.animation.Draw(_spriteBatch);
            }

            //_spriteBatch.Draw(warewolfIdle, new Vector2(500, 500), Color.White);
            //warewolf.animation.Draw(_spriteBatch);

            if (player2.lives == 0 || timer <= 0)
            {
                menu.LoadMenu(this);
                _spriteBatch.Draw(menu.start, new Vector2(164, 96), Color.White);
                _spriteBatch.Draw(menu.controls, new Vector2(164, 300), Color.White);
                _spriteBatch.Draw(menu.quit, new Vector2(164, 504), Color.White);
            }

            if(warewolfLife < 0)
            {
                _spriteBatch.DrawString(gameFont, "Jogo Completado", new Vector2(928/2, 793/2), Color.White);


            }


            _spriteBatch.End();


            base.Draw(gameTime);
            }
        }
}


