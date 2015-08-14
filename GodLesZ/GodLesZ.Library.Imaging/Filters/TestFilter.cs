namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging;

    public class TestFilter : IFilter
    {
        private byte threshold = 10;

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int width = srcImg.Width;
            int height = srcImg.Height;
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            if (format != PixelFormat.Format8bppIndexed)
            {
                throw new ArgumentException();
            }
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = (format == PixelFormat.Format8bppIndexed) ? GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height) : new Bitmap(width, height, format);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, format);
            int stride = bitmapdata.Stride;
            int index = 1;
            Win32.memcpy(data2.Scan0, bitmapdata.Scan0, height * bitmapdata.Stride);
            if (format == PixelFormat.Format8bppIndexed)
            {
                byte[,] buffer = null;
                int length = width >> index;
                for (int i = height >> index; (length > 0) && (i > 0); i = i >> 1)
                {
                    byte* numPtr3 = (byte*) data2.Scan0.ToPointer();
                    byte* numPtr4 = (byte*) data2.Scan0.ToPointer();
                    byte[,] buffer2 = new byte[i, length];
                    int[] array = new int[length];
                    int num7 = index << 1;
                    for (int j = 0; j < i; j++)
                    {
                        Array.Clear(array, 0, length);
                        byte* numPtr = numPtr3;
                        byte* numPtr2 = numPtr3 + (stride * index);
                        int num9 = 0;
                        while (num9 < length)
                        {
                            array[num9] = ((numPtr[0] + numPtr[index]) + numPtr2[0]) + numPtr2[index];
                            num9++;
                            numPtr += num7;
                            numPtr2 += num7;
                        }
                        numPtr3 += stride * num7;
                        for (int k = 0; k < length; k++)
                        {
                            array[k] = array[k] >> 2;
                        }
                        numPtr = numPtr4;
                        numPtr2 = numPtr4 + (stride * index);
                        int num11 = 0;
                        while (num11 < length)
                        {
                            int num12 = array[num11];
                            if (((Math.Abs((int) (numPtr[0] - num12)) < this.threshold) && (Math.Abs((int) (numPtr[index] - num12)) < this.threshold)) && ((Math.Abs((int) (numPtr2[0] - num12)) < this.threshold) && (Math.Abs((int) (numPtr2[index] - num12)) < this.threshold)))
                            {
                                if (buffer == null)
                                {
                                    byte num18;
                                    byte num19;
                                    numPtr2[index] = num18 = (byte) num12;
                                    numPtr2[0] = num19 = num18;
                                    numPtr[0] = numPtr[index] = num19;
                                    buffer2[j, num11] = 1;
                                }
                                else
                                {
                                    int num13 = j << 1;
                                    int num14 = num11 << 1;
                                    if ((((buffer[num13, num14] & buffer[num13, num14 + 1]) & buffer[num13 + 1, num14]) & buffer[num13 + 1, num14 + 1]) == 1)
                                    {
                                        int num15 = stride - num7;
										byte* numPtr5 = (byte*)((byte*)data2.Scan0.ToPointer() + (((j * num7) * stride) + (num11 * num7)));
                                        for (int m = 0; m < num7; m++)
                                        {
                                            int num17 = 0;
                                            while (num17 < num7)
                                            {
                                                numPtr5[0] = (byte) num12;
                                                num17++;
                                                numPtr5++;
                                            }
                                            numPtr5 += num15;
                                        }
                                        buffer2[j, num11] = 1;
                                    }
                                }
                            }
                            num11++;
                            numPtr += num7;
                            numPtr2 += num7;
                        }
                        numPtr4 += stride * num7;
                    }
                    buffer = buffer2;
                    index = index << 1;
                    length = length >> 1;
                }
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }
    }
}

