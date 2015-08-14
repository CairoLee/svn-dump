using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GodLesZ.eAthenaEditor.Library.Script {

	/// <summary>
	/// Represents a eAthena script command
	/// </summary>
	public class ScriptCommand {
		/// <summary>
		/// Used internaly to convert the xml-stored commands to a faster useable list
		/// </summary>
		private ScriptCommandArgumentList mArguments;

		/// <summary>
		/// The command name
		/// </summary>
		[XmlAttribute()]
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// An optional second name, may be empty
		/// </summary>
		[XmlAttribute()]
		public string NameOptional {
			get;
			set;
		}

		/// <summary>
		/// A short command description
		/// </summary>
		public string Description {
			get;
			set;
		}

		/// <summary>
		/// The script command arguments stoed in the xml file
		/// <para>
		/// They will be moved to a Dictionary after set
		/// </para>
		/// </summary>
		public ScriptCommandArgumentList ArgumentList {
			get { return mArguments; }
			set {
				Arguments.Clear();
				if (value != null) {
					mArguments = value;
					foreach (ScriptCommandArgument arg in mArguments) {
						AddArgument(arg);
					}
				} else {
					mArguments = value;
				}
			}
		}

		/// <summary>
		/// The script command arguments
		/// </summary>
		[XmlIgnore]
		public Dictionary<string, ScriptCommandArgument> Arguments {
			get;
			set;
		}

		/// <summary>
		/// Returns the argument with the name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public ScriptCommandArgument this[string name] {
			get {
				if (Arguments.ContainsKey(name) == true) {
					return Arguments[name];
				}
				throw new ArgumentOutOfRangeException("name");
			}
		}


		public ScriptCommand() {
			Arguments = new Dictionary<string, ScriptCommandArgument>();
			ArgumentList = new ScriptCommandArgumentList();
		}


		public void AddArgument(ScriptCommandArgument arg) {
			if (Arguments.ContainsKey(arg.Name) == false) {
				Arguments.Add(arg.Name, arg);
			}
		}

		public void RemoveArgument(ScriptCommandArgument arg) {
			if (Arguments.ContainsKey(arg.Name) == true) {
				Arguments.Remove(arg.Name);
			}
		}


		public override string ToString() {
			return string.Format("{0}: {1} ({2} args)", Name + (NameOptional.Length > 0 ? " / " + NameOptional : ""), Description, Arguments.Count);
		}
	}

}
