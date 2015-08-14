using System;
using System.Collections;

using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Util {
	/// <summary>
	/// An entry in the <see cref="LevelMapping"/>
	/// </summary>
	/// <remarks>
	/// <para>
	/// This is an abstract base class for types that are stored in the
	/// <see cref="LevelMapping"/> object.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	public abstract class LevelMappingEntry : IOptionHandler {
		#region Public Instance Constructors

		/// <summary>
		/// Default protected constructor
		/// </summary>
		/// <remarks>
		/// <para>
		/// Default protected constructor
		/// </para>
		/// </remarks>
		protected LevelMappingEntry() {
		}

		#endregion // Public Instance Constructors

		#region Public Instance Properties

		/// <summary>
		/// The level that is the key for this mapping 
		/// </summary>
		/// <value>
		/// The <see cref="Level"/> that is the key for this mapping 
		/// </value>
		/// <remarks>
		/// <para>
		/// Get or set the <see cref="Level"/> that is the key for this
		/// mapping subclass.
		/// </para>
		/// </remarks>
		public Level Level {
			get { return m_level; }
			set { m_level = value; }
		}

		#endregion // Public Instance Properties

		#region IOptionHandler Members

		/// <summary>
		/// Initialize any options defined on this entry
		/// </summary>
		/// <remarks>
		/// <para>
		/// Should be overridden by any classes that need to initialise based on their options
		/// </para>
		/// </remarks>
		virtual public void ActivateOptions() {
			// default implementation is to do nothing
		}

		#endregion // IOptionHandler Members

		#region Private Instance Fields

		private Level m_level;

		#endregion // Private Instance Fields
	}
}
