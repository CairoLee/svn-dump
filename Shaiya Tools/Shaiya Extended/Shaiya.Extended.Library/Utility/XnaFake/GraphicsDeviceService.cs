using System;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;

// The IGraphicsDeviceService interface requires a DeviceCreated event, but we
// always just create the device inside our ctor, so we have no place to
// raise that event. The C# compiler warns us that the event is never used, but
// we don't care so we just disable this warning.
#pragma warning disable 67

namespace Shaiya.Extended.Library.Utility {

	public class GraphicsDeviceService : IGraphicsDeviceService {
		public event EventHandler DeviceCreated;
		public event EventHandler DeviceDisposing;
		public event EventHandler DeviceReset;
		public event EventHandler DeviceResetting;
		
		private static GraphicsDeviceService singletonInstance;
		private static int referenceCount;

		private GraphicsDevice graphicsDevice;
		private PresentationParameters parameters;

		/// <summary>
		/// Gets the current graphics device.
		/// </summary>
		public GraphicsDevice GraphicsDevice {
			get { return graphicsDevice; }
		}


		/// <summary>
		/// Constructor is private, because this is a singleton class:
		/// client controls should use the public AddRef method instead.
		/// </summary>
		private GraphicsDeviceService( IntPtr windowHandle, int width, int height ) {
			parameters = new PresentationParameters();

			parameters.BackBufferWidth = Math.Max( width, 1 );
			parameters.BackBufferHeight = Math.Max( height, 1 );
			parameters.BackBufferFormat = SurfaceFormat.Color;

			parameters.EnableAutoDepthStencil = true;
			parameters.AutoDepthStencilFormat = DepthFormat.Depth24;

			graphicsDevice = new GraphicsDevice( GraphicsAdapter.DefaultAdapter, DeviceType.Hardware, windowHandle, parameters );
		}


		/// <summary>
		/// Gets a reference to the singleton instance.
		/// </summary>
		public static GraphicsDeviceService AddRef( IntPtr windowHandle, int width, int height ) {
			if( Interlocked.Increment( ref referenceCount ) == 1 )
				singletonInstance = new GraphicsDeviceService( windowHandle, width, height );

			return singletonInstance;
		}


		/// <summary>
		/// Releases a reference to the singleton instance.
		/// </summary>
		public void Release( bool disposing ) {
			if( Interlocked.Decrement( ref referenceCount ) == 0 ) {
				if( disposing ) {
					if( DeviceDisposing != null )
						DeviceDisposing( this, EventArgs.Empty );
					graphicsDevice.Dispose();
				}

				graphicsDevice = null;
			}
		}


		/// <summary>
		/// Resets the graphics device to whichever is bigger out of the specified
		/// resolution or its current size. This behavior means the device will
		/// demand-grow to the largest of all its GraphicsDeviceControl clients.
		/// </summary>
		public void ResetDevice( int width, int height ) {
			if( DeviceResetting != null )
				DeviceResetting( this, EventArgs.Empty );

			parameters.BackBufferWidth = Math.Max( parameters.BackBufferWidth, width );
			parameters.BackBufferHeight = Math.Max( parameters.BackBufferHeight, height );

			graphicsDevice.Reset( parameters );

			if( DeviceReset != null )
				DeviceReset( this, EventArgs.Empty );
		}

	}
}
