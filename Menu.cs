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
    class Menu
    {
        public Texture2D controls;
        public Texture2D quit;
        public Texture2D resume;
        public Texture2D start;

        public void LoadMenu(Game1 game)
        {
            controls = game.Content.Load<Texture2D>("Menu/Controls Button");
            quit = game.Content.Load<Texture2D>("Menu/Quit Button");
            resume = game.Content.Load<Texture2D>("Menu/Resume Button");
            start = game.Content.Load<Texture2D>("Menu/Start Button");
        }

        




        }
    }
