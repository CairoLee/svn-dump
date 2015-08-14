using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Media;
using System.Windows.Forms;
namespace a
{
	public class I
	{
		private Bitmap A;
		private ImageAttributes A = new ImageAttributes();
		private int A;
		private int a;
		private float A = 0.1f;
		public I(string text, float num) : this(text, num, 1f)
		{
		}
		public I(string text, float num, float num2) : this(text, num, num2, num2)
		{
		}
		public I(string filename, float num, float num2, float num3) : this(new Bitmap(filename), num, num2, num3)
		{
		}
		public I(string filename, float num, int num2, int num3) : this(new Bitmap(filename), num, num2, num3)
		{
		}
		public I(Bitmap bitmap, float num) : this(bitmap, num, 1f)
		{
		}
		public I(Bitmap bitmap, float num, float num2) : this(bitmap, num, num2, num2)
		{
		}
		public I(Bitmap bitmap, float num, float num2, float num3) : this(bitmap, num, (int)((float)bitmap.Width * num2), (int)((float)bitmap.Height * num2))
		{
		}
		public I(Bitmap bitmap, float num, int num2, int num3)
		{
			if (bitmap == null)
			{
				throw new l1();
			}
			this.A = bitmap;
			this.A = num2;
			this.a = num3;
			this.A(num);
		}
		~I()
		{
			this.A();
		}
		public void A()
		{
			if (this.A != null)
			{
				this.A.Dispose();
				this.A = null;
			}
		}
		public float A()
		{
			return this.A;
		}
		public void A(float num)
		{
			this.A = num;
			float[][] array = new float[5][];
			float[][] arg_20_0 = array;
			int arg_20_1 = 0;
			float[] array2 = new float[5];
			array2[0] = 1f;
			arg_20_0[arg_20_1] = array2;
			float[][] arg_36_0 = array;
			int arg_36_1 = 1;
			float[] array3 = new float[5];
			array3[1] = 1f;
			arg_36_0[arg_36_1] = array3;
			float[][] arg_4C_0 = array;
			int arg_4C_1 = 2;
			float[] array4 = new float[5];
			array4[2] = 1f;
			arg_4C_0[arg_4C_1] = array4;
			float[][] arg_63_0 = array;
			int arg_63_1 = 3;
			float[] array5 = new float[5];
			array5[3] = this.A;
			arg_63_0[arg_63_1] = array5;
			array[4] = new float[]
			{
				0f,
				0f,
				0f,
				0f,
				1f
			};
			float[][] newColorMatrix = array;
			ColorMatrix newColorMatrix2 = new ColorMatrix(newColorMatrix);
			this.A.SetColorMatrix(newColorMatrix2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
		}
		public int A()
		{
			return this.A;
		}
		public int a()
		{
			return this.a;
		}
		public Rectangle A()
		{
			return new Rectangle(0, 0, this.A, this.a);
		}
		public void A(Graphics graphics, Point pos)
		{
			Rectangle destRect = this.A();
			destRect.Offset(pos);
			graphics.DrawImage(this.A, destRect, 0, 0, this.A.Width, this.A.Height, GraphicsUnit.Pixel, this.A);
		}
	}
	public abstract class i
	{
		protected e2 A;
		protected KeyEventArgs A;
		protected Point A;
		protected Point a;
		protected Point B;
		protected bool A;
		public i(e2 e) : this(e, null)
		{
		}
		public i(e2 e, KeyEventArgs keyEventArgs)
		{
			this.A = e;
			this.A = keyEventArgs;
			this.F(Point.Empty);
		}
		public virtual void A(bool flag)
		{
			this.A.l();
		}
		protected void F(Point b)
		{
			this.A = b;
			this.a = b;
			this.B = b;
		}
		public static bool F(Point point, Point point2)
		{
			int num = 2;
			return Math.Abs(point2.X - point.X) >= num || Math.Abs(point2.Y - point.Y) >= num;
		}
		public virtual void a(KeyEventArgs keyEventArgs)
		{
			this.A = keyEventArgs;
			if (this.A != null)
			{
				this.B();
			}
		}
		public virtual bool B()
		{
			if (this.A != null)
			{
				if (this.A.KeyCode == Keys.Escape)
				{
					this.A(false);
					return true;
				}
				if (this.A.Modifiers == Keys.None)
				{
					SystemSounds.Exclamation.Play();
				}
			}
			return false;
		}
		public virtual void b()
		{
			this.A = null;
			this.B();
		}
		public virtual void C(MouseEventArgs mouseEventArgs)
		{
			if (this.A != null && this.A.Control)
			{
				int num = 120;
				int num2 = 5;
				e2 expr_20 = this.A;
				expr_20.L(expr_20.L() + mouseEventArgs.Delta * num2 / num);
				this.A.C();
				return;
			}
			if (this.A != null && this.A.Shift)
			{
				this.A.AutoScrollPosition = new Point(-mouseEventArgs.Delta / 2 - this.A.AutoScrollPosition.X, -this.A.AutoScrollPosition.Y);
				this.A.C();
				return;
			}
			this.A.AutoScrollPosition = new Point(-this.A.AutoScrollPosition.X, -mouseEventArgs.Delta / 2 - this.A.AutoScrollPosition.Y);
			this.A.C();
		}
		public virtual void c(MouseEventArgs mouseEventArgs)
		{
			this.A = false;
			this.F(new Point(mouseEventArgs.X, mouseEventArgs.Y));
		}
		public virtual void D(MouseEventArgs mouseEventArgs)
		{
			this.a = this.B;
			this.B = new Point(mouseEventArgs.X, mouseEventArgs.Y);
			if (!this.A && this.a != this.B)
			{
				this.A = true;
			}
		}
		public virtual void d(MouseEventArgs mouseEventArgs)
		{
			this.A(true);
		}
		public virtual void E()
		{
			Type type = (this.A.L() != null) ? this.A.L().A() : null;
			Type type2 = (this.A.L() is z) ? ((z)this.A.L()).a() : null;
			if (type != null && type != type2)
			{
				this.A.l(false);
				this.A.L(new z(this.A, type));
			}
		}
		public virtual void e()
		{
		}
	}
}
