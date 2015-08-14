using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Library.Captcha {
	
	/// <summary>
	/// Represents all operations that could be done by the <see cref="CaptchaImageProcessor"/>
	/// </summary>
	public class ImageProcessorSettings {

		/// <summary>
		/// Removes X pixel from every site and smallers the image
		/// </summary>
		public int RemoveBorder {
			get;
			set;
		}

		/// <summary>
		/// Removes noise at a certain level from the image
		/// </summary>
		public int RemovePixelNoise {
			get;
			set;
		}

		/// <summary>
		/// Applys a blur effect on the image
		/// </summary>
		public bool ImageBlur {
			get;
			set;
		}

		/// <summary>
		/// Reduce Brightness by (100 - value)
		/// <para>
		/// In german its like: "Die Sonne scheint dir aus dem Arsch"
		/// </para>
		/// </summary>
		public int BrightnessThreshold {
			get;
			set;
		}

		/// <summary>
		/// Linearize the colors
		/// </summary>
		public bool LinearizeColors {
			get;
			set;
		}

		/// <summary>
		/// Inverts every color pixel on the image
		/// </summary>
		public bool InvertColors {
			get;
			set;
		}


		public ImageProcessorSettings() {
			RemoveBorder = 0;
			RemovePixelNoise = 0;
			ImageBlur = false;
			BrightnessThreshold = 0;
			LinearizeColors = false;
			InvertColors = false;
		}

	}
}
