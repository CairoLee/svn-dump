namespace GodLesZ.Library.Imaging {

	public class HSL
    {
        public int Hue;
        public double Luminance;
        public double Saturation;

        public HSL()
        {
        }

        public HSL(int hue, double saturation, double luminance)
        {
            this.Hue = hue;
            this.Saturation = saturation;
            this.Luminance = luminance;
        }
    }
}

