using System.Data;
using System.Reflection;
#if !(NET_1_1)
using System.Collections.Generic;
#endif
using GodLesZ.Library.Amf.Invocation;

namespace GodLesZ.Library.Amf {
	/// <summary>
	/// The DataSetTypeAttribute specifies the types of data in a DataSet. The attribute controls how a DataSet is sent to the Flex client.
	/// </summary>
	/// <example>
	/// <code lang="CS">
	/// In this sample the Flex client will receive a PersonVO object with a "phoneNumbers" property having an Arraycollection of PhoneVO objects.
	/// 
	/// [DataSetType("FlexRemoteObjectSample.PersonVO")]
	/// [DataTableType("phones", "phoneNumbers", "FlexRemoteObjectSample.PhoneVO")]
	/// public DataSet GetDataSet()
	/// {
	///     DataSet dataSet = new DataSet("mydataset");
	///     DataTable dataTable = dataSet.Tables.Add("phones");
	///     dataTable.Columns.Add( "number", typeof(string) );
	///     dataTable.Rows.Add( new object[] {"123456"} );
	///     dataTable.Rows.Add( new object[] {"456789"} );
	///     return dataSet;
	/// }
	/// </code>
	/// </example>
	public class DataSetTypeAttribute : System.Attribute, IInvocationResultHandler {
		string _remoteClass;
		/// <summary>
		/// Initializes a new instance of the DataSetTypeAttribute class.
		/// </summary>
		/// <param name="remoteClass">The ActionScript3 class name.</param>
		public DataSetTypeAttribute(string remoteClass) {
			_remoteClass = remoteClass;
		}

		#region IInvocationResultHandler Members
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="invocationManager"></param>
		/// <param name="memberInfo"></param>
		/// <param name="obj"></param>
		/// <param name="arguments"></param>
		/// <param name="result"></param>
		public void HandleResult(IInvocationManager invocationManager, MemberInfo memberInfo, object obj, object[] arguments, object result) {
			if (result is DataSet) {
				DataSet dataSet = result as DataSet;
				ASObject asoResult = new ASObject(_remoteClass);

#if !(NET_1_1)
				foreach (KeyValuePair<object, object> entry in invocationManager.Properties)
#else
				foreach(DictionaryEntry entry in invocationManager.Properties)
#endif
 {
					if (entry.Key is DataTable) {
						DataTable dataTable = entry.Key as DataTable;
						if (dataSet.Tables.IndexOf(dataTable) != -1) {
							if (!dataTable.ExtendedProperties.ContainsKey("alias"))
								asoResult[dataTable.TableName] = entry.Value;
							else
								asoResult[dataTable.ExtendedProperties["alias"] as string] = entry.Value;
						}
					}
				}
				invocationManager.Result = asoResult;
			}
		}

		#endregion
	}
}
