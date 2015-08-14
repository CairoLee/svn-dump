using System;
using System.Collections;
using antlr.collections;

namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	abstract class NodeWithArguments : BaseNode {
		private BaseNode[] args;

		public NodeWithArguments() {
		}

		/// <summary>
		/// Initializes the node. 
		/// </summary>
		private void InitializeNode() {
			if (args == null) {
				lock (this) {
					if (args == null) {
						ArrayList argList = new ArrayList();

						AST node = this.getFirstChild();

						while (node != null) {
							argList.Add(node);
							node = node.getNextSibling();
						}
						args = (BaseNode[])argList.ToArray(typeof(BaseNode));
					}
				}
			}
		}

		/// <summary>
		/// Asserts the argument count.
		/// </summary>
		/// <param name="requiredCount">The required count.</param>
		protected void AssertArgumentCount(int requiredCount) {
			InitializeNode();
			if (requiredCount != args.Length) {
				throw new ArgumentException("This expression node requires exactly " +
											requiredCount + " argument(s) and " +
											args.Length + " were specified.");
			}
		}

		/// <summary>
		/// Resolves the arguments.
		/// </summary>
		/// <param name="evalContext">Current expression evaluation context.</param>
		/// <returns>An array of argument values</returns>
		protected object[] ResolveArguments(EvaluationContext evalContext) {
			InitializeNode();
			object[] values = new object[args.Length];
			for (int i = 0; i < args.Length; i++) {
				values[i] = ResolveArgument(i, evalContext);
			}
			return values;
		}


		/// <summary>
		/// Resolves the argument.
		/// </summary>
		/// <param name="position">Argument position.</param>
		/// <param name="evalContext">Current expression evaluation context.</param>
		/// <returns>Resolved argument value.</returns>
		protected object ResolveArgument(int position, EvaluationContext evalContext) {
			InitializeNode();
			return ((BaseNode)args[position]).EvaluateInternal(evalContext.ThisContext, evalContext);
		}
	}
}