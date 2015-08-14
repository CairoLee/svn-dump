
namespace GodLesZ.FunRO.Patcher.Patches {

	public enum EPatchAction {
		None = 0,

		GrfAdd,
		GrfDelete,

		DataAdd,
		DataDelete,

		PatchReset,

		PatcherUpdate = 255,
	}

}
