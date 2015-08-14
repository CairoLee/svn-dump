using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using ImageHelper;

namespace Shaiya_Userbar_Generator {

	public partial class frmMain : Form {
		private Userbar mUserbar;
		private Timer mInputTimer;
		private System.Reflection.Assembly mAssembly;

		public frmMain() {
			InitializeComponent();
		}

		private void InitializeUserbar() {
			mUserbar.Width = (int)numWidth.Value;
			mUserbar.Height = (int)numHeight.Value;

			mUserbar.SetCustomFont( comboCustomFont.SelectedItem.ToString(), (float)numCustomFontsize.Value, false, comboCustomFont.SelectedIndex );
			mUserbar.CustomText = txtCustomText.Text;
			mUserbar.CustomTextColor = colorCustomText.SelectedColor;
			mUserbar.CustomTextBorder = chkCustomTextBorder.Checked;
			mUserbar.CustomTextBorderColor = colorCustomTextBorder.SelectedColor;
			mUserbar.CustomTextBorderAlpha = sliderCustomTextBorderOpacity.Value;
			mUserbar.CustomPadRight = positionCustomText.ValueX;
			mUserbar.CustomPadTop = positionCustomText.ValueY;

			mUserbar.BackgroundGradient1 = colorGradient1.SelectedColor;
			mUserbar.BackgroundGradient2 = colorGradient2.SelectedColor;
			mUserbar.BackgroundBorderColor = colorBorder.SelectedColor;
			mUserbar.BackgroundBorder = chkBorder.Checked;
			mUserbar.BackgroundOverlayColor = colorBackgroundOverlay.SelectedColor;
			mUserbar.BackgroundOverlayOpacity = sliderBackgroundOverlayOpacity.Value;
			mUserbar.BackgroundOpacity = sliderBackgroundOpacity.Value;

			mUserbar.BackgroundFixxColor = colorWorkflow.SelectedColor;


			mUserbar.SetShaiyaFont( comboShaiyaFont.SelectedItem.ToString(), (float)numShaiyaFontsize.Value, false, comboShaiyaFont.SelectedIndex );
			mUserbar.ShaiyaTextColor = colorShaiyaFontcolor.SelectedColor;
			mUserbar.ShaiyaTextBorderColor = colorShaiyaFontBorder.SelectedColor;
			mUserbar.ShaiyaTextBorderAlpha = sliderShaiyaFontBorderOpacity.Value;
			mUserbar.ShaiyaTextBorder = chkShaiyaFontBorder.Checked;

			mUserbar.ShaiyaName = txtShaiyaName.Text;
			mUserbar.ShaiyaNamePadRight = positionShaiyaName.ValueX;
			mUserbar.ShaiyaNamePadTop = positionShaiyaName.ValueY;

			mUserbar.ShaiyaClass = ImageHelper.Helper.GetShaiyaClass( comboShaiyaClass.SelectedIndex );
			mUserbar.XmlShaiyaClass = comboShaiyaClass.SelectedIndex;
			mUserbar.ShaiyaClassWidth = (int)numShaiyaClassWidth.Value;
			mUserbar.ShaiyaClassHeight = (int)numShaiyaClassHeight.Value;
			mUserbar.ShaiyaClassPadRight = positionShaiyaClass.ValueX;
			mUserbar.ShaiyaClassPadTop = positionShaiyaClass.ValueY;

			mUserbar.ShaiyaLevel = txtShaiyaLevel.Text;
			mUserbar.ShaiyaLevelPadRight = positionShaiyaLevel.ValueX;
			mUserbar.ShaiyaLevelPadTop = positionShaiyaLevel.ValueY;

			mUserbar.BackgroundImage = GetBackgroundImage();
			mUserbar.XmlBackgroundImage = comboBackgroundImage.SelectedIndex;
			mUserbar.BackgroundImageSrcX = (int)numBackgroundImageSrcX.Value;
			mUserbar.BackgroundImageSrcY = (int)numBackgroundImageSrcY.Value;
			mUserbar.BackgroundImageDstX = (int)numBackgroundImageDstX.Value;
			mUserbar.BackgroundImageDstY = (int)numBackgroundImageDstY.Value;
			mUserbar.BackgroundImageMode = comboBackgroundImageMode.SelectedIndex;

			mUserbar.Initialized = true;
		}
		private void InitializeForm() {
			numWidth.Value = mUserbar.Width;
			numHeight.Value = mUserbar.Height;

			try {
				comboCustomFont.SelectedIndex = mUserbar.XmlCustomFont;
				//comboCustomFont_SelectedIndexChanged( null, null );
			} catch {
				comboCustomFont.SelectedIndex = 0;
			}
			numCustomFontsize.Value = (int)mUserbar.CustomFont.Size;
			txtCustomText.Text = mUserbar.CustomText;
			colorCustomText.SelectedColor = mUserbar.CustomTextColor;
			chkCustomTextBorder.Checked = mUserbar.CustomTextBorder;
			colorCustomTextBorder.SelectedColor = mUserbar.CustomTextBorderColor;
			sliderCustomTextBorderOpacity.Value = mUserbar.CustomTextBorderAlpha;
			positionCustomText.ValueX = mUserbar.CustomPadRight;
			positionCustomText.ValueY = mUserbar.CustomPadTop;

			colorGradient1.SelectedColor = mUserbar.BackgroundGradient1;
			colorGradient2.SelectedColor = mUserbar.BackgroundGradient2;
			colorBorder.SelectedColor = mUserbar.BackgroundBorderColor;
			chkBorder.Checked = mUserbar.BackgroundBorder;
			colorBackgroundOverlay.SelectedColor = mUserbar.BackgroundOverlayColor;
			sliderBackgroundOverlayOpacity.Value = mUserbar.BackgroundOverlayOpacity;
			sliderBackgroundOpacity.Value = mUserbar.BackgroundOpacity;

			colorWorkflow.SelectedColor = mUserbar.BackgroundFixxColor;


			try {
				comboShaiyaFont.SelectedIndex = mUserbar.XmlShaiyaFont;
				//comboShaiyaFont_SelectedIndexChanged( null, null );
			} catch {
				comboShaiyaFont.SelectedIndex = 0;
			}
			numShaiyaFontsize.Value = (int)mUserbar.ShaiyaFont.Size;
			colorShaiyaFontcolor.SelectedColor = mUserbar.ShaiyaTextColor;
			colorShaiyaFontBorder.SelectedColor = mUserbar.ShaiyaTextBorderColor;
			sliderShaiyaFontBorderOpacity.Value = mUserbar.ShaiyaTextBorderAlpha;
			chkShaiyaFontBorder.Checked = mUserbar.ShaiyaTextBorder;

			txtShaiyaName.Text = mUserbar.ShaiyaName;
			positionShaiyaName.ValueX = mUserbar.ShaiyaNamePadRight;
			positionShaiyaName.ValueY = mUserbar.ShaiyaNamePadTop;

			if( mUserbar.XmlShaiyaClass != -1 ) {
				comboShaiyaClass.SelectedIndex = mUserbar.XmlShaiyaClass;
				comboShaiyaClass_SelectedIndexChanged( null, null );
			}
			numShaiyaClassWidth.Value = mUserbar.ShaiyaClassWidth;
			numShaiyaClassHeight.Value = mUserbar.ShaiyaClassHeight;
			positionShaiyaClass.ValueX = mUserbar.ShaiyaClassPadRight;
			positionShaiyaClass.ValueY = mUserbar.ShaiyaClassPadTop;

			txtShaiyaLevel.Text = mUserbar.ShaiyaLevel;
			positionShaiyaLevel.ValueX = mUserbar.ShaiyaLevelPadRight;
			positionShaiyaLevel.ValueY = mUserbar.ShaiyaLevelPadTop;

			if( mUserbar.XmlBackgroundImage != -1 ) {
				comboBackgroundImage.SelectedIndex = mUserbar.XmlBackgroundImage;
				comboBackgroundImage_SelectedIndexChanged( null, null );
			}
			numBackgroundImageSrcX.Value = mUserbar.BackgroundImageSrcX;
			numBackgroundImageSrcY.Value = mUserbar.BackgroundImageSrcY;
			numBackgroundImageDstX.Value = mUserbar.BackgroundImageDstX;
			numBackgroundImageDstY.Value = mUserbar.BackgroundImageDstY;
			comboBackgroundImageMode.SelectedIndex = mUserbar.BackgroundImageMode;

			mUserbar.Initialized = true;
		}

		private void InitializeCombos( bool Items, bool Index ) {
			if( Items ) {
				object[] items = new object[ comboCustomFont.Items.Count ];
				comboCustomFont.Items.CopyTo( items, 0 );
				comboShaiyaFont.Items.Clear();
				comboShaiyaFont.Items.AddRange( items );
			}

			if( Index ) {
				if( comboCustomFont.SelectedIndex == -1 )
					comboCustomFont.SelectedIndex = 0;
				if( comboShaiyaFont.SelectedIndex == -1 )
					comboShaiyaFont.SelectedIndex = 0;
				if( comboShaiyaClass.SelectedIndex == -1 )
					comboShaiyaClass.SelectedIndex = 0;
				if( comboBackgroundImage.SelectedIndex == -1 )
					comboBackgroundImage.SelectedIndex = 0;
				if( comboBackgroundImageMode.SelectedIndex == -1 )
					comboBackgroundImageMode.SelectedIndex = 0;
			}
		}

		#region Form Events
		private void frmMain_Load( object sender, EventArgs e ) {
			mAssembly = System.Reflection.Assembly.GetExecutingAssembly();

			Text += string.Format( " v{0} - by GodLesZ", mAssembly.ShortVersion() );

			mUserbar = new Userbar( mAssembly, userbarImage, comboCustomFont );
			mInputTimer = new Timer();
			mInputTimer.Interval = 350;
			mInputTimer.Tick += new EventHandler( mInputTimer_Tick );
			mInputTimer.Enabled = true;
			mInputTimer.Stop();

			InitializeCombos( true, true );

			InitializeUserbar();
			mUserbar.Update();
		}
		#endregion

		#region Menu Events
		private void MenuProgramClose_Click( object sender, EventArgs e ) {
			this.Close();
		}

		private void MenuUserbarSave_Click( object sender, EventArgs e ) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "PNG Image|*.png";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			if( dlg.FileName.Substring( dlg.FileName.Length - 4, 4 ) != ".png" )
				dlg.FileName += ".png"; // happens on Files like "GodLesZ.v3", ebil dot

			if( MessageBox.Show( "Möchtest du dein Userbar Bild nun speichern?", "Bild speichern?", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes ) {
				mUserbar.Update( new Rectangle( 0, 0, mUserbar.Width, mUserbar.Height ), false );
				using( Stream s = dlg.OpenFile() )
					mUserbar.ImageObj.Save( s, System.Drawing.Imaging.ImageFormat.Png );
			}

			if( MessageBox.Show( "Möchtest du die Xml Datei der Userbar speichern?\nDiese wird benötigt, um die Userbar später zu bearbeiten [Userbar->Laden]", "Xml Datei speichern?", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
				return;

			XmlSerializer xml = new XmlSerializer( typeof( Userbar ) );
			string filename = Path.GetDirectoryName( dlg.FileName ) + @"\" + Path.GetFileNameWithoutExtension( dlg.FileName ) + ".xml";
			using( Stream s = File.OpenWrite( filename ) )
				try {
					xml.Serialize( s, mUserbar );
				} catch( Exception ex ) {
					System.Diagnostics.Debug.WriteLine( ex );
				}

		}

		private void MenuUserbarLoad_Click( object sender, EventArgs e ) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Userbar Struktur (*.xml)|*.xml";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			XmlSerializer xml = new XmlSerializer( typeof( Userbar ) );
			Userbar tempBar = null;
			using( Stream s = File.OpenRead( dlg.FileName ) )
				try {
					tempBar = xml.Deserialize( s ) as Userbar;
				} catch( Exception ex ) {
					System.Diagnostics.Debug.WriteLine( ex );
				}

			if( tempBar == null ) {
				MessageBox.Show( "Fehler beim öffnen der Datei!\nFalls dies öfter passiert, wende dich bitte an GodLesZ.", "Fehler beim laden", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return;
			}

			mUserbar = tempBar;
			mUserbar.ReInitialize( mAssembly, userbarImage, comboCustomFont );
			InitializeCombos( true, false );
			InitializeForm();
			InitializeCombos( false, true );
			mUserbar.Initialized = true;
			mUserbar.Update();
		}
		#endregion

		#region OnChanged Events
		private void chkWorkflowColor_CheckedChanged( object sender, EventArgs e ) {
			if( chkWorkflowColor.Checked == false ) {
				userbarImage.BackColor = mUserbar.BackgroundFixxColor = Color.Transparent;
				userbarImage.BackgroundImage = Properties.Resources.background;
				mUserbar.Update();
				return;
			}

			userbarImage.BackgroundImage = null;
			userbarImage.BackColor = mUserbar.BackgroundFixxColor = colorWorkflow.SelectedColor = Color.Gray;
			mUserbar.Update();
		}

		private void colorWorkflow_ColorChanged( object sender, EventArgs e ) {
			chkWorkflowColor.Checked = true;
			userbarImage.BackgroundImage = null;
			userbarImage.BackColor = mUserbar.BackgroundFixxColor = colorWorkflow.SelectedColor;
			mUserbar.Update();
		}

		private void numWidth_ValueChanged( object sender, EventArgs e ) {
			mUserbar.Width = (int)numWidth.Value;
			mUserbar.Update();
		}

		private void numHeight_ValueChanged( object sender, EventArgs e ) {
			mUserbar.Height = (int)numHeight.Value;
			mUserbar.Update();
		}

		private void numFontsize_ValueChanged( object sender, EventArgs e ) {
			mUserbar.SetCustomFont( comboCustomFont.SelectedItem.ToString(), (float)numCustomFontsize.Value, true, comboCustomFont.SelectedIndex );
		}

		private void comboCustomFont_SelectedIndexChanged( object sender, EventArgs e ) {
			mUserbar.SetCustomFont( comboCustomFont.SelectedItem.ToString(), (float)numCustomFontsize.Value, true, comboCustomFont.SelectedIndex );
		}

		private void txtCustomText_TextChanged( object sender, EventArgs e ) {
			mUserbar.CustomText = txtCustomText.Text;
			mInputTimer.Stop();
			mInputTimer.Start();
		}

		private void chkCustomTextBorder_CheckedChanged( object sender, EventArgs e ) {
			mUserbar.CustomTextBorder = chkCustomTextBorder.Checked;
			mUserbar.Update();
		}

		private void colorGradian1_ColorChanged( object sender, EventArgs e ) {
			mUserbar.BackgroundGradient1 = colorGradient1.SelectedColor;
			mUserbar.Update();
		}

		private void colorGradian2_ColorChanged( object sender, EventArgs e ) {
			mUserbar.BackgroundGradient2 = colorGradient2.SelectedColor;
			mUserbar.Update();
		}

		private void colorBorder_ColorChanged( object sender, EventArgs e ) {
			mUserbar.BackgroundBorderColor = colorBorder.SelectedColor;
			mUserbar.Update();
		}

		private void chkBorder_CheckedChanged( object sender, EventArgs e ) {
			mUserbar.BackgroundBorder = chkBorder.Checked;
			mUserbar.Update();
		}

		private void chkBackgroundVertical_CheckedChanged( object sender, EventArgs e ) {
			if( chkBackgroundVertical.Checked == true )
				mUserbar.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			else
				mUserbar.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
			mUserbar.Update();
		}

		private void colorText_ValueChanged( object sender, EventArgs e ) {
			mUserbar.CustomTextColor = colorCustomText.SelectedColor;
			mUserbar.Update();
		}

		private void colorTextBorder_ValueChanged( object sender, EventArgs e ) {
			mUserbar.CustomTextBorderColor = colorCustomTextBorder.SelectedColor;
			mUserbar.Update();
		}

		private void sliderTextBorderOpacity_ValueChanged( object sender, EventArgs e ) {
			mUserbar.CustomTextBorderAlpha = sliderCustomTextBorderOpacity.Value;
			mUserbar.Update();
		}

		private void positionText_ValueChangedX( object sender, EventArgs e ) {
			mUserbar.CustomPadRight = positionCustomText.ValueX;
			mUserbar.Update();
		}

		private void positionText_ValueChangedY( object sender, EventArgs e ) {
			mUserbar.CustomPadTop = positionCustomText.ValueY;
			mUserbar.Update();
		}

		private void colorBackgroundOverlay_ColorChanged( object sender, EventArgs e ) {
			mUserbar.BackgroundOverlayColor = colorBackgroundOverlay.SelectedColor;
			mUserbar.Update();
		}

		private void sliderBackgroundOverlayOpacity_ValueChanged( object sender, EventArgs e ) {
			mUserbar.BackgroundOverlayOpacity = sliderBackgroundOverlayOpacity.Value;
			mUserbar.Update();
		}






		private void txtShaiyaName_TextChanged( object sender, EventArgs e ) {
			mUserbar.ShaiyaName = txtShaiyaName.Text;
			mUserbar.Update();
		}

		private void comboShaiyaClass_SelectedIndexChanged( object sender, EventArgs e ) {
			mUserbar.ShaiyaClass = imageShaiyaClass.Image = ImageHelper.Helper.GetShaiyaClass( comboShaiyaClass.SelectedIndex );
			mUserbar.XmlShaiyaClass = comboShaiyaClass.SelectedIndex;
			mUserbar.Update();
		}

		private void numShaiyaClassWidth_ValueChanged( object sender, EventArgs e ) {
			mUserbar.ShaiyaClassWidth = (int)numShaiyaClassWidth.Value;
			mUserbar.Update();
		}

		private void numShaiyaClassHeight_ValueChanged( object sender, EventArgs e ) {
			mUserbar.ShaiyaClassHeight = (int)numShaiyaClassHeight.Value;
			mUserbar.Update();
		}

		private void txtShaiyaLevel_TextChanged( object sender, EventArgs e ) {
			mUserbar.ShaiyaLevel = txtShaiyaLevel.Text;
			mUserbar.Update();
		}

		private void comboShaiyaFont_SelectedIndexChanged( object sender, EventArgs e ) {
			mUserbar.SetShaiyaFont( comboShaiyaFont.SelectedItem.ToString(), (float)numShaiyaFontsize.Value, true, comboShaiyaFont.SelectedIndex );
		}

		private void numShaiyaFontsize_ValueChanged( object sender, EventArgs e ) {
			mUserbar.SetShaiyaFont( comboShaiyaFont.SelectedItem.ToString(), (float)numShaiyaFontsize.Value, true, comboShaiyaFont.SelectedIndex );
		}

		private void colorShaiyaFontcolor_ColorChanged( object sender, EventArgs e ) {
			mUserbar.ShaiyaTextColor = colorShaiyaFontcolor.SelectedColor;
			mUserbar.Update();
		}

		private void chkShaiyaFontBorder_CheckedChanged( object sender, EventArgs e ) {
			mUserbar.ShaiyaTextBorder = chkShaiyaFontBorder.Checked;
			mUserbar.Update();
		}

		private void colorShaiyaFontBorder_ColorChanged( object sender, EventArgs e ) {
			mUserbar.ShaiyaTextBorderColor = colorShaiyaFontBorder.SelectedColor;
			mUserbar.Update();
		}

		private void sliderShaiyaFontBorderOpacity_ValueChanged( object sender, EventArgs e ) {
			mUserbar.ShaiyaTextBorderAlpha = sliderShaiyaFontBorderOpacity.Value;
			mUserbar.Update();
		}

		private void positionShaiyaName_ValueChangedX( object sender, EventArgs e ) {
			mUserbar.ShaiyaNamePadRight = positionShaiyaName.ValueX;
			mUserbar.Update();
		}

		private void positionShaiyaName_ValueChangedY( object sender, EventArgs e ) {
			mUserbar.ShaiyaNamePadTop = positionShaiyaName.ValueY;
			mUserbar.Update();
		}

		private void positionShaiyaClass_ValueChangedX( object sender, EventArgs e ) {
			mUserbar.ShaiyaClassPadRight = positionShaiyaClass.ValueX;
			mUserbar.Update();
		}

		private void positionShaiyaClass_ValueChangedY( object sender, EventArgs e ) {
			mUserbar.ShaiyaClassPadTop = positionShaiyaClass.ValueY;
			mUserbar.Update();
		}

		private void positionShaiyaLevel_ValueChangedX( object sender, EventArgs e ) {
			mUserbar.ShaiyaLevelPadRight = positionShaiyaLevel.ValueX;
			mUserbar.Update();
		}

		private void positionShaiyaLevel_ValueChangedY( object sender, EventArgs e ) {
			mUserbar.ShaiyaLevelPadTop = positionShaiyaLevel.ValueY;
			mUserbar.Update();
		}

		private void sliderBackgroundOpacity_ValueChanged( object sender, EventArgs e ) {
			mUserbar.BackgroundOpacity = sliderBackgroundOpacity.Value;
			mUserbar.Update();
		}



		private void comboBackgroundImage_SelectedIndexChanged( object sender, EventArgs e ) {
			if( comboBackgroundImage.SelectedIndex <= 0 ) {
				mUserbar.BackgroundImage = null;
				mUserbar.XmlBackgroundImage = -1;
				mUserbar.Update();
				return;
			}

			mUserbar.BackgroundImage = GetBackgroundImage();
			mUserbar.XmlBackgroundImage = comboBackgroundImage.SelectedIndex;
			mUserbar.Update();
		}

		private void numBackgroundImageSrcX_ValueChanged( object sender, EventArgs e ) {
			mUserbar.BackgroundImageSrcX = (int)numBackgroundImageSrcX.Value;
			mUserbar.Update();
		}

		private void numBackgroundImageSrcY_ValueChanged( object sender, EventArgs e ) {
			mUserbar.BackgroundImageSrcY = (int)numBackgroundImageSrcY.Value;
			mUserbar.Update();
		}

		private void numBackgroundImageDstX_ValueChanged( object sender, EventArgs e ) {
			mUserbar.BackgroundImageDstX = (int)numBackgroundImageDstX.Value;
			mUserbar.Update();
		}

		private void numBackgroundImageDstY_ValueChanged( object sender, EventArgs e ) {
			mUserbar.BackgroundImageDstY = (int)numBackgroundImageDstY.Value;
			mUserbar.Update();
		}

		private void comboBackgroundImageMode_SelectedIndexChanged( object sender, EventArgs e ) {
			mUserbar.BackgroundImageMode = comboBackgroundImageMode.SelectedIndex;
			if( mUserbar.BackgroundImageMode == 1 ) {
				lblBackgroundImageDst.Text = "Finale Größe";
				lblBackgroundImageDstP1.Text = "%";
				lblBackgroundImageDstP2.Text = "%";
				numBackgroundImageDstX.Minimum = 1;
				numBackgroundImageDstY.Minimum = 1;
			} else {
				lblBackgroundImageDst.Text = "Finale Position";
				lblBackgroundImageDstP1.Text = "";
				lblBackgroundImageDstP2.Text = "";
				numBackgroundImageDstX.Minimum = -1000;
				numBackgroundImageDstY.Minimum = -1000;
			}
			mUserbar.Update();
		}
		#endregion



		private void mInputTimer_Tick( object sender, EventArgs e ) {
			mInputTimer.Stop();
			mUserbar.Update();
		}

		private Image GetBackgroundImage() {
			if( comboBackgroundImage.SelectedIndex <= 0 )
				return null;

			string resName = mAssembly.GetName().Name.Replace( " ", "_" ) + ".Resources.BG_" + comboBackgroundImage.SelectedIndex + ".png";
			return Bitmap.FromStream( mAssembly.GetManifestResourceStream( resName ) );
		}

	}

}
