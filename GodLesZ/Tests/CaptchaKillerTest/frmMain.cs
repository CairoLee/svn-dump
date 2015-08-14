using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GodLesZ.Library.Captcha;

namespace CaptchaKillerTest {

	public partial class frmMain : Form {

		public frmMain() {
			InitializeComponent();
		}


		private void frmMain_Load(object sender, EventArgs e) {

		}

		private void imgBefore_Click(object sender, EventArgs e) {
			using (OpenFileDialog dlg = new OpenFileDialog()) {
				dlg.Filter = "Image|*.png;*.jpg;*.bmp";
				if (dlg.ShowDialog(this) != System.Windows.Forms.DialogResult.OK) {
					return;
				}

				Bitmap bmp = Bitmap.FromFile(dlg.FileName) as Bitmap;
				imgBefore.Image = bmp;
				//ProcessImage(bmp);
			}
		}

		private void btnProcess_Click(object sender, EventArgs e) {
			if (imgBefore.Image == null) {
				return;
			}

			ProcessImage(imgBefore.Image as Bitmap);
		}



		private void ProcessImage(Bitmap image) {
			CaptchaImageProcessor proc = new CaptchaImageProcessor(image);
			ImageProcessorSettings settings = new ImageProcessorSettings() {
				ImageBlur = chkBlur.Checked,
				RemoveBorder = (int)numericRemoveBorder.Value,
				RemovePixelNoise = (int)numericNoiseKill.Value,
				InvertColors = chkInvertColors.Checked,
				LinearizeColors = chkLinarizeColors.Checked,
				BrightnessThreshold = (int)numericBrightness.Value
			};

			Bitmap imageAfter = proc.ProcessImage(settings);
			string result = CaptchaKiller.OCR(imageAfter);
			imgAfter.Image = imageAfter;

			if (result == null) {
				lblResult.BackColor = Color.Maroon;
				lblResult.ForeColor = Color.WhiteSmoke;
				lblResult.Text = "OCR Error";
			} else {
				lblResult.BackColor = Color.DarkGreen;
				lblResult.ForeColor = Color.WhiteSmoke;
				lblResult.Text = result;
			}
		}

	}

}
