using System;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;

//#pragma warning disable 67

namespace FreeWorld.Engine.Tools.XnaFake {

	public class GraphicsDeviceService : IGraphicsDeviceService {
		// Singleton device service instance.
		protected static GraphicsDeviceService mSingletonInstance;

		// Keep track of how many controls are sharing the singletonInstance.
		protected static int mReferenceCount;

		// Store the current device settings.
		protected readonly PresentationParameters mParameters;

		/// <summary>
		/// Gets the current graphics device.
		/// </summary>
		public GraphicsDevice GraphicsDevice {
			get;
			protected set;
		}


		// IGraphicsDeviceService events.
		public event EventHandler<EventArgs> DeviceCreated;
		public event EventHandler<EventArgs> DeviceDisposing;
		public event EventHandler<EventArgs> DeviceReset;
		public event EventHandler<EventArgs> DeviceResetting;


		/// <summary>
		/// Constructor is private, because this is a singleton class:
		/// client controls should use the public AddRef method instead.
		/// </summary>
		protected GraphicsDeviceService(IntPtr windowHandle, int width, int height, GraphicsProfile profile) {
			mParameters = new PresentationParameters {
				BackBufferWidth = Math.Max(width, 1),
				BackBufferHeight = Math.Max(height, 1),
				BackBufferFormat = SurfaceFormat.Color,
				DepthStencilFormat = DepthFormat.Depth24,
				DeviceWindowHandle = windowHandle,
				PresentationInterval = PresentInterval.Immediate,
				IsFullScreen = false
			};

			GraphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, profile, mParameters) {
				BlendState = BlendState.Additive,
				DepthStencilState = DepthStencilState.Default
			};
		}


		/// <summary>
		/// Gets a reference to the singleton instance.
		/// </summary>
		public static GraphicsDeviceService AddRef(IntPtr windowHandle, int width, int height, GraphicsProfile profile) {
			// Increment the "how many controls sharing the device" reference count.
			if (Interlocked.Increment(ref mReferenceCount) == 1) {
				// If this is the first control to start using the
				// device, we must create the singleton instance.
				mSingletonInstance = new GraphicsDeviceService(windowHandle, width, height, profile);
			}

			return mSingletonInstance;
		}


		/// <summary>
		/// Releases a reference to the singleton instance.
		/// </summary>
		public void Release(bool disposing) {
			// Decrement the "how many controls sharing the device" reference count.
			if (Interlocked.Decrement(ref mReferenceCount) != 0) {
				return;
			}

			// If this is the last control to finish using the
			// device, we should dispose the singleton instance.
			if (disposing) {
				if (DeviceDisposing != null) {
					DeviceDisposing(this, EventArgs.Empty);
				}

				GraphicsDevice.Dispose();
			}

			GraphicsDevice = null;
		}


		/// <summary>
		/// Resets the graphics device to whichever is bigger out of the specified
		/// resolution or its current size. This behavior means the device will
		/// demand-grow to the largest of all its GraphicsDeviceControl clients.
		/// </summary>
		public void ResetDevice(int width, int height) {
			if (DeviceResetting != null) {
				DeviceResetting(this, EventArgs.Empty);
			}

			mParameters.BackBufferWidth = Math.Max(mParameters.BackBufferWidth, width);
			mParameters.BackBufferHeight = Math.Max(mParameters.BackBufferHeight, height);

			GraphicsDevice.Reset(mParameters);

			if (DeviceReset != null) {
				DeviceReset(this, EventArgs.Empty);
			}
		}

	}

}
