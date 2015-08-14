using System;
using System.Collections;

using GodLesZ.Library.Amf.Messaging.Messages;

namespace GodLesZ.Library.Amf.IO {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class ErrorResponseBody : ResponseBody {
		/// <summary>
		/// Initializes a new instance of the ErrorResponseBody class.
		/// </summary>
		/// <param name="requestBody"></param>
		/// <param name="error"></param>
		public ErrorResponseBody(AMFBody requestBody, string error)
			: base(requestBody) {
			IgnoreResults = requestBody.IgnoreResults;
			Target = requestBody.Response + AMFBody.OnStatus;
			Response = null;
			Content = new ExceptionASO(error);
		}
		/// <summary>
		/// Initializes a new instance of the ErrorResponseBody class.
		/// </summary>
		/// <param name="requestBody"></param>
		/// <param name="exception"></param>
		public ErrorResponseBody(AMFBody requestBody, Exception exception)
			: base(requestBody) {
			if (requestBody.IsEmptyTarget) {
				object content = requestBody.Content;
				if (content is IList)
					content = (content as IList)[0];
				IMessage message = content as IMessage;
				//Check for Flex2 messages and handle
				if (message != null) {
					ErrorMessage errorMessage = ErrorMessage.GetErrorMessage(message, exception);
					Content = errorMessage;
				}
			}
			if (Content == null)
				Content = new ExceptionASO(exception);
			IgnoreResults = requestBody.IgnoreResults;
			Target = requestBody.Response + AMFBody.OnStatus;
			Response = null;
		}
		/// <summary>
		/// Initializes a new instance of the ErrorResponseBody class.
		/// </summary>
		/// <param name="requestBody"></param>
		/// <param name="message"></param>
		/// <param name="exception"></param>
		public ErrorResponseBody(AMFBody requestBody, IMessage message, Exception exception)
			: base(requestBody) {
			ErrorMessage errorMessage = ErrorMessage.GetErrorMessage(message, exception);
			Content = errorMessage;
			Target = requestBody.Response + AMFBody.OnStatus;
			IgnoreResults = requestBody.IgnoreResults;
			Response = "";
		}
		/// <summary>
		/// Initializes a new instance of the ErrorResponseBody class.
		/// </summary>
		/// <param name="requestBody"></param>
		/// <param name="message"></param>
		/// <param name="errorMessage"></param>
		public ErrorResponseBody(AMFBody requestBody, IMessage message, ErrorMessage errorMessage)
			: base(requestBody) {
			Content = errorMessage;
			Target = requestBody.Response + AMFBody.OnStatus;
			IgnoreResults = requestBody.IgnoreResults;
			Response = "";
		}

	}
}
