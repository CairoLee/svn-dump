using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ZlibDeflate = GodLesZ.Library.Ragnarok.Grf.Deflate;
using Rovolution.Server.Geometry;
using System.Runtime.Serialization.Formatters.Binary;

namespace Rovolution.Tools.MapcacheConverter {

	public class Program {
		private class MapcacheMapData {
			public short Width;
			public short Height;
			public byte[] CellData;
			public byte[] MyCellData;
		};


		public static void Main(string[] args) {
			string path = "Config/Data/map_cache.dat";
			string pathNew = "Config/Data/mapcellcache.dat";

			Console.WriteLine("Reading " + path + "..");
			Dictionary<string, MapcacheMapData> mapdata = ReadMapcache(path);

			Console.WriteLine("Writing " + pathNew + "..");
			WriteMapcache(pathNew, mapdata);
		}

		private static Dictionary<string, MapcacheMapData> ReadMapcache(string path) {
			Dictionary<string, MapcacheMapData> mapdata = new Dictionary<string, MapcacheMapData>();
			byte[] decodedBuf, encodedBuf;

			using (FileStream fs = File.OpenRead(path)) {
				using (BinaryReader bin = new BinaryReader(fs)) {
					uint fileSize = bin.ReadUInt32();
					uint mapCount = bin.ReadUInt32();

					for (int i = 0; i < mapCount; i++) {
						// Mapinfo
						char[] name = bin.ReadChars(12);
						short xs = bin.ReadInt16();
						short ys = bin.ReadInt16();
						int len = bin.ReadInt32();

						string mapname = new string(name).TrimEnd('\0');
						Console.WriteLine("\t[" + i.ToString("000") + "/" + mapCount + "] " + mapname);
						decodedBuf = bin.ReadBytes(len);
						encodedBuf = ZlibDeflate.Decompress(decodedBuf);

						// encodedBuf now contains the cell array
						mapdata.Add(mapname, new MapcacheMapData {
							Width = xs,
							Height = ys,
							CellData = encodedBuf
						});

						decodedBuf = null;
						encodedBuf = null;
					}
				}
			}

			return mapdata;
		}

		private static void WriteMapcache(string pathNew, Dictionary<string, MapcacheMapData> dataList) {
			BinaryFormatter bin = new BinaryFormatter();
			int iMap = 0;
			using (FileStream s = new FileStream(pathNew, FileMode.Create)) {
				using (BinaryWriter writer = new BinaryWriter(s)) {
					writer.Write(dataList.Count);
					foreach (KeyValuePair<string, MapcacheMapData> kvp in dataList) {
						MapcacheMapData mapData = kvp.Value;
						Console.WriteLine("\t[" + (++iMap).ToString("000") + "/" + dataList.Count + "] " + kvp.Key);

						mapData.MyCellData = new byte[mapData.Width * mapData.Height];
						for (int x = 0; x < mapData.Width; x++) {
							for (int y = 0; y < mapData.Height; y++) {
								int i = (y * mapData.Width) + x;
								ECollisionType flag = Map.ByteToFlag(mapData.CellData[i]);
								mapData.MyCellData[i] = (byte)flag;
							}
						}

						writer.Write(kvp.Key);
						writer.Write(mapData.Width);
						writer.Write(mapData.Height);

						byte[] buf = ZlibDeflate.Compress(mapData.MyCellData, true);
						writer.Write(buf.Length);
						writer.Write(buf);

						buf = null;
						mapData.MyCellData = null;
						mapData.CellData = null;

						GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
					}

				}
			}

		}

	}

}
