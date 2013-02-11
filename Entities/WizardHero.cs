using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Railsrogue.Entities
{
	public class WizardHero : Sprite
	{
		private ButtonState m_lastLeftButtonState = ButtonState.Released;

		public WizardHero (Vector2 position)
			: base ("hero")
		{
			Position = position;
		}

		public override void Update (GameTime gameTime)
		{
			MouseState mouseState = Mouse.GetState ();
			ButtonState leftButton = mouseState.LeftButton;
			if (leftButton != m_lastLeftButtonState) {
				m_lastLeftButtonState = leftButton;

				if (leftButton == ButtonState.Pressed) {
					Vector2 direction = Vector2.Subtract(new Vector2(mouseState.X, mouseState.Y), Position);
					Game.Add (new Fireball(Position, direction));
				}
			}

		}
	}
}

