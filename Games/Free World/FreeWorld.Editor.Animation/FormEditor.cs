using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FreeWorld.Engine.TileEngine;
using FreeWorld.Engine.TileEngine.Animation;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XnaKeys = Microsoft.Xna.Framework.Input.Keys;
using FreeWorld.Engine;
using DrawHelper = FreeWorld.Engine.Tools.DrawHelper;
using FileLists = GodLesZ.Library.Xna.Content.FileListLoader;
using Keys = System.Windows.Forms.Keys;

namespace FreeWorld.Editor.Animation {

	public partial class FormEditor : Form {
		private const string COMBO_TILESETS_PREFIX = "";

		private bool mFormLoaded;
		private TileAnimation mAnimation = new TileAnimation();

		private SpriteBatch mSpriteBatch;
		private SpriteFont mSpriteFont;

		private Texture2D mOrientationChar;
		private Texture2D mAnimationTileset;
		private Texture2D mLineTexture;

		private int mSelectedFrame = -1;
		private int mSelectedAnimation = -1;
		private int mSelectedDrawnAnimation = -1;
		private List<System.Drawing.Bitmap> mAnimationParts;

		private readonly System.Drawing.Pen mPenInnerBorder = new System.Drawing.Pen(System.Drawing.Brushes.LightSlateGray, 2f);
		private readonly System.Drawing.Pen mPenOuterBorder = new System.Drawing.Pen(System.Drawing.Brushes.Black, 1f);

		private Point2D mMousePosition = Point2D.Zero;

		private TileAnimationFrame mCopiedFrame;

		private Timer mAnimationTimer;

		public TileAnimationFrameImage SelectedImage {
			get {
				if (mSelectedFrame == -1 || mSelectedDrawnAnimation == -1)
					return null;
				return mAnimation.Frames[mSelectedFrame][mSelectedDrawnAnimation];
			}
		}

		public PictureBox SelectedPictureBox {
			get {
				if (mSelectedAnimation == -1)
					return null;
				return pnlTilesetThumbs.Controls[mSelectedAnimation] as PictureBox;
			}
		}


		/// <exception cref="ArgumentException">Animation timer not initialized, failed to start</exception>
		public bool AnimationTimerRunning {
			get { return mAnimationTimer != null && mAnimationTimer.Enabled; }
			set {
				if (value && mAnimationTimer == null) {
					throw new ArgumentException("Animation timer not initialized, failed to start");
				}

				mAnimationTimer.Enabled = value;
				if (value) {
					mAnimationTimer.Stop();
				}

				if (value) {
					MenuToolStripPlay.Enabled = false;
					MenuToolStripStop.Enabled = true;
				} else {
					MenuToolStripPlay.Enabled = true;
					MenuToolStripStop.Enabled = false;
				}
			}
		}

		public Point2D RenderDisplayCenterPosition {
			get { return new Point2D(RenderDisplayAnimation.Width / 2, RenderDisplayAnimation.Height / 2); }
		}

		public GraphicsDevice GraphicsDevice {
			get { return RenderDisplayAnimation.GraphicsDevice; }
		}


		public FormEditor() {
			InitializeComponent();

			RenderDisplayAnimation.OnInitialize += RenderDisplayAnimation_OnInitialize;
			RenderDisplayAnimation.OnDraw += RenderDisplayAnimation_OnDraw;

			Application.Idle += delegate {
				RenderDisplayAnimation.Invalidate();
			};

			SliderCharX.Minimum = -(RenderDisplayAnimation.Width / 2);
			SliderCharX.Maximum = (RenderDisplayAnimation.Width / 2);
			SliderCharY.Minimum = -(RenderDisplayAnimation.Height / 2);
			SliderCharY.Maximum = (RenderDisplayAnimation.Height / 2);
		}


		#region frmEditor Events
		private void frmEditor_Load(object sender, EventArgs e) {
#if DEBUG
			// (re)build the File Lists
			FileLists.Instance.LoadLists(true);
#endif
			// fill Character Box
			foreach (var entry in FileLists.Instance.Characters) {
				comboCharTilesets.Items.Add(COMBO_TILESETS_PREFIX + entry);
			}
			// fill Tileset Box
			foreach (var entry in FileLists.Instance.AnimationTilesets) {
				cmbTilesets.Items.Add(COMBO_TILESETS_PREFIX + entry);
			}

			// auto-select first
			comboCharTilesets.SelectedIndex = 0;
			cmbTilesets.SelectedIndex = 0;
			comboFrameCount.SelectedIndex = 0;
			listFrames.SelectedIndex = 0;

			StatusLabel.Text = "Ready.";
			mFormLoaded = true;
		}

		private void frmEditor_KeyDown(object sender, KeyEventArgs e) {
			// Timer running? Handle some timer keys
			if (AnimationTimerRunning) {
				if (mAnimationTimer != null && mAnimationTimer.Enabled) {
					// Pause timer?
					if (e.KeyCode == System.Windows.Forms.Keys.P || e.KeyCode == System.Windows.Forms.Keys.W) {
						AnimationTimerRunning = false;
						// Handled!
						return;
					}
				}
			}

			switch (e.KeyCode) {
				case Keys.Up:
					e.Handled = MoveImage(XnaKeys.Up);
					break;
				case Keys.Down:
					e.Handled = MoveImage(XnaKeys.Down);
					break;
				case Keys.Left:
					e.Handled = MoveImage(XnaKeys.Left);
					break;
				case Keys.Right:
					e.Handled = MoveImage(XnaKeys.Right);
					break;
				case Keys.Delete:
				case Keys.EraseEof:
					e.Handled = RemoveImage();
					break;
				case Keys.P:
					e.Handled = true;
					AnimationPlay(false);
					break;
				case Keys.W:
					e.Handled = true;
					AnimationPlay(true);
					break;
				case Keys.Escape:
					// Unselect picturebox
					if (mSelectedAnimation != -1) {
						UnselectAnimationTileset(mSelectedAnimation);
						// or unselect frame image
					} else if (listFrameImages.SelectedIndices.Count > 0) {
						listFrameImages.SelectedIndices.Clear();
					}
					break;
			}
		}
		#endregion

		#region Tileset-Auwahl Events
		private void comboTileset_SelectedIndexChanged(object sender, EventArgs e) {
			mAnimationTileset = EngineCore.ContentLoader.GetAnimationTileset(FileLists.Instance.AnimationTilesets[cmbTilesets.SelectedIndex].Filename);
			SplitAnmationTileset();
		}
		#endregion

		#region Char Modification Events
		private void comboCharTilesets_SelectedIndexChanged(object sender, EventArgs e) {
			mOrientationChar = EngineCore.ContentLoader.GetCharacter(FileLists.Instance.Characters[comboCharTilesets.SelectedIndex].Filename);
		}

		private void btnCharPosReset_Click(object sender, EventArgs e) {
			SliderCharX.Value = 0;
			SliderCharY.Value = 0;
		}

		private void numFrameTime_ValueChanged(object sender, EventArgs e) {
			mAnimation.FrameLength = (float)numFrameTime.Value / 1000f;
		}
		#endregion

		#region RenderDisplayAnimation Events
		private void RenderDisplayAnimation_OnInitialize(object sender, EventArgs e) {
			EngineCore.Initialize("Content", GraphicsDevice, RenderDisplayAnimation.Services);

			mSpriteBatch = new SpriteBatch(GraphicsDevice);
			mLineTexture = DrawHelper.Rect2Texture(1, 1, 0, Color.White);

			mSpriteFont = EngineCore.ContentLoader.Load<SpriteFont>(@"Fonts\Arial");
		}

		private void RenderDisplayAnimation_OnDraw(object sender, EventArgs e) {
			if (mFormLoaded == false) {
				return;
			}

			GraphicsDevice.Clear(Color.Black);
			LogicDraw();
			LogicRender();
		}

		private void RenderDisplayAnimation_Click(object sender, EventArgs e) {
			RenderDisplayAnimation.Focus();
		}

		/// <exception cref="Exception"></exception>
		private void RenderDisplayAnimation_MouseUp(object sender, MouseEventArgs e) {
			RenderDisplayAnimation.Focus();

			if (mSelectedFrame == -1) {
				return;
			}
			if (AnimationTimerRunning) {
				return;
			}

			// Place a new Image
			if (mSelectedAnimation != -1 && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)) {
				var imagePos = CalculateNewImagePosition();

				var img = new TileAnimationFrameImage {
					TextureSource = GetTextureSource(pnlTilesetThumbs.Controls[mSelectedAnimation].Name),
					Scale = 0.5f,
					Offset = imagePos,
					IsBackground = (e.Button == MouseButtons.Left)
				};
				img.Scale = (Constants.AnimationWidth / (float)Constants.AnimationTilesetWidth);
				// Add to animation object
				mAnimation.Frames[mSelectedFrame].Add(img);

				// Add to frame image list
				var item = new FrameImageListItem(mSelectedFrame, mAnimation.Frames[mSelectedFrame].Count - 1, img);
				var listViewItem = listFrameImages.Items.Add(item);
				// Select frame image
				listFrameImages.SelectedItems.Clear();
				listFrameImages.SelectedIndices.Add(listFrameImages.Items.IndexOf(listViewItem));

				return;
			}

			// Select a Image from the frame
			var frame = mAnimation.Frames[mSelectedFrame];
			var intersectionPosition = mMousePosition;
			int i;
			for (i = frame.Count - 1; i >= 0; i--) {
				if (intersectionPosition.Contains(frame[i].GetDestinationRectangle(RenderDisplayCenterPosition)))
					break;
			}
			if (i == -1) { // no collision
				listFrameImages.SelectedIndices.Clear();
				return;
			}

			// Search the listImages Index
			for (var l = 0; l < listFrameImages.Items.Count; l++) {
				var item = listFrameImages.Items[l] as FrameImageListItem;
				if (item == null) {
					throw new Exception("Invalid item data in frame image list at index " + i);
				}

				if (item.FrameIndex != mSelectedFrame || item.FrameImageIndex != i) {
					continue;
				}

				listFrameImages.SelectedIndices.Clear();
				listFrameImages.SelectedIndices.Add(l);
				break;
			}
		}

		private void RenderDisplayAnimation_MouseEnter(object sender, EventArgs e) {
			if (chkMousePointer.Checked) {
				return;
			}

			Cursor.Hide();
		}

		private void RenderDisplayAnimation_MouseLeave(object sender, EventArgs e) {
			// Did we hide the Cursor?
			if (chkMousePointer.Checked == false) {
				Cursor.Show();
			}

			mMousePosition = Point2D.Zero;
		}
		#endregion

		#region Menu Events
		private void MenuEditorClose_Click(object sender, EventArgs e) {
			if (AnimationTimerRunning) {
				return;
			}

			Close();
		}

		private void MenuEditorSave_Click(object sender, EventArgs e) {
			if (AnimationTimerRunning) {
				return;
			}

			var dlg = new SaveFileDialog {
				InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Content\Data\bAnimations\",
				Filter = "Blubb Animation (*.bani)|*.bani",
				FileName = ""
			};
			if (dlg.ShowDialog() != DialogResult.OK) {
				return;
			}

			mAnimation.Save(dlg.FileName);
		}

		private void MenuEditorOpen_Click(object sender, EventArgs e) {
			if (AnimationTimerRunning) {
				return;
			}

			var dlg = new OpenFileDialog {
				Filter = "Blubb Animation (*.bani)|*.bani",
				InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Content\bAnimations\"
			};
			if (dlg.ShowDialog() != DialogResult.OK) {
				return;
			}

			OpenAnimation(dlg.FileName);
		}

		private void MenuEditorNew_Click(object sender, EventArgs e) {
			mSelectedAnimation = -1;
			mSelectedFrame = -1;
			SelectImagePreview(-1);

			mAnimation = new TileAnimation();

			listFrameImages.Items.Clear();
			listFrames.Items.Clear();
			listFrames.Items.Add("Frame " + 1);
			cmbTilesets.SelectedIndex = 0;
			comboFrameCount.SelectedIndex = 0;
			listFrames.SelectedItem = 0;
			numFrameTime.Value = (int)(mAnimation.FrameLength * 1000f);
		}

		private void menuEditorImportRpgMaker_Click(object sender, EventArgs e) {
			using (var frm = new FormImportRpgMaker()) {
				if (frm.ShowDialog(this) != DialogResult.OK) {
					return;
				}

				var selectedAnim = frm.SelectedAnimation;
				var newTileAnimation = TileAnimation.LoadFromJson(selectedAnim);
				mAnimation = newTileAnimation.Clone() as TileAnimation;
				// FIX: RPG Maker XP effects are based on a larger character
				/*
				foreach (var frame in mAnimation.Frames) {
					foreach (var image in frame) {
						if (image.Scale > 0.1f) {
							image.Scale = image.Scale * 0.5f;
						}
					}
				}
				*/
				ReloadAnimation();
			}
		}

		private void MenuToolStripPlay_Click(object sender, EventArgs e) {
			AnimationPlay(false);
		}

		private void MenuToolStripStop_Click(object sender, EventArgs e) {
			if (mAnimationTimer != null && mAnimationTimer.Enabled) {
				mAnimationTimer.Stop();
			}

			AnimationTimerRunning = false;
		}
		#endregion

		#region ListFrames Events
		private void comboFrameCount_SelectedIndexChanged(object sender, EventArgs e) {
			var fCount = comboFrameCount.SelectedIndex + 1;
			if (listFrames.Items.Count < fCount) {
				for (var i = listFrames.Items.Count; i < fCount; i++) {
					listFrames.Items.Add("Frame " + (i + 1));
					mAnimation.Frames.Add(new TileAnimationFrame());
				}
			} else if (listFrames.Items.Count > fCount) {
				while (listFrames.Items.Count > fCount) {
					listFrames.Items.RemoveAt(listFrames.Items.Count - 1);
					mAnimation.Frames.RemoveAt(mAnimation.Frames.Count - 1);
				}
			}
		}

		private void ListFrames_SelectedIndexChanged(object sender, EventArgs e) {
			mSelectedFrame = listFrames.SelectedIndex;
			SelectImagePreview(-1);

			RefreshFrameImageList();
		}

		private void ListFramesContextMenu_Opening(object sender, CancelEventArgs e) {
			if (mSelectedFrame == -1) {
				e.Cancel = true;
				return;
			}

			ListFramesContextPaste.Enabled = (mCopiedFrame != null);
		}

		private void ListFramesContextCopy_Click(object sender, EventArgs e) {
			if (mSelectedFrame == -1)
				return;

			mCopiedFrame = mAnimation.Frames[mSelectedFrame].Clone() as TileAnimationFrame;
		}

		private void ListFramesContextPaste_Click(object sender, EventArgs e) {
			if (mSelectedFrame == -1 || mCopiedFrame == null)
				return;

			mAnimation.Frames[mSelectedFrame] = mCopiedFrame.Clone() as TileAnimationFrame;
			RefreshFrameImageList();
		}

		private void ListFramesContextClear_Click(object sender, EventArgs e) {
			mAnimation.Frames[mSelectedFrame] = new TileAnimationFrame();
			listFrameImages.Items.Clear();
		}
		#endregion

		#region ListImages Events
		/// <exception cref="Exception">Invalid item data in frame image list at index 0</exception>
		private void listFrameImages_SelectedIndexChanged(object sender, EventArgs e) {
			if (listFrameImages.SelectedIndices.Count == 0) {
				SelectImagePreview(-1);
				return;
			}

			var item = listFrameImages.SelectedItems[0] as FrameImageListItem;
			if (item == null) {
				throw new Exception("Invalid item data in frame image list at index 0");
			}

			listFrames.SelectedIndex = item.FrameIndex;
			SelectImagePreview(item.FrameImageIndex);
		}

		private void listFrameImagesContextDelete_Click(object sender, EventArgs e) {
			if (listFrameImages.SelectedIndices.Count == 0) {
				return;
			}

			int removeIndex = listFrameImages.SelectedIndices[0];
			SelectImagePreview(-1);
			mAnimation.Frames[mSelectedFrame].RemoveAt(removeIndex);
			listFrameImages.Items.RemoveAt(removeIndex);
		}
		#endregion

		#region Image Settings
		private void sliderScale_Scroll(object sender, EventArgs e) {
			var scale = sliderScale.Value / 100f;
			SelectedImage.Scale = scale;
			lblWidth.Text = sliderScale.Value + "%";
		}

		private void SliderRotate_Scroll(object sender, EventArgs e) {
			SelectedImage.Rotation = SliderRotate.Value / 60f;
			lblRotate.Text = SliderRotate.Value + "°";
		}

		private void SliderTrans_Scroll(object sender, EventArgs e) {
			SelectedImage.Color = new Color(SelectedImage.Color.R, SelectedImage.Color.G, SelectedImage.Color.B, (255 - SliderTrans.Value));
			lblAlpha.Text = Math.Round(((255 - SelectedImage.Color.A) / 255f) * 100f) + "%";
		}

		private void ColorBox_Click(object sender, EventArgs e) {
			var dlg = new ColorDialog();
			var c = SelectedImage.Color;
			dlg.Color = System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);
			if (dlg.ShowDialog() != DialogResult.OK) {
				return;
			}

			SelectedImage.Color = new Color(dlg.Color.R, dlg.Color.G, dlg.Color.B, dlg.Color.A);
			ColorBox.BackColor = dlg.Color;
		}

		private void SliderColorRed_Scroll(object sender, EventArgs e) {
			SelectedImage.Color = SelectedImage.Color.SetR((byte)SliderColorRed.Value);
			ColorBox.BackColor = SelectedImage.Color.ToWinColor();
		}

		private void SliderColorGreen_Scroll(object sender, EventArgs e) {
			SelectedImage.Color = SelectedImage.Color.SetG((byte)SliderColorGreen.Value);
			ColorBox.BackColor = SelectedImage.Color.ToWinColor();
		}

		private void SliderColorBlue_Scroll(object sender, EventArgs e) {
			SelectedImage.Color = SelectedImage.Color.SetB((byte)SliderColorBlue.Value);
			ColorBox.BackColor = SelectedImage.Color.ToWinColor();
		}

		private void chkMirrorHori_CheckedChanged(object sender, EventArgs e) {
			if (chkMirrorHori.Checked)
				SelectedImage.Mirror |= SpriteEffects.FlipHorizontally;
			else
				SelectedImage.Mirror &= ~SpriteEffects.FlipHorizontally;
		}

		private void chkMirrorVerti_CheckedChanged(object sender, EventArgs e) {
			if (chkMirrorVerti.Checked)
				SelectedImage.Mirror |= SpriteEffects.FlipVertically;
			else
				SelectedImage.Mirror &= ~SpriteEffects.FlipVertically;
		}

		private void chkSelectedImageIsBackground_CheckedChanged(object sender, EventArgs e) {
			SelectedImage.IsBackground = chkSelectedImageIsBackground.Checked;
		}
		#endregion

		#region PanelTilesets Events
		/// <exception cref="ArgumentException">Invalid sender, expected PictureBox</exception>
		public void PanelTilesetImage_Click(object sender, EventArgs e) {
			var box = sender as PictureBox;
			if (box == null) {
				throw new ArgumentException("Invalid sender, expected PictureBox", "sender");
			}

			var newSelection = int.Parse(box.Tag.ToString());

			// Restore prev Anmation Part without Border
			if (mSelectedAnimation != -1) {
				SelectedPictureBox.Image = mAnimationParts[mSelectedAnimation].Clone() as System.Drawing.Bitmap;
				SelectedPictureBox.Invalidate();
			}

			// Clicked the same again? unmark it
			if (newSelection == mSelectedAnimation) {
				mSelectedAnimation = -1;
				return;
			}

			// Set new selected Animation
			mSelectedAnimation = int.Parse(box.Tag.ToString());

			// Paint the Border to mark as "selected"
			using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(box.Image)) {
				g.DrawRectangle(mPenOuterBorder, new System.Drawing.Rectangle(0, 0, box.Image.Width - 1, box.Image.Height - 1));
				g.DrawRectangle(mPenInnerBorder, new System.Drawing.Rectangle(2, 2, box.Image.Width - 4, box.Image.Height - 4));
				g.DrawRectangle(mPenOuterBorder, new System.Drawing.Rectangle(3, 3, box.Image.Width - 7, box.Image.Height - 7));
			}

			box.Invalidate();
		}
		#endregion




		private void LogicRender() {
			Mouse.WindowHandle = RenderDisplayAnimation.Handle;

			mMousePosition = new Point2D(Mouse.GetState().X, Mouse.GetState().Y);

			if (mSelectedFrame == -1 || mSelectedAnimation == -1)
				return;
			if (mMousePosition == Point.Zero)
				return;
			if (AnimationTimerRunning)
				return;

			// Draw preview
			var texSrc = GetTextureSource(pnlTilesetThumbs.Controls[mSelectedAnimation].Name);
			var drawTexture = EngineCore.ContentLoader.GetAnimationTileset(texSrc.TextureIndex);
			var previewDrawPosition = new Point(mMousePosition.X - (Constants.AnimationWidth / 2), mMousePosition.Y - (Constants.AnimationHeight / 2));
			var destRect = new Rectangle(previewDrawPosition.X, previewDrawPosition.Y, Constants.AnimationWidth, Constants.AnimationHeight);
			var srcRect = new Rectangle(texSrc.X, texSrc.Y, texSrc.Width, texSrc.Height);

			// @TODO: Position => based on display center
			mSpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
			mSpriteBatch.Draw(drawTexture, destRect, srcRect, Color.White);
			var shownPos = new Point(mMousePosition.X - RenderDisplayCenterPosition.X, mMousePosition.Y - RenderDisplayCenterPosition.Y);
			mSpriteBatch.DrawString(mSpriteFont, string.Format("{0:000} / {1:000}", shownPos.X, shownPos.Y), new Vector2(10, RenderDisplayAnimation.Height - 20), Color.LightSalmon);
			mSpriteBatch.DrawRectangle(mLineTexture, destRect, 1, Color.White);
			mSpriteBatch.End();
		}

		private void LogicDraw() {
			mSpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);

			var drawOffset = RenderDisplayCenterPosition;
			var onDrawImage = new OnDrawTileAnimationFrameImageDelegate(delegate(TileAnimationFrame frame, TileAnimationFrameImage image) {
				var i = frame.IndexOf(image);
				// Border + frame number (skip on animation)
				if (AnimationTimerRunning) {
					return;
				}

				var destRectangle = image.GetDestinationRectangle(drawOffset);
				var drawColor = (mSelectedDrawnAnimation == i ? Color.White : Color.Red);
				mSpriteBatch.DrawRectangle(mLineTexture, destRectangle, 1, drawColor);
				var drawFrameNum = (i + 1).ToString(CultureInfo.InvariantCulture);
				var drawPos = new Vector2(destRectangle.X + 3, destRectangle.Y + 2);
				mSpriteBatch.DrawString(mSpriteFont, drawFrameNum, drawPos, drawColor);
			});
			var onDrawLastImage = new OnDrawTileAnimationFrameImageDelegate(delegate(TileAnimationFrame frame, TileAnimationFrameImage image) {
				var i = frame.IndexOf(image);
				// Border + frame number (skip on animation)
				if (AnimationTimerRunning) {
					return;
				}

				var destRectangle = image.GetDestinationRectangle(drawOffset);
				var drawColor = Color.SlateBlue;
				mSpriteBatch.DrawRectangle(mLineTexture, destRectangle, 1, drawColor);
				var drawFrameNum = (i + 1).ToString(CultureInfo.InvariantCulture);
				var drawPos = new Vector2(destRectangle.X + 3, destRectangle.Y + 2);
				mSpriteBatch.DrawString(mSpriteFont, drawFrameNum, drawPos, drawColor);
			});

			if (AnimationTimerRunning == false) {
				// draw a Cross
				// ---
				var drawRect = new Rectangle(0, RenderDisplayAnimation.Height / 2 - 1, RenderDisplayAnimation.Width, 1);
				mSpriteBatch.Draw(mLineTexture, drawRect, Color.Violet);
				//  |
				drawRect = new Rectangle(RenderDisplayAnimation.Width / 2 - 1, 0, 1, RenderDisplayAnimation.Height);
				mSpriteBatch.Draw(mLineTexture, drawRect, Color.Violet);
			}

			// Background Images, if a Frame is selected
			if (mSelectedFrame != -1) {
				if (chkDrawLastFrame.Checked && mSelectedFrame > 0) {
					var lastFrame = mAnimation.Frames[mSelectedFrame - 1];
					lastFrame.DrawBackground(mSpriteBatch, drawOffset, onDrawLastImage);
				}

				var frame = mAnimation.Frames[mSelectedFrame];
				frame.DrawBackground(mSpriteBatch, drawOffset, onDrawImage);
			}

			// draw the Char
			if (chkCharDisplay.Checked && mOrientationChar != null) {
				var destRect = new Rectangle(drawOffset.X + SliderCharX.Value, drawOffset.Y + SliderCharY.Value, Constants.CharTileWidth, Constants.CharTileHeight);
				var srcRect = new Rectangle(0, 0, Constants.CharTileWidth, Constants.CharTileHeight);
				destRect.X -= Constants.CharTileWidth / 2;
				destRect.Y -= Constants.CharTileHeight / 2;
				mSpriteBatch.Draw(mOrientationChar, destRect, srcRect, Color.White);
			}

			// Foreground Images, if a Frame is selected
			if (mSelectedFrame != -1) {
				if (chkDrawLastFrame.Checked && mSelectedFrame > 0) {
					var lastFrame = mAnimation.Frames[mSelectedFrame - 1];
					lastFrame.DrawForeground(mSpriteBatch, drawOffset, onDrawLastImage);
				}

				var frame = mAnimation.Frames[mSelectedFrame];
				frame.DrawForeground(mSpriteBatch, drawOffset, onDrawImage);
			}


			// Image Selection? draw Position
			if (mSelectedFrame != -1 && mSelectedDrawnAnimation != -1) {
				var frameImage = mAnimation.Frames[mSelectedFrame][mSelectedDrawnAnimation];
				var drawString = string.Format("{0:000} / {1:000}",
					frameImage.Offset.X,
					frameImage.Offset.Y
				);
				var drawPos = new Vector2(RenderDisplayAnimation.Width - mSpriteFont.MeasureString(drawString).X - 10, RenderDisplayAnimation.Height - 20);
				mSpriteBatch.DrawString(mSpriteFont, drawString, drawPos, Color.White);
			}

			mSpriteBatch.End();
		}


		private void OpenAnimation(string fileName) {
			mSelectedAnimation = -1;
			mSelectedFrame = -1;
			SelectImagePreview(-1);

			if (TileAnimation.Load(fileName, out mAnimation) != TileLoadResult.Success) {
				mAnimation = new TileAnimation(); // avoid "null" crashes
			}

			ReloadAnimation();
		}

		private void ReloadAnimation() {
			numFrameTime.Value = (int)(mAnimation.FrameLength * 1000f);

			listFrameImages.Items.Clear();
			listFrames.Items.Clear();
			for (var i = 0; i < mAnimation.Frames.Count; i++) {
				listFrames.Items.Add("Frame " + (i + 1));
			}
			
			comboFrameCount.SelectedIndex = Math.Max(1, mAnimation.Frames.Count - 1);
			if (listFrames.Items.Count > 0) {
				listFrames.SelectedItem = 0;
			}

			if (mAnimation.Frames.Count > 0 && mAnimation.Frames[0].Count > 0) {
				cmbTilesets.SelectedItem = COMBO_TILESETS_PREFIX + mAnimation.Frames[0][0].TextureIndex;
			}
		}

		private void SplitAnmationTileset() {
			pnlTilesetThumbs.Controls.Clear();
			// Taken from the old code - row was 125px, animation height 96px
			tableLayoutPanel1.RowStyles[4].Height = Constants.AnimationHeight + 29;

			var imgParts = new Point(mAnimationTileset.Width / Constants.AnimationTilesetWidth, mAnimationTileset.Height / Constants.AnimationTilesetHeight);
			var animationBmp = DrawHelper.Texture2Image(mAnimationTileset);
			mAnimationParts = new List<System.Drawing.Bitmap>();
			mSelectedAnimation = -1;

			int padding = 2, indexTag = 0;
			for (var y = 0; y < imgParts.Y; y++) {
				var modY = y * (imgParts.X * Constants.AnimationWidth);
				for (var x = 0; x < imgParts.X; x++, padding += 2) {
					var imgBox = new PictureBox {
						Location = new System.Drawing.Point(padding + modY + (x * Constants.AnimationWidth), 2),
						Image = GetAnimationPart(animationBmp, x, y)
					};

					imgBox.Size = new System.Drawing.Size(imgBox.Image.Width, imgBox.Image.Height);
					imgBox.Tag = (indexTag++); // Allows to quickly detect the selection in an array
					imgBox.Name = string.Format("{0}_{1}_{2}", cmbTilesets.SelectedIndex, x, y);
					imgBox.Click += PanelTilesetImage_Click;
					imgBox.BackColor = System.Drawing.Color.Black;

					mAnimationParts.Add(imgBox.Image.Clone() as System.Drawing.Bitmap);
					pnlTilesetThumbs.Controls.Add(imgBox);
				}
			}

			animationBmp.Dispose();
		}

		private void UnselectAnimationTileset(int index) {
			var indexAsString = index.ToString(CultureInfo.InvariantCulture);
			foreach (var control in pnlTilesetThumbs.Controls.Cast<PictureBox>().Where(control => control.Tag != null && control.Tag.ToString() == indexAsString)) {
				PanelTilesetImage_Click(control, EventArgs.Empty);
				break;
			}
		}

		private System.Drawing.Bitmap GetAnimationPart(System.Drawing.Bitmap animationBmp, int x, int y) {
			var newBmp = new System.Drawing.Bitmap(Constants.AnimationWidth, Constants.AnimationHeight);
			using (var g = System.Drawing.Graphics.FromImage(newBmp)) {
				g.DrawImage(animationBmp, new System.Drawing.Rectangle(0, 0, newBmp.Width, newBmp.Height), new System.Drawing.Rectangle(x * Constants.AnimationTilesetWidth, y * Constants.AnimationTilesetHeight, Constants.AnimationTilesetWidth, Constants.AnimationTilesetHeight), System.Drawing.GraphicsUnit.Pixel);
				g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Brushes.Black, 1f), new System.Drawing.Rectangle(0, 0, newBmp.Width - 1, newBmp.Height - 1));
			}

			return newBmp;
		}

		private static TileCellSource GetTextureSource(string name) {
			var parts = name.Split(new[] { '_' });
			var src = new TileCellSource {
				TextureIndex = FileLists.Instance.AnimationTilesets[int.Parse(parts[0])].Filename,
				Width = Constants.AnimationTilesetWidth,
				Height = Constants.AnimationTilesetHeight,
				X = (int.Parse(parts[1]) * Constants.AnimationTilesetWidth),
				Y = (int.Parse(parts[2]) * Constants.AnimationTilesetHeight)
			};

			return src;
		}

		private Point2D CalculateNewImagePosition() {
			// Image position is based on render display center
			var imagePos = mMousePosition - RenderDisplayCenterPosition;
			// Dont forget to subtract tileset half size
			// EDIT: Should be done in frameImage class itself
			//imagePos -= new Point2D(Constants.AnimationWidth, Constants.AnimationHeight) / 2;

			return imagePos;
		}

		private void SelectImagePreview(int p) {
			mSelectedDrawnAnimation = p;
			if (p == -1 || mAnimation.Frames[mSelectedFrame].Count <= p) {
				SliderColorBlue.Enabled = false;
				SliderColorGreen.Enabled = false;
				SliderColorRed.Enabled = false;
				SliderRotate.Enabled = false;
				SliderTrans.Enabled = false;
				sliderScale.Enabled = false;
				chkMirrorHori.Enabled = false;
				chkMirrorVerti.Enabled = false;
				ColorBox.Enabled = false;
				chkSelectedImageIsBackground.Enabled = false;
				mSelectedDrawnAnimation = -1;
				return;
			}

			var img = mAnimation.Frames[mSelectedFrame][p];

			SliderTrans.Enabled = true;
			SliderTrans.Value = 255 - img.Color.A;
			SliderColorRed.Enabled = true;
			SliderColorRed.Value = img.Color.R;
			SliderColorGreen.Enabled = true;
			SliderColorGreen.Value = img.Color.G;
			SliderColorBlue.Enabled = true;
			SliderColorBlue.Value = img.Color.B;
			ColorBox.Enabled = true;
			ColorBox.BackColor = img.Color.ToWinColor();

			sliderScale.Enabled = true;
			sliderScale.Value = (int)(img.Scale * 100);
			SliderRotate.Enabled = true;
			SliderRotate.Value = (int)(img.Rotation * 6);
			chkMirrorHori.Enabled = true;
			chkMirrorHori.Checked = (img.Mirror & SpriteEffects.FlipHorizontally) == SpriteEffects.FlipHorizontally;
			chkMirrorVerti.Enabled = true;
			chkMirrorVerti.Checked = (img.Mirror & SpriteEffects.FlipVertically) == SpriteEffects.FlipVertically;
			chkSelectedImageIsBackground.Enabled = true;
			chkSelectedImageIsBackground.Checked = img.IsBackground;

			lblWidth.Text = sliderScale.Value + "%";
			lblRotate.Text = SliderRotate.Value + "°";
			lblAlpha.Text = Math.Round(((255 - SelectedImage.Color.A) / 255f) * 100f) + "%";
		}

		private bool MoveImage(XnaKeys keys) {
			if (mSelectedDrawnAnimation == -1 || mSelectedFrame == -1)
				return false;

			if (keys == XnaKeys.Up)
				SelectedImage.Offset.ReduceY();
			else if (keys == XnaKeys.Down)
				SelectedImage.Offset.AddY();
			else if (keys == XnaKeys.Left)
				SelectedImage.Offset.ReduceX();
			else if (keys == XnaKeys.Right)
				SelectedImage.Offset.AddX();

			return true;
		}

		private bool RemoveImage() {
			if (mSelectedDrawnAnimation == -1 || mSelectedFrame == -1)
				return false;

			int removeIndex = mSelectedDrawnAnimation;
			SelectImagePreview(-1);
			mAnimation.Frames[mSelectedFrame].RemoveAt(removeIndex);
			listFrameImages.Items.RemoveAt(removeIndex);

			return true;
		}

		private void RefreshFrameImageList() {
			listFrameImages.Items.Clear();
			if (mSelectedFrame == -1) {
				return;
			}

			for (var i = 0; i < mAnimation.Frames[mSelectedFrame].Count; i++) {
				var image = mAnimation.Frames[mSelectedFrame][i];
				var item = new FrameImageListItem(mSelectedFrame, i, image);
				listFrameImages.Items.Add(item);
			}
		}


		private void AnimationPlay(bool loop) {
			// Nothing to animate
			if (listFrames.Items.Count < 2) {
				return;
			}

			mAnimationTimer = new Timer {
				Enabled = true,
				Interval = (int)(mAnimation.FrameLength * 1000),
				Tag = loop
			};
			mAnimationTimer.Tick += AnimationTimer_Tick;

			SelectImagePreview(-1);
			listFrames.SelectedIndex = 0;
			AnimationTimerRunning = false;
			mAnimationTimer.Start();
		}
		private void AnimationTimer_Tick(object sender, EventArgs e) {
			if (listFrames.SelectedIndex + 1 >= listFrames.Items.Count) {
				mAnimationTimer.Stop();
				if ((bool)mAnimationTimer.Tag) {
					AnimationPlay(true);
				} else {
					AnimationTimerRunning = false;
					listFrames.SelectedIndex = 0;
				}
				return;
			}

			if (AnimationTimerRunning == false) {
				AnimationTimerRunning = true;
				return;
			}

			listFrames.SelectedIndex++;
		}


	}

}
