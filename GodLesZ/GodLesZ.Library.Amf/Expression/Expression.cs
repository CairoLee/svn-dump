using System;
using System.Collections;
using System.IO;

using antlr;
using antlr.collections;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class Expression : BaseNode {
		public Expression() {
		}

		private class FluorineASTFactory : ASTFactory {
			public FluorineASTFactory(Type t)
				: base(t.FullName) {
				base.defaultASTNodeTypeObject_ = t;
				base.typename2creator_ = new Hashtable(32, 0.3f);
				base.typename2creator_[t.FullName] = FluorineAST.Creator;
			}
		}

		private class FluorineExpressionParser : ExpressionParser {
			public FluorineExpressionParser(TokenStream lexer)
				: base(lexer) {
				base.astFactory = new FluorineASTFactory(typeof(FluorineAST));
				base.initialize();
			}
		}

		public static IExpression Parse(string expression) {
			if (expression != null && expression != string.Empty) {
				ExpressionLexer lexer = new ExpressionLexer(new StringReader(expression));
				ExpressionParser parser = new FluorineExpressionParser(lexer);

				parser.expr();
				return parser.getAST() as IExpression;
			} else {
				return new Expression();
			}
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			object result = context;
			if (this.getNumberOfChildren() > 0) {
				AST node = this.getFirstChild();
				while (node != null) {
					result = ((BaseNode)node).EvaluateInternal(result, evalContext);
					node = node.getNextSibling();
				}
			}
			return result;
		}
	}
}
