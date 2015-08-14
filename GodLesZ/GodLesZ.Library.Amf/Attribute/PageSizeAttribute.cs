using System;

namespace GodLesZ.Library.Amf {
	/// <summary>
	/// Indicates that the result of a service method is pageable recordset.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PageSizeAttribute : System.Attribute {
		int _pageSize;
		int _offset;
		int _limit;

		/// <summary>
		/// Initializes a new instance of the PageSizeAttribute class.
		/// </summary>
		/// <param name="pageSize">The number of records requested each time.</param>
		public PageSizeAttribute(int pageSize) {
			_pageSize = pageSize;
			_offset = 0;
			_limit = 25;
		}
		/// <summary>
		/// Initializes a new instance of the PageSizeAttribute class.
		/// </summary>
		/// <param name="pageSize">The number of records requested each time.</param>
		/// <param name="offset">The offset of the first row to return.</param>
		/// <param name="limit">The maximum number of rows to return.</param>
		public PageSizeAttribute(int pageSize, int offset, int limit) {
			_pageSize = pageSize;
			_offset = offset;
			_limit = limit;
		}
		/// <summary>
		/// Gets the page size (number of records requested each time).
		/// </summary>
		public int PageSize {
			get { return _pageSize; }
		}
		/// <summary>
		/// Gets the offset of the first row to return.
		/// </summary>
		public int Offset {
			get { return _offset; }
		}
		/// <summary>
		/// Gets the maximum number of rows to return.
		/// </summary>
		public int Limit {
			get { return _limit; }
		}
	}
}
