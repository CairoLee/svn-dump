using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Network;

namespace Rovolution.Server.Scripting {

	public delegate void SerialObjectScriptHandler(DatabaseObject obj, params object[] args);

	public class SerialObjectScriptList : Dictionary<ESerialObjectScriptType, List<SerialObjectScriptHandler>> {

		public SerialObjectScriptList()
			: base() {
			// Initialize all Enum types
			foreach (object obj in Enum.GetValues(typeof(ESerialObjectScriptType))) {
				ESerialObjectScriptType k = (ESerialObjectScriptType)obj;
				this.Add(k, new List<SerialObjectScriptHandler>());
			}
		}


		/// <summary>
		/// Adds a handler for the specific type
		/// </summary>
		/// <param name="type"></param>
		/// <param name="handler"></param>
		public void AddHandler(ESerialObjectScriptType type, SerialObjectScriptHandler handler) {
			this[type].Add(handler);
		}

		/// <summary>
		/// Executes all registered Scripts/Handler for that type
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="type"></param>
		/// <param name="args"></param>
		public void Execute(DatabaseObject obj, ESerialObjectScriptType type, params object[] args) {
			if (ContainsKey(type) == false || this[type].Count == 0) {
				return;
			}

			foreach (SerialObjectScriptHandler handler in this[type]) {
				handler(obj, args);
			}

		}

	}
}
