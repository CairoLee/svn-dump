using System;
using System.Collections;

namespace GodLesZ.Library.Logging.Repository.Hierarchy {
	/// <summary>
	/// Provision nodes are used where no logger instance has been specified
	/// </summary>
	/// <remarks>
	/// <para>
	/// <see cref="ProvisionNode"/> instances are used in the 
	/// <see cref="Hierarchy" /> when there is no specified 
	/// <see cref="Logger" /> for that node.
	/// </para>
	/// <para>
	/// A provision node holds a list of child loggers on behalf of
	/// a logger that does not exist.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	/// <author>Gert Driesen</author>
	internal sealed class ProvisionNode : ArrayList {
		/// <summary>
		/// Create a new provision node with child node
		/// </summary>
		/// <param name="log">A child logger to add to this node.</param>
		/// <remarks>
		/// <para>
		/// Initializes a new instance of the <see cref="ProvisionNode" /> class 
		/// with the specified child logger.
		/// </para>
		/// </remarks>
		internal ProvisionNode(Logger log)
			: base() {
			this.Add(log);
		}
	}
}
