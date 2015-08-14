
namespace ZenAIConfigPanel.Expression {
	abstract class Expression {
		internal abstract Result Eval(Evaluator evaluater, Result[] argArray);
	}
}
