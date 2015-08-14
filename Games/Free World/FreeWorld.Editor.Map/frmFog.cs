using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using FileLists = GodLesZ.Library.Xna.Content.FileListLoader;
using FreeWorld.Engine;

namespace FreeWorld.Editor.Map {

	public delegate void OnFogChangeHandler(string Index);
	public delegate void OnDenseHandler(float FogDense);
	public delegate void OnColorHandler(Color Color);

	public partial class frmFog : Form {
		public int FogIndex = -1;
		public float FogDense = 0.5f;
		public Color FogColor = Color.White;

		public event OnDenseHandler OnDense;
		public event OnFogChangeHandler OnFog;
		public event OnColorHandler OnColor;

		private GraphicsDevice mGraphicsDevice;
		private SpriteBatch mSpriteBatch;
		private Texture2D mDisplayTexture;

		public frmFog(GraphicsDevice Device, SpriteBatch SpriteBatch, string Index, float Dense, Color Col) {
			mGraphicsDevice = Device;
			mSpriteBatch = SpriteBatch;
			FogDense = Dense;
			FogColor = Col;

			Application.Idle += delegate {
				FogDisplay.Invalidate();
			};

			InitializeComponent();
			InitializeList();

			if (Index != string.Empty)
				ListFogs.SelectedItem = "Nebel " + Index;
			else
				ListFogs.SelectedIndex = 0;
			SliderDense.Value = (int)(FogDense * 100);
			UpdateColor(FogColor);

			FogDisplay.OnDraw += new EventHandler(FogDisplay_OnDraw);
		}

		private void FogDisplay_OnDraw(object sender, EventArgs e) {
			mGraphicsDevice.Clear(Color.Transparent);

			if (mDisplayTexture == null)
				return;

			mSpriteBatch.Begin();
			mSpriteBatch.Draw(mDisplayTexture, new Rectangle(0, 0, FogDisplay.Width, FogDisplay.Height), FogColor * FogDense);
			mSpriteBatch.End();

		}

		private void InitializeList() {
			ListFogs.Items.Clear();

			ListFogs.Items.Add("<kein Nebel>");
			for (int i = 0; i < FileLists.Instance.Fogs.Count; i++)
				ListFogs.Items.Add(string.Format("Nebel {0}", FileLists.Instance.Fogs[i]));

		}

		private void ListFogs_SelectedIndexChanged(object sender, EventArgs e) {
			if (ListFogs.SelectedIndex == -1)
				return;
			else if (ListFogs.SelectedIndex == 0) {
				mDisplayTexture = null;
				FogIndex = -1;
			} else {
				FogIndex = ListFogs.SelectedIndex - 1;
				mDisplayTexture = EngineCore.ContentLoader.GetFog(FileLists.Instance.Fogs[FogIndex].Filename);
			}

			if (OnFog != null)
				OnFog((FogIndex == -1 ? string.Empty : FileLists.Instance.Fogs[FogIndex].Filename));
		}

		private void SliderDense_Scroll(object sender, EventArgs e) {
			FogDense = ((float)SliderDense.Value / 100f);
			if (OnDense != null)
				OnDense(FogDense);
		}

		private void btnClose_Click(object sender, EventArgs e) {
			FogIndex = -1;
			Close();
		}

		private void btnOk_Click(object sender, EventArgs e) {
			Close();
		}

		private void ColorBox_Click(object sender, EventArgs e) {
			ColorDialog dlg = new ColorDialog();
			dlg.Color = System.Drawing.Color.FromArgb(FogColor.A, FogColor.R, FogColor.G, FogColor.B);
			if (dlg.ShowDialog() != DialogResult.OK)
				return;

			UpdateColor(dlg.Color);
		}

		private void SliderRed_Scroll(object sender, EventArgs e) {
			UpdateColor(System.Drawing.Color.FromArgb(FogColor.A, SliderRed.Value, FogColor.G, FogColor.B));
		}

		private void SliderGreen_Scroll(object sender, EventArgs e) {
			UpdateColor(System.Drawing.Color.FromArgb(FogColor.A, FogColor.R, SliderGreen.Value, FogColor.B));
		}

		private void SliderBlue_Scroll(object sender, EventArgs e) {
			UpdateColor(System.Drawing.Color.FromArgb(FogColor.A, FogColor.R, FogColor.G, SliderBlue.Value));
		}


		private void UpdateColor(Color Color) {
			UpdateColor(System.Drawing.Color.FromArgb(Color.A, Color.R, Color.G, Color.B));
		}
		private void UpdateColor(System.Drawing.Color Color) {
			ColorBox.BackColor = Color;
			SliderRed.Value = Color.R;
			SliderGreen.Value = Color.G;
			SliderBlue.Value = Color.B;
			FogColor = new Color(Color.R, Color.G, Color.B, Color.A);

			if (OnColor != null)
				OnColor(FogColor);
		}

	}

}
