namespace GodLesZ.Library.Imaging {

	public class Interpolation
    {
        public static float BiCubicKernel(float x)
        {
            if (x > 2f)
            {
                return 0f;
            }
            float num5 = x - 1f;
            float num6 = x + 1f;
            float num7 = x + 2f;
            float num = (num7 <= 0f) ? 0f : ((num7 * num7) * num7);
            float num2 = (num6 <= 0f) ? 0f : ((num6 * num6) * num6);
            float num3 = (x <= 0f) ? 0f : ((x * x) * x);
            float num4 = (num5 <= 0f) ? 0f : ((num5 * num5) * num5);
            return (0.1666667f * (((num - (4f * num2)) + (6f * num3)) - (4f * num4)));
        }
    }
}

