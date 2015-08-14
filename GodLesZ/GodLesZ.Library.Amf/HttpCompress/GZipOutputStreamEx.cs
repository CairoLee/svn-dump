


#if (NET_1_1)
using ICSharpCode.SharpZipLib.GZip;

namespace GodLesZ.Library.Amf.HttpCompress
{
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class GZipOutputStreamEx : GZipOutputStream
	{
		public GZipOutputStreamEx(Stream baseOutputStream):base(baseOutputStream)
		{
		}

		public GZipOutputStreamEx(Stream baseOutputStream, int size):base(baseOutputStream, size)
		{
		}

		public long TotalIn
		{
			get{ return this.deflater_.TotalIn; }
		}

		public long TotalOut
		{
            get { return this.deflater_.TotalOut; }
		}
	}
}

#endif