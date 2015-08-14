using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Awesomium.Core;
using GodLesZ.Library.MonoGame.Awesomium.DirectX;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.MonoGame.Awesomium {

	public static class TextureFormatConverter {

		public static unsafe void DirectBlit(BitmapSurface buffer, ref Texture2D texture2D) {
			//TODO : Test if d3dt can be cached
			var d3Dt = GetIUnknownObject<IDirect3DTexture9>(texture2D);
			//XE.Performance.Log("IDirect3DTexture9 Is "+(d3dt!=null ? d3dt.ToString():"null"));

			//D3DSURFACE_DESC desc=new D3DSURFACE_DESC();
			//Marshal.ThrowExceptionForHR(d3dt.GetLevelDesc(0, out desc));
			//XE.Performance.Log("LevelDesc Format "+desc.Format.ToString());
			//XE.Performance.Log("LevelDesc MultiSampleQuality "+desc.MultiSampleQuality.ToString());
			//XE.Performance.Log("LevelDesc MultiSampleType "+desc.MultiSampleType.ToString());
			//XE.Performance.Log("LevelDesc Pool "+desc.Pool.ToString());
			//XE.Performance.Log("LevelDesc Type "+desc.Type.ToString());
			//XE.Performance.Log("LevelDesc Usage "+desc.Usage.ToString());
			//XE.Performance.Log("LevelDesc Width "+desc.Width.ToString());
			//XE.Performance.Log("LevelDesc Height "+desc.Height.ToString());

			D3DlockedRect lockrect;
			var rect = new Rect();
			Marshal.ThrowExceptionForHR(d3Dt.LockRect(0, out  lockrect, rect, 0));
			//XE.Performance.Log("LockRect Pitch "+lockrect.Pitch.ToString());
			//XE.Performance.Log("LockRect pBits "+((uint)lockrect.pBits).ToString());

			//buffer.CopyTo(destBuffer, destRowSpan, destDepth, convertoRGBA, flipY);

			buffer.CopyTo((IntPtr)(uint)(lockrect.pBits), lockrect.Pitch, 4, false, false);
			d3Dt.UnlockRect(0);

			//Meve onto Dispose() if d3dt will be cached d3dt
			Marshal.ReleaseComObject(d3Dt);
		}

		private static T GetIUnknownObject<T>(object container) {
			unsafe {
				//Get the COM object pointer from the D3D object and marshal it as one of the interfaces defined below
				var dField = container.GetType().GetField("pComPtr", BindingFlags.NonPublic | BindingFlags.Instance);
				if (dField == null) {
					return default(T);
				}

				var dPointer = new IntPtr(Pointer.Unbox(dField.GetValue(container)));
				return (T)Marshal.GetObjectForIUnknown(dPointer);
			}
		}

	}

}