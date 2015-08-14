namespace GodLesZ.Library.Imaging.Filters {

	public class StevensonArceDithering : ErrorDiffusionDithering
    {
        private static int[] coef1 = new int[] { 12, 0x1a, 30, 0x10 };
        private static int[] coef2 = new int[] { 12, 0x1a, 12 };
        private static int[] coef3 = new int[] { 5, 12, 12, 5 };

        protected override unsafe void Diffuse(int error, byte* ptr)
        {
            int num;
            if (base.x < (base.widthM1 - 1))
            {
                num = ptr[2] + ((error * 0x20) / 200);
                num = (num < 0) ? 0 : ((num > 0xff) ? 0xff : num);
                ptr[2] = (byte) num;
            }
            if (base.y < base.heightM1)
            {
                ptr += base.stride;
                int index = -3;
                for (int i = 0; index <= 3; i++)
                {
                    if (((base.x + index) >= 0) && ((base.x + index) < base.width))
                    {
                        num = ptr[index] + ((error * coef1[i]) / 200);
                        num = (num < 0) ? 0 : ((num > 0xff) ? 0xff : num);
                        ptr[index] = (byte) num;
                    }
                    index += 2;
                }
            }
            if (base.y < (base.heightM1 - 1))
            {
                ptr += base.stride;
                int num4 = -2;
                for (int j = 0; num4 <= 2; j++)
                {
                    if (((base.x + num4) >= 0) && ((base.x + num4) < base.width))
                    {
                        num = ptr[num4] + ((error * coef2[j]) / 200);
                        num = (num < 0) ? 0 : ((num > 0xff) ? 0xff : num);
                        ptr[num4] = (byte) num;
                    }
                    num4 += 2;
                }
            }
            if (base.y < (base.heightM1 - 2))
            {
                ptr += base.stride;
                int num6 = -3;
                for (int k = 0; num6 <= 3; k++)
                {
                    if (((base.x + num6) >= 0) && ((base.x + num6) < base.width))
                    {
                        num = ptr[num6] + ((error * coef3[k]) / 200);
                        num = (num < 0) ? 0 : ((num > 0xff) ? 0xff : num);
                        ptr[num6] = (byte) num;
                    }
                    num6 += 2;
                }
            }
        }
    }
}

