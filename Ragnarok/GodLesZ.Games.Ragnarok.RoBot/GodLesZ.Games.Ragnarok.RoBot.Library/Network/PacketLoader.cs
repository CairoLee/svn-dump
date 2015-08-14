using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using GodLesZ.Library.Network.Packets;

namespace GodLesZ.Games.Ragnarok.RoBot.Library.Network {

	public class PacketLoader {
		private string mFilepath;
		private PacketList mPackets;


		public PacketLoader()
			: this(null) {
		}

		public PacketLoader(string filepath) {
			mFilepath = filepath;
			if (String.IsNullOrEmpty(mFilepath) == false) {
				LoadPacketDefintions();
			}
		}


		public bool LoadPacketDefintions() {

			if (File.Exists(mFilepath) == false) {
				ServerConsole.WriteLine(GodLesZ.Library.EConsoleColor.Error, "failed, file not found!");
				return false;
			}

			var xml = new XmlSerializer(typeof(PacketList));
			using (Stream fs = File.OpenRead(mFilepath)) {
				mPackets = (PacketList)xml.Deserialize(fs);
			}

			// TODO: Make a defaul packet version, holding base definitions
			//		 and let them be overritten from higher versions


			// Load all types from script assemblies
			//List<Type> scriptTypes = new List<Type>();
			/*
			foreach (Assembly asm in Scripting.ScriptCompiler.Assemblies) {
				scriptTypes.AddRange(asm.GetTypes());
			}
			*/
			Assembly lookupAsm = Assembly.GetExecutingAssembly();

			// Attach all packet handlers
			foreach (PacketVersion packets in mPackets) {
				foreach (PacketDefinition p in packets.Packets) {
					string asmName = string.Format("GodLesZ.Library.Network.Packets.{0}", p.HandlerType);
					/*
					foreach (Type type in scriptTypes) {
						if (type.FullName == asmName) {
							MethodInfo info = type.GetMethod(p.HandlerName, BindingFlags.Public | BindingFlags.Static);
							Delegate dele = Delegate.CreateDelegate(typeof(OnPacketReceive), info);
							PacketHandlers.Register(p.ID, p.Length, (OnPacketReceive)dele);
							
							found = true;
							break;
						}
					}
					*/
					var t = lookupAsm.GetType(asmName);
					if (t != null) {
						var info = t.GetMethod(p.HandlerName, BindingFlags.Public | BindingFlags.Static);
						if (info == null) {
							ServerConsole.ErrorLine("Unable to find Packet handler for definition: {0}.{1}", p.HandlerType, p.HandlerName);
							continue;
						}
						var dele = Delegate.CreateDelegate(typeof(OnPacketReceive), info);
						PacketHandlers.Register(p.HandlerName, p.ID, p.Length, (OnPacketReceive)dele);
					} else {
						ServerConsole.ErrorLine("Unable to find Packet handler for definition: {0}.{1}", p.HandlerType, p.HandlerName);
					}
				}
			}

			return true;
		}
	}

}
