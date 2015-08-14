using System;
using System.Collections;

namespace GodLesZ.Library.Amf.Json {
	public class JsonConverterCollection : CollectionBase {
		public JsonConverterCollection() {
		}

		public JsonConverterCollection(JsonConverterCollection collection) {
			this.InnerList.AddRange(collection);
		}

		public JsonConverter this[int index] {
			get { return (JsonConverter)List[index]; }
			set { List[index] = value; }
		}

		public virtual void Add(JsonConverter converter) {
			List.Add(converter);
		}

		public virtual void Remove(JsonConverter converter) {
			List.Remove(converter);
		}

		public bool Contains(JsonConverter converter) {
			return List.Contains(converter);
		}

		public int IndexOf(JsonConverter converter) {
			return List.IndexOf(converter);
		}

		protected override void OnValidate(object value) {
			base.OnValidate(value);
			if (!(value is JsonConverter)) {
				throw new ArgumentException("JsonConverterCollection only supports JsonConverter objects.");
			}
		}
	}
}
