using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;

namespace Vigilante
{
	public class Player
	{
		AnimatedTexture front = new AnimatedTexture (
			new ArrayList { "../../Textures/Characters/kin1_fr1.png", "../../Textures/Characters/kin1_fr2.png" }
		);
		AnimatedTexture back = new AnimatedTexture (
			new ArrayList { "../../Textures/Characters/kin1_bk1.png", "../../Textures/Characters/kin1_bk2.png" }
		);
		AnimatedTexture left = new AnimatedTexture (
			new ArrayList { "../../Textures/Characters/kin1_lf1.png", "../../Textures/Characters/kin1_lf2.png" }
		);
		AnimatedTexture right = new AnimatedTexture (
			new ArrayList { "../../Textures/Characters/kin1_rt1.png", "../../Textures/Characters/kin1_rt2.png" }
		);
		AnimatedTexture texture;
	
		Vector2 direction = new Vector2();
		Vector2 position = new Vector2();
		float velocity;

		public Player ()
		{
			texture = front;
		}
		
		public void LoadContent (ContentManager content)
		{
			front.LoadContent (content);
			back.LoadContent (content);
			left.LoadContent (content);
			right.LoadContent (content);
		}
		
		public void Update ()
		{
			KeyboardState keyState = Keyboard.GetState ();
			if (keyState.IsKeyDown (Keys.Up)) {
				velocity = 2;
				direction.X = 0;
				direction.Y = -1;
				texture = back;
			} else if (keyState.IsKeyDown (Keys.Down)) {
				velocity = 2;
				direction.X = 0;
				direction.Y = 1;
				texture = front;
			} else if (keyState.IsKeyDown (Keys.Left)) {
				velocity = 2;
				direction.X = -1;
				direction.Y = 0;
				texture = left;
			} else if (keyState.IsKeyDown (Keys.Right)) {
				velocity = 2;
				direction.X = 1;
				direction.Y = 0;
				texture = right;
			} else {
				velocity = 0;
			}
		}
		
		public void Animate ()
		{
			if (velocity != 0)
				texture.Animate ();
		}

		public void Move ()
		{
			position += direction * velocity;
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			spriteBatch.Draw (texture.GetFrame (), new Rectangle ((int) position.X, (int) position.Y, 31, 31), Color.White);
		}
	}
}