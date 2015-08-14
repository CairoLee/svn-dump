namespace GodLesZ.Library.Imaging.Filters {

	public sealed class FloydSteinbergDithering : ErrorDiffusionDithering
    {
        private static int[] coef = new int[] { 3, 5, 1 };

        protected override unsafe void Diffuse(int error, byte* ptr)
        {
            int num;
            if (base.x != base.widthM1)
            {
                num = ptr[1] + ((error * 7) / 0x10);
                num = (num < 0) ? 0 : ((num > 0xff) ? 0xff : num);
                ptr[1] = (byte) num;
            }
            if (base.y != base.heightM1)
            {
                ptr += base.stride;
                int index = -1;
                for (int i = 0; index <= 1; i++)
                {
                    if (((base.x + index) >= 0) && ((base.x + index) < base.width))
                    {
                        num = ptr[index] + ((error * coef[i]) / 0x10);
                        num = (num < 0) ? 0 : ((num > 0xff) ? 0xff : num);
                        ptr[index] = (byte) num;
                    }
                    index++;
                }
            }
        }
    }
}

