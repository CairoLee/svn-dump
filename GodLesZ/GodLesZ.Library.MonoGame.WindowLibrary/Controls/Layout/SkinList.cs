using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class SkinList<T> : List<T> {
		public T this[string index] {
			get {
				for (int i = 0; i < this.Count; i++) {
					SkinBase s = (SkinBase)(object)this[i];
					if (s.Name.ToLower() == index.ToLower()) {
						return this[i];
					}
				}
				return default(T);
			}
			set {
				for (int i = 0; i < this.Count; i++) {
					SkinBase s = (SkinBase)(object)this[i];
					if (s.Name.ToLower() == index.ToLower()) {
						this[i] = value;
					}
				}
			}
		}

		public SkinList()
			: base() {
		}

		public SkinList(SkinList<T> source)
			: base() {
			for (int i = 0; i < source.Count; i++) {
				Type[] t = new Type[1];
				t[0] = typeof(T);

				object[] p = new object[1];
				p[0] = source[i];

				this.Add((T)t[0].GetConstructor(t).Invoke(p));
			}
		}

	}

}
