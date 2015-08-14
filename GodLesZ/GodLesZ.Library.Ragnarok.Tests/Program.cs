#define DISABLE_GRF_EVENTS

using System;
using System.Reflection;
using GodLesZ.Library.Ragnarok.Tests.Library;

namespace GodLesZ.Library.Ragnarok.Tests {

	public static class Program {

		[STAThread]
		public static void Main() {

			// Open & read a big grf to trace using dotTrace
			using (var grf = new Grf.RoGrfFile(@"C:\Games\TalonRO\sdata.grf")) {
				Console.WriteLine("Grf opened, found {0} files", grf.Files.Count);
			}

			Console.WriteLine("Press any key to exit.");
			Console.Read();

			// Run all performancd tests in this assembly
			//RunPerformanceTests();
		}


		private static void RunPerformanceTests() {
			// Get all performance tests
			var asm = Assembly.GetExecutingAssembly();
			var testCount = 0;
			foreach (var testClass in asm.GetExportedTypes()) {
				foreach (var testMethod in testClass.GetMethods(BindingFlags.Static | BindingFlags.Public)) {
					object[] runAttributes;
					if ((runAttributes = testMethod.GetCustomAttributes(typeof(PerformanceTestRunAttribute), true)).Length == 0) {
						continue;
					}

					var runAttribute = runAttributes[0] as PerformanceTestRunAttribute;
					if (runAttribute == null) {
						Console.WriteLine("Failed to run test {0}.{1}. Invalid test run attribute.", testClass.Name, testMethod.Name);
						continue;
					}

					Console.WriteLine("# Running test {0}.{1} {2} times.", testClass.Name, testMethod.Name, runAttribute.RunCount);

					var startTick = DateTime.Now.Ticks;
					long elapsedTicks = 0;
					for (var i = 0; i < runAttribute.RunCount; i++) {
						testMethod.Invoke(null, null);
						elapsedTicks += DateTime.Now.Ticks - startTick;
					}

					var elapsedTime = new TimeSpan(elapsedTicks);
					var elapsedTimeAvg = new TimeSpan(elapsedTime.Ticks / runAttribute.RunCount);

					Console.WriteLine("-----------------------------------------------------");
					Console.WriteLine("\tElapsed time: {0}", elapsedTime);
					Console.WriteLine("\tAverage time: {0}", elapsedTimeAvg);
					Console.WriteLine("-----------------------------------------------------");
					testCount++;
				}
			}

			Console.WriteLine("Finished {0} tests", testCount);
			Console.WriteLine("Press any key to exit.");
			Console.Read();
		}

	}

}