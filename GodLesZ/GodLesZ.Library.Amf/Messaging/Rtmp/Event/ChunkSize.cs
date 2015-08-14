using System;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Event;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Event {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public class ChunkSize : BaseEvent {
		int _size = 0;

		internal ChunkSize(int size)
			: base(EventType.SYSTEM) {
			_dataType = Constants.TypeChunkSize;
			_size = size;
		}
		/// <summary>
		/// Chunk size.
		/// </summary>
		public int Size {
			get { return _size; }
			set { _size = value; }
		}
		/// <summary>
		/// Returns a string that represents the current object fields.
		/// </summary>
		/// <param name="indentLevel">The indentation level used for tracing the members.</param>
		/// <returns>A string that represents the current object fields.</returns>
		protected override string ToStringFields(int indentLevel) {
			string sep = GetFieldSeparator(indentLevel);
			string value = base.ToStringFields(indentLevel);
			value += sep + "size = " + _size;
			return value;
		}
	}
}
