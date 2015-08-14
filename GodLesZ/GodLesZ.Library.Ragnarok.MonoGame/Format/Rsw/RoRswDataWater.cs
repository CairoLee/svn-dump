using System.IO;
using GodLesZ.Library.Formats;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsw {

	public class RoRswDataWater : GenericFileFormatData {

		/// <summary>
		/// Versions 1.3 and above
		/// </summary>
		public float Height {
			get;
			protected set;
		}

		/// <summary>
		/// Versions 1.8 and above
		/// </summary>
		public uint Type {
			get;
			protected set;
		}

		/// <summary>
		/// Versions 1.8 and above
		/// </summary>
		public float Amplitude {
			get;
			protected set;
		}

		/// <summary>
		/// Versions 1.8 and above
		/// </summary>
		public float Phase {
			get;
			protected set;
		}

		/// <summary>
		/// Versions 1.8 and above
		/// </summary>
		public float SurfaceCurveLevel {
			get;
			protected set;
		}

		/// <summary>
		/// Versions 1.9 and above
		/// </summary>
		public int TextureCycling {
			get;
			protected set;
		}


		public RoRswDataWater(BinaryReader reader, GenericFileFormatVersion version)
			: base(reader, version) {
			Height = 0;
			Type = 0;
			Amplitude = 1;
			Phase = 2;
			SurfaceCurveLevel = 0.5f;
			TextureCycling = 3;

			if (version.IsCompatible(1, 3)) {
				Height = reader.ReadSingle();

				if (version.IsCompatible(1, 8)) {
					Type = reader.ReadUInt32();
					Amplitude = reader.ReadSingle();
					Phase = reader.ReadSingle();
					SurfaceCurveLevel = reader.ReadSingle();

					if (version.IsCompatible(1, 9)) {
						TextureCycling = reader.ReadInt32();
					}
				}
			}
		}

	}

}
