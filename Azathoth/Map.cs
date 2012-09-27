using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Azathoth
{
	public class Map
	{
		Texture2D wallBottom;
		Texture2D wallRight;
		Texture2D wallLeft;
		Texture2D wallTop;

		public Map ()
		{
		}

		public void DrawBefore (SpriteBatch spriteBatch)
		{
			for (int x = 0; x < 3; x++) {
				int y = 0;
				Rectangle rect = new Rectangle (x * 95, y * 95, 95, 95);
				spriteBatch.Draw (wallTop, rect, Color.White);
			}
		}

		public void DrawAfter (SpriteBatch spriteBatch)
		{
			for (int y = 0; y < 3; y++) {
				int x = 0;
				Rectangle rect = new Rectangle (x * 95, y * 95, 95, 95);
				spriteBatch.Draw (wallLeft, rect, Color.White);
			}
			for (int y = 0; y < 3; y++) {
				int x = 2;
				Rectangle rect = new Rectangle (x * 95, y * 95, 95, 95);
				spriteBatch.Draw (wallRight, rect, Color.White);
			}
			for (int x = 0; x < 3; x++) {
				int y = 2;
				Rectangle rect = new Rectangle (x * 95, y * 95, 95, 95);
				spriteBatch.Draw (wallBottom, rect, Color.White);
			}
		}

		public void LoadContent (ContentManager Content)
		{
			wallLeft   = Content.Load<Texture2D> ("../../Textures/Walls/Wall_left.png");
			wallRight  = Content.Load<Texture2D> ("../../Textures/Walls/Wall_right.png");
			wallTop    = Content.Load<Texture2D> ("../../Textures/Walls/Wall_top.png");
			wallBottom = Content.Load<Texture2D> ("../../Textures/Walls/Wall_bottom.png");
		}
	}
}