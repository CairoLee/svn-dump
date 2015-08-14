using System;
using GodLesZ.Library.Amf.AMF3;
using log4net;
namespace GodLesZ.Library.Amf.IO.Bytecode.CodeDom {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class BytecodeProvider : IBytecodeProvider {
		private static readonly ILog log = LogManager.GetLogger(typeof(BytecodeProvider));

		public BytecodeProvider() {
		}

		#region IBytecodeProvider Members


		public IReflectionOptimizer GetReflectionOptimizer(Type type, ClassDefinition classDefinition, AMFReader reader, object instance) {
			if (classDefinition == null)
				return new AMF0ReflectionOptimizer(type, reader).Generate(instance);
			else
				return new AMF3ReflectionOptimizer(type, classDefinition, reader).Generate(instance);
		}

		#endregion

	}
}
