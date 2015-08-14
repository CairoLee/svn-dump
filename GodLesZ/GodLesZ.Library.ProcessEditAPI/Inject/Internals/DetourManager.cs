using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using GodLesZ.Library.ProcessEditAPI.Inject.Native;

namespace GodLesZ.Library.ProcessEditAPI.Inject.Internals {

	/// <summary>
	/// A manager class to handle function detours, and hooks.
	/// </summary>
	public class DetourManager : Manager<Detour> {

		internal DetourManager( Win32 win32 )
			: base( win32 ) {
		}

		/// <summary>
		/// Creates a new Detour.
		/// </summary>
		/// <param name="target">The original function to detour. (This delegate should already be registered via Magic.RegisterDelegate)</param>
		/// <param name="newTarget">The new function to be called. (This delegate should NOT be registered!)</param>
		/// <param name="name">The name of the detour.</param>
		/// <returns>A <see cref="Detour"/> object containing the required methods to apply, remove, and call the original function.</returns>
		public Detour Create( Delegate target, Delegate newTarget, string name ) {
#if !NOEXCEPTIONS
			if( target == null )
				throw new ArgumentNullException( "target" );
			if( newTarget == null )
				throw new ArgumentNullException( "newTarget" );
			if( string.IsNullOrEmpty( name ) )
				throw new ArgumentNullException( "name" );
			if( !Utilities.HasUFPAttribute( target ) )
				throw new MissingAttributeException( "The target delegate does not have the proper UnmanagedFunctionPointer attribute!" );
			if( !Utilities.HasUFPAttribute( newTarget ) )
				throw new MissingAttributeException( "The new target delegate does not have the proper UnmanagedFunctionPointer attribute!" );
#endif

			if( Applications.ContainsKey( name ) )
				throw new ArgumentException( string.Format( "The {0} detour already exists!", name ), "name" );

			Detour d = new Detour( target, newTarget, name, Win32 );
			Applications.Add( name, d );
			return d;
		}
		/// <summary>
		/// Creates and applies new Detour.
		/// </summary>
		/// <param name="target">The original function to detour. (This delegate should already be registered via Magic.RegisterDelegate)</param>
		/// <param name="newTarget">The new function to be called. (This delegate should NOT be registered!)</param>
		/// <param name="name">The name of the detour.</param>
		/// <returns>A <see cref="Detour"/> object containing the required methods to apply, remove, and call the original function.</returns>
		public Detour CreateAndApply( Delegate target, Delegate newTarget, string name ) {
			Detour ret = Create( target, newTarget, name );
			if( ret != null )
				ret.Apply();

			return ret;
		}
	}

	/// <summary>
	/// Contains methods, and information for a detour, or hook.
	/// </summary>
	public class Detour : IMemoryOperation {
		private readonly IntPtr mHook;
		/// <summary>
		/// This var is not used within the detour itself. It is only here
		/// to keep a reference, to avoid the GC from collecting the delegate instance!
		/// </summary>
		private readonly Delegate mHookDelegate;
		private readonly List<byte> mNew;
		private readonly List<byte> mOrginal;
		private readonly IntPtr mTarget;
		private readonly Delegate mTargetDelegate;
		private readonly Win32 mWin32;

		internal Detour( Delegate target, Delegate hook, string name, Win32 win32 ) {
			mWin32 = win32;
			Name = name;
			mTargetDelegate = target;
			mTarget = Marshal.GetFunctionPointerForDelegate( target );
			mHookDelegate = hook;
			mHook = Marshal.GetFunctionPointerForDelegate( hook );

			//Store the orginal bytes
			mOrginal = new List<byte>();
			mOrginal.AddRange( win32.ReadBytes( mTarget, 6 ) );

			//Setup the detour bytes
			mNew = new List<byte> { 0x68 };
			byte[] tmp = BitConverter.GetBytes( mHook.ToInt32() );
			mNew.AddRange( tmp );
			mNew.Add( 0xC3 );
		}

		#region IMemoryOperation Members
		/// <summary>
		/// Returns true if this Detour is currently applied.
		/// </summary>
		public bool IsApplied {
			get;
			private set;
		}

		/// <summary>
		/// Returns the name for this Detour.
		/// </summary>
		public string Name {
			get;
			private set;
		}

		/// <summary>
		/// Applies this Detour to memory. (Writes new bytes to memory)
		/// </summary>
		/// <returns></returns>
		public bool Apply() {
			if( mWin32.WriteBytes( mTarget, mNew.ToArray() ) == mNew.Count ) {
				IsApplied = true;
				return true;
			}
			return false;
		}

		/// <summary>
		/// Removes this Detour from memory. (Reverts the bytes back to their originals.)
		/// </summary>
		/// <returns></returns>
		public bool Remove() {
			if( mWin32.WriteBytes( mTarget, mOrginal.ToArray() ) == mOrginal.Count ) {
				IsApplied = false;
				return true;
			}
			return false;
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		public void Dispose() {
			if( IsApplied )
				Remove();

			GC.SuppressFinalize( this );
		}

		#endregion

		/// <summary>
		/// Calls the original function, and returns a return value.
		/// </summary>
		/// <param name="args">The arguments to pass. If it is a 'void' argument list,
		/// you MUST pass 'null'.</param>
		/// <returns>An object containing the original functions return value.</returns>
		public object CallOriginal( params object[] args ) {
			Remove();
			object ret = mTargetDelegate.DynamicInvoke( args );
			Apply();
			return ret;
		}

		/// <summary>
		/// Allows an <see cref="T:System.Object"/> to attempt to free resources and perform other cleanup operations before the <see cref="T:System.Object"/> is reclaimed by garbage collection.
		/// </summary>
		~Detour() {
			Dispose();
		}

	}

}