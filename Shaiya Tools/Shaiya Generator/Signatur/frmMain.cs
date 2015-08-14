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
using System.Drawing.Drawing2D;
using ImageHelper;

namespace Shaiya_Signatur_Generator {

	public partial class frmMain : Form {
		private Signatur mSignatur;
		private Timer mInputTimer;
		private System.Reflection.Assembly mAssembly;

		public frmMain() {
			InitializeComponent();
		}

		private void InitializeSignatur() {
			mSignatur.Width = (int)numWidth.Value;
			mSignatur.Height = (int)numHeight.Value;

			mSignatur.SetCustomFont( comboCustomFont.SelectedItem.ToString(), (float)numCustomFontsize.Value, false, comboCustomFont.SelectedIndex );
			mSignatur.CustomText = txtCustomText.Text;
			mSignatur.CustomTextColor = colorCustomText.SelectedColor;
			mSignatur.CustomTextBorder = chkCustomTextBorder.Checked;
			mSignatur.CustomTextBorderColor = colorCustomTextBorder.SelectedColor;
			mSignatur.CustomTextBorderAlpha = sliderCustomTextBorderOpacity.Value;
			mSignatur.CustomPadRight = positionCustomText.ValueX;
			mSignatur.CustomPadTop = positionCustomText.ValueY;

			mSignatur.BackgroundGradient1 = colorGradient1.SelectedColor;
			mSignatur.BackgroundGradient2 = colorGradient2.SelectedColor;
			mSignatur.BackgroundBorderColor = colorBorder.SelectedColor;
			mSignatur.BackgroundBorder = chkBorder.Checked;
			mSignatur.BackgroundOverlayColor = colorBackgroundOverlay.SelectedColor;
			mSignatur.BackgroundOverlayOpacity = sliderBackgroundOverlayOpacity.Value;
			mSignatur.BackgroundOpacity = sliderBackgroundOpacity.Value;
			mSignatur.BackgroundOverlayHeight = (int)numBackgroundOverlayHeight.Value;

			mSignatur.BackgroundFixxColor = colorWorkflow.SelectedColor;


			mSignatur.SetShaiyaFont( comboShaiyaFont.SelectedItem.ToString(), (float)numShaiyaFontsize.Value, false, comboShaiyaFont.SelectedIndex );
			mSignatur.ShaiyaTextColor = colorShaiyaFontcolor.SelectedColor;
			mSignatur.ShaiyaTextBorderColor = colorShaiyaFontBorder.SelectedColor;
			mSignatur.ShaiyaTextBorderAlpha = sliderShaiyaFontBorderOpacity.Value;
			mSignatur.ShaiyaTextBorder = chkShaiyaFontBorder.Checked;

			mSignatur.ShaiyaName = txtShaiyaName.Text;
			mSignatur.ShaiyaNamePadRight = positionShaiyaName.ValueX;
			mSignatur.ShaiyaNamePadTop = positionShaiyaName.ValueY;

			mSignatur.ShaiyaClass = ImageHelper.Helper.GetShaiyaClass( comboShaiyaClass.SelectedIndex );
			mSignatur.XmlShaiyaClass = comboShaiyaClass.SelectedIndex;
			mSignatur.ShaiyaClassWidth = (int)numShaiyaClassWidth.Value;
			mSignatur.ShaiyaClassHeight = (int)numShaiyaClassHeight.Value;
			mSignatur.ShaiyaClassPadRight = positionShaiyaClass.ValueX;
			mSignatur.ShaiyaClassPadTop = positionShaiyaClass.ValueY;

			mSignatur.ShaiyaLevel = txtShaiyaLevel.Text;
			mSignatur.ShaiyaLevelPadRight = positionShaiyaLevel.ValueX;
			mSignatur.ShaiyaLevelPadTop = positionShaiyaLevel.ValueY;

			mSignatur.BackgroundImage = GetBackgroundImage();
			mSignatur.XmlBackgroundImage = comboBackgroundImage.SelectedIndex;
			mSignatur.BackgroundImageSrcX = (int)numBackgroundImageSrcX.Value;
			mSignatur.BackgroundImageSrcY = (int)numBackgroundImageSrcY.Value;
			mSignatur.BackgroundImageDstX = (int)numBackgroundImageDstX.Value;
			mSignatur.BackgroundImageDstY = (int)numBackgroundImageDstY.Value;
			mSignatur.BackgroundImageMode = comboBackgroundImageMode.SelectedIndex;
			mSignatur.BackgroundCorner = (int)numBackgroundCorner.Value;

			mSignatur.Initialized = true;
		}
		private void InitializeForm() {
			numWidth.Value = mSignatur.Width;
			numHeight.Value = mSignatur.Height;

			numCustomFontsize.Value = (int)mSignatur.CustomFontsize;
			try {
				comboCustomFont.SelectedIndex = mSignatur.XmlCustomFont;
				//comboCustomFont_SelectedIndexChanged( null, null );
			} catch {
				comboCustomFont.SelectedIndex = 0;
			}
			txtCustomText.Text = mSignatur.CustomText;
			colorCustomText.SelectedColor = mSignatur.CustomTextColor;
			chkCustomTextBorder.Checked = mSignatur.CustomTextBorder;
			colorCustomTextBorder.SelectedColor = mSignatur.CustomTextBorderColor;
			sliderCustomTextBorderOpacity.Value = mSignatur.CustomTextBorderAlpha;
			positionCustomText.ValueX = mSignatur.CustomPadRight;
			positionCustomText.ValueY = mSignatur.CustomPadTop;

			colorGradient1.SelectedColor = mSignatur.BackgroundGradient1;
			colorGradient2.SelectedColor = mSignatur.BackgroundGradient2;
			colorBorder.SelectedColor = mSignatur.BackgroundBorderColor;
			chkBorder.Checked = mSignatur.BackgroundBorder;
			colorBackgroundOverlay.SelectedColor = mSignatur.BackgroundOverlayColor;
			sliderBackgroundOverlayOpacity.Value = mSignatur.BackgroundOverlayOpacity;
			sliderBackgroundOpacity.Value = mSignatur.BackgroundOpacity;
			numBackgroundOverlayHeight.Value = mSignatur.BackgroundOverlayHeight;

			colorWorkflow.SelectedColor = mSignatur.BackgroundFixxColor;


			numShaiyaFontsize.Value = (int)mSignatur.ShaiyaFontsize;
			try {
				comboShaiyaFont.SelectedIndex = mSignatur.XmlShaiyaFont;
				//comboShaiyaFont_SelectedIndexChanged( null, null );
			} catch {
				comboShaiyaFont.SelectedIndex = 0;
			}
			colorShaiyaFontcolor.SelectedColor = mSignatur.ShaiyaTextColor;
			colorShaiyaFontBorder.SelectedColor = mSignatur.ShaiyaTextBorderColor;
			sliderShaiyaFontBorderOpacity.Value = mSignatur.ShaiyaTextBorderAlpha;
			chkShaiyaFontBorder.Checked = mSignatur.ShaiyaTextBorder;

			txtShaiyaName.Text = mSignatur.ShaiyaName;
			positionShaiyaName.ValueX = mSignatur.ShaiyaNamePadRight;
			positionShaiyaName.ValueY = mSignatur.ShaiyaNamePadTop;

			if( mSignatur.XmlShaiyaClass != -1 ) {
				comboShaiyaClass.SelectedIndex = mSignatur.XmlShaiyaClass;
				comboShaiyaClass_SelectedIndexChanged( null, null );
			}
			numShaiyaClassWidth.Value = mSignatur.ShaiyaClassWidth;
			numShaiyaClassHeight.Value = mSignatur.ShaiyaClassHeight;
			positionShaiyaClass.ValueX = mSignatur.ShaiyaClassPadRight;
			positionShaiyaClass.ValueY = mSignatur.ShaiyaClassPadTop;

			txtShaiyaLevel.Text = mSignatur.ShaiyaLevel;
			positionShaiyaLevel.ValueX = mSignatur.ShaiyaLevelPadRight;
			positionShaiyaLevel.ValueY = mSignatur.ShaiyaLevelPadTop;

			if( mSignatur.XmlBackgroundImage != -1 ) {
				comboBackgroundImage.SelectedIndex = mSignatur.XmlBackgroundImage;
				comboBackgroundImage_SelectedIndexChanged( null, null );
			}
			numBackgroundImageSrcX.Value = mSignatur.BackgroundImageSrcX;
			numBackgroundImageSrcY.Value = mSignatur.BackgroundImageSrcY;
			numBackgroundImageDstX.Value = mSignatur.BackgroundImageDstX;
			numBackgroundImageDstY.Value = mSignatur.BackgroundImageDstY;
			comboBackgroundImageMode.SelectedIndex = mSignatur.BackgroundImageMode;
			numBackgroundCorner.Value = mSignatur.BackgroundCorner;

			mSignatur.Initialized = true;
		}
		private void InitializeCombos( bool Items, bool Index ) {
			if( Items ) {
				// Fonts
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
		private void InitializeBackgrounds() {
			comboBackgroundImage.Items.Clear();
			comboBackgroundImage.Items.Add( "--kein Image--" );
			string asmName = mAssembly.GetName().Name.Replace( " ", "_" );
			List<string> comboItems = new List<string>();

			foreach( string name in mAssembly.GetManifestResourceNames() ) {
				string[] parts = name.Split( new char[] { '.' } );
				string ext = parts[ parts.Length - 1 ];
				if( ext != "jpg" )
					continue;
				string fName = name.Replace( asmName + ".Resources.", "" ).Replace( "." + ext, "" );
				comboItems.Add( fName );
			}
			comboItems.Sort();
			comboBackgroundImage.Items.AddRange( comboItems.ToArray() );
		}

		#region Form Events
		private void frmMain_Load( object sender, EventArgs e ) {
			mAssembly = System.Reflection.Assembly.GetExecutingAssembly();

			Text += string.Format( " v{0} - by GodLesZ", mAssembly.ShortVersion() );

			mSignatur = new Signatur( mAssembly, signaturImage, comboCustomFont );
			mInputTimer = new Timer();
			mInputTimer.Interval = 350;
			mInputTimer.Tick += new EventHandler( mInputTimer_Tick );
			mInputTimer.Enabled = true;
			mInputTimer.Stop();

			InitializeBackgrounds();
			InitializeCombos( true, true );

			InitializeSignatur();
			mSignatur.Update();
		}
		#endregion

		#region Menu Events
		private void MenuProgramClose_Click( object sender, EventArgs e ) {
			this.Close();
		}

		private void MenuSignaturSave_Click( object sender, EventArgs e ) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "PNG Image|*.png";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			if( dlg.FileName.Substring( dlg.FileName.Length - 4, 4 ) != ".png" )
				dlg.FileName += ".png"; // happens on Files like "GodLesZ.v3", ebil dot

			if( MessageBox.Show( "Möchtest du dein Signatur Bild nun speichern?", "Bild speichern?", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes ) {
				try { File.Delete( dlg.FileName ); } catch { }
				mSignatur.Update( new Rectangle( 0, 0, mSignatur.Width, mSignatur.Height ), false );
				using( Stream s = dlg.OpenFile() )
					mSignatur.ImageObj.Save( s, System.Drawing.Imaging.ImageFormat.Png );
			}

			if( MessageBox.Show( "Möchtest du die Xml Datei der Signatur speichern?\nDiese wird benötigt, um die Signatur später zu bearbeiten [Signatur->Laden]", "Xml Datei speichern?", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
				return;

			XmlSerializer xml = new XmlSerializer( typeof( Signatur ) );
			string filename = Path.GetDirectoryName( dlg.FileName ) + @"\" + Path.GetFileNameWithoutExtension( dlg.FileName ) + ".xml";
			try { File.Delete( filename ); } catch { }
			using( Stream s = File.OpenWrite( filename ) )
				try {
					xml.Serialize( s, mSignatur );
				} catch( Exception ex ) {
					System.Diagnostics.Debug.WriteLine( ex );
				}

		}

		private void MenuSignaturLoad_Click( object sender, EventArgs e ) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Signatur Struktur (*.xml)|*.xml";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			XmlSerializer xml = new XmlSerializer( typeof( Signatur ) );
			Signatur tempBar = null;
			using( Stream s = File.OpenRead( dlg.FileName ) )
				try {
					tempBar = xml.Deserialize( s ) as Signatur;
				} catch( Exception ex ) {
					System.Diagnostics.Debug.WriteLine( ex );
				}

			if( tempBar == null ) {
				MessageBox.Show( "Fehler beim öffnen der Datei!\nFalls dies öfter passiert, wende dich bitte an GodLesZ.", "Fehler beim laden", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return;
			}

			mSignatur = tempBar;
			mSignatur.ReInitialize( mAssembly, signaturImage, comboCustomFont );
			InitializeCombos( true, false );
			InitializeForm();
			InitializeCombos( false, true );
			mSignatur.Initialized = true;
			mSignatur.Update();
		}
		#endregion

		#region OnChanged Events
		private void chkWorkflowColor_CheckedChanged( object sender, EventArgs e ) {
			if( chkWorkflowColor.Checked == false ) {
				signaturImage.BackColor = mSignatur.BackgroundFixxColor = Color.Transparent;
				signaturImage.BackgroundImage = Properties.Resources.background;
				mSignatur.Update();
				return;
			}

			signaturImage.BackgroundImage = null;
			signaturImage.BackColor = mSignatur.BackgroundFixxColor = colorWorkflow.SelectedColor = Color.Gray;
			mSignatur.Update();
		}

		private void colorWorkflow_ColorChanged( object sender, EventArgs e ) {
			chkWorkflowColor.Checked = true;
			signaturImage.BackgroundImage = null;
			signaturImage.BackColor = mSignatur.BackgroundFixxColor = colorWorkflow.SelectedColor;
			mSignatur.Update();
		}

		private void numWidth_ValueChanged( object sender, EventArgs e ) {
			mSignatur.Width = (int)numWidth.Value;
			mSignatur.Update();
		}

		private void numHeight_ValueChanged( object sender, EventArgs e ) {
			mSignatur.Height = (int)numHeight.Value;
			mSignatur.Update();
		}

		private void numFontsize_ValueChanged( object sender, EventArgs e ) {
			if( comboCustomFont.SelectedIndex == -1 )
				return;
			mSignatur.SetCustomFont( comboCustomFont.SelectedItem.ToString(), (float)numCustomFontsize.Value, true, comboCustomFont.SelectedIndex );
		}

		private void comboCustomFont_SelectedIndexChanged( object sender, EventArgs e ) {
			if( comboCustomFont.SelectedIndex == -1 )
				return;
			mSignatur.SetCustomFont( comboCustomFont.SelectedItem.ToString(), (float)numCustomFontsize.Value, true, comboCustomFont.SelectedIndex );
		}

		private void txtCustomText_TextChanged( object sender, EventArgs e ) {
			mSignatur.CustomText = txtCustomText.Text;
			mInputTimer.Stop();
			mInputTimer.Start();
		}

		private void chkCustomTextBorder_CheckedChanged( object sender, EventArgs e ) {
			mSignatur.CustomTextBorder = chkCustomTextBorder.Checked;
			mSignatur.Update();
		}

		private void colorGradian1_ColorChanged( object sender, EventArgs e ) {
			mSignatur.BackgroundGradient1 = colorGradient1.SelectedColor;
			mSignatur.Update();
		}

		private void colorGradian2_ColorChanged( object sender, EventArgs e ) {
			mSignatur.BackgroundGradient2 = colorGradient2.SelectedColor;
			mSignatur.Update();
		}

		private void colorBorder_ColorChanged( object sender, EventArgs e ) {
			mSignatur.BackgroundBorderColor = colorBorder.SelectedColor;
			mSignatur.Update();
		}

		private void chkBorder_CheckedChanged( object sender, EventArgs e ) {
			mSignatur.BackgroundBorder = chkBorder.Checked;
			mSignatur.Update();
		}

		private void chkBackgroundVertical_CheckedChanged( object sender, EventArgs e ) {
			if( chkBackgroundVertical.Checked == true )
				mSignatur.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			else
				mSignatur.BackgroundGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
			mSignatur.Update();
		}

		private void colorText_ValueChanged( object sender, EventArgs e ) {
			mSignatur.CustomTextColor = colorCustomText.SelectedColor;
			mSignatur.Update();
		}

		private void colorTextBorder_ValueChanged( object sender, EventArgs e ) {
			mSignatur.CustomTextBorderColor = colorCustomTextBorder.SelectedColor;
			mSignatur.Update();
		}

		private void sliderTextBorderOpacity_ValueChanged( object sender, EventArgs e ) {
			mSignatur.CustomTextBorderAlpha = sliderCustomTextBorderOpacity.Value;
			mSignatur.Update();
		}

		private void positionText_ValueChangedX( object sender, EventArgs e ) {
			mSignatur.CustomPadRight = positionCustomText.ValueX;
			mSignatur.Update();
		}

		private void positionText_ValueChangedY( object sender, EventArgs e ) {
			mSignatur.CustomPadTop = positionCustomText.ValueY;
			mSignatur.Update();
		}

		private void colorBackgroundOverlay_ColorChanged( object sender, EventArgs e ) {
			mSignatur.BackgroundOverlayColor = colorBackgroundOverlay.SelectedColor;
			mSignatur.Update();
		}

		private void sliderBackgroundOverlayOpacity_ValueChanged( object sender, EventArgs e ) {
			mSignatur.BackgroundOverlayOpacity = sliderBackgroundOverlayOpacity.Value;
			mSignatur.Update();
		}






		private void txtShaiyaName_TextChanged( object sender, EventArgs e ) {
			mSignatur.ShaiyaName = txtShaiyaName.Text;
			mSignatur.Update();
		}

		private void comboShaiyaClass_SelectedIndexChanged( object sender, EventArgs e ) {
			mSignatur.ShaiyaClass = imageShaiyaClass.Image = ImageHelper.Helper.GetShaiyaClass( comboShaiyaClass.SelectedIndex );
			mSignatur.XmlShaiyaClass = comboShaiyaClass.SelectedIndex;
			mSignatur.Update();
		}

		private void numShaiyaClassWidth_ValueChanged( object sender, EventArgs e ) {
			mSignatur.ShaiyaClassWidth = (int)numShaiyaClassWidth.Value;
			mSignatur.Update();
		}

		private void numShaiyaClassHeight_ValueChanged( object sender, EventArgs e ) {
			mSignatur.ShaiyaClassHeight = (int)numShaiyaClassHeight.Value;
			mSignatur.Update();
		}

		private void txtShaiyaLevel_TextChanged( object sender, EventArgs e ) {
			mSignatur.ShaiyaLevel = txtShaiyaLevel.Text;
			mSignatur.Update();
		}

		private void comboShaiyaFont_SelectedIndexChanged( object sender, EventArgs e ) {
			if( comboShaiyaFont.SelectedIndex == -1 )
				return;
			mSignatur.SetShaiyaFont( comboShaiyaFont.SelectedItem.ToString(), (float)numShaiyaFontsize.Value, true, comboShaiyaFont.SelectedIndex );
		}

		private void numShaiyaFontsize_ValueChanged( object sender, EventArgs e ) {
			if( comboShaiyaFont.SelectedIndex == -1 )
				return;
			mSignatur.SetShaiyaFont( comboShaiyaFont.SelectedItem.ToString(), (float)numShaiyaFontsize.Value, true, comboShaiyaFont.SelectedIndex );
		}

		private void colorShaiyaFontcolor_ColorChanged( object sender, EventArgs e ) {
			mSignatur.ShaiyaTextColor = colorShaiyaFontcolor.SelectedColor;
			mSignatur.Update();
		}

		private void chkShaiyaFontBorder_CheckedChanged( object sender, EventArgs e ) {
			mSignatur.ShaiyaTextBorder = chkShaiyaFontBorder.Checked;
			mSignatur.Update();
		}

		private void colorShaiyaFontBorder_ColorChanged( object sender, EventArgs e ) {
			mSignatur.ShaiyaTextBorderColor = colorShaiyaFontBorder.SelectedColor;
			mSignatur.Update();
		}

		private void sliderShaiyaFontBorderOpacity_ValueChanged( object sender, EventArgs e ) {
			mSignatur.ShaiyaTextBorderAlpha = sliderShaiyaFontBorderOpacity.Value;
			mSignatur.Update();
		}

		private void positionShaiyaName_ValueChangedX( object sender, EventArgs e ) {
			mSignatur.ShaiyaNamePadRight = positionShaiyaName.ValueX;
			mSignatur.Update();
		}

		private void positionShaiyaName_ValueChangedY( object sender, EventArgs e ) {
			mSignatur.ShaiyaNamePadTop = positionShaiyaName.ValueY;
			mSignatur.Update();
		}

		private void positionShaiyaClass_ValueChangedX( object sender, EventArgs e ) {
			mSignatur.ShaiyaClassPadRight = positionShaiyaClass.ValueX;
			mSignatur.Update();
		}

		private void positionShaiyaClass_ValueChangedY( object sender, EventArgs e ) {
			mSignatur.ShaiyaClassPadTop = positionShaiyaClass.ValueY;
			mSignatur.Update();
		}

		private void positionShaiyaLevel_ValueChangedX( object sender, EventArgs e ) {
			mSignatur.ShaiyaLevelPadRight = positionShaiyaLevel.ValueX;
			mSignatur.Update();
		}

		private void positionShaiyaLevel_ValueChangedY( object sender, EventArgs e ) {
			mSignatur.ShaiyaLevelPadTop = positionShaiyaLevel.ValueY;
			mSignatur.Update();
		}

		private void sliderBackgroundOpacity_ValueChanged( object sender, EventArgs e ) {
			mSignatur.BackgroundOpacity = sliderBackgroundOpacity.Value;
			mSignatur.Update();
		}



		private void comboBackgroundImage_SelectedIndexChanged( object sender, EventArgs e ) {
			if( comboBackgroundImage.SelectedIndex <= 0 ) {
				mSignatur.BackgroundImage = imageBackgroundPreview.Image = null;
				mSignatur.XmlBackgroundImage = -1;
				mSignatur.Update();
				return;
			}

			mSignatur.BackgroundImage = imageBackgroundPreview.Image = GetBackgroundImage();
			mSignatur.XmlBackgroundImage = comboBackgroundImage.SelectedIndex;
			mSignatur.Update();
		}

		private void numBackgroundImageSrcX_ValueChanged( object sender, EventArgs e ) {
			mSignatur.BackgroundImageSrcX = (int)numBackgroundImageSrcX.Value;
			mSignatur.Update();
		}

		private void numBackgroundImageSrcY_ValueChanged( object sender, EventArgs e ) {
			mSignatur.BackgroundImageSrcY = (int)numBackgroundImageSrcY.Value;
			mSignatur.Update();
		}

		private void numBackgroundImageDstX_ValueChanged( object sender, EventArgs e ) {
			mSignatur.BackgroundImageDstX = (int)numBackgroundImageDstX.Value;
			mSignatur.Update();
		}

		private void numBackgroundImageDstY_ValueChanged( object sender, EventArgs e ) {
			mSignatur.BackgroundImageDstY = (int)numBackgroundImageDstY.Value;
			mSignatur.Update();
		}

		private void comboBackgroundImageMode_SelectedIndexChanged( object sender, EventArgs e ) {
			mSignatur.BackgroundImageMode = comboBackgroundImageMode.SelectedIndex;
			if( mSignatur.BackgroundImageMode == 1 ) {
				lblBackgroundImageDst.Text = "Finale Größe";
				lblBackgroundImageDstP1.Text = "%";
				lblBackgroundImageDstP2.Text = "%";
				numBackgroundImageDstX.Minimum = 1;
				numBackgroundImageDstY.Minimum = 1;
				numBackgroundImageDstX.Value = 100;
				numBackgroundImageDstY.Value = 100;
			} else {
				lblBackgroundImageDst.Text = "Finale Position";
				lblBackgroundImageDstP1.Text = "";
				lblBackgroundImageDstP2.Text = "";
				numBackgroundImageDstX.Minimum = -1000;
				numBackgroundImageDstY.Minimum = -1000;
				numBackgroundImageDstX.Value = 0;
				numBackgroundImageDstY.Value = 0;
			}
			mSignatur.Update();
		}

		private void numBackgroundCorner_ValueChanged( object sender, EventArgs e ) {
			mSignatur.BackgroundCorner = (int)numBackgroundCorner.Value;
			mSignatur.Update();
		}

		private void numBackgroundOverlayHeight_ValueChanged( object sender, EventArgs e ) {
			mSignatur.BackgroundOverlayHeight = (int)numBackgroundOverlayHeight.Value;
			mSignatur.Update();
		}

		private void sliderBackgroundImageOpacity_ValueChanged( object sender, EventArgs e ) {
			mSignatur.BackgroundImageOpacity = sliderBackgroundImageOpacity.Value;
			mSignatur.Update();
		}
		#endregion

		#region DrawOrder Mod
		private void btnDrawOrderUp_Click( object sender, EventArgs e ) {
			if( listDrawOrder.SelectedIndex < 1 )
				return;

			listDrawOrder.Items.Swap( listDrawOrder.SelectedIndex, -1 );
			mSignatur.DrawOrder.Swap( listDrawOrder.SelectedIndex, -1 );
			listDrawOrder.SelectedIndex--;
			mSignatur.Update();
		}

		private void btnDrawOrderDown_Click( object sender, EventArgs e ) {
			if( listDrawOrder.SelectedIndex == -1 || listDrawOrder.SelectedIndex >= listDrawOrder.Items.Count - 1 )
				return;

			listDrawOrder.Items.Swap( listDrawOrder.SelectedIndex, +1 );
			mSignatur.DrawOrder.Swap( listDrawOrder.SelectedIndex, +1 );
			listDrawOrder.SelectedIndex++;
			mSignatur.Update();
		}

		private void listDrawOrder_SelectedIndexChanged( object sender, EventArgs e ) {
			if( listDrawOrder.SelectedIndex == -1 ) {
				btnDrawOrderUp.Enabled = false;
				btnDrawOrderDown.Enabled = false;
				return;
			}

			btnDrawOrderUp.Enabled = listDrawOrder.SelectedIndex > 0;
			btnDrawOrderDown.Enabled = listDrawOrder.SelectedIndex < listDrawOrder.Items.Count - 1;
		}
		#endregion


		private void mInputTimer_Tick( object sender, EventArgs e ) {
			mInputTimer.Stop();
			mSignatur.Update();
		}

		private Image GetBackgroundImage() {
			if( comboBackgroundImage.SelectedIndex <= 0 )
				return null;

			string resName = mAssembly.GetName().Name.Replace( " ", "_" ) + ".Resources." + comboBackgroundImage.SelectedItem.ToString() + ".jpg";
			return Bitmap.FromStream( mAssembly.GetManifestResourceStream( resName ) );
		}

		private void MenuCustomAdd_Click( object sender, EventArgs e ) {
			/*
			TabPage page = new TabPage( "Custom Text " + ( tabControl1.TabCount - 4 ) ); // 6 base Tabs
			CheckBox chkTextBorder = new CheckBox();
			Label lblPosition = new Label();
			Label lblTransparenz = new Label();
			Label lblText = new Label();
			Label lblSchrift = new Label();
			ComboBox cmbFont = new ComboBox();
			TextBox txtText = new TextBox();
			NumericUpDown numFontsize = new NumericUpDown();
			ArrowControl arrTextPos = new ArrowControl();

			SliderLabel sldBorderOp = new SliderLabel();
			ColorChooser clTextBorder = new ColorChooser();
			ColorChooser clText = new ColorChooser();

			this.pageCustomText.BackColor = System.Drawing.SystemColors.Control;
			this.pageCustomText.Controls.Add( this.btnCustomDelete );
			this.pageCustomText.Controls.Add( this.chkCustomTextBorder );
			this.pageCustomText.Controls.Add( this.label9 );
			this.pageCustomText.Controls.Add( this.label8 );
			this.pageCustomText.Controls.Add( this.label4 );
			this.pageCustomText.Controls.Add( this.comboCustomFont );
			this.pageCustomText.Controls.Add( this.label3 );
			this.pageCustomText.Controls.Add( this.txtCustomText );
			this.pageCustomText.Controls.Add( this.numCustomFontsize );
			this.pageCustomText.Controls.Add( this.positionCustomText );
			this.pageCustomText.Controls.Add( this.sliderCustomTextBorderOpacity );
			this.pageCustomText.Controls.Add( this.colorCustomTextBorder );
			this.pageCustomText.Controls.Add( this.colorCustomText );
			this.pageCustomText.Location = new System.Drawing.Point( 4, 22 );
			this.pageCustomText.Name = "pageCustomText";
			this.pageCustomText.Padding = new System.Windows.Forms.Padding( 3 );
			this.pageCustomText.Size = new System.Drawing.Size( 592, 180 );
			this.pageCustomText.TabIndex = 1;

			this.chkCustomTextBorder.AutoSize = true;
			this.chkCustomTextBorder.Location = new System.Drawing.Point( 10, 79 );
			this.chkCustomTextBorder.Name = "chkCustomTextBorder";
			this.chkCustomTextBorder.Size = new System.Drawing.Size( 52, 17 );
			this.chkCustomTextBorder.TabIndex = 12;
			this.chkCustomTextBorder.Text = "Rand";
			this.chkCustomTextBorder.UseVisualStyleBackColor = true;
			this.chkCustomTextBorder.CheckedChanged += new System.EventHandler( this.chkCustomTextBorder_CheckedChanged );
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point( 414, 23 );
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size( 44, 13 );
			this.label9.TabIndex = 10;
			this.label9.Text = "Position";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point( 103, 80 );
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size( 66, 13 );
			this.label8.TabIndex = 8;
			this.label8.Text = "Transparenz";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 7, 44 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 28, 13 );
			this.label4.TabIndex = 3;
			this.label4.Text = "Text";
			// 
			// comboCustomFont
			// 
			this.comboCustomFont.FormattingEnabled = true;
			this.comboCustomFont.Location = new System.Drawing.Point( 57, 3 );
			this.comboCustomFont.Name = "comboCustomFont";
			this.comboCustomFont.Size = new System.Drawing.Size( 109, 21 );
			this.comboCustomFont.TabIndex = 1;
			this.comboCustomFont.SelectedIndexChanged += new System.EventHandler( this.comboCustomFont_SelectedIndexChanged );
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 7, 7 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 37, 13 );
			this.label3.TabIndex = 0;
			this.label3.Text = "Schrift";
			// 
			// txtCustomText
			// 
			this.txtCustomText.Location = new System.Drawing.Point( 57, 40 );
			this.txtCustomText.Name = "txtCustomText";
			this.txtCustomText.Size = new System.Drawing.Size( 171, 20 );
			this.txtCustomText.TabIndex = 4;
			this.txtCustomText.Text = "Shaiya Signatur Generator";
			this.txtCustomText.TextChanged += new System.EventHandler( this.txtCustomText_TextChanged );
			// 
			// numCustomFontsize
			// 
			this.numCustomFontsize.Location = new System.Drawing.Point( 181, 4 );
			this.numCustomFontsize.Maximum = new decimal( new int[] {
            40,
            0,
            0,
            0} );
			this.numCustomFontsize.Minimum = new decimal( new int[] {
            5,
            0,
            0,
            0} );
			this.numCustomFontsize.Name = "numCustomFontsize";
			this.numCustomFontsize.Size = new System.Drawing.Size( 47, 20 );
			this.numCustomFontsize.TabIndex = 2;
			this.numCustomFontsize.Value = new decimal( new int[] {
            10,
            0,
            0,
            0} );
			this.numCustomFontsize.ValueChanged += new System.EventHandler( this.numFontsize_ValueChanged );
			// 
			// positionCustomText
			// 
			this.positionCustomText.BackColor = System.Drawing.Color.Transparent;
			this.positionCustomText.Location = new System.Drawing.Point( 464, 8 );
			this.positionCustomText.MaximumX = 500;
			this.positionCustomText.MaximumY = 500;
			this.positionCustomText.MinimumX = -500;
			this.positionCustomText.MinimumY = -500;
			this.positionCustomText.Name = "positionCustomText";
			this.positionCustomText.Size = new System.Drawing.Size( 122, 46 );
			this.positionCustomText.TabIndex = 11;
			this.positionCustomText.ValueX = -5;
			this.positionCustomText.ValueY = 0;
			this.positionCustomText.ValueChangedY += new System.EventHandler( this.positionText_ValueChangedY );
			this.positionCustomText.ValueChangedX += new System.EventHandler( this.positionText_ValueChangedX );
			// 
			// sliderCustomTextBorderOpacity
			// 
			this.sliderCustomTextBorderOpacity.BackColor = System.Drawing.SystemColors.Control;
			this.sliderCustomTextBorderOpacity.Location = new System.Drawing.Point( 175, 76 );
			this.sliderCustomTextBorderOpacity.Maximum = 255;
			this.sliderCustomTextBorderOpacity.Minimum = 0;
			this.sliderCustomTextBorderOpacity.Name = "sliderCustomTextBorderOpacity";
			this.sliderCustomTextBorderOpacity.Size = new System.Drawing.Size( 143, 23 );
			this.sliderCustomTextBorderOpacity.TabIndex = 9;
			this.sliderCustomTextBorderOpacity.Value = 0;
			this.sliderCustomTextBorderOpacity.ValueChanged += new System.EventHandler( this.sliderTextBorderOpacity_ValueChanged );
			// 
			// colorCustomTextBorder
			// 
			this.colorCustomTextBorder.Location = new System.Drawing.Point( 68, 77 );
			this.colorCustomTextBorder.Name = "colorCustomTextBorder";
			this.colorCustomTextBorder.SelectedColor = System.Drawing.Color.Black;
			this.colorCustomTextBorder.Size = new System.Drawing.Size( 20, 20 );
			this.colorCustomTextBorder.TabIndex = 7;
			this.colorCustomTextBorder.XmlSelectedColor = "Black";
			this.colorCustomTextBorder.ColorChanged += new System.EventHandler( this.colorTextBorder_ValueChanged );
			// 
			// colorCustomText
			// 
			this.colorCustomText.Location = new System.Drawing.Point( 234, 4 );
			this.colorCustomText.Name = "colorCustomText";
			this.colorCustomText.SelectedColor = System.Drawing.Color.White;
			this.colorCustomText.Size = new System.Drawing.Size( 20, 20 );
			this.colorCustomText.TabIndex = 5;
			this.colorCustomText.XmlSelectedColor = "White";
			this.colorCustomText.ColorChanged += new System.EventHandler( this.colorText_ValueChanged );
			*/

		}

	}




}
