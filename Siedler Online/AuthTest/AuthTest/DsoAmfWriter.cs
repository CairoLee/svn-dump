using System;
using System.IO;
using System.Text;
using GodLesZ.Library.Amf.IO;

namespace AuthTest {

	public class DsoAmfWriter {
		private MemoryStream mMemStream;
		private AMFWriter mMamfStream;

		public AMFWriter Amf {
			get { return mMamfStream; }
		}


		public DsoAmfWriter() {
			mMemStream = new MemoryStream();
			mMamfStream = new AMFWriter(mMemStream);
		}


		public byte[] ToArray() {
			string header = "";
			header += "Referer: http://static13.cdn.ubi.com/settlers_online/live/de/L4203DE/SWMMO/debug/SWMMO.swf\r\n";
			header += "Content-type: application/x-amf\r\n";
			header += "Content-length: " + mMemStream.Length + "\r\n\r\n";
			byte[] headerBuf = Encoding.Default.GetBytes(header);
			byte[] bodyBuf = mMemStream.ToArray();
			byte[] data = new byte[headerBuf.Length + bodyBuf.Length];

			Array.Copy(headerBuf, 0, data, 0, headerBuf.Length);
			Array.Copy(bodyBuf, 0, data, headerBuf.Length, bodyBuf.Length);

			headerBuf = null;
			bodyBuf = null;

			return data;
		}

	}

}
