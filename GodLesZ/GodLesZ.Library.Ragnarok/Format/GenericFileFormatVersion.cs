using System.IO;

namespace GodLesZ.Library.Ragnarok {

	public class GenericFileFormatVersion {
		private ushort mVersion;

		public byte Major {
			get;
			protected set;
		}

		public byte Minor {
			get;
			protected set;
		}

		public ushort Version {
			get { return mVersion; }
		}


		public GenericFileFormatVersion(BinaryReader reader) {
			Major = reader.ReadByte();
			Minor = reader.ReadByte();
			reader.BaseStream.Seek(-2, SeekOrigin.Current);
			mVersion = reader.ReadUInt16();
		}


		public bool IsCompatible(byte major, byte minor) {
			return (Major > major || (Major == major && Minor >= minor));
		}


		public static implicit operator int(GenericFileFormatVersion version) {
			return version.Version;
		}


		public override string ToString() {
			return Version.ToString("X2");
		}

	}

}
