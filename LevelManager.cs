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
    class LevelManager
    {
        public int level = 3;

        Menu menu = new Menu();
        Player2 player2 = new Player2();
        Wolf wolf = new Wolf(new Vector2(100, 0));
        public Warewolf warewolf1 = new Warewolf();

        public SpriteFont gameFont;
        public Texture2D portal1;
        public Portal portal = new Portal();
        public bool loaded = false;
        public bool loaded2 = false;
        public bool loaded3 = false;


        public void Level1Unload(int playerLives, Vector2 portalPosition, Vector2 playerPosition, Game1 game)//ver se game
        {
            if (Vector2.Distance(portalPosition, playerPosition) <= 50 && level == 1)
            {

                game.Content.Unload();
                level = 2;

            }
            else if (playerLives == 0)
            {
                game.Content.Unload();

            }


        }


        public void Level2Load(Game1 game, Player2 player2)
        {
            //MySounds.bgSong = game.Content.Load<Song>("Sounds/nature");
            //MySounds.swordsound = game.Content.Load<SoundEffect>("sounds/swordsound");
            //MediaPlayer.Play(MySounds.bgSong);
            player2.setY(500);
            player2.loadPlayer(game);
            wolf.wolfLoad(game);

            player2.lives = 1;
            gameFont = game.Content.Load<SpriteFont>("Game/gameFont");
        }


        public void Level2Unload(Game1 game, Player2 player2, Vector2 portalPosition, Vector2 playerPosition)
        {
            if (Vector2.Distance(portalPosition, playerPosition) <= 50 && level == 2)
            {

                game.Content.Unload();
                level = 3;

            }
            else if (player2.lives == 0)
            {
                game.Content.Unload();

            }

        }

        public void Level3Load(Game1 game, Player2 player2)
        {
           //MySounds.bgSong = game.Content.Load<Song>("Sounds/nature");
           //MySounds.swordsound = game.Content.Load<SoundEffect>("sounds/swordsound");
           //MediaPlayer.Play(MySounds.bgSong);
            player2.lives = 3;
            player2.setY(500);
           // warewolf1.Update(gameTime, player2.Position);
            //warewolf1.LoadWarewolf(game);
            player2.loadPlayer(game);
            
           
            gameFont = game.Content.Load<SpriteFont>("Game/gameFont");
        }


        






        




    }
}
