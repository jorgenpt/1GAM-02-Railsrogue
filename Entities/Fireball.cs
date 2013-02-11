using System;
using Microsoft.Xna.Framework;

namespace Railsrogue.Entities
{
	public class Fireball : Sprite
	{
		private const double c_lifespan = 3f;
		private const float c_speed = 300f;

		private Vector2 m_direction;
		private double m_lifespan;

		public Fireball (Vector2 position, Vector2 direction)
			: base("fireball")
		{
			Position = position;
			m_direction = direction;
			m_direction.Normalize();
			m_lifespan = c_lifespan;
		}

		public override void Update (GameTime gameTime)
		{
			float distance = (float)(c_speed * gameTime.ElapsedGameTime.TotalSeconds);
			Position += Vector2.Multiply (m_direction, distance);

			m_lifespan -= gameTime.ElapsedGameTime.TotalSeconds;
			if (m_lifespan < 0) {
				Game.Remove (this);
			}
		}
	}
}

