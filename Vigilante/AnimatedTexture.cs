using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace Vigilante
{
	public class AnimatedTexture
	{
		ArrayList frames = new ArrayList();
		ArrayList files;
		int frame;

		public AnimatedTexture (ArrayList files)
		{
			this.files = files;
		}

		public void LoadContent (ContentManager content)
		{
			foreach (string file in files)
				frames.Add (content.Load<Texture2D>(file));
		}

		public void Animate ()
		{
			frame++;
		}

		public Texture2D GetFrame ()
		{
			return (Texture2D) frames[frame % frames.Count];
		}
	}
}