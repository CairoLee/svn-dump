
namespace Helper {
	class Packet {
	public:
		static DWORD PlayerID;
		static DWORD Target;
		static bool IsBotting;
		static bool PickItems;
		static bool DoSellItems;
		static bool CastingSkill;

		Packet();
		~Packet();

		static void RootIncome( char *direction, WORD opcode, char *buf, int len );

		static void EnteredWorld();

	};
}
