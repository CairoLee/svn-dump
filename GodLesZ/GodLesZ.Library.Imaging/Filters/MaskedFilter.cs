namespace GodLesZ.Library.Imaging.Filters
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class MaskedFilter : IFilter
    {
        private IFilter filter1;
        private IFilter filter2;
        private Bitmap mask;

        public MaskedFilter()
        {
        }

        public MaskedFilter(Bitmap mask, IFilter filter1)
        {
            this.mask = mask;
            this.filter1 = filter1;
        }

        public MaskedFilter(Bitmap mask, IFilter filter1, IFilter filter2)
        {
            this.mask = mask;
            this.filter1 = filter1;
            this.filter2 = filter2;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int width = this.mask.Width;
            int height = this.mask.Height;
            if ((width != srcImg.Width) || (height != srcImg.Height))
            {
                throw new ArgumentException();
            }
            Bitmap img = this.filter1.Apply(srcImg);
            bool flag = false;
            if ((width != img.Width) || (height != img.Height))
            {
                img.Dispose();
                throw new ApplicationException();
            }
            if (this.filter2 != null)
            {
                srcImg = this.filter2.Apply(srcImg);
                flag = true;
                if ((width != srcImg.Width) || (height != srcImg.Height))
                {
                    srcImg.Dispose();
                    img.Dispose();
                    throw new ApplicationException();
                }
            }
            if (img.PixelFormat != srcImg.PixelFormat)
            {
                IFilter filter = new GrayscaleToRGB();
                if (img.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    Bitmap bitmap2 = filter.Apply(img);
                    img.Dispose();
                    img = bitmap2;
                }
                if (srcImg.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    Bitmap bitmap3 = filter.Apply(srcImg);
                    if (flag)
                    {
                        srcImg.Dispose();
                    }
                    srcImg = bitmap3;
                    flag = true;
                }
            }
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, srcImg.PixelFormat);
            BitmapData data2 = img.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, img.PixelFormat);
            BitmapData data3 = this.mask.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, this.mask.PixelFormat);
            int num3 = data2.Stride - ((img.PixelFormat == PixelFormat.Format8bppIndexed) ? width : (width * 3));
            int num4 = data3.Stride - ((this.mask.PixelFormat == PixelFormat.Format8bppIndexed) ? width : (width * 3));
            int num5 = (this.mask.PixelFormat == PixelFormat.Format8bppIndexed) ? 1 : 3;
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            byte* numPtr3 = (byte*) data3.Scan0.ToPointer();
            if (img.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                for (int i = 0; i < height; i++)
                {
                    int num7 = 0;
                    while (num7 < width)
                    {
                        if (numPtr3[0] != 0)
                        {
                            numPtr2[0] = numPtr[0];
                        }
                        num7++;
                        numPtr++;
                        numPtr2++;
                        numPtr3 += num5;
                    }
                    numPtr += num3;
                    numPtr2 += num3;
                    numPtr3 += num4;
                }
            }
            else
            {
                for (int j = 0; j < height; j++)
                {
                    int num9 = 0;
                    while (num9 < width)
                    {
                        if (numPtr3[0] != 0)
                        {
                            numPtr2[2] = numPtr[2];
                            numPtr2[1] = numPtr[1];
                            numPtr2[0] = numPtr[0];
                        }
                        num9++;
                        numPtr += 3;
                        numPtr2 += 3;
                        numPtr3 += num5;
                    }
                    numPtr += num3;
                    numPtr2 += num3;
                    numPtr3 += num4;
                }
            }
            img.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            this.mask.UnlockBits(data3);
            if (flag)
            {
                srcImg.Dispose();
            }
            return img;
        }

        public IFilter Filter1
        {
            get
            {
                return this.filter1;
            }
            set
            {
                this.filter1 = value;
            }
        }

        public IFilter Filter2
        {
            get
            {
                return this.filter2;
            }
            set
            {
                this.filter2 = value;
            }
        }

        public Bitmap Mask
        {
            get
            {
                return this.mask;
            }
            set
            {
                this.mask = value;
            }
        }
    }
}

