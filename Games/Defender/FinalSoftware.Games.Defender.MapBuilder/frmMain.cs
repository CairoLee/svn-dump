using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace FinalSoftware.Games.Defender.MapBuilder {

	public partial class frmMain : Form {
		public const int GRID_SIZE = 20;

		private Bitmap mBackground = null;
		private List<Point> mSpots = new List<Point>();
		private bool mMouseDown = false;


		public frmMain() {
			InitializeComponent();
		}


		#region menuMain Editor
		private void menuMainProgramClose_Click(object sender, EventArgs e) {
			Close();
		}
		#endregion

		#region menuMain Map
		private void menuMainMapBackground_Click(object sender, EventArgs e) {
			string filepath = "";
			using (OpenFileDialog dlg = new OpenFileDialog()) {
				dlg.Filter = "Images (*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
				if (dlg.ShowDialog(this) != DialogResult.OK) {
					return;
				}

				filepath = dlg.FileName;
			}

			ResetMap(filepath);
		}
		#endregion

		#region menuMain About
		private void menuMainAbout_Click(object sender, EventArgs e) {

		}
		#endregion


		#region imageBackground Events
		private void imageBackground_MouseClick(object sender, MouseEventArgs e) {
			bool right = e.Button == System.Windows.Forms.MouseButtons.Right;
			AddSpot(e.X, e.Y, right);
		}

		private void imageBackground_MouseDown(object sender, MouseEventArgs e) {
			mMouseDown = true;
		}

		private void imageBackground_MouseUp(object sender, MouseEventArgs e) {
			mMouseDown = false;
		}

		private void imageBackground_MouseMove(object sender, MouseEventArgs e) {
			if (mMouseDown) {
				AddSpot(e.X, e.Y, false);
			}
		}
		#endregion


		/// <summary>
		/// Clears all spots, draws a fresh grid on the loaded image and refreshs the control
		/// </summary>
		/// <param name="filepath"></param>
		private void ResetMap(string filepath) {
			// Clear spots
			mSpots.Clear();

			// Load image
			mBackground = (Bitmap)Bitmap.FromFile(filepath);
			// Draw grid
			Bitmap bmp = (Bitmap)mBackground.Clone();
			bmp.DrawGrid(GRID_SIZE, Color.Black);

			// Update image
			imageBackground.Image = bmp;
			imageBackground.Size = bmp.Size;
			imageBackground.Refresh();
		}

		/// <summary>
		/// Refreshs the map taking a fresh copy form background image and redraws all spots
		/// </summary>
		private void RedrawMap() {
			// Take image fresh from background
			Bitmap bmp = (Bitmap)mBackground.Clone();
			// Add grid
			bmp.DrawGrid(GRID_SIZE, Color.Black);
			imageBackground.Image = bmp;

			// Only add them to the map, dont refresh
			foreach (Point p in mSpots) {
				AddSpotMap(p, false);
			}
			// Refresh the control after draw
			imageBackground.Refresh();
		}

		/// <summary>
		/// Adds a spot to the internal array and draws them on the map
		/// </summary>
		/// <param name="posX"></param>
		/// <param name="posY"></param>
		/// <param name="remove"></param>
		private void AddSpot(int posX, int posY, bool remove) {
			// Valid?
			if (mBackground == null || posX < 0 || posY < 0 || posX >= mBackground.Width || posY >= mBackground.Height) {
				return;
			}

			// Create point based of grid size
			Point p = new Point((posX / GRID_SIZE) * GRID_SIZE, (posY / GRID_SIZE) * GRID_SIZE);
			if (AddSpotInternal(p, remove) == false) {
				return;
			}
			AddSpotMap(p);
		}

		/// <summary>
		/// Adds a spot to the internal array
		/// </summary>
		/// <param name="p"></param>
		/// <param name="remove"></param>
		private bool AddSpotInternal(Point p, bool remove) {
			if (mSpots.Contains(p)) {
				if (remove) {
					mSpots.Remove(p);
				}
				RedrawMap();

				// Return false because no redraw needed
				return false;
			}

			mSpots.Add(p);

			return true;
		}

		/// <summary>
		/// Draws a spot to the map and refresh the control
		/// </summary>
		/// <param name="p"></param>
		private void AddSpotMap(Point p) {
			AddSpotMap(p, true);
		}

		/// <summary>
		/// Draws a spot to the map and refresh the control, if given
		/// </summary>
		/// <param name="p"></param>
		/// <param name="refresh"></param>
		private void AddSpotMap(Point p, bool refresh) {
			Bitmap bmp = (Bitmap)imageBackground.Image;

			for (int x = p.X + 1; x < (p.X + GRID_SIZE); x++) {
				for (int y = p.Y + 1; y < (p.Y + GRID_SIZE); y++) {
					bmp.SetPixel(x, y, Color.Black);
				}
			}

			imageBackground.Image = bmp;
			// Prevent flicker on multi update
			if (refresh) {
				imageBackground.Refresh();
			}
		}

		private void imageBackground_Resize(object sender, EventArgs e) {
			// Resize panelBackground to trigger AutoScroll feature
			//panelBackground.Width = imageBackground.Width;
			//panelBackground.Height = imageBackground.Height;
		}

	}

}

