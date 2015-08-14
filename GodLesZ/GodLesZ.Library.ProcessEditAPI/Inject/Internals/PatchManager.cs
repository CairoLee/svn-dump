using System;

using GodLesZ.Library.ProcessEditAPI.Inject.Native;

namespace GodLesZ.Library.ProcessEditAPI.Inject.Internals {

	/// <summary>
	/// A manager class to handle memory patches.
	/// </summary>
	public class PatchManager : Manager<Patch> {
		internal PatchManager( Win32 win32 )
			: base( win32 ) {
		}

		/// <summary>
		/// Creates a new <see cref="Patch"/> at the specified address.
		/// </summary>
		/// <param name="address">The address to begin the patch.</param>
		/// <param name="patchWith">The bytes to be written as the patch.</param>
		/// <param name="name">The name of the patch.</param>
		/// <returns>A patch object that exposes the required methods to apply and remove the patch.</returns>
		public Patch Create( IntPtr address, byte[] patchWith, string name ) {
#if !NOEXCEPTIONS
            if (address == IntPtr.Zero)
            {
                throw new ArgumentException("Address cannot be 0!", "address");
            }
            if (patchWith == null || patchWith.Length == 0)
            {
                throw new ArgumentNullException("patchWith", "Patch bytes cannot be null, or 0 bytes long!");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
#endif

			if( !Applications.ContainsKey( name ) )
				return new Patch( address, patchWith, name, Win32 );

			return null;
		}

		/// <summary>
		/// Creates a new <see cref="Patch"/> at the specified address, and applies it.
		/// </summary>
		/// <param name="address">The address to begin the patch.</param>
		/// <param name="patchWith">The bytes to be written as the patch.</param>
		/// <param name="name">The name of the patch.</param>
		/// <returns>A patch object that exposes the required methods to apply and remove the patch.</returns>
		public Patch CreateAndApply( IntPtr address, byte[] patchWith, string name ) {
			Patch p = Create( address, patchWith, name );
			if( p != null )
				p.Apply();

			return p;
		}
	}

	/// <summary>
	/// Contains methods, and information for a memory patch.
	/// </summary>
	public class Patch : IMemoryOperation {
		private readonly IntPtr mAddress;
		private readonly byte[] mOriginalBytes;
		private readonly byte[] mPatchBytes;
		private readonly Win32 mWin32;

		internal Patch( IntPtr address, byte[] patchWith, string name, Win32 win ) {
			Name = name;
			mWin32 = win;
			mAddress = address;
			mPatchBytes = patchWith;
			mOriginalBytes = mWin32.ReadBytes( address, patchWith.Length );
		}

		#region IMemoryOperation Members
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		public void Dispose() {
			if( IsApplied )
				Remove();

			GC.SuppressFinalize( this );
		}

		/// <summary>
		/// Removes this Patch from memory. (Reverts the bytes back to their originals.)
		/// </summary>
		/// <returns></returns>
		public bool Remove() {
			if( mWin32.WriteBytes( mAddress, mOriginalBytes ) == mOriginalBytes.Length ) {
				IsApplied = false;
				return true;
			}
			return false;
		}

		/// <summary>
		/// Applies this Patch to memory. (Writes new bytes to memory)
		/// </summary>
		/// <returns></returns>
		public bool Apply() {
			if( mWin32.WriteBytes( mAddress, mPatchBytes ) == mPatchBytes.Length ) {
				IsApplied = true;
				return true;
			}
			return false;
		}

		/// <summary>
		/// Returns true if this Patch is currently applied.
		/// </summary>
		public bool IsApplied {
			get;
			private set;
		}

		/// <summary>
		/// Returns the name for this Patch.
		/// </summary>
		public string Name {
			get;
			private set;
		}
		#endregion

		/// <summary>
		/// Allows an <see cref="T:System.Object"/> to attempt to free resources and perform other cleanup operations before the <see cref="T:System.Object"/> is reclaimed by garbage collection.
		/// </summary>
		~Patch() {
			Dispose();
		}

	}

}