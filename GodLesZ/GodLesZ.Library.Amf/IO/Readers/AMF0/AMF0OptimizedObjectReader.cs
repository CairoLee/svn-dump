using System;
using System.Collections;
using GodLesZ.Library.Amf.AMF3;
using GodLesZ.Library.Amf.Configuration;
using GodLesZ.Library.Amf.IO.Bytecode;
using log4net;

namespace GodLesZ.Library.Amf.IO.Readers {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class AMF0OptimizedObjectReader : IAMFReader {
		private static readonly ILog log = LogManager.GetLogger(typeof(AMF0OptimizedObjectReader));

		Hashtable _optimizedReaders;

		public AMF0OptimizedObjectReader() {
			_optimizedReaders = new Hashtable();
		}

		#region IAMFReader Members

		public object ReadData(AMFReader reader) {
			object instance = null;
			string typeIdentifier = reader.ReadString();
			if (log.IsDebugEnabled) {
				string msg = string.Format("Attempt to read custom object {0}", typeIdentifier);
				log.Debug(msg);
			}
			IReflectionOptimizer reflectionOptimizer = _optimizedReaders[typeIdentifier] as IReflectionOptimizer;
			if (reflectionOptimizer == null) {
				lock (_optimizedReaders) {
					if (!_optimizedReaders.Contains(typeIdentifier)) {
						if (log.IsDebugEnabled) {
							string msg = string.Format("Generating optimizer for type {0}", typeIdentifier);
							log.Debug(msg);
						}

						//Temporary reader
						_optimizedReaders[typeIdentifier] = new AMF0TempObjectReader();
						Type type = ObjectFactory.Locate(typeIdentifier);
						if (type != null) {
							instance = ObjectFactory.CreateInstance(type);
							reader.AddReference(instance);
							if (type != null) {
								IBytecodeProvider bytecodeProvider = null;
#if NET_1_1
								//codedom only
								if( FluorineConfiguration.Instance.OptimizerSettings != null )
									bytecodeProvider = new GodLesZ.Library.Amf.IO.Bytecode.CodeDom.BytecodeProvider();
#else
								if (FluorineConfiguration.Instance.OptimizerSettings.Provider == "codedom")
									bytecodeProvider = new GodLesZ.Library.Amf.IO.Bytecode.CodeDom.BytecodeProvider();
								if (FluorineConfiguration.Instance.OptimizerSettings.Provider == "il")
									bytecodeProvider = new GodLesZ.Library.Amf.IO.Bytecode.Lightweight.BytecodeProvider();
#endif

								reflectionOptimizer = bytecodeProvider.GetReflectionOptimizer(type, null, reader, instance);
								//Fixup
								if (reflectionOptimizer != null)
									_optimizedReaders[typeIdentifier] = reflectionOptimizer;
								else
									_optimizedReaders[typeIdentifier] = new AMF0TempObjectReader();
							}
						} else {
							if (log.IsWarnEnabled)
								log.Warn("Custom object " + typeIdentifier + " could not be loaded. An ActionScript typed object (ASObject) will be created");

							reflectionOptimizer = new AMF0TypedASObjectReader(typeIdentifier);
							_optimizedReaders[typeIdentifier] = reflectionOptimizer;
							instance = reflectionOptimizer.ReadData(reader, null);
						}
					} else {
						reflectionOptimizer = _optimizedReaders[typeIdentifier] as IReflectionOptimizer;
						instance = reflectionOptimizer.ReadData(reader, null);
					}
				}
			} else {
				instance = reflectionOptimizer.ReadData(reader, null);
			}
			return instance;
		}

		#endregion
	}

	class AMF0TempObjectReader : IReflectionOptimizer {
		#region IReflectionOptimizer Members

		public object CreateInstance() {
			throw new NotImplementedException();
		}

		public object ReadData(AMFReader reader, ClassDefinition classDefinition) {
			object amfObject = reader.ReadObject();
			return amfObject;
		}

		#endregion
	}
}
