using System;
using System.Net;

namespace Rovolution.Server {

	public static class IPAddressExtension {

		/// <summary>The IPAddress extension method that gets the address as a number.</summary>
		/// <exception cref="Exception">Thrown when an exception error condition occurs.</exception>
		/// <param name="ip">The ip to act on.</param>
		/// <returns>The address.</returns>
		public static long GetAddress(this IPAddress ip) {
			byte[] buf = ip.GetAddressBytes();
			long ipLong = -1;

			// TODO: confirm this!
			// Long needs 8 bytes, so try to ident by length
			if (buf.Length == 4) {
				try {
					ipLong = BitConverter.ToInt32(buf, 0);
				} catch {
					ipLong = -1;
				}
			} else if (buf.Length == 8) {
				try {
					ipLong = BitConverter.ToInt64(buf, 0);
				} catch {
					ipLong = -1;
				}
			} else {
				ipLong = -1;
			}
#if DEBUG
			if (ipLong == -1) {
				throw new Exception("Unable to convert IP address to integer or long: " + ip.ToString() + " (buf.Length " + buf.Length + "9");
			}
#endif

			return ipLong;
		}

	}

}
