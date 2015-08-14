namespace GodLesZ.Library.Imaging.Filters
{
	using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class ConservativeSmoothing : IFilter
    {
        private int size;

        public ConservativeSmoothing()
        {
            this.size = 3;
        }

        public ConservativeSmoothing(int size)
        {
            this.size = 3;
            this.Size = size;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int num6;
            int num7;
            int num8;
            byte num12;
            byte num13;
            byte num16;
            int width = srcImg.Width;
            int height = srcImg.Height;
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = (format == PixelFormat.Format8bppIndexed) ? GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height) : new Bitmap(width, height, format);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, format);
            int num3 = (format == PixelFormat.Format8bppIndexed) ? 1 : 3;
            int stride = bitmapdata.Stride;
            int num5 = stride - (width * num3);
            int num9 = this.size >> 1;
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            if (format == PixelFormat.Format8bppIndexed)
            {
                for (int i = 0; i < height; i++)
                {
                    int num18 = 0;
                    while (num18 < width)
                    {
                        num12 = 0xff;
                        num13 = 0;
                        num6 = -num9;
                        while (num6 <= num9)
                        {
                            num8 = i + num6;
                            if (num8 >= 0)
                            {
                                if (num8 >= height)
                                {
                                    goto Label_014A;
                                }
                                num7 = -num9;
                                while (num7 <= num9)
                                {
                                    num8 = num18 + num7;
                                    if (((num8 >= 0) && (num6 != num7)) && (num8 < width))
                                    {
                                        num16 = numPtr[(num6 * stride) + num7];
                                        if (num16 < num12)
                                        {
                                            num12 = num16;
                                        }
                                        if (num16 > num13)
                                        {
                                            num13 = num16;
                                        }
                                    }
                                    num7++;
                                }
                            }
                            num6++;
                        }
                    Label_014A:
                        num16 = numPtr[0];
                        numPtr2[0] = (num16 > num13) ? num13 : ((num16 < num12) ? num12 : num16);
                        num18++;
                        numPtr++;
                        numPtr2++;
                    }
                    numPtr += num5;
                    numPtr2 += num5;
                }
            }
            else
            {
                for (int j = 0; j < height; j++)
                {
                    int num20 = 0;
                    while (num20 < width)
                    {
                        byte num14;
                        byte num15;
                        byte num10 = num12 = (byte) (num14 = 0xff);
                        byte num11 = num13 = (byte) (num15 = 0);
                        for (num6 = -num9; num6 <= num9; num6++)
                        {
                            num8 = j + num6;
                            if (num8 >= 0)
                            {
                                if (num8 >= height)
                                {
                                    goto Label_0289;
                                }
                                for (num7 = -num9; num7 <= num9; num7++)
                                {
                                    num8 = num20 + num7;
                                    if (((num8 >= 0) && (num6 != num7)) && (num8 < width))
                                    {
                                        byte* numPtr3 = numPtr + ((num6 * stride) + (num7 * 3));
                                        num16 = numPtr3[2];
                                        if (num16 < num10)
                                        {
                                            num10 = num16;
                                        }
                                        if (num16 > num11)
                                        {
                                            num11 = num16;
                                        }
                                        num16 = numPtr3[1];
                                        if (num16 < num12)
                                        {
                                            num12 = num16;
                                        }
                                        if (num16 > num13)
                                        {
                                            num13 = num16;
                                        }
                                        num16 = numPtr3[0];
                                        if (num16 < num14)
                                        {
                                            num14 = num16;
                                        }
                                        if (num16 > num15)
                                        {
                                            num15 = num16;
                                        }
                                    }
                                }
                            }
                        }
                    Label_0289:
                        num16 = numPtr[2];
                        numPtr2[2] = (num16 > num11) ? num11 : ((num16 < num10) ? num10 : num16);
                        num16 = numPtr[1];
                        numPtr2[1] = (num16 > num13) ? num13 : ((num16 < num12) ? num12 : num16);
                        num16 = numPtr[0];
                        numPtr2[0] = (num16 > num15) ? num15 : ((num16 < num14) ? num14 : num16);
                        num20++;
                        numPtr += 3;
                        numPtr2 += 3;
                    }
                    numPtr += num5;
                    numPtr2 += num5;
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

