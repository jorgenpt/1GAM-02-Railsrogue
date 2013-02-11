using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Railsrogue.Entities
{
	public abstract class Sprite : Entity
	{
		public string SpriteName {
			get; set;
		}

		public Texture2D SpriteTexture {
			get; set;
		}

		public Vector2 Position {
			get; set;
		}

		protected RailsrogueGame Game {
			get { return RailsrogueGame.Game; }
		}

		public Sprite (string spriteName)
		{
			SpriteName = spriteName;
			Position = Vector2.Zero;
		}

		public virtual void LoadContent(ContentManager content)
		{
			SpriteTexture = content.Load<Texture2D>(SpriteName);
		}

		public virtual void Draw (SpriteBatch batch)
		{
			Vector2 topLeft = Position;
			topLeft.X -= SpriteTexture.Width / 2f;
			topLeft.Y -= SpriteTexture.Height / 2f;

			batch.Draw (SpriteTexture, topLeft, Color.White);
		}

		public virtual void Initialize () {}
		public virtual void OnDestroy () {}

		public abstract void Update (GameTime gameTime);
	}
}

