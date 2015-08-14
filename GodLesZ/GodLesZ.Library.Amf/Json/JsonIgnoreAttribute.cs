using System;

namespace GodLesZ.Library.Amf.Json {
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
	public sealed class JsonIgnoreAttribute : Attribute {
	}
}