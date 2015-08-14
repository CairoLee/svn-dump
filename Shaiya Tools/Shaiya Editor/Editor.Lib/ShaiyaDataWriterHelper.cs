using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Editor.Lib {

	public class ShaiyaDataWriterHelper {

		public static byte[] GetHeader() {
			List<byte> headData = new List<byte>();
			headData.AddRange(
				new byte[]{
					0x53,  // S
					0x41,  // A
					0x48,  // H

					0x00, // 3
					0x00, 
					0x00, 
					0x00, 
					0xB0, // 7 
					0x4E, // 8 
					0x00, 
					0x00, // 10

					0x53, // S
					0x68, // h
					0x61, // a
					0x69, // i
					0x6A, // j
					0x61, // a
					0x20, // 
					0x44, // D
					0x61, // a
					0x74, // t (20)
					0x61, // a
					0x45, // E
					0x64, // d
					0x69, // i
					0x74, // t
					0x6F, // o
					0x72, // r
					0x20, // 
					0x2D, // -
					0x20, //  (30)
					0x62, // b
					0x79, // y
					0x20, // 
					0x47, // G
					0x6F, // o
					0x64, // d
					0x4C, // L
					0x65, // e
					0x73, // s (40)
					0x5A, // Z

					0x00, // 42
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00,
					0x00, // 50
					0x00,
					0x01, // 52
				}
			);

			// fill up
			for( int i = headData.Count; i < Editor.Lib.ShaiyaData.StartOffset; i++ )
				headData.Add( 0x00 );

			return headData.ToArray();
		}

	}

}
