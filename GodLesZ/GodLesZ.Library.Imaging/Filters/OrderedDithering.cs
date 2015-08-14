namespace GodLesZ.Library.Imaging.Filters
{
	using System.Drawing;
    using System.Drawing.Imaging;

    public class OrderedDithering : IFilter
    {
        private int cols;
        private byte[,] matrix;
        private int rows;

        public OrderedDithering()
        {
            this.rows = 4;
            this.cols = 4;
            this.matrix = new byte[,] { { 15, 0x8f, 0x2f, 0xaf }, { 0xcf, 0x4f, 0xef, 0x6f }, { 0x3f, 0xbf, 0x1f, 0x9f }, { 0xff, 0x7f, 0xdf, 0x5f } };
        }

        public OrderedDithering(byte[,] matrix)
        {
            this.rows = 4;
            this.cols = 4;
            this.matrix = new byte[,] { { 15, 0x8f, 0x2f, 0xaf }, { 0xcf, 0x4f, 0xef, 0x6f }, { 0x3f, 0xbf, 0x1f, 0x9f }, { 0xff, 0x7f, 0xdf, 0x5f } };
            this.rows = matrix.GetLength(0);
            this.cols = matrix.GetLength(1);
            this.matrix = matrix;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            byte num5;
            int width = srcImg.Width;
            int height = srcImg.Height;
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            int num3 = bitmapdata.Stride - ((format == PixelFormat.Format8bppIndexed) ? width : (width * 3));
            int num4 = data2.Stride - width;
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            if (format == PixelFormat.Format8bppIndexed)
            {
                for (int i = 0; i < height; i++)
                {
                    int num7 = 0;
                    while (num7 < width)
                    {
                        num5 = this.matrix[i % this.rows, num7 % this.cols];
                        numPtr2[0] = (numPtr[0] <= num5) ? ((byte) 0) : ((byte) 0xff);
                        num7++;
                        numPtr++;
                        numPtr2++;
                    }
                    numPtr += num3;
                    numPtr2 += num4;
                }
            }
            else
            {
                for (int j = 0; j < height; j++)
                {
                    int num10 = 0;
                    while (num10 < width)
                    {
                        byte num8 = (byte) (((0.2125f * numPtr[2]) + (0.7154f * numPtr[1])) + (0.0721f * numPtr[0]));
                        num5 = this.matrix[j % this.rows, num10 % this.cols];
                        numPtr2[0] = (num8 <= num5) ? ((byte) 0) : ((byte) 0xff);
                        num10++;
                        numPtr += 3;
                        numPtr2++;
                    }
                    numPtr += num3;
                    numPtr2 += num4;
                }
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }
    }
}

