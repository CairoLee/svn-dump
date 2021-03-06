
using GodLesZ.Library.Amf.AMF3;

namespace GodLesZ.Library.Amf.IO.Bytecode {
	/// <summary>
	/// Reflection optimizer interface.
	/// </summary>
	public interface IReflectionOptimizer {
		/// <summary>
		/// Performs instantiation of an instance of the underlying class.
		/// </summary>
		/// <returns>The new instance.</returns>
		object CreateInstance();
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="classDefinition"></param>
		/// <returns></returns>
		object ReadData(AMFReader reader, ClassDefinition classDefinition);
	}
}
