using System;
using GodLesZ.Library.Amf.AMF3;
namespace GodLesZ.Library.Amf.IO.Bytecode.Lightweight {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class BytecodeProvider : IBytecodeProvider {
		public BytecodeProvider() {
		}

		#region IBytecodeProvider Members

		public IReflectionOptimizer GetReflectionOptimizer(Type type, ClassDefinition classDefinition, AMFReader reader, object instance) {
#if NET_1_1
            return null;

#else
			if (classDefinition == null)
				return new AMF0ReflectionOptimizer(type, reader, instance);
			else
				return new AMF3ReflectionOptimizer(type, classDefinition, reader, instance);
#endif
		}

		#endregion
	}
}
