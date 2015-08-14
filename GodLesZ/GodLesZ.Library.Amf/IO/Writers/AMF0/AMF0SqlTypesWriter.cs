using System.Data.SqlTypes;
using GodLesZ.Library.Amf.Exceptions;
using log4net;

namespace GodLesZ.Library.Amf.IO.Writers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0SqlTypesWriter : IAMFWriter {
		private static readonly ILog _log = LogManager.GetLogger(typeof(AMF0SqlTypesWriter));

		public AMF0SqlTypesWriter() {
		}

		#region IAMFWriter Members

		public bool IsPrimitive { get { return true; } }

		public void WriteData(AMFWriter writer, object data) {
			if (data is INullable) {
				if ((data as INullable).IsNull) {
					writer.WriteNull();
					return;
				}
			}
			if (data is SqlByte) {
				writer.WriteData(ObjectEncoding.AMF0, ((SqlByte)data).Value);
				return;
			}
			if (data is SqlInt16) {
				writer.WriteData(ObjectEncoding.AMF0, ((SqlInt16)data).Value);
				return;
			}
			if (data is SqlInt32) {
				writer.WriteData(ObjectEncoding.AMF0, ((SqlInt32)data).Value);
				return;
			}
			if (data is SqlInt64) {
				writer.WriteData(ObjectEncoding.AMF0, ((SqlInt64)data).Value);
				return;
			}
			if (data is SqlSingle) {
				writer.WriteData(ObjectEncoding.AMF0, ((SqlSingle)data).Value);
				return;
			}
			if (data is SqlDouble) {
				writer.WriteData(ObjectEncoding.AMF0, ((SqlDouble)data).Value);
				return;
			}
			if (data is SqlDecimal) {
				writer.WriteData(ObjectEncoding.AMF0, ((SqlDecimal)data).Value);
				return;
			}
			if (data is SqlMoney) {
				writer.WriteData(ObjectEncoding.AMF0, ((SqlMoney)data).Value);
				return;
			}
			if (data is SqlDateTime) {
				writer.WriteData(ObjectEncoding.AMF0, ((SqlDateTime)data).Value);
				return;
			}
			if (data is SqlString) {
				writer.WriteString(((SqlString)data).Value);
				return;
			}
			if (data is SqlGuid) {
				writer.WriteData(ObjectEncoding.AMF0, ((SqlGuid)data).Value.ToString("D"));
				return;
			}
			if (data is SqlBoolean) {
				writer.WriteBoolean(((SqlBoolean)data).Value);
				return;
			}
			string msg = string.Format("Could not find serializer for type {0}", data.GetType().FullName);
			if (_log.IsErrorEnabled)
				_log.Error(msg);
			throw new FluorineException(msg);
		}

		#endregion
	}
}
