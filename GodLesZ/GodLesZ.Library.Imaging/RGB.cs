namespace GodLesZ.Library.Imaging {

	public class RGB {
		public const short B = 0;
		public const short G = 1;
		public const short R = 2;

		public byte Blue;
		public byte Green;
		public byte Red;

		public System.Drawing.Color Color {
			get { return System.Drawing.Color.FromArgb(this.Red, this.Green, this.Blue); }
			set {
				this.Red = value.R;
				this.Green = value.G;
				this.Blue = value.B;
			}
		}


		public RGB() {
		}

		public RGB(byte red, byte green, byte blue) {
			this.Red = red;
			this.Green = green;
			this.Blue = blue;
		}
	}
}

