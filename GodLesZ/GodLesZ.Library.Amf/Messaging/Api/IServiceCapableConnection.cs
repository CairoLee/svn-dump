using System;
using GodLesZ.Library.Amf.Messaging.Api.Service;

namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// Connection that supports remote call invocation.
	/// </summary>
	[CLSCompliant(false)]
	public interface IServiceCapableConnection : IConnection {
		/// <summary>
		/// Invokes service using service call object.
		/// </summary>
		/// <param name="serviceCall">Service call object.</param>
		void Invoke(IServiceCall serviceCall);
		/// <summary>
		/// Invokes service using service call object and channel.
		/// </summary>
		/// <param name="serviceCall">Service call object.</param>
		/// <param name="channel">Channel to use.</param>
		void Invoke(IServiceCall serviceCall, byte channel);
		/// <summary>
		/// Invoke method by name.
		/// </summary>
		/// <param name="method">Method name.</param>
		void Invoke(string method);
		/// <summary>
		/// Invoke method by name with callback.
		/// </summary>
		/// <param name="method">Method name.</param>
		/// <param name="callback">Callback used to handle return values.</param>
		void Invoke(string method, IPendingServiceCallback callback);
		/// <summary>
		/// Invoke method with parameters.
		/// </summary>
		/// <param name="method">Method name.</param>
		/// <param name="parameters">Invocation parameters passed to the method.</param>
		void Invoke(string method, object[] parameters);
		/// <summary>
		/// Invoke method with parameters and callback.
		/// </summary>
		/// <param name="method">Method name.</param>
		/// <param name="parameters">Invocation parameters passed to the method.</param>
		/// <param name="callback">Callback used to handle return values.</param>
		void Invoke(string method, object[] parameters, IPendingServiceCallback callback);
		/// <summary>
		/// Notifies service using service call object.
		/// </summary>
		/// <param name="serviceCall">Service call object.</param>
		void Notify(IServiceCall serviceCall);
		/// <summary>
		/// Notifies service using service call object and channel.
		/// </summary>
		/// <param name="serviceCall">Service call object.</param>
		/// <param name="channel">Channel to use.</param>
		void Notify(IServiceCall serviceCall, byte channel);
		/// <summary>
		/// Notifies method by name.
		/// </summary>
		/// <param name="method">Method name.</param>
		void Notify(string method);
		/// <summary>
		/// Notifies method with parameters.
		/// </summary>
		/// <param name="method">Method name.</param>
		/// <param name="parameters">Parameters passed to the method.</param>
		void Notify(string method, object[] parameters);
#if !SILVERLIGHT
		/// <summary>
		/// Begins an asynchronous operation to invoke a service using service call object and channel.
		/// </summary>
		/// <param name="asyncCallback">The AsyncCallback delegate.</param>
		/// <param name="serviceCall">Service call object.</param>
		/// <param name="channel">Channel to use.</param>
		/// <returns>An IAsyncResult that references the asynchronous invocation.</returns>
		/// <remarks>
		/// <para>
		/// You can create a callback method that implements the AsyncCallback delegate and pass its name to the BeginInvoke method.
		/// </para>
		/// <para>
		/// Your callback method should invoke the EndInvoke method. When your application calls BeginInvoke, the system will use a separate thread to execute the specified callback method, and will block on EndInvoke until the client is invoked successfully or throws an exception.
		/// </para>
		/// </remarks>        
		IAsyncResult BeginInvoke(AsyncCallback asyncCallback, IServiceCall serviceCall, byte channel);
		/// <summary>
		/// Begins an asynchronous operation to invoke a service using service call object.
		/// </summary>
		/// <param name="asyncCallback">The AsyncCallback delegate.</param>
		/// <param name="serviceCall">Service call object.</param>
		/// <returns>An IAsyncResult that references the asynchronous invocation.</returns>
		/// <remarks>
		/// <para>
		/// You can create a callback method that implements the AsyncCallback delegate and pass its name to the BeginInvoke method.
		/// </para>
		/// <para>
		/// Your callback method should invoke the EndInvoke method. When your application calls BeginInvoke, the system will use a separate thread to execute the specified callback method, and will block on EndInvoke until the client is invoked successfully or throws an exception.
		/// </para>
		/// </remarks>        
		IAsyncResult BeginInvoke(AsyncCallback asyncCallback, IServiceCall serviceCall);
		/// <summary>
		/// Begins an asynchronous operation to invoke a service by name.
		/// </summary>
		/// <param name="asyncCallback">The AsyncCallback delegate.</param>
		/// <param name="method">Method name.</param>
		/// <returns>An IAsyncResult that references the asynchronous invocation.</returns>
		/// <remarks>
		/// <para>
		/// You can create a callback method that implements the AsyncCallback delegate and pass its name to the BeginInvoke method.
		/// </para>
		/// <para>
		/// Your callback method should invoke the EndInvoke method. When your application calls BeginInvoke, the system will use a separate thread to execute the specified callback method, and will block on EndInvoke until the client is invoked successfully or throws an exception.
		/// </para>
		/// </remarks>
		IAsyncResult BeginInvoke(AsyncCallback asyncCallback, string method);
		/// <summary>
		/// Begins an asynchronous operation to invoke a service by name and with callback.
		/// </summary>
		/// <param name="asyncCallback">The AsyncCallback delegate.</param>
		/// <param name="method">Method name.</param>
		/// <param name="callback">Callback used to handle return values.</param>
		/// <returns>An IAsyncResult that references the asynchronous invocation.</returns>
		/// <remarks>
		/// <para>
		/// You can create a callback method that implements the AsyncCallback delegate and pass its name to the BeginInvoke method.
		/// </para>
		/// <para>
		/// Your callback method should invoke the EndInvoke method. When your application calls BeginInvoke, the system will use a separate thread to execute the specified callback method, and will block on EndInvoke until the client is invoked successfully or throws an exception.
		/// </para>
		/// </remarks>
		IAsyncResult BeginInvoke(AsyncCallback asyncCallback, string method, IPendingServiceCallback callback);
		/// <summary>
		/// Begins an asynchronous operation to invoke a service by name and with parameters.
		/// </summary>
		/// <param name="asyncCallback">The AsyncCallback delegate.</param>
		/// <param name="method">Method name.</param>
		/// <param name="parameters">Invocation parameters passed to the method.</param>
		/// <returns>An IAsyncResult that references the asynchronous invocation.</returns>
		/// <remarks>
		/// <para>
		/// You can create a callback method that implements the AsyncCallback delegate and pass its name to the BeginInvoke method.
		/// </para>
		/// <para>
		/// Your callback method should invoke the EndInvoke method. When your application calls BeginInvoke, the system will use a separate thread to execute the specified callback method, and will block on EndInvoke until the client is invoked successfully or throws an exception.
		/// </para>
		/// </remarks>
		IAsyncResult BeginInvoke(AsyncCallback asyncCallback, string method, object[] parameters);
		/// <summary>
		/// Begins an asynchronous operation to invoke a service by name with parameters and callback.
		/// </summary>
		/// <param name="asyncCallback">The AsyncCallback delegate.</param>
		/// <param name="method">Method name.</param>
		/// <param name="parameters">Invocation parameters passed to the method.</param>
		/// <param name="callback">Callback used to handle return values.</param>
		/// <returns>An IAsyncResult that references the asynchronous invocation.</returns>
		/// <remarks>
		/// <para>
		/// You can create a callback method that implements the AsyncCallback delegate and pass its name to the BeginInvoke method.
		/// </para>
		/// <para>
		/// Your callback method should invoke the EndInvoke method. When your application calls BeginInvoke, the system will use a separate thread to execute the specified callback method, and will block on EndInvoke until the client is invoked successfully or throws an exception.
		/// </para>
		/// </remarks>
		IAsyncResult BeginInvoke(AsyncCallback asyncCallback, string method, object[] parameters, IPendingServiceCallback callback);
		/// <summary>
		/// Ends a pending asynchronous service invocation.
		/// </summary>
		/// <param name="asyncResult">An IAsyncResult that stores state information and any user defined data for this asynchronous operation.</param>
		/// <remarks>
		/// <para>
		/// EndInvoke is a blocking method that completes the asynchronous client invocation request started in the BeginInvoke method.
		/// </para>
		/// <para>
		/// Before calling BeginInvoke, you can create a callback method that implements the AsyncCallback delegate. This callback method executes in a separate thread and is called by the system after BeginInvoke returns. 
		/// The callback method must accept the IAsyncResult returned by the BeginInvoke method as a parameter.
		/// </para>
		/// <para>Within the callback method you can call the EndInvoke method to successfully complete the invocation attempt.</para>
		/// <para>The BeginInvoke enables to use the fire and forget pattern too (by not implementing an AsyncCallback delegate), however if the invocation fails the EndInvoke method is responsible to throw an appropriate exception.
		/// Implementing the callback and calling EndInvoke also allows early garbage collection of the internal objects used in the asynchronous call.</para>
		/// </remarks>
		void EndInvoke(IAsyncResult asyncResult);
#endif
	}
}
