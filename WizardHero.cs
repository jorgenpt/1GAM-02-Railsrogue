using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Railsrogue
{
	public class WizardHero
	{
		public WizardHero ()
		{
		}

		private Vector2 position;

		public void LoadContent (ContentManager content)
		{
			Texture = content.Load<Texture2D> ("tile");
		}
		
		public void Update (GameTime gameTime)
		{
		}
	}
}

