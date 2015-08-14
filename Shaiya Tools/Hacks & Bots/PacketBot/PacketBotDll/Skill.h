#pragma once

namespace Shaiya {
	class Skill {
	public:
		BYTE ID;
		BYTE Level;
		BYTE Use;
		BYTE Type;
		bool IsUsed;
		DWORD LastUsage;
		DWORD Cooldown;
		bool CastingSkill;

		Skill( void );
		~Skill( void );

	private:
	};

};