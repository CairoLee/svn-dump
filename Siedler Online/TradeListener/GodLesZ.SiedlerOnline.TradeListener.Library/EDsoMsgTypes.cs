using System;

namespace GodLesZ.SiedlerOnline.TradeListener.Library {

	[Flags()]
	public enum EDsoMsgTypes : byte {
		/// <summary>
		/// Default type, used to identify an invalid parse
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// Normal trade message
		/// </summary>
		Trade = 1,

		/// <summary>
		/// Clears a trade from the list because of expired or selled
		/// </summary>
		Clear = 2,

		/// <summary>
		/// Identifies my trade
		/// </summary>
		MyTrade = 4,
		/// <summary>
		/// Identifies my message (or priv message/whisper? Check this)
		/// </summary>
		MyChat = 8,

		/// <summary>
		/// Message in a global chat
		/// </summary>
		ChatGlobal = 16,

		/// <summary>
		/// Message in a help chat
		/// </summary>
		ChatHelp = 32
	}

}
