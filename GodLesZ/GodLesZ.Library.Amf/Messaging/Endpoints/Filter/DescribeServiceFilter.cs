
using GodLesZ.Library.Amf.IO;

namespace GodLesZ.Library.Amf.Messaging.Endpoints.Filter {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class DescribeServiceFilter : AbstractFilter {
		/// <summary>
		/// Initializes a new instance of the DescribeServiceFilter class.
		/// </summary>
		public DescribeServiceFilter() {
		}

		#region IFilter Members

		public override void Invoke(AMFContext context) {
			AMFMessage amfMessage = context.AMFMessage;
			AMFHeader amfHeader = amfMessage.GetHeader(AMFHeader.ServiceBrowserHeader);
			if (amfHeader != null) {
				AMFBody amfBody = amfMessage.GetBodyAt(0);
				amfBody.IsDescribeService = true;
			}
		}

		#endregion
	}
}
