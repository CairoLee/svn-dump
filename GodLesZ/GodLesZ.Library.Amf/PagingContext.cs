using GodLesZ.Library.Amf.Context;

namespace GodLesZ.Library.Amf {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class PagingContext {
		const string FluorinePagingContextKey = "__@fluorinepagingcontext";

		int _offset;

		/// <summary>
		/// The offset of the first row to return.
		/// </summary>
		public int Offset {
			get { return _offset; }
		}

		int _limit;

		/// <summary>
		/// The maximum number of rows to return.
		/// </summary>
		public int Limit {
			get { return _limit; }
		}

		internal PagingContext(int offset, int limit) {
			_offset = offset;
			_limit = limit;
		}

		/// <summary>
		/// Gets the PagingContext object for the current request.
		/// </summary>
		static public PagingContext Current {
			get {
				return FluorineWebSafeCallContext.GetData(FluorinePagingContextKey) as PagingContext;
			}
		}

		internal static void SetPagingContext(PagingContext current) {
			FluorineWebSafeCallContext.SetData(FluorinePagingContextKey, current);
		}
	}
}
