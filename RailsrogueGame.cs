#region File Description
//-----------------------------------------------------------------------------
// RailsrogueGame.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;


#endregion

#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

using Railsrogue.Entities;

#endregion

namespace Railsrogue
{
	/// <summary>
	/// Default Project Template
	/// </summary>
	public class RailsrogueGame : Game
	{
	#region Fields
		private static RailsrogueGame s_game = null;
		public static RailsrogueGame Game
		{
			get { return s_game; }
		}

		GraphicsDeviceManager m_graphics;
		SpriteBatch m_spriteBatch;

		public Terrain Terrain {
			get;
			set;
		}

		public WizardHero Hero {
			get;
			set;
		}

		public List<Entity> Entities {
			get;
			set;
		}
	#endregion

	#region Initialization

		public RailsrogueGame ()
		{
			s_game = this;
			Entities = new List<Entity>();

			IsMouseVisible = true;
			Content.RootDirectory = "Content";

			m_graphics = new GraphicsDeviceManager (this);
			m_graphics.IsFullScreen = false;
		}

		/// <summary>
		/// Overridden from the base Game.Initialize. Once the GraphicsDevice is setup,
		/// we'll use the viewport to initialize some values.
		/// </summary>
		protected override void Initialize ()
		{
			Entities.Add (Terrain = new Terrain (GraphicsDevice.Viewport.Width));
			Entities.Add (Hero = new WizardHero (new Vector2 (5, 398 - 128)));

			// Initialize calls LoadContent.
			base.Initialize ();

			foreach (Entity entity in Entities) {
				entity.Initialize ();
			}
		}


		/// <summary>
		/// Load your graphics content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be use to draw textures.
			m_spriteBatch = new SpriteBatch (m_graphics.GraphicsDevice);

			foreach (Entity entity in Entities) {
				entity.LoadContent (Content);
			}
		}

	#endregion

	#region Update and Draw

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			KeyboardState state = Keyboard.GetState ();
			Keys[] keys = state.GetPressedKeys ();
			foreach (Keys key in keys) {
				switch (key) {
				case Keys.Escape:
					Exit ();
					break;
				}
			}

			foreach (Entity entity in Entities) {
				entity.Update (gameTime);
			}

			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself. 
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			// Clear the backbuffer
			m_graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

			m_spriteBatch.Begin ();
			// TODO: Layers / ordering.
			foreach (Entity entity in Entities) {
				entity.Draw (m_spriteBatch);
			}
			m_spriteBatch.End ();

			base.Draw (gameTime);
		}

	#endregion
	}
}
