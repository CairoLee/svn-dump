using System;
using System.Collections;
#if !(NET_1_1)
using System.Collections.Generic;
#endif

namespace GodLesZ.Library.Amf.AMF3 {
	/// <summary>
	/// Flex ObjectProxy class.
	/// </summary>
	[CLSCompliant(false)]
#if !(NET_1_1)
	public class ObjectProxy : Dictionary<string, Object>, IExternalizable
#else
    public class ObjectProxy : Hashtable, IExternalizable
#endif
 {
		/// <summary>
		/// Initializes a new instance of the ObjectProxy class.
		/// </summary>
		public ObjectProxy() {
		}

		#region IExternalizable Members

		/// <summary>
		/// Decode the ObjectProxy from a data stream.
		/// </summary>
		/// <param name="input">IDataInput interface.</param>
		public void ReadExternal(IDataInput input) {
			object value = input.ReadObject();
			if (value is IDictionary) {
				IDictionary dictionary = value as IDictionary;
				foreach (DictionaryEntry entry in dictionary) {
					this.Add(entry.Key as string, entry.Value);
				}
			}
		}
		/// <summary>
		/// Encode the ObjectProxy for a data stream.
		/// </summary>
		/// <param name="output">IDataOutput interface.</param>
		public void WriteExternal(IDataOutput output) {
			ASObject asObject = new ASObject();
#if !(NET_1_1)
			foreach (KeyValuePair<string, object> entry in this)
#else
			foreach(DictionaryEntry entry in this)
#endif
 {
				asObject.Add(entry.Key, entry.Value);
			}
			output.WriteObject(asObject);
		}

		#endregion
	}
}
