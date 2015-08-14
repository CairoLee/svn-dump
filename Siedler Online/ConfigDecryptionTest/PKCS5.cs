using System;
using System.Collections.Generic;

namespace ConfigDecryptionTest {

	public class PKCS5 {
		private uint mBlockSize;

		public uint BlockSize {
			get { return mBlockSize; }
			set {
				mBlockSize = value;
			}
		}




		public void Unpad(System.IO.MemoryStream param1) {
			List<byte> buf = new List<byte>(param1.ToArray());
			uint _loc_4 = 0;
			var _loc_2 = param1.Length % BlockSize;
			if (_loc_2 != 0) {
				throw new Exception("PKCS#5::unpad: ByteArray.length isn\'t a multiple of the blockSize");
			}
			_loc_2 = buf[buf.Count - 1];
			var _loc_3 = _loc_2;
			while (_loc_3 > 0) {

				_loc_4 = buf[(buf.Count - 1)];
				buf.RemoveAt(buf.Count - 1);
				if (_loc_2 != _loc_4) {
					throw new Exception("PKCS#5:unpad: Invalid padding value. expected [" + _loc_2 + "], found [" + _loc_4 + "]");
				}
				_loc_3--;
			}

			param1 = new System.IO.MemoryStream(buf.ToArray());
		}

	}

}