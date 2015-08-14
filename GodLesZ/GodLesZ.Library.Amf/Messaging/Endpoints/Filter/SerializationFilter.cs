
using GodLesZ.Library.Amf.IO;

namespace GodLesZ.Library.Amf.Messaging.Endpoints.Filter {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class SerializationFilter : AbstractFilter {
		bool _useLegacyCollection = false;
		bool _useLegacyThrowable = true;
		/// <summary>
		/// Initializes a new instance of the SerializationFilter class.
		/// </summary>
		public SerializationFilter() {
		}
		/// <summary>
		/// Gets or sets whether legacy collection serialization is used for AMF3.
		/// </summary>
		public bool UseLegacyCollection {
			get { return _useLegacyCollection; }
			set { _useLegacyCollection = value; }
		}
		/// <summary>
		/// Gets or sets whether legacy exception serialization is used for AMF3.
		/// </summary>
		public bool UseLegacyThrowable {
			get { return _useLegacyThrowable; }
			set { _useLegacyThrowable = value; }
		}

		#region IFilter Members

		public override void Invoke(AMFContext context) {
			AMFSerializer serializer = new AMFSerializer(context.OutputStream);
			serializer.UseLegacyCollection = _useLegacyCollection;
			serializer.UseLegacyThrowable = _useLegacyThrowable;
			serializer.WriteMessage(context.MessageOutput);
			serializer.Flush();


			//Serialization/deserialization debugging
			//Note: this will not work correctly with optimizers (different ClassDefinitions from server and client)
			/*
			MemoryStream ms = new MemoryStream();
			AMFSerializer testSerializer = new AMFSerializer(ms);
			testSerializer.UseLegacyCollection = _useLegacyCollection;
			testSerializer.UseLegacyThrowable = _useLegacyThrowable;
			testSerializer.WriteMessage(context.MessageOutput);
			testSerializer.Flush();
			ms.Position = 0;
			AMFDeserializer testDeserializer = new AMFDeserializer(ms);
			testDeserializer.UseLegacyCollection = _useLegacyCollection;
			AMFMessage amfMessageOut = testDeserializer.ReadAMFMessage();
			ms.Position = 0;
			byte[] buffer = ms.ToArray();
			context.OutputStream.Write(buffer, 0, buffer.Length);
			*/
		}

		#endregion
	}
}
