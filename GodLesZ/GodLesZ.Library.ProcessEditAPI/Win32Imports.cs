using System;
using System.Text;
using System.Runtime.InteropServices;

namespace GodLesZ.Library.ProcessEditAPI {

	/// <summary>
	/// Values to gain required access to process or thread.
	/// </summary>
	public static class AccessRights {
		/// <summary>
		/// Standard rights required to mess with an object's security descriptor, change, or delete the object.
		/// </summary>
		public const uint STANDARD_RIGHTS_REQUIRED = 0x000F0000;
		/// <summary>
		/// The right to use the object for synchronization. This enables a thread to wait until the object is in the signaled state. Some object types do not support this access right.
		/// </summary>
		public const uint SYNCHRONIZE = 0x00100000;

		/// <summary>
		/// Required to terminate a process using TerminateProcess.
		/// </summary>
		public const uint PROCESS_TERMINATE = 0x0001;
		/// <summary>
		/// Required to create a thread.
		/// </summary>
		public const uint PROCESS_CREATE_THREAD = 0x0002;
		//public const uint PROCESS_SET_SESSIONID = 0x0004;
		/// <summary>
		/// Required to perform an operation on the address space of a process (see VirtualProtectEx and WriteProcessMemory).
		/// </summary>
		public const uint PROCESS_VM_OPERATION = 0x0008;
		/// <summary>
		/// Required to read memory in a process using ReadProcessMemory.
		/// </summary>
		public const uint PROCESS_VM_READ = 0x0010;
		/// <summary>
		/// Required to write memory in a process using WriteProcessMemory.
		/// </summary>
		public const uint PROCESS_VM_WRITE = 0x0020;
		/// <summary>
		/// Required to duplicate a handle using DuplicateHandle.
		/// </summary>
		public const uint PROCESS_DUP_HANDLE = 0x0040;
		/// <summary>
		/// Required to create a process.
		/// </summary>
		public const uint PROCESS_CREATE_PROCESS = 0x0080;
		/// <summary>
		/// Required to set memory limits using SetProcessWorkingSetSize.
		/// </summary>
		public const uint PROCESS_SET_QUOTA = 0x0100;
		/// <summary>
		/// Required to set certain information about a process, such as its priority class (see SetPriorityClass).
		/// </summary>
		public const uint PROCESS_SET_INFORMATION = 0x0200;
		/// <summary>
		/// Required to retrieve certain information about a process, such as its token, exit code, and priority class (see OpenProcessToken, GetExitCodeProcess, GetPriorityClass, and IsProcessInJob).
		/// </summary>
		public const uint PROCESS_QUERY_INFORMATION = 0x0400;
		/// <summary>
		/// Required to suspend or resume a process.
		/// </summary>
		public const uint PROCESS_SUSPEND_RESUME = 0x0800;
		/// <summary>
		/// Required to retrieve certain information about a process (see QueryFullProcessImageName). A handle that has the PROCESS_QUERY_INFORMATION access right is automatically granted PROCESS_QUERY_LIMITED_INFORMATION.
		/// </summary>
		public const uint PROCESS_QUERY_LIMITED_INFORMATION = 0x1000;

		/// <summary>
		/// All possible access rights for a process object.
		/// </summary>
		public const uint PROCESS_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFF;//0x001F0FFF on WinXP, should be changed to 0xFFFF on Vista/2k8

		/// <summary>
		/// Required to terminate a thread using TerminateThread.
		/// </summary>
		public const uint THREAD_TERMINATE = 0x0001;
		/// <summary>
		/// Required to suspend or resume a thread.
		/// </summary>
		public const uint THREAD_SUSPEND_RESUME = 0x0002;
		/// <summary>
		/// Required to read the context of a thread using <see cref="Imports.GetThreadContext"/>
		/// </summary>
		public const uint THREAD_GET_CONTEXT = 0x0008;
		/// <summary>
		/// Required to set the context of a thread using <see cref="Imports.SetThreadContext"/>
		/// </summary>
		public const uint THREAD_SET_CONTEXT = 0x0010;
		/// <summary>
		/// Required to read certain information from the thread object, such as the exit code (see GetExitCodeThread).
		/// </summary>
		public const uint THREAD_QUERY_INFORMATION = 0x0040;
		/// <summary>
		/// Required to set certain information in the thread object.
		/// </summary>
		public const uint THREAD_SET_INFORMATION = 0x0020;
		/// <summary>
		/// Required to set the impersonation token for a thread using SetThreadToken.
		/// </summary>
		public const uint THREAD_SET_THREAD_TOKEN = 0x0080;
		/// <summary>
		/// Required to use a thread's security information directly without calling it by using a communication mechanism that provides impersonation services.
		/// </summary>
		public const uint THREAD_IMPERSONATE = 0x0100;
		/// <summary>
		/// Required for a server thread that impersonates a client.
		/// </summary>
		public const uint THREAD_DIRECT_IMPERSONATION = 0x0200;

		/// <summary>
		/// All possible access rights for a thread object.
		/// </summary>
		public const uint THREAD_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0x3FF;
	}

	/// <summary>
	/// Values that determine how memory is allocated.
	/// </summary>
	public static class MemoryAllocType {
		/// <summary>
		/// Allocates physical storage in memory or in the paging file on disk for the specified reserved memory pages. The function initializes the memory to zero. 
		///
		///To reserve and commit pages in one step, call VirtualAllocEx with MEM_COMMIT | MEM_RESERVE.
		///
		///The function fails if you attempt to commit a page that has not been reserved. The resulting error code is ERROR_INVALID_ADDRESS.
		///
		///An attempt to commit a page that is already committed does not cause the function to fail. This means that you can commit pages without first determining the current commitment state of each page.
		/// </summary>
		public const uint MEM_COMMIT = 0x00001000;

		/// <summary>
		/// Reserves a range of the process's virtual address space without allocating any actual physical storage in memory or in the paging file on disk.
		///
		///You commit reserved pages by calling VirtualAllocEx again with MEM_COMMIT.
		/// </summary>
		public const uint MEM_RESERVE = 0x00002000;

		/// <summary>
		/// Indicates that data in the memory range specified by lpAddress and dwSize is no longer of interest. The pages should not be read from or written to the paging file. However, the memory block will be used again later, so it should not be decommitted. This value cannot be used with any other value.
		///
		///Using this value does not guarantee that the range operated on with MEM_RESET will contain zeroes. If you want the range to contain zeroes, decommit the memory and then recommit it.
		/// </summary>
		public const uint MEM_RESET = 0x00080000;

		/// <summary>
		/// Reserves an address range that can be used to map Address Windowing Extensions (AWE) pages.
		///
		///This value must be used with MEM_RESERVE and no other values.
		/// </summary>
		public const uint MEM_PHYSICAL = 0x00400000;

		/// <summary>
		/// Allocates memory at the highest possible address. 
		/// </summary>
		public const uint MEM_TOP_DOWN = 0x00100000;
	}

	/// <summary>
	/// Values that determine how a block of memory is protected.
	/// </summary>
	public static class MemoryProtectType {
		/// <summary>
		/// Enables execute access to the committed region of pages. An attempt to read or write to the committed region results in an access violation. 
		/// </summary>
		public const uint PAGE_EXECUTE = 0x10;
		/// <summary>
		/// Enables execute and read access to the committed region of pages. An attempt to write to the committed region results in an access violation. 
		/// </summary>
		public const uint PAGE_EXECUTE_READ = 0x20;
		/// <summary>
		/// Enables execute, read, and write access to the committed region of pages. 
		/// </summary>
		public const uint PAGE_EXECUTE_READWRITE = 0x40;
		/// <summary>
		/// Enables execute, read, and write access to the committed region of image file code pages. The pages are shared read-on-write and copy-on-write. 
		/// </summary>
		public const uint PAGE_EXECUTE_WRITECOPY = 0x80;

		/// <summary>
		/// Disables all access to the committed region of pages. An attempt to read from, write to, or execute the committed region results in an access violation exception, called a general protection (GP) fault. 
		/// </summary>
		public const uint PAGE_NOACCESS = 0x01;
		/// <summary>
		/// Enables read access to the committed region of pages. An attempt to write to the committed region results in an access violation. If the system differentiates between read-only access and execute access, an attempt to execute code in the committed region results in an access violation.
		/// </summary>
		public const uint PAGE_READONLY = 0x02;
		/// <summary>
		/// Enables both read and write access to the committed region of pages.
		/// </summary>
		public const uint PAGE_READWRITE = 0x04;
		/// <summary>
		/// Gives copy-on-write protection to the committed region of pages. 
		/// </summary>
		public const uint PAGE_WRITECOPY = 0x08;

		/// <summary>
		///Pages in the region become guard pages. Any attempt to access a guard page causes the system to raise a STATUS_GUARD_PAGE_VIOLATION exception and turn off the guard page status. Guard pages thus act as a one-time access alarm. For more information, see Creating Guard Pages.
		///
		///When an access attempt leads the system to turn off guard page status, the underlying page protection takes over.
		///
		///If a guard page exception occurs during a system service, the service typically returns a failure status indicator.
		///
		///This value cannot be used with PAGE_NOACCESS.
		/// </summary>
		public const uint PAGE_GUARD = 0x100;
		/// <summary>
		/// Does not allow caching of the committed regions of pages in the CPU cache. The hardware attributes for the physical memory should be specified as "no cache." This is not recommended for general usage. It is useful for device drivers, for example, mapping a video frame buffer with no caching.
		///
		///This value cannot be used with PAGE_NOACCESS.
		/// </summary>
		public const uint PAGE_NOCACHE = 0x200;
		/// <summary>
		/// Enables write-combined memory accesses. When enabled, the processor caches memory write requests to optimize performance. Thus, if two requests are made to write to the same memory address, only the more recent write may occur.
		///
		///Note that the PAGE_GUARD and PAGE_NOCACHE flags cannot be specified with PAGE_WRITECOMBINE. If an attempt is made to do so, the SYSTEM_INVALID_PAGE_PROTECTION NT error code is returned by the function.
		/// </summary>
		public const uint PAGE_WRITECOMBINE = 0x400;
	}

	/// <summary>
	/// Values that determine how a block of memory is freed.
	/// </summary>
	public static class MemoryFreeType {
		/// <summary>
		/// Decommits the specified region of committed pages. After the operation, the pages are in the reserved state.
		///
		///The function does not fail if you attempt to decommit an uncommitted page. This means that you can decommit a range of pages without first determining their current commitment state.
		///
		///Do not use this value with MEM_RELEASE.
		/// </summary>
		public const uint MEM_DECOMMIT = 0x4000;

		/// <summary>
		/// Releases the specified region of pages. After the operation, the pages are in the free state.
		///
		/// If you specify this value, dwSize must be 0 (zero), and lpAddress must point to the base address returned by the VirtualAllocEx function when the region is reserved. The function fails if either of these conditions is not met.
		///
		/// If any pages in the region are committed currently, the function first decommits, and then releases them.
		///
		/// The function does not fail if you attempt to release pages that are in different states, some reserved and some committed. This means that you can release a range of pages without first determining the current commitment state.
		///
		/// Do not use this value with MEM_DECOMMIT.
		/// </summary>
		public const uint MEM_RELEASE = 0x8000;
	}

	/// <summary>
	/// Values which determine the state or creation-state of a thread.
	/// </summary>
	public static class ThreadFlags {
		/// <summary>
		/// The thread will execute immediately.
		/// </summary>
		public const uint THREAD_EXECUTE_IMMEDIATELY = 0;
		/// <summary>
		/// The thread will be created in a suspended state.  Use <see cref="Imports.ResumeThread"/> to resume the thread.
		/// </summary>
		public const uint CREATE_SUSPENDED = 0x04;
		/// <summary>
		/// The dwStackSize parameter specifies the initial reserve size of the stack. If this flag is not specified, dwStackSize specifies the commit size.
		/// </summary>
		public const uint STACK_SIZE_PARAM_IS_A_RESERVATION = 0x00010000;
		/// <summary>
		/// The thread is still active.
		/// </summary>
		public const uint STILL_ACTIVE = 259;
	}

	/// <summary>
	/// Values that determine the wait status of an object (thread, mutex, event, etc.).
	/// </summary>
	public static class WaitValues {
		/// <summary>
		/// The object is in a signaled state.
		/// </summary>
		public const uint WAIT_OBJECT_0 = 0x00000000;
		/// <summary>
		/// The specified object is a mutex object that was not released by the thread that owned the mutex object before the owning thread terminated. Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.
		/// </summary>
		public const uint WAIT_ABANDONED = 0x00000080;
		/// <summary>
		/// The time-out interval elapsed, and the object's state is nonsignaled.
		/// </summary>
		public const uint WAIT_TIMEOUT = 0x00000102;
		/// <summary>
		/// The wait has failed.
		/// </summary>
		public const uint WAIT_FAILED = 0xFFFFFFFF;
		/// <summary>
		/// Wait an infinite amount of time for the object to become signaled.
		/// </summary>
		public const uint INFINITE = 0xFFFFFFFF;
	}

	/// <summary>
	/// Determines which registers are returned or set when using <see cref="Imports.GetThreadContext"/> or <see cref="Imports.SetThreadContext"/>.
	/// </summary>
	public static class CONTEXT_FLAGS {
		private const uint CONTEXT_i386 = 0x00010000;
		private const uint CONTEXT_i486 = 0x00010000;

		/// <summary>
		/// SS:SP, CS:IP, FLAGS, BP
		/// </summary>
		public const uint CONTEXT_CONTROL = (CONTEXT_i386 | 0x01);
		/// <summary>
		/// AX, BX, CX, DX, SI, DI
		/// </summary>
		public const uint CONTEXT_INTEGER = (CONTEXT_i386 | 0x02);
		/// <summary>
		/// DS, ES, FS, GS
		/// </summary>
		public const uint CONTEXT_SEGMENTS = (CONTEXT_i386 | 0x04);
		/// <summary>
		/// 387 state
		/// </summary>
		public const uint CONTEXT_FLOATING_POINT = (CONTEXT_i386 | 0x08);
		/// <summary>
		/// DB 0-3,6,7
		/// </summary>
		public const uint CONTEXT_DEBUG_REGISTERS = (CONTEXT_i386 | 0x10);
		/// <summary>
		/// cpu specific extensions
		/// </summary>
		public const uint CONTEXT_EXTENDED_REGISTERS = (CONTEXT_i386 | 0x20);

		/// <summary>
		/// Everything but extended information and debug registers.
		/// </summary>
		public const uint CONTEXT_FULL = (CONTEXT_CONTROL | CONTEXT_INTEGER | CONTEXT_SEGMENTS);

		/// <summary>
		/// Everything.
		/// </summary>
		public const uint CONTEXT_ALL = (CONTEXT_CONTROL | CONTEXT_INTEGER | CONTEXT_SEGMENTS | CONTEXT_FLOATING_POINT | CONTEXT_DEBUG_REGISTERS | CONTEXT_EXTENDED_REGISTERS);
	}

	/// <summary>
	/// Returned if <see cref="CONTEXT_FLAGS.CONTEXT_FLOATING_POINT"/> flag is specified.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct FLOATING_SAVE_AREA {
		/// <summary>
		/// None.
		/// </summary>
		public uint ControlWord;
		/// <summary>
		/// None.
		/// </summary>
		public uint StatusWord;
		/// <summary>
		/// None.
		/// </summary>
		public uint TagWord;
		/// <summary>
		/// None.
		/// </summary>
		public uint ErrorOffset;
		/// <summary>
		/// None.
		/// </summary>
		public uint ErrorSelector;
		/// <summary>
		/// None.
		/// </summary>
		public uint DataOffset;
		/// <summary>
		/// None.
		/// </summary>
		public uint DataSelector;
		/// <summary>
		/// None.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
		public byte[] RegisterArea;
		/// <summary>
		/// None.
		/// </summary>
		public uint Cr0NpxState;
	}

	/// <summary>
	/// Used for getting or setting a thread's context.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct CONTEXT {
		///<summary>
		/// The flags values within this flag control the contents of a CONTEXT record.
		///
		/// If the context record is used as an input parameter, then for each portion of the context record controlled by a flag whose value is set, it is assumed that that portion of the context record contains valid context. If the context record is being used to modify a threads context, then only that portion of the threads context will be modified.
		///
		/// If the context record is used as an IN OUT parameter to capture the context of a thread, then only those portions of the thread's context corresponding to set flags will be returned.
		///
		/// The context record is never used as an OUT only parameter.
		/// </summary>
		public uint ContextFlags;


		/// <summary>
		/// Specified/returned if <see cref="CONTEXT_FLAGS.CONTEXT_DEBUG_REGISTERS"/> flag is set.
		/// </summary>
		public uint Dr0;
		/// <summary>
		/// Specified/returned if <see cref="CONTEXT_FLAGS.CONTEXT_DEBUG_REGISTERS"/> flag is set.
		/// </summary>
		public uint Dr1;
		/// <summary>
		/// Specified/returned if <see cref="CONTEXT_FLAGS.CONTEXT_DEBUG_REGISTERS"/> flag is set.
		/// </summary>
		public uint Dr2;
		/// <summary>
		/// Specified/returned if <see cref="CONTEXT_FLAGS.CONTEXT_DEBUG_REGISTERS"/> flag is set.
		/// </summary>
		public uint Dr3;
		/// <summary>
		/// Specified/returned if <see cref="CONTEXT_FLAGS.CONTEXT_DEBUG_REGISTERS"/> flag is set.
		/// </summary>
		public uint Dr6;
		/// <summary>
		/// Specified/returned if <see cref="CONTEXT_FLAGS.CONTEXT_DEBUG_REGISTERS"/> flag is set.
		/// </summary>
		public uint Dr7;


		/// <summary>
		/// This section is specified/returned if the ContextFlags word contians the flag CONTEXT_FLOATING_POINT.
		/// </summary>
		[MarshalAs(UnmanagedType.Struct)]
		public FLOATING_SAVE_AREA FloatSave;


		/// <summary>
		/// This is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_SEGMENTS"/>.
		/// </summary>
		public uint SegGs;
		/// <summary>
		/// This is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_SEGMENTS"/>.
		/// </summary>
		public uint SegFs;
		/// <summary>
		/// This is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_SEGMENTS"/>.
		/// </summary>
		public uint SegEs;
		/// <summary>
		/// This is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_SEGMENTS"/>.
		/// </summary>
		public uint SegDs;


		/// <summary>
		/// This register is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_INTEGER"/>.
		/// </summary>
		public uint Edi;
		/// <summary>
		/// This register is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_INTEGER"/>.
		/// </summary>
		public uint Esi;
		/// <summary>
		/// This register is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_INTEGER"/>.
		/// </summary>
		public uint Ebx;
		/// <summary>
		/// This register is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_INTEGER"/>.
		/// </summary>
		public uint Edx;
		/// <summary>
		/// This register is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_INTEGER"/>.
		/// </summary>
		public uint Ecx;
		/// <summary>
		/// This register is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_INTEGER"/>.
		/// </summary>
		public uint Eax;


		/// <summary>
		/// This register is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_CONTROL"/>.
		/// </summary>
		public uint Ebp;
		/// <summary>
		/// This register is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_CONTROL"/>.
		/// </summary>
		public uint Eip;
		/// <summary>
		/// This register is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_CONTROL"/>.
		/// </summary>
		public uint SegCs;
		/// <summary>
		/// This register is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_CONTROL"/>.
		/// </summary>
		public uint EFlags;
		/// <summary>
		/// This register is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_CONTROL"/>.
		/// </summary>
		public uint Esp;
		/// <summary>
		/// This register is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_CONTROL"/>.
		/// </summary>
		public uint SegSs;


		/// <summary>
		/// This section is specified/returned if the ContextFlags word contains the flag <see cref="CONTEXT_FLAGS.CONTEXT_EXTENDED_REGISTERS"/>.  The format and contexts are processor specific.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
		public byte[] ExtendedRegisters;
	}

	/// <summary>
	/// Virtual Keys
	/// </summary>
	public enum EVirtualKeyStates : int {
		VK_LBUTTON = 0x01,
		VK_RBUTTON = 0x02,
		VK_CANCEL = 0x03,
		VK_MBUTTON = 0x04,
		//
		VK_XBUTTON1 = 0x05,
		VK_XBUTTON2 = 0x06,
		//
		VK_BACK = 0x08,
		VK_TAB = 0x09,
		//
		VK_CLEAR = 0x0C,
		VK_RETURN = 0x0D,
		//
		VK_SHIFT = 0x10,
		VK_CONTROL = 0x11,
		VK_MENU = 0x12,
		VK_PAUSE = 0x13,
		VK_CAPITAL = 0x14,
		//
		VK_KANA = 0x15,
		VK_HANGEUL = 0x15, /* old name - should be here for compatibility */
		VK_HANGUL = 0x15,
		VK_JUNJA = 0x17,
		VK_FINAL = 0x18,
		VK_HANJA = 0x19,
		VK_KANJI = 0x19,
		//
		VK_ESCAPE = 0x1B,
		//
		VK_CONVERT = 0x1C,
		VK_NONCONVERT = 0x1D,
		VK_ACCEPT = 0x1E,
		VK_MODECHANGE = 0x1F,
		//
		VK_SPACE = 0x20,
		VK_PRIOR = 0x21,
		VK_NEXT = 0x22,
		VK_END = 0x23,
		VK_HOME = 0x24,
		VK_LEFT = 0x25,
		VK_UP = 0x26,
		VK_RIGHT = 0x27,
		VK_DOWN = 0x28,
		VK_SELECT = 0x29,
		VK_PRINT = 0x2A,
		VK_EXECUTE = 0x2B,
		VK_SNAPSHOT = 0x2C,
		VK_INSERT = 0x2D,
		VK_DELETE = 0x2E,
		VK_HELP = 0x2F,
		//
		VK_0 = 0x30, //0 key
		VK_1 = 0x31, //1 key
		VK_2 = 0x32, //2 key
		VK_3 = 0x33, //3 key
		VK_4 = 0x34, //4 key
		VK_5 = 0x35, //5 key
		VK_6 = 0x36, //6 key
		VK_7 = 0x37, //7 key
		VK_8 = 0x38, //8 key
		VK_9 = 0x39, //9 key
		VK_A = 0x41, //A key
		VK_B = 0x42, //B key
		VK_C = 0x43, //C key
		VK_D = 0x44, //D key
		VK_E = 0x45, //E key
		VK_F = 0x46, //F key
		VK_G = 0x47, //G key
		VK_H = 0x48, //H key
		VK_I = 0x49, //I key
		VK_J = 0x4A, //J key
		VK_K = 0x4B, //K key
		VK_L = 0x4C, //L key
		VK_M = 0x4D, //M key
		VK_N = 0x4E, //N key
		VK_O = 0x4F, //O key
		VK_P = 0x50, //P key
		VK_Q = 0x51, //Q key
		VK_R = 0x52, //R key
		VK_S = 0x53, //S key
		VK_T = 0x54, //T key
		VK_U = 0x55, //U key
		VK_V = 0x56, //V key
		VK_W = 0x57, //W key
		VK_X = 0x58, //X key
		VK_Y = 0x59, //Y key
		VK_Z = 0x5A, //Z key
		//
		VK_LWIN = 0x5B,
		VK_RWIN = 0x5C,
		VK_APPS = 0x5D,
		//
		VK_SLEEP = 0x5F,
		//
		VK_NUMPAD0 = 0x60,
		VK_NUMPAD1 = 0x61,
		VK_NUMPAD2 = 0x62,
		VK_NUMPAD3 = 0x63,
		VK_NUMPAD4 = 0x64,
		VK_NUMPAD5 = 0x65,
		VK_NUMPAD6 = 0x66,
		VK_NUMPAD7 = 0x67,
		VK_NUMPAD8 = 0x68,
		VK_NUMPAD9 = 0x69,
		VK_MULTIPLY = 0x6A,
		VK_ADD = 0x6B,
		VK_SEPARATOR = 0x6C,
		VK_SUBTRACT = 0x6D,
		VK_DECIMAL = 0x6E,
		VK_DIVIDE = 0x6F,
		VK_F1 = 0x70,
		VK_F2 = 0x71,
		VK_F3 = 0x72,
		VK_F4 = 0x73,
		VK_F5 = 0x74,
		VK_F6 = 0x75,
		VK_F7 = 0x76,
		VK_F8 = 0x77,
		VK_F9 = 0x78,
		VK_F10 = 0x79,
		VK_F11 = 0x7A,
		VK_F12 = 0x7B,
		VK_F13 = 0x7C,
		VK_F14 = 0x7D,
		VK_F15 = 0x7E,
		VK_F16 = 0x7F,
		VK_F17 = 0x80,
		VK_F18 = 0x81,
		VK_F19 = 0x82,
		VK_F20 = 0x83,
		VK_F21 = 0x84,
		VK_F22 = 0x85,
		VK_F23 = 0x86,
		VK_F24 = 0x87,
		//
		VK_NUMLOCK = 0x90,
		VK_SCROLL = 0x91,
		//
		VK_OEM_NEC_EQUAL = 0x92, // '=' key on numpad
		//
		VK_OEM_FJ_JISHO = 0x92, // 'Dictionary' key
		VK_OEM_FJ_MASSHOU = 0x93, // 'Unregister word' key
		VK_OEM_FJ_TOUROKU = 0x94, // 'Register word' key
		VK_OEM_FJ_LOYA = 0x95, // 'Left OYAYUBI' key
		VK_OEM_FJ_ROYA = 0x96, // 'Right OYAYUBI' key
		//
		VK_LSHIFT = 0xA0,
		VK_RSHIFT = 0xA1,
		VK_LCONTROL = 0xA2,
		VK_RCONTROL = 0xA3,
		VK_LMENU = 0xA4,
		VK_RMENU = 0xA5,
		//
		VK_BROWSER_BACK = 0xA6,
		VK_BROWSER_FORWARD = 0xA7,
		VK_BROWSER_REFRESH = 0xA8,
		VK_BROWSER_STOP = 0xA9,
		VK_BROWSER_SEARCH = 0xAA,
		VK_BROWSER_FAVORITES = 0xAB,
		VK_BROWSER_HOME = 0xAC,
		//
		VK_VOLUME_MUTE = 0xAD,
		VK_VOLUME_DOWN = 0xAE,
		VK_VOLUME_UP = 0xAF,
		VK_MEDIA_NEXT_TRACK = 0xB0,
		VK_MEDIA_PREV_TRACK = 0xB1,
		VK_MEDIA_STOP = 0xB2,
		VK_MEDIA_PLAY_PAUSE = 0xB3,
		VK_LAUNCH_MAIL = 0xB4,
		VK_LAUNCH_MEDIA_SELECT = 0xB5,
		VK_LAUNCH_APP1 = 0xB6,
		VK_LAUNCH_APP2 = 0xB7,
		//
		VK_OEM_1 = 0xBA, // ';:' for US
		VK_OEM_PLUS = 0xBB, // '+' any country
		VK_OEM_COMMA = 0xBC, // ',' any country
		VK_OEM_MINUS = 0xBD, // '-' any country
		VK_OEM_PERIOD = 0xBE, // '.' any country
		VK_OEM_2 = 0xBF, // '/?' for US
		VK_OEM_3 = 0xC0, // '`~' for US
		//
		VK_OEM_4 = 0xDB, // '[{' for US
		VK_OEM_5 = 0xDC, // '|' for US
		VK_OEM_6 = 0xDD, // ']}' for US
		VK_OEM_7 = 0xDE, // ''"' for US
		VK_OEM_8 = 0xDF,
		//
		VK_OEM_AX = 0xE1, // 'AX' key on Japanese AX kbd
		VK_OEM_102 = 0xE2, // "<>" or "|" on RT 102-key kbd.
		VK_ICO_HELP = 0xE3, // Help key on ICO
		VK_ICO_00 = 0xE4, // 00 key on ICO
		//
		VK_PROCESSKEY = 0xE5,
		//
		VK_ICO_CLEAR = 0xE6,
		//
		VK_PACKET = 0xE7,
		//
		VK_OEM_RESET = 0xE9,
		VK_OEM_JUMP = 0xEA,
		VK_OEM_PA1 = 0xEB,
		VK_OEM_PA2 = 0xEC,
		VK_OEM_PA3 = 0xED,
		VK_OEM_WSCTRL = 0xEE,
		VK_OEM_CUSEL = 0xEF,
		VK_OEM_ATTN = 0xF0,
		VK_OEM_FINISH = 0xF1,
		VK_OEM_COPY = 0xF2,
		VK_OEM_AUTO = 0xF3,
		VK_OEM_ENLW = 0xF4,
		VK_OEM_BACKTAB = 0xF5,
		//
		VK_ATTN = 0xF6,
		VK_CRSEL = 0xF7,
		VK_EXSEL = 0xF8,
		VK_EREOF = 0xF9,
		VK_PLAY = 0xFA,
		VK_ZOOM = 0xFB,
		VK_NONAME = 0xFC,
		VK_PA1 = 0xFD,
		VK_OEM_CLEAR = 0xFE
	}

	public enum EMouseEvents : int {
		ABSOLUTE = 0x8000,
		LEFTDOWN = 0x0002,
		LEFTUP = 0x0004,
		MIDDLEDOWN = 0x0020,
		MIDDLEUP = 0x0040,
		MOVE = 0x0001,
		RIGHTDOWN = 0x0008,
		RIGHTUP = 0x0010
	}


	[StructLayout(LayoutKind.Sequential)]
	public struct MOUSEINPUT {
		int dx;
		int dy;
		uint mouseData;
		uint dwFlags;
		uint time;
		IntPtr dwExtraInfo;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct KEYBDINPUT {
		public ushort wVk;
		public ushort wScan;
		public uint dwFlags;
		public uint time;
		public IntPtr dwExtraInfo;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct HARDWAREINPUT {
		uint uMsg;
		ushort wParamL;
		ushort wParamH;
	}

	[StructLayout(LayoutKind.Explicit, Size = 28)]
	public struct INPUT {
		[FieldOffset(0)]
		public int type;
		[FieldOffset(4)] 
		public MOUSEINPUT mi;
		[FieldOffset(4)] 
		public KEYBDINPUT ki;
		[FieldOffset(4)] 
		public HARDWAREINPUT hi;
	}


	/// <summary>
	/// Methods imported from Win32 libraries.
	/// </summary>
	public static class Imports {
		[DllImport("user32.dll", ExactSpelling = true)]
		public static extern long mouse_event(Int32 dwFlags, Int32 dx, Int32 dy, Int32 cButtons, Int32 dwExtraInfo);

		[DllImport("user32.dll", ExactSpelling = true)]
		public static extern void SetCursorPos(Int32 x, Int32 y);


		#region Windows
		/// <summary>
		/// Callback function to be used with <see cref="Imports.EnumWindows"/>.
		/// </summary>
		/// <param name="hWnd">The window handle of the current window.</param>
		/// <param name="lParam">The parameter passed to EnumWindows.</param>
		/// <returns>To continue enumeration, the callback function must return TRUE; to stop enumeration, it must return FALSE. </returns>
		public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

		/// <summary>
		/// Enumerates all open windows.
		/// </summary>
		/// <param name="lpEnumFunc">Callback function that will be called with the window handle of each window.</param>
		/// <param name="lParam">Parameter that will be passed to the callback function.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		[DllImport("user32", EntryPoint = "EnumWindows")]
		public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);


		[DllImport("user32", EntryPoint = "GetWindowText")]
		private static extern int _GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		/// <summary>
		/// Returns the title of a window.
		/// </summary>
		/// <param name="hWnd">The window handle of the window in question.</param>
		/// <param name="nMaxCount">Maximum number of characters in the window title.</param>
		/// <returns>Returns null on failure.</returns>
		public static string GetWindowTitle(IntPtr hWnd, int nMaxCount) {
			StringBuilder s = new StringBuilder(nMaxCount);
			int Length;
			if ((Length = _GetWindowText(hWnd, s, nMaxCount)) > 0)
				return s.ToString(0, Length);
			return null;
		}

		/// <summary>
		/// Returns the title of a window.
		/// </summary>
		/// <param name="hWnd">The window handle of the window in question.</param>
		/// <returns>Returns null on failure.</returns>
		public static string GetWindowTitle(IntPtr hWnd) {
			return GetWindowTitle(hWnd, 256);
		}


		[DllImport("user32", EntryPoint = "GetClassName")]
		private static extern int _GetClassName(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		/// <summary>
		/// Gets the classname of the supplied window.
		/// </summary>
		/// <param name="hWnd">The window handle of the window in question.</param>
		/// <param name="nMaxCount">The maximum number of characters to return.</param>
		/// <returns>Returns the classname of the supplied window.</returns>
		public static string GetClassName(IntPtr hWnd, int nMaxCount) {
			StringBuilder s = new StringBuilder(nMaxCount);
			int Length;

			if ((Length = _GetClassName(hWnd, s, nMaxCount)) > 0)
				return s.ToString(0, Length);

			return null;
		}

		/// <summary>
		/// Gets the classname of the supplied window.
		/// </summary>
		/// <param name="hWnd">The window handle of the window in question.</param>
		/// <returns>Returns the classname of the supplied window.</returns>
		public static string GetClassName(IntPtr hWnd) {
			return GetClassName(hWnd, 256);
		}

		/// <summary>
		/// Determines whether a window is visible or hidden.
		/// </summary>
		/// <param name="hWnd">The window handle of the window in question.</param>
		/// <returns>Returns true if the window is visible, false if not.</returns>
		[DllImport("user32", EntryPoint = "IsWindowVisible")]
		public static extern bool IsWindowVisible(IntPtr hWnd);
		#endregion

		#region GetWindowThreadProcessId
		/// <summary>
		/// Gets the process and thread IDs associated with a given window.
		/// </summary>
		/// <param name="hWnd">The window handle of the window in question.</param>
		/// <param name="dwProcessId">[Out] The process ID of the process which created the provided window.</param>
		/// <returns>The thread ID of the process which created the provided window.</returns>
		[DllImport("user32", EntryPoint = "GetWindowThreadProcessId")]
		public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int dwProcessId);
		#endregion

		#region OpenProcess
		/// <summary>
		/// Open process for external manipulation.
		/// </summary>
		/// <param name="dwDesiredAccess">The desired access to the external program.</param>
		/// <param name="bInheritHandle">Whether or not we wish to inherit a handle.</param>
		/// <param name="dwProcessId">The unique process ID of the external program.</param>
		/// <returns>Returns a process handle used in memory manipulation.</returns>
		[DllImport("kernel32", EntryPoint = "OpenProcess")]
		public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);
		#endregion

		#region CloseHandle
		/// <summary>
		/// Closes an open object handle.
		/// </summary>
		/// <param name="hObject">The object handle we wish to close.</param>
		/// <returns>Returns non-zero if success, zero if failure.</returns>
		[DllImport("kernel32", EntryPoint = "CloseHandle")]
		public static extern bool CloseHandle(IntPtr hObject);
		#endregion

		#region ProcAddress
		/// <summary>
		/// Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
		/// </summary>
		/// <param name="lpModuleName">
		/// The name of the loaded module (either a .dll or .exe file). If the file name extension is omitted, the default library extension .dll is appended. The file name string can include a trailing point character (.) to indicate that the module name has no extension. The string does not have to specify a path. When specifying a path, be sure to use backslashes (\), not forward slashes (/). The name is compared (case independently) to the names of modules currently mapped into the address space of the calling process.
		///
		/// If this parameter is NULL, GetModuleHandle returns a handle to the file used to create the calling process (.exe file).
		/// </param>
		/// <returns>If success, returns the base address of the module; if failure, returns UIntPtr.Zero.</returns>
		[DllImport("kernel32", EntryPoint = "GetModuleHandleW")]
		public static extern UIntPtr GetModuleHandle([MarshalAs(UnmanagedType.LPWStr)] string lpModuleName);

		/// <summary>
		/// Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
		/// </summary>
		/// <param name="hModule">A handle to the DLL module that contains the function or variable.</param>
		/// <param name="lpProcName">The function or variable name, or the function's ordinal value. If this parameter is an ordinal value, it must be in the low-order word; the high-order word must be zero.</param>
		/// <returns>
		/// If the function succeeds, the return value is the address of the exported function or variable.
		/// 
		/// If the function fails, the return value is NULL (UIntPtr.Zero).
		/// </returns>
		[DllImport("kernel32")]
		public static extern UIntPtr GetProcAddress(UIntPtr hModule, [MarshalAs(UnmanagedType.LPStr)] string lpProcName);
		#endregion

		#region Read/WriteProcessMemory
		/// <summary>
		/// Reads raw bytes from another process' memory.
		/// </summary>
		/// <param name="hProcess">Handle to the external process.</param>
		/// <param name="dwAddress">Address from which to read.</param>
		/// <param name="lpBuffer">[Out] Allocated buffer into which raw bytes will be read. (Hint: Use Marshal.AllocHGlobal)</param>
		/// <param name="nSize">Number of bytes to be read.</param>
		/// <param name="lpBytesRead">[Out] Number of bytes actually read.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		[DllImport("kernel32", EntryPoint = "ReadProcessMemory")]
		public static extern bool ReadProcessMemory(IntPtr hProcess, uint dwAddress, IntPtr lpBuffer, int nSize, out int lpBytesRead);

		/// <summary>
		/// Writes raw bytes to another process' memory.
		/// </summary>
		/// <param name="hProcess">Handle to the external process.</param>
		/// <param name="dwAddress">Address to which bytes will be written.</param>
		/// <param name="lpBuffer">Unmanaged buffer that will be written to process in question.</param>
		/// <param name="nSize">Number of bytes to be written.</param>
		/// <param name="iBytesWritten">[Out] Number of bytes actually written.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		[DllImport("kernel32", EntryPoint = "WriteProcessMemory")]
		public static extern bool WriteProcessMemory(IntPtr hProcess, uint dwAddress, IntPtr lpBuffer, int nSize, out IntPtr iBytesWritten);
		#endregion

		#region AllocateFreeMemory
		/// <summary>
		/// Reserves or commits a region of memory within the virtual address space of a specified process. The function initializes the memory it allocates to zero, unless MEM_RESET is used.
		/// </summary>
		/// <param name="hProcess">The handle to a process. The function allocates memory within the virtual address space of this process.</param>
		/// <param name="dwAddress">The pointer that specifies a desired starting address for the region of pages that you want to allocate. (optional)</param>
		/// <param name="nSize">The size of the region of memory to allocate, in bytes.  If dwAddress is null, nSize is rounded up to the next page boundary.</param>
		/// <param name="dwAllocationType">The type of memory allocation. </param>
		/// <param name="dwProtect">The memory protection for the region of pages to be allocated.</param>
		/// <returns></returns>
		[DllImport("kernel32", EntryPoint = "VirtualAllocEx")]
		public static extern uint VirtualAllocEx(IntPtr hProcess, uint dwAddress, int nSize, uint dwAllocationType, uint dwProtect);

		/// <summary>
		/// Releases, decommits, or releases and decommits a region of memory within the virtual address space of a specified process.
		/// </summary>
		/// <param name="hProcess">A handle to a process. The function frees memory within the virtual address space of the process. </param>
		/// <param name="dwAddress">A pointer to the starting address of the region of memory to be freed. </param>
		/// <param name="nSize">The size of the region of memory to free, in bytes.  If the dwFreeType parameter is MEM_RELEASE, dwSize must be 0 (zero). The function frees the entire region that is reserved in the initial allocation call to VirtualAllocEx.</param>
		/// <param name="dwFreeType">The type of free operation.  See Imports.MemoryFreeType.</param>
		/// <returns>If the function succeeds, the return value is a nonzero value.  If the function fails, the return value is 0 (zero).</returns>
		[DllImport("kernel32", EntryPoint = "VirtualFreeEx")]
		public static extern bool VirtualFreeEx(IntPtr hProcess, uint dwAddress, int nSize, uint dwFreeType);
		#endregion

		#region Thread
		/// <summary>
		/// Creates a thread that runs in the virtual address space of another process.
		/// </summary>
		/// <param name="hProcess">A handle to the process in which the thread is to be created.</param>
		/// <param name="lpThreadAttributes">A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new thread and determines whether child processes can inherit the returned handle. If lpThreadAttributes is NULL, the thread gets a default security descriptor and the handle cannot be inherited.</param>
		/// <param name="dwStackSize">The initial size of the stack, in bytes. The system rounds this value to the nearest page. If this parameter is 0 (zero), the new thread uses the default size for the executable.</param>
		/// <param name="lpStartAddress">A pointer to the application-defined function of type LPTHREAD_START_ROUTINE to be executed by the thread and represents the starting address of the thread in the remote process. The function must exist in the remote process.</param>
		/// <param name="lpParameter">A pointer to a variable to be passed to the thread function.</param>
		/// <param name="dwCreationFlags">The flags that control the creation of the thread.</param>
		/// <param name="dwThreadId">A pointer to a variable that receives the thread identifier.</param>
		/// <returns>If the function succeeds, the return value is a handle to the new thread.  If the function fails, the return value is IntPtr.Zero.</returns>
		[DllImport("kernel32", EntryPoint = "CreateRemoteThread")]
		public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr dwThreadId);

		/// <summary>
		/// Waits until the specified object is in the signaled state or the time-out interval elapses.
		/// </summary>
		/// <param name="hObject">A handle to the object. For a list of the object types whose handles can be specified, see the following Remarks section.</param>
		/// <param name="dwMilliseconds">The time-out interval, in milliseconds. The function returns if the interval elapses, even if the object's state is nonsignaled. If dwMilliseconds is zero, the function tests the object's state and returns immediately. If dwMilliseconds is INFINITE, the function's time-out interval never elapses.</param>
		/// <returns>If the function succeeds, the return value indicates the event that caused the function to return. If the function fails, the return value is WAIT_FAILED ((DWORD)0xFFFFFFFF).</returns>
		[DllImport("kernel32", EntryPoint = "WaitForSingleObject")]
		public static extern uint WaitForSingleObject(IntPtr hObject, uint dwMilliseconds);

		/// <summary>
		/// Retrieves the termination status of the specified thread.
		/// </summary>
		/// <param name="hThread">A handle to the thread.</param>
		/// <param name="lpExitCode">[Out] The exit code of the thread.</param>
		/// <returns>A pointer to a variable to receive the thread termination status.For more information.</returns>
		[DllImport("kernel32", EntryPoint = "GetExitCodeThread")]
		public static extern bool GetExitCodeThread(IntPtr hThread, out UIntPtr lpExitCode);

		/// <summary>
		/// Opens an existing thread object.
		/// </summary>
		/// <param name="dwDesiredAccess">The access to the thread object. This access right is checked against the security descriptor for the thread. This parameter can be one or more of the thread access rights.</param>
		/// <param name="bInheritHandle">If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.</param>
		/// <param name="dwThreadId">The identifier of the thread to be opened.</param>
		/// <returns>
		/// If the function succeeds, the return value is an open handle to the specified thread.
		/// 
		/// If the function fails, the return value is NULL.
		/// </returns>
		[DllImport("kernel32", EntryPoint = "OpenThread")]
		public static extern IntPtr OpenThread(uint dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

		/// <summary>
		/// Suspends execution of a given thread.
		/// </summary>
		/// <param name="hThread">Handle to the thread that will be suspended.</param>
		/// <returns>Returns (DWORD)-1 on failure, otherwise the suspend count of the thread.</returns>
		[DllImport("kernel32", EntryPoint = "SuspendThread")]
		public static extern uint SuspendThread(IntPtr hThread);

		/// <summary>
		/// Resumes execution of a given thread.
		/// </summary>
		/// <param name="hThread">Handle to the thread that will be suspended.</param>
		/// <returns>Returns (DWORD)-1 on failure, otherwise the previous suspend count of the thread.</returns>
		[DllImport("kernel32", EntryPoint = "ResumeThread")]
		public static extern uint ResumeThread(IntPtr hThread);

		/// <summary>
		/// Terminates the specified thread.
		/// </summary>
		/// <param name="hThread">Handle to the thread to exit.</param>
		/// <param name="dwExitCode">Exit code that will be stored in the thread object.</param>
		/// <returns>Returns zero on failure, non-zero on success.</returns>
		[DllImport("kernel32", EntryPoint = "TerminateThread")]
		public static extern uint TerminateThread(IntPtr hThread, uint dwExitCode);


		/// <summary>
		/// Gets the context of a given thread.
		/// </summary>
		/// <param name="hThread">Handle to the thread for which the context will be returned.</param>
		/// <param name="lpContext">CONTEXT structure into which context will be read</param>
		/// <returns>Returns true on success, false on failure.</returns>
		[DllImport("kernel32", EntryPoint = "GetThreadContext")]
		public static extern bool GetThreadContext(IntPtr hThread, ref CONTEXT lpContext);

		/// <summary>
		/// Sets the context of a given thread.
		/// </summary>
		/// <param name="hThread">Handle to the thread for which the context will be set.</param>
		/// <param name="lpContext">CONTEXT structure to which the thread's context will be set.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		[DllImport("kernel32", EntryPoint = "SetThreadContext")]
		public static extern bool SetThreadContext(IntPtr hThread, ref CONTEXT lpContext);
		#endregion

	}

}