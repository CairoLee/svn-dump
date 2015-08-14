
namespace GodLesZ.Library.Imaging.Mathematic {

	public class Tools {
		public static bool IsPowerOf2(int x) {
			return ((x & (x - 1)) == 0);
		}

		public static int Log2(int x) {
			if (x <= 0x10000) {
				if (x <= 0x100) {
					if (x <= 0x10) {
						if (x <= 4) {
							if (x > 2) {
								return 2;
							}
							if (x <= 1) {
								return 0;
							}
							return 1;
						}
						if (x <= 8) {
							return 3;
						}
						return 4;
					}
					if (x <= 0x40) {
						if (x <= 0x20) {
							return 5;
						}
						return 6;
					}
					if (x <= 0x80) {
						return 7;
					}
					return 8;
				}
				if (x <= 0x1000) {
					if (x <= 0x400) {
						if (x <= 0x200) {
							return 9;
						}
						return 10;
					}
					if (x <= 0x800) {
						return 11;
					}
					return 12;
				}
				if (x <= 0x4000) {
					if (x <= 0x2000) {
						return 13;
					}
					return 14;
				}
				if (x <= 0x8000) {
					return 15;
				}
				return 0x10;
			}
			if (x <= 0x1000000) {
				if (x <= 0x100000) {
					if (x <= 0x40000) {
						if (x <= 0x20000) {
							return 0x11;
						}
						return 0x12;
					}
					if (x <= 0x80000) {
						return 0x13;
					}
					return 20;
				}
				if (x <= 0x400000) {
					if (x <= 0x200000) {
						return 0x15;
					}
					return 0x16;
				}
				if (x <= 0x800000) {
					return 0x17;
				}
				return 0x18;
			}
			if (x <= 0x10000000) {
				if (x <= 0x4000000) {
					if (x <= 0x2000000) {
						return 0x19;
					}
					return 0x1a;
				}
				if (x <= 0x8000000) {
					return 0x1b;
				}
				return 0x1c;
			}
			if (x > 0x40000000) {
				return 0x1f;
			}
			if (x <= 0x20000000) {
				return 0x1d;
			}
			return 30;
		}

		public static int Pow2(int exp) {
			if ((exp >= 0) && (exp <= 30)) {
				return (((int)1) << exp);
			}
			return 0;
		}

	}

}

