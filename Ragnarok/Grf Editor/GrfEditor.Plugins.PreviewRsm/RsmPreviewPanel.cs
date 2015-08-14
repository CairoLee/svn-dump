using System;
using System.IO;
using System.Windows.Forms;
using GodLesZ.Library.MonoGame;
using GodLesZ.Library.MonoGame.Geometry.Camera;
using GodLesZ.Library.Ragnarok.MonoGame.Format.Rsm;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GrfEditor.Library.Controls {

	public partial class RsmPreviewPanel : UserControl, IPreviewPanel, IEditorPlugin {
		private Form mParentForm;
		private DrawableRoRsm mRsmFile;

		private GameClock mGameTime;
		private BasicEffect mBasicEffect;
		private MouseCamera mCamera;

		private Vector3 mCenter = Vector3.Zero;
		private Matrix mMatrixWorld;

		private GraphicsDevice GraphicsDevice {
			get { return renderDisplay.GraphicsDevice; }
		}

		public RsmPreviewPanel() {
			InitializeComponent();

			renderDisplay.OnInitialize += new System.EventHandler(renderDisplay_OnInitialize);
			renderDisplay.OnDraw += new System.EventHandler(renderDisplay_OnDraw);
		}


		public void LoadPlugin(Form form) {
			mParentForm = form;
			(mParentForm as IPreviewPanelHost).GetPreviewHost().Controls.Add(this);
		}

		public void LoadMenu(ToolStripMenuItem item) {

		}

		public void UnloadPlugin() {
			(mParentForm as IPreviewPanelHost).GetPreviewHost().Controls.Remove(this);
		}

		public bool IsSupported(string extensions) {
			// TODO: Not yet working
			return false; //extensions == "rsm";
		}

		public bool BlockListView() {
			return true;
		}

		public string GetPluginName() {
			return "Model Preview";
		}

		public string GetPluginDescription() {
			return "Todo";
		}

		public void SetData(byte[] data, string filename) {
			using (MemoryStream ms = new MemoryStream(data)) {
				mRsmFile = new DrawableRoRsm(ms, GraphicsDevice);
			}
		}


		private void renderDisplay_OnInitialize(object sender, EventArgs e) {
			mGameTime = new GameClock();
			mBasicEffect = new BasicEffect(GraphicsDevice);
			mCamera = new MouseCamera(GraphicsDevice);

			Visible = false;
		}

		private void renderDisplay_OnDraw(object sender, EventArgs e) {
			GraphicsDevice.Clear(Color.Black);
			mGameTime.Start();

			mCamera.Update();

			if (mRsmFile != null) {
				mMatrixWorld = Matrix.CreateTranslation(mCamera.PositionAsVector3 - mCenter) * mCamera.MatrixRotation;

				mRsmFile.DrawAll(GraphicsDevice, mBasicEffect, mCamera.MatrixView, mCamera.MatrixProjection, mMatrixWorld);
			}

			mGameTime.Stop();
		}

	}

}
