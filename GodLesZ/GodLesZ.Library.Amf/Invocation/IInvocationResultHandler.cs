using System.Reflection;

namespace GodLesZ.Library.Amf.Invocation {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IInvocationResultHandler {
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="invocationManager"></param>
		/// <param name="memberInfo"></param>
		/// <param name="obj"></param>
		/// <param name="arguments"></param>
		/// <param name="result"></param>
		void HandleResult(IInvocationManager invocationManager, MemberInfo memberInfo, object obj, object[] arguments, object result);
	}
}
