using System;

namespace GodLesZ.Library.Pcap {
	/// <summary>
	/// Capture event arguments
	/// </summary>
	public class CaptureEventArgs : EventArgs {
		private RawCapture packet;

		/// <summary>
		/// Packet that was captured
		/// </summary>
		public RawCapture Packet {
			get { return packet; }
		}

		private ICaptureDevice device;

		/// <summary>
		/// Device this EventArgs was generated for
		/// </summary>
		public ICaptureDevice Device {
			get { return device; }
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="packet">
		/// A <see cref="RawCapture"/>
		/// </param>
		/// <param name="device">
		/// A <see cref="ICaptureDevice"/>
		/// </param>
		public CaptureEventArgs(RawCapture packet, ICaptureDevice device) {
			this.packet = packet;
			this.device = device;
		}
	}
}
