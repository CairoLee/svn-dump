using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using GodLesZ.Library;
using Microsoft.CSharp;

namespace Rovolution.Server.Scripting {

	public class ScriptCompiler {
		private static List<string> mAdditionalReferences = new List<string>();

		public static Assembly[] Assemblies {
			get;
			set;
		}

		public static string Namespace {
			get;
			set;
		}


		static ScriptCompiler() {
			Namespace = "";
		}


		/// <summary>
		/// Holds the namespace for later <see cref="CallMethod"/> using and register basic events for scripts
		/// <para>Only <see cref="Events.WorldLoadFinish"/> and <see cref="Events.ServerStarted"/> will be registered</para>
		/// </summary>
		/// <param name="baseNamespace"></param>
		public static void Initialize(string baseNamespace) {
			Namespace = baseNamespace;

			// Register script events for CallMethod()
			Events.WorldLoadFinish += delegate() {
				ScriptCompiler.CallMethod("OnWorldLoadFinish");
			};
			Events.ServerStarted += delegate() {
				ScriptCompiler.CallMethod("OnServerStarted");
			};
		}


		public static void DeleteFiles(string mask) {
			try {
				string[] files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts/Output"), mask);
				foreach (string file in files) {
					try { File.Delete(file); } catch { }
				}
			} catch {
			}
		}


		public static bool Compile(string AssemblyFile, bool debug, bool cache) {
			Tools.EnsureDirectory("Scripts/");
			Tools.EnsureDirectory("Scripts/Output/");

			if (mAdditionalReferences.Count > 0)
				mAdditionalReferences.Clear();

			List<Assembly> assemblies = new List<Assembly>();
			Assembly assembly;
			if (CompileScripts(AssemblyFile, debug, cache, out assembly)) {
				if (assembly != null) {
					assemblies.Add(assembly);
				}
			} else {
				return false;
			}

			if (assemblies.Count == 0)
				return false;

			Assemblies = assemblies.ToArray();

			return true;
		}



		public static string[] GetNpcs() {
			int count = 0;
			List<string> list = new List<string>();
			ScriptEntry[] entrys = ScriptDatabase.GetType(EScriptContent.Npc);

			for (int i = 0; i < entrys.Length; i++) {
				if (entrys[i].Type != EScriptType.Path)
					continue;
				if (File.Exists(entrys[i].Path) == false) {
					ServerConsole.ErrorLine("Cant find File/Path: \"" + entrys[i].Path + "\"! Skipping...");
					continue;
				}

				list.Add(Path.Combine(Environment.CurrentDirectory, entrys[i].Path));
				ServerConsole.InfoLine("\t#{0}: \"{1}\"", (++count), entrys[i].Path);
			}

			return list.ToArray();
		}



		/// <summary>
		/// Calls a Method/Function from the <see cref="Assemblies"/>
		/// </summary>
		/// <param name="MethodName">The searched Method/Function name</param>		
		public static bool CallMethod(string MethodName) {
			return CallMethod(MethodName, null, true);
		}

		/// <summary>
		/// Calls a Method/Function from the <see cref="Assemblies"/>
		/// </summary>
		/// <param name="MethodName">The searched Method/Function name</param>		
		/// <param name="Arguments">an <see cref="object[]"/> Array which represents the Arguments</param>
		public static bool CallMethod(string MethodName, object[] Arguments) {
			return CallMethod(MethodName, Arguments, true);
		}

		/// <summary>
		/// Calls a Method/Function from the <see cref="Assemblies"/>
		/// </summary>
		/// <param name="MethodName">The searched Method/Function name</param>		
		/// <param name="Arguments">an <see cref="object[]"/> Array which represents the Arguments</param>
		/// <param name="Silent">no Error Output?</param>
		public static bool CallMethod(string MethodName, object[] Arguments, bool Silent) {
			Assembly Assembly = null;
			List<MethodInfo> invokeList = new List<MethodInfo>();
			string NamespaceName = Namespace;

			// Any assembly to call from?
			if (Assemblies == null || Assemblies.Length < 1) {
				return false;
			}

			// Search for the exact name
			// TODO: we need some sort of cache, maybe dictionary to call directly without searching
			for (int i = 0; i < Assemblies.Length; i++) {
				if ((Assembly = Assemblies[i]) == null) {
					continue;
				}

				Type[] types = Assembly.GetTypes();
				for (int t = 0; t < types.Length; t++) {
					// We only search in scripting namespace
					if (types[t].Namespace.StartsWith(NamespaceName) == false) {
						continue;
					}
					try {
						// Search a puplic and static method
						MethodInfo info = types[t].GetMethod(MethodName, BindingFlags.Static | BindingFlags.Public);
						if (info != null)
							invokeList.Add(info);
					} catch { }
				}
			}

			// Found some? Sort them by call priority (custom attribute)
			if (invokeList.Count > 0) {
				invokeList.Sort(new CallPriorityComparer());
			} else {
				if (Silent == false) {
					ServerConsole.ErrorLine("CallMethod \"{0}.{1}\" failed! Method was not found in {2} Assemblies!", NamespaceName, MethodName, Assemblies.Length);
				}
				return false;
			}

			for (int i = 0; i < invokeList.Count; i++) {
				ParameterInfo[] args = invokeList[i].GetParameters();
				MethodInvokeHelper inv = new MethodInvokeHelper(invokeList[i]);
				// Dynamic fill all arguments
				// Note: if more arguments need then given, null will be used
				if (args != null && args.Length > 0) {
					inv.MethodArguments = FillArgList(args, Arguments);
				}

				// Start a thread for every execution
				// TODO: we need some sort of logic here!
				//		 if we execute this for 100 player @ a time, 100 threads are running
				//		 might by slow and unstable..
				Thread thread = new Thread(new ThreadStart(inv.Invoke));
				thread.Name = inv.MethodInfo.Name;
				thread.Start();
			}

			// Garbage 
			invokeList.Clear();

			return true;
		}

		/// <summary>
		/// Fills an object[] Array with Agruments, taken from <see cref="ParameterInfo[] args"/>
		/// <para>Values will be taken from <see cref="object[] UserArguments"/></para>
		/// <para>If <see cref="UserArguments"/> has not enough Elements, the Value will be null</para>
		/// </summary>
		/// <param name="args"></param>
		/// <param name="UserArguments"></param>
		/// <returns>The filled Argument List</returns>
		private static object[] FillArgList(ParameterInfo[] args, object[] UserArguments) {
			// TODO: this might crash a method using multiple parameters..
			if (args.Length == 0) {
				return null;
			}

			object[] methodArgs = new object[args.Length];
			if (UserArguments == null || UserArguments.Length == 0) {
				return methodArgs;
			}

			for (int a = 0; a < methodArgs.Length; a++) {
				// Fill missing arguments with null
				// TODO: maybe check for Nullable types?
				if (a < UserArguments.Length && UserArguments[a] != null) {
					methodArgs[a] = UserArguments[a];
				} else {
					methodArgs[a] = null;
				}
			}

			return methodArgs;
		}

		#region Compile methods
		private static string[] GetReferenceAssemblies(string ConfigFile) {
			List<string> list = new List<string>();

			if (File.Exists(ConfigFile)) {
				using (StreamReader ip = new StreamReader(ConfigFile)) {
					string line;

					while ((line = ip.ReadLine()) != null) {
						if (line.Length == 0 || line.StartsWith("//"))
							continue;
						list.Add(line);
					}
				}
			} else {
				ServerConsole.ErrorLine("Script Assembie Files \"{0}\" not found!", ConfigFile);
			}

			if (Core.Assembly != null)
				list.Add(Core.Assembly.Location);
			list.AddRange(mAdditionalReferences);

			return list.ToArray();
		}

		private static string GetDefines() {
			string defines = "";

			defines += "/d:Framework_4_0 ";

			return defines.Trim();
		}

		private static byte[] GetHashCode(string compiledFile, string[] scriptFiles, bool debug) {
			using (MemoryStream ms = new MemoryStream()) {
				using (BinaryWriter bin = new BinaryWriter(ms)) {
					FileInfo fileInfo = new FileInfo(compiledFile);

					bin.Write(fileInfo.LastWriteTimeUtc.Ticks);

					foreach (string scriptFile in scriptFiles) {
						fileInfo = new FileInfo(scriptFile);

						bin.Write(fileInfo.LastWriteTimeUtc.Ticks);
					}

					bin.Write(debug);

					ms.Position = 0;

					using (SHA1 sha1 = SHA1.Create()) {
						return sha1.ComputeHash(ms);
					}
				}
			}
		}


		private static bool CompileScripts(string AssemblyFile, bool debug, bool cache, out Assembly assembly) {

			ServerConsole.InfoLine("Compile Scripts...");

			string[] files = GetNpcs();
			if (files.Length == 0) {
				ServerConsole.WriteLine(EConsoleColor.Error, "no Script found oO");
				assembly = null;
				return true;
			}

			if (File.Exists("Scripts/Output/Scripts.dll")) {
				if (cache && File.Exists("Scripts/Output/Scripts.hash")) {
					try {
						byte[] hashCode = GetHashCode("Scripts/Output/Scripts.dll", files, debug);

						using (FileStream fs = File.OpenRead("Scripts/Output/Scripts.hash")) {
							using (BinaryReader bin = new BinaryReader(fs)) {
								byte[] bytes = bin.ReadBytes(hashCode.Length);

								if (bytes.Length == hashCode.Length) {
									bool valid = true;

									for (int i = 0; i < bytes.Length; ++i) {
										if (bytes[i] != hashCode[i]) {
											valid = false;
											break;
										}
									}

									if (valid) {
										assembly = Assembly.LoadFrom("Scripts/Output/Scripts.dll");

										if (!mAdditionalReferences.Contains(assembly.Location)) {
											mAdditionalReferences.Add(assembly.Location);
										}

										ServerConsole.StatusLine("done (cached)");

										return true;
									}
								}
							}
						}
					} catch {
					}
				}
			}

			DeleteFiles("Scripts*.dll");

			var providerOptions = new Dictionary<string, string>();
			providerOptions.Add("CompilerVersion", "v4.0");

			using (CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions)) {
				string path = GetUnusedPath("Scripts");
				CompilerParameters parms = new CompilerParameters(GetReferenceAssemblies(AssemblyFile), path, debug);
				string defines = GetDefines();
				if (defines != null) {
					parms.CompilerOptions = defines;
				}
				parms.CompilerOptions = string.Format("{0} /debug /nowarn:169,219,414 /recurse:Scripts/*.cs", parms.CompilerOptions);
				parms.IncludeDebugInformation = true;
				parms.WarningLevel = 4;

				CompilerResults results = provider.CompileAssemblyFromFile(parms, files);
				Display(results);
				foreach (CompilerError e in results.Errors) {
					if (e.IsWarning == false) {
						assembly = null;
						return false;
					}
				}

				mAdditionalReferences.Add(path);

				if (cache && Path.GetFileName(path) == "Scripts.dll") {
					try {
						byte[] hashCode = GetHashCode(path, files, debug);

						using (FileStream fs = File.OpenWrite("Scripts/Output/Scripts.hash")) {
							using (BinaryWriter bin = new BinaryWriter(fs)) {
								bin.Write(hashCode, 0, hashCode.Length);
							}
						}
					} catch {
					}
				}

				assembly = results.CompiledAssembly;
				return true;
			}
		}


		private static void Display(CompilerResults results) {
			if (results.Errors.Count > 0) {
				Dictionary<string, List<CompilerError>> errors = new Dictionary<string, List<CompilerError>>(results.Errors.Count, StringComparer.OrdinalIgnoreCase);
				Dictionary<string, List<CompilerError>> warnings = new Dictionary<string, List<CompilerError>>(results.Errors.Count, StringComparer.OrdinalIgnoreCase);

				foreach (CompilerError e in results.Errors) {
					string file = e.FileName;

					if (string.IsNullOrEmpty(file)) {
						ServerConsole.ErrorLine("\n# {0}: {1}", e.ErrorNumber, e.ErrorText);
						continue;
					}

					Dictionary<string, List<CompilerError>> table = (e.IsWarning ? warnings : errors);

					List<CompilerError> list = null;
					table.TryGetValue(file, out list);

					if (list == null)
						table[file] = list = new List<CompilerError>();

					list.Add(e);
				}

				if (errors.Count > 0)
					ServerConsole.ErrorLine("failed ({0} errors, {1} warnings)", errors.Count, warnings.Count);
				else
					ServerConsole.ErrorLine("done ({0} errors, {1} warnings)", errors.Count, warnings.Count);

				string scriptRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts" + Path.DirectorySeparatorChar));
				Uri scriptRootUri = new Uri(scriptRoot);

				if (warnings.Count > 0)
					ServerConsole.WriteLine(EConsoleColor.DarkYellow, "Script Warnings:");

				foreach (KeyValuePair<string, List<CompilerError>> kvp in warnings) {
					string fileName = kvp.Key;
					List<CompilerError> list = kvp.Value;

					string fullPath = Path.GetFullPath(fileName);
					string usedPath = Uri.UnescapeDataString(scriptRootUri.MakeRelativeUri(new Uri(fullPath)).OriginalString);

					ServerConsole.WriteLine(" + {0}:", usedPath);

					foreach (CompilerError e in list)
						ServerConsole.WriteLine("\t#{0}: Line {1}/ Col {2}: {3}", e.ErrorNumber, e.Line, e.Column, e.ErrorText);
				}

				if (errors.Count > 0)
					ServerConsole.WriteLine(EConsoleColor.Error, "Script Errors:");

				foreach (KeyValuePair<string, List<CompilerError>> kvp in errors) {
					string fileName = kvp.Key;
					List<CompilerError> list = kvp.Value;

					string fullPath = Path.GetFullPath(fileName);
					string usedPath = Uri.UnescapeDataString(scriptRootUri.MakeRelativeUri(new Uri(fullPath)).OriginalString);

					ServerConsole.WriteLine(" + {0}:", usedPath);

					foreach (CompilerError e in list)
						ServerConsole.WriteLine("\t#{0}: Line {1}/ Col {2}: {3}", e.ErrorNumber, e.Line, e.Column, e.ErrorText);
				}
			} else {
				ServerConsole.StatusLine("done (0 errors, 0 warnings)");
			}
		}

		private static string GetUnusedPath(string name) {
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, String.Format("Scripts/Output/{0}.dll", name));

			for (int i = 2; File.Exists(path) && i <= 1000; ++i)
				path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, String.Format("Scripts/Output/{0}.{1}.dll", name, i));

			return path;
		}

		#endregion

	}

}
