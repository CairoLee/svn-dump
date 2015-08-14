using System;
using System.Runtime.InteropServices;

namespace GodLesZ.Library.ProcessEditAPI.Inject {

#if !NOEXCEPTIONS
	internal class Utilities {

		internal static bool HasAttrib<T>( Type item ) {
			return item.GetCustomAttributes( typeof( T ), true ).Length != 0;
		}

		internal static bool HasUFPAttribute( Delegate d ) {
			return HasUFPAttribute( d.GetType() );
		}

		internal static bool HasUFPAttribute( Type t ) {
			return HasAttrib<UnmanagedFunctionPointerAttribute>( t );
		}

	}
#endif

}