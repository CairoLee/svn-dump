namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging;

    public class Crop : IFilter
    {
        private System.Drawing.Rectangle rect;

        public Crop()
        {
            this.rect = new System.Drawing.Rectangle(0, 0, 100, 100);
        }

        public Crop(System.Drawing.Rectangle rect)
        {
            this.rect = rect;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int width = srcImg.Width;
            int height = srcImg.Height;
            int num3 = Math.Max(0, Math.Min(width - 1, this.rect.Left));
            int num4 = Math.Max(0, Math.Min(height - 1, this.rect.Top));
            int num5 = Math.Min((int) (width - 1), (int) (((num3 + this.rect.Width) - 1) + ((this.rect.Left < 0) ? this.rect.Left : 0)));
            int num6 = Math.Min((int) (height - 1), (int) (((num4 + this.rect.Height) - 1) + ((this.rect.Top < 0) ? this.rect.Top : 0)));
            int num7 = (num5 - num3) + 1;
            int num8 = (num6 - num4) + 1;
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new System.Drawing.Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = (format == PixelFormat.Format8bppIndexed) ? GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(num7, num8) : new Bitmap(num7, num8, format);
            BitmapData data2 = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, num7, num8), ImageLockMode.ReadWrite, format);
            int stride = bitmapdata.Stride;
            int num10 = data2.Stride;
            int num11 = (format == PixelFormat.Format8bppIndexed) ? 1 : 3;
            int count = num7 * num11;
			byte* src = (byte*)(((byte*)bitmapdata.Scan0.ToPointer() + (num4 * stride)) + (num3 * num11));
            byte* dst = (byte*) data2.Scan0.ToPointer();
            for (int i = num4; i <= num6; i++)
            {
                Win32.memcpy(dst, src, count);
                src += stride;
                dst += num10;
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }

        public System.Drawing.Rectangle Rectangle
        {
            get
            {
                return this.rect;
            }
            set
            {
                this.rect = value;
            }
        }
    }
}

