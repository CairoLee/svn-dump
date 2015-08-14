namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging;

    public class Resize : IFilter
    {
        private InterpolationMethod method;
        private int newHeight;
        private int newWidth;

        public Resize()
        {
            this.method = InterpolationMethod.Bilinear;
        }

        public Resize(int newWidth, int newHeight)
        {
            this.method = InterpolationMethod.Bilinear;
            this.newWidth = newWidth;
            this.newHeight = newHeight;
        }

        public Resize(int newWidth, int newHeight, InterpolationMethod method)
        {
            this.method = InterpolationMethod.Bilinear;
            this.newWidth = newWidth;
            this.newHeight = newHeight;
            this.method = method;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int width = srcImg.Width;
            int height = srcImg.Height;
            if ((this.newWidth == width) && (this.newHeight == height))
            {
                return GodLesZ.Library.Imaging.Image.Clone(srcImg);
            }
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = (format == PixelFormat.Format8bppIndexed) ? GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(this.newWidth, this.newHeight) : new Bitmap(this.newWidth, this.newHeight, format);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, this.newWidth, this.newHeight), ImageLockMode.ReadWrite, format);
            int num3 = (format == PixelFormat.Format8bppIndexed) ? 1 : 3;
            int stride = bitmapdata.Stride;
            int num5 = data2.Stride - (num3 * this.newWidth);
            float num6 = ((float) width) / ((float) this.newWidth);
            float num7 = ((float) height) / ((float) this.newHeight);
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            switch (this.method)
            {
                case InterpolationMethod.NearestNeighbor:
                    for (int i = 0; i < this.newHeight; i++)
                    {
                        int num9 = (int) (i * num7);
                        for (int j = 0; j < this.newWidth; j++)
                        {
                            int num8 = (int) (j * num6);
                            byte* numPtr3 = (numPtr + (num9 * stride)) + (num8 * num3);
                            int num12 = 0;
                            while (num12 < num3)
                            {
                                numPtr2[0] = numPtr3[0];
                                num12++;
                                numPtr2++;
                                numPtr3++;
                            }
                        }
                        numPtr2 += num5;
                    }
                    break;

                case InterpolationMethod.Bilinear:
                {
                    int num23 = height - 1;
                    int num24 = width - 1;
                    for (int k = 0; k < this.newHeight; k++)
                    {
                        float num14 = k * num7;
                        int num20 = (int) num14;
                        int num22 = (num20 == num23) ? num20 : (num20 + 1);
                        float num16 = num14 - num20;
                        float num18 = 1f - num16;
                        byte* numPtr4 = numPtr + (num20 * stride);
                        byte* numPtr5 = numPtr + (num22 * stride);
                        for (int m = 0; m < this.newWidth; m++)
                        {
                            float num13 = m * num6;
                            int num19 = (int) num13;
                            int num21 = (num19 == num24) ? num19 : (num19 + 1);
                            float num15 = num13 - num19;
                            float num17 = 1f - num15;
                            byte* numPtr6 = numPtr4 + (num19 * num3);
                            byte* numPtr7 = numPtr4 + (num21 * num3);
                            byte* numPtr8 = numPtr5 + (num19 * num3);
                            byte* numPtr9 = numPtr5 + (num21 * num3);
                            int num29 = 0;
                            while (num29 < num3)
                            {
                                byte num25 = (byte) ((num17 * numPtr6[0]) + (num15 * numPtr7[0]));
                                byte num26 = (byte) ((num17 * numPtr8[0]) + (num15 * numPtr9[0]));
                                numPtr2[0] = (byte) ((num18 * num25) + (num16 * num26));
                                num29++;
                                numPtr2++;
                                numPtr6++;
                                numPtr7++;
                                numPtr8++;
                                numPtr9++;
                            }
                        }
                        numPtr2 += num5;
                    }
                    break;
                }
                case InterpolationMethod.Bicubic:
                {
                    float num30;
                    float num31;
                    float num32;
                    float num33;
                    float num34;
                    float num35;
                    float num37;
                    int num39;
                    int num40;
                    int num41;
                    int num42;
                    int num43 = height - 1;
                    int num44 = width - 1;
                    if (format != PixelFormat.Format8bppIndexed)
                    {
                        for (int num49 = 0; num49 < this.newHeight; num49++)
                        {
                            num31 = (num49 * num7) - 0.5f;
                            num40 = (int) num31;
                            num33 = num31 - num40;
                            int num50 = 0;
                            while (num50 < this.newWidth)
                            {
                                float num38;
                                num30 = (num50 * num6) - 0.5f;
                                num39 = (int) num30;
                                num32 = num30 - num39;
                                float num36 = num37 = num38 = 0f;
                                for (int num51 = -1; num51 < 3; num51++)
                                {
                                    num34 = Interpolation.BiCubicKernel(num33 - num51);
                                    num42 = num40 + num51;
                                    if (num42 < 0)
                                    {
                                        num42 = 0;
                                    }
                                    if (num42 > num43)
                                    {
                                        num42 = num43;
                                    }
                                    for (int num52 = -1; num52 < 3; num52++)
                                    {
                                        num35 = num34 * Interpolation.BiCubicKernel(num52 - num32);
                                        num41 = num39 + num52;
                                        if (num41 < 0)
                                        {
                                            num41 = 0;
                                        }
                                        if (num41 > num44)
                                        {
                                            num41 = num44;
                                        }
                                        byte* numPtr10 = (numPtr + (num42 * stride)) + (num41 * 3);
                                        num36 += num35 * numPtr10[2];
                                        num37 += num35 * numPtr10[1];
                                        num38 += num35 * numPtr10[0];
                                    }
                                }
                                numPtr2[2] = (byte) num36;
                                numPtr2[1] = (byte) num37;
                                numPtr2[0] = (byte) num38;
                                num50++;
                                numPtr2 += 3;
                            }
                            numPtr2 += num5;
                        }
                        break;
                    }
                    for (int n = 0; n < this.newHeight; n++)
                    {
                        num31 = (n * num7) - 0.5f;
                        num40 = (int) num31;
                        num33 = num31 - num40;
                        int num46 = 0;
                        while (num46 < this.newWidth)
                        {
                            num30 = (num46 * num6) - 0.5f;
                            num39 = (int) num30;
                            num32 = num30 - num39;
                            num37 = 0f;
                            for (int num47 = -1; num47 < 3; num47++)
                            {
                                num34 = Interpolation.BiCubicKernel(num33 - num47);
                                num42 = num40 + num47;
                                if (num42 < 0)
                                {
                                    num42 = 0;
                                }
                                if (num42 > num43)
                                {
                                    num42 = num43;
                                }
                                for (int num48 = -1; num48 < 3; num48++)
                                {
                                    num35 = num34 * Interpolation.BiCubicKernel(num48 - num32);
                                    num41 = num39 + num48;
                                    if (num41 < 0)
                                    {
                                        num41 = 0;
                                    }
                                    if (num41 > num44)
                                    {
                                        num41 = num44;
                                    }
                                    num37 += num35 * numPtr[(num42 * stride) + num41];
                                }
                            }
                            numPtr2[0] = (byte) num37;
                            num46++;
                            numPtr2++;
                        }
                        numPtr2 += num5;
                    }
                    break;
                }
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }

        public InterpolationMethod Method
        {
            get
            {
                return this.method;
            }
            set
            {
                this.method = value;
            }
        }

        public int NewHeight
        {
            get
            {
                return this.newHeight;
            }
            set
            {
                this.newHeight = Math.Max(1, Math.Min(0x1388, value));
            }
        }

        public int NewWidth
        {
            get
            {
                return this.newWidth;
            }
            set
            {
                this.newWidth = Math.Max(1, Math.Min(0x1388, value));
            }
        }
    }
}

