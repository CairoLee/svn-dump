namespace GodLesZ.Library.Imaging.Filters
{
	using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class Correlation : IFilter
    {
        protected int[,] kernel;
        protected int size;

        protected Correlation()
        {
        }

        public Correlation(int[,] kernel)
        {
            int length = kernel.GetLength(0);
            if (((length != kernel.GetLength(1)) || (length < 3)) || ((length > 0x19) || ((length % 2) == 0)))
            {
                throw new ArgumentException();
            }
            this.kernel = kernel;
            this.size = length;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            int num10;
            long num13;
            long num15;
            int width = srcImg.Width;
            int height = srcImg.Height;
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = (format == PixelFormat.Format8bppIndexed) ? GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height) : new Bitmap(width, height, format);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, format);
            int stride = bitmapdata.Stride;
            int num4 = stride - ((format == PixelFormat.Format8bppIndexed) ? width : (width * 3));
            int num11 = this.size >> 1;
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            if (format == PixelFormat.Format8bppIndexed)
            {
                for (int i = 0; i < height; i++)
                {
                    int num17 = 0;
                    while (num17 < width)
                    {
                        num13 = num15 = 0L;
                        num5 = 0;
                        while (num5 < this.size)
                        {
                            num9 = num5 - num11;
                            num7 = i + num9;
                            if (num7 >= 0)
                            {
                                if (num7 >= height)
                                {
                                    goto Label_015E;
                                }
                                num6 = 0;
                                while (num6 < this.size)
                                {
                                    num10 = num6 - num11;
                                    num7 = num17 + num10;
                                    if ((num7 >= 0) && (num7 < width))
                                    {
                                        num8 = this.kernel[num5, num6];
                                        num15 += num8;
                                        num13 += num8 * numPtr[(num9 * stride) + num10];
                                    }
                                    num6++;
                                }
                            }
                            num5++;
                        }
                    Label_015E:
                        if (num15 != 0L)
                        {
                            num13 /= num15;
                        }
                        numPtr2[0] = (num13 > 0xffL) ? ((byte) 0xff) : ((num13 < 0L) ? ((byte) 0) : ((byte) num13));
                        num17++;
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
                    int num19 = 0;
                    while (num19 < width)
                    {
                        long num14;
                        long num12 = num13 = num14 = num15 = 0L;
                        for (num5 = 0; num5 < this.size; num5++)
                        {
                            num9 = num5 - num11;
                            num7 = j + num9;
                            if (num7 >= 0)
                            {
                                if (num7 >= height)
                                {
                                    goto Label_029E;
                                }
                                for (num6 = 0; num6 < this.size; num6++)
                                {
                                    num10 = num6 - num11;
                                    num7 = num19 + num10;
                                    if ((num7 >= 0) && (num7 < width))
                                    {
                                        num8 = this.kernel[num5, num6];
                                        byte* numPtr3 = numPtr + ((num9 * stride) + (num10 * 3));
                                        num15 += num8;
                                        num12 += num8 * numPtr3[2];
                                        num13 += num8 * numPtr3[1];
                                        num14 += num8 * numPtr3[0];
                                    }
                                }
                            }
                        }
                    Label_029E:
                        if (num15 != 0L)
                        {
                            num12 /= num15;
                            num13 /= num15;
                            num14 /= num15;
                        }
                        numPtr2[2] = (num12 > 0xffL) ? ((byte) 0xff) : ((num12 < 0L) ? ((byte) 0) : ((byte) num12));
                        numPtr2[1] = (num13 > 0xffL) ? ((byte) 0xff) : ((num13 < 0L) ? ((byte) 0) : ((byte) num13));
                        numPtr2[0] = (num14 > 0xffL) ? ((byte) 0xff) : ((num14 < 0L) ? ((byte) 0) : ((byte) num14));
                        num19++;
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
    }
}

