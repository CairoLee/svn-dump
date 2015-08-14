using System;
using System.Collections.Generic;
using System.Text;

namespace GenerationMath {
	class Engine : IEngine {
		private Dictionary<string, double> variables = new Dictionary<string, double>();
		public double GetVariable( string name ) {
			return variables[ name ];
		}

		public void SetVariable( string name, double value ) {
			variables[ name ] = value;
		}
	}
}
