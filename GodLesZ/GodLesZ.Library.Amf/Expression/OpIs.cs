
namespace GodLesZ.Library.Amf.Expression {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class OpIs : BinaryOperator {
		public OpIs() {
		}

		protected override object Evaluate(object context, EvaluationContext evalContext) {
			object instance = Left.EvaluateInternal(context, evalContext);
			object value = Right.EvaluateInternal(context, evalContext);
			if (instance == null && value == null)
				return true;
			if (instance != null && value != null)
				return true;
			return false;
			/*
            Type type = Right.EvaluateInternal( context, evalContext ) as Type;
            if (instance == null || type == null)
            {
                return false;
            }
            return type.IsAssignableFrom(instance.GetType());
			*/
		}
	}
}