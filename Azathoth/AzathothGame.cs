using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Azathoth
{
	public class AzathothGame : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Terrain terrain;
		Player player;
		Song song;
		Map map;

		public AzathothGame ()
		{
			graphics = new GraphicsDeviceManager (this);
			terrain = new Terrain ();
			player = new Player ();
			map = new Map ();
		}
		
		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch (GraphicsDevice);
			
			terrain.LoadContent (Content);
			player.LoadContent (Content);
			map.LoadContent (Content);
			song = Content.Load<Song>("../../Songs/song.wav");
			MediaPlayer.Play (song);
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
			
			terrain.Draw (spriteBatch);

			map.DrawBefore (spriteBatch);

			player.Draw (spriteBatch);

			map.DrawAfter (spriteBatch);

			spriteBatch.End ();
			
			base.Draw (gameTime);
		}
	}
}