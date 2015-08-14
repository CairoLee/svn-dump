using System;
using System.Collections;

namespace GodLesZ.Library.Logging.Util {
	/// <summary>
	/// Implementation of Stacks collection for the <see cref="GodLesZ.Library.Logging.ThreadContext"/>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Implementation of Stacks collection for the <see cref="GodLesZ.Library.Logging.ThreadContext"/>
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	public sealed class ThreadContextStacks {
		private readonly ContextPropertiesBase m_properties;

		#region Public Instance Constructors

		/// <summary>
		/// Internal constructor
		/// </summary>
		/// <remarks>
		/// <para>
		/// Initializes a new instance of the <see cref="ThreadContextStacks" /> class.
		/// </para>
		/// </remarks>
		internal ThreadContextStacks(ContextPropertiesBase properties) {
			m_properties = properties;
		}

		#endregion Public Instance Constructors

		#region Public Instance Properties

		/// <summary>
		/// Gets the named thread context stack
		/// </summary>
		/// <value>
		/// The named stack
		/// </value>
		/// <remarks>
		/// <para>
		/// Gets the named thread context stack
		/// </para>
		/// </remarks>
		public ThreadContextStack this[string key] {
			get {
				ThreadContextStack stack = null;

				object propertyValue = m_properties[key];
				if (propertyValue == null) {
					// Stack does not exist, create
					stack = new ThreadContextStack();
					m_properties[key] = stack;
				} else {
					// Look for existing stack
					stack = propertyValue as ThreadContextStack;
					if (stack == null) {
						// Property is not set to a stack!
						string propertyValueString = SystemInfo.NullText;

						try {
							propertyValueString = propertyValue.ToString();
						} catch {
						}

						LogLog.Error(declaringType, "ThreadContextStacks: Request for stack named [" + key + "] failed because a property with the same name exists which is a [" + propertyValue.GetType().Name + "] with value [" + propertyValueString + "]");

						stack = new ThreadContextStack();
					}
				}

				return stack;
			}
		}

		#endregion Public Instance Properties

		#region Private Static Fields

		/// <summary>
		/// The fully qualified type of the ThreadContextStacks class.
		/// </summary>
		/// <remarks>
		/// Used by the internal logger to record the Type of the
		/// log message.
		/// </remarks>
		private readonly static Type declaringType = typeof(ThreadContextStacks);

		#endregion Private Static Fields
	}
}

