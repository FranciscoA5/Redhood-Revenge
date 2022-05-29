using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
namespace Tdjgame
{
    class Backgroud
    {
        public Texture2D texture;
        public Rectangle rectangle;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

        public void Scrolling(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            rectangle = newRectangle;
        }

        public void CreateBackGround(Player2 player2, Backgroud backGround, Backgroud backGround2)
        {
            if (player2.Position.X > 463 && player2.kStateOld.IsKeyDown(Keys.D)) //alterie kstate para kstateOld
            {

                if (backGround.rectangle.X + backGround.texture.Width <= 0)
                {
                    backGround.rectangle.X = backGround2.rectangle.X + backGround2.texture.Width;
                }

                if (backGround2.rectangle.X + backGround2.texture.Width <= 0)
                {
                    backGround2.rectangle.X = backGround.rectangle.X + backGround.texture.Width;
                }
                backGround.Update(3);
                backGround2.Update(3);
            }
        }

        public void Update(int speed)
        {
            rectangle.X -= speed;
        }
    }
}
