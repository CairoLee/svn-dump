using System;
using System.IO;
using GodLesZ.Library.Formats;

namespace GodLesZ.Library.Ragnarok.Action {

	public class RoActionFile : GenericFileFormat {
		public const string FormatExtension = ".act";

		public byte MajorVersion {
			get;
			protected set;
		}

		public byte MinorVersion {
			get;
			protected set;
		}

		public RoActionList Actions {
			get;
			protected set;
		}

		public RoActionIntervalList Intervals {
			get;
			protected set;
		}

		public RoActionSoundList Sounds {
			get;
			protected set;
		}


		public RoActionFile(string Actionpath)
			: base(Actionpath) {
		}

		public RoActionFile(Stream stream)
			: base(stream) {
		}

		public RoActionFile()
			: this("") {
		}


		protected override bool ReadInternal() {
			Actions = new RoActionList();
			Sounds = new RoActionSoundList();
			Intervals = new RoActionIntervalList();

			Actions.Clear();
			Sounds.Clear();
			Intervals.Clear();

			char[] magicHead = Reader.ReadChars(2);
			MajorVersion = Reader.ReadByte();
			MinorVersion = Reader.ReadByte();
			Reader.BaseStream.Seek(-2, System.IO.SeekOrigin.Current);
			Version = new GenericFileFormatVersion(Reader);
			string versionString = "0x" + Version.ToString();

			if (Version > 0x205) {
				throw new Exception("Unsupported action format 0x" + versionString);
			}

			short animationCount = Reader.ReadInt16();
			Reader.BaseStream.Seek(10, System.IO.SeekOrigin.Current);

			RoAction ani;
			RoActionFrame frame;
			RoActionFrameImage img;
			for (int a = 0; a < animationCount; a++) {
				int frameCount = Reader.ReadInt32();

				ani = new RoAction();
				for (int f = 0; f < frameCount; f++) {
					frame = new RoActionFrame {
						Index = f,
						SoundNo = 0,
						ExtraX = 0,
						ExtraY = 0
					};

					Reader.BaseStream.Seek(16, System.IO.SeekOrigin.Current); // range1 RECT{left,top,right,bottom}
					Reader.BaseStream.Seek(16, System.IO.SeekOrigin.Current); // range1 RECT{left,top,right,bottom}

					int imageCount = Reader.ReadInt32();

					for (int i = 0; i < imageCount; i++) {
						img = new RoActionFrameImage {
							OffsetX = Reader.ReadInt32(),
							OffsetY = Reader.ReadInt32(),
							ImageIndex = Reader.ReadInt32(),
							Direction = Reader.ReadInt32(),
							Color = System.Drawing.Color.White,
							Rotation = 0,
							ScaleX = 1,
							ScaleY = 1,
							Width = 0,
							Height = 0
						};

						// Version >= 2
						if (Version >= 0x200) {
							img.Color = Reader.ReadRoSpriteColor(false);
							// Version <= 2.3
							if (Version <= 0x203) {
								img.ScaleX = img.ScaleY = Reader.ReadSingle();
							} else {
								// Version > 2.3
								img.ScaleX = Reader.ReadSingle();
								img.ScaleY = Reader.ReadSingle();
							}
							img.Rotation = Reader.ReadInt32();
							img.RgbImage = (Reader.ReadInt32() == 1);

							if (Version >= 0x205) {
								img.Width = Reader.ReadInt32();
								img.Height = Reader.ReadInt32();
							}
						}

						frame.Add(img);
					}

					if (Version >= 0x200) {
						frame.SoundNo = Reader.ReadInt32();
						frame.ExtraX = frame.ExtraY = 0;

						if (Version >= 0x203) {
							int extrainfo = Reader.ReadInt32();
							// TODO: Maybe its a list, but dont know how to handle more than one extra offsets
							if (extrainfo > 0) {
								Reader.BaseStream.Seek(4, System.IO.SeekOrigin.Current);
								frame.ExtraX = Reader.ReadInt32();
								frame.ExtraY = Reader.ReadInt32();
								Reader.BaseStream.Seek(4, System.IO.SeekOrigin.Current);
							}
						}
					}

					ani.Add(frame);
				}

				Actions.Add(ani);
			}

			// Sounds
			if (Version >= 0x0201) {
				int soundNum = Reader.ReadInt32();
				string[] soundNames = new string[soundNum];
				for (int i = 0; i < soundNames.Length; i++) {
					soundNames[i] = new String(Reader.ReadChars(40));
					soundNames[i] = soundNames[i].Replace("\0", "");
				}

				Sounds.AddRange(soundNames);
				soundNames = null;
			}

			// Interval
			if (Version >= 0x0202) {
				float[] intervals = new float[animationCount];
				for (int i = 0; i < intervals.Length; i++) {
					intervals[i] = Reader.ReadSingle() * 25f;
				}

				Intervals.AddRange(intervals);
				intervals = null;
			} else {
				for (int i = 0; i < animationCount; i++) {
					Intervals.Add(100f);
				}
			}

			Flush();
			return true;
		}

		public override bool Write(string filePath, bool overwrite) {
			base.Write(filePath, overwrite);

			Flush();

			return true;
		}

		public override string ToString() {
			return string.Format("0x{0:X2}, {1}x actions, {2}x sounds", Version, Actions.Count, Sounds.Count);
		}
	}

}
