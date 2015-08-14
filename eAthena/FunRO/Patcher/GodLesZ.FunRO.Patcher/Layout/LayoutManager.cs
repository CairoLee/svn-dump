using System;
using System.Drawing;
using System.Reflection;

namespace GodLesZ.FunRO.Patcher {

	internal static class LayoutManager {

		private static ELayout mLayout = ELayout.Default;
		private static global::System.Resources.ResourceManager mResourceMan = null;

		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static global::System.Resources.ResourceManager ResourceManager {
			get {
				if (object.ReferenceEquals(mResourceMan, null)) {
					Type t = mLayout.GetType();
					Assembly asm = t.Assembly;
					global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GodLesZ.FunRO.Patcher.Layout.Resources." + mLayout, asm);
					mResourceMan = temp;
				}

				return mResourceMan;
			}
		}

		internal static ELayout Layout {
			get { return mLayout; }
			set {
				mLayout = value;
				mResourceMan = null;
			}
		}


		public static Bitmap GetImage(string name) {
			return ResourceManager.GetObject(name) as Bitmap;
		}

	}

}
