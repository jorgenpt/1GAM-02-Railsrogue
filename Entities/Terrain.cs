using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Railsrogue.Entities
{
	public class Terrain : Entity
	{
		public class Tile
		{
			public Texture2D texture;
			public float top;

			public Tile(Texture2D texture) {
				this.top = 400f;
				this.texture = texture;
			}
		}

		private LinkedList<Tile> tiles = new LinkedList<Tile>();
		private const int tileWidth = 64;
		private float firstTileX = 0f;
		private Texture2D tileTexture;

		public float screenWidth;
		public float leftX = 0f;

		public Terrain (float screenWidth)
		{
			this.screenWidth = screenWidth;
		}

		public void LoadContent (ContentManager content)
		{
			tileTexture = content.Load<Texture2D> ("tile");
		}

		public void Initialize () {
			int numTiles = (int)Math.Ceiling (screenWidth / (float)tileWidth);
			for (int i = 0; i < numTiles; ++i) {
				AddNewTile ();
			}
		}

		public void Update (GameTime gameTime)
		{
			if (tiles.Count < 1) {
				return;
			}

			while (leftX > firstTileX + tileWidth) {
				tiles.RemoveFirst();
				AddNewTile();
				firstTileX += tileWidth;
			}
		}

		private void AddNewTile ()
		{
			tiles.AddLast(new Tile(tileTexture));
		}

		public void Draw (SpriteBatch spriteBatch)
		{
			float x = firstTileX - leftX;
			foreach (Tile tile in tiles) {
				spriteBatch.Draw (tile.texture, new Vector2(x, tile.top), Color.White);
				x += tileWidth;
			}
		}
	}
}

