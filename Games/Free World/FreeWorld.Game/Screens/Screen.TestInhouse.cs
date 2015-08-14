using System;
using System.Diagnostics;
using FreeWorld.Engine;
using FreeWorld.Engine.Tools;
using FreeWorld.Game.Tests.Tmx;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FreeWorld.Game.Screens {

	public class ScreenTestInhouse : GameScreen {
		protected TmxMap mMap;
		protected Texture2D mGridTexture;

		// Saves the last event state to ensure not to trigger the move-on-door twice
		// Otherwise we would interpret the second move on the door as the move out of the house
		protected string mLastMapEvent = string.Empty;

		public ScreenTestInhouse() {
			Name = "ScreenTestInhouse";
			InputHandle = true;
		}


		/// <exception cref="Exception">Failed to load interface</exception>
		public override void LoadContent() {
			base.LoadContent();

			mMap = new TmxMap("Tests/Tmx/Maps/test-inhouse.tmx");
			mGridTexture = DrawHelper.Rect2Texture(ScreenManager.GameCamera.TileWidth, ScreenManager.GameCamera.TileHeight, 1, Color.White);
		}


		public override void Update(GameTime gameTime) {
			base.Update(gameTime);

			// Update objects
		}

		public override void HandleInput(GameTime gameTime) {
			base.HandleInput(gameTime);

			// Handle me
			if (WasKeyPressed(Keys.Left)) {
				ScreenManager.GameCamera.X++;
			}
			if (WasKeyPressed(Keys.Right)) {
				ScreenManager.GameCamera.X--;
			}
			if (WasKeyPressed(Keys.Up)) {
				ScreenManager.GameCamera.Y++;
			}
			if (WasKeyPressed(Keys.Down)) {
				ScreenManager.GameCamera.Y--;
			}

			// We clicked on a cell and emulate a move to this cell
			if (WasLeftMouseButtonDown) {
				TryHandleFakeMapMoveEvent();
			}
		}

		public override void Draw(GameTime gameTime) {
			// Draw tmx map test
			mMap.Draw(SpriteBatch, gameTime, ScreenManager.GameCamera);

			// Draw cursor aligned on grid
			var tilePos = GetMousePositionOnMap();
			var mousePos = new Point2D(tilePos.X * mMap.TileWidth, tilePos.Y * mMap.TileHeight);
			var rectDest = new Rectangle(mousePos.X, mousePos.Y, ScreenManager.GameCamera.TileWidth, ScreenManager.GameCamera.TileHeight);
			SpriteBatch.Draw(mGridTexture, rectDest, Color.Red);

			base.Draw(gameTime);
		}


		protected Point2D GetMousePositionOnMap(bool includeCameraOffset = false) {
			var pos = new Point2D(CurrentMouseState.X / ScreenManager.GameCamera.TileWidth, CurrentMouseState.Y / ScreenManager.GameCamera.TileHeight);
			// Apply camera offset (offset is negativ)
			if (includeCameraOffset) {
				pos.X += ScreenManager.GameCamera.Position.X * -1;
				pos.Y += ScreenManager.GameCamera.Position.Y * -1;
			}
			return pos;
		}

		private void TryHandleFakeMapMoveEvent() {
			// Get map tile position (including camera offset)
			var tilePos = GetMousePositionOnMap(true);
			// Any events (stored as objects) available?
			if (mMap.ObjectGroups.Count == 0) {
				return;
			}

			// The layer we want to hide
			// @TODO: Later we should just hide a specific area of the roof layer! This is set on width/height properties
			var roofLayer = mMap.Layers["Roof"];
			// We have to check for walking out of the roof and door 
			var walkedOutOfRoofEvents = true;

			var mousePos = new Point2D(tilePos.X * mMap.TileWidth, tilePos.Y * mMap.TileHeight);
			foreach (var objectGroup in mMap.ObjectGroups) {
				var objects = objectGroup.GetObjectsByPosition(mousePos);
				if (objects.Count == 0) {
					continue;
				}

				foreach (var eventObject in objects) {

					// @TODO: Fancy opacity transitions

					// We walked before the door
					if (eventObject.Type == "Before Door") {
						walkedOutOfRoofEvents = false;
						// Possible states.. (2)
						// 1: We walked on the before-door tile and didnt have a last-event => half-trans the roof
						// 2: We walked from the door on the before-door tile => make roof full visible
						// @EDIT: Think about it - everytime we visit the before-door tile, we have to half-trans!
						
						roofLayer.Opacity = 0.5d;
						// @TODO: temp-change the door to a open door
						

						// Store last event
						mLastMapEvent = eventObject.Type;
					}
					// We walked on the door
					if (eventObject.Type == "Door") {
						walkedOutOfRoofEvents = false;
						// Possible states.. (2)
						// 1: Move from before-door onto the door => full-trans the roof
						// 2: Move from the roof-tile onto the door => half-trans the roof
						//    ^- wrong! half-trans is done by before-door only; we have to always full-trans the roof!
						roofLayer.Opacity = 0;
						
						// Store last event
						mLastMapEvent = eventObject.Type;
					}
					// Ensure roof is invisible while walking on the roof
					if (eventObject.Type == "Roof") {
						walkedOutOfRoofEvents = false;
						roofLayer.Opacity = 0d;

						// Store last event
						mLastMapEvent = eventObject.Type;
					}

					// Lil debug
					Debug.WriteLine("Event triggered: {0} [{1}]; Opacity = {2}", eventObject.Name, eventObject.Type, mMap.Layers["Roof"].Opacity);
				}

			}

			// Walked out of the roof?
			// Note: Triggers only if didnt raise a roof-like event
			if (walkedOutOfRoofEvents) {
				// Make roof full visible again
				roofLayer.Opacity = 1d;
				// Clear last event state
				mLastMapEvent = string.Empty;
			}
		}

	}

}
