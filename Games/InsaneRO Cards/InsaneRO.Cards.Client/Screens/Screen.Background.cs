using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WindowLibrary.Controls;

namespace InsaneRO.Cards.Client.Screens {

	public class ScreenBackground : GameScreen {

		public ScreenBackground( GameClient game )
			: base( game ) {
			Name = "Background";
			IsActive = true;
			InputHandle = false;
		}


		public override void Initialize() {
			base.Initialize();

			ScreenManager.MainWindow = new Window( WindowManager );
			ScreenManager.MainWindow.Init();
			ScreenManager.MainWindow.Text = "InsaneRO Card Game - © 2010 by InsaneRO | Developed by Fischy, Jecky & GodLesZ";
			ScreenManager.MainWindow.Width = Game.GraphicsDevice.Viewport.Width;
			ScreenManager.MainWindow.Height = Game.GraphicsDevice.Viewport.Height;
			ScreenManager.MainWindow.Center();
			ScreenManager.MainWindow.CloseButtonVisible = true;
			ScreenManager.MainWindow.Resizable = false;
			ScreenManager.MainWindow.Movable = false;
			ScreenManager.MainWindow.Shadow = false;
			ScreenManager.MainWindow.Visible = true;
			ScreenManager.MainWindow.MouseDown += new MouseEventHandler( win_MouseDown );
			ScreenManager.MainWindow.MouseUp += new MouseEventHandler( win_MouseUp );
			ScreenManager.MainWindow.MouseMove += new MouseEventHandler( win_MouseMove );
			ScreenManager.MainWindow.Closing += delegate( object sender, WindowClosingEventArgs e ) {
				Game.Exit();
			};

			WindowManager.Add( ScreenManager.MainWindow );
		}


		#region fake Dragging
		private bool mDrag = false;
		private Point mDragStart;
		private System.Drawing.Point mOldLocation;
		private void win_MouseDown( object sender, MouseEventArgs e ) {
			mDrag = true;
			mDragStart = e.Position;
			mOldLocation = Game.FormHandle.Location;
		}

		private void win_MouseUp( object sender, MouseEventArgs e ) {
			mDrag = false;
		}

		private void win_MouseMove( object sender, MouseEventArgs e ) {
			if( mDrag == false || GameClient.GraphicsManager.IsFullScreen == true )
				return;

			Point pointDif = new Point( e.Position.X - mDragStart.X, e.Position.Y - mDragStart.Y );
			Game.FormHandle.Location = new System.Drawing.Point( mOldLocation.X + pointDif.X, mOldLocation.Y + pointDif.Y );
		}
		#endregion

	}

}
