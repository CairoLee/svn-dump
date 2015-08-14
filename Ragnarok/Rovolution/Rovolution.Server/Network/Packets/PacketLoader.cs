using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace Rovolution.Server.Network {

	public class PacketLoader {
		private static PacketList mPackets;


		public PacketLoader() {
			LoadPacketDefintions();
		}


		public static void Initialize() {
			ServerConsole.InfoLine("Loading packet structures..");
			if (LoadPacketDefintions() == false) {
				return;
			}

		}


		private static bool LoadPacketDefintions() {

			string filePath = "Config/Server/Packets.xml";
			if (File.Exists(filePath) == false) {
				ServerConsole.WriteLine(GodLesZ.Library.EConsoleColor.Error, "failed, file not found!");
				Core.Kill();
				return false;
			}

			XmlSerializer xml = new XmlSerializer(typeof(PacketList));
			using (Stream fs = File.OpenRead(filePath)) {
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
					string asmName = string.Format("Rovolution.Server.Network.Packets.{0}", p.HandlerType);
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
					Type t = lookupAsm.GetType(asmName);
					if (t != null) {
						MethodInfo info = t.GetMethod(p.HandlerName, BindingFlags.Public | BindingFlags.Static);
						if (info == null) {
							ServerConsole.ErrorLine("Unable to find Packet handler for definition: {0}.{1}", p.HandlerType, p.HandlerName);
							continue;
						}
						Delegate dele = Delegate.CreateDelegate(typeof(OnPacketReceive), info);
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
