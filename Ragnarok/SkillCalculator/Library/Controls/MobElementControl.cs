using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GodLesZ.Ragnarok.SkillCalculator.Library.Controls {

	public class MobElementControl : PictureBox {
		private EElement mElement = default(EElement);
		private int mElementLevel = 1;

		public EElement Element {
			get { return mElement; }
			set {
				mElement = value;
				UpdateImage();
			}
		}

		public int ElementLevel {
			get { return mElementLevel; }
			set {
				mElementLevel = value;
				UpdateImage();
			}
		}


		public MobElementControl()
			: base() {
			Size = new Size(24, 24);
			BackColor = Color.Transparent;
			SizeMode = PictureBoxSizeMode.CenterImage;
		}


		private void UpdateImage() {
			using (Bitmap bmp = new Bitmap(Size.Width, Size.Height)) {
				using (Graphics g = Graphics.FromImage(bmp)) {
					Color c = Color.Black;
					switch (Element) {
						case EElement.Dark:
							c = Color.DarkGray;
							break;
						case EElement.Earth:
							c = Color.Brown;
							break;
						case EElement.Fire:
							c = Color.Red;
							break;
						case EElement.Ghost:
							c = Color.Gray;
							break;
						case EElement.Holy:
							c = Color.LightYellow;
							break;
						case EElement.Poison:
							c = Color.Purple;
							break;
						case EElement.Undead:
							c = Color.DarkOliveGreen;
							break;
						case EElement.Water:
							c = Color.Blue;
							break;
						case EElement.Wind:
							c = Color.Yellow;
							break;

						default:
						case EElement.Neutral:
						case EElement.SkillUseEndowElement:
						case EElement.SkillUseRandomElement:
						case EElement.SkillUseWeaponElement:
							c = Color.LightSlateGray;
							break;
					}

					Size circleSize = new Size(bmp.Width - 2, bmp.Height - 2);
					Point circlePadding = new Point(1, 1);
					SizeF stringSize = g.MeasureString(ElementLevel.ToString(), DefaultFont);
					PointF stringPos = new PointF(((float)circleSize.Width / 2f) - (stringSize.Width / 2) + ((float)circlePadding.X / 2f), ((float)circleSize.Height / 2f) - (stringSize.Height / 2) + ((float)circlePadding.Y / 2f));

					g.FillEllipse(new SolidBrush(c), new Rectangle(circlePadding, circleSize));
					g.DrawString(ElementLevel.ToString(), DefaultFont, new SolidBrush(DefaultForeColor), stringPos);
				}

				Image = bmp.Clone() as Image;
			}
		}

	}

}
