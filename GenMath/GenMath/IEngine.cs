using System;
namespace GenerationMath {
	public interface IEngine {
		double GetVariable( string name );
		void SetVariable( string name, double value );
	}
}
