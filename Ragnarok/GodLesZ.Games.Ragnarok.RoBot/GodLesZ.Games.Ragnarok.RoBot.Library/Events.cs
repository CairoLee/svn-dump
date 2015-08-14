using System;
using System.Collections.Generic;

namespace GodLesZ.Games.Ragnarok.RoBot.Library {

	public static class Events {
		private static Dictionary<string, Delegate> mEvents;

		public static EventHandler OnInvokeWorldLoadStart;

		static Events() {
			mEvents.Add("worldLoadStart", null);
			mEvents.Add("worldLoadFinish", null);
		}


		public static void Delegate(string eventName, Delegate del) {
			if (mEvents.ContainsKey(eventName) == false) {
				throw new Exception("Invalid event name " + eventName);
			}

			mEvents[eventName] = del;
		}

		public static void Call(string eventName) {
			if (mEvents.ContainsKey(eventName) == false) {
				throw new Exception("Invalid event name " + eventName);
			}

			if (mEvents[eventName] != null) {
				mEvents[eventName].DynamicInvoke();
			}
		}

	}

}