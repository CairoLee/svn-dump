using System;
using GodLesZ.Library.Amf.Context;

namespace GodLesZ.Library.Amf {
	/// <summary>
	/// Helper class used for date, timezone management.
	/// </summary>
	/// <remarks>DateWrapper uses time zone in the last Date encountered during deserialization.</remarks>
	public sealed class DateWrapper {
		/// <summary>
		/// This member supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		public const string FluorineTimezoneKey = "__@fluorinetimezone";

		/// <summary>
		/// Initializes a new instance of the DateWrapper class.
		/// </summary>
		internal DateWrapper() {
		}

		internal static int GetTimeZone() {
			object value = FluorineWebSafeCallContext.GetData(FluorineTimezoneKey);
			if (value != null)
				System.Convert.ToInt32(value);
			return 0;
		}

		internal static void SetTimeZone(int timezone) {
			FluorineWebSafeCallContext.SetData(FluorineTimezoneKey, timezone);
		}
		/// <summary>
		/// Gets the client time zone.
		/// </summary>
		public static TimeSpan ClientTimeZone {
			get { return new TimeSpan(GetTimeZone(), 0, 0); }
		}
		/// <summary>
		/// Gets the server time zone.
		/// </summary>
		public static TimeSpan ServerTimeZone {
			get { return TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Today); }
		}
		/// <summary>
		/// Get the date according to client timezone.
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static DateTime GetClientDate(DateTime date) {
			return date.Add(ClientTimeZone);
		}
		/// <summary>
		/// Get the date according to server timezone.
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static DateTime GetServerDate(DateTime date) {
			return date.Add(ServerTimeZone);
		}
	}
}
