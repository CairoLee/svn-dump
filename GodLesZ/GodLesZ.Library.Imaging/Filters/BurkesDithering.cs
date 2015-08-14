namespace GodLesZ.Library.Imaging.Filters {

	public sealed class BurkesDithering : ErrorDiffusionDithering
    {
        private static int[] coef = new int[] { 2, 4, 8, 4, 2 };

        protected override unsafe void Diffuse(int error, byte* ptr)
        {
            int num;
            if (base.x < base.widthM1)
            {
                num = ptr[1] + ((error * 8) / 0x20);
                num = (num < 0) ? 0 : ((num > 0xff) ? 0xff : num);
                ptr[1] = (byte) num;
            }
            if (base.x < (base.widthM1 - 1))
            {
                num = ptr[2] + ((error * 4) / 0x20);
                num = (num < 0) ? 0 : ((num > 0xff) ? 0xff : num);
                ptr[2] = (byte) num;
            }
            if (base.y != base.heightM1)
            {
                ptr += base.stride;
                int index = -2;
                for (int i = 0; index <= 2; i++)
                {
                    if (((base.x + index) >= 0) && ((base.x + index) < base.width))
                    {
                        num = ptr[index] + ((error * coef[i]) / 0x20);
                        num = (num < 0) ? 0 : ((num > 0xff) ? 0xff : num);
                        ptr[index] = (byte) num;
                    }
                    index++;
                }
            }
        }
    }
}

