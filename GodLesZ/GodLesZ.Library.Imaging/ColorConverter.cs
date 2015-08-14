namespace GodLesZ.Library.Imaging {
	using System;

	public class ColorConverter {
		public static void HSL2RGB(HSL hsl, RGB rgb) {
			if (hsl.Saturation == 0.0) {
				rgb.Red = rgb.Green = rgb.Blue = (byte)(hsl.Luminance * 255.0);
			} else {
				double vH = ((double)hsl.Hue) / 360.0;
				double num2 = (hsl.Luminance < 0.5) ? (hsl.Luminance * (1.0 + hsl.Saturation)) : ((hsl.Luminance + hsl.Saturation) - (hsl.Luminance * hsl.Saturation));
				double num = (2.0 * hsl.Luminance) - num2;
				rgb.Red = (byte)(255.0 * Hue2RGB(num, num2, vH + 0.33333333333333331));
				rgb.Green = (byte)(255.0 * Hue2RGB(num, num2, vH));
				rgb.Blue = (byte)(255.0 * Hue2RGB(num, num2, vH - 0.33333333333333331));
			}
		}

		private static double Hue2RGB(double v1, double v2, double vH) {
			if (vH < 0.0) {
				vH++;
			}
			if (vH > 1.0) {
				vH--;
			}
			if ((6.0 * vH) < 1.0) {
				return (v1 + (((v2 - v1) * 6.0) * vH));
			}
			if ((2.0 * vH) < 1.0) {
				return v2;
			}
			if ((3.0 * vH) < 2.0) {
				return (v1 + (((v2 - v1) * (0.66666666666666663 - vH)) * 6.0));
			}
			return v1;
		}

		public static void RGB2HSL(RGB rgb, HSL hsl) {
			double num = ((double)rgb.Red) / 255.0;
			double num2 = ((double)rgb.Green) / 255.0;
			double num3 = ((double)rgb.Blue) / 255.0;
			double num4 = Math.Min(Math.Min(num, num2), num3);
			double num5 = Math.Max(Math.Max(num, num2), num3);
			double num6 = num5 - num4;
			hsl.Luminance = (num5 + num4) / 2.0;
			if (num6 == 0.0) {
				hsl.Hue = 0;
				hsl.Saturation = 0.0;
			} else {
				double num10;
				hsl.Saturation = (hsl.Luminance < 0.5) ? (num6 / (num5 + num4)) : (num6 / ((2.0 - num5) - num4));
				double num7 = (((num5 - num) / 6.0) + (num6 / 2.0)) / num6;
				double num8 = (((num5 - num2) / 6.0) + (num6 / 2.0)) / num6;
				double num9 = (((num5 - num3) / 6.0) + (num6 / 2.0)) / num6;
				if (num == num5) {
					num10 = num9 - num8;
				} else if (num2 == num5) {
					num10 = (0.33333333333333331 + num7) - num9;
				} else {
					num10 = (0.66666666666666663 + num8) - num7;
				}
				if (num10 < 0.0) {
					num10++;
				}
				if (num10 > 1.0) {
					num10--;
				}
				hsl.Hue = (int)(num10 * 360.0);
			}
		}
	}
}

