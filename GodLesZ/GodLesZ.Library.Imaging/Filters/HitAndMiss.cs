namespace GodLesZ.Library.Imaging.Filters
{
	using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class HitAndMiss : IFilter
    {
        private HitAndMissMode mode;
        private short[,] se;
        private int size;

        public HitAndMiss(short[,] se)
        {
            int length = se.GetLength(0);
            if (((length != se.GetLength(1)) || (length < 3)) || ((length > 0x19) || ((length % 2) == 0)))
            {
                throw new ArgumentException();
            }
            this.se = se;
            this.size = length;
        }

        public HitAndMiss(short[,] se, HitAndMissMode mode) : this(se)
        {
            this.mode = mode;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            if (srcImg.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                throw new ArgumentException();
            }
            int width = srcImg.Width;
            int height = srcImg.Height;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            Bitmap bitmap = GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            int stride = data2.Stride;
            int num4 = stride - width;
            int num9 = this.size >> 1;
            byte[] buffer3 = new byte[3];
            buffer3[0] = 0xff;
            buffer3[2] = 0xff;
            byte[] buffer = buffer3;
            byte[] buffer2 = new byte[3];
            int mode = (int) this.mode;
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            for (int i = 0; i < height; i++)
            {
                int num15 = 0;
                while (num15 < width)
                {
                    buffer2[1] = buffer2[2] = numPtr[0];
                    byte num10 = 0xff;
                    for (int j = 0; j < this.size; j++)
                    {
                        int num5 = j - num9;
                        for (int k = 0; k < this.size; k++)
                        {
                            int num6 = k - num9;
                            short num12 = this.se[j, k];
                            if (num12 != -1)
                            {
                                if ((((i + num5) < 0) || ((i + num5) >= height)) || (((num15 + num6) < 0) || ((num15 + num6) >= width)))
                                {
                                    num10 = 0;
                                    break;
                                }
                                byte num11 = numPtr[(num5 * stride) + num6];
                                if (((num12 != 0) || (num11 != 0)) && ((num12 != 1) || (num11 != 0xff)))
                                {
                                    num10 = 0;
                                    break;
                                }
                            }
                        }
                        if (num10 == 0)
                        {
                            break;
                        }
                    }
                    numPtr2[0] = (num10 == 0xff) ? buffer[mode] : buffer2[mode];
                    num15++;
                    numPtr++;
                    numPtr2++;
                }
                numPtr += num4;
                numPtr2 += num4;
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }

        public HitAndMissMode Mode
        {
            get
            {
                return this.mode;
            }
            set
            {
                this.mode = value;
            }
        }
    }
}

