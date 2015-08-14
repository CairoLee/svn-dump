namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging;

    public class HueModifier : IFilter
    {
        private int hue;

        public HueModifier()
        {
        }

        public HueModifier(int hue)
        {
            this.hue = hue;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            if (srcImg.PixelFormat != PixelFormat.Format24bppRgb)
            {
                throw new ArgumentException();
            }
            int width = srcImg.Width;
            int height = srcImg.Height;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            RGB rgb = new RGB();
            HSL hsl = new HSL();
            int num3 = bitmapdata.Stride - (width * 3);
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            for (int i = 0; i < height; i++)
            {
                int num5 = 0;
                while (num5 < width)
                {
                    rgb.Red = numPtr[2];
                    rgb.Green = numPtr[1];
                    rgb.Blue = numPtr[0];
                    GodLesZ.Library.Imaging.ColorConverter.RGB2HSL(rgb, hsl);
                    hsl.Hue = this.hue;
                    GodLesZ.Library.Imaging.ColorConverter.HSL2RGB(hsl, rgb);
                    numPtr2[2] = rgb.Red;
                    numPtr2[1] = rgb.Green;
                    numPtr2[0] = rgb.Blue;
                    num5++;
                    numPtr += 3;
                    numPtr2 += 3;
                }
                numPtr += num3;
                numPtr2 += num3;
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }

        public int Hue
        {
            get
            {
                return this.hue;
            }
            set
            {
                this.hue = Math.Max(0, Math.Min(0x167, value));
            }
        }
    }
}

