namespace GodLesZ.Games.Ragnarok.RoBot.Library.Objects.Enumerations {
	
	public enum EAccountState {
		/// <summary>
		/// This is the default value, used for freshly created objects
		/// </summary>
		None = 0,

		/// <summary>
		/// Means the account passed the login authendication
		/// </summary>
		Login = 1,

		/// <summary>
		/// Means the account passed the character authendication and didnt select a char yet
		/// </summary>
		Char = 2,

		/// <summary>
		/// Means where is an active char on this account playing in Midgard
		/// </summary>
		World = 3
	}

}
