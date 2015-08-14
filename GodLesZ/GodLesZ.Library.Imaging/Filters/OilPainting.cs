namespace GodLesZ.Library.Imaging.Filters
{
	using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class OilPainting : IFilter
    {
        private int brushSize;

        public OilPainting()
        {
            this.brushSize = 5;
        }

        public OilPainting(int brushSize)
        {
            this.brushSize = 5;
            this.BrushSize = brushSize;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int num5;
            int num6;
            int num7;
            byte num9;
            byte num10;
            int width = srcImg.Width;
            int height = srcImg.Height;
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = (format == PixelFormat.Format8bppIndexed) ? GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height) : new Bitmap(width, height, format);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, format);
            int stride = bitmapdata.Stride;
            int num4 = stride - ((format == PixelFormat.Format8bppIndexed) ? width : (width * 3));
            int num8 = this.brushSize >> 1;
            int[] array = new int[0x100];
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            if (format == PixelFormat.Format8bppIndexed)
            {
                for (int i = 0; i < height; i++)
                {
                    int num12 = 0;
                    while (num12 < width)
                    {
                        Array.Clear(array, 0, 0xff);
                        num5 = -num8;
                        while (num5 <= num8)
                        {
                            num7 = i + num5;
                            if (num7 >= 0)
                            {
                                if (num7 >= height)
                                {
                                    goto Label_0151;
                                }
                                num6 = -num8;
                                while (num6 <= num8)
                                {
                                    num7 = num12 + num6;
                                    if ((num7 >= 0) && (num7 < width))
                                    {
                                        num9 = numPtr[(num5 * stride) + num6];
                                        array[num9]++;
                                    }
                                    num6++;
                                }
                            }
                            num5++;
                        }
                    Label_0151:
                        num10 = 0;
                        num6 = 0;
                        num5 = 0;
                        while (num5 < 0x100)
                        {
                            if (array[num5] > num6)
                            {
                                num10 = (byte) num5;
                                num6 = array[num5];
                            }
                            num5++;
                        }
                        numPtr2[0] = num10;
                        num12++;
                        numPtr++;
                        numPtr2++;
                    }
                    numPtr += num4;
                    numPtr2 += num4;
                }
            }
            else
            {
                int[] numArray2 = new int[0x100];
                int[] numArray3 = new int[0x100];
                int[] numArray4 = new int[0x100];
                for (int j = 0; j < height; j++)
                {
                    int num14 = 0;
                    while (num14 < width)
                    {
                        Array.Clear(array, 0, 0xff);
                        Array.Clear(numArray2, 0, 0x100);
                        Array.Clear(numArray3, 0, 0x100);
                        Array.Clear(numArray4, 0, 0x100);
                        num5 = -num8;
                        while (num5 <= num8)
                        {
                            num7 = j + num5;
                            if (num7 >= 0)
                            {
                                if (num7 >= height)
                                {
                                    goto Label_0327;
                                }
                                num6 = -num8;
                                while (num6 <= num8)
                                {
                                    num7 = num14 + num6;
                                    if ((num7 >= 0) && (num7 < width))
                                    {
                                        byte* numPtr3 = numPtr + ((num5 * stride) + (num6 * 3));
                                        num9 = (byte) (((0.2125f * numPtr3[2]) + (0.7154f * numPtr3[1])) + (0.0721f * numPtr3[0]));
                                        array[num9]++;
                                        numArray2[num9] += numPtr3[2];
                                        numArray3[num9] += numPtr3[1];
                                        numArray4[num9] += numPtr3[0];
                                    }
                                    num6++;
                                }
                            }
                            num5++;
                        }
                    Label_0327:
                        num10 = 0;
                        num6 = 0;
                        for (num5 = 0; num5 < 0x100; num5++)
                        {
                            if (array[num5] > num6)
                            {
                                num10 = (byte) num5;
                                num6 = array[num5];
                            }
                        }
                        numPtr2[2] = (byte) (numArray2[num10] / array[num10]);
                        numPtr2[1] = (byte) (numArray3[num10] / array[num10]);
                        numPtr2[0] = (byte) (numArray4[num10] / array[num10]);
                        num14++;
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

        public int BrushSize
        {
            get
            {
                return this.brushSize;
            }
            set
            {
                this.brushSize = Math.Max(3, Math.Min(0x15, value | 1));
            }
        }
    }
}

