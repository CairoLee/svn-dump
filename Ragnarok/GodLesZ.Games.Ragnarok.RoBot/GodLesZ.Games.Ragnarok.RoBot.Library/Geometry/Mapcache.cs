using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using GodLesZ.Library.Compression;

namespace GodLesZ.Games.Ragnarok.RoBot.Library.Geometry {

	public class Mapcache {
		private class MapcacheMapData {
			public short Width;
			public short Height;
			public byte[] CellData;
		};

		public static Dictionary<int, Map> Maps {
			get;
			private set;
		}


		public static void Initialize()
		{
			return;
			/*
			Maps = new Dictionary<int, Map>();

			Stopwatch watch = Stopwatch.StartNew();
			Dictionary<string, MapcacheMapData> mapDataList = ReadMapcache(Core.Conf.Maplist["MapcachePath"]);
			Debug.WriteLine("Mapcache binary data took: " + watch.ElapsedMilliseconds + "ms");
			watch.Restart();

			MapcacheMapData mapData;
			Map map;
			string mapname;
			ECollisionType[] cells;

			int mapCount = Core.Conf.Maplist.Settings.Count - 1;
			foreach (KeyValuePair<string, string> kvp in Core.Conf.Maplist.Settings) {
				if (kvp.Key == "MapcachePath") {
					continue;
				}

				mapname = kvp.Value;
				if (mapDataList.ContainsKey(mapname) == false) {
					// Map not found!
					ServerConsole.ErrorLine("Can't find mapcache data for map '{0}', removed from list.", mapname);
					continue;
				}
				mapData = mapDataList[mapname];
				mapDataList.Remove(mapname);

				map = new Map(mapname, mapData.Width, mapData.Height);

				// Faster than .ConvertAll() or .Cast<>()..
				// but still needs 4-6sec..
				// TODO: this should be faster than 150 maps per sec!
				cells = new ECollisionType[mapData.CellData.Length];
				for (int i = 0; i < cells.Length; i++) {
					cells[i] = (ECollisionType)mapData.CellData[i];
				}

				map.SetCellData(cells);
				Maps.Add(map.ID, map);
				
				cells = null;
				map = null;

				//ServerConsole.DebugLine("Loading Maps [{0:000}/{1}]: {2}\r", Maps.Count, mapCount, mapname);
			}

			mapData = null;
			mapDataList = null;
			map = null;

			Debug.WriteLine("Mapcache managed data took: " + watch.ElapsedMilliseconds + "ms");
			watch.Stop();
			watch = null;
			*/
		}

		public static void Destroy() {
			if (Maps != null) {
				foreach (Map m in Maps.Values) {
					m.Dispose();
				}
				Maps.Clear();
				Maps = null;
			}
		}

		public static int GetID(string mapname) {
			mapname = mapname.ToLower();
			foreach (Map m in Maps.Values) {
				if (m.Name == mapname) {
					return m.ID;
				}
			}
			return -1;
		}


		private static Dictionary<string, MapcacheMapData> ReadMapcache(string path) {
			Dictionary<string, MapcacheMapData> mapdata = new Dictionary<string, MapcacheMapData>();
			byte[] decodedBuf, encodedBuf;

			// We want a relative path
			if (path[0] == '/' || path[0] == '\\') {
				path = path.Substring(1);
			}
			//path = Path.Combine(Core.Conf.ConfigDir, path);
			using (FileStream fs = File.OpenRead(path)) {
				using (BinaryReader bin = new BinaryReader(fs)) {
					uint mapCount = bin.ReadUInt32();

					for (int i = 0; i < mapCount; i++) {
						// Mapinfo
						string mapname = bin.ReadString();
						short xs = bin.ReadInt16();
						short ys = bin.ReadInt16();
						int len = bin.ReadInt32();

						encodedBuf = bin.ReadBytes(len);
						decodedBuf = Deflate.Decompress(encodedBuf);

						// encodedBuf now contains the cell array
						mapdata.Add(mapname, new MapcacheMapData {
							Width = xs,
							Height = ys,
							CellData = decodedBuf
						});

						encodedBuf = null;
						decodedBuf = null;
					}
				}
			}

			return mapdata;
		}

	}

}
