namespace GodLesZ.Library.Imaging
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class BlobCounter
    {
        private int[] objectLabels;
        private int objectsCount;

        public static Rectangle[] GetObjectRectangles(Bitmap srcImg)
        {
            BlobCounter counter = new BlobCounter();
            counter.ProcessImage(srcImg);
            int[] objectLabels = counter.ObjectLabels;
            int objectsCount = counter.ObjectsCount;
            int width = srcImg.Width;
            int height = srcImg.Height;
            int index = 0;
            int[] numArray2 = new int[objectsCount + 1];
            int[] numArray3 = new int[objectsCount + 1];
            int[] numArray4 = new int[objectsCount + 1];
            int[] numArray5 = new int[objectsCount + 1];
            for (int i = 1; i <= objectsCount; i++)
            {
                numArray2[i] = width;
                numArray3[i] = height;
            }
            for (int j = 0; j < height; j++)
            {
                int num8 = 0;
                while (num8 < width)
                {
                    int num5 = objectLabels[index];
                    if (num5 != 0)
                    {
                        if (num8 < numArray2[num5])
                        {
                            numArray2[num5] = num8;
                        }
                        if (num8 > numArray4[num5])
                        {
                            numArray4[num5] = num8;
                        }
                        if (j < numArray3[num5])
                        {
                            numArray3[num5] = j;
                        }
                        if (j > numArray5[num5])
                        {
                            numArray5[num5] = j;
                        }
                    }
                    num8++;
                    index++;
                }
            }
            Rectangle[] rectangleArray = new Rectangle[objectsCount];
            for (int k = 1; k <= objectsCount; k++)
            {
                rectangleArray[k - 1] = new Rectangle(numArray2[k], numArray3[k], (numArray4[k] - numArray2[k]) + 1, (numArray5[k] - numArray3[k]) + 1);
            }
            return rectangleArray;
        }

        public static unsafe Blob[] GetObjects(Bitmap srcImg)
        {
            BlobCounter counter = new BlobCounter();
            counter.ProcessImage(srcImg);
            int[] objectLabels = counter.ObjectLabels;
            int objectsCount = counter.ObjectsCount;
            int width = srcImg.Width;
            int height = srcImg.Height;
            int index = 0;
            int[] numArray2 = new int[objectsCount + 1];
            int[] numArray3 = new int[objectsCount + 1];
            int[] numArray4 = new int[objectsCount + 1];
            int[] numArray5 = new int[objectsCount + 1];
            for (int i = 1; i <= objectsCount; i++)
            {
                numArray2[i] = width;
                numArray3[i] = height;
            }
            for (int j = 0; j < height; j++)
            {
                int num8 = 0;
                while (num8 < width)
                {
                    int num5 = objectLabels[index];
                    if (num5 != 0)
                    {
                        if (num8 < numArray2[num5])
                        {
                            numArray2[num5] = num8;
                        }
                        if (num8 > numArray4[num5])
                        {
                            numArray4[num5] = num8;
                        }
                        if (j < numArray3[num5])
                        {
                            numArray3[num5] = j;
                        }
                        if (j > numArray5[num5])
                        {
                            numArray5[num5] = j;
                        }
                    }
                    num8++;
                    index++;
                }
            }
            Blob[] blobArray = new Blob[objectsCount];
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            int stride = bitmapdata.Stride;
            for (int k = 1; k <= objectsCount; k++)
            {
                int x = numArray2[k];
                int num12 = numArray4[k];
                int y = numArray3[k];
                int num14 = numArray5[k];
                int num15 = (num12 - x) + 1;
                int num16 = (num14 - y) + 1;
                Bitmap image = GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(num15, num16);
                BitmapData data2 = image.LockBits(new Rectangle(0, 0, num15, num16), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
				byte* numPtr = (byte*)(((byte*)bitmapdata.Scan0.ToPointer() + (y * stride)) + x);
                byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
                int num17 = (y * width) + x;
                int num18 = stride - num15;
                int num19 = data2.Stride - num15;
                int num20 = width - num15;
                for (int m = y; m <= num14; m++)
                {
                    int num22 = x;
                    while (num22 <= num12)
                    {
                        if (objectLabels[num17] == k)
                        {
                            numPtr2[0] = numPtr[0];
                        }
                        num22++;
                        numPtr++;
                        numPtr2++;
                        num17++;
                    }
                    numPtr += num18;
                    numPtr2 += num19;
                    num17 += num20;
                }
                image.UnlockBits(data2);
                blobArray[k - 1] = new Blob(image, new Point(x, y), srcImg);
            }
            srcImg.UnlockBits(bitmapdata);
            return blobArray;
        }

        public unsafe void ProcessImage(Bitmap srcImg)
        {
            if (srcImg.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                throw new ArgumentException();
            }
            int width = srcImg.Width;
            int height = srcImg.Height;
            if (width == 1)
            {
                throw new ArgumentException("Too small image");
            }
            this.objectLabels = new int[width * height];
            int num3 = 0;
            int num4 = (((width / 2) + 1) * ((height / 2) + 1)) + 1;
            int[] numArray = new int[num4];
            for (int i = 0; i < num4; i++)
            {
                numArray[i] = i;
            }
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            int stride = bitmapdata.Stride;
            int num7 = stride - width;
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            int index = 0;
            if (numPtr[0] != 0)
            {
                this.objectLabels[index] = ++num3;
            }
            numPtr++;
            index++;
            int num9 = 1;
            while (num9 < width)
            {
                if (numPtr[0] != 0)
                {
                    if (numPtr[-1] != 0)
                    {
                        this.objectLabels[index] = this.objectLabels[index - 1];
                    }
                    else
                    {
                        this.objectLabels[index] = ++num3;
                    }
                }
                num9++;
                numPtr++;
                index++;
            }
            numPtr += num7;
            for (int j = 1; j < height; j++)
            {
                if (numPtr[0] != 0)
                {
                    if (numPtr[-stride] != 0)
                    {
                        this.objectLabels[index] = this.objectLabels[index - width];
                    }
                    else if (numPtr[1 - stride] != 0)
                    {
                        this.objectLabels[index] = this.objectLabels[(index + 1) - width];
                    }
                    else
                    {
                        this.objectLabels[index] = ++num3;
                    }
                }
                numPtr++;
                index++;
                int num11 = 1;
                while (num11 < (width - 1))
                {
                    if (numPtr[0] != 0)
                    {
                        if (numPtr[-1] != 0)
                        {
                            this.objectLabels[index] = this.objectLabels[index - 1];
                        }
                        else if (numPtr[-1 - stride] != 0)
                        {
                            this.objectLabels[index] = this.objectLabels[(index - 1) - width];
                        }
                        else if (numPtr[-stride] != 0)
                        {
                            this.objectLabels[index] = this.objectLabels[index - width];
                        }
                        if (numPtr[1 - stride] != 0)
                        {
                            if (this.objectLabels[index] == 0)
                            {
                                this.objectLabels[index] = this.objectLabels[(index + 1) - width];
                            }
                            else
                            {
                                int num12 = this.objectLabels[index];
                                int num13 = this.objectLabels[(index + 1) - width];
                                if ((num12 != num13) && (numArray[num12] != numArray[num13]))
                                {
                                    if (numArray[num12] == num12)
                                    {
                                        numArray[num12] = numArray[num13];
                                    }
                                    else if (numArray[num13] == num13)
                                    {
                                        numArray[num13] = numArray[num12];
                                    }
                                    else
                                    {
                                        numArray[numArray[num12]] = numArray[num13];
                                        numArray[num12] = numArray[num13];
                                    }
                                    for (int n = 1; n <= num3; n++)
                                    {
                                        if (numArray[n] != n)
                                        {
                                            int num15 = numArray[n];
                                            while (num15 != numArray[num15])
                                            {
                                                num15 = numArray[num15];
                                            }
                                            numArray[n] = num15;
                                        }
                                    }
                                }
                            }
                        }
                        if (this.objectLabels[index] == 0)
                        {
                            this.objectLabels[index] = ++num3;
                        }
                    }
                    num11++;
                    numPtr++;
                    index++;
                }
                if (numPtr[0] != 0)
                {
                    if (numPtr[-1] != 0)
                    {
                        this.objectLabels[index] = this.objectLabels[index - 1];
                    }
                    else if (numPtr[-1 - stride] != 0)
                    {
                        this.objectLabels[index] = this.objectLabels[(index - 1) - width];
                    }
                    else if (numPtr[-stride] != 0)
                    {
                        this.objectLabels[index] = this.objectLabels[index - width];
                    }
                    else
                    {
                        this.objectLabels[index] = ++num3;
                    }
                }
                numPtr++;
                index++;
                numPtr += num7;
            }
            srcImg.UnlockBits(bitmapdata);
            int[] numArray2 = new int[numArray.Length];
            this.objectsCount = 0;
            for (int k = 1; k <= num3; k++)
            {
                if (numArray[k] == k)
                {
                    numArray2[k] = ++this.objectsCount;
                }
            }
            for (int m = 1; m <= num3; m++)
            {
                if (numArray[m] != m)
                {
                    numArray2[m] = numArray2[numArray[m]];
                }
            }
            int num18 = 0;
            int length = this.objectLabels.Length;
            while (num18 < length)
            {
                this.objectLabels[num18] = numArray2[this.objectLabels[num18]];
                num18++;
            }
        }

        public int[] ObjectLabels
        {
            get
            {
                return this.objectLabels;
            }
        }

        public int ObjectsCount
        {
            get
            {
                return this.objectsCount;
            }
        }
    }
}

