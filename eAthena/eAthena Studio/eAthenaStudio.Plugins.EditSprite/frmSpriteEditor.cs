using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Library.Ragnarok.Sprite;
using eAthenaStudio.Library.Plugin;
using eAthenaStudio.Plugins.EditSprite.Controls;

namespace eAthenaStudio.Plugins.EditSprite {

	public sealed partial class frmSpriteEditor : frmPluginPage {
		private RoSprite mSprite;
		private int mSelectedImage = -1;
		private Color mSelectedPaletteColor = Color.Transparent;
		private PaletteColor mOldPaletteColor = null;
		private readonly FrameWindow mWndSprite;
		private readonly PaletteWindow mWndPalette;


		public frmSpriteEditor(PluginBase plugin, List<string> pluginArgs)
			: base(plugin, pluginArgs) {
			InitializeComponent();

			mWndSprite = new FrameWindow {
				RightToLeftLayout = RightToLeftLayout,
				AllowDrop = true
			};
			mWndSprite.DragEnter += frmSpriteEditor_DragEnter;
			mWndSprite.DragDrop += frmSpriteEditor_DragDrop;
			mWndPalette = new PaletteWindow {
				RightToLeftLayout = RightToLeftLayout
			};

			if (MenuPaletteColorHighlight.ColorComboBox.SelectedIndex == 1)
				MenuPaletteColorHighlight.ColorComboBox.SelectedIndex = 0;
			MenuPaletteColorHighlight.ColorComboBox.SelectedIndex = 1;
			MouseWheel += new MouseEventHandler(frmSpriteEditor_MouseWheel);

			if (pluginArgs != null && pluginArgs.Count > 0) {
				ParsePluginArgs(pluginArgs);
			}
		}


		#region frmSpriteEditor Events
		private void frmSpriteEditor_Load(object sender, EventArgs e) {
			mWndSprite.Show(dockPanel);
			mWndPalette.Show(dockPanel);
		}

		private void frmSpriteEditor_MouseWheel(object sender, MouseEventArgs e) {
			if (e.Location.X < mWndSprite.Location.X || e.Location.X > (mWndSprite.Location.X + mWndSprite.Width))
				return;
			if (e.Location.Y < mWndSprite.Location.Y || e.Location.Y > (mWndSprite.Location.Y + mWndSprite.Height))
				return;
			mWndSprite.OnMouseScroll(e);
			mWndSprite.SetStatusZoom(mWndSprite.Zoom.ToString("0.0"));
		}

		private void frmSpriteEditor_Resize(object sender, EventArgs e) {
			mWndSprite.DoResize();
		}
		#endregion

		#region MenuEditor Events
		private void MenuEditorClose_Click(object sender, EventArgs e) {
			Close();
		}
		#endregion

		#region MenuSprite Events
		private void MenuSpriteOpen_Click(object sender, EventArgs e) {
			SetControls(OpenSprite());
		}

		private void MenuSpriteSave_Click(object sender, EventArgs e) {
			using (SaveFileDialog dlg = new SaveFileDialog()) {
				dlg.Filter = "Ragnarok Sprite (*.spr)|*.spr";
				dlg.InitialDirectory = Path.GetDirectoryName(mSprite.Filepath);
				if (dlg.ShowDialog(this) != DialogResult.OK)
					return;

				mSprite.Write(dlg.FileName, true);
			}
		}

		private void MenuSpriteExtract_Click(object sender, EventArgs e) {
			using (frmSpriteExtract frm = new frmSpriteExtract(mSprite.Images.Count)) {
				if (frm.ShowDialog(this) != DialogResult.OK)
					return;
				string filePath = frm.ExtractPath;
				int[] frames = frm.GetCheckedFrames();
				bool trans = frm.Transparency;
				frm.Close();

				string newDir = filePath;
				if (frames.Length > 1) { // append filename as new dir
					//newDir = Path.Combine( filePath, Path.GetFileNameWithoutExtension( mSprite.Filepath ) );
					// TODO: clean filname; may contain ebil chars
					newDir = Path.Combine(filePath, "Sprite_extract");
				}

				Library.SafeIo.CreateFolder(newDir);
				for (int i = 0; i < frames.Length; i++)
					ExtractFrame(newDir, frames[i], trans);
			}
		}

		private void MenuSpriteFrameAdd_Click(object sender, EventArgs e) {
			using (frmSpriteFrameAdd frm = new frmSpriteFrameAdd(mSprite)) {
				if (frm.ShowDialog(this) != DialogResult.OK)
					return;

				mSprite.AddImagePal(frm.NewImage as Bitmap, frm.NewImagePosition);
				SetControls(SetImage(mSelectedImage)); // refresh
			}

		}

		private void MenuSpriteFrameDel_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Willst du die aktuelle Frame wirklich löschen?", "Frame " + (mSelectedImage + 1) + " löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			mSprite.RemoveImage(mSelectedImage);
			int newIndex = mSelectedImage;
			if (newIndex >= mSprite.Images.Count)
				newIndex = 0;

			SetControls(SetImage(newIndex));
		}
		#endregion

		#region MenuPalette Events
		private void MenuPaletteRestore_Click(object sender, EventArgs e) {
			if (mSprite.Palette.PaletteChanged == false)
				mSprite.ResetImages();
			else {
				mSprite.Read(mSprite.Filepath);
				mWndSprite.SpriteControl.BackColor = mSprite.Palette[0];
				InitializePalette();
			}
			SetImage(mSelectedImage); // force redraw
		}

		private void MenuPaletteImport_Click(object sender, EventArgs e) {
			using (OpenFileDialog dlg = new OpenFileDialog()) {
				dlg.Filter = "Ragnarok Palette (*.pal)|*.pal";
				dlg.InitialDirectory = Path.GetDirectoryName(mSprite.Filepath);
				if (dlg.ShowDialog(this) != DialogResult.OK)
					return;

				mSprite.Palette.ApplyPalette(dlg.FileName);
				InitializePalette();
				mSprite.ResetImages();
				SetImage(mSelectedImage); // force redraw
			}
		}

		private void MenuPaletteExport_Click(object sender, EventArgs e) {
			using (SaveFileDialog dlg = new SaveFileDialog()) {
				dlg.Filter = "Ragnarok Palette (*.pal)|*.pal";
				dlg.InitialDirectory = Path.GetDirectoryName(mSprite.Filepath);
				if (dlg.ShowDialog(this) != DialogResult.OK)
					return;

				mSprite.Palette.CreateColorChart(20, dlg.FileName);
			}
		}

		private void MenuPaletteChart_Click(object sender, EventArgs e) {
			using (SaveFileDialog dlg = new SaveFileDialog()) {
				dlg.Filter = "PNG Bild (*.png)|*.png";
				dlg.InitialDirectory = Path.GetDirectoryName(mSprite.Filepath);
				if (dlg.ShowDialog(this) != DialogResult.OK)
					return;

				mSprite.Palette.CreateColorChart(20, dlg.FileName);
			}
		}

		private void MenuPaletteColorHighlight_SelectedColorChanged(object sender, EventArgs e) {
			Color col = MenuPaletteColorHighlight.SelectedColor;
			mWndSprite.HoverColor = col;
			if (mWndSprite.SpriteImage != null)
				mWndSprite.Invalidate();
			mWndSprite.Focus();
		}
		#endregion

		#region Drag & Drop Events
		private void frmSpriteEditor_DragEnter(object sender, DragEventArgs e) {
			string[] formats = e.Data.GetFormats();
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Move;
			else
				e.Effect = DragDropEffects.None;
		}

		private void frmSpriteEditor_DragDrop(object sender, DragEventArgs e) {
			if (!e.Data.GetDataPresent(DataFormats.FileDrop)) {
				return;
			}

			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files != null && files.Length > 0) {
				foreach (string filepath in files) {
					OpenSprite(filepath, false);
				}
			}
		}
		#endregion

		#region ToolSprite Events
		private void ToolSpriteOpen_Click(object sender, EventArgs e) {
			SetControls(OpenSprite());
		}

		private void ToolSpriteSave_Click(object sender, EventArgs e) {
			using (SaveFileDialog dlg = new SaveFileDialog()) {
				dlg.Filter = "Ragnarok Sprite (*.spr)|*.spr";
				dlg.InitialDirectory = Path.GetDirectoryName(mSprite.Filepath);
				if (dlg.ShowDialog(this) != DialogResult.OK)
					return;

				mSprite.Write(dlg.FileName, true);
			}
		}
		#endregion

		#region ToolFrame Events
		private void ToolFramePrev_Click(object sender, EventArgs e) {
			SetImage(mSelectedImage - 1);
		}

		private void ToolFrameNext_Click(object sender, EventArgs e) {
			SetImage(mSelectedImage + 1);
		}

		private void ToolFrameFirst_Click(object sender, EventArgs e) {
			SetImage(0);
		}

		private void ToolFrameLast_Click(object sender, EventArgs e) {
			SetImage(mSprite.Images.Count - 1);
		}

		private void ToolFrameZoomIn_Click(object sender, EventArgs e) {
			mWndSprite.Zoom++;
			mWndSprite.SetStatusZoom(mWndSprite.Zoom.ToString("0.0"));
		}

		private void ToolFrameZoomOut_Click(object sender, EventArgs e) {
			mWndSprite.Zoom--;
			mWndSprite.SetStatusZoom(mWndSprite.Zoom.ToString("0.0"));
		}
		#endregion

		#region Palette Events
		private void PaletteColor_MouseClick(object sender, MouseEventArgs e) {
			var item = sender as PaletteColor;
			if (item == null) {
				return;
			}
			var index = (int)item.Tag;

			// first click on color
			if (mSelectedPaletteColor != item.Color) {
				mSelectedPaletteColor = item.Color;
				mWndSprite.SelectedColor = mSprite.Palette[index];
				if (mOldPaletteColor != null && mOldPaletteColor.Selected)
					mOldPaletteColor.Selected = false;

				mOldPaletteColor = item;
				item.Selected = true;

				if (e.Button != MouseButtons.Right)
					return;
			}

			// second click, deselect
			if (e.Button == MouseButtons.Left) {
				mWndSprite.SelectedColor = mSelectedPaletteColor = Color.Transparent;
				item.Selected = false;
				return;
			}

			// only right = change color
			if (e.Button == MouseButtons.Right) {
				using (var dlg = new ColorDialog()) {
					if (dlg.ShowDialog(this) != DialogResult.OK || item.Color == dlg.Color)
						return;
					item.Color = dlg.Color;

					mSprite.Palette[index] = dlg.Color;
					mSprite.ResetImages();
					SetImage(mSelectedImage); // set again to force redraw
				}
			}
		}

		private void PaletteColor_ColorHovered(object sender, EventArgs e) {
			var item = sender as PaletteColor;
			if (item == null) {
				return;
			}
			var index = (int)item.Tag;

			mWndPalette.SetStatusRGB(string.Format("[{0}] {1}, {2}, {3}", (index + 1), mSprite.Palette[index].R, mSprite.Palette[index].G, mSprite.Palette[index].B));
		}
		#endregion


		private void ParsePluginArgs(List<string> pluginArgs) {
			// Format: <command*arg>
			for (var i = 0; i < pluginArgs.Count; i++) {
				string arg = pluginArgs[i].Trim(), arg2 = "";
				if (arg.Contains("*")) {
					var tmp = arg.Split('*');
					arg = tmp[0].Trim();
					arg2 = tmp[1].Trim();
				}
				switch (arg) {
					case "sprite": // fast sprite loading
						OpenSprite(arg2, true);
						break;
					default:
						Plugin.Logger.Error("Unknown start arg: " + arg);
						break;
				}
			}
		}

		private bool OpenSprite() {
			using (var dlg = new OpenFileDialog()) {
				dlg.Filter = "Sprite|*" + RoSprite.FormatExtension;
				if (dlg.ShowDialog(this) != DialogResult.OK)
					return false;

				return OpenSprite(dlg.FileName, false);
			}
		}

		private bool OpenSprite(string spritepath, bool fromBash) {
			mSprite = new RoSprite(spritepath);
			if (mSprite.Images.Count == 0) { // lol
				mSprite = null;

				if (fromBash) {
					SetControls(false);
				}
				return false;
			}

			InitializePalette();
			mWndSprite.SpriteControl.BackColor = mSprite.Palette[0];
			SetImage(0);

			if (fromBash) {
				SetControls(true);
			}
			return true;
		}

		private void InitializePalette() {
			mWndPalette.SuspendLayout();
			mWndPalette.Controls["pnlPalette"].Controls.Clear();
			mSelectedPaletteColor = Color.Transparent;

			for (int i = 0; i < mSprite.Palette.Count; i++) {
				var item = new PaletteColor(mSprite.Palette[i]);
				// 5 padding from border, 3 per item
				var x = 5 + ((mWndPalette.Controls["pnlPalette"].Controls.Count % 16) * item.Width) + ((mWndPalette.Controls["pnlPalette"].Controls.Count % 16) * 3);
				var y = 5 + ((mWndPalette.Controls["pnlPalette"].Controls.Count / 16) * item.Height) + ((mWndPalette.Controls["pnlPalette"].Controls.Count / 16) * 3);
				item.Location = new Point(x, y);
				item.Tag = i;
				item.MouseClick += new MouseEventHandler(PaletteColor_MouseClick);
				item.ColorHovered += new EventHandler(PaletteColor_ColorHovered);

				mWndPalette.Controls["pnlPalette"].Controls.Add(item);
			}

			mWndPalette.ResumeLayout(false);
			mWndPalette.PerformLayout();
		}

		private bool SetImage(int index) {
			if (index < 0 || index >= mSprite.Images.Count)
				return false;

			mSelectedImage = index;
			if (mSprite.IsDrawn(mSelectedImage) == false)
				mSprite.DrawImage(mSelectedImage);
			mWndSprite.SpriteImage = mSprite[mSelectedImage].Image;

			mWndSprite.SetStatusFrameCount((mSelectedImage + 1) + "/" + mSprite.Images.Count);
			mWndSprite.SetStatusFrameSize(mWndSprite.SpriteImage.Width + " x " + mWndSprite.SpriteImage.Height);

			ToolFramePrev.Enabled = ToolFrameFirst.Enabled = (mSelectedImage > 0);
			ToolFrameNext.Enabled = ToolFrameLast.Enabled = (mSelectedImage + 1 < mSprite.Images.Count);
			return true;
		}

		private void ExtractFrame(string filePath, int index, bool trans) {
			if (mSprite.IsDrawn(index) == false)
				mSprite.DrawImage(index);
			filePath = Path.GetFullPath(filePath) + @"\Image " + (index + 1) + ".png";
			Library.SafeIo.DeleteFile(filePath);
			if (trans) {
				mSprite.GetImageTransparent(index).Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
			} else {
				mSprite[index].Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
			}
		}


		private void SetControls(bool Enabled) {
			MenuSpriteSave.Enabled = Enabled;
			MenuSpriteExtract.Enabled = Enabled;
			MenuSpriteFrameAdd.Enabled = Enabled;
			MenuSpriteFrameDel.Enabled = Enabled;
			MenuPalette.Enabled = Enabled;
			ToolSpriteSave.Enabled = Enabled;
			ToolFrameFirst.Enabled = Enabled;
			ToolFramePrev.Enabled = Enabled;
			ToolFrameNext.Enabled = Enabled;
			ToolFrameLast.Enabled = Enabled;
			ToolFrameZoomIn.Enabled = Enabled;
			ToolFrameZoomOut.Enabled = Enabled;
		}


	}

}
