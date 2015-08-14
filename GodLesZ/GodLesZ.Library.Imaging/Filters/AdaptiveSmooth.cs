namespace GodLesZ.Library.Imaging.Filters
{
	using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class AdaptiveSmooth : IFilter
    {
        private float factor;

        public AdaptiveSmooth()
        {
            this.factor = 3f;
        }

        public AdaptiveSmooth(float factor)
        {
            this.factor = 3f;
            this.factor = factor;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int width = srcImg.Width;
            int height = srcImg.Height;
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = (format == PixelFormat.Format8bppIndexed) ? GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height) : new Bitmap(width, height, format);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, format);
            int stride = bitmapdata.Stride;
            int index = (format == PixelFormat.Format8bppIndexed) ? 1 : 3;
            int num5 = index * 2;
            int num6 = stride - (width * index);
            int num7 = width - 2;
            int num8 = height - 2;
            float num9 = (-8f * this.factor) * this.factor;
			byte* numPtr = (byte*)((byte*)bitmapdata.Scan0.ToPointer() + (stride * 2));
			byte* numPtr2 = (byte*)((byte*)data2.Scan0.ToPointer() + (stride * 2));
            for (int i = 2; i < num8; i++)
            {
                numPtr += 2 * index;
                numPtr2 += 2 * index;
                for (int j = 2; j < num7; j++)
                {
                    int num17 = 0;
                    while (num17 < index)
                    {
                        float num13 = 0f;
                        float num14 = 0f;
                        float num10 = numPtr[-stride] - numPtr[-num5 - stride];
                        float num11 = numPtr[-index] - numPtr[-index - (2 * stride)];
                        float num12 = (float) Math.Exp((double) (((num10 * num10) + (num11 * num11)) / num9));
                        num14 += num12 * numPtr[-index - stride];
                        num13 += num12;
                        num10 = numPtr[index - stride] - numPtr[-index - stride];
                        num11 = numPtr[0] - numPtr[-2 * stride];
                        num12 = (float) Math.Exp((double) (((num10 * num10) + (num11 * num11)) / num9));
                        num14 += num12 * numPtr[-stride];
                        num13 += num12;
                        num10 = numPtr[num5 - stride] - numPtr[-stride];
                        num11 = numPtr[index] - numPtr[index - (2 * stride)];
                        num12 = (float) Math.Exp((double) (((num10 * num10) + (num11 * num11)) / num9));
                        num14 += num12 * numPtr[index - stride];
                        num13 += num12;
                        num10 = numPtr[0] - numPtr[-num5];
                        num11 = numPtr[-index + stride] - numPtr[-index - stride];
                        num12 = (float) Math.Exp((double) (((num10 * num10) + (num11 * num11)) / num9));
                        num14 += num12 * numPtr[-index];
                        num13 += num12;
                        num10 = numPtr[index] - numPtr[-index];
                        num11 = numPtr[stride] - numPtr[-stride];
                        num12 = (float) Math.Exp((double) (((num10 * num10) + (num11 * num11)) / num9));
                        num14 += num12 * numPtr[0];
                        num13 += num12;
                        num10 = numPtr[num5] - numPtr[0];
                        num11 = numPtr[index + stride] - numPtr[index - stride];
                        num12 = (float) Math.Exp((double) (((num10 * num10) + (num11 * num11)) / num9));
                        num14 += num12 * numPtr[index];
                        num13 += num12;
                        num10 = numPtr[stride] - numPtr[-num5 + stride];
                        num11 = numPtr[-index + (2 * stride)] - numPtr[-index];
                        num12 = (float) Math.Exp((double) (((num10 * num10) + (num11 * num11)) / num9));
                        num14 += num12 * numPtr[-index + stride];
                        num13 += num12;
                        num10 = numPtr[index + stride] - numPtr[-index + stride];
                        num11 = numPtr[2 * stride] - numPtr[0];
                        num12 = (float) Math.Exp((double) (((num10 * num10) + (num11 * num11)) / num9));
                        num14 += num12 * numPtr[stride];
                        num13 += num12;
                        num10 = numPtr[num5 + stride] - numPtr[stride];
                        num11 = numPtr[index + (2 * stride)] - numPtr[index];
                        num12 = (float) Math.Exp((double) (((num10 * num10) + (num11 * num11)) / num9));
                        num14 += num12 * numPtr[index + stride];
                        num13 += num12;
                        numPtr2[0] = (num13 == 0.0) ? numPtr[0] : ((byte) Math.Min((float) (num14 / num13), (float) 255f));
                        num17++;
                        numPtr++;
                        numPtr2++;
                    }
                }
                numPtr += num6 + (2 * index);
                numPtr2 += num6 + (2 * index);
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }

        public float Factor
        {
            get
            {
                return this.factor;
            }
            set
            {
                this.factor = value;
            }
        }
    }
}

