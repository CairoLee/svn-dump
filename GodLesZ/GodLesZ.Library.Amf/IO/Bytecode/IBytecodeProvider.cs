using System;

using GodLesZ.Library.Amf.AMF3;
namespace GodLesZ.Library.Amf.IO.Bytecode {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	interface IBytecodeProvider {
		IReflectionOptimizer GetReflectionOptimizer(Type type, ClassDefinition classDefinition, AMFReader reader, object instance);
	}
}
