using System;
using System.Runtime.InteropServices;

namespace GodLesZ.Library.MonoGame.Awesomium.DirectX {
	
	[ComImport, Guid("85C31227-3DE5-4f00-9B3A-F11AC38C18B5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDirect3DTexture9 {
		void GetDevice();
		void SetPrivateData();
		void GetPrivateData();
		void FreePrivateData();
		void SetPriority();
		void GetPriority();
		void PreLoad();
		void GetType();
		void SetLOD();
		void GetLOD();
		void GetLevelCount();
		void SetAutoGenFilterType();
		void GetAutoGenFilterType();
		void GenerateMipSubLevels();
		int GetLevelDesc(uint level, out D3DsurfaceDesc Desc);
		int GetSurfaceLevel(uint level, out IntPtr surfacePointer);
		int LockRect(uint level, out D3DlockedRect LockedRect, Rect rect, int Flags);
		int UnlockRect(uint level);
		int AddDirtyRect(Rect pDirtyRect);
	}

}