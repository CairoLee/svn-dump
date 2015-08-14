using System;

namespace GodLesZ.Library.Logging.Core {
	/// <summary>
	/// An evaluator that triggers on an Exception type
	/// </summary>
	/// <remarks>
	/// <para>
	/// This evaluator will trigger if the type of the Exception
	/// passed to <see cref="IsTriggeringEvent(LoggingEvent)"/>
	/// is equal to a Type in <see cref="ExceptionType"/>.    /// 
	/// </para>
	/// </remarks>
	/// <author>Drew Schaeffer</author>
	public class ExceptionEvaluator : ITriggeringEventEvaluator {
		/// <summary>
		/// The type that causes the trigger to fire.
		/// </summary>
		private Type m_type;

		/// <summary>
		/// Causes subclasses of <see cref="ExceptionType"/> to cause the trigger to fire.
		/// </summary>
		private bool m_triggerOnSubclass;

		/// <summary>
		/// Default ctor to allow dynamic creation through a configurator.
		/// </summary>
		public ExceptionEvaluator() {
			// empty
		}

		/// <summary>
		/// Constructs an evaluator and initializes to trigger on <paramref name="exType"/>
		/// </summary>
		/// <param name="exType">the type that triggers this evaluator.</param>
		/// <param name="triggerOnSubClass">If true, this evaluator will trigger on subclasses of <see cref="ExceptionType"/>.</param>
		public ExceptionEvaluator(Type exType, bool triggerOnSubClass) {
			if (exType == null) {
				throw new ArgumentNullException("exType");
			}

			m_type = exType;
			m_triggerOnSubclass = triggerOnSubClass;
		}

		/// <summary>
		/// The type that triggers this evaluator.
		/// </summary>
		public Type ExceptionType {
			get { return m_type; }
			set { m_type = value; }
		}

		/// <summary>
		/// If true, this evaluator will trigger on subclasses of <see cref="ExceptionType"/>.
		/// </summary>
		public bool TriggerOnSubclass {
			get { return m_triggerOnSubclass; }
			set { m_triggerOnSubclass = value; }
		}

		#region ITriggeringEventEvaluator Members

		/// <summary>
		/// Is this <paramref name="loggingEvent"/> the triggering event?
		/// </summary>
		/// <param name="loggingEvent">The event to check</param>
		/// <returns>This method returns <c>true</c>, if the logging event Exception 
		/// Type is <see cref="ExceptionType"/>. 
		/// Otherwise it returns <c>false</c></returns>
		/// <remarks>
		/// <para>
		/// This evaluator will trigger if the Exception Type of the event
		/// passed to <see cref="IsTriggeringEvent(LoggingEvent)"/>
		/// is <see cref="ExceptionType"/>.
		/// </para>
		/// </remarks>
		public bool IsTriggeringEvent(LoggingEvent loggingEvent) {
			if (loggingEvent == null) {
				throw new ArgumentNullException("loggingEvent");
			}

			if (m_triggerOnSubclass && loggingEvent.ExceptionObject != null) {
				// check if loggingEvent.ExceptionObject is of type ExceptionType or subclass of ExceptionType
				Type exceptionObjectType = loggingEvent.ExceptionObject.GetType();
				return exceptionObjectType == m_type || exceptionObjectType.IsSubclassOf(m_type);
			} else if (!m_triggerOnSubclass && loggingEvent.ExceptionObject != null) {   // check if loggingEvent.ExceptionObject is of type ExceptionType
				return loggingEvent.ExceptionObject.GetType() == m_type;
			} else {   // loggingEvent.ExceptionObject is null
				return false;
			}
		}

		#endregion
	}
}
