using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GodLesZ.Library.XNA.WindowLibrary.Controls;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.GamerServices;

namespace GodLesZ.Library.XNA.WindowLibrary.Central {

	public class Central : Application {
		public static long Frames = 0;

		private int mAvgFps = 0;
		private int mFps = 0;
		private double mEllapsedTime = 0;


		public Central()
			: base(true) {
			Manager.SkinDirectory = @"Content\Skins\";
			Manager.Content.UseArchive = false;
			SystemBorder = false;
			FullScreenBorder = false;
			ClearBackground = false;
			ExitConfirmation = false;
			Manager.TargetFrames = 60;
		}


		protected override void Initialize() {
			base.Initialize();
		}

		protected override Window CreateMainWindow() {
			return new MainWindow(Manager);
		}

		protected override void LoadContent() {
			base.LoadContent();
		}

		protected override void Update(GameTime gameTime) {
			base.Update(gameTime);
			UpdateStats(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			Frames += 1;
			base.Draw(gameTime);
		}

		private void UpdateStats(GameTime time) {
			MainWindow wnd = MainWindow as MainWindow;
			// Update in a cycle of 500ms
			if (mEllapsedTime >= 500 || mEllapsedTime == 0) {
				if (wnd != null) {
					wnd.lblObjects.Text = "Objects: " + Disposable.Count.ToString();
					wnd.lblAvgFps.Text = "Average FPS: " + mAvgFps.ToString();
					wnd.lblFps.Text = "Current FPS: " + mFps.ToString();
				}

				if (time.TotalGameTime.TotalSeconds != 0) {
					mAvgFps = (int)(Frames / time.TotalGameTime.TotalSeconds);
				}

				if (time.ElapsedGameTime.TotalMilliseconds != 0) {
					mFps = (int)(1000 / time.ElapsedGameTime.TotalMilliseconds);
				}

				mEllapsedTime = 1;
			}
			mEllapsedTime += time.ElapsedGameTime.TotalMilliseconds;
		}

	}

}