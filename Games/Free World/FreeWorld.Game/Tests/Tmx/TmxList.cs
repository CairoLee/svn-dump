using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FreeWorld.Game.Tests.Tmx {

	public class TmxList<T> : KeyedCollection<string, T> where T : ITmxElement {
		public static readonly Dictionary<Tuple<TmxList<T>, string>, int> NameCount = new Dictionary<Tuple<TmxList<T>, string>, int>();

		public new void Add(T t) {
			// Rename duplicate entries by appending a number
			var key = Tuple.Create(this, t.Name);
			if (Contains(t.Name))
				NameCount[key] += 1;
			else
				NameCount.Add(key, 0);
			base.Add(t);
		}

		protected override string GetKeyForItem(T t) {
			var key = Tuple.Create(this, t.Name);
			var count = NameCount[key];
			if (count == 0)
				return t.Name;
			
			return t.Name + count;
		}

	}

}