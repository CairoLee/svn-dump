using System;
using System.Text;
using System.IO;
using System.Collections;

using GodLesZ.Library.Logging.Core;
using GodLesZ.Library.Logging.Util;
using GodLesZ.Library.Logging.Repository;

namespace GodLesZ.Library.Logging.Util.PatternStringConverters {
	/// <summary>
	/// Property pattern converter
	/// </summary>
	/// <remarks>
	/// <para>
	/// This pattern converter reads the thread and global properties.
	/// The thread properties take priority over global properties.
	/// See <see cref="ThreadContext.Properties"/> for details of the 
	/// thread properties. See <see cref="GlobalContext.Properties"/> for
	/// details of the global properties.
	/// </para>
	/// <para>
	/// If the <see cref="PatternConverter.Option"/> is specified then that will be used to
	/// lookup a single property. If no <see cref="PatternConverter.Option"/> is specified
	/// then all properties will be dumped as a list of key value pairs.
	/// </para>
	/// </remarks>
	/// <author>Nicko Cadell</author>
	internal sealed class PropertyPatternConverter : PatternConverter {
		/// <summary>
		/// Write the property value to the output
		/// </summary>
		/// <param name="writer"><see cref="TextWriter" /> that will receive the formatted result.</param>
		/// <param name="state">null, state is not set</param>
		/// <remarks>
		/// <para>
		/// Writes out the value of a named property. The property name
		/// should be set in the <see cref="GodLesZ.Library.Logging.Util.PatternConverter.Option"/>
		/// property.
		/// </para>
		/// <para>
		/// If the <see cref="GodLesZ.Library.Logging.Util.PatternConverter.Option"/> is set to <c>null</c>
		/// then all the properties are written as key value pairs.
		/// </para>
		/// </remarks>
		override protected void Convert(TextWriter writer, object state) {
			CompositeProperties compositeProperties = new CompositeProperties();

#if !NETCF
			PropertiesDictionary logicalThreadProperties = LogicalThreadContext.Properties.GetProperties(false);
			if (logicalThreadProperties != null) {
				compositeProperties.Add(logicalThreadProperties);
			}
#endif
			PropertiesDictionary threadProperties = ThreadContext.Properties.GetProperties(false);
			if (threadProperties != null) {
				compositeProperties.Add(threadProperties);
			}

			// TODO: Add Repository Properties
			compositeProperties.Add(GlobalContext.Properties.GetReadOnlyProperties());

			if (Option != null) {
				// Write the value for the specified key
				WriteObject(writer, null, compositeProperties[Option]);
			} else {
				// Write all the key value pairs
				WriteDictionary(writer, null, compositeProperties.Flatten());
			}
		}
	}
}
