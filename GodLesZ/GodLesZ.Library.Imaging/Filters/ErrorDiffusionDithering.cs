namespace GodLesZ.Library.Imaging.Filters
{
	using System.Drawing;
    using System.Drawing.Imaging;

    public abstract class ErrorDiffusionDithering : IFilter
    {
        protected int height;
        protected int heightM1;
        protected int stride;
        protected int width;
        protected int widthM1;
        protected int x;
        protected int y;

        protected ErrorDiffusionDithering()
        {
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            Bitmap bitmap;
            this.width = srcImg.Width;
            this.height = srcImg.Height;
            if (srcImg.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                bitmap = GodLesZ.Library.Imaging.Image.Clone(srcImg);
            }
            else
            {
                IFilter filter = new GrayscaleRMY();
                bitmap = filter.Apply(srcImg);
            }
            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, this.width, this.height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            Bitmap bitmap2 = GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(this.width, this.height);
            BitmapData data2 = bitmap2.LockBits(new Rectangle(0, 0, this.width, this.height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            this.stride = data2.Stride;
            this.widthM1 = this.width - 1;
            this.heightM1 = this.height - 1;
            int num = this.stride - this.width;
            byte* ptr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            this.y = 0;
            while (this.y < this.height)
            {
                this.x = 0;
                while (this.x < this.width)
                {
                    int num3;
                    int num2 = ptr[0];
                    if (num2 < 0x80)
                    {
                        numPtr2[0] = 0;
                        num3 = num2;
                    }
                    else
                    {
                        numPtr2[0] = 0xff;
                        num3 = num2 - 0xff;
                    }
                    this.Diffuse(num3, ptr);
                    this.x++;
                    ptr++;
                    numPtr2++;
                }
                ptr += num;
                numPtr2 += num;
                this.y++;
            }
            bitmap2.UnlockBits(data2);
            bitmap.UnlockBits(bitmapdata);
            bitmap.Dispose();
            return bitmap2;
        }

        protected abstract unsafe void Diffuse(int error, byte* ptr);
    }
}

