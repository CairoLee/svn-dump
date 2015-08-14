namespace GodLesZ.Library.Imaging.Filters
{
    using System;

    public class Convolution : Correlation
    {
        public Convolution(int[,] kernel)
        {
            int length = kernel.GetLength(0);
            if (((length != kernel.GetLength(1)) || (length < 3)) || ((length > 0x19) || ((length % 2) == 0)))
            {
                throw new ArgumentException();
            }
            base.kernel = new int[length, length];
            base.size = length;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    base.kernel[i, j] = kernel[(length - i) - 1, (length - j) - 1];
                }
            }
        }
    }
}

