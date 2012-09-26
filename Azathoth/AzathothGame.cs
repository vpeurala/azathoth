using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Azathoth
{
	public class AzathothGame : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Player player;
		Map map;

		public AzathothGame ()
		{
			graphics = new GraphicsDeviceManager (this);
			player = new Player ();
			map = new Map ();
		}
		
		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch (GraphicsDevice);
			
			player.LoadContent (Content);
			map.LoadContent (Content);
		}
		
		double timePerFrame = 1.0 / 8.0;
		double totalElapsed;
		double timePerFrame2 = 1.0 / 60.0;
		double totalElapsed2;
		
		protected override void Update (GameTime gameTime)
		{
			player.Update ();
			totalElapsed += gameTime.ElapsedGameTime.TotalSeconds;
			totalElapsed2 += gameTime.ElapsedGameTime.TotalSeconds;
			
			if (totalElapsed > timePerFrame) {
				player.Animate ();
				totalElapsed -= timePerFrame;
			}

			if (totalElapsed2 > timePerFrame2) {
				player.Move ();
				totalElapsed2 -= timePerFrame2;
			}
		}
		
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.Black);
			
			spriteBatch.Begin ();
			
			map.Draw (spriteBatch);

			player.Draw (spriteBatch);

			spriteBatch.End ();
			
			base.Draw (gameTime);
		}
	}
}