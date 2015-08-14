namespace GodLesZ.Library.Imaging.Filters
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class ReplaceChannel : IFilter
    {
        private short channel;
        private Bitmap channelImage;

        public ReplaceChannel()
        {
            this.channel = 2;
        }

        public ReplaceChannel(Bitmap channelImage)
        {
            this.channel = 2;
            if (channelImage.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                throw new ArgumentException();
            }
            this.channelImage = channelImage;
        }

        public ReplaceChannel(short channel)
        {
            this.channel = 2;
            this.channel = channel;
        }

        public ReplaceChannel(Bitmap channelImage, short channel) : this(channelImage)
        {
            this.channel = channel;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int width = srcImg.Width;
            int height = srcImg.Height;
            int num3 = this.channelImage.Width;
            int num4 = this.channelImage.Height;
            if (((srcImg.PixelFormat != PixelFormat.Format24bppRgb) || (width != num3)) || (height != num4))
            {
                throw new ArgumentException();
            }
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData data3 = this.channelImage.LockBits(new Rectangle(0, 0, num3, num4), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            int num5 = bitmapdata.Stride - (width * 3);
            int num6 = data3.Stride - width;
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            byte* numPtr3 = (byte*) data3.Scan0.ToPointer();
            for (int i = 0; i < height; i++)
            {
                int num8 = 0;
                while (num8 < width)
                {
                    numPtr2[2] = numPtr[2];
                    numPtr2[1] = numPtr[1];
                    numPtr2[0] = numPtr[0];
                    numPtr2[this.channel] = numPtr3[0];
                    num8++;
                    numPtr += 3;
                    numPtr2 += 3;
                    numPtr3++;
                }
                numPtr += num5;
                numPtr2 += num5;
                numPtr3 += num6;
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            this.channelImage.UnlockBits(data3);
            return bitmap;
        }

        public short Channel
        {
            get
            {
                return this.channel;
            }
            set
            {
                this.channel = value;
            }
        }

        public Bitmap ChannelImage
        {
            get
            {
                return this.channelImage;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException();
                }
                if (value.PixelFormat != PixelFormat.Format8bppIndexed)
                {
                    throw new ArgumentException();
                }
                this.channelImage = value;
            }
        }
    }
}

