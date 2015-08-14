using System;
using Microsoft.Xna.Framework;

namespace GodLesZ.Games.Match3 {

	public static class GameServiceContainerExtensions {

		public static T GetService<T>(this GameServiceContainer services) {
			return (T)services.GetService(typeof(T));
		}

		public static void AddService<T>(this GameServiceContainer services, object service) {
			services.AddService(typeof(T), service);
		}

		/// <exception cref="ArgumentNullException">service</exception>
		public static void AddService(this GameServiceContainer services, object service) {
			if (service == null) {
				throw new ArgumentNullException("service");
			}

			var serviceType = service.GetType();
			services.AddService(serviceType, service);
		}

	}

}