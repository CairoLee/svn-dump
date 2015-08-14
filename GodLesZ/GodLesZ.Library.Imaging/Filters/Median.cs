namespace GodLesZ.Library.Imaging.Filters
{
	using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class Median : IFilter
    {
        private int size;

        public Median()
        {
            this.size = 3;
        }

        public Median(int size)
        {
            this.size = 3;
            this.Size = size;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int num5;
            int num6;
            int num7;
            int num9;
            int width = srcImg.Width;
            int height = srcImg.Height;
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = (format == PixelFormat.Format8bppIndexed) ? GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height) : new Bitmap(width, height, format);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, format);
            int stride = bitmapdata.Stride;
            int num4 = stride - ((format == PixelFormat.Format8bppIndexed) ? width : (width * 3));
            int num8 = this.size >> 1;
            byte[] array = new byte[this.size * this.size];
            byte[] buffer2 = new byte[this.size * this.size];
            byte[] buffer3 = new byte[this.size * this.size];
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            if (format == PixelFormat.Format8bppIndexed)
            {
                for (int i = 0; i < height; i++)
                {
                    int num11 = 0;
                    while (num11 < width)
                    {
                        num9 = 0;
                        num5 = -num8;
                        while (num5 <= num8)
                        {
                            num7 = i + num5;
                            if (num7 >= 0)
                            {
                                if (num7 >= height)
                                {
                                    goto Label_0169;
                                }
                                num6 = -num8;
                                while (num6 <= num8)
                                {
                                    num7 = num11 + num6;
                                    if ((num7 >= 0) && (num7 < width))
                                    {
                                        buffer2[num9++] = numPtr[(num5 * stride) + num6];
                                    }
                                    num6++;
                                }
                            }
                            num5++;
                        }
                    Label_0169:
                        Array.Sort<byte>(buffer2, 0, num9);
                        numPtr2[0] = buffer2[num9 >> 1];
                        num11++;
                        numPtr++;
                        numPtr2++;
                    }
                    numPtr += num4;
                    numPtr2 += num4;
                }
            }
            else
            {
                for (int j = 0; j < height; j++)
                {
                    int num13 = 0;
                    while (num13 < width)
                    {
                        num9 = 0;
                        for (num5 = -num8; num5 <= num8; num5++)
                        {
                            num7 = j + num5;
                            if (num7 >= 0)
                            {
                                if (num7 >= height)
                                {
                                    goto Label_0249;
                                }
                                for (num6 = -num8; num6 <= num8; num6++)
                                {
                                    num7 = num13 + num6;
                                    if ((num7 >= 0) && (num7 < width))
                                    {
                                        byte* numPtr3 = numPtr + ((num5 * stride) + (num6 * 3));
                                        array[num9] = numPtr3[2];
                                        buffer2[num9] = numPtr3[1];
                                        buffer3[num9] = numPtr3[0];
                                        num9++;
                                    }
                                }
                            }
                        }
                    Label_0249:
                        Array.Sort<byte>(array, 0, num9);
                        Array.Sort<byte>(buffer2, 0, num9);
                        Array.Sort<byte>(buffer3, 0, num9);
                        num7 = num9 >> 1;
                        numPtr2[2] = array[num7];
                        numPtr2[1] = buffer2[num7];
                        numPtr2[0] = buffer3[num7];
                        num13++;
                        numPtr += 3;
                        numPtr2 += 3;
                    }
                    numPtr += num4;
                    numPtr2 += num4;
                }
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = Math.Max(3, Math.Min(0x19, value | 1));
            }
        }
    }
}

