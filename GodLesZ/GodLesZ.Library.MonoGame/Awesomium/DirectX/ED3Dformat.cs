namespace GodLesZ.Library.MonoGame.Awesomium.DirectX {
	public enum ED3Dformat {
		D3DfmtUnknown = 0,

		D3DfmtR8G8B8 = 20,
		D3DfmtA8R8G8B8 = 21,
		D3DfmtX8R8G8B8 = 22,
		D3DfmtR5G6B5 = 23,
		D3DfmtX1R5G5B5 = 24,
		D3DfmtA1R5G5B5 = 25,
		D3DfmtA4R4G4B4 = 26,
		D3DfmtR3G3B2 = 27,
		D3DfmtA8 = 28,
		D3DfmtA8R3G3B2 = 29,
		D3DfmtX4R4G4B4 = 30,
		D3DfmtA2B10G10R10 = 31,
		D3DfmtA8B8G8R8 = 32,
		D3DfmtX8B8G8R8 = 33,
		D3DfmtG16R16 = 34,
		D3DfmtA2R10G10B10 = 35,
		D3DfmtA16B16G16R16 = 36,

		D3DfmtA8P8 = 40,
		D3DfmtP8 = 41,

		D3DfmtL8 = 50,
		D3DfmtA8L8 = 51,
		D3DfmtA4L4 = 52,

		D3DfmtV8U8 = 60,
		D3DfmtL6V5U5 = 61,
		D3DfmtX8L8V8U8 = 62,
		D3DfmtQ8W8V8U8 = 63,
		D3DfmtV16U16 = 64,
		D3DfmtA2W10V10U10 = 67,

		//TODO Check MAKEFOURCC conversions
		D3DfmtUyvy = ('U' << 24) + ('Y' << 16) + ('V' << 8) + 'Y', //MAKEFOURCC('U', 'Y', 'V', 'Y'),
		D3DfmtR8G8B8G8 = ('R' << 24) + ('G' << 16) + ('B' << 8) + 'G', //MAKEFOURCC('R', 'G', 'B', 'G'),
		D3DfmtYuy2 = ('Y' << 24) + ('U' << 16) + ('Y' << 8) + '2', //MAKEFOURCC('Y', 'U', 'Y', '2'),
		D3DfmtG8R8G8B8 = ('G' << 24) + ('R' << 16) + ('G' << 8) + 'B', //MAKEFOURCC('G', 'R', 'G', 'B'),
		D3DfmtDxt1 = ('D' << 24) + ('X' << 16) + ('T' << 8) + '1', //MAKEFOURCC('D', 'X', 'T', '1'),
		D3DfmtDxt2 = ('D' << 24) + ('X' << 16) + ('T' << 8) + '2', //MAKEFOURCC('D', 'X', 'T', '2'),
		D3DfmtDxt3 = ('D' << 24) + ('X' << 16) + ('T' << 8) + '3', //MAKEFOURCC('D', 'X', 'T', '3'),
		D3DfmtDxt4 = ('D' << 24) + ('X' << 16) + ('T' << 8) + '4', //MAKEFOURCC('D', 'X', 'T', '4'),
		D3DfmtDxt5 = ('D' << 24) + ('X' << 16) + ('T' << 8) + '5', //MAKEFOURCC('D', 'X', 'T', '5'),

		D3DfmtD16Lockable = 70,
		D3DfmtD32 = 71,
		D3DfmtD15S1 = 73,
		D3DfmtD24S8 = 75,
		D3DfmtD24X8 = 77,
		D3DfmtD24X4S4 = 79,
		D3DfmtD16 = 80,

		D3DfmtD32FLockable = 82,
		D3DfmtD24Fs8 = 83,

		D3DfmtD32Lockable = 84,
		D3DfmtS8Lockable = 85,

		D3DfmtL16 = 81,

		D3DfmtVertexdata = 100,
		D3DfmtIndex16 = 101,
		D3DfmtIndex32 = 102,

		D3DfmtQ16W16V16U16 = 110,

		D3DfmtMulti2Argb8 = ('M' << 24) + ('E' << 16) + ('T' << 8) + '1', //MAKEFOURCC('M','E','T','1'),

		D3DfmtR16F = 111,
		D3DfmtG16R16F = 112,
		D3DfmtA16B16G16R16F = 113,

		D3DfmtR32F = 114,
		D3DfmtG32R32F = 115,
		D3DfmtA32B32G32R32F = 116,

		D3DfmtCxV8U8 = 117,

		D3DfmtA1 = 118,
		D3DfmtA2B10G10R10XrBias = 119,
		D3DfmtBinarybuffer = 199,

		D3DfmtForceDword = 0x7fffffff
	}
}