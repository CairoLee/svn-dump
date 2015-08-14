using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InsaneRO.Cards.Library;
using System.Reflection;
using System.IO;

namespace InsaneRO.Cards.CardBuilder {

	public partial class frmMain : Form {
		private Assembly mAssembly;
		private GameCard mCard = new GameCard();
		private Font mFontElement;
		private Color mColorElement;
		private Font mFontName;
		private Color mColorName;
		private Color mColorNameShadow;
		private Font mFontZeny;
		private Color mColorZeny;
		private Color mColorZenyShadow;
		private Font mFontMobType;
		private Color mColorMobType;
		private Font mFontMobEffect;
		private Color mColorMobEffect;
		private Font mFontMobDesc;
		private Color mColorMobDesc;
		private Font mFontCardAuthor;
		private Color mColorCardAuthor;
		private Font mFontCardStrength;
		private Color mColorCardStrength;

		private Image mBase;
		private Size mCardImageSize;
		private Rectangle mCardBounds, mCardBoundsOrgin;

		public frmMain() {
			InitializeComponent();

			mAssembly = Assembly.GetExecutingAssembly();
			propGrid.SelectedObject = mCard;

			mFontElement = new Font("Arial", 8);
			mFontName = new Font("Georgia", 13);
			mFontZeny = new Font("Georgia", 13);
			mFontMobType = new Font("Courier New", 11, FontStyle.Bold);
			mFontMobEffect = new Font("Courier New", 8);
			mFontMobDesc = new Font("Letter Gothic Std", 7f);
			mFontCardAuthor = new Font("Georgia", 10);

			mColorElement = Color.FromArgb(191, 190, 201);
			mColorName = Color.FromArgb(0, 0, 0);
			mColorNameShadow = Color.FromArgb(255, 255, 255);
			mColorZeny = Color.FromArgb(0, 0, 0);
			mColorZenyShadow = Color.FromArgb(255, 255, 255);
			mColorMobType = Color.FromArgb(0, 0, 0);
			mColorMobEffect = Color.FromArgb(101, 57, 0);
			mColorMobDesc = Color.FromArgb(107, 107, 107);
			mColorCardAuthor = Color.FromArgb(107, 107, 107);

			mFontCardStrength = new Font("Courier New", 11, FontStyle.Bold);
			mColorCardStrength = Color.FromArgb(0, 0, 0);

			mBase = GetRessource("card_blank");
			mCardImageSize = new Size(228, 161);
			mCardBounds = mCardBoundsOrgin = new Rectangle(3, 3, mCardImageSize.Width, mCardImageSize.Height);

			RebuildImage();
		}


		private void propGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
			RebuildImage();
		}

		#region Card Image dragging
		private bool mDragCard = false;
		private Point mDragStart = Point.Empty;
		private void imgPreview_MouseDown(object sender, MouseEventArgs e) {
			mDragCard = true;
			mDragStart = e.Location;
			mCardBoundsOrgin = mCardBounds;
		}

		private void imgPreview_MouseUp(object sender, MouseEventArgs e) {
			mDragCard = false;
		}

		private void imgPreview_MouseMove(object sender, MouseEventArgs e) {
			if (mDragCard == false)
				return;
			Point moving = new Point(e.Location.X - mDragStart.X, e.Location.Y - mDragStart.Y);
			mCardBounds.X = mCardBoundsOrgin.X - moving.X;
			mCardBounds.Y = mCardBoundsOrgin.Y - moving.Y;

			RebuildImage();
		}
		#endregion

		private void btnSave_Click(object sender, EventArgs e) {
			if (imgPreview.Image == null) {
				return;
			}

			using (SaveFileDialog dlg = new SaveFileDialog()) {
				dlg.Filter = "Image (*.png)|*.png";
				dlg.FileName = mCard.MobID + ".png";
				if (dlg.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) {
					return;
				}

				imgPreview.Image.Save(dlg.FileName);
			}
		}


		private void RebuildImage() {
			string basePath = AppDomain.CurrentDomain.BaseDirectory + @"Cards\";

			using (Bitmap bmp = new Bitmap(imgPreview.Width, imgPreview.Height)) {
				string imgPath = basePath + mCard.MobID + ".png";
				if (File.Exists(imgPath) == false)
					imgPath = basePath + "0.png";

				using (Graphics g = Graphics.FromImage(bmp)) {
					// Cardimage
					using (Image cardIllu = GetCardImage(imgPath))
						g.DrawImage(cardIllu, new Rectangle(6, 30, mCardImageSize.Width, mCardImageSize.Height), mCardBounds, GraphicsUnit.Pixel);

					// container
					g.DrawImage(mBase, new Rectangle(0, 0, bmp.Width, bmp.Height), new Rectangle(0, 0, mBase.Width, mBase.Height), GraphicsUnit.Pixel);

					// name
					g.DrawString(mCard.Name, mFontName, new SolidBrush(mColorNameShadow), new PointF(23, 5));
					g.DrawString(mCard.Name, mFontName, new SolidBrush(mColorName), new PointF(22, 4));

					// element
					Image eleIcon = GetRessource("element_" + mCard.ElementType.ToString().ToLower());
					g.DrawImage(eleIcon, new Point(8, 7));
					g.DrawString(mCard.ElementLevel.ToString(), mFontElement, new SolidBrush(mColorElement), new PointF(11, 7));

					// zeny 
					g.DrawString(mCard.Cost.ToString(), mFontZeny, new SolidBrush(mColorZenyShadow), new PointF(207, 4));
					g.DrawString(mCard.Cost.ToString(), mFontZeny, new SolidBrush(mColorZeny), new PointF(206, 3));
					g.DrawImage(GetRessource("zeny"), new Point(218, 5));

					// card type
					g.DrawString("[" + GetCardType(mCard.Type) + "]", mFontMobType, new SolidBrush(mColorMobType), new PointF(5, 202));

					// card desc
					g.DrawString(mCard.EffectText, mFontMobEffect, new SolidBrush(mColorMobEffect), new PointF(12, 218));

					// card fun desc
					g.DrawString(mCard.FunText, mFontMobDesc, new SolidBrush(mColorMobDesc), new PointF(12, 301));

					// card author
					string author = "© 2010 - 2011 " + mCard.Author;
					int w = (int)(g.MeasureString(author, mFontCardAuthor).Width / 2f);
					g.DrawString(author, mFontCardAuthor, new SolidBrush(mColorCardAuthor), new PointF((bmp.Width / 2) - w, 332));

					// card strength/defence
					g.DrawString(mCard.Strength + "/" + mCard.Defence, mFontCardStrength, new SolidBrush(mColorCardStrength), new PointF(200, 282));
				}

				imgPreview.Image = bmp.Clone() as Image;
			}

		}

		private Image GetCardImage(string Filepath) {
			Image NewImage;
			using (Image FullsizeImage = Image.FromFile(Filepath)) {

				FullsizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
				FullsizeImage.RotateFlip(RotateFlipType.Rotate180FlipNone);

				int NewWidth = (int)((float)FullsizeImage.Width * mCard.ImageScale);
				int NewHeight = (int)((float)FullsizeImage.Height * mCard.ImageScale);

				NewImage = FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);
			}

			return NewImage;
		}

		private Image GetRessource(string Resname) {
			return Bitmap.FromStream(mAssembly.GetManifestResourceStream("InsaneRO.Cards.CardBuilder.Images." + Resname + ".png"));
		}

		private string GetCardType(ECardType Type) {
			string strType = Type.ToString();
			for (int i = 1; i < strType.Length; i++) {
				if (strType[i] >= 'A' && strType[i] <= 'Z') {
					string prefix = strType.Substring(0, i);
					string sufix = strType.Substring(i);
					return prefix + ": " + sufix;
				}
			}
			return strType;
		}

	}

}
