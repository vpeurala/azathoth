using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Vigilante
{
	public class Map
	{
		Texture2D texture;

		public Map ()
		{
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			for (int y = 0; y < 2; y++) {
				for (int x = 0; x < 2; x++) {
					Rectangle rect = new Rectangle (x * 95, y * 95, 95, 95);
				
					spriteBatch.Draw (texture, rect, Color.White);
				}
			}
		}

		public void LoadContent (ContentManager Content)
		{
			texture = Content.Load<Texture2D> ("../../Textures/Terrain/floor.png");
		}
	}
}