using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0ObjectWriter : IAMFWriter {
		public AMF0ObjectWriter() {
		}
		#region IAMFWriter Members

		public bool IsPrimitive { get { return false; } }

		public void WriteData(AMFWriter writer, object data) {
			if (data is IList) {
				IList list = data as IList;
				object[] array = new object[list.Count];
				list.CopyTo(array, 0);
				writer.WriteArray(ObjectEncoding.AMF0, array);
				return;
			}
#if !(SILVERLIGHT)
			IListSource listSource = data as IListSource;
			if (listSource != null) {
				IList list = listSource.GetList();
				object[] array = new object[list.Count];
				list.CopyTo(array, 0);
				writer.WriteArray(ObjectEncoding.AMF0, array);
				return;
			}
#endif
			if (data is IDictionary) {
				writer.WriteAssociativeArray(ObjectEncoding.AMF0, data as IDictionary);
				return;
			}
			if (data is Exception) {
				writer.WriteASO(ObjectEncoding.AMF0, new ExceptionASO(data as Exception));
				return;
			}
			if (data is IEnumerable) {
				List<object> tmp = new List<object>();
				foreach (object element in (data as IEnumerable)) {
					tmp.Add(element);
				}
				writer.WriteArray(ObjectEncoding.AMF0, tmp.ToArray());
				return;
			}
			writer.WriteObject(ObjectEncoding.AMF0, data);
		}

		#endregion
	}
}
