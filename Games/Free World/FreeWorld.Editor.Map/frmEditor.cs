//#define MORE_SPEED // uncomment to get more Speed but bad refresh rate

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FreeWorld.Editor.Map.Properties;
using FreeWorld.Engine;
using FreeWorld.Engine.Geometry.Camera;
using FreeWorld.Engine.TileEngine;
using FreeWorld.Engine.TileEngine.Animation;
using GodLesZ.Library.Xna;
using GodLesZ.Library.Xna.Content;
using GodLesZ.Library.Xna.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Color = Microsoft.Xna.Framework.Color;
using DrawHelper = FreeWorld.Engine.Tools.DrawHelper;
using XnaKeys = Microsoft.Xna.Framework.Input.Keys;
using FileLists = GodLesZ.Library.Xna.Content.FileListLoader;
using Keys = System.Windows.Forms.Keys;
using Point = System.Drawing.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace FreeWorld.Editor.Map {
	public partial class FrmEditor : Form {
		private readonly string mBasicContentDirectory = string.Empty;
		private const string LAYER_STATUSDEFAULT = "Aktive Ebene: ";
		private const string COLLISION_LAYER_NAME = "Kollisions Ebene";
		private static Texture2D mGridTexture;

		private SpriteBatch mSpriteBatch;
		private Texture2D mPreviewTileset;
		private Texture2D mPreviewAutotile;
		private TileAnimation mPreviewAnimation;
		private Texture2D mPreviewObject;

		private Texture2D mEraseTexture;
		private Texture2D mFlipHTexture;
		private Texture2D mFlipVTexture;
		private Texture2D mLineTexture;
		private SpriteEffects mTempEffect = SpriteEffects.None;

		private TileMap mTileMap;
		private EngineCamera mCamera;
		private int mCurrentLayer = -1;

		private Point2D mCursorCell;
		private Rectangle mTextureRect = Rectangle.Empty;
		private Rectangle mMarkerRectangle = Rectangle.Empty;

		private bool mMouseOnMapLeftButton;
		private bool mMouseOnMapRightButton;
		private bool mMouseOnTexture;

		private EDrawMode mDrawMode = EDrawMode.Draw;

		private readonly List<int> mLastTilesetIndex = new List<int>();
		private readonly List<int> mLastAutotileIndex = new List<int>();
		private readonly List<int> mLastAnimationIndex = new List<int>();
		private readonly List<int> mLastObjectIndex = new List<int>();

		private KeyboardState mNewState;

		private Point2D mLastRotatePoint = Point2D.Zero;
		private int mLastRotateTime;


		private int mLastTextureVAutoscrollTime;
		private int mLastTextureHAutoscrollTime;
		private int mLastMapAutoscrollTime;

		private readonly Stack<List<UndoAction>> mUndoQueue = new Stack<List<UndoAction>>();
		private readonly Stack<List<UndoAction>> mRedoQueue = new Stack<List<UndoAction>>();

		private readonly string[] mCallerArgs;

		private float mZoomMulti = 1.0f;
#if MORE_SPEED
		private bool mFormIsActive = false;
#endif
		private readonly GameClock mGameTime = new GameClock();


		public GraphicsDevice GraphicsDevice {
			get { return RenderDisplayMap.GraphicsDevice; }
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
		public static extern short GetKeyState(int keyCode);

		public bool GetCapsLock {
			get { return (((ushort)GetKeyState(0x14)) & 0xffff) != 0; }
		}

		public bool GetNumLock {
			get { return (((ushort)GetKeyState(0x90)) & 0xffff) != 0; }
		}

		public bool GetScrollLock {
			get { return (((ushort)GetKeyState(0x91)) & 0xffff) != 0; }
		}


		public FrmEditor(string[] args) {
			mCallerArgs = args;
			InitializeComponent();

			RenderDisplayMap.OnInitialize += MapDisplay_OnInitialize;
			RenderDisplayMap.OnDraw += MapDisplay_OnDraw;
			RenderDisplayTexture.OnDraw += TextureDisplay_OnDraw;
			RenderDisplayAutotile.OnDraw += RenderDisplayAutotiles_OnDraw;
			RenderDisplayAnimations.OnDraw += RenderDisplayAnimations_OnDraw;
			RenderDisplayObjects.OnDraw += RenderDisplayObjects_OnDraw;
			MouseWheel += frmEditor_MouseWheel;

			Application.Idle += delegate {
				RenderDisplayMap.Invalidate();
				RenderDisplayTexture.Invalidate();
				RenderDisplayAutotile.Invalidate();
				RenderDisplayAnimations.Invalidate();
				RenderDisplayObjects.Invalidate();
			};

			ProjectTreeImageList.Images.Add(Resources.Map_New); // Map
			ProjectTreeImageList.Images.Add(Resources.Layer_Lila); // Background
			ProjectTreeImageList.Images.Add(Resources.Layer_Blue); // Layer X
			ProjectTreeImageList.Images.Add(Resources.Layer_Green); // Foreground
			ProjectTreeImageList.Images.Add(Resources.Layer_Red); // Collision

			mBasicContentDirectory = @"Content\";
			mMarkerRectangle = Rectangle.Empty;

			KeyPreview = true;
		}

		#region frmEditor Events
		private void frmEditor_Shown(object sender, EventArgs e) {
			var fileLists = FileLists.Instance;
#if DEBUG
			// (re)build the File Lists
			fileLists.LoadLists(true);
#endif

			// add Tilesets, Autotiles, Animations & Objects
			foreach (var entry in fileLists.Tilesets) {
				comboTilesets.Items.Add("Tileset " + entry);
			}
			foreach (var entry in fileLists.Autotiles) {
				comboAutotiles.Items.Add("Autotile " + entry);
			}
			foreach (var entry in fileLists.Animations) {
				comboAnimations.Items.Add("Animation " + entry);
			}
			foreach (var entry in fileLists.Characters) {
				comboObjects.Items.Add("Objekt " + entry);
			}

			// called with Arguments?
			if (mCallerArgs != null && mCallerArgs.Length > 0) {
				LoadMap(mCallerArgs[0]);
			}

			AdjustScrollBars();
		}


		private void frmEditor_ResizeEnd(object sender, EventArgs e) {
			AdjustScrollBars();
		}

		private void frmEditor_FormClosing(object sender, FormClosingEventArgs e) {
			EngineCore.ContentLoader.Unload();
			Settings.Default.Save();
		}

		private void frmEditor_MouseWheel(object sender, MouseEventArgs e) {
			if (MapHScrollBar.Visible == false) {
				return;
			}

			var value = -(e.Delta / 100);
			var ks = Keyboard.GetState();
			if (ks.IsCtrlDown()) {
				value *= 3;
			}
			if (ks.IsShiftDown() == false) {
				if (MapVScrollBar.Value + value >= 0 && MapVScrollBar.Value + value <= MapVScrollBar.Maximum) {
					MapVScrollBar.Value += value;
				}
			} else {
				if (MapHScrollBar.Value + value >= 0 && MapHScrollBar.Value + value <= MapHScrollBar.Maximum) {
					MapHScrollBar.Value += value;
				}
			}
		}

		private void frmEditor_KeyDown(object sender, KeyEventArgs e) {
			//System.Diagnostics.Debug.WriteLine( e.KeyCode );
			if (e.Control == false) {
				if (e.KeyCode == Keys.H) {
					if ((mTempEffect & SpriteEffects.FlipHorizontally) == SpriteEffects.FlipHorizontally) {
						mTempEffect &= ~SpriteEffects.FlipHorizontally;
					} else {
						mTempEffect |= SpriteEffects.FlipHorizontally;
					}
				} else if (e.KeyCode == Keys.V) {
					if ((mTempEffect & SpriteEffects.FlipVertically) == SpriteEffects.FlipVertically) {
						mTempEffect &= ~SpriteEffects.FlipVertically;
					} else {
						mTempEffect |= SpriteEffects.FlipVertically;
					}
				}
				return;
			}

			// All need STRG/CTRL
			switch (e.KeyCode) {
				case Keys.Y:
					Redo();
					break;
				case Keys.Z:
					Undo();
					break;
				case Keys.Up:
					MoveTextures(XnaKeys.Up);
					break;
				case Keys.Down:
					MoveTextures(XnaKeys.Down);
					break;
				case Keys.Left:
					MoveTextures(XnaKeys.Left);
					break;
				case Keys.Right:
					MoveTextures(XnaKeys.Right);
					break;
				case Keys.Add:
				case Keys.Oemplus:
					AddZoom(null);
					break;
				case Keys.Subtract:
				case Keys.OemMinus:
					DelZoom(null);
					break;
				case Keys.R:
					SetZoom(1.0f);
					break;
				case Keys.C:
					StartCopy(false, false);
					break;
				case Keys.V:
					StartPaste(e.Alt);
					break;
				case Keys.X:
					StartCopy(true, e.Alt);
					break;
			}
		}

		private void frmEditor_Deactivate(object sender, EventArgs e) {
#if MORE_SPEED
			mFormIsActive = false;
#endif
		}

		private void frmEditor_Activated(object sender, EventArgs e) {
#if MORE_SPEED
			mFormIsActive = true;
#endif
		}
		#endregion

		#region ScrollBar Events
		private void MapVScrollBar_Scroll(object sender, ScrollEventArgs e) {
			RenderDisplayMap.Invalidate();
		}

		private void MapHScrollBar_Scroll(object sender, ScrollEventArgs e) {
			RenderDisplayMap.Invalidate();
		}

		private void TextureHScrollBar_Scroll(object sender, ScrollEventArgs e) {
			if (e.OldValue < e.NewValue) // move down
			{
				mMarkerRectangle.Y--;
			} else {
				mMarkerRectangle.Y++;
			}
			RenderDisplayTexture.Invalidate();
		}

		private void AnimationsVScrollBar_Scroll(object sender, ScrollEventArgs e) {
			RenderDisplayAnimations.Invalidate();
		}

		private void ObjectsVScrollBar_Scroll(object sender, ScrollEventArgs e) {
			RenderDisplayObjects.Invalidate();
		}

		private void AnimationsHScrollBar_Scroll(object sender, ScrollEventArgs e) {
			RenderDisplayAnimations.Invalidate();
		}

		private void ObjectsHScrollBar_Scroll(object sender, ScrollEventArgs e) {
			RenderDisplayObjects.Invalidate();
		}
		#endregion

		#region (File) Menu Events
		private void MenuFileNew_Click(object sender, EventArgs e) {
			var frm = new frmNewMap();
			frm.ShowDialog();
			if (frm.OKPressed == false) {
				return;
			}

			mTileMap = new TileMap(frm.txtName.Text, int.Parse(frm.txtWidth.Text), int.Parse(frm.txtHeight.Text));

			// clear Project
			ProjectTree.Nodes.Clear();
			mCurrentLayer = -1;
			mTextureRect = Rectangle.Empty;
			mPreviewTileset = null;
			mCursorCell.X = mCursorCell.Y = -1;
			mLastTilesetIndex.Clear();
			mLastAutotileIndex.Clear();
			mLastAnimationIndex.Clear();
			mLastObjectIndex.Clear();
			mUndoQueue.Clear();
			mRedoQueue.Clear();

			// Add Project Main Map
			ProjectTree.Nodes.Add(mTileMap.Name);
			ProjectTree.Nodes[0].ImageIndex = 0;
			ProjectTree.Nodes[0].SelectedImageIndex = 0;
			ProjectTree.Nodes[0].Tag = mTileMap.Name;
			ProjectTree.Nodes[0].ContextMenuStrip = ProjectTreeContext;

			// Add Collision				
			ProjectTree.Nodes[0].Nodes.Add(COLLISION_LAYER_NAME);
			ProjectTree.Nodes[0].Nodes[0].ImageIndex = 4;
			ProjectTree.Nodes[0].Nodes[0].SelectedImageIndex = 4;
			ProjectTree.Nodes[0].Nodes[0].Tag = COLLISION_LAYER_NAME;

			// Add first BG & FG
			AddLayerToTree("Hintergrund Ebene 1", true, 1, true, false, true);
			AddLayerToTree("Vordergrund Ebene 1", true, 3, true, false, false);

			ProjectTree.ExpandAll();

			// auto-select BG 1 (0=Collision, 1=BG, 2=FG)
			ProjectTree.SelectedNode = ProjectTree.Nodes[0].Nodes[1];
		}

		private void MenuFileOpen_Click(object sender, EventArgs e) {
			using (var dlg = new OpenFileDialog()) {
				dlg.Filter = "TileMap File (*.bmap;*.xnb)|*.bmap;*.xnb";
				dlg.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + mBasicContentDirectory, @"bMaps\");
				if (dlg.ShowDialog() != DialogResult.OK) {
					return;
				}

				LoadMap(dlg.FileName);
			}
		}

		private void MenuFileSave_Click(object sender, EventArgs e) {
			if (ProjectTree.Nodes.Count == 0 || ProjectTree.Nodes[0].Nodes.Count <= 1) {
				MessageBox.Show("Es gibt noch nixx zum speichern :|");
				return;
			}

			using (var dlg = new SaveFileDialog()) {
				dlg.Filter = "TileMap File (*.bmap)|*.bmap";
				dlg.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + mBasicContentDirectory, @"bMaps\");
				dlg.FileName = mTileMap.Name;
				if (dlg.ShowDialog() != DialogResult.OK) {
					return;
				}

				var watch = Stopwatch.StartNew();
				mTileMap.Save(dlg.FileName);
				MessageBox.Show("Speichern erfolgreich abgeschlossen!\nBenötigte zeit: " + (watch.ElapsedMilliseconds / 1000) + "sec");
			}
		}

		private void MenuEditorExit_Click(object sender, EventArgs e) {
			Close();
		}

		private void MenuToolStripUndoAction_Click(object sender, EventArgs e) {
			Undo();
		}

		private void MenuToolStripRedoAction_Click(object sender, EventArgs e) {
			Redo();
		}

		private void MenuExtrasMapPreview_Click(object sender, EventArgs e) {
			if (mTileMap == null || mTileMap.Width == 0 || mTileMap.Height == 0) {
				return;
			}

			var watch = Stopwatch.StartNew();
			var pp = GraphicsDevice.PresentationParameters;
			var renderTarget = new RenderTarget2D(GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight);
			var toDelete = new List<string>();
			var mapBmp = new Bitmap(mTileMap.WidthInPixels, mTileMap.HeightInPixels);
			var g = Graphics.FromImage(mapBmp);

			Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Preview");

			// reset MapView to always display first Screen
			SetZoom(1.0f);
			MapVScrollBar.Value = 0;
			MapHScrollBar.Value = 0;
			mCamera.X = 0;
			mCamera.Y = 0;

			var end = Point2D.Zero;
			var viewable = new Point2D(RenderDisplayMap.Width / mCamera.TileWidth, RenderDisplayMap.Height / mCamera.TileHeight);

			for (var mapX = 0; mapX < mTileMap.Width; mapX += viewable.X) {
				for (var mapY = 0; mapY < mTileMap.Height; mapY += viewable.Y) {
					GraphicsDevice.SetRenderTarget(renderTarget);
					GraphicsDevice.Clear(Color.Black);

					var start = new Point2D(mapX, mapY);
					end.X = Math.Min(start.X + viewable.X, mTileMap.Width);
					end.Y = Math.Min(start.Y + viewable.Y, mTileMap.Height);

					mSpriteBatch.Begin();
					mTileMap.Draw(mSpriteBatch, mCamera, mGameTime.ElapsedGameTime.TotalSeconds, (ETileDrawType.BackGround | ETileDrawType.ForeGround | ETileDrawType.Animation), start, end, true);
					mSpriteBatch.End();

					GraphicsDevice.SetRenderTarget(null);

					var texPath = String.Format(@"{0}Preview\{1}_{2}x{3}.png", AppDomain.CurrentDomain.BaseDirectory, mTileMap.Name, mapX, mapY);
					renderTarget.SaveAsPng(File.OpenWrite(texPath), renderTarget.Width, renderTarget.Height);
					using (var img = Image.FromFile(texPath)) {
						g.DrawImage(img, new Point(mapX * mCamera.TileWidth, mapY * mCamera.TileHeight));
					}
					//mapBmp.Save( String.Format( @"{0}Preview\{1}_Full_{2}x{3}.png", AppDomain.CurrentDomain.BaseDirectory, mTileMap.Name, mapX, mapY ), System.Drawing.Imaging.ImageFormat.Png );

					toDelete.Add(texPath);
				}
			}


			// save & clean
			try {
				g.Save();
				mapBmp.Save(AppDomain.CurrentDomain.BaseDirectory + @"Preview\" + mTileMap.Name + "_Full.png", ImageFormat.Png);
				mapBmp.Dispose();
				g.Dispose();
			} catch (Exception ex) {
				Debug.WriteLine(ex);
			}

			foreach (var filepath in toDelete) {
				try {
					File.Delete(filepath);
				} catch {
				}
			}
			toDelete.Clear();

			MessageBox.Show("Preview erstellt!\nBenötigte Zeit: " + (watch.ElapsedMilliseconds / 1000) + "sec");
			watch.Stop();
		}

		private void MenuExtrasMapConvert_Click(object sender, EventArgs e) {
			string filepath;
			using (var dlg = new OpenFileDialog()) {
				dlg.Filter = "Free World Map (*.bmap)|*.bmap";
				if (dlg.ShowDialog(this) != DialogResult.OK) {
					return;
				}

				filepath = dlg.FileName;
			}

			var con = new Converter30();
			var map = con.Convert(filepath);
			if (map == null) {
				MessageBox.Show("Fehler beim aktualisieren der Map..", "Aktualisierungsfehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			map.FixxMap();
			using (var dlg = new SaveFileDialog()) {
				dlg.Filter = "Free World Map (*.bmap)|*.bmap";
				dlg.FileName = map.Name;
				if (dlg.ShowDialog(this) != DialogResult.OK) {
					return;
				}

				map.Save(dlg.FileName);
			}

			MessageBox.Show("Convertierung erfolgreich");
		}

		private void MenuAbout_Click(object sender, EventArgs e) {
			const string desc = @"Map Editor für das Free World Projekt.

© 2010 - 2011 GodLesZ";
			using (var dlg = new frmAboutBox(desc)) {
				dlg.ShowDialog();
			}
		}

		private void ProjectTreeContextEditFog_Click(object sender, EventArgs e) {
			var prevDense = mTileMap.FogDense;
			var prevIndex = mTileMap.FogIndex;
			var prevColor = mTileMap.FogColor;

			// to see Fog Preview
			if (MenuToolStripShowFog.Checked == false) {
				MenuToolStripShowFog.PerformClick();
			}

			var frm = new frmFog(GraphicsDevice, mSpriteBatch, mTileMap.FogIndex, mTileMap.FogDense, mTileMap.FogColor);
			frm.OnDense += frm_OnDense;
			frm.OnFog += frm_OnFog;
			frm.OnColor += frm_OnColor;
			frm.ShowDialog();

			if (frm.FogIndex == -1) {
				mTileMap.FogIndex = prevIndex;
				mTileMap.FogDense = prevDense;
				mTileMap.FogColor = prevColor;
			} else {
				mTileMap.FogIndex = FileLists.Instance.Fogs[frm.FogIndex].Filename;
				mTileMap.FogDense = frm.FogDense;
				mTileMap.FogColor = frm.FogColor;
			}
			frm.Dispose();
		}

		private void frm_OnColor(Color color) {
			mTileMap.FogColor = color;
		}

		private void frm_OnFog(string index) {
			mTileMap.FogIndex = index;
		}

		private void frm_OnDense(float fogDense) {
			mTileMap.FogDense = fogDense;
		}
		#endregion

		#region DrawMode Buttons
		private void MenuToolStripDrawNormalButton_Click(object sender, EventArgs e) {
			if (MenuToolStripDrawNormalButton.Checked) {
				mDrawMode |= EDrawMode.Draw;
				mDrawMode &= ~EDrawMode.Erase;

				MenuToolStripDrawEraseButton.Checked = false;
			} else {
				mDrawMode &= ~EDrawMode.Draw;
				mDrawMode |= EDrawMode.Erase;

				MenuToolStripDrawEraseButton.Checked = true;
			}
		}

		private void MenuToolStripDrawEraseButton_Click(object sender, EventArgs e) {
			if (MenuToolStripDrawEraseButton.Checked) {
				mDrawMode |= EDrawMode.Erase;
				mDrawMode &= ~EDrawMode.Draw;

				MenuToolStripDrawNormalButton.Checked = false;
			} else {
				mDrawMode &= ~EDrawMode.Erase;
				mDrawMode |= EDrawMode.Draw;

				MenuToolStripDrawNormalButton.Checked = true;
			}
		}

		private void MenuToolStripDrawFillButton_Click(object sender, EventArgs e) {
			if (MenuToolStripDrawFillButton.Checked) {
				mDrawMode |= EDrawMode.Fill;
			} else {
				mDrawMode &= ~EDrawMode.Fill;
			}
		}

		private void MenuToolStripDrawRectangleButton_Click(object sender, EventArgs e) {
			mMarkerRectangle = Rectangle.Empty;
			if (MenuToolStripDrawRectangleButton.Checked) {
				mDrawMode |= EDrawMode.Rectangle;
			} else {
				mDrawMode &= ~EDrawMode.Rectangle;
			}
		}

		private void MenuToolStripDrawRotateButton_Click(object sender, EventArgs e) {
			if (MenuToolStripDrawRotateButton.Checked) {
				mDrawMode |= EDrawMode.Rotate;
			} else {
				mDrawMode &= ~EDrawMode.Rotate;
			}
		}

		private void MenuToolStripDrawFlipButton_Click(object sender, EventArgs e) {
			if (MenuToolStripDrawFlipButton.Checked) {
				mDrawMode |= EDrawMode.Flipping;
			} else {
				mDrawMode &= ~EDrawMode.Flipping;
			}
		}
		#endregion

		#region ProjectTree + ContextMenu
		private void ProjectTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
			// @BUG: Windows.Forms wont select on right-click, so we have to pre-select
			if (e.Button != MouseButtons.Right) {
				return; // handled in AfterSelect
			}

			if (ProjectTree == null || ProjectTree.SelectedNode == e.Node) {
				return; // all went fine
			}

			ProjectTree.SelectedNode = e.Node;
		}

		private void mapGrößeÄndernToolStripMenuItem_Click(object sender, EventArgs e) {
			var frm = new frmNewMap {
				txtName = {
					Text = mTileMap.Name,
					Enabled = false
				},
				txtWidth = {
					Text = mTileMap.Width.ToString(CultureInfo.InvariantCulture)
				},
				txtHeight = {
					Text = mTileMap.Height.ToString(CultureInfo.InvariantCulture)
				}
			};
			frm.ShowDialog();
			if (frm.OKPressed == false) {
				return;
			}

			var newW = int.Parse(frm.txtWidth.Text);
			var newH = int.Parse(frm.txtHeight.Text);
			if (newW == mTileMap.Width && newH == mTileMap.Height) {
				MessageBox.Show("Größe is gleich...", ",,!,,", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (newH < 1 || newW < 1) {
				MessageBox.Show("Die Map sollte mind. eine Zelle groß/klein sein...", ",,!,,", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			mTileMap.Resize(newW, newH);
			mTileMap.CollisionLayer = new TileCollisionLayer(mTileMap.CollisionLayer.LayoutMap, newW, newH);

			for (var i = 0; i < mTileMap.Layers.Count; i++) {
				mTileMap.Layers[i] = new TileLayer(mTileMap.Layers[i], newW, newH);
			}

			ProjectTree.Nodes[0].Text = BuildMapName();


			// reset Cursor
			mCursorCell = new Point2D(0, 0); // let the Logic fix it
			AdjustFormScrollbars(true);
		}

		private void mapNameÄndernToolStripMenuItem_Click(object sender, EventArgs e) {
			var frm = new frmNewMap {
				txtName = {
					Text = mTileMap.Name
				},
				txtWidth = {
					Text = mTileMap.Width.ToString(CultureInfo.InvariantCulture),
					Enabled = false
				},
				txtHeight = {
					Text = mTileMap.Height.ToString(CultureInfo.InvariantCulture),
					Enabled = false
				}
			};
			frm.ShowDialog();
			if (frm.OKPressed == false) {
				return;
			}

			var newName = frm.txtName.Text;
			if (newName == mTileMap.Name) {
				MessageBox.Show("Name is gleich...", ",,!,,", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			mTileMap.Name = newName;

			ProjectTree.Nodes[0].Text = BuildMapName();
		}

		private void ProjectTreeContext_Opening(object sender, CancelEventArgs e) {
			// select Project Root Layer to avoid bad Context menus
			ProjectTree.SelectedNode = ProjectTree.Nodes[0];
		}

		private void ProjectTree_AfterSelect(object sender, TreeViewEventArgs e) {
			if (ProjectTree.SelectedNode == null || ProjectTree.Nodes.Count == 0) {
				return;
			}

			if (ProjectTree.SelectedNode.Text == COLLISION_LAYER_NAME) {
				mDrawMode |= EDrawMode.Collision;
				mDrawMode &= ~EDrawMode.Draw;
				mDrawMode &= ~EDrawMode.Erase;

				MenuToolStripDrawEraseButton.Checked = false;
				MenuToolStripDrawEraseButton.Enabled = false;
				MenuToolStripDrawNormalButton.Checked = false;
				MenuToolStripDrawNormalButton.Enabled = false;

				mPreviewTileset = null;
				mTextureRect = Rectangle.Empty;
				comboTilesets.Enabled = false;
				comboAutotiles.Enabled = false;
				comboAnimations.Enabled = false;
				comboObjects.Enabled = false;

				if (MenuToolStripShowCollisionLayer.Checked == false) {
					MenuToolStripShowCollisionLayer.PerformClick();
				}

				SetLayerStatus(COLLISION_LAYER_NAME);

				return;
			}
			if ((mDrawMode & EDrawMode.Collision) > 0) {
				mDrawMode &= ~EDrawMode.Collision;
				mDrawMode &= ~EDrawMode.Erase;
				mDrawMode |= EDrawMode.Draw;

				MenuToolStripDrawNormalButton.Checked = true;
				MenuToolStripDrawNormalButton.Enabled = true;
				MenuToolStripDrawEraseButton.Checked = false;
				MenuToolStripDrawEraseButton.Enabled = true;
			}

			// Root selected?
			if (ProjectTree.SelectedNode == ProjectTree.Nodes[0]) {
				comboTilesets.Enabled = false;
				comboAutotiles.Enabled = false;
				comboAnimations.Enabled = false;
				comboObjects.Enabled = false;
				mCurrentLayer = -1;
				return;
			}


			int i;
			for (i = 0; i < mTileMap.Layers.Count; i++) {
				if (mTileMap.Layers[i].Name == (string)ProjectTree.SelectedNode.Tag) {
					break;
				}
			}

			if (i >= mTileMap.Layers.Count) {
				// Error Msg
				return;
			}

			comboTilesets.Enabled = true;
			comboAutotiles.Enabled = true;
			comboAnimations.Enabled = true;
			comboObjects.Enabled = true;

			mDrawMode &= ~EDrawMode.Collision;
			mCurrentLayer = i;
			SetLayerStatus(mTileMap.Layers[mCurrentLayer].Name);

			SetLastTilesetIndex();
			SetLastAutotileIndex();
			SetLastAnimationIndex();
		}

		private void ProjectTreeContextAddLayer_Click(object sender, EventArgs e) {
			AddLayerToTree("neue Ebene", true, -1, true);
		}

		private void ProjectTreeNodeContext_Opening(object sender, CancelEventArgs e) {
			var lastBg = GetLastBGIndex();

			ProjectTreeNodeContextMoveUp.Enabled = true;
			ProjectTreeNodeContextMoveDown.Enabled = true;

			// letzte Node
			if (ProjectTree.SelectedNode.Index >= ProjectTree.Nodes[0].Nodes.Count - 1) {
				ProjectTreeNodeContextMoveDown.Enabled = false;
			}

			// erste oder zweite
			if (ProjectTree.SelectedNode.Index <= 1) {
				ProjectTreeNodeContextMoveUp.Enabled = false;
			}

			// letzte BG?
			if (lastBg != -1 && ProjectTree.SelectedNode.Index - 1 == lastBg) {
				ProjectTreeNodeContextMoveDown.Enabled = false;
			}

			// letzte BG +1 (erste FG)?
			if (lastBg != -1 && ProjectTree.SelectedNode.Index - 1 == lastBg + 1) {
				ProjectTreeNodeContextMoveUp.Enabled = false;
			}
		}

		private void ProjectTreeNodeContextDelete_Click(object sender, EventArgs e) {
			if (ProjectTree.SelectedNode == null || ProjectTree.SelectedNode == ProjectTree.Nodes[0]) {
				return;
			}

			var index = ProjectTree.SelectedNode.Index;

			if (index == 0) {
				return; // can't delete Collision(0)
			}

			mTileMap.Layers.RemoveAt(index - 1); // Projecttree has Collision Layer too

			ProjectTree.Nodes[0].Nodes.RemoveAt(index);
			ProjectTree.Nodes[0].Text = BuildMapName();

			ProjectTree.SelectedNode = ProjectTree.Nodes[0].Nodes[1];
		}

		private void ProjectTreeNodeContextMoveUp_Click(object sender, EventArgs e) {
			if (ProjectTree.SelectedNode == null) {
				MessageBox.Show("No Node selected oO");
				return;
			}

			if (ProjectTree.SelectedNode == ProjectTree.Nodes[0].Nodes[0]) {
				return;
			}

			Swap(ProjectTree.SelectedNode.Index, ProjectTree.SelectedNode.Index - 1);

			ProjectTree.Invalidate();
			RenderDisplayMap.Invalidate();
		}

		private void ProjectTreeNodeContextMoveDown_Click(object sender, EventArgs e) {
			if (ProjectTree.SelectedNode == null) {
				MessageBox.Show("No Node selected oO");
				return;
			}

			if (ProjectTree.SelectedNode == ProjectTree.Nodes[0].Nodes[0]) {
				return;
			}

			Swap(ProjectTree.SelectedNode.Index, ProjectTree.SelectedNode.Index + 1);

			ProjectTree.Invalidate();
			RenderDisplayMap.Invalidate();
		}

		private void Swap(int fromIndex, int toIndex) {
			var copyNode = (TreeNode)ProjectTree.Nodes[0].Nodes[fromIndex].Clone();
			ProjectTree.Nodes[0].Nodes.RemoveAt(fromIndex);
			ProjectTree.Nodes[0].Nodes.Insert(toIndex, copyNode);

			// TileMap dos not have Collision Layer in Layers[]
			fromIndex--;
			toIndex--;
			var fromLayer = (TileLayer)mTileMap.Layers[fromIndex].Clone();
			mTileMap.Layers.RemoveAt(fromIndex);
			mTileMap.Layers.Insert(toIndex, fromLayer);
		}

		private void ProjectTreeNodeContextRename_Click(object sender, EventArgs e) {
			if (ProjectTree.SelectedNode == null || ProjectTree.SelectedNode == ProjectTree.Nodes[0]) {
				return;
			}

			var frm = new frmNewLayer {
				txtName = {
					Text = ProjectTree.SelectedNode.Text
				},
				chkBackground = {
					Checked = mTileMap.Layers[ProjectTree.SelectedNode.Index - 1].IsBackground
				},
				chkForeground = {
					Checked = !mTileMap.Layers[ProjectTree.SelectedNode.Index - 1].IsBackground
				}
			};
			frm.chkBackground.Enabled = false;
			frm.chkForeground.Enabled = false;
			frm.ShowDialog();
			if (frm.OKPressed == false) {
				return;
			}

			if (frm.txtName.Text == ProjectTree.SelectedNode.Text) {
				return;
			}

			mTileMap.Layers[mCurrentLayer].Name = frm.txtName.Text;
			ProjectTree.Nodes[0].Nodes[ProjectTree.SelectedNode.Index].Tag = frm.txtName.Text;
			ProjectTree.Nodes[0].Nodes[ProjectTree.SelectedNode.Index].Text = frm.txtName.Text;
			ProjectTree.Invalidate();
		}
		#endregion

		#region TextureTabControl Events
		private void TextureTabControl_SelectedIndexChanged(object sender, EventArgs e) {
			switch (TextureTabControl.SelectedIndex) {
				case 0:
					mDrawMode &= ~(EDrawMode.Autotile | EDrawMode.Animation | EDrawMode.Objects);
					RenderDisplayMap.Invalidate();
					break;
				case 1:
					mDrawMode |= EDrawMode.Autotile;
					mDrawMode &= ~(EDrawMode.Animation | EDrawMode.Objects);
					RenderDisplayAutotile.Invalidate();
					break;
				case 2:
					mDrawMode |= EDrawMode.Animation;
					mDrawMode &= ~(EDrawMode.Autotile | EDrawMode.Objects);
					RenderDisplayAnimations.Invalidate();
					break;
				case 3:
					mDrawMode |= EDrawMode.Objects;
					mDrawMode &= ~(EDrawMode.Autotile | EDrawMode.Animation);
					RenderDisplayObjects.Invalidate();
					break;
			}

			AdjustScrollBars();
		}
		#endregion

		#region RenderDisplayMap Events
		private void MapDisplay_OnInitialize(object sender, EventArgs e) {
			EngineCore.Initialize("Content", GraphicsDevice, RenderDisplayMap.Services);

			mSpriteBatch = new SpriteBatch(GraphicsDevice);
			mEraseTexture = DrawHelper.Bitmap2Texture(Resources.Mode_Erase);
			mFlipHTexture = DrawHelper.Bitmap2Texture(Resources.Flip_H);
			mFlipVTexture = DrawHelper.Bitmap2Texture(Resources.Flip_V);
			mLineTexture = DrawHelper.Rect2Texture(1, 1, 0, Color.White);

			mCamera = new EngineCamera(GraphicsDevice);
		}

		private void MapDisplay_OnDraw(object sender, EventArgs e) {
			mGameTime.Start();
			GraphicsDevice.Clear(Color.Black);

#if MORE_SPEED
			if( mFormIsActive == false )
				return;
#endif
			DrawLogic();
			RenderLogic();
			mGameTime.Stop();
		}

		private Point2D mMouseWheelStart = new Point2D(-1, -1);

		private void MapDisplay_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Middle) {
				Cursor = Cursors.SizeAll;
				mMouseWheelStart = new Point2D(e.Location.X, e.Location.Y);
				return;
			}

			mMouseWheelStart = new Point2D(-1, -1);
			if (e.Button == MouseButtons.Right) {
				if (mDrawMode.Has(EDrawMode.Rectangle)) {
					if (mMarkerRectangle != Rectangle.Empty) {
						mMarkerRectangle = Rectangle.Empty;
						return;
					}

					Mouse.WindowHandle = RenderDisplayMap.Handle;
					var p = new Point2D(mCursorCell.X, mCursorCell.Y);

					if (p.X < 0 || p.Y < 0) {
						mMarkerRectangle = Rectangle.Empty;
						return;
					}

					mMarkerRectangle = new Rectangle(p.X, p.Y, 1, 1);
					mMouseOnMapRightButton = true;
				} else if (mDrawMode.Has(EDrawMode.Rotate | EDrawMode.Flipping)) {
					mMouseOnMapRightButton = true;
				}

				mMouseOnMapLeftButton = false;
				return;
			}

			mMouseOnMapLeftButton = true;
		}

		private void MapDisplay_MouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Middle) {
				mMouseWheelStart = new Point2D(-1, -1);
				Cursor = Cursors.Default;
				return;
			}

			if (e.Button == MouseButtons.Right) {
				mMouseOnMapRightButton = false;
				return;
			}

			mMouseOnMapLeftButton = false;
		}

		private void MapDisplay_MouseMove(object sender, MouseEventArgs e) {
			if (mMouseWheelStart.X != -1 && mMouseWheelStart.Y != -1) {
				Cursor = Cursors.SizeAll;
				if (MapHScrollBar.Value > 0 && mMouseWheelStart.X > e.Location.X) // move left
				{
					MapHScrollBar.Value--;
				} else if (MapHScrollBar.Value < MapHScrollBar.Maximum && mMouseWheelStart.X < e.Location.X) // move right
				{
					MapHScrollBar.Value++;
				}

				if (MapVScrollBar.Value > 0 && mMouseWheelStart.Y > e.Location.Y) // move up
				{
					MapVScrollBar.Value--;
				} else if (MapVScrollBar.Value < MapHScrollBar.Maximum && mMouseWheelStart.Y < e.Location.Y) // move down
				{
					MapVScrollBar.Value++;
				}
				mMouseWheelStart = new Point2D(e.Location.X, e.Location.Y);
				return;
			}

			if (mMouseOnMapRightButton == false || (mDrawMode & EDrawMode.Rectangle) == 0 || mMarkerRectangle == Rectangle.Empty) {
				return;
			}

			Mouse.WindowHandle = RenderDisplayMap.Handle;
			var p = new Point2D(mCursorCell.X, mCursorCell.Y);

			if (p.X < 0 || p.Y < 0) {
				//mAuswahlRectangle = Rectangle.Empty;
				return;
			}

			p.X++;
			p.Y++;

			mMarkerRectangle.Width = (mMarkerRectangle.X - p.X);
			mMarkerRectangle.Height = (mMarkerRectangle.Y - p.Y);
			if (mMarkerRectangle.Height < 0) {
				mMarkerRectangle.Height *= -1;
			}
			if (mMarkerRectangle.Width < 0) {
				mMarkerRectangle.Width *= -1;
			}

			if (mMarkerRectangle.Width < 1) {
				mMarkerRectangle.Width = 1;
			}
			if (mMarkerRectangle.Height < 1) {
				mMarkerRectangle.Height = 1;
			}

			CheckMapAutoScroll();
		}

		private void MapDisplay_MouseClick(object sender, MouseEventArgs e) {
			// one-click things
			if (mCurrentLayer == -1) {
				return;
			}

			var startPoint = mCursorCell;
			//var endPoint = new Point2D(mTileMap.Width, mTileMap.Height);
			if (mMarkerRectangle != Rectangle.Empty) {
				if (mDrawMode.Has(EDrawMode.Fill) || startPoint.X < (mMarkerRectangle.X + MapHScrollBar.Value) || startPoint.X >= (mMarkerRectangle.X + mMarkerRectangle.Width + MapHScrollBar.Value)) {
					startPoint.X = (mMarkerRectangle.X + MapHScrollBar.Value);
				}
				if (mDrawMode.Has(EDrawMode.Fill) || startPoint.Y < (mMarkerRectangle.Y + MapVScrollBar.Value) || startPoint.Y >= (mMarkerRectangle.Y + mMarkerRectangle.Height + MapVScrollBar.Value)) {
					startPoint.Y = (mMarkerRectangle.Y + MapVScrollBar.Value);
				}
				//endPoint = new Point2D((mMarkerRectangle.X + MapHScrollBar.Value) + mMarkerRectangle.Width, (mMarkerRectangle.Y + MapVScrollBar.Value) + mMarkerRectangle.Height);
			}

			if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && mDrawMode.Has(EDrawMode.Flipping) && mCurrentLayer != -1) {
				var cell = GetCell(startPoint);
				if (cell.IsEqualTo(TileCell.Empty) == false) {
					if (e.Button == MouseButtons.Left && Keyboard.GetState().IsCtrlUp()) {
						if ((cell.FlipEffect & SpriteEffects.FlipHorizontally) == SpriteEffects.FlipHorizontally) {
							cell.FlipEffect &= ~SpriteEffects.FlipHorizontally;
						} else {
							cell.FlipEffect |= SpriteEffects.FlipHorizontally;
						}
					} else if ((Keyboard.GetState().IsCtrlDown() && e.Button == MouseButtons.Left) || e.Button == MouseButtons.Right) {
						if ((cell.FlipEffect & SpriteEffects.FlipVertically) == SpriteEffects.FlipVertically) {
							cell.FlipEffect &= ~SpriteEffects.FlipVertically;
						} else {
							cell.FlipEffect |= SpriteEffects.FlipVertically;
						}
					}

					SetCell(startPoint, cell, false);
				}
			}
		}
		#endregion

		#region RenderDisplayTilesets Events
		private void TextureDisplay_OnDraw(object sender, EventArgs e) {
			GraphicsDevice.Clear(Color.White);

#if MORE_SPEED
			if( mFormIsActive == false )
				return;
#endif

			if (mPreviewTileset == null) {
				return;
			}

			if (TextureTabControl.SelectedIndex != 0) {
				return;
			}

			mSpriteBatch.Begin();
			mSpriteBatch.Draw(mPreviewTileset, new Rectangle(-(TilesetHScrollBar.Value * Constants.TileWidth), -(TilesetVScrollBar.Value * Constants.TileHeight), mPreviewTileset.Width, mPreviewTileset.Height), Color.White);
			mSpriteBatch.End();

			// TileDisplay Rectangle
			if (mTextureRect != Rectangle.Empty) {
				var rect = new Rectangle((mTextureRect.X - TilesetHScrollBar.Value) * Constants.TileWidth, (mTextureRect.Y - TilesetVScrollBar.Value) * Constants.TileHeight, mTextureRect.Width * Constants.TileWidth, mTextureRect.Height * Constants.TileHeight);

				var rectangleTexture = DrawHelper.Rect2Texture(rect.Width, rect.Height, 2, Color.White);

				mSpriteBatch.Begin();
				mSpriteBatch.Draw(rectangleTexture, rect, Color.Black);
				mSpriteBatch.End();
			}
		}

		private void TextureDisplay_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button != MouseButtons.Left) {
				return;
			}
			if (mPreviewTileset == null) {
				return;
			}

			mMouseOnTexture = true;

			Mouse.WindowHandle = RenderDisplayTexture.Handle;
			var p = new Point2D(Mouse.GetState().X, Mouse.GetState().Y);

			if (p.X < 0 || p.Y < 0) {
				mTextureRect = Rectangle.Empty;
				return;
			}

			p.X /= Constants.TileWidth;
			p.Y /= Constants.TileHeight;
			p.X += TilesetHScrollBar.Value;
			p.Y += TilesetVScrollBar.Value;

			mTextureRect = new Rectangle(p.X, p.Y, 1, 1);
		}

		private void TextureDisplay_MouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				mMouseOnTexture = false;
			}
		}

		private void TextureDisplay_MouseMove(object sender, MouseEventArgs e) {
			if (mMouseOnTexture == false) {
				return;
			}

			Mouse.WindowHandle = RenderDisplayTexture.Handle;
			var p = new Point2D(Mouse.GetState().X, Mouse.GetState().Y);

			if (p.X < 0 || p.Y < 0 || p.X > RenderDisplayTexture.Width || p.Y > RenderDisplayTexture.Height) {
				return;
			}

			p.X /= Constants.TileWidth;
			p.Y /= Constants.TileHeight;
			p.X += TilesetHScrollBar.Value;
			p.Y += TilesetVScrollBar.Value;

			if (p.X < mTextureRect.X) {
				mTextureRect.X = p.X;
			}
			if (p.Y < mTextureRect.Y) {
				mTextureRect.Y = p.Y;
			}

			mTextureRect.Width = (p.X - mTextureRect.X + 1);
			mTextureRect.Height = (p.Y - mTextureRect.Y + 1);

			if (mTextureRect.Width < 1) {
				mTextureRect.Width = 1;
			}
			if (mTextureRect.Height < 1) {
				mTextureRect.Height = 1;
			}

			CheckTextureAutoScroll();
		}

		private void comboTextures_SelectedIndexChanged(object sender, EventArgs e) {
			if (mCurrentLayer == -1 || comboTilesets.SelectedItem == null) {
				mPreviewTileset = null;
				comboTilesets.SelectedIndex = 0;
				return;
			}

			mLastTilesetIndex[mCurrentLayer] = comboTilesets.SelectedIndex;
			var i = mLastTilesetIndex[mCurrentLayer];
			mPreviewTileset = EngineCore.ContentLoader.GetTileset(FileLists.Instance.Tilesets[i].Filename);
			RenderDisplayTexture.Invalidate();

			AdjustScrollBars();
		}
		#endregion

		#region RenderDisplayAutotiles Events
		private void RenderDisplayAutotiles_OnDraw(object sender, EventArgs e) {
			GraphicsDevice.Clear(Color.Transparent);

#if MORE_SPEED
			if( mFormIsActive == false )
				return;
#endif

			if (mPreviewAutotile == null) {
				return;
			}
			if (TextureTabControl.SelectedIndex != 1) {
				return;
			}

			mSpriteBatch.Begin();
			mSpriteBatch.Draw(mPreviewAutotile, new Rectangle(0, -(AutotilesVScrollBar.Value * Constants.TileHeight), mPreviewAutotile.Width, mPreviewAutotile.Height), Color.White);
			mSpriteBatch.End();
		}

		private void comboAutoTextures_SelectedIndexChanged(object sender, EventArgs e) {
			if (mCurrentLayer == -1 || comboAutotiles.SelectedItem == null) {
				mPreviewAutotile = null;
				comboAutotiles.SelectedIndex = 0;
				return;
			}

			mLastAutotileIndex[mCurrentLayer] = comboAutotiles.SelectedIndex;
			mPreviewAutotile = EngineCore.ContentLoader.GetAutotile(FileLists.Instance.Autotiles[mLastAutotileIndex[mCurrentLayer]].Filename);
			RenderDisplayAutotile.Invalidate();

			AdjustScrollBars();
		}
		#endregion

		#region RenderDisplayAnimations Events
		private void RenderDisplayAnimations_OnDraw(object sender, EventArgs e) {
			GraphicsDevice.Clear(Color.Black);

#if MORE_SPEED
			if( mFormIsActive == false )
				return;
#endif

			if (mPreviewAnimation == null) {
				return;
			}
			if (TextureTabControl.SelectedIndex != 2) {
				return;
			}

			// @TODO: Test it with scrollbar value
			//var basePos = new Point2D(-(AnimationsHScrollBar.Value*Constants.TileWidth), -(AnimationsVScrollBar.Value*Constants.TileHeight));
			var basePos = new Point2D(Constants.AnimationTilesetWidth, Constants.AnimationTilesetHeight);
			mSpriteBatch.Begin();
			mPreviewAnimation.Draw(mSpriteBatch, mCamera, mGameTime.ElapsedGameTime.TotalSeconds, basePos);
			mSpriteBatch.End();
		}

		private void comboAnimations_SelectedIndexChanged(object sender, EventArgs e) {
#if DEBUG
			if (mCurrentLayer == -1 || comboAnimations.SelectedItem == null) {
				mPreviewAnimation = null;
				if (mCurrentLayer != -1) {
					mLastAnimationIndex[mCurrentLayer] = -1;
				}
				if (comboAnimations.Items.Count > 0) {
					comboAnimations.SelectedIndex = 0;
				}
				return;
			}

			mLastAnimationIndex[mCurrentLayer] = comboAnimations.SelectedIndex;
			mPreviewAnimation = EngineCore.ContentLoader.GetAnimation(FileLists.Instance.Animations[mLastAnimationIndex[mCurrentLayer]].Filename);
			RenderDisplayAnimations.Invalidate();

			AdjustScrollBars();
#endif
		}
		#endregion

		#region RenderDisplayObjects Events
		private void RenderDisplayObjects_OnDraw(object sender, EventArgs e) {
			GraphicsDevice.Clear(Color.Transparent);

#if MORE_SPEED
			if( mFormIsActive == false )
				return;
#endif

			if (mPreviewObject == null) {
				return;
			}
			if (TextureTabControl.SelectedIndex != 3) {
				return;
			}

			mSpriteBatch.Begin();
			mSpriteBatch.Draw(mPreviewObject, new Rectangle(-(ObjectsHScrollBar.Value * Constants.TileWidth), -(ObjectsVScrollBar.Value * Constants.TileHeight), mPreviewObject.Width, mPreviewObject.Height), Color.White);
			mSpriteBatch.End();
		}

		private void comboObjects_SelectedIndexChanged(object sender, EventArgs e) {
			if (mCurrentLayer == -1 || comboObjects.SelectedItem == null) {
				mPreviewObject = null;
				comboObjects.SelectedIndex = 0;
				return;
			}

			mLastObjectIndex[mCurrentLayer] = comboObjects.SelectedIndex;
			mPreviewObject = EngineCore.ContentLoader.GetCharacter(FileLists.Instance.Characters[mLastObjectIndex[mCurrentLayer]].Filename);
			RenderDisplayObjects.Invalidate();

			AdjustScrollBars();
		}
		#endregion

		private void DrawLogic() {
			mNewState = Keyboard.GetState();
			mCamera.X = MapHScrollBar.Value * mCamera.TileWidth;
			mCamera.Y = MapVScrollBar.Value * mCamera.TileHeight;

			// seltsamer Bug...
			if (mMarkerRectangle.Width == 0 || mMarkerRectangle.Height == 0) {
				mMarkerRectangle = Rectangle.Empty;
			}

			if (mCurrentLayer == -1 && (mDrawMode & EDrawMode.Collision) == 0) {
				return;
			}

			Mouse.WindowHandle = RenderDisplayMap.Handle;
			mCursorCell = new Point2D(Mouse.GetState().X, Mouse.GetState().Y);

			if (mCursorCell.X < 0 || mCursorCell.Y < 0 || mCursorCell.X >= RenderDisplayMap.Width || mCursorCell.Y >= RenderDisplayMap.Height) {
				mCursorCell.X = mCursorCell.Y = -1;
				return;
			}

			mCursorCell.X /= mCamera.TileWidth;
			mCursorCell.Y /= mCamera.TileHeight;

			if (MapHScrollBar.Visible) {
				mCursorCell.X += MapHScrollBar.Value;
			}
			if (MapVScrollBar.Visible) {
				mCursorCell.Y += MapVScrollBar.Value;
			}

			if (mCursorCell.X >= mTileMap.Width || mCursorCell.Y >= mTileMap.Height) {
				SetStatus("Zelle: n/a");
				mCursorCell.X = mCursorCell.Y = -1;
				return;
			}

			mCursorCell.X = (int)MathHelper.Clamp(mCursorCell.X, 0, mTileMap.Width - 1);
			mCursorCell.Y = (int)MathHelper.Clamp(mCursorCell.Y, 0, mTileMap.Height - 1);

			var celltext = String.Format("Zelle: {0} / {1}", mCursorCell.X, mCursorCell.Y);
			if (mCurrentLayer != -1) {
				var statusCell = mTileMap.Layers[mCurrentLayer].GetCell(mCursorCell);
				celltext += String.Format(" [Tileset: {0}] [Move: {1}] [Rotation: {2}°] [Autotile: {3}] [Flip: {4}]", statusCell.TextureSource.TextureIndex, mTileMap.CollisionLayer.GetCell(mCursorCell.X, mCursorCell.Y), statusCell.Rotation * 60f, statusCell.AutoTextureType, statusCell.FlipEffect);
			}
			SetStatus(celltext);

			var startPoint = mCursorCell;
			var endPoint = new Point2D(mTileMap.Width, mTileMap.Height);
			if (mMarkerRectangle != Rectangle.Empty) {
				if (mDrawMode.Has(EDrawMode.Fill) || startPoint.X < mMarkerRectangle.X || startPoint.X >= (mMarkerRectangle.X + mMarkerRectangle.Width)) {
					startPoint.X = mMarkerRectangle.X;
				}
				if (mDrawMode.Has(EDrawMode.Fill) || startPoint.Y < mMarkerRectangle.Y || startPoint.Y >= (mMarkerRectangle.Y + mMarkerRectangle.Height)) {
					startPoint.Y = mMarkerRectangle.Y;
				}
				endPoint = new Point2D(mMarkerRectangle.X + mMarkerRectangle.Width, mMarkerRectangle.Y + mMarkerRectangle.Height);
			}


			if (mCurrentLayer == -1 && mDrawMode.HasNot(EDrawMode.Collision)) {
				return;
			}

			// "Pipetten" Funktion
			if (mDrawMode.HasNot(EDrawMode.Collision) && (mMouseOnMapLeftButton || mMouseOnMapRightButton) && mNewState.IsKeyDown(XnaKeys.LeftAlt)) {
				var cell = GetCell(startPoint);
				if (cell.TextureSource.TextureIndex == string.Empty) {
					return;
				}
				List<FileListEntry> searchList = (cell.IsAutoTexture ? FileLists.Instance.Autotiles : FileLists.Instance.Tilesets);
				for (var i = 0; i < searchList.Count; i++) {
					if (searchList[i].Filename == cell.TextureSource.TextureIndex) {
						if (cell.IsAutoTexture) {
							comboAutotiles.SelectedIndex = i;
							TextureTabControl.SelectedIndex = 1;
						} else {
							comboTilesets.SelectedIndex = i;
							TextureTabControl.SelectedIndex = 0;
						}
						break;
					}
				}
				return;
			}


			if (mMouseOnMapLeftButton) {
				// Delete tile(s)
				if (mDrawMode.Has(EDrawMode.Erase) && mDrawMode.HasNot(EDrawMode.Rotate | EDrawMode.Flipping)) {
					// Delete normal tiles from start to end
					if (mDrawMode.Has(EDrawMode.Fill) && mDrawMode.HasNot(EDrawMode.Animation)) {
						SetCells(startPoint, endPoint, TileCell.Empty);
						if (MenuSettingsOneTimeFill.Checked) {
							MenuToolStripDrawFillButton.PerformClick();
						}
						// Delete single tile
					} else if (mDrawMode.HasNot(EDrawMode.Animation)) {
						SetCell(startPoint, TileCell.Empty, false);
						// Delete a animation cell
					} else if (mDrawMode.Has(EDrawMode.Animation)) {
						mTileMap.AnimationLayer.SetCell(startPoint, null);
					}

					// Draw a normal tile
				} else if (mDrawMode.Has(EDrawMode.Draw) && mDrawMode.HasNot(EDrawMode.Rotate | EDrawMode.NotTilesetMode | EDrawMode.Flipping)) {
					// Nee a valid texture selection
					if (mTextureRect.Width > 0 || mTextureRect.Height > 0) {
						// Draw more than once?
						if (mDrawMode.Has(EDrawMode.Fill)) {
							// Draw from start to end
							SetCellGroups(startPoint, endPoint);
							if (MenuSettingsOneTimeFill.Checked) {
								MenuToolStripDrawFillButton.PerformClick();
							}
						} else {
							// Draw a single tile
							SetCellGroup(startPoint, false);
						}
					}
					// Draw a collision tile
				} else if (mDrawMode.Has(EDrawMode.Collision)) {
					// Get type of collision
					var drawType = ECollisionType.NotMoveable;
					if (mNewState.IsCtrlDown() || GetCapsLock) {
						drawType = ECollisionType.Moveable;
					} else if (mNewState.IsShiftDown() || GetScrollLock) {
						drawType = ECollisionType.Water;
					} else if (mNewState.IsKeyDown(XnaKeys.LeftAlt) /* || GetNumLock*/) {
						drawType = ECollisionType.Underwater;
					}

					// Fill collisions from start to end?
					if (mDrawMode.Has(EDrawMode.Fill)) {
						var baseType = mTileMap.CollisionLayer.GetCell(startPoint.X, startPoint.Y);
						for (var x = startPoint.X; x < endPoint.X; x++) {
							for (var y = startPoint.Y; y < endPoint.Y; y++) {
								if (MenuSettingsFillSameTexture.Checked && mTileMap.CollisionLayer.GetCell(x, y) != baseType) {
									continue;
								}
								mTileMap.CollisionLayer.SetCell(x, y, drawType);
							}
						}
						if (MenuSettingsOneTimeFill.Checked) {
							MenuToolStripDrawFillButton.PerformClick();
						}
					} else {
						// Just a single draw
						mTileMap.CollisionLayer.SetCell(startPoint, drawType);
					}
				}
			}

			if (mCurrentLayer == -1) {
				return;
			}

			if ((mMouseOnMapRightButton || mMouseOnMapLeftButton) && mDrawMode.Has(EDrawMode.Rotate) && mDrawMode.HasNot(EDrawMode.NotTilesetMode | EDrawMode.Flipping | EDrawMode.Collision)) {
				var cell = mTileMap.Layers[mCurrentLayer].GetCell(startPoint.X, startPoint.Y);
				if (cell.IsEqualTo(TileCell.Empty) == false && cell.TextureSource.TextureIndex != string.Empty && CanRotate(startPoint)) {
					var rotation = (mMouseOnMapRightButton ? 1.5f : -1.5f);
					if (mNewState.IsCtrlDown()) {
						rotation /= 10f;
					}
					cell.Rotation += rotation;
					if (cell.Rotation >= 6f || cell.Rotation <= -6f) {
						cell.Rotation = 0f;
					}
					mTileMap.Layers[mCurrentLayer].SetCell(startPoint, cell);

					Debug.WriteLine("Rotation: " + cell.Rotation);
				}
			} else if (mMouseOnMapLeftButton && mDrawMode.Has(EDrawMode.Autotile) && mDrawMode.HasNot(EDrawMode.Rotate | EDrawMode.Erase | EDrawMode.Collision)) {
				if (mDrawMode.Has(EDrawMode.Fill)) {
					for (var x = startPoint.X; x < endPoint.X; x++) {
						for (var y = startPoint.Y; y < endPoint.Y; y++) {
							UpdateAutoTiles(new Point2D(x, y), true);
						}
					}

					if (MenuSettingsOneTimeFill.Checked) {
						MenuToolStripDrawFillButton.PerformClick();
					}
				} else {
					UpdateAutoTiles(startPoint, true);
				}
			} else if (mMouseOnMapLeftButton && mDrawMode.Has(EDrawMode.Animation) && mDrawMode.HasNot(EDrawMode.Rotate | EDrawMode.Erase | EDrawMode.Collision)) {
				mTileMap.AnimationLayer.SetCell(startPoint, mPreviewAnimation);
			}
		}

		private void RenderLogic() {
			if (mTileMap == null) {
				return;
			}

			Rectangle rect;
			Point2D start = Point2D.Zero, part = Point2D.Zero, end = Point2D.Zero;
			start.X = (MapHScrollBar.Visible ? MapHScrollBar.Value : 0);
			start.Y = (MapVScrollBar.Visible ? MapVScrollBar.Value : 0);
			part.X = (RenderDisplayMap.Width / mCamera.TileWidth) + start.X + 1;
			part.Y = (RenderDisplayMap.Height / mCamera.TileHeight) + start.Y + 1;
			end.X = Math.Min(part.X, mTileMap.Width);
			end.Y = Math.Min(part.Y, mTileMap.Height);
			
			mSpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, mCamera.TransformMatrix);
			for (var i = 0; i < mTileMap.Layers.Count; i++) {
				float alphaMod;
				if (MenuToolStripShowAllLayersButton.Checked || i == mCurrentLayer) {
					alphaMod = 0f;
				} else if (MenuSettingsTransparentLayer.Checked == false) {
					alphaMod = -1f;
				} else {
					alphaMod = -0.5f;
				}
				mTileMap.Layers[i].Draw(mSpriteBatch, mCamera, start, end, alphaMod, false);

				#region Grid it
				if (MenuToolStripShowGridButton.Checked && i == mCurrentLayer) {
					for (var y = start.Y; y < end.Y; y++) {
						for (var x = start.X; x < end.X; x++) {
							if (MenuSettingsGridNonEmptyCells.Checked && mTileMap.Layers[i].GetCell(x, y).IsEqualTo(TileCell.Empty) == false) {
								continue;
							}
							rect = new Rectangle(x * mCamera.TileWidth, y * mCamera.TileHeight, mCamera.TileWidth, mCamera.TileHeight) {
								Width = 1,
								Height = mCamera.TileHeight
							};

							// | left 
							mSpriteBatch.DrawLine(mLineTexture, rect, (x == 0 ? Color.Red : Color.White));
							// | right
							rect.Width = 1;
							rect.Height = mCamera.TileHeight;
							rect.X += mCamera.TileWidth;
							mSpriteBatch.DrawLine(mLineTexture, rect, (x == mTileMap.Width - 1 ? Color.Red : Color.White));

							rect.X -= mCamera.TileWidth;

							// - top
							rect.Width = mCamera.TileWidth;
							rect.Height = 1;
							mSpriteBatch.DrawLine(mLineTexture, rect, (y == 0 ? Color.Red : Color.White));
							// - bottom
							rect.Width = mCamera.TileWidth;
							rect.Height = 1;
							rect.Y += mCamera.TileHeight;
							mSpriteBatch.DrawLine(mLineTexture, rect, (y == mTileMap.Height - 1 ? Color.Red : Color.White));
						}
					}
				}
				#endregion
			}

			mTileMap.AnimationLayer.Draw(mSpriteBatch, mCamera, mGameTime.ElapsedGameTime.TotalSeconds, start, end);

			if (MenuToolStripShowFog.Checked) {
				mTileMap.DrawFog(mSpriteBatch, mCamera, start, end);
			}

			if (MenuToolStripShowCollisionLayer.Checked) {
				mTileMap.CollisionLayer.Draw(mSpriteBatch, mCamera, start, end);
			}

			mSpriteBatch.End();

			if (mCurrentLayer == -1) {
				return;
			}

			var mapWidth = mTileMap.WidthInPixels;
			var mapHeight = mTileMap.HeightInPixels;
			rect = new Rectangle(mCursorCell.X * mCamera.TileWidth - mCamera.X, mCursorCell.Y * mCamera.TileHeight - mCamera.Y, Math.Max(mCamera.TileWidth, mTextureRect.Width * mCamera.TileWidth), Math.Max(mCamera.TileHeight, mTextureRect.Height * mCamera.TileHeight));
			if ((rect.X + rect.Width) > mapWidth) {
				rect.Width = (rect.X - mapWidth);
			}
			if ((rect.Y + rect.Height) > mapHeight) {
				rect.Height = (rect.Y - mapHeight);
			}


			// @TODO: "Pipetten" Preview 
			if (mDrawMode.HasNot(EDrawMode.Collision) && mNewState.IsKeyDown(XnaKeys.LeftAlt)) {
				if (rect.Width > 0 && rect.Height > 0) {
					mSpriteBatch.Begin();
					mSpriteBatch.Draw(DrawHelper.Rect2Texture(mCamera.TileWidth, mCamera.TileHeight, Math.Max(1, mCamera.TileWidth / 5), Color.DarkGreen), new Rectangle(rect.X, rect.Y, mCamera.TileWidth, mCamera.TileHeight), Color.White);
					mSpriteBatch.End();
				}
				return;
			}

			mSpriteBatch.Begin();

			// MouseCursor Rectangle
			if (mDrawMode.Has(EDrawMode.Draw) && mDrawMode.HasNot(EDrawMode.Rotate | EDrawMode.NotTilesetMode | EDrawMode.Flipping) && mCursorCell.X != -1 && mCursorCell.Y != -1) {
				if (rect.Width > 0 && rect.Height > 0) {
					var srcRect = new Rectangle();

					if (mTextureRect != Rectangle.Empty) {
						srcRect.X = (mTextureRect.X * Constants.TileWidth);
						srcRect.Y = (mTextureRect.Y * Constants.TileHeight);
						srcRect.Width = (mTextureRect.Width * Constants.TileWidth);
						srcRect.Height = (mTextureRect.Height * Constants.TileHeight);
					}

					rect.Width += 1;
					rect.Height += 1;

					var borderText = DrawHelper.Rect2Texture(Math.Max(mCamera.TileWidth, srcRect.Width), Math.Max(mCamera.TileHeight, srcRect.Height), 1, Color.White);

					if (srcRect != Rectangle.Empty) {
						mSpriteBatch.Draw(mPreviewTileset, rect, srcRect, new Color(new Vector4(Color.White.ToVector3(), 110)), 0f, Vector2.Zero, mTempEffect, 0f);
					}
					mSpriteBatch.Draw(borderText, rect, Color.Red);
				}
			} else if (mDrawMode.Has(EDrawMode.Erase) && mDrawMode.HasNot(EDrawMode.Rotate)) {

				mSpriteBatch.Draw(mEraseTexture, rect, Color.White);

			} else if (mDrawMode.Has(EDrawMode.Collision)) {
				var drawTex = Constants.TextureNotMoveable;
				var drawColor = Constants.ColorNotMoveable;
				if (Keyboard.GetState().IsCtrlDown() || GetCapsLock) {
					drawTex = Constants.TextureMoveable;
					drawColor = Constants.ColorMoveable;
				} else if (Keyboard.GetState().IsShiftDown() || GetScrollLock) {
					drawTex = Constants.TextureWater;
					drawColor = Constants.ColorWater;
				} else if (Keyboard.GetState().IsKeyDown(XnaKeys.LeftAlt) /* || GetNumLock*/) {
					drawTex = Constants.TextureUnderwater;
					drawColor = Constants.ColorUnderwater;
				}

				mSpriteBatch.Draw(drawTex, rect, drawColor);
				mSpriteBatch.Draw(DrawHelper.Rect2Texture(rect.Width, rect.Height, 2, new Color(new Vector4(Color.Green.ToVector3(), 0.8f))), rect, new Color(new Vector4(Color.White.ToVector3(), 0.8f)));
			} else if (mDrawMode.Has(EDrawMode.Autotile) && mDrawMode.HasNot(EDrawMode.Rotate | EDrawMode.Erase | EDrawMode.Flipping) && mCursorCell.X != -1 && mCursorCell.Y != -1) {
				// Autotile Preview
				// @TODO: add the right Preview Tile
				var srcRect = new Rectangle(0, 0, Constants.TileWidth, Constants.TileHeight);
				var borderText = DrawHelper.Rect2Texture(srcRect.Width, srcRect.Height, 1, Color.White);

				mSpriteBatch.Draw(mPreviewAutotile, rect, srcRect, new Color(new Vector4(Color.White.ToVector3(), 110)));
				mSpriteBatch.Draw(borderText, rect, Color.Red);
			} else if (mDrawMode.Has(EDrawMode.Flipping) && mCurrentLayer != -1) {
				var flipTex = mFlipVTexture;
				if (Keyboard.GetState().IsCtrlDown()) {
					flipTex = mFlipHTexture;
				}

				mSpriteBatch.Draw(flipTex, rect, new Color(new Vector4(Color.White.ToVector3(), 100)));
				mSpriteBatch.Draw(DrawHelper.Rect2Texture(rect.Width, rect.Height, 1, Color.Black), rect, Color.White);
			} else if (mDrawMode.Has(EDrawMode.Animation) && mDrawMode.HasNot(EDrawMode.Rotate | EDrawMode.Erase | EDrawMode.Flipping) && mCursorCell.X != -1 && mCursorCell.Y != -1 && mPreviewAnimation != null) {
				var aniBasePos = new Point2D(mCursorCell.X * mCamera.TileWidth - mCamera.X + mCamera.TileWidth / 2, mCursorCell.Y * mCamera.TileHeight - mCamera.Y + mCamera.TileHeight / 2);
				var borderSrcRect = new Rectangle(0, 0, Constants.TileWidth, Constants.TileHeight);
				var borderText = DrawHelper.Rect2Texture(borderSrcRect.Width, borderSrcRect.Height, 1, Color.White);

				mPreviewAnimation.Draw(mSpriteBatch, mCamera, 0, aniBasePos);
				mSpriteBatch.Draw(borderText, rect, Color.Red);
			}


			if (mDrawMode.Has(EDrawMode.Rotate) && mDrawMode.HasNot(EDrawMode.Collision | EDrawMode.Autotile | EDrawMode.Flipping)) {
				rect = new Rectangle(mCursorCell.X * mCamera.TileWidth - mCamera.X, mCursorCell.Y * mCamera.TileHeight - mCamera.Y, mCamera.TileWidth, mCamera.TileHeight);

				mSpriteBatch.Draw(DrawHelper.Rect2Texture(rect.Width, rect.Height, 2, Color.Violet), rect, Color.White);
			}

			if (mDrawMode.Has(EDrawMode.Rectangle) && mMarkerRectangle != Rectangle.Empty) {
				rect = new Rectangle(mMarkerRectangle.X * mCamera.TileWidth - mCamera.X, mMarkerRectangle.Y * mCamera.TileHeight - mCamera.Y, mMarkerRectangle.Width * mCamera.TileWidth, mMarkerRectangle.Height * mCamera.TileHeight);

				var rectangleTexture = DrawHelper.Rect2Texture(rect.Width, rect.Height, 1, Color.Blue);

				mSpriteBatch.Draw(rectangleTexture, rect, Color.Blue);
			}


			mSpriteBatch.End();
		}


		private void MoveTextures(XnaKeys key) {
			if (mMarkerRectangle == Rectangle.Empty || mCurrentLayer == -1 || mTileMap == null) {
				return;
			}

			Point2D moveAdd = Point2D.Zero, startPoint = Point2D.Zero;
			startPoint.X = mMarkerRectangle.X;
			startPoint.Y = mMarkerRectangle.Y;
			var endPoint = new Point2D(startPoint.X + mMarkerRectangle.Width, startPoint.Y + mMarkerRectangle.Height);

			var cells = new TileCell[endPoint.X - startPoint.X, endPoint.Y - startPoint.Y];
			for (var mapY = startPoint.Y; mapY < endPoint.Y; mapY++) {
				for (var mapX = startPoint.X; mapX < endPoint.X; mapX++) {
					cells[mapX - startPoint.X, mapY - startPoint.Y] = mTileMap.Layers[mCurrentLayer].GetCell(mapX, mapY);
				}
			}

			if (key == XnaKeys.Up) {
				moveAdd.Y = -1;
				for (var mapX = startPoint.X; mapX < endPoint.X; mapX++) {
					mTileMap.Layers[mCurrentLayer].SetCell(new Point2D(mapX, endPoint.Y - 1), TileCell.Empty);
				}
			} else if (key == XnaKeys.Left) {
				moveAdd.X = -1;
				for (var mapY = startPoint.Y; mapY < endPoint.Y; mapY++) {
					mTileMap.Layers[mCurrentLayer].SetCell(new Point2D(endPoint.X - 1, mapY), TileCell.Empty);
				}
			} else if (key == XnaKeys.Down) {
				moveAdd.Y = 1;
				for (var mapX = startPoint.X; mapX < endPoint.X; mapX++) {
					mTileMap.Layers[mCurrentLayer].SetCell(new Point2D(mapX, startPoint.Y), TileCell.Empty);
				}
			} else if (key == XnaKeys.Right) {
				moveAdd.X = 1;
				for (var mapY = startPoint.Y; mapY < endPoint.Y; mapY++) {
					mTileMap.Layers[mCurrentLayer].SetCell(new Point2D(startPoint.X, mapY), TileCell.Empty);
				}
			}

			// move saved Cells
			for (var mapY = startPoint.Y; mapY < endPoint.Y; mapY++) {
				for (var mapX = startPoint.X; mapX < endPoint.X; mapX++) {
					mTileMap.Layers[mCurrentLayer].SetCell(mapX + moveAdd.X, mapY + moveAdd.Y, cells[mapX - startPoint.X, mapY - startPoint.Y]);
				}
			}
			
			// move our rectangle
			mMarkerRectangle.X += moveAdd.X;
			mMarkerRectangle.Y += moveAdd.Y;
		}

		private void UpdateAutoTiles(Point2D startPoint, bool fakeMyLogic) {
			var undoCells = new List<UndoAction>();
			var doneCells = new List<Point2D>();
			var cell = GetCell(startPoint);
			if (fakeMyLogic && (cell.AutoTextureType == EAutoTileType.None || cell.TextureSource.TextureIndex != FileLists.Instance.Autotiles[mLastAutotileIndex[mCurrentLayer]].Filename)) {
				cell.AutoTextureType = EAutoTileType.StandAlone;
				cell.TextureSource.TextureIndex = FileLists.Instance.Autotiles[mLastAutotileIndex[mCurrentLayer]].Filename;
				undoCells.Add(new UndoAction(mCurrentLayer, cell, GetCell(startPoint), startPoint));
				mTileMap.Layers[mCurrentLayer].SetCell(startPoint, cell);
			}

			SetAutotileType(startPoint, FileLists.Instance.Autotiles[mLastAutotileIndex[mCurrentLayer]].Filename, ref doneCells, ref undoCells);

			UndoAdd(undoCells);
			doneCells.Clear();
			undoCells.Clear();
		}

		private void SetAutotileType(Point2D startPoint, string autoIndex, ref List<Point2D> doneCells, ref List<UndoAction> undoCells) {
			TileCell cellBefore;
			var p = new Point2D(startPoint.X, startPoint.Y);
			if (doneCells.Contains(startPoint)) {
				return;
			}

			doneCells.Add(p);

			var thisCell = mTileMap.Layers[mCurrentLayer].GetCell(startPoint.X, startPoint.Y);
			var cellTop = mTileMap.Layers[mCurrentLayer].GetCell(startPoint.X, startPoint.Y - 1);
			var cellBottom = mTileMap.Layers[mCurrentLayer].GetCell(startPoint.X, startPoint.Y + 1);
			var cellLeft = mTileMap.Layers[mCurrentLayer].GetCell(startPoint.X - 1, startPoint.Y);
			var cellRight = mTileMap.Layers[mCurrentLayer].GetCell(startPoint.X + 1, startPoint.Y);
			var cellTopLeft = mTileMap.Layers[mCurrentLayer].GetCell(startPoint.X - 1, startPoint.Y - 1);
			var cellTopRight = mTileMap.Layers[mCurrentLayer].GetCell(startPoint.X + 1, startPoint.Y - 1);
			var cellBottomLeft = mTileMap.Layers[mCurrentLayer].GetCell(startPoint.X - 1, startPoint.Y + 1);
			var cellBottomRight = mTileMap.Layers[mCurrentLayer].GetCell(startPoint.X + 1, startPoint.Y + 1);

			var isAutoTile = (thisCell.IsAutoTexture && thisCell.TextureSource.TextureIndex == autoIndex);
			var hasTop = (cellTop.IsAutoTexture && cellTop.TextureSource.TextureIndex == autoIndex);
			var hasBottom = (cellBottom.IsAutoTexture && cellBottom.TextureSource.TextureIndex == autoIndex);
			var hasLeft = (cellLeft.IsAutoTexture && cellLeft.TextureSource.TextureIndex == autoIndex);
			var hasRight = (cellRight.IsAutoTexture && cellRight.TextureSource.TextureIndex == autoIndex);
			var hasTopLeft = (cellTopLeft.IsAutoTexture && cellTopLeft.TextureSource.TextureIndex == autoIndex);
			var hasTopRight = (cellTopRight.IsAutoTexture && cellTopRight.TextureSource.TextureIndex == autoIndex);
			var hasBottomLeft = (cellBottomLeft.IsAutoTexture && cellBottomLeft.TextureSource.TextureIndex == autoIndex);
			var hasBottomRight = (cellBottomRight.IsAutoTexture && cellBottomRight.TextureSource.TextureIndex == autoIndex);

			var autoSource = new TileCellSource(autoIndex, 0, 0, Constants.TileWidth, Constants.TileHeight);
			var cell = new TileCell(Point2D.Zero, autoSource, 1f, 0f);

			// keine anliegenden Autotiles
			if (hasTop == false && hasBottom == false && hasLeft == false && hasRight == false && hasTopLeft == false && hasTopRight == false && hasBottomLeft == false && hasBottomRight == false) {
				cell.AutoTextureType = EAutoTileType.None; // reset Cell type
				if (isAutoTile) {
					cell.AutoTextureType = EAutoTileType.StandAlone;
					if (startPoint.X == 0) {
						cell.AutoTextureType |= EAutoTileType.Left | EAutoTileType.TopLeft | EAutoTileType.BottomLeft;
					}
					if (startPoint.Y == 0) {
						cell.AutoTextureType |= EAutoTileType.Top | EAutoTileType.TopLeft | EAutoTileType.TopRight;
					}
					if (startPoint.X >= mTileMap.Layers[mCurrentLayer].Width - 1) {
						cell.AutoTextureType |= EAutoTileType.Right | EAutoTileType.BottomRight | EAutoTileType.TopRight;
					}
					if (startPoint.Y >= mTileMap.Layers[mCurrentLayer].Height - 1) {
						cell.AutoTextureType |= EAutoTileType.Bottom | EAutoTileType.BottomLeft | EAutoTileType.BottomRight;
					}

					cellBefore = GetCell(p);
					if (SetCell(p, cell, true)) {
						undoCells.Add(new UndoAction(mCurrentLayer, cell, cellBefore, p));
					}
				}
				return;
			}

			// not alone in the Dark...
			cell.AutoTextureType = EAutoTileType.None;

			if (isAutoTile) {
				// say the Cell it has Autotiles on the Map Ending [open-end Autotile like RPG Maker XP]
				if (startPoint.X == 0) {
					cell.AutoTextureType |= EAutoTileType.Left | EAutoTileType.TopLeft | EAutoTileType.BottomLeft;
				}
				if (startPoint.Y == 0) {
					cell.AutoTextureType |= EAutoTileType.Top | EAutoTileType.TopLeft | EAutoTileType.TopRight;
				}
				if (startPoint.X >= mTileMap.Layers[mCurrentLayer].Width - 1) {
					cell.AutoTextureType |= EAutoTileType.Right | EAutoTileType.BottomRight | EAutoTileType.TopRight;
				}
				if (startPoint.Y >= mTileMap.Layers[mCurrentLayer].Height - 1) {
					cell.AutoTextureType |= EAutoTileType.Bottom | EAutoTileType.BottomLeft | EAutoTileType.BottomRight;
				}

				if (hasRight) {
					cell.AutoTextureType |= EAutoTileType.Right;
				}
				if (hasLeft) {
					cell.AutoTextureType |= EAutoTileType.Left;
				}
				if (hasTop) {
					cell.AutoTextureType |= EAutoTileType.Top;
				}
				if (hasBottom) {
					cell.AutoTextureType |= EAutoTileType.Bottom;
				}

				if (hasTopLeft) {
					cell.AutoTextureType |= EAutoTileType.TopLeft;
				}
				if (hasTopRight) {
					cell.AutoTextureType |= EAutoTileType.TopRight;
				}
				if (hasBottomLeft) {
					cell.AutoTextureType |= EAutoTileType.BottomLeft;
				}
				if (hasBottomRight) {
					cell.AutoTextureType |= EAutoTileType.BottomRight;
				}

				// nothing to update
				if (thisCell.AutoTextureType == cell.AutoTextureType) {
					return;
				}

				// set Cell Type
				cellBefore = GetCell(p);
				if (SetCell(p, cell, true)) {
					undoCells.Add(new UndoAction(mCurrentLayer, cell, cellBefore, p));
				}
			}


			// update other Cells
			if (hasRight) {
				SetAutotileType(new Point2D(startPoint.X + 1, startPoint.Y), autoIndex, ref doneCells, ref undoCells);
			}
			if (hasLeft) {
				SetAutotileType(new Point2D(startPoint.X - 1, startPoint.Y), autoIndex, ref doneCells, ref undoCells);
			}
			if (hasTop) {
				SetAutotileType(new Point2D(startPoint.X, startPoint.Y - 1), autoIndex, ref doneCells, ref undoCells);
			}
			if (hasBottom) {
				SetAutotileType(new Point2D(startPoint.X, startPoint.Y + 1), autoIndex, ref doneCells, ref undoCells);
			}

			if (hasTopLeft) {
				SetAutotileType(new Point2D(startPoint.X - 1, startPoint.Y - 1), autoIndex, ref doneCells, ref undoCells);
			}
			if (hasTopRight) {
				SetAutotileType(new Point2D(startPoint.X + 1, startPoint.Y - 1), autoIndex, ref doneCells, ref undoCells);
			}
			if (hasBottomLeft) {
				SetAutotileType(new Point2D(startPoint.X - 1, startPoint.Y + 1), autoIndex, ref doneCells, ref undoCells);
			}
			if (hasBottomRight) {
				SetAutotileType(new Point2D(startPoint.X + 1, startPoint.Y + 1), autoIndex, ref doneCells, ref undoCells);
			}

		}

		private void AdjustScrollBars() {
			if (mTileMap == null) {
				MapHScrollBar.Visible = false;
				MapVScrollBar.Visible = false;
				TilesetHScrollBar.Visible = false;
				TilesetVScrollBar.Visible = false;
				AutotilesVScrollBar.Visible = false;
				return;
			}

			Point2D texPoint;

			#region Map
			var cellPoint = DrawHelper.Point2ToEngineCell(new Point2D(RenderDisplayMap.Width, RenderDisplayMap.Height));
			if (mTileMap.Width > cellPoint.X) {
				MapHScrollBar.Visible = true;
				MapHScrollBar.Minimum = 0;
				MapHScrollBar.Maximum = mTileMap.Width - cellPoint.X;
			} else {
				MapHScrollBar.Visible = false;
				MapHScrollBar.Value = 0;
			}


			if (mTileMap.Height > cellPoint.Y) {
				MapVScrollBar.Visible = true;
				MapVScrollBar.Minimum = 0;
				MapVScrollBar.Maximum = mTileMap.Height - cellPoint.Y;
			} else {
				MapVScrollBar.Visible = false;
				MapVScrollBar.Value = 0;
			}

			RenderDisplayMap.Invalidate();
			#endregion

			#region Tileset
			if (mPreviewTileset != null && TextureTabControl.SelectedIndex == 0) {
				texPoint = DrawHelper.Point2ToEngineCell(new Point2D(mPreviewTileset.Width, mPreviewTileset.Height));
				cellPoint = DrawHelper.Point2ToEngineCell(new Point2D(RenderDisplayTexture.Width, RenderDisplayTexture.Height));

				if (cellPoint.X >= texPoint.X) {
					TilesetHScrollBar.Visible = false;
					TilesetHScrollBar.Value = 0;
				} else {
					TilesetHScrollBar.Maximum = texPoint.X - cellPoint.X + 1;
					TilesetHScrollBar.Visible = true;
				}
				if (cellPoint.Y >= texPoint.Y) {
					TilesetVScrollBar.Visible = false;
					TilesetVScrollBar.Value = 0;
				} else {
					TilesetVScrollBar.Maximum = texPoint.Y - cellPoint.Y + 1;
					TilesetVScrollBar.Visible = true;
				}
				RenderDisplayTexture.Invalidate();
			} else {
				TilesetHScrollBar.Visible = false;
				TilesetVScrollBar.Visible = false;
				TilesetHScrollBar.Value = 0;
				TilesetVScrollBar.Value = 0;
			}
			#endregion

			#region Autotile
			if (mPreviewAutotile != null && TextureTabControl.SelectedIndex == 1) {
				texPoint = DrawHelper.Point2ToEngineCell(new Point2D(mPreviewAutotile.Width, mPreviewAutotile.Height));
				cellPoint = DrawHelper.Point2ToEngineCell(new Point2D(RenderDisplayAutotile.Width, RenderDisplayAutotile.Height));
				if (cellPoint.Y >= texPoint.Y) {
					AutotilesVScrollBar.Visible = false;
					AutotilesVScrollBar.Value = 0;
				} else {
					AutotilesVScrollBar.Maximum = texPoint.Y - cellPoint.Y + 1;
					AutotilesVScrollBar.Visible = true;
				}

				RenderDisplayAutotile.Invalidate();
			} else {
				AutotilesVScrollBar.Visible = false;
				AutotilesVScrollBar.Value = 0;
			}
			#endregion

			#region Animation
			if (mPreviewAnimation != null && mPreviewAnimation.Frames.Count > 0 && TextureTabControl.SelectedIndex == 2) {
				texPoint = DrawHelper.Point2ToEngineCell(new Point2D(mPreviewAnimation[0][0].Width, mPreviewAnimation[0][0].Height));
				cellPoint = DrawHelper.Point2ToEngineCell(new Point2D(RenderDisplayAnimations.Width, RenderDisplayAnimations.Height));
				if (cellPoint.X >= texPoint.X) {
					AnimationsHScrollBar.Visible = false;
					AnimationsHScrollBar.Value = 0;
				} else {
					AnimationsHScrollBar.Maximum = texPoint.X - cellPoint.X + 1;
					AnimationsHScrollBar.Visible = true;
				}
				if (cellPoint.Y >= texPoint.Y) {
					AnimationsVScrollBar.Visible = false;
					AnimationsVScrollBar.Value = 0;
				} else {
					AnimationsVScrollBar.Maximum = texPoint.Y - cellPoint.Y + 1;
					AnimationsVScrollBar.Visible = true;
				}

				RenderDisplayAnimations.Invalidate();
			} else {
				AnimationsHScrollBar.Visible = false;
				AnimationsVScrollBar.Visible = false;
				AnimationsHScrollBar.Value = 0;
				AnimationsVScrollBar.Value = 0;
			}
			#endregion

			#region Object
			if (mPreviewObject != null && TextureTabControl.SelectedIndex == 3) {
				texPoint = DrawHelper.Point2ToEngineCell(new Point2D(mPreviewObject.Width, mPreviewObject.Height));
				cellPoint = DrawHelper.Point2ToEngineCell(new Point2D(RenderDisplayObjects.Width, RenderDisplayObjects.Height));
				if (cellPoint.X >= texPoint.X) {
					ObjectsHScrollBar.Visible = false;
					ObjectsHScrollBar.Value = 0;
				} else {
					ObjectsHScrollBar.Maximum = texPoint.X - cellPoint.X + 1;
					ObjectsHScrollBar.Visible = true;
				}
				if (cellPoint.Y >= texPoint.Y) {
					ObjectsVScrollBar.Visible = false;
					ObjectsVScrollBar.Value = 0;
				} else {
					ObjectsVScrollBar.Maximum = texPoint.Y - cellPoint.Y + 1;
					ObjectsVScrollBar.Visible = true;
				}

				RenderDisplayObjects.Invalidate();
			} else {
				ObjectsVScrollBar.Visible = false;
				ObjectsHScrollBar.Visible = false;
				ObjectsVScrollBar.Value = 0;
				ObjectsHScrollBar.Value = 0;
			}
			#endregion
		}


		private void AddLayerToTree(string layername, bool canRename, int imageIndex, bool addContextMenu, bool canChoiceBgFg = true, bool isBackgroundSelected = true) {
			TreeNode node;

			var frm = new frmNewLayer {
				txtName = {
					Text = layername
				}
			};
			if (canRename || canChoiceBgFg) {
				if (canRename == false) {
					frm.txtName.ReadOnly = true;
				}
				if (canChoiceBgFg == false) {
					frm.chkBackground.Enabled = false;
					frm.chkForeground.Enabled = false;
				}
				frm.chkBackground.Checked = isBackgroundSelected;
				frm.chkForeground.Checked = !isBackgroundSelected;

				do {
					frm.ShowDialog();
				} while (frm.OKPressed == false);
			}

			var layer = new TileLayer(mTileMap.Width, mTileMap.Height);
			layer.Name = frm.txtName.Text;
			layer.IsBackground = frm.chkBackground.Checked;

			var lastBgIndex = GetLastBGIndex();
			// vor FG [wenn BG Layer] oder ans Ende [wenn FG Layer]
			// wnen keine Layer vorhanden, reicht Add()
			if (layer.IsBackground && lastBgIndex > -1 && lastBgIndex < mTileMap.Layers.Count) {
				node = ProjectTree.Nodes[0].Nodes.Insert(lastBgIndex + 2, layer.Name); // Tree enthält noch Collision 
				mTileMap.Layers.Insert(lastBgIndex + 1, layer);
			} else {
				node = ProjectTree.Nodes[0].Nodes.Add(layer.Name);
				mTileMap.Layers.Add(layer);
			}

			if (addContextMenu) {
				node.ContextMenuStrip = ProjectTreeNodeContext;
			}

			node.ImageIndex = (imageIndex != -1 ? imageIndex : (layer.IsBackground ? 1 : 3));
			node.SelectedImageIndex = imageIndex;
			node.Tag = layer.Name;

			ProjectTree.Nodes[0].Text = BuildMapName();

			if (layer.IsBackground && lastBgIndex > 0) {
				mLastTilesetIndex.Insert(lastBgIndex, 0);
				mLastAutotileIndex.Insert(lastBgIndex, 0);
				mLastAnimationIndex.Insert(lastBgIndex, 0);
				mLastObjectIndex.Insert(lastBgIndex, 0);
			} else {
				mLastTilesetIndex.Add(0);
				mLastAutotileIndex.Add(0);
				mLastAnimationIndex.Add(0);
				mLastObjectIndex.Add(0);
			}
		}


		private void SetLastAutotileIndex() {
			if (mLastAutotileIndex[mCurrentLayer] != -1) {
				comboAutotiles.SelectedItem = mLastAutotileIndex[mCurrentLayer];
				comboAutoTextures_SelectedIndexChanged(null, EventArgs.Empty);
				return;
			}

			mLastAutotileIndex[mCurrentLayer] = 0;
			comboAutotiles.SelectedIndex = 0;
			comboAutoTextures_SelectedIndexChanged(null, EventArgs.Empty);
		}

		private void SetLastTilesetIndex() {
			if (mLastTilesetIndex[mCurrentLayer] != -1) {
				comboTilesets.SelectedItem = mLastTilesetIndex[mCurrentLayer];
				comboTextures_SelectedIndexChanged(null, EventArgs.Empty);
				return;
			}

			mLastTilesetIndex[mCurrentLayer] = 0;
			comboTilesets.SelectedIndex = 0;
			comboTextures_SelectedIndexChanged(null, EventArgs.Empty);
		}

		private void SetLastAnimationIndex() {
			if (mLastAnimationIndex[mCurrentLayer] != -1) {
				comboAnimations.SelectedItem = mLastAnimationIndex[mCurrentLayer];
				comboAnimations_SelectedIndexChanged(null, EventArgs.Empty);
				return;
			}

			mLastAnimationIndex[mCurrentLayer] = 0;
			comboAnimations.SelectedIndex = 0;
			comboAnimations_SelectedIndexChanged(null, EventArgs.Empty);
		}

		private void SetLastObjectIndex() {
			if (mLastObjectIndex[mCurrentLayer] != -1) {
				comboObjects.SelectedItem = mLastObjectIndex[mCurrentLayer];
				comboObjects_SelectedIndexChanged(null, EventArgs.Empty);
				return;
			}

			mLastObjectIndex[mCurrentLayer] = 0;
			comboObjects.SelectedIndex = 0;
			comboObjects_SelectedIndexChanged(null, EventArgs.Empty);
		}


		private string BuildMapName() {
			return String.Format("{0} [{1} x {2}] ({3} Ebene{4})", mTileMap.Name, mTileMap.Width, mTileMap.Height, mTileMap.Layers.Count - 1, mTileMap.Layers.Count != 1 ? "n" : "");
		}


		private void AddZoom(ToolStripMenuItem ExceptItem) {
			if (mZoomMulti >= 1.5f) {
				return;
			}
			mZoomMulti += 0.1f;
			SetZoom();
		}

		private void DelZoom(ToolStripMenuItem ExceptItem) {
			if (mZoomMulti <= 0.1f) {
				return;
			}
			mZoomMulti -= 0.1f;
			SetZoom();
		}

		private void SetZoom(float Multi) {
			mZoomMulti = Multi;
			SetZoom();
		}

		private void SetZoom() {
			mCamera.Zoom = mZoomMulti;
			mCamera.Refresh();

			//Engine.Init( GraphicsDevice );
			AdjustScrollBars();
		}


		private bool CanRotate(Point2D Cell) {
			// never Rotate?
			if (mLastRotatePoint.Equals(null) || mLastRotateTime == 0) {
				mLastRotatePoint = Cell;
				mLastRotateTime = DateTime.Now.UnixTimestamp();
				return true;
			}

			// last Rotate was the same Cell?
			if (mLastRotatePoint == Cell) {
				var ret = (DateTime.Now.UnixTimestamp() - mLastRotateTime) >= 1;
				mLastRotateTime = DateTime.Now.UnixTimestamp();
				return ret;
			}

			// last Rotate was another Cell, it's okay
			mLastRotatePoint = Cell;
			mLastRotateTime = DateTime.Now.UnixTimestamp();

			return true;
		}

		private bool CanTextureVAutoScroll() {
			if (TilesetVScrollBar.Value >= TilesetVScrollBar.Maximum) {
				return false;
			}

			if (mLastTextureVAutoscrollTime == 0) {
				mLastTextureVAutoscrollTime = DateTime.Now.UnixTimestamp();
				return true;
			}

			if ((DateTime.Now.UnixTimestamp() - mLastTextureVAutoscrollTime) < 1) {
				return false;
			}

			mLastTextureVAutoscrollTime = DateTime.Now.UnixTimestamp();
			return true;
		}

		private bool CanTextureHAutoScroll() {
			if (TilesetHScrollBar.Value >= TilesetHScrollBar.Maximum) {
				return false;
			}

			if (mLastTextureHAutoscrollTime == 0) {
				mLastTextureHAutoscrollTime = DateTime.Now.UnixTimestamp();
				return true;
			}

			if ((DateTime.Now.UnixTimestamp() - mLastTextureHAutoscrollTime) < 1) {
				return false;
			}

			mLastTextureHAutoscrollTime = DateTime.Now.UnixTimestamp();
			return true;
		}

		private bool CanMapAutoScroll() {
			if (mLastMapAutoscrollTime == 0) {
				mLastMapAutoscrollTime = DateTime.Now.UnixTimestamp();
				return true;
			}

			if ((DateTime.Now.UnixTimestamp() - mLastMapAutoscrollTime) < 1) {
				return false;
			}

			mLastMapAutoscrollTime = DateTime.Now.UnixTimestamp();
			return true;
		}


		private void CheckTextureAutoScroll() {
			Mouse.WindowHandle = Handle;
			var p = new Point2D(Mouse.GetState().X, Mouse.GetState().Y);
			if (p.X >= (RenderDisplayTexture.Location.X + RenderDisplayTexture.Width)) {
				if (CanTextureHAutoScroll()) {
					TilesetHScrollBar.Value++;
				}
			}
			if (p.Y >= (RenderDisplayTexture.Location.Y + RenderDisplayTexture.Height)) {
				if (CanTextureVAutoScroll()) {
					TilesetVScrollBar.Value++;
				}
			}
		}

		private void CheckMapAutoScroll() {
			Mouse.WindowHandle = Handle;
			var p = new Point2D(Mouse.GetState().X, Mouse.GetState().Y);
			if (CanMapAutoScroll() == false) {
				return;
			}
			if (MapVScrollBar.Value < MapVScrollBar.Maximum && p.Y >= (RenderDisplayMap.Location.Y + RenderDisplayMap.Height)) {
				MapVScrollBar.Value++;
			}
			if (MapHScrollBar.Value < MapHScrollBar.Maximum && p.X >= (RenderDisplayMap.Location.X + RenderDisplayMap.Width)) {
				MapHScrollBar.Value++;
			}
		}


		private bool SetCell(Point2D toPoint, TileCell toCell, bool GroupDraw) {
			var oldCell = GetCell(toPoint);
			if (toCell.IsEqualTo(oldCell)) {
				return false;
			}
			if (GroupDraw == false) {
				UndoAdd(toCell, oldCell, toPoint);
			}

			mTileMap.Layers[mCurrentLayer].SetCell(toPoint, toCell);
			mTileMap.Layers[mCurrentLayer][toPoint].LoadContent(EngineCore.ContentLoader.XnaContent);
			if (GroupDraw == false) {
				UpdateAutoTiles(toPoint, false);
			}
			return true;
		}

		private void SetCells(Point2D toPointStart, Point2D toPointEnd, TileCell toCell) {
			var undos = new List<UndoAction>();
			Point2D p;
			TileCell cellBefore;
			var baseCell = GetCell(mCursorCell);
			var sameTexture = MenuSettingsFillSameTexture.Checked;
			for (var x = toPointStart.X; x < toPointEnd.X; x++) {
				for (var y = toPointStart.Y; y < toPointEnd.Y; y++) {
					p = new Point2D(x, y);
					cellBefore = GetCell(p);
					if (sameTexture && cellBefore.TextureSource.IsEqualTo(baseCell.TextureSource) == false) {
						continue;
					}
					if (SetCell(p, toCell, true) == false) {
						break;
					}

					undos.Add(new UndoAction(mCurrentLayer, toCell, cellBefore, p));
				}
			}
			UndoAdd(undos);
		}

		private bool SetCellGroup(Point2D toPoint, bool groupDraw, List<UndoAction> RefUndos = null) {
			if (RefUndos == null) {
				RefUndos = new List<UndoAction>();
			}

			TileCell cell, cellBefore;
			int texX, texY;
			var privUndos = new List<UndoAction>();
			Point2D p;
			var mirrorH = (mTempEffect & SpriteEffects.FlipHorizontally) == SpriteEffects.FlipHorizontally;
			var mirrorV = (mTempEffect & SpriteEffects.FlipVertically) == SpriteEffects.FlipVertically;
			var mirrorSubX = (mirrorH ? mTextureRect.Width - 1 : 0);
			var mirrorSubY = (mirrorV ? mTextureRect.Height - 1 : 0);

			for (var x = 0; x < mTextureRect.Width; x++) {
				if ((toPoint.X + x) >= mTileMap.Layers[mCurrentLayer].Width) {
					break;
				}
				for (var y = 0; y < mTextureRect.Height; y++) {
					if ((toPoint.Y + y) >= mTileMap.Layers[mCurrentLayer].Height) {
						break;
					}

					p = new Point2D(toPoint.X + x, toPoint.Y + y);

					texX = (mirrorSubX - x) * Constants.TileWidth;
					if (texX < 0) // no mirror, 0 - X = -Y...
					{
						texX *= -1;
					}
					texX += mTextureRect.X * Constants.TileWidth;

					texY = (mirrorSubY - y) * Constants.TileHeight;
					if (texY < 0) {
						texY *= -1;
					}
					texY += mTextureRect.Y * Constants.TileHeight;

					cell = new TileCell(p, new Rectangle(texX, texY, Constants.TileWidth, Constants.TileHeight), FileLists.Instance.Tilesets[mLastTilesetIndex[mCurrentLayer]].Filename, 1f, 0f);
					cell.FlipEffect = mTempEffect;
					cellBefore = GetCell(p);
					if (SetCell(p, cell, true)) {
						if (groupDraw) {
							RefUndos.Add(new UndoAction(mCurrentLayer, cell, cellBefore, p));
						} else {
							privUndos.Add(new UndoAction(mCurrentLayer, cell, cellBefore, p));
						}
					}
				}
			}

			if (groupDraw == false) {
				UndoAdd(privUndos);
			}
			privUndos.Clear();

			return true;
		}

		private void SetCellGroups(Point2D toPointStart, Point2D toPointEnd) {
			var undoItems = new List<UndoAction>();
			TileCell baseCell = GetCell(mCursorCell), checkCell;
			var sameTexture = MenuSettingsFillSameTexture.Checked;
			Point2D p;
			for (var x = toPointStart.X; x < toPointEnd.X; x += mTextureRect.Width) {
				for (var y = toPointStart.Y; y < toPointEnd.Y; y += mTextureRect.Height) {
					p = new Point2D(x, y);
					checkCell = GetCell(p);
					if (sameTexture && (checkCell.TextureSource.IsEqualTo(baseCell.TextureSource) == false || checkCell.TextureSource.TextureIndex != baseCell.TextureSource.TextureIndex)) {
						continue;
					}
					if (SetCellGroup(p, true, undoItems) == false) {
						break;
					}
				}
			}
			UndoAdd(undoItems);
		}


		private TileCell GetCell(Point2D FromPoint) {
			return mTileMap.Layers[mCurrentLayer].GetCell(FromPoint);
		}


		private void UndoAdd(TileCell to, TileCell from, Point2D p) {
			var items = new List<UndoAction>();
			items.Add(new UndoAction(mCurrentLayer, to, from, p));
			UndoAdd(items);
		}

		private void UndoAdd(List<UndoAction> items) {
			if (items.Count == 0) {
				return;
			}

			var safeItems = new List<UndoAction>(items.Count);
			safeItems.AddRange(items);

			MenuToolStripActionUndo.Enabled = true;
			mUndoQueue.Push(safeItems);
		}

		private void Undo() {
			if (mUndoQueue.Count == 0) {
				MenuToolStripActionUndo.Enabled = false;
				return;
			}
			var items = mUndoQueue.Pop();

			// reverse it, so we first try the Last
			for (var i = items.Count - 1; i >= 0; i--) {
				if (mTileMap == null || items[i].LayerID >= mTileMap.Layers.Count) {
					MessageBox.Show("Undo failed! Layer nicht gefunden");
					continue;
				}

				if (mTileMap.Layers[items[i].LayerID].SetCell(items[i].Point, items[i].CellFrom) == false) {
					MessageBox.Show("Undo failed! Gespeicherter Punkt ist größer als die Map!");
				}
			}
			if (mUndoQueue.Count == 0) {
				MenuToolStripActionUndo.Enabled = false;
			}

			RedoAdd(items);
		}

		private void RedoAdd(List<UndoAction> items) {
			if (items.Count == 0) {
				return;
			}

			var safeItems = new List<UndoAction>(items.Count);
			safeItems.AddRange(items);

			MenuToolStripActionRedo.Enabled = true;
			mRedoQueue.Push(safeItems);
		}

		private void Redo() {
			if (mRedoQueue.Count == 0) {
				MenuToolStripActionRedo.Enabled = false;
				return;
			}
			var items = mRedoQueue.Pop();

			// we got it reversed, so start from begin (last added)
			for (var i = 0; i < items.Count; i++) {
				if (mTileMap == null || items[i].LayerID >= mTileMap.Layers.Count) {
					MessageBox.Show("Redo failed! Layer nicht gefunden");
					return;
				}

				if (mTileMap.Layers[items[i].LayerID].SetCell(items[i].Point, items[i].CellTo) == false) {
					MessageBox.Show("Redo failed! Gespeicherter Punkt ist größer als die Map!");
				}
			}
			if (mRedoQueue.Count == 0) {
				MenuToolStripActionRedo.Enabled = false;
			}

			UndoAdd(items);
		}


		private void LoadMap(string Filename) {
			ProjectTree.Nodes.Clear();
			mTextureRect = Rectangle.Empty;
			mPreviewTileset = null;
			mCursorCell.X = mCursorCell.Y = -1;
			mLastTilesetIndex.Clear();
			mLastAutotileIndex.Clear();
			mLastAnimationIndex.Clear();
			mLastObjectIndex.Clear();
			mUndoQueue.Clear();
			mRedoQueue.Clear();

			var result = TileLoadResult.Success;
			if (Path.GetExtension(Filename) == ".xnb") {
				mTileMap = EngineCore.ContentLoader.GetMap(Path.GetFileNameWithoutExtension(Filename));
			} else {
				result = TileMap.Load(Filename, out mTileMap);
			}
			if (result != TileLoadResult.Success || mTileMap == null) {
				// w00t oO
				mTileMap = new TileMap(); // to avoid <null> Crashes

				var msg = "Fehler beim öffnen der Map!\n";
				switch (result) {
					case TileLoadResult.NoEntryInArchiv:
						msg += "Es wurde keine Map Datei in dem .bmap Archiv gefunden!";
						break;
					case TileLoadResult.OldType:
						msg += "Die Map-Version ist zu alt!\n\nBitte benutze den Converter (Extras)";
						break;
					case TileLoadResult.UnkownError:
						msg += "Die Ursache ist unbekannt :/\n\nWenn du den Editor im Debug laufen hast, schau bitte in das \nAusgabe fenster und kopiere es in einen Bug Post, danke ^.^";
						break;
				}

				MessageBox.Show(msg, "Fehler beim öffnen", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			// update Version to newst
			mTileMap.VersionMajor = TileMap.VersionMajorNow;
			mTileMap.VersionMinor = TileMap.VersionMinorNow;

			// Load content
			mTileMap.LoadContent(EngineCore.ContentLoader.XnaContent);

			mCurrentLayer = -1;

			// add Main Map
			ProjectTree.Nodes.Add(BuildMapName());
			ProjectTree.Nodes[0].ImageIndex = 0;
			ProjectTree.Nodes[0].SelectedImageIndex = 0;
			ProjectTree.Nodes[0].Tag = mTileMap.Name;
			ProjectTree.Nodes[0].ContextMenuStrip = ProjectTreeContext;

			// add Collision Layer
			ProjectTree.Nodes[0].Nodes.Add(COLLISION_LAYER_NAME);
			ProjectTree.Nodes[0].Nodes[0].ImageIndex = 4;
			ProjectTree.Nodes[0].Nodes[0].SelectedImageIndex = 4;

			// add Sub Layer
			for (var layer = 0; layer < mTileMap.Layers.Count; layer++) {
				ProjectTree.Nodes[0].Nodes.Add(mTileMap.Layers[layer].Name);
				ProjectTree.Nodes[0].Nodes[layer + 1].ImageIndex = ProjectTree.Nodes[0].Nodes[layer + 1].SelectedImageIndex = (mTileMap.Layers[layer].IsBackground ? 1 : 3);
				ProjectTree.Nodes[0].Nodes[layer + 1].Tag = mTileMap.Layers[layer].Name;
				ProjectTree.Nodes[0].Nodes[layer + 1].ContextMenuStrip = ProjectTreeNodeContext;
				mLastTilesetIndex.Add(0);
				mLastAutotileIndex.Add(0);
				mLastAnimationIndex.Add(0);
				mLastObjectIndex.Add(0);
			}

			ProjectTree.SelectedNode = ProjectTree.Nodes[0].Nodes[1];

			ProjectTree.ExpandAll();
		}


		private void SetStatus(string text) {
			StatusLabel.Text = text;
		}

		private void SetLayerStatus(string text) {
			LayerStatus.Text = LAYER_STATUSDEFAULT + text;
		}


		/// <summary>
		///     <para>Returns the index of the last background layer</para>
		///     <para>-1 if no background layer found</para>
		/// </summary>
		/// <returns>
		/// </returns>
		private int GetLastBGIndex() {
			int i;
			for (i = 0; i < mTileMap.Layers.Count; i++) {
				if (mTileMap.Layers[i].IsBackground == false) {
					break;
				}
			}

			// kein FG Layer gefunden [also alles BG]
			if (i >= mTileMap.Layers.Count) {
				return mTileMap.Layers.Count - 1;
			}

			return --i;
		}


		private TileCell[][,] mCopyLayout;
		private int mCopyLayer = -1;

		private void StartCopy(bool Cut, bool DeepCut) {
			if (mTileMap == null || mTileMap.Width == 0 || mTileMap.Height == 0 || mCurrentLayer == -1) {
				return;
			}
			if (mMarkerRectangle == Rectangle.Empty) {
				return;
			}

			var undoItems = new List<UndoAction>();
			Point2D startPoint = Point2D.Zero, endPoint = Point2D.Zero;
			startPoint.X = mMarkerRectangle.X;
			startPoint.Y = mMarkerRectangle.Y;
			endPoint = new Point2D(startPoint.X + mMarkerRectangle.Width, startPoint.Y + mMarkerRectangle.Height);

			mCopyLayout = new TileCell[mTileMap.Layers.Count][,];
			mCopyLayer = mCurrentLayer;
			for (var layer = 0; layer < mTileMap.Layers.Count; layer++) {
				mCopyLayout[layer] = new TileCell[endPoint.X - startPoint.X, endPoint.Y - startPoint.Y];
				for (var mapY = startPoint.Y; mapY < endPoint.Y; mapY++) {
					for (var mapX = startPoint.X; mapX < endPoint.X; mapX++) {
						mCopyLayout[layer][mapX - startPoint.X, mapY - startPoint.Y] = mTileMap.Layers[layer].GetCell(mapX, mapY);
						if (Cut && (DeepCut || layer == mCurrentLayer)) {
							undoItems.Add(new UndoAction(layer, TileCell.Empty, mCopyLayout[layer][mapX - startPoint.X, mapY - startPoint.Y], new Point2D(mapX, mapY)));
							mTileMap.Layers[layer].SetCell(mapX, mapY, TileCell.Empty);
						}
					}
				}
			}

			UndoAdd(undoItems);
			undoItems.Clear();
		}

		private void StartPaste(bool Deep) {
			if (mTileMap == null || mTileMap.Width == 0 || mTileMap.Height == 0 || mCurrentLayer == -1) {
				return;
			}
			if (mCursorCell.X == -1 || mCursorCell.Y == -1) {
				return;
			}
			if (mCopyLayout == null) {
				return;
			}

			if (Deep == false && mCopyLayer >= mTileMap.Layers.Count) {
				Messagehelper.ShowError("Kopierfehler", "Die kopierte Ebene ist größer als deine momentane Ebenanzahl!");
				return;
			}

			var actLayer = 0;
			Point2D p, startPoint = Point2D.Zero, endPoint = Point2D.Zero;
			startPoint.X = mCursorCell.X;
			startPoint.Y = mCursorCell.Y;
			endPoint = new Point2D(startPoint.X + mCopyLayout[0].GetLength(0), startPoint.Y + mCopyLayout[0].GetLength(1));
			endPoint.X = Math.Min(endPoint.X, mTileMap.Width);
			endPoint.Y = Math.Min(endPoint.Y, mTileMap.Height);

			var undoItems = new List<UndoAction>();
			TileCell cellBefore;
			for (var layer = 0; layer < mTileMap.Layers.Count; layer++) {
				if (Deep == false && layer != mCurrentLayer) {
					continue;
				}

				actLayer = (Deep == false ? mCopyLayer : layer); // copy to <mCopyLayer> [copied Layer, not Depp, or paste in all Layer, Deep Paste]
				for (var mapY = startPoint.Y; mapY < endPoint.Y; mapY++) {
					for (var mapX = startPoint.X; mapX < endPoint.X; mapX++) {
						p = new Point2D(mapX, mapY);
						cellBefore = mTileMap.Layers[layer].GetCell(p);
						var destination = p - startPoint;
						if (mTileMap.Layers[layer].SetCell(p, mCopyLayout[actLayer][destination.X, destination.Y])) {
							undoItems.Add(new UndoAction(layer, mCopyLayout[actLayer][destination.X, destination.Y], cellBefore, p));
							mTileMap.Layers[layer][p].LoadContent(EngineCore.ContentLoader.XnaContent);
						}
					}
				}
			}

			UndoAdd(undoItems);
		}
	}
}