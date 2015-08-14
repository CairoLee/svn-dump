
namespace GodLesZ.Library.Amf.Reflection.Lightweight {
	/// <summary>
	/// A delegate to invoke the constructor of a type.
	/// </summary>
	/// <param name="parameters">An array of arguments that match in number, order, and type the parameters of the constructor to invoke.</param>
	/// <returns>A reference to the newly created object.</returns>
	public delegate object ConstructorInvoker(params object[] parameters);
}
