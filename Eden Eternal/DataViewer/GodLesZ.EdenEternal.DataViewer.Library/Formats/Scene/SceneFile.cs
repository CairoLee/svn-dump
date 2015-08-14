using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using GodLesZ.Library.Formats;

namespace GodLesZ.EdenEternal.DataViewer.Library.Formats.Scene {

	public class SceneFile : GenericFileFormat {
		public const string MapImageBasePath = @"C:\Games\Eden Eternal\EdenEternal-DE\pkg\_Unpack\UI\map\";
		public static NumberFormatInfo DefaultFloatFormat = new NumberFormatInfo { CurrencyDecimalSeparator = "." };

		protected Image mMapImage = null;

		public string Mapname {
			get;
			protected set;
		}

		public string MapImageFilepath {
			get { return string.Format("{0}{1}m.dds", MapImageBasePath, Mapname); }
		}

		public int Width {
			get;
			protected set;
		}

		public int Height {
			get;
			protected set;
		}

		public List<SceneFileMobSpawnEntry> MobSpawns {
			get;
			protected set;
		}

		public SceneFileMobPatrolRouteList MobRoutes {
			get;
			protected set;
		}


		/// <summary>
		/// If implemented, creates a new instance without any filepath and uses the <see cref="GenericFileFormat.Encoding.Default"/> encoding for
		/// further reading and writing
		/// </summary>
		public SceneFile() {
		}

		/// <summary>
		/// If implemented, creates a new instance with the given filepath and used the <see cref="GenericFileFormat.Encoding.Default"/> 
		/// encoding for further reading and writing.
		/// The <see cref="GenericFileFormat.Read()"/> method will be called automatically.
		/// <param name="filepath">The filepath to read from</param>
		/// </summary>
		public SceneFile(string filepath)
			: base(filepath) {
		}

		/// <summary>
		/// If implemented, creates a new instance with the given filepath and encoding for reading and writing.
		/// The <see cref="GenericFileFormat.Read()"/> method will be called automatically.
		/// <param name="filepath">The filepath to read from</param>
		/// <param name="enc">The used encoding for reading and writing</param>
		/// </summary>
		public SceneFile(string filepath, Encoding enc)
			: base(filepath, enc) {
		}


		public Image GetMapImage() {
			if (mMapImage == null) {
				var filepath = MapImageFilepath;
				var img = new DDSImage(filepath);
				mMapImage = img.images[0];
			}

			return mMapImage.Clone() as Image;
		}

		/// <summary>
		/// Internal method to read the file format.
		/// </summary>
		/// <returns></returns>
		protected override bool ReadInternal() {
			Mapname = string.Format("{0}", Path.GetFileNameWithoutExtension(Filepath).ToUpper());
			MobSpawns = new List<SceneFileMobSpawnEntry>();
			MobRoutes = new SceneFileMobPatrolRouteList();

			var lineReader = new StreamReader(ReaderBaseStream, Encoding);
			var line = string.Empty;
			var iLine = 0;
			var blockStatus = ESceneFileArea.None;

			while ((line = GetNextLine(lineReader)) != null) {
				line = line.Trim();
				iLine++;

				if (string.IsNullOrEmpty(line)) {
					continue;
				}

				var reFileBlock = new Regex(@"^\[([^\]]+)\],$", RegexOptions.Compiled);
				var match = reFileBlock.Match(line);

				if (line == "[globe_data],") {
					blockStatus = ESceneFileArea.GlobeData;
				} else if (line == "[born_area],") {
					blockStatus = ESceneFileArea.BornArea;
				} else if (line == "[revive_area],") {
					blockStatus = ESceneFileArea.ReviveArea;
				} else if (line == "[gateway_area],") {
					blockStatus = ESceneFileArea.GatewayArea;
				} else if (line == "[normal_area],") {
					blockStatus = ESceneFileArea.NormalArea;
				} else if (line == "[event_area],") {
					blockStatus = ESceneFileArea.EventArea;
				} else if (line == "[position],") {
					blockStatus = ESceneFileArea.Position;
				} else if (line == "[mob_patrol_mode],") {
					blockStatus = ESceneFileArea.MobPatrol;
				} else if (line == "[reborn_monsters],") {
					blockStatus = ESceneFileArea.RebornMonsters;
				} else if (line == "[npc],") {
					blockStatus = ESceneFileArea.Npc;
				} else if (line == "[environment_sound],") {
					blockStatus = ESceneFileArea.EnvironmentSound;
				} else if (line == "[event],") {
					blockStatus = ESceneFileArea.Event;
				} else if (match.Success == false && blockStatus != ESceneFileArea.None) {
					object result = null;
					switch (blockStatus) {
						case ESceneFileArea.GlobeData:
							result = ParseBlockGlobeData(line, iLine);
							break;
						case ESceneFileArea.RebornMonsters:
							result = ParseBlockRebornMonsters(line, iLine);
							break;
						case ESceneFileArea.MobPatrol:
							result = ParseBlockMonsterPatrol(line, iLine);
							break;
						case ESceneFileArea.Npc:
							result = ParseBlockNpc(line, iLine);
							break;
					}


				}
			}

			return true;
		}

		protected string GetNextLine(StreamReader lineReader) {
			if (lineReader.EndOfStream || lineReader.BaseStream.Position >= lineReader.BaseStream.Length) {
				return null;
			}

			// We need to buffer the line... damn unicodes
			var line = string.Empty;
			while (lineReader.BaseStream.Position < lineReader.BaseStream.Length) {
				var c = (char)lineReader.Read();
				line += c;
				if (line.EndsWith("\r\n")) {
					break;
				}
			}

			return line;
		}

		protected object ParseBlockGlobeData(string line, int iLine) {
			// S002.fsm,448,448,V7,
			var columns = line.Split(',');
			Width = int.Parse(columns[1]);
			Height = int.Parse(columns[2]);

			return null;
		}

		protected object ParseBlockRebornMonsters(string line, int iLine) {
			// 1,56001,48,10,0,149.224,278.336,0,0,0,0,0,1,M025,LV1 ¶À´³Û£ 56001,0,0,0,0,0,0,0,0,0,
			// [0:ID],[1:MobID],[?2:PatrolID],[3:Unknown1],[4:Unknown2],[5:X],[6:Y],...
			var columns = line.Split(',');
			if (columns.Length < 7) {
				return null;
			}
			
			var entry = new SceneFileMobSpawnEntry {
				ID = int.Parse(columns[0]),
				MobID = int.Parse(columns[1]),
				PatrolID = int.Parse(columns[2]),
				X = float.Parse(columns[5], DefaultFloatFormat),
				Y = float.Parse(columns[6], DefaultFloatFormat)
			};
			MobSpawns.Add(entry);

			return entry;
		}

		protected object ParseBlockNpc(string line, int iLine) {

			return null;
		}

		protected object ParseBlockMonsterPatrol(string line, int iLine) {
			var route = SceneFileMobPatrolRoute.Parse(line);
			if (route == null || route.RouteID == 0) {
				return null;
			}

			if (MobRoutes.ContainsKey(route.RouteID)) {
				throw new Exception("Invalid route data in line " + iLine + ", duplicate id " + route.RouteID);
			}

			MobRoutes.Add(route);

			return route;
		}

	}

}