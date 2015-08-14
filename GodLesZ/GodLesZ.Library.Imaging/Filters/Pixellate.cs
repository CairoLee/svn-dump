namespace GodLesZ.Library.Imaging.Filters
{
	using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class Pixellate : IFilter
    {
        private int pixelSize;

        public Pixellate()
        {
            this.pixelSize = 8;
        }

        public Pixellate(int pixelSize)
        {
            this.pixelSize = 8;
            this.PixelSize = pixelSize;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int num5;
            int num6;
            int num8;
            int num9;
            int num10;
            int width = srcImg.Width;
            int height = srcImg.Height;
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = (format == PixelFormat.Format8bppIndexed) ? GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height) : new Bitmap(width, height, format);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, format);
            int num4 = bitmapdata.Stride - ((format == PixelFormat.Format8bppIndexed) ? width : (width * 3));
            int length = ((width - 1) / this.pixelSize) + 1;
            int num12 = ((width - 1) % this.pixelSize) + 1;
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            if (format == PixelFormat.Format8bppIndexed)
            {
                int[] array = new int[length];
                int num13 = 0;
                int num14 = 0;
                while (num13 < height)
                {
                    Array.Clear(array, 0, length);
                    num5 = 0;
                    while ((num5 < this.pixelSize) && (num13 < height))
                    {
                        num8 = 0;
                        while (num8 < width)
                        {
                            array[num8 / this.pixelSize] += numPtr[0];
                            num8++;
                            numPtr++;
                        }
                        numPtr += num4;
                        num5++;
                        num13++;
                    }
                    num9 = num5 * this.pixelSize;
                    num10 = num5 * num12;
                    num6 = 0;
                    while (num6 < (length - 1))
                    {
                        array[num6] /= num9;
                        num6++;
                    }
                    array[num6] /= num10;
                    num5 = 0;
                    while ((num5 < this.pixelSize) && (num14 < height))
                    {
                        num8 = 0;
                        while (num8 < width)
                        {
                            numPtr2[0] = (byte) array[num8 / this.pixelSize];
                            num8++;
                            numPtr2++;
                        }
                        numPtr2 += num4;
                        num5++;
                        num14++;
                    }
                }
            }
            else
            {
                int[] numArray2 = new int[length * 3];
                int num15 = 0;
                int num16 = 0;
                while (num15 < height)
                {
                    int num7;
                    Array.Clear(numArray2, 0, length * 3);
                    num5 = 0;
                    while ((num5 < this.pixelSize) && (num15 < height))
                    {
                        num8 = 0;
                        while (num8 < width)
                        {
                            num7 = (num8 / this.pixelSize) * 3;
                            numArray2[num7] += numPtr[2];
                            numArray2[num7 + 1] += numPtr[1];
                            numArray2[num7 + 2] += numPtr[0];
                            num8++;
                            numPtr += 3;
                        }
                        numPtr += num4;
                        num5++;
                        num15++;
                    }
                    num9 = num5 * this.pixelSize;
                    num10 = num5 * num12;
                    num6 = 0;
                    num7 = 0;
                    while (num6 < (length - 1))
                    {
                        numArray2[num7] /= num9;
                        numArray2[num7 + 1] /= num9;
                        numArray2[num7 + 2] /= num9;
                        num6++;
                        num7 += 3;
                    }
                    numArray2[num7] /= num10;
                    numArray2[num7 + 1] /= num10;
                    numArray2[num7 + 2] /= num10;
                    num5 = 0;
                    while ((num5 < this.pixelSize) && (num16 < height))
                    {
                        num8 = 0;
                        while (num8 < width)
                        {
                            num7 = (num8 / this.pixelSize) * 3;
                            numPtr2[2] = (byte) numArray2[num7];
                            numPtr2[1] = (byte) numArray2[num7 + 1];
                            numPtr2[0] = (byte) numArray2[num7 + 2];
                            num8++;
                            numPtr2 += 3;
                        }
                        numPtr2 += num4;
                        num5++;
                        num16++;
                    }
                }
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }

        public int PixelSize
        {
            get
            {
                return this.pixelSize;
            }
            set
            {
                this.pixelSize = Math.Max(2, Math.Min(0x20, value));
            }
        }
    }
}

