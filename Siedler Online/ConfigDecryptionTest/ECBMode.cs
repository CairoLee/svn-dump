using System;
using System.IO;

namespace ConfigDecryptionTest {

	public class ECBMode {
		private BlowFishKey mKey;
		private PKCS5 mPadding;

		public uint BlockSize {
			get { return mKey.BlockSize; }
		}	
		
		public ECBMode(BlowFishKey bKey, PKCS5 pkcs5) {
			mKey = bKey;
			mPadding = pkcs5;
			mPadding.BlockSize = mKey.BlockSize;
		}


		public byte[] Decrypt(MemoryStream param1) {
			param1.Position = 0;

			uint _loc_2 = mKey.BlockSize;
			if ((uint)param1.Length % _loc_2 != 0)
			{
				throw new Exception("ECB mode cipher length must be a multiple of blocksize " + _loc_2);
			}
			var _loc_3 = new byte[_loc_2];
			var _loc_4 = new MemoryStream();
			uint _loc_5 = 0;
			while (_loc_5 < param1.Length) {
				_loc_3 = new byte[_loc_2];
				param1.Read(_loc_3, 0, _loc_3.Length);
				mKey.Decrypt(ref _loc_3);
				_loc_4.Write(_loc_3, 0, _loc_3.Length);
				_loc_5 = _loc_5 + _loc_2;
			}

			mPadding.Unpad(_loc_4);
			return _loc_4.ToArray();
		}

	}

}