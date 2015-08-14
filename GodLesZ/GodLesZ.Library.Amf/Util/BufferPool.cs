namespace GodLesZ.Library.Amf.Util {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class BufferPool : ObjectPool<byte[]> {
		private readonly int _bufferSize;

		/// <summary>
		/// Initializes a new instance of the <see cref="BufferPool"/> class.
		/// </summary>
		public BufferPool()
			: this(10, 10, 4096) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BufferPool"/> class.
		/// </summary>
		/// <param name="bufferSize">Size of the buffer.</param>
		public BufferPool(int bufferSize)
			: this(10, 10, bufferSize) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BufferPool"/> class.
		/// </summary>
		/// <param name="capacity">The number of elements that the object pool object initially contains.</param>
		/// <param name="growth">The number of elements reserved in the object pool when there are no available objects.</param>
		/// <param name="bufferSize">Size of the buffer.</param>
		public BufferPool(int capacity, int growth, int bufferSize)
			: base(capacity, growth, true) {
			_bufferSize = bufferSize;
		}

		/// <summary>
		/// Creates a new buffer to be placed in the object pool.
		/// </summary>
		/// <returns>A new buffer.</returns>
		protected override byte[] GetObject() {
			return new byte[_bufferSize];
		}
	}
}