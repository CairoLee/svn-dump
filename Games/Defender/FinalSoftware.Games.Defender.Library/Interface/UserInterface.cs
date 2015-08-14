using System.Collections.Generic;
using FinalSoftware.Games.Defender.Library.Map;
using FinalSoftware.Games.Defender.Library.Projectiles;
using FinalSoftware.Games.Defender.Library.Tools;
using FinalSoftware.Games.Defender.Library.Towers;
using FinalSoftware.Games.Defender.Library.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalSoftware.Games.Defender.Library.Interface {

	public class UserInterface : DefenderComponent {
		private const int ButtonWidth = 80;
		private const int ButtonHeight = 25;
		private const int ButtonPad = 1;
		private const int ScrollValue = 5;
		private const float ZoomValue = 0.05f;
		private const int PanelPad = 8;

		private SpriteBatch mSpriteBatch;
		private SpriteBatch mSpriteBatchAdditive;

		private Rectangle mScreenSize;
		private Rectangle mMinimap;
		private Vector2 mMinimapRatio;
		private bool mExpanded;
		private Rectangle mMinimapOrig;
		private Camera2D mCamera;

		private ButtonMenuDirect mButtonDirect;
		private ButtonMenuSplash mButtonSplash;
		private ButtonMenUtility mButtonUtility;
		private ButtonUpgrade mButtonUpgrade;
		private List<Button> mButtonsBuild;
		private List<Button> mButtonsDirect;
		private List<Button> mButtonsSplash;
		private List<Button> mButtonsUtility;
		private List<Button> mButtonsMenu;

		private Rectangle mBPanel;
		private Rectangle mBPanelTop;
		private Rectangle mBPanelSelect;
		private Rectangle mBPanelTowersL;
		private Rectangle mBPanelTowersR;
		private Rectangle mMenuBounds;
		private Rectangle mBgDull;

		private SpriteFont mFont, mFont2;

		protected bool mDrawMenu;
		protected bool mCanBuild;
		protected bool mBuildMode;
		protected bool mDisplayControls;
		private Tower mSelectedTower;
		private string mBuildType;
		protected Tower mTowerToBeBuilt;

		private readonly ColorFade mFadeRange = new ColorFade(20, 100, 2);
		private readonly ColorFade fadeSelection = new ColorFade(64, 255, 15);
		private ColorFade fadeBuild = new ColorFade(128, 160, 3);
		private ColorFade fadeNoBuild = new ColorFade(64, 160, 10);
		private float bPressTimer = 0f;
		private Rectangle startButtonArea;


		public bool DebugInfo = false;
		public bool DrawPaths;
		public float Zoom;
		public Rectangle mapArea;
		public Texture2D texButtonUp, texButtonDown, texPanel, texGrid, texUIArrow, texUITooltip;
		public Texture2D texSelection, texPanelBar, texIconMoney, texIconArtifact, texIconEra, texCircleRadius;
		public Texture2D texBlank, texControls, texMiniMapBack;

		public Camera2D Camera {
			get { return mCamera; }
		}

		public SpriteBatch SpriteBatch {
			get { return mSpriteBatch; }
		}

		public SpriteBatch SpriteBatchAdditive {
			get { return mSpriteBatchAdditive; }
		}

		public SpriteFont Font {
			get { return mFont; }
		}

		public Tower SelectedTower {
			get { return mSelectedTower; }
			set { mSelectedTower = value; }
		}


		public UserInterface(DefenderGame game)
			: base(game) {
		}


		public override void Initialize() {
			int mmSide;
			SetupPanels();

			mScreenSize = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
			mCamera = new Camera2D(World.Map.Bounds);

			mmSide = 200;
			mMinimap = new Rectangle(mScreenSize.Width - mmSide - 5, 5, mmSide, mmSide);
			mMinimapOrig = mMinimap;
			mapArea = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height - mBPanel.Height);
			mMinimapRatio = new Vector2((float)mMinimap.Width / World.Map.Bounds.Width, (float)mMinimap.Height / World.Map.Bounds.Height);

			base.Initialize();
		}

		protected override void LoadContent() {
			mSpriteBatch = new SpriteBatch(GraphicsDevice);
			mSpriteBatchAdditive = new SpriteBatch(GraphicsDevice);

			mFont = Content.Load<SpriteFont>("TahomaFont");
			mFont2 = Content.Load<SpriteFont>("Font2");
			texBlank = Content.Load<Texture2D>("texBlank");
			texButtonUp = Content.Load<Texture2D>("button1");
			texButtonDown = Content.Load<Texture2D>("button1d");
			texPanel = Content.Load<Texture2D>("texPanelMetal");
			texGrid = Content.Load<Texture2D>("texGrid");
			texUIArrow = Content.Load<Texture2D>("texUIArrow");
			texSelection = Content.Load<Texture2D>("texSelection");
			texUITooltip = Content.Load<Texture2D>("texUITooltip");
			texPanelBar = Content.Load<Texture2D>("texPanelBar");
			texIconMoney = Content.Load<Texture2D>("texIconMoney");
			texIconEra = Content.Load<Texture2D>("texIconMoney");
			texIconArtifact = Content.Load<Texture2D>("texIconMoney");
			texCircleRadius = Content.Load<Texture2D>("texCircleRadius");
			texControls = Content.Load<Texture2D>("controls");
			texMiniMapBack = Content.Load<Texture2D>("minimapBack");

			SetupMenu();
			SetupButtons();

			base.LoadContent();
		}

		#region UI Setup
		protected virtual void SetupPanels() {
			int bPHeight = 138;
			int bPTHeight = 30;
			int bPSWidth = 200;

			mBPanel = new Rectangle(0, Game.Window.ClientBounds.Height - bPHeight, Game.Window.ClientBounds.Width, bPHeight);
			mBPanelTop = new Rectangle(0, mBPanel.Y - bPTHeight, Game.Window.ClientBounds.Width, bPTHeight);
			mBPanelSelect = new Rectangle(mBPanel.Width - bPSWidth - PanelPad, mBPanel.Y + PanelPad, bPSWidth, mBPanel.Height - 2 * PanelPad);

			mBPanelTowersL = new Rectangle(mBPanel.X + PanelPad, mBPanel.Y + PanelPad, ButtonWidth + PanelPad * 2, mBPanel.Height - 2 * PanelPad);
			mBPanelTowersR = new Rectangle(mBPanelTowersL.X + mBPanelTowersL.Width + PanelPad, mBPanel.Y + PanelPad, mBPanel.Width - mBPanelTowersL.Width - mBPanelSelect.Width - 4 * PanelPad, mBPanel.Height - 2 * PanelPad);
		}

		protected virtual void SetupButtons() {
			mButtonDirect = new ButtonMenuDirect("Direct", mFont, new Rectangle(mBPanelTowersL.X + PanelPad, mBPanelTowersL.Y + PanelPad, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, true, "Towers that apply damage to a single target");
			mButtonSplash = new ButtonMenuSplash("Splash", mFont, new Rectangle(mButtonDirect.Area.X, mButtonDirect.Area.Y + ButtonHeight + ButtonPad, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, false, "Towers that apply damage to multiple targets");
			mButtonUtility = new ButtonMenUtility("Utility", mFont, new Rectangle(mButtonSplash.Area.X, mButtonSplash.Area.Y + ButtonHeight + ButtonPad, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, false, "Towers that perform support roles");
			mButtonsBuild = new List<Button>();
			mButtonsBuild.AddRange(new Button[] { mButtonDirect, mButtonSplash, mButtonUtility });

			mButtonsDirect = new List<Button>();
			mButtonsDirect.Add(new Button("Rifle", mFont, new Rectangle(mBPanelTowersR.X + PanelPad, mBPanelTowersR.Y + PanelPad, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, false, "Cheap tower that fires single shots"));
			mButtonsDirect.Add(new Button("MG", mFont, new Rectangle(mBPanelTowersR.X + PanelPad, mBPanelTowersR.Y + ButtonHeight + PanelPad, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, false, "Covers an area with bullets"));
			mButtonsDirect.Add(new Button("Pulse", mFont, new Rectangle(mBPanelTowersR.X + PanelPad, mBPanelTowersR.Y + ButtonHeight * 2 + PanelPad, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, false, "Fires accurate pulses of energy"));
			mButtonsDirect.Add(new Button("Gamma", mFont, new Rectangle(mBPanelTowersR.X + PanelPad, mBPanelTowersR.Y + ButtonHeight * 3 + PanelPad, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, false, "Continuously damages its target"));

			mButtonsSplash = new List<Button>();
			mButtonsSplash.Add(new Button("Rocket", mFont, new Rectangle(mBPanelTowersR.X + PanelPad, mBPanelTowersR.Y + PanelPad, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, false, "Fires rockets"));
			mButtonsSplash.Add(new Button("Artillery", mFont, new Rectangle(mBPanelTowersR.X + PanelPad, mBPanelTowersR.Y + PanelPad + ButtonHeight, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, false, "Fires long range shells"));
			mButtonsSplash.Add(new Button("Flame", mFont, new Rectangle(mBPanelTowersR.X + PanelPad, mBPanelTowersR.Y + PanelPad + ButtonHeight * 2, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, false, "Shoots fire"));


			mButtonsUtility = new List<Button>();
			mButtonsUtility.Add(new Button("Command", mFont, new Rectangle(mBPanelTowersR.X + PanelPad, mBPanelTowersR.Y + PanelPad, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, false, "Enhances nearby towers' attributes"));
			mButtonsUtility.Add(new Button("Concussion", mFont, new Rectangle(mBPanelTowersR.X + PanelPad, mBPanelTowersR.Y + PanelPad + ButtonHeight, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, false, "Slows Nearby Enemies"));

			mButtonsMenu = new List<Button>();
			mButtonsMenu.Add(new Button("Controls", mFont, new Rectangle(mMenuBounds.X + (mMenuBounds.Width - ButtonWidth) / 2, mMenuBounds.Y + 80, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, false, "Display controls"));
			mButtonsMenu.Add(new Button("Quit", mFont, new Rectangle(mMenuBounds.X + (mMenuBounds.Width - ButtonWidth) / 2, mMenuBounds.Y + 120, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, false, "Exits the game"));
			mButtonsMenu.Add(new Button("Restart", mFont, new Rectangle(mMenuBounds.X + (mMenuBounds.Width - ButtonWidth) / 2, mMenuBounds.Y + 160, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, false, "Restarts the game"));

			mButtonUpgrade = new ButtonUpgrade("Upgrade", mFont, new Rectangle(mBPanelSelect.X - PanelPad * 2 - ButtonWidth, mBPanelSelect.Bottom - ButtonHeight - PanelPad, ButtonWidth, ButtonHeight), texButtonUp, texButtonDown, false, "Improves this tower");
			mButtonUpgrade.Show = true;

			foreach (Button b in mButtonsDirect)
				b.Show = true;
		}
		#endregion

		#region UI Control
		public void UpdateInput() {
			UpdateMouse();
			UpdateKeyboard();
			UpdatePushedButtons();
		}

		public void DrawUIBack() {
			if (mBuildMode) {
				mSpriteBatch.Draw(World.Map.CollisionTex, World.Map.Bounds, new Color(255, 0, 0, 20));
				if (Input.MouseTile.Intersects(World.Map.Bounds))
					DrawTileHighlight();
				DrawGrid();
			}

			DrawSelectionBox();
			DrawBuildCircle();
		}

		private void DrawSelectionBox() {
			if (!mBuildMode && mSelectedTower == null) {
				foreach (Tower t in World.Towers) {
					if (Input.Bounds.Intersects(t.TowerBase)) {
						mSpriteBatch.Draw(texCircleRadius, new Rectangle((int)t.Center.X - t.Range, (int)t.Center.Y - t.Range, t.Range * 2, t.Range * 2), null, new Color(255, 255, 255, mFadeRange.UpdateAndValue()), 0, Vector2.Zero, SpriteEffects.None, 0);
						mSpriteBatch.Draw(texSelection, t.TowerBase, new Color(255, 255, 255, fadeSelection.UpdateAndValue()));
						break;
					}
				}
			}

			if (mSelectedTower != null) {
				mSpriteBatch.Draw(texCircleRadius, new Rectangle((int)mSelectedTower.Center.X - mSelectedTower.Range, (int)mSelectedTower.Center.Y - mSelectedTower.Range, mSelectedTower.Range * 2, mSelectedTower.Range * 2), null, new Color(255, 255, 255, mFadeRange.UpdateAndValue()), 0, Vector2.Zero, SpriteEffects.None, 0);
				mSpriteBatch.Draw(texSelection, mSelectedTower.TowerBase, Color.White);
			}
		}

		public void DrawUIFront() {
			DrawPanels();
			DrawAllButtons();

			if (!mBuildMode && !mDrawMenu)
				DrawTooltip();
			if (mDrawMenu)
				DrawMenu();
			if (mDisplayControls)
				DisplayControls();

			if (mSelectedTower != null && mTowerToBeBuilt == null)
				DrawSelectionInfo();

			if (mTowerToBeBuilt != null) {
				mTowerToBeBuilt.DrawUpgradeDescription(mSpriteBatch, mFont, new Vector2(mBPanelTowersR.X + ButtonWidth + 30, mBPanelTowersR.Y + PanelPad));
				mTowerToBeBuilt.DrawTowerDescription(mSpriteBatch, mFont2, new Vector2(430, mBPanelTowersR.Y + PanelPad));

				mSpriteBatch.Draw(mTowerToBeBuilt.Texture, new Rectangle(mBPanelSelect.X + PanelPad, mBPanelSelect.Y + PanelPad, 60, 60), Color.White);
			}

			DrawMinimap();
			DrawTestingInfo();

			if (World.Status.Lost)
				DisplayLostScreen();

			if (!World.StartWaves && !mDrawMenu && !mDisplayControls)
				DrawStartButton();

			if (World.GamePaused && !mDrawMenu && !mDisplayControls) {
				float tW = mFont.MeasureString("Pause").X;
				float tH = mFont.MeasureString("Pause").Y;
				mSpriteBatch.DrawString(mFont, "Pause", new Vector2((Game.Window.ClientBounds.Width - tW) / 2, (Game.Window.ClientBounds.Height - tH) / 2 - 100), Color.White);
			}
		}

		private void DrawStartButton() {
			Color color = Color.White;
			string startString = "Spiel starten";
			startButtonArea = new Rectangle((int)(Game.Window.ClientBounds.Width - mFont.MeasureString(startString).X) / 2, (int)(Game.Window.ClientBounds.Height - mFont.MeasureString(startString).Y) / 2, (int)mFont.MeasureString(startString).X, (int)mFont.MeasureString(startString).Y);

			if (!mBuildMode && startButtonArea.Contains(Input.BoundsReal))
				color = Color.LightBlue;
			else if (mBuildMode)
				color = new Color(255, 255, 255, 64);

			mSpriteBatch.DrawString(mFont, startString, new Vector2((Game.Window.ClientBounds.Width - mFont.MeasureString(startString).X) / 2, (Game.Window.ClientBounds.Height - mFont.MeasureString(startString).Y) / 2), color);
		}

		private void DrawTestingInfo() {
			if (DebugInfo == false)
				return;

			string text;
			int projectiles = 0;
			foreach (Tower t in World.Towers)
				projectiles += t.ProjectileCount;

			var lineHeight = 20;

			text = string.Format("Created: {0} | Destroyed: {1} | Survived: {2}", World.Status.Created, World.Status.Kills, World.Status.Survived);
			DrawStringShadowed(mFont, text, new Vector2(1, lineHeight * 0), Color.White, Color.Black);

			text = "Graphics Quality: " + World.Status.GraphicsQuality;
			DrawStringShadowed(mFont, text, new Vector2(1, lineHeight * 1), Color.White, Color.Black);

			text = "Active Projectiles: " + projectiles;
			DrawStringShadowed(mFont, text, new Vector2(1, lineHeight * 2), Color.White, Color.Black);

			text = "Animation Effects: " + World.ProjectileEffects.Count;
			DrawStringShadowed(mFont, text, new Vector2(1, lineHeight * 3), Color.White, Color.Black);

			text = "Active Towers: " + World.Towers.Count;
			DrawStringShadowed(mFont, text, new Vector2(1, lineHeight * 4), Color.White, Color.Black);

			text = "Wave Type: " + World.UnitType;
			DrawStringShadowed(mFont, text, new Vector2(1, lineHeight * 5), Color.White, Color.Black);

			text = "Camera: " + mCamera;
			DrawStringShadowed(mFont, text, new Vector2(1, lineHeight * 6), Color.White, Color.Black);

			text = "Mouse: " + Input.PositionReal;
			DrawStringShadowed(mFont, text, new Vector2(1, lineHeight * 7), Color.White, Color.Black);

			text = "Difficult: " + World.GameDifficult;
			DrawStringShadowed(mFont, text, new Vector2(1, lineHeight * 8), Color.White, Color.Black);
		}

		private void DrawStringShadowed(SpriteFont font, string text, Vector2 pos, Color textCol, Color shadowCol, float rot = 0, Vector2 origin = new Vector2(), float scale = 0.35f, SpriteEffects eff = SpriteEffects.None, float depth = 0) {
			mSpriteBatch.DrawString(font, text, pos + new Vector2(1, -1), shadowCol, rot, origin, scale, eff, depth);
			mSpriteBatch.DrawString(font, text, pos, textCol, rot, origin, scale, eff, depth);
		}

		private void DrawMinimap() {
			Rectangle drawTo;
			Vector2 drawToV;
			Color pColor = Color.Black;
			Color uColor = Color.White;
			Color tColor = new Color(20, 240, 20, 255);
			Color prColor = Color.White;

			mSpriteBatch.Draw(texMiniMapBack, new Rectangle(mMinimap.X - 5, mMinimap.Y - 5, mMinimap.Width + 10, mMinimap.Height + 10), new Color(255, 255, 255, 255));
			if (mExpanded)
				mSpriteBatch.Draw(texBlank, new Rectangle(0, 0, mScreenSize.Width, mScreenSize.Height), new Color(0, 0, 0, 180));
			mSpriteBatch.Draw(World.texMap, mMinimap, Color.White);

			Rectangle theBase = World.MapBaseArea;
			theBase.X = (int)(theBase.X * mMinimapRatio.X + mMinimap.X);
			theBase.Y = (int)(theBase.Y * mMinimapRatio.Y + mMinimap.Y);
			theBase.Width = (int)(theBase.Width * mMinimapRatio.X);
			theBase.Height = (int)(theBase.Height * mMinimapRatio.Y);
			mSpriteBatch.Draw(texBlank, theBase, new Color(0, 200, 200, 230));

			drawTo = new Rectangle((int)(mCamera.ViewArea.X * mMinimapRatio.X + mMinimap.X), (int)(mCamera.ViewArea.Y * mMinimapRatio.Y + mMinimap.Y), (int)(mCamera.ViewArea.Width * mMinimapRatio.X), (int)(mCamera.ViewArea.Height * mMinimapRatio.Y));
			mSpriteBatch.Draw(texBlank, drawTo, null, new Color(200, 200, 255, 80), 0, Vector2.Zero, SpriteEffects.None, 0.13f);

			if (DrawPaths) {
				foreach (Path p in World.Paths) {
					drawToV = new Vector2(p.Position.X * mMinimapRatio.X + mMinimap.X, p.Position.Y * mMinimapRatio.Y + mMinimap.Y);
					mSpriteBatch.Draw(texBlank, drawToV, p.Rectangle, pColor, p.Angle, Vector2.Zero, mMinimapRatio.X, SpriteEffects.None, 0.11f);
				}


				foreach (Crossroad c in World.Crossroads) {
					drawToV = new Vector2(c.Position.X * mMinimapRatio.X + mMinimap.X, c.Position.Y * mMinimapRatio.Y + mMinimap.Y);
					mSpriteBatch.Draw(texBlank, drawToV, c.Area, pColor, 0, Vector2.Zero, mMinimapRatio.X, SpriteEffects.None, 0.12f);
				}
			}

			foreach (Tower t in World.Towers) {
				if (World.GameDisplayTowerLvls)
					tColor = new Color((byte)(t.LevelPercent * 255), (byte)(255 - t.LevelPercent * 255), 0, 255);
				else
					tColor = t.Color;
				drawToV = new Vector2(t.Position.X * mMinimapRatio.X + mMinimap.X, t.Position.Y * mMinimapRatio.Y + mMinimap.Y);
				mSpriteBatch.Draw(texBlank, drawToV, t.TowerBase, tColor, 0, Vector2.Zero, mMinimapRatio.X, SpriteEffects.None, 0.11f);

				if (mExpanded) {
					foreach (Projectile p in t.Projectiles) {
						drawToV = new Vector2(p.Position.X * mMinimapRatio.X + mMinimap.X, p.Position.Y * mMinimapRatio.Y + mMinimap.Y);
						mSpriteBatch.Draw(texBlank, drawToV, p.Area, prColor, p.Angle, Vector2.Zero, mMinimapRatio.X, SpriteEffects.None, 0.1f);
					}
				}
			}

			foreach (Unit u in World.Waves.GetUnits()) {
				drawToV = new Vector2(u.Position.X * mMinimapRatio.X + mMinimap.X, u.Position.Y * mMinimapRatio.Y + mMinimap.Y);
				mSpriteBatch.Draw(texBlank, drawToV, u.Rectangle, uColor, 0, Vector2.Zero, mMinimapRatio.X, SpriteEffects.None, 0.99f);
			}

		}

		private void ExpandMinimap() {
			if (!mExpanded) {
				mMinimap.Height = (int)(Game.Window.ClientBounds.Height * 0.9f);
				mMinimap.Width = mMinimap.Height;
				mMinimap.Y = (int)(mScreenSize.Y + (mScreenSize.Height - mMinimap.Height) / 2);
				mMinimap.X = (int)(mScreenSize.X + (mScreenSize.Width - mMinimap.Width) / 2);
			} else {
				mMinimap = mMinimapOrig;
			}

			mExpanded = !mExpanded;
			mMinimapRatio = new Vector2((float)mMinimap.Width / World.Map.Bounds.Width, (float)mMinimap.Height / World.Map.Bounds.Height);
		}
		#endregion

		#region Mouse/Selection Methods
		private void UpdateMouse() {
			if (mBuildMode)
				mCanBuild = CanBuild();

			if (Input.IsButtonDown(EMouseButtons.LeftButton))
				MoveCam();
			else if (Input.WasButtonPressed(EMouseButtons.LeftButton)) {
				if (!World.StartWaves && !mBuildMode && startButtonArea.Contains(Input.PositionReal))
					World.StartWaves = true;

				UpdateSelection();
				CheckButtons();
				CheckBuilding();
			} else if (Input.WasButtonPressed(EMouseButtons.RightButton)) {
				if (mBuildMode)
					ExitBuildMode();
				else
					mSelectedTower = null;
			}

		}

		private bool CanBuild() {
			if (mBPanel.Contains(Input.BoundsReal) || mMinimap.Contains(Input.BoundsReal) || mBPanelTop.Contains(Input.BoundsReal))
				return false;
			if (!World.Map.IsBuildable(Input.MouseTile))
				return false;
			return true;
		}

		private void CheckBuilding() {
			TowerType(mBuildType);

			if (mBuildType == null || !mBuildMode || !mCanBuild)
				return;
			if (!World.Map.Bounds.Contains(Input.MouseTile) || World.Status.Money < mTowerToBeBuilt.Cost)
				return;

			World.BuildTower(Input.MouseTile, mBuildType);
			World.Status.Money -= mTowerToBeBuilt.Cost;
		}


		public virtual void TowerType(string buildType) {
			switch (buildType) {
				default:
					mTowerToBeBuilt = null;
					mCanBuild = false;
					break;
			}
		}

		private void DrawBuildCircle() {
			Rectangle circleArea;
			if (mTowerToBeBuilt != null) {
				circleArea = new Rectangle(Input.MouseTile.X + Input.MouseTile.Width / 2 - mTowerToBeBuilt.Range, Input.MouseTile.Y + Input.MouseTile.Height / 2 - mTowerToBeBuilt.Range, mTowerToBeBuilt.Range * 2, mTowerToBeBuilt.Range * 2);
				mSpriteBatch.Draw(texCircleRadius, circleArea, null, new Color(255, 255, 255, mFadeRange.UpdateAndValue()), 0, Vector2.Zero, SpriteEffects.None, 0);
			}
		}

		private void MoveCam() {
			if (!Input.BoundsReal.Intersects(mMinimap))
				return;

			Vector2 mmMouse;
			mmMouse = new Vector2((Input.PositionReal.X - mMinimap.X) / mMinimapRatio.X, (Input.PositionReal.Y - mMinimap.Y) / mMinimapRatio.Y);
			mCamera.Focus(mmMouse);
		}

		private void UpdateSelection() {
			if (!Input.BoundsReal.Intersects(World.Map.Bounds) || mBuildMode)
				return;

			foreach (Tower t in World.Towers)
				if (Input.Bounds.Intersects(t.TowerBase)) {
					mSelectedTower = t;
					break;
				}
		}

		private void DrawTileHighlight() {
			Color color;
			if (mCanBuild && mTowerToBeBuilt != null && mTowerToBeBuilt.Cost <= World.Status.Money)
				color = new Color(255, 255, 255, fadeBuild.UpdateAndValue());
			else
				color = new Color(255, 0, 0, fadeNoBuild.UpdateAndValue());
			mSpriteBatch.Draw(texBlank, Input.MouseTile, color);
		}

		private void DrawSelectionInfo() {
			Color color = Color.White;
			int tGSide = 60;
			float ratio = tGSide / mSelectedTower.DrawArea.Width;
			int sDrawWidth = (int)(ratio * mSelectedTower.DrawArea.Width);
			int sDrawHeight = (int)(ratio * mSelectedTower.DrawArea.Height);
			int sDrawY;
			Vector2 textPos = new Vector2(mBPanelSelect.X + PanelPad, mBPanelSelect.Y + PanelPad);
			float tScale = 0.4f;
			int tSpace = 20;

			Rectangle tGraphic = new Rectangle(mBPanelSelect.X - PanelPad * 3 - tGSide, mBPanelSelect.Y + PanelPad, tGSide, tGSide);

			sDrawHeight = (int)((float)mSelectedTower.Texture.Height / mSelectedTower.Texture.Width * tGraphic.Width);
			sDrawY = tGraphic.Y - sDrawHeight + tGraphic.Height;
			Rectangle SDrawArea = new Rectangle(tGraphic.X, sDrawY, tGraphic.Width, sDrawHeight);

			mSpriteBatch.Draw(mSelectedTower.Texture, SDrawArea, new Rectangle(0, 0, mSelectedTower.Texture.Width, mSelectedTower.Texture.Height), color);
			mSpriteBatch.DrawString(mFont, mSelectedTower.NameDisplay, textPos, color, 0, Vector2.Zero, tScale, SpriteEffects.None, 0);

			tScale = 0.3f;

			mSpriteBatch.DrawString(mFont, "Level: " + mSelectedTower.Level, new Vector2(textPos.X, textPos.Y + tSpace), color, 0, Vector2.Zero, tScale, SpriteEffects.None, 0);
			mSelectedTower.DrawStatusDescription(mSpriteBatch, mFont, textPos, tSpace, color, tScale);

			if (mTowerToBeBuilt == null) {
				string label2 = "Sell for " + mSelectedTower.CurrentWorth() + "€";
				mSpriteBatch.DrawString(mFont, label2, new Vector2(400, mBPanel.Y + 100), Color.White, 0, Vector2.Zero, tScale, SpriteEffects.None, 0);
				if (mSelectedTower.UpgradeCost != 0)
					mSelectedTower.DrawUpgradeInfo(mSpriteBatch, mFont, new Vector2(400, mBPanel.Y + 10));
			}

		}

		private void DrawTooltip() {
			Rectangle tooltip;
			string label;
			int width, height;
			float scale = 0.4f;

			foreach (Tower t in World.Towers) {
				if (Input.Bounds.Intersects(t.TowerBase) == false)
					continue;
				label = t.NameDisplay;
				width = (int)(mFont.MeasureString(label).X * scale);
				height = (int)(mFont.MeasureString(label).Y * scale);
				tooltip = new Rectangle(Input.PositionReal.X, Input.PositionReal.Y - 15, width, height);
				mSpriteBatch.Draw(texBlank, tooltip, new Color(50, 50, 50, 128));
				mSpriteBatch.DrawString(mFont, label, new Vector2(tooltip.X, tooltip.Y), Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
				break;
			}

			if (mBPanel.Contains(Input.PositionReal)) {
				DrawButtonToolTip(mButtonsDirect);
				DrawButtonToolTip(mButtonsSplash);
				DrawButtonToolTip(mButtonsUtility);
			}
		}

		private void DrawButtonToolTip(IEnumerable<Button> buttons) {
			Rectangle tooltip;
			string label;
			int width, height;
			float scale = 0.4f;
			foreach (Button b in buttons) {
				if (b.Show == false || Input.BoundsReal.Intersects(b.Area) == false)
					continue;
				label = b.Tooltip;
				width = (int)(mFont.MeasureString(label).X * scale);
				height = (int)(mFont.MeasureString(label).Y * scale);
				tooltip = new Rectangle(Input.PositionReal.X, Input.PositionReal.Y - 15, width, height);
				mSpriteBatch.Draw(texBlank, tooltip, new Color(50, 50, 50, 128));
				mSpriteBatch.DrawString(mFont, label, new Vector2(tooltip.X, tooltip.Y), Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
				break;
			}
		}
		#endregion

		private void UpdateKeyboard() {

			if (Input.WasKeyPressed(Keys.D)) {
				// Debug info [D]

				DebugInfo = !DebugInfo;
			} else if (Input.WasKeyPressed(Keys.Tab) && Input.IsKeyDown(Keys.LeftShift) == false) {
				// Jump to next tower [Tab]

				if (World.Towers.Count > 0) {
					if (mSelectedTower != null) {
						int i = World.Towers.IndexOf(mSelectedTower);
						if (i != -1) {
							// Previous tower
							if (Input.IsKeyDown(Keys.LeftControl) || Input.IsKeyDown(Keys.RightControl)) {
								i = ((i - 1) < 0 ? World.Towers.Count - 1 : i - 1);
							} else {
								i = ((i + 1) < World.Towers.Count ? i + 1 : 0);
							}
							mSelectedTower = World.Towers[i] as Tower;
						}
					} else {
						mSelectedTower = World.Towers[0] as Tower;
					}
				}
			} else if (Input.WasKeyPressed(Keys.Tab) && Input.IsKeyDown(Keys.LeftShift)) {
				// Jump to next tower without full upgrade [SHIFT+Tab]

				if (World.Towers.Count > 0) {
					if (mSelectedTower != null) {
						int i = World.Towers.IndexOf(mSelectedTower);
						if (i != -1) {
							for (i++; i < World.Towers.Count; i++) {
								if ((World.Towers[i] as Tower).Level < Tower.MAX_LVL) {
									break;
								}
							}
							if (i >= World.Towers.Count) {
								int iBase = World.Towers.IndexOf(mSelectedTower) + i;
								for (i = 0; i < iBase; i++) {
									if ((World.Towers[i] as Tower).Level < Tower.MAX_LVL) {
										break;
									}
								}
								if (i >= World.Towers.Count) {
									// Failed to find a tower without upgrade?
									i = 0;
								}
							}
							mSelectedTower = World.Towers[i] as Tower;
						}
					} else {
						mSelectedTower = World.Towers[0] as Tower;
					}
				}
			} else if (Input.WasKeyPressed(Keys.U)) {
				// Uprade selected tower [U]

				if (mSelectedTower != null) {
					mButtonUpgrade.Press();
				}
			} else if (Input.WasKeyPressed(Keys.Delete)) {
				// Delete tower [DEL]

				if (mSelectedTower != null) {
					World.Status.Money += mSelectedTower.CurrentWorth();
					World.Map.RemoveTower(mSelectedTower.TowerBase);
					World.Towers.Remove(mSelectedTower);
					mSelectedTower = null;
				}
			} else if (Input.WasKeyPressed(Keys.Escape)) {
				// Menu [ESC]

				if (mBuildMode) {
					ExitBuildMode();
				}
				mDrawMenu = !mDrawMenu;
				mDisplayControls = false;
				World.GamePaused = mDrawMenu;
			} else if (Input.WasKeyPressed(Keys.M) && !Input.IsKeyDown(Keys.C)) {
				// Minimap extend [M]

				ExpandMinimap();
			} else if (Input.WasKeyPressed(Keys.LeftAlt) || Input.WasKeyPressed(Keys.RightAlt)) {
				// Tower level [ALT]

				World.GameDisplayTowerLvls = !World.GameDisplayTowerLvls;
			} else if (Input.WasKeyPressed(Keys.P)) {
				// Pause [P]

				if (!mDrawMenu) {
					World.GamePaused = !World.GamePaused;
				}
			} else if (Input.WasKeyPressed(Keys.S)) {
				// Sound on/off [S]

				World.Status.Sound = !World.Status.Sound;
			} else if (Input.WasKeyPressed(Keys.T)) {
				// Unit paths hide/show [T]

				DrawPaths = !DrawPaths;
			} else if (Input.IsKeyDown(Keys.G) && Input.WasKeyPressed(Keys.OemPlus)) {
				// Graphic quality increase [G+]

				if (World.Status.GraphicsQuality < 1f) {
					World.Status.GraphicsQuality += 0.1f;
				}
			} else if (Input.IsKeyDown(Keys.G) && Input.WasKeyPressed(Keys.OemMinus)) {
				// Graphic quality decrease [G-]

				if (World.Status.GraphicsQuality > 0.1f) {
					World.Status.GraphicsQuality -= 0.1f;
				}
			} else if (Input.IsKeyDown(Keys.C) && Input.WasKeyPressed(Keys.N)) {
				// Easy mode

				World.SetGameDifficult(EGameDifficult.Easy);
			} else if (Input.IsKeyDown(Keys.C) && Input.WasKeyPressed(Keys.M)) {
				// Medium mode

				World.SetGameDifficult(EGameDifficult.Medium);
			} else if (Input.IsKeyDown(Keys.C) && Input.WasKeyPressed(Keys.H)) {
				// Hard mode

				World.SetGameDifficult(EGameDifficult.Hard);
			} else if (Input.IsKeyDown(Keys.C) && Input.IsKeyDown(Keys.W) && Input.WasKeyPressed(Keys.OemPlus)) {
				// Wave num increase

				World.Status.Wave++;
				World.SpawnHealth = 100 + (World.Status.Wave * 10);
				World.UpdateWaveSpawnSize();
			} else if (Input.IsKeyDown(Keys.C) && Input.IsKeyDown(Keys.M) && Input.WasKeyPressed(Keys.OemPlus)) {
				// Money increase

				World.Status.Money += 10000;
			}

			// Movement using arrows, increased while hold CTRL
			int scrollValue = ScrollValue * (Input.IsKeyDown(Keys.LeftControl) || Input.IsKeyDown(Keys.RightControl) ? 5 : 1);
			if (Input.IsKeyDown(Keys.Down)) {
				mCamera.Move(new Vector2(0, scrollValue));
			} else if (Input.IsKeyDown(Keys.Up)) {
				mCamera.Move(new Vector2(0, -scrollValue));
			}
			if (Input.IsKeyDown(Keys.Left)) {
				mCamera.Move(new Vector2(-scrollValue, 0));
			} else if (Input.IsKeyDown(Keys.Right)) {
				mCamera.Move(new Vector2(scrollValue, 0));
			}

			if (Input.IsKeyDown(Keys.G) == false && Input.IsKeyDown(Keys.OemPlus)) {
				// Zoom in [+]

				mCamera.ZoomIn(ZoomValue);
			} else if (Input.IsKeyDown(Keys.G) == false && Input.IsKeyDown(Keys.OemMinus)) {
				// Zoom out [-]

				mCamera.ZoomOut(ZoomValue);
			} else if (Input.ScrollWheelDelta != 0) {
				// Zoom [Scroll]

				float zoom = Input.ScrollWheelDelta / 10;
				if (zoom > 0) {
					mCamera.ZoomIn(zoom);
				} else {
					mCamera.ZoomOut(-zoom);
				}
			}


		}

		private void DrawGrid() {
			Color gridColor = new Color(0, 0, 0, 128);
			Rectangle gridSquare;

			int left = mCamera.ViewArea.X / DefenderWorld.TileSize;
			int right = mCamera.ViewArea.Right / DefenderWorld.TileSize;
			int top = mCamera.ViewArea.Y / DefenderWorld.TileSize;
			int bottom = mCamera.ViewArea.Bottom / DefenderWorld.TileSize;

			for (int x = left; x < right + 1; x++) {
				for (int y = top; y < bottom; y++) {
					gridSquare = new Rectangle(x * DefenderWorld.TileSize, y * DefenderWorld.TileSize, DefenderWorld.TileSize, DefenderWorld.TileSize);
					mSpriteBatch.Draw(texGrid, gridSquare, gridColor);
				}
			}
		}

		#region Buttons
		private void UpdatePushedButtons() {
			if (mButtonUpgrade.Down) {
				bPressTimer += 10;
				if (bPressTimer > 40) {
					mButtonUpgrade.Release();
					bPressTimer = 0;
				}
			}
		}

		private void CheckButtons() {
			if (!mDrawMenu) {
				#region Check Panel Buttons
				if (Input.BoundsReal.Intersects(mButtonUpgrade.Area) && mSelectedTower != null) {
					mButtonUpgrade.Press();
				}
				#endregion

				#region Check Build Type Buttons
				if (Input.BoundsReal.Intersects(mButtonDirect.Area)) {
					ExitBuildMode();
					mButtonDirect.Press();
					mButtonSplash.Release();
					mButtonUtility.Release();

					foreach (Button b in mButtonsDirect)
						b.Show = true;
					foreach (Button b in mButtonsSplash)
						b.Show = false;
					foreach (Button b in mButtonsUtility)
						b.Show = false;
				} else if (Input.BoundsReal.Intersects(mButtonSplash.Area)) {
					ExitBuildMode();
					mButtonDirect.Release();
					mButtonSplash.Press();
					mButtonUtility.Release();

					foreach (Button b in mButtonsDirect)
						b.Show = false;
					foreach (Button b in mButtonsSplash)
						b.Show = true;
					foreach (Button b in mButtonsUtility)
						b.Show = false;
				} else if (Input.BoundsReal.Intersects(mButtonUtility.Area)) {
					ExitBuildMode();
					mButtonDirect.Release();
					mButtonSplash.Release();
					mButtonUtility.Press();

					foreach (Button b in mButtonsDirect)
						b.Show = false;
					foreach (Button b in mButtonsSplash)
						b.Show = false;
					foreach (Button b in mButtonsUtility)
						b.Show = true;
				}
				#endregion

				if (mButtonDirect.Down)
					CheckTowerButtons(mButtonsDirect);

				if (mButtonSplash.Down)
					CheckTowerButtons(mButtonsSplash);

				if (mButtonUtility.Down)
					CheckTowerButtons(mButtonsUtility);

			} else {
				foreach (Button b in mButtonsMenu) {
					if (b.Label == "Quit" && Input.BoundsReal.Intersects(b.Area))
						World.Game.Exit();
					else if (b.Label == "Controls" && Input.BoundsReal.Intersects(b.Area)) {
						mDrawMenu = false;
						mDisplayControls = true;
					} else if (b.Label == "Restart" && Input.BoundsReal.Intersects(b.Area)) {
						World.GameRestart = true;
					}
				}
			}
		}

		private void CheckTowerButtons(IEnumerable<Button> buttons) {
			Button lastDown = null, newDown = null;
			bool somethingPressed = false;

			foreach (Button b in buttons) {
				if (Input.BoundsReal.Intersects(b.Area)) {
					newDown = b;
					somethingPressed = true;
					mBuildType = b.Label;
					mBuildMode = true;
				}
				if (b.Down)
					lastDown = b;
				b.Release();
			}
			if (!somethingPressed && lastDown != null)
				lastDown.Press();
			if (newDown != null) {
				newDown.Press();
			}
		}

		private void ExitBuildMode() {
			mBuildType = null;
			mTowerToBeBuilt = null;
			mBuildMode = false;
			mCanBuild = false;

			foreach (Button b in mButtonsDirect)
				b.Release();
			foreach (Button b in mButtonsSplash)
				b.Release();
			foreach (Button b in mButtonsUtility)
				b.Release();
		}

		private void DrawAllButtons() {
			Color bColor = new Color(255, 255, 255, 255);
			Color lColor = new Color(255, 255, 255, 255);

			if (mSelectedTower != null && mSelectedTower.Level < Tower.MAX_LVL) {
				if (mButtonUpgrade.Down) {
					lColor = Color.White;
				}
				if (mTowerToBeBuilt == null) {
					if (World.Status.Money < mSelectedTower.UpgradeCost) {
						lColor = Color.Red;
					}
					mSpriteBatch.Draw(mButtonUpgrade.Texture, mButtonUpgrade.Area, bColor);
					mSpriteBatch.DrawString(mFont, mButtonUpgrade.Label, mButtonUpgrade.LabelPosition, lColor, 0, Vector2.Zero, mButtonUpgrade.LabelScale, SpriteEffects.None, 0);
				}
			}


			DrawButtons(mButtonsBuild);
			if (mButtonDirect.Down)
				DrawButtons(mButtonsDirect);
			else if (mButtonSplash.Down)
				DrawButtons(mButtonsSplash);
			else if (mButtonUtility.Down)
				DrawButtons(mButtonsUtility);
		}

		private void DrawButtons(IEnumerable<Button> buttons) {
			Color lColor;
			Color bColor;

			foreach (Button b in buttons) {
				if (b.Down) {
					bColor = Color.White;
					lColor = Color.White;
				} else {
					bColor = new Color(230, 230, 250, 255);
					lColor = new Color(255, 255, 255, 200);
				}

				mSpriteBatch.Draw(b.Texture, b.Area, bColor);
				mSpriteBatch.DrawString(mFont, b.Label, b.LabelPosition, lColor, 0, Vector2.Zero, b.LabelScale, SpriteEffects.None, 0);
			}
		}
		#endregion

		private void DrawPanels() {
			Color pColor = new Color(30, 30, 30, 64);
			Rectangle money = new Rectangle(mBPanelTop.X + 30, mBPanelTop.Y + 5, 20, 20);

			mSpriteBatch.Draw(texPanel, mBPanel, null, new Color(50, 50, 50, 100), 0, Vector2.Zero, SpriteEffects.None, 0.3f);

			mSpriteBatch.Draw(texBlank, mBPanelTowersL, null, pColor, 0, Vector2.Zero, SpriteEffects.None, 0.3f);
			mSpriteBatch.Draw(texBlank, mBPanelTowersR, null, pColor, 0, Vector2.Zero, SpriteEffects.None, 0.3f);

			mSpriteBatch.Draw(texBlank, mBPanelSelect, pColor);

			pColor = new Color(100, 100, 100, 150);
			mSpriteBatch.Draw(texPanelBar, mBPanelTop, pColor);
			mSpriteBatch.Draw(texIconMoney, money, Color.White);

			string text = World.Status.Money.ToString();
			money.X += money.Width + 2;
			mSpriteBatch.DrawString(mFont, text, new Vector2(money.X, money.Y), Color.White, 0, Vector2.Zero, 0.4f, SpriteEffects.None, 0);

			money.X = World.Game.Window.ClientBounds.Width / 2 - 220;
			mSpriteBatch.DrawString(mFont, string.Format("Welle {0} ({1:00.0}sec)", World.Status.Wave, World.NextWaveIn / 1000), new Vector2(money.X, money.Y), Color.White, 0, Vector2.Zero, 0.4f, SpriteEffects.None, 0);

			money.X = World.Game.Window.ClientBounds.Width / 2 + 20;
			mSpriteBatch.DrawString(mFont, string.Format("{0} Gegner mit {1} HP", World.SpawnSize, World.SpawnHealth), new Vector2(money.X, money.Y), Color.White, 0, Vector2.Zero, 0.4f, SpriteEffects.None, 0);

			money.X = World.Game.Window.ClientBounds.Width - 150;
			mSpriteBatch.DrawString(mFont, string.Format("Leben: {0} / {1}", World.Status.Health - World.Status.Survived, World.Status.Health), new Vector2(money.X, money.Y), Color.White, 0, Vector2.Zero, 0.4f, SpriteEffects.None, 0);
		}

		#region Menus
		public void DisplayLostScreen() {
			Rectangle lostArea = new Rectangle(mScreenSize.Width / 2 - 200, mScreenSize.Height / 2 - 150, 400, 300);
			string text = "You Lost!\nKills: " + World.Status.Kills;
			float x = mScreenSize.Width / 2 - mFont.MeasureString(text).X / 2.0f;

			mSpriteBatch.DrawString(mFont, text, new Vector2(x, 60), Color.White, 0, Vector2.Zero, 0.7f, SpriteEffects.None, 0);
		}


		private void SetupMenu() {
			int widthW = World.Game.Window.ClientBounds.Width;
			int heightW = World.Game.Window.ClientBounds.Height;
			int widthM = (int)(widthW * .3);
			int heightM = (int)(heightW * .3);

			mBgDull = new Rectangle(0, 0, widthW, heightW);
			mMenuBounds = new Rectangle((widthW - widthM) / 2, (mapArea.Height - heightM) / 3, widthM, heightM);
		}


		private void DrawMenu() {
			string text;
			int textW;

			mSpriteBatch.Draw(texBlank, mBgDull, new Color(30, 30, 30, 150));
			mSpriteBatch.Draw(texBlank, mMenuBounds, new Color(30, 30, 30, 200));
			DrawButtons(mButtonsMenu);

			text = "Menu";
			textW = (int)mFont.MeasureString(text).X;
			mSpriteBatch.DrawString(mFont, text, new Vector2((mMenuBounds.Width - textW) / 2 + mMenuBounds.X, mMenuBounds.Y + 15), Color.White);
		}

		protected void DisplayControls() {
			int widthW = World.Game.Window.ClientBounds.Width;
			int widthM = texControls.Width;
			int heightM = texControls.Height;

			Rectangle control = new Rectangle((widthW - widthM) / 2, (mapArea.Height - heightM) / 2, widthM, heightM);

			mSpriteBatch.Draw(texBlank, mBgDull, new Color(30, 30, 30, 150));
			mSpriteBatch.Draw(texBlank, control, new Color(30, 30, 30, 200));
			mSpriteBatch.Draw(texControls, control, Color.White);
		}
		#endregion

	}

}
