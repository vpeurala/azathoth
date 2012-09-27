using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Azathoth
{
	public class Terrain
	{
		Texture2D terrain;
		Texture2D carpet;

		public Terrain ()
		{
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			/*
			 * Terrain
			 */
			for (int y = 0; y < 3; y++) {
				for (int x = 0; x < 3; x++) {
					Rectangle rect = new Rectangle (x * 95, y * 95, 95, 95);
				
					spriteBatch.Draw (terrain, rect, Color.White);
				}
			}
			
			DrawSprite (spriteBatch, 1, 1, carpet);
		}
		
		private void DrawSprite (SpriteBatch spriteBatch, int x, int y, Texture2D sprite)
		{
			Rectangle rect = new Rectangle (x * 95, y * 95, 95, 95);
				
			spriteBatch.Draw (sprite, rect, Color.White);
		}

		public void LoadContent (ContentManager Content)
		{
			terrain = Content.Load<Texture2D> ("../../Textures/Terrain/floor.png");
			carpet  = Content.Load<Texture2D> ("../../Textures/Terrain/Carpet.png");
		}
	}
}