namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging;

    public class Rotate : IFilter
    {
        private float angle;
        private Color fillColor;
        private bool keepSize;
        private InterpolationMethod method;

        public Rotate()
        {
            this.method = InterpolationMethod.Bilinear;
            this.fillColor = Color.FromArgb(0, 0, 0);
        }

        public Rotate(float angle)
        {
            this.method = InterpolationMethod.Bilinear;
            this.fillColor = Color.FromArgb(0, 0, 0);
            this.angle = angle;
        }

        public Rotate(float angle, InterpolationMethod method)
        {
            this.method = InterpolationMethod.Bilinear;
            this.fillColor = Color.FromArgb(0, 0, 0);
            this.angle = angle;
            this.method = method;
        }

        public Rotate(float angle, InterpolationMethod method, bool keepSize)
        {
            this.method = InterpolationMethod.Bilinear;
            this.fillColor = Color.FromArgb(0, 0, 0);
            this.angle = angle;
            this.method = method;
            this.keepSize = keepSize;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            double num8;
            double num9;
            int num10;
            int num11;
            int width = srcImg.Width;
            int height = srcImg.Height;
            if (this.angle == 0f)
            {
                return GodLesZ.Library.Imaging.Image.Clone(srcImg);
            }
            double d = (-this.angle * 3.1415926535897931) / 180.0;
            double num4 = Math.Cos(d);
            double num5 = Math.Sin(d);
            double num6 = ((double) width) / 2.0;
            double num7 = ((double) height) / 2.0;
            if (this.keepSize)
            {
                num8 = num6;
                num9 = num7;
                num10 = width;
                num11 = height;
            }
            else
            {
                double num12 = num6 * num4;
                double num13 = num6 * num5;
                double num14 = (num6 * num4) - (num7 * num5);
                double num15 = (num6 * num5) + (num7 * num4);
                double num16 = -num7 * num5;
                double num17 = num7 * num4;
                double num18 = 0.0;
                double num19 = 0.0;
                num8 = Math.Max(Math.Max(num12, num14), Math.Max(num16, num18)) - Math.Min(Math.Min(num12, num14), Math.Min(num16, num18));
                num9 = Math.Max(Math.Max(num13, num15), Math.Max(num17, num19)) - Math.Min(Math.Min(num13, num15), Math.Min(num17, num19));
                num10 = (int) ((num8 * 2.0) + 0.5);
                num11 = (int) ((num9 * 2.0) + 0.5);
            }
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = (format == PixelFormat.Format8bppIndexed) ? GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(num10, num11) : new Bitmap(num10, num11, format);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, num10, num11), ImageLockMode.ReadWrite, format);
            int stride = bitmapdata.Stride;
            int num21 = data2.Stride - ((format == PixelFormat.Format8bppIndexed) ? num10 : (num10 * 3));
            byte r = this.fillColor.R;
            byte g = this.fillColor.G;
            byte b = this.fillColor.B;
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            switch (this.method)
            {
                case InterpolationMethod.NearestNeighbor:
                    double num25;
                    double num26;
                    int num27;
                    int num28;
                    if (format != PixelFormat.Format8bppIndexed)
                    {
                        num26 = -num9;
                        for (int j = 0; j < num11; j++)
                        {
                            num25 = -num8;
                            int num32 = 0;
                            while (num32 < num10)
                            {
                                num27 = (int) (((num4 * num25) + (num5 * num26)) + num6);
                                num28 = (int) (((-num5 * num25) + (num4 * num26)) + num7);
                                if (((num27 < 0) || (num28 < 0)) || ((num27 >= width) || (num28 >= height)))
                                {
                                    numPtr2[2] = r;
                                    numPtr2[1] = g;
                                    numPtr2[0] = b;
                                }
                                else
                                {
                                    byte* numPtr3 = (numPtr + (num28 * stride)) + (num27 * 3);
                                    numPtr2[2] = numPtr3[2];
                                    numPtr2[1] = numPtr3[1];
                                    numPtr2[0] = numPtr3[0];
                                }
                                num25++;
                                num32++;
                                numPtr2 += 3;
                            }
                            num26++;
                            numPtr2 += num21;
                        }
                        break;
                    }
                    num26 = -num9;
                    for (int i = 0; i < num11; i++)
                    {
                        num25 = -num8;
                        int num30 = 0;
                        while (num30 < num10)
                        {
                            num27 = (int) (((num4 * num25) + (num5 * num26)) + num6);
                            num28 = (int) (((-num5 * num25) + (num4 * num26)) + num7);
                            if (((num27 < 0) || (num28 < 0)) || ((num27 >= width) || (num28 >= height)))
                            {
                                numPtr2[0] = g;
                            }
                            else
                            {
                                numPtr2[0] = numPtr[(num28 * stride) + num27];
                            }
                            num25++;
                            num30++;
                            numPtr2++;
                        }
                        num26++;
                        numPtr2 += num21;
                    }
                    break;

                case InterpolationMethod.Bilinear:
                {
                    double num33;
                    double num34;
                    float num35;
                    float num36;
                    float num37;
                    float num38;
                    float num39;
                    float num40;
                    int num41;
                    int num42;
                    int num43;
                    int num44;
                    byte num47;
                    byte num48;
                    byte* numPtr4;
                    byte* numPtr5;
                    int num45 = height - 1;
                    int num46 = width - 1;
                    if (format != PixelFormat.Format8bppIndexed)
                    {
                        num34 = -num9;
                        for (int m = 0; m < num11; m++)
                        {
                            num33 = -num8;
                            int num52 = 0;
                            while (num52 < num10)
                            {
                                num35 = (float) (((num4 * num33) + (num5 * num34)) + num6);
                                num36 = (float) (((-num5 * num33) + (num4 * num34)) + num7);
                                num41 = (int) num35;
                                num42 = (int) num36;
                                if (((num41 < 0) || (num42 < 0)) || ((num41 >= width) || (num42 >= height)))
                                {
                                    numPtr2[2] = r;
                                    numPtr2[1] = g;
                                    numPtr2[0] = b;
                                }
                                else
                                {
                                    byte* numPtr7;
                                    num43 = (num41 == num46) ? num41 : (num41 + 1);
                                    num44 = (num42 == num45) ? num42 : (num42 + 1);
                                    num37 = num35 - num41;
                                    if (num37 < 0f)
                                    {
                                        num37 = 0f;
                                    }
                                    num39 = 1f - num37;
                                    num38 = num36 - num42;
                                    if (num38 < 0f)
                                    {
                                        num38 = 0f;
                                    }
                                    num40 = 1f - num38;
                                    numPtr4 = numPtr5 = numPtr + (num42 * stride);
                                    numPtr4 += num41 * 3;
                                    numPtr5 += num43 * 3;
                                    byte* numPtr6 = numPtr7 = numPtr + (num44 * stride);
                                    numPtr6 += num41 * 3;
                                    numPtr7 += num43 * 3;
                                    num47 = (byte) ((num39 * numPtr4[2]) + (num37 * numPtr5[2]));
                                    num48 = (byte) ((num39 * numPtr6[2]) + (num37 * numPtr7[2]));
                                    numPtr2[2] = (byte) ((num40 * num47) + (num38 * num48));
                                    num47 = (byte) ((num39 * numPtr4[1]) + (num37 * numPtr5[1]));
                                    num48 = (byte) ((num39 * numPtr6[1]) + (num37 * numPtr7[1]));
                                    numPtr2[1] = (byte) ((num40 * num47) + (num38 * num48));
                                    num47 = (byte) ((num39 * numPtr4[0]) + (num37 * numPtr5[0]));
                                    num48 = (byte) ((num39 * numPtr6[0]) + (num37 * numPtr7[0]));
                                    numPtr2[0] = (byte) ((num40 * num47) + (num38 * num48));
                                }
                                num33++;
                                num52++;
                                numPtr2 += 3;
                            }
                            num34++;
                            numPtr2 += num21;
                        }
                        break;
                    }
                    num34 = -num9;
                    for (int k = 0; k < num11; k++)
                    {
                        num33 = -num8;
                        int num50 = 0;
                        while (num50 < num10)
                        {
                            num35 = (float) (((num4 * num33) + (num5 * num34)) + num6);
                            num36 = (float) (((-num5 * num33) + (num4 * num34)) + num7);
                            num41 = (int) num35;
                            num42 = (int) num36;
                            if (((num41 < 0) || (num42 < 0)) || ((num41 >= width) || (num42 >= height)))
                            {
                                numPtr2[0] = g;
                            }
                            else
                            {
                                num43 = (num41 == num46) ? num41 : (num41 + 1);
                                num44 = (num42 == num45) ? num42 : (num42 + 1);
                                num37 = num35 - num41;
                                if (num37 < 0f)
                                {
                                    num37 = 0f;
                                }
                                num39 = 1f - num37;
                                num38 = num36 - num42;
                                if (num38 < 0f)
                                {
                                    num38 = 0f;
                                }
                                num40 = 1f - num38;
                                numPtr4 = numPtr + (num42 * stride);
                                numPtr5 = numPtr + (num44 * stride);
                                num47 = (byte) ((num39 * numPtr4[num41]) + (num37 * numPtr4[num43]));
                                num48 = (byte) ((num39 * numPtr5[num41]) + (num37 * numPtr5[num43]));
                                numPtr2[0] = (byte) ((num40 * num47) + (num38 * num48));
                            }
                            num33++;
                            num50++;
                            numPtr2++;
                        }
                        num34++;
                        numPtr2 += num21;
                    }
                    break;
                }
                case InterpolationMethod.Bicubic:
                {
                    double num53;
                    double num54;
                    float num55;
                    float num56;
                    float num57;
                    float num58;
                    float num59;
                    float num60;
                    float num62;
                    int num64;
                    int num65;
                    int num66;
                    int num67;
                    int num68 = height - 1;
                    int num69 = width - 1;
                    if (format != PixelFormat.Format8bppIndexed)
                    {
                        num54 = -num9;
                        for (int num74 = 0; num74 < num11; num74++)
                        {
                            num53 = -num8;
                            int num75 = 0;
                            while (num75 < num10)
                            {
                                num55 = (float) (((num4 * num53) + (num5 * num54)) + num6);
                                num56 = (float) (((-num5 * num53) + (num4 * num54)) + num7);
                                num64 = (int) num55;
                                num65 = (int) num56;
                                if (((num64 < 0) || (num65 < 0)) || ((num64 >= width) || (num65 >= height)))
                                {
                                    numPtr2[2] = r;
                                    numPtr2[1] = g;
                                    numPtr2[0] = b;
                                }
                                else
                                {
                                    float num63;
                                    num57 = num55 - num64;
                                    num58 = num56 - num65;
                                    float num61 = num62 = num63 = 0f;
                                    for (int num76 = -1; num76 < 3; num76++)
                                    {
                                        num59 = Interpolation.BiCubicKernel(num58 - num76);
                                        num67 = num65 + num76;
                                        if (num67 < 0)
                                        {
                                            num67 = 0;
                                        }
                                        if (num67 > num68)
                                        {
                                            num67 = num68;
                                        }
                                        for (int num77 = -1; num77 < 3; num77++)
                                        {
                                            num60 = num59 * Interpolation.BiCubicKernel(num77 - num57);
                                            num66 = num64 + num77;
                                            if (num66 < 0)
                                            {
                                                num66 = 0;
                                            }
                                            if (num66 > num69)
                                            {
                                                num66 = num69;
                                            }
                                            byte* numPtr8 = (numPtr + (num67 * stride)) + (num66 * 3);
                                            num61 += num60 * numPtr8[2];
                                            num62 += num60 * numPtr8[1];
                                            num63 += num60 * numPtr8[0];
                                        }
                                    }
                                    numPtr2[2] = (byte) num61;
                                    numPtr2[1] = (byte) num62;
                                    numPtr2[0] = (byte) num63;
                                }
                                num53++;
                                num75++;
                                numPtr2 += 3;
                            }
                            num54++;
                            numPtr2 += num21;
                        }
                        break;
                    }
                    num54 = -num9;
                    for (int n = 0; n < num11; n++)
                    {
                        num53 = -num8;
                        int num71 = 0;
                        while (num71 < num10)
                        {
                            num55 = (float) (((num4 * num53) + (num5 * num54)) + num6);
                            num56 = (float) (((-num5 * num53) + (num4 * num54)) + num7);
                            num64 = (int) num55;
                            num65 = (int) num56;
                            if (((num64 < 0) || (num65 < 0)) || ((num64 >= width) || (num65 >= height)))
                            {
                                numPtr2[0] = g;
                            }
                            else
                            {
                                num57 = num55 - num64;
                                num58 = num56 - num65;
                                num62 = 0f;
                                for (int num72 = -1; num72 < 3; num72++)
                                {
                                    num59 = Interpolation.BiCubicKernel(num58 - num72);
                                    num67 = num65 + num72;
                                    if (num67 < 0)
                                    {
                                        num67 = 0;
                                    }
                                    if (num67 > num68)
                                    {
                                        num67 = num68;
                                    }
                                    for (int num73 = -1; num73 < 3; num73++)
                                    {
                                        num60 = num59 * Interpolation.BiCubicKernel(num73 - num57);
                                        num66 = num64 + num73;
                                        if (num66 < 0)
                                        {
                                            num66 = 0;
                                        }
                                        if (num66 > num69)
                                        {
                                            num66 = num69;
                                        }
                                        num62 += num60 * numPtr[(num67 * stride) + num66];
                                    }
                                }
                                numPtr2[0] = (byte) num62;
                            }
                            num53++;
                            num71++;
                            numPtr2++;
                        }
                        num54++;
                        numPtr2 += num21;
                    }
                    break;
                }
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }

        public float Angle
        {
            get
            {
                return this.angle;
            }
            set
            {
                this.angle = value % 360f;
            }
        }

        public Color FillColor
        {
            get
            {
                return this.fillColor;
            }
            set
            {
                this.fillColor = value;
            }
        }

        public bool KeepSize
        {
            get
            {
                return this.keepSize;
            }
            set
            {
                this.keepSize = value;
            }
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
    }
}

