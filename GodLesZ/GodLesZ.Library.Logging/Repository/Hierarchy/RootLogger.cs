using System;

using GodLesZ.Library.Logging.Util;
using GodLesZ.Library.Logging.Core;

namespace GodLesZ.Library.Logging.Repository.Hierarchy {
	/// <summary>
	/// The <see cref="RootLogger" /> sits at the root of the logger hierarchy tree. 
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <see cref="RootLogger" /> is a regular <see cref="Logger" /> except 
	/// that it provides several guarantees.
	/// </para>
	/// <para>
	/// First, it cannot be assigned a <c>null</c>
	/// level. Second, since the root logger cannot have a parent, the
	/// <see cref="EffectiveLevel"/> property always returns the value of the
	/// level field without walking the hierarchy.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	public class RootLogger : Logger {
		#region Public Instance Constructors

		/// <summary>
		/// Construct a <see cref="RootLogger"/>
		/// </summary>
		/// <param name="level">The level to assign to the root logger.</param>
		/// <remarks>
		/// <para>
		/// Initializes a new instance of the <see cref="RootLogger" /> class with
		/// the specified logging level.
		/// </para>
		/// <para>
		/// The root logger names itself as "root". However, the root
		/// logger cannot be retrieved by name.
		/// </para>
		/// </remarks>
		public RootLogger(Level level)
			: base("root") {
			this.Level = level;
		}

		#endregion Public Instance Constructors

		#region Override implementation of Logger

		/// <summary>
		/// Gets the assigned level value without walking the logger hierarchy.
		/// </summary>
		/// <value>The assigned level value without walking the logger hierarchy.</value>
		/// <remarks>
		/// <para>
		/// Because the root logger cannot have a parent and its level
		/// must not be <c>null</c> this property just returns the
		/// value of <see cref="Logger.Level"/>.
		/// </para>
		/// </remarks>
		override public Level EffectiveLevel {
			get {
				return base.Level;
			}
		}

		/// <summary>
		/// Gets or sets the assigned <see cref="Level"/> for the root logger.  
		/// </summary>
		/// <value>
		/// The <see cref="Level"/> of the root logger.
		/// </value>
		/// <remarks>
		/// <para>
		/// Setting the level of the root logger to a <c>null</c> reference
		/// may have catastrophic results. We prevent this here.
		/// </para>
		/// </remarks>
		override public Level Level {
			get { return base.Level; }
			set {
				if (value == null) {
					LogLog.Error(declaringType, "You have tried to set a null level to root.", new LogException());
				} else {
					base.Level = value;
				}
			}
		}

		#endregion Override implementation of Logger

		#region Private Static Fields

		/// <summary>
		/// The fully qualified type of the RootLogger class.
		/// </summary>
		/// <remarks>
		/// Used by the internal logger to record the Type of the
		/// log message.
		/// </remarks>
		private readonly static Type declaringType = typeof(RootLogger);

		#endregion Private Static Fields
	}
}
