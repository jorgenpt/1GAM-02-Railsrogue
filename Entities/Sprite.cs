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
			batch.Draw (SpriteTexture, Position, Color.White);
		}

		public virtual void Initialize () {}
		public abstract void Update (GameTime gameTime);
	}
}

