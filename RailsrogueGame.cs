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
		bool m_enumeratingActiveSet;
		List<Entity> m_entities, m_addedEntities, m_removedEntities;

		public Terrain Terrain {
			get;
			set;
		}

		public WizardHero Hero {
			get;
			set;
		}

	#endregion

	#region Initialization

		public RailsrogueGame ()
		{
			s_game = this;
			m_entities = new List<Entity>();
			m_addedEntities = new List<Entity>();
			m_removedEntities = new List<Entity>();

			m_enumeratingActiveSet = false;

			IsMouseVisible = true;
			Content.RootDirectory = "Content";

			m_graphics = new GraphicsDeviceManager (this);
			m_graphics.IsFullScreen = false;
		}

		public void Add (Entity e)
		{
			if (m_enumeratingActiveSet) {
				m_addedEntities.Add (e);
			} else {
				e.LoadContent (Content);
				m_entities.Add (e);
				e.Initialize ();
			}
		}
		
		private void AddPendingEntities ()
		{
			foreach (Entity entity in m_addedEntities) {
				entity.LoadContent (Content);
			}
			m_entities.AddRange (m_addedEntities);
			
			foreach (Entity entity in m_addedEntities) {
				entity.Initialize ();
			}
			m_addedEntities.Clear ();
		}

		public void Remove (Entity e)
		{
			if (m_enumeratingActiveSet) {
				m_removedEntities.Add (e);
			} else {
				m_entities.Remove (e);
				e.OnDestroy ();
			}
		}

		private void RemovePendingEntities ()
		{
			foreach (Entity entity in m_removedEntities) {
				m_entities.Remove (entity);
				entity.OnDestroy ();
			}
			m_removedEntities.Clear ();
		}


		/// <summary>
		/// Overridden from the base Game.Initialize. Once the GraphicsDevice is setup,
		/// we'll use the viewport to initialize some values.
		/// </summary>
		protected override void Initialize ()
		{
			m_entities.Add (Terrain = new Terrain (GraphicsDevice.Viewport.Width));
			m_entities.Add (Hero = new WizardHero (new Vector2 (37, 398 - 64)));

			m_enumeratingActiveSet = true;
			// Initialize calls LoadContent.
			base.Initialize ();

			foreach (Entity entity in m_entities) {
				entity.Initialize ();
			}
			m_enumeratingActiveSet = false;
		}


		/// <summary>
		/// Load your graphics content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be use to draw textures.
			m_spriteBatch = new SpriteBatch (m_graphics.GraphicsDevice);

			foreach (Entity entity in m_entities) {
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

			m_enumeratingActiveSet = true;
			foreach (Entity entity in m_entities) {
				entity.Update (gameTime);
			}
			m_enumeratingActiveSet = false;

			RemovePendingEntities ();
			AddPendingEntities ();

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
			m_enumeratingActiveSet = true;
			foreach (Entity entity in m_entities) {
				entity.Draw (m_spriteBatch);
			}
			m_enumeratingActiveSet = false;
			m_spriteBatch.End ();

			base.Draw (gameTime);
		}

	#endregion
	}
}
