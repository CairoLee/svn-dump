using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PacMan.Editor {

	public partial class frmMain : Form {
		private static Color COLOR_WALL = Color.Transparent;
		private static Color COLOR_PATH = Color.Blue;
		private static Color COLOR_BASE = Color.Fuchsia;

		private bool mMouseDown = false;
		private Bitmap mBmp;
		private int mBlockWidth = 20;
		private int mBlockHeight = 20;
		private Color mCurrentColor;
		private int[,] mGrid;

		public frmMain() {
			InitializeComponent();
		}


		private void Form1_Load(object sender, EventArgs e) {
			CreateGrid();
		}


		private void menuProgramNewLevel_Click(object sender, EventArgs e) {
			CreateGrid();
		}

		private void menuProgramClose_Click(object sender, EventArgs e) {
			Close();
		}


		private void imageEditor_MouseClick(object sender, MouseEventArgs e) {
			DrawBlock(e.X, e.Y, mCurrentColor);
		}

		private void imageEditor_MouseDown(object sender, MouseEventArgs e) {
			mMouseDown = true;
		}

		private void imageEditor_MouseUp(object sender, MouseEventArgs e) {
			mMouseDown = false;
		}

		private void imageEditor_MouseMove(object sender, MouseEventArgs e) {
			if (mMouseDown == true) {
				DrawBlock(e.X, e.Y, mCurrentColor);
			}
		}


		private void btnWall_Click(object sender, EventArgs e) {
			mCurrentColor = COLOR_WALL;
			lblPath.BackColor = lblHomeBase.BackColor = Color.Transparent;
			lblWall.BackColor = Color.ForestGreen;
		}

		private void btnPath_Click(object sender, EventArgs e) {
			mCurrentColor = COLOR_PATH;
			lblWall.BackColor = lblHomeBase.BackColor = Color.Transparent;
			lblPath.BackColor = Color.ForestGreen;

		}

		private void btnHomeBase_Click(object sender, EventArgs e) {
			mCurrentColor = COLOR_BASE;
			lblPath.BackColor = lblWall.BackColor = Color.Transparent;
			lblHomeBase.BackColor = Color.ForestGreen;

		}


		private void btnSave_Click(object sender, EventArgs e) {
			string filepath = "";
			using (SaveFileDialog dlg = new SaveFileDialog()) {
				dlg.Filter = "Text-Datei|*.txt";
				if (dlg.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) {
					return;
				}

				filepath = dlg.FileName;
			}

			using (StreamWriter writer = new StreamWriter(File.OpenWrite(filepath))) {
				string line = "";
				for (int y = 0; y < mGrid.GetLength(1); y++) {
					line = "";
					for (int x = 0; x < mGrid.GetLength(0); x++) {
						line += mGrid[x, y] + " ";
					}
					writer.WriteLine(line);
				}
			}
		}


		private void DrawBlock(int posX, int posY, Color color) {
			if (posX < 0 || posY < 0 || posX >= mBmp.Width || posY >= mBmp.Height) {
				return;
			}

			int realX = (posX / mBlockWidth);
			int realY = (posY / mBlockHeight);
			int blockX = realX * mBlockWidth;
			int blockY = realY * mBlockHeight;

			for (int x = blockX + 1; x < (blockX + mBlockWidth); x++) {
				for (int y = blockY + 1; y < (blockY + mBlockHeight); y++) {
					mBmp.SetPixel(x, y, mCurrentColor);
				}
			}

			if (mCurrentColor == COLOR_WALL) {
				mGrid[realX, realY] = 0;
			} else if (mCurrentColor == COLOR_PATH) {
				mGrid[realX, realY] = 1;
			} else if (mCurrentColor == COLOR_BASE) {
				mGrid[realX, realY] = 2;
			}

			imageEditor.Refresh();
		}

		private void CreateGrid() {
			mBmp = new Bitmap(600, 600);
			for (int y = 0; y < mBmp.Height; y += mBlockHeight) {
				for (int x = 0; x < mBmp.Width; x++) {
					mBmp.SetPixel(x, y, Color.Black);
				}
			}
			for (int x = 0; x < mBmp.Width; x += mBlockWidth) {
				for (int y = 0; y < mBmp.Height; y++) {
					mBmp.SetPixel(x, y, Color.Black);
				}
			}

			mGrid = new int[mBmp.Width / mBlockWidth, mBmp.Height / mBlockHeight];

			imageEditor.Image = mBmp;

			btnWall.PerformClick();
		}

	}

}
