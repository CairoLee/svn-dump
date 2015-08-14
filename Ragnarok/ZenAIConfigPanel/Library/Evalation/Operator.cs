
namespace ZenAIConfigPanel.Expression {
	abstract class Operator : Expression {
		public Operator() {
		}

		public abstract OperatorPriority Priority {
			get;
		}
	}
}
