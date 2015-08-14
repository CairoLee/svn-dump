namespace GodLesZ.Library.Imaging.Filters
{
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging;

    public class Shrink : IFilter
    {
        private Color colorToRemove;

        public Shrink()
        {
            this.colorToRemove = Color.FromArgb(0, 0, 0);
        }

        public Shrink(Color colorToRemove)
        {
            this.colorToRemove = Color.FromArgb(0, 0, 0);
            this.colorToRemove = colorToRemove;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int width = srcImg.Width;
            int height = srcImg.Height;
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            int num3 = bitmapdata.Stride - ((format == PixelFormat.Format8bppIndexed) ? width : (width * 3));
            byte r = this.colorToRemove.R;
            byte g = this.colorToRemove.G;
            byte b = this.colorToRemove.B;
            int num7 = width;
            int num8 = height;
            int num9 = 0;
            int num10 = 0;
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            if (format == PixelFormat.Format8bppIndexed)
            {
                for (int j = 0; j < height; j++)
                {
                    int num12 = 0;
                    while (num12 < width)
                    {
                        if (numPtr[0] != g)
                        {
                            if (num12 < num7)
                            {
                                num7 = num12;
                            }
                            if (num12 > num9)
                            {
                                num9 = num12;
                            }
                            if (j < num8)
                            {
                                num8 = j;
                            }
                            if (j > num10)
                            {
                                num10 = j;
                            }
                        }
                        num12++;
                        numPtr++;
                    }
                    numPtr += num3;
                }
            }
            else
            {
                for (int k = 0; k < height; k++)
                {
                    int num14 = 0;
                    while (num14 < width)
                    {
                        if (((numPtr[2] != r) || (numPtr[1] != g)) || (numPtr[0] != b))
                        {
                            if (num14 < num7)
                            {
                                num7 = num14;
                            }
                            if (num14 > num9)
                            {
                                num9 = num14;
                            }
                            if (k < num8)
                            {
                                num8 = k;
                            }
                            if (k > num10)
                            {
                                num10 = k;
                            }
                        }
                        num14++;
                        numPtr += 3;
                    }
                    numPtr += num3;
                }
            }
            if (((num7 == width) && (num8 == height)) && ((num9 == 0) && (num10 == 0)))
            {
                num7 = num8 = 0;
            }
            int num15 = (num9 - num7) + 1;
            int num16 = (num10 - num8) + 1;
            Bitmap bitmap = (format == PixelFormat.Format8bppIndexed) ? GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(num15, num16) : new Bitmap(num15, num16, format);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, num15, num16), ImageLockMode.ReadWrite, format);
            int stride = data2.Stride;
            int num18 = bitmapdata.Stride;
            int count = num15;
            byte* src = (byte*) bitmapdata.Scan0.ToPointer();
            byte* dst = (byte*) data2.Scan0.ToPointer();
            src += num8 * bitmapdata.Stride;
            if (format == PixelFormat.Format8bppIndexed)
            {
                src += num7;
            }
            else
            {
                src += num7 * 3;
                count *= 3;
            }
            for (int i = 0; i < num16; i++)
            {
                Win32.memcpy(dst, src, count);
                dst += stride;
                src += num18;
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }

        public Color ColorToRemove
        {
            get
            {
                return this.colorToRemove;
            }
            set
            {
                this.colorToRemove = value;
            }
        }
    }
}

