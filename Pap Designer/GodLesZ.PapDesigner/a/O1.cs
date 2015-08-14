using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace a
{
	internal class O1
	{
		public static void A(p1 p)
		{
			s1 s = p.f();
			try
			{
				O1.A(s);
			}
			finally
			{
				s.Dispose();
			}
		}
		private static void A(s1 s)
		{
			bool flag = true;
			Rectangle rectangle2;
			bool flag2;
			bool flag3;
			using (a2 a = new a2())
			{
				Rectangle rectangle = s.G(flag);
				float num = 1.5f;
				a.A(new Size((int)((float)rectangle.Width * num), (int)((float)rectangle.Height * num)));
				a.A(false);
				if (a.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				rectangle2 = new Rectangle(0, 0, a.A().Width, a.A().Height);
				flag2 = a.A();
				flag3 = a.a();
			}
			object[][] array = new object[][]
			{
				new object[]
				{
					ImageFormat.Png,
					"Portable Network Graphics (*.png)",
					"*.png"
				},
				new object[]
				{
					ImageFormat.Bmp,
					"Bitmap (*.bmp)",
					"*.bmp"
				},
				new object[]
				{
					ImageFormat.Tiff,
					"Tag Image File (*.tif)",
					"*.tif"
				},
				new object[]
				{
					ImageFormat.Jpeg,
					"Joint Photographic Experts Group (*.jpg)",
					"*.jpg"
				}
			};
			if (flag2)
			{
				array = new object[][]
				{
					array[0],
					array[2]
				};
			}
			string text = "";
			object[][] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				object[] array3 = array2[i];
				if (text.Length > 0)
				{
					text += "|";
				}
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"",
					array3[1],
					"|",
					array3[2]
				});
			}
			int num2 = 0;
			string text2 = y1.A(s.A().b(), 64);
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = text;
				saveFileDialog.FilterIndex = num2 + 1;
				saveFileDialog.RestoreDirectory = true;
				saveFileDialog.InitialDirectory = K1.A().A().RecentPicturePath;
				saveFileDialog.FileName = text2;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					num2 = saveFileDialog.FilterIndex - 1;
					text2 = saveFileDialog.FileName;
					K1.A().A().RecentPicturePath = Path.GetDirectoryName(saveFileDialog.FileName);
				}
			}
			Bitmap bitmap = new Bitmap(rectangle2.Width, rectangle2.Height);
			Color white = Color.White;
			Graphics graphics = Graphics.FromImage(bitmap);
			if (!flag2)
			{
				graphics.FillRectangle(new SolidBrush(white), graphics.ClipBounds);
			}
			B1 b = s.A().G(s, graphics, a1.Picture, flag2);
			s.H(rectangle2, 0f, b);
			bitmap.Save(text2, (ImageFormat)array[num2][0]);
			if (flag3)
			{
				try
				{
					Process.Start(text2);
				}
				catch (Exception)
				{
				}
			}
		}
	}
	public class o1
	{
		private string A;
		protected o1()
		{
		}
		protected o1(string text)
		{
			this.b(text);
		}
		public string b()
		{
			return this.A;
		}
		public void b(string text)
		{
			if (!this.a(text))
			{
				throw new ArgumentException("Name '" + text + "' is not acceptable");
			}
		}
		public virtual bool A(string text)
		{
			return !(text == this.b()) && this.B(text);
		}
		public virtual bool a(string text)
		{
			if (!this.A(text))
			{
				return false;
			}
			this.A = text;
			n1.B();
			return true;
		}
		public static string b(string input)
		{
			Regex regex = new Regex("\\s+");
			return regex.Replace(input, " ").Trim();
		}
		public virtual bool B(string text)
		{
			return o1.b(text);
		}
		public static bool b(string text)
		{
			return !string.IsNullOrEmpty(text) && o1.b(text) == text;
		}
	}
}
