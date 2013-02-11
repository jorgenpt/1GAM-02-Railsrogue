using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Railsrogue.Entities
{
	public interface Entity
	{
		void Initialize();
		void LoadContent(ContentManager content);

		void Draw (SpriteBatch batch);
		void Update (GameTime gameTime);

		void OnDestroy ();
	}
}

