namespace GodLesZ.Library.Imaging.Filters
{
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging;

    public class ConnectedComponentsLabeling : IFilter
    {
        private BlobCounter blobCounter = new BlobCounter();
        private static Color[] colorTable = new Color[] { 
            Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Violet, Color.Brown, Color.Olive, Color.Cyan, Color.Magenta, Color.Gold, Color.Indigo, Color.Ivory, Color.HotPink, Color.DarkRed, Color.DarkGreen, Color.DarkBlue, 
            Color.DarkSeaGreen, Color.Gray, Color.DarkKhaki, Color.DarkGray, Color.LimeGreen, Color.Tomato, Color.SteelBlue, Color.SkyBlue, Color.Silver, Color.Salmon, Color.SaddleBrown, Color.RosyBrown, Color.PowderBlue, Color.Plum, Color.PapayaWhip, Color.Orange
         };

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            this.blobCounter.ProcessImage(srcImg);
            int[] objectLabels = this.blobCounter.ObjectLabels;
            int width = srcImg.Width;
            int height = srcImg.Height;
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int num3 = bitmapdata.Stride - (width * 3);
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            int index = 0;
            for (int i = 0; i < height; i++)
            {
                int num6 = 0;
                while (num6 < width)
                {
                    if (objectLabels[index] != 0)
                    {
                        Color color = colorTable[(objectLabels[index] - 1) % colorTable.Length];
                        numPtr[2] = color.R;
                        numPtr[1] = color.G;
                        numPtr[0] = color.B;
                    }
                    num6++;
                    numPtr += 3;
                    index++;
                }
                numPtr += num3;
            }
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }

        public static Color[] ColorTable
        {
            get
            {
                return colorTable;
            }
            set
            {
                colorTable = value;
            }
        }

        public int ObjectCount
        {
            get
            {
                return this.blobCounter.ObjectsCount;
            }
        }
    }
}

