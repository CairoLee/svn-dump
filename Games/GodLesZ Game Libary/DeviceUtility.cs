
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace GLibary {
	public partial class Utility {
		private static GraphicsDevice graphicsDevice = null;
		public static GraphicsDevice GraphicsDevice {
			get {
				if( graphicsDevice == null ) {
					graphicsDevice = DeviceManager.GraphicsDevice;
				}
				return graphicsDevice;
			}
		}

		private static GraphicsDeviceManager deviceManager = null;
		public static GraphicsDeviceManager DeviceManager {
			get {
				if( deviceManager == null ) {
					deviceManager = GetService<IGraphicsDeviceService, GraphicsDeviceManager>();
				}
				return deviceManager;
			}
		}

		public static float GetWindowAspectRatio( GameWindow window ) {
			return (float)window.ClientBounds.Width / (float)window.ClientBounds.Height;
		}

		public static float GetViewportAspectRatio() {
			return GraphicsDevice.Viewport.AspectRatio;
		}
	}
}