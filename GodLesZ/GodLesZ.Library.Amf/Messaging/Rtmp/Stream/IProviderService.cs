using System;
using System.Collections;
using System.IO;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Messaging;
using GodLesZ.Library.Amf.Messaging.Api.Stream;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {

	/// <summary>
	/// Input type enumeration.
	/// </summary>
	public enum InputType {
		/// <summary>
		/// Input type not found.
		/// </summary>
		NotFound,
		/// <summary>
		/// Live provider.
		/// </summary>
		Live,
		/// <summary>
		/// Vod provider.
		/// </summary>
		Vod
	};

	/// <summary>
	/// Central unit to get access to different types of provider inputs.
	/// </summary>
	[CLSCompliant(false)]
	public interface IProviderService : IScopeService {
		/// <summary>
		/// Lookups the input type of the provider.
		/// </summary>
		/// <param name="scope">The scope.</param>
		/// <param name="name">The provider name.</param>
		/// <returns><code>Live</code> if live, <code>Vod</code> if VOD stream, <code>NotFound</code> otherwise.</returns>
		/// <remarks>Live is checked first and VOD second.</remarks>
		InputType LookupProviderInputType(IScope scope, string name);
		/// <summary>
		/// Returns a named provider as the source of input. Live stream first, VOD stream second.
		/// </summary>
		/// <param name="scope">Scope of provider.</param>
		/// <param name="name">Name of provider.</param>
		/// <returns>null if nothing found.</returns>
		IMessageInput GetProviderInput(IScope scope, String name);
		/// <summary>
		/// Returns a named Live provider as the source of input.
		/// </summary>
		/// <param name="scope">Scope of provider.</param>
		/// <param name="name">Name of provider.</param>
		/// <param name="needCreate">Whether there's need to create basic scope if that doesn't exist.</param>
		/// <returns>null if not found.</returns>
		IMessageInput GetLiveProviderInput(IScope scope, String name, bool needCreate);
		/// <summary>
		/// Returns a named VOD provider as the source of input.
		/// </summary>
		/// <param name="scope">Scope of provider.</param>
		/// <param name="name">Name of provider.</param>
		/// <returns>null if not found.</returns>
		IMessageInput GetVODProviderInput(IScope scope, String name);
		/// <summary>
		/// Returns a named VOD source file.
		/// </summary>
		/// <param name="scope">Scope of provider.</param>
		/// <param name="name">Name of provider.</param>
		/// <returns>null if not found</returns>
		FileInfo GetVODProviderFile(IScope scope, String name);
		/// <summary>
		/// Registers a broadcast stream to a scope.
		/// </summary>
		/// <param name="scope">Scope.</param>
		/// <param name="name">Name of stream.</param>
		/// <param name="broadcastStream">Broadcast stream to register.</param>
		/// <returns>true if register successfully.</returns>
		bool RegisterBroadcastStream(IScope scope, String name, IBroadcastStream broadcastStream);
		/// <summary>
		/// Returns names of existing broadcast streams in a scope. 
		/// </summary>
		/// <param name="scope">Scope to get stream names from.</param>
		/// <returns>List of stream names.</returns>
		IEnumerator GetBroadcastStreamNames(IScope scope);
		/// <summary>
		/// Unregister a broadcast stream of a specific name from a scope.
		/// </summary>
		/// <param name="scope">Scope.</param>
		/// <param name="name">Stream name.</param>
		/// <returns>true if unregister successfully.</returns>
		bool UnregisterBroadcastStream(IScope scope, String name);
	}
}
