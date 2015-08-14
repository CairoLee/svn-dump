
namespace GodLesZ.Games.Match3 {
	
	public static class Program {
		
		public static void Main(string[] args) {
			using (var game = new GameMatch3()) {
				game.Run();
			}
		}

	}

}