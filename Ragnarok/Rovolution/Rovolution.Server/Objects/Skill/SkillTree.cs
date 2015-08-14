using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using GodLesZ.Library;
using Rovolution.Server.Internal;

namespace Rovolution.Server.Objects {

	public class SkillTree : Dictionary<int, SkillTreeJob> {
		public static SkillTree Tree;


		public SkillTreeJob this[uint id] {
			get { return this[(int)id]; }
			set { this[(int)id] = value; }
		}


		public SkillTree() {
		}


		public static void Initialize() {
			ServerConsole.Info("\t# loading Skill Tree...");
			Stopwatch watch = Stopwatch.StartNew();

			string filepath = Core.Conf.ConfigDir + "/Database/CharacterSkillTree.xml";
			Tree = new SkillTree();

			Tree = Parser.ParseSkillTree(filepath);

			ServerConsole.WriteLine(EConsoleColor.Status, " done in " + watch.ElapsedMilliseconds + "ms");
			watch.Stop();
			watch = null;
		}

	}

}
