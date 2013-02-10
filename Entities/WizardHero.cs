using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Railsrogue.Entities
{
	public class WizardHero : Sprite
	{
		public WizardHero (Vector2 position)
			: base ("hero")
		{
			Position = position;
		}

		public override void Update (GameTime gameTime)
		{
			//MouseState mouseState = Mouse.GetState();

		}
	}
}

