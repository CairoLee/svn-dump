using System;
using System.Collections;
using GodLesZ.Library.Amf.Expression;
using log4net;

namespace GodLesZ.Library.Amf.Messaging.Services.Messaging {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class Selector : IComparable {
		private static readonly ILog log = LogManager.GetLogger(typeof(Selector));
		private EvaluateInvoker _evaluateMethod;
		readonly string _expression;

		public Selector(string expression, EvaluateInvoker evaluateMethod) {
			_evaluateMethod = evaluateMethod;
			_expression = expression;
		}

		public string Expression {
			get { return _expression; }
		}

		public bool Evaluate(object root, IDictionary variables) {
			object result = _evaluateMethod(root, variables);
			if (result is bool)
				return (bool)result;
			else {
				if (log.IsDebugEnabled)
					log.Debug(__Res.GetString(__Res.Selector_InvalidResult));
				return false;
			}
		}

		public static Selector CreateSelector(string expression) {
			IExpression expressionObj = GodLesZ.Library.Amf.Expression.Expression.Parse(expression);

#if !(NET_1_1)
			if (expressionObj is IExpressionGenerator) {
				/*
				IExpressionGenerator expressionGenerator = expressionObj as IExpressionGenerator;
				bool canSkipChecks = SecurityManager.IsGranted(new ReflectionPermission(ReflectionPermissionFlag.MemberAccess));
				DynamicMethod method = new DynamicMethod(string.Empty, typeof(object), new Type[] { typeof(object), typeof(IDictionary) }, typeof(Selector).Module, canSkipChecks);
				ILGenerator ilg = method.GetILGenerator();
				expressionGenerator.Emit(ilg);
				EvaluateInvoker evaluateInvoker = (EvaluateInvoker)method.CreateDelegate(typeof(EvaluateInvoker));
				*/
				return new Selector(expression, new EvaluateInvoker(expressionObj.Evaluate));
			} else
				return new Selector(expression, new EvaluateInvoker(expressionObj.Evaluate));
#else
			return new Selector(expression, new EvaluateInvoker(expressionObj.Evaluate));
#endif
		}

		#region IComparable Members

		public int CompareTo(object obj) {
			if (obj is Selector) {
				Selector other = (Selector)obj;
				return string.Equals(other.Expression, _expression) ? 0 : -1;
			}
			return -1;
		}

		#endregion

		public override bool Equals(object obj) {
			return CompareTo(obj) == 0;
		}

		public override int GetHashCode() {
			return _expression.GetHashCode();
		}
	}
}
