
using System;

namespace GodLesZ.Library.Amf.Json {
	public abstract class JsonConverter {
		public virtual void WriteJson(JsonWriter writer, object value) {
			JsonSerializer serializer = new JsonSerializer();

			serializer.Serialize(writer, value);
		}

		public virtual object ReadJson(JsonReader reader, Type objectType) {
			throw new NotImplementedException(string.Format("{0} has not overriden FromJson method.", GetType().Name));
		}

		public abstract bool CanConvert(Type objectType);
	}
}
