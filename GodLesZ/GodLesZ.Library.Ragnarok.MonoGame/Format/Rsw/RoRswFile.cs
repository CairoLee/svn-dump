using System.Collections.Generic;
using System.Text;
using GodLesZ.Library.Formats;
using GodLesZ.Library.MonoGame.Extensions;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Rsw {

	public class RoRswFile : GenericFileFormat {
		private string mIniFile;
		private string mGndFile;
		private string mGatFile;

		private RoRswDataWater mWaterData;
		private List<RoRswDataModel> mModelData = new List<RoRswDataModel>();
		private List<RoRswDataLight> mLightData = new List<RoRswDataLight>();
		private List<RoRswDataSound> mSoundData = new List<RoRswDataSound>();
		private List<RoRswDataEffect> mEffectData = new List<RoRswDataEffect>();


		public RoRswDataWater WaterData {
			get { return mWaterData; }
		}
		public List<RoRswDataModel> ModelData {
			get { return mModelData; }
		}
		public List<RoRswDataLight> LightData {
			get { return mLightData; }
		}
		public List<RoRswDataSound> SoundData {
			get { return mSoundData; }
		}
		public List<RoRswDataEffect> EffectData {
			get { return mEffectData; }
		}


		public RoRswFile(string Filename)
			: base(Filename, Encoding.GetEncoding("ISO-8859-1")) {
			Read(Filename);
		}


		protected override bool ReadInternal() {
			if (base.ReadInternal() == false) {
				return false;
			}

			// skip Magic Header
			Reader.BaseStream.Position += 4; // GRSW

			Version = new GenericFileFormatVersion(Reader);

			mIniFile = Reader.ReadWord(40);
			mGndFile = Reader.ReadWord(40);
			if (Version.IsCompatible(1, 4)) {
				mGatFile = Reader.ReadWord(40);
			}

			mWaterData = new RoRswDataWater(Reader, Version);

			// Unknown Byte Skipping
			if (Version.IsCompatible(1, 4)) {
				int i1 = Reader.ReadInt32(); // angle(?) in degrees
				int i2 = Reader.ReadInt32(); // angle(?) in degrees
				Vector3 v1 = Reader.ReadVector3(); // some sort of Vector3D
				Vector3 v2 = Reader.ReadVector3(); // some sort of Vector3D
			}
			if (Version.IsCompatible(1, 7)) {
				float f1 = Reader.ReadSingle();
			}
			if (Version.IsCompatible(1, 6)) {
				int i1 = Reader.ReadInt32();
				int i2 = Reader.ReadInt32();
				int i3 = Reader.ReadInt32();
				int i4 = Reader.ReadInt32();
			}

			// reading Objects
			uint objCount = Reader.ReadUInt32();
			RoRswDataModel m;
			RoRswDataLight l;
			RoRswDataSound s;
			RoRswDataEffect e;

			//System.Diagnostics.Debug.WriteLine( "reading " + objCount + " Objects from RWS File" );
			for (int i = 0; i < objCount; i++) {
				if (Reader.BaseStream.Position + 4 >= Reader.BaseStream.Length)
					break;

				int objType = Reader.ReadInt32();
				if (objType < 1 || objType > 4) {
					//System.Diagnostics.Debug.WriteLine( "- UNKNOWN Object (" + objType + ") @ " + i );
					continue;
				}

				// 1 = Model
				// 2 = Light
				// 3 = Sound
				// 4 = Effect
				if (objType == 1) {
					try {
						//System.Diagnostics.Debug.WriteLine( "- found Model @ Obj " + i );
						m = new RoRswDataModel(Reader, Version);
						mModelData.Add(m);
					} catch {
						continue;
					}
				} else if (objType == 2) {
					try {
						//System.Diagnostics.Debug.WriteLine( "- found Light @ Obj " + i );
						l = new RoRswDataLight(Reader, Version);
						mLightData.Add(l);
					} catch {
						continue;
					}
				} else if (objType == 3) {
					try {
						//System.Diagnostics.Debug.WriteLine( "- found Sound @ Obj " + i );
						s = new RoRswDataSound(Reader, Version);
						mSoundData.Add(s);
					} catch {
						continue;
					}
				} else if (objType == 4) {
					try {
						//System.Diagnostics.Debug.WriteLine( "- found Effect @ Obj " + i );
						e = new RoRswDataEffect(Reader, Version);
						mEffectData.Add(e);
					} catch {
						continue;
					}
				}

			}


			return true;
		}


	}

}
