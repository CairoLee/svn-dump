#pragma once

namespace Shaiya {
	class Client {
	public:
		bool IsBotting;
		DWORD Target;
		Shaiya::Monster Player;
		vector<Shaiya::Monster> MonsterList;
		vector<Shaiya::Skill> SkillList;
		bool LoggedIn;
		bool PickItems;
		bool DoSellItems;
		bool DoRepairEquipment;
		bool UseOnlySkills;
		bool BotReady;
		CRITICAL_SECTION cs;
		CRITICAL_SECTION cs2;
		DWORD Killcount;
		DWORD Repaircount;

		float HuntingX;
		float HuntingZ;
		DWORD HuntingRadius;
		DWORD AttackDistance;


		Client( void );
		~Client( void );

		void UpdatePlayerPos( float x, float y, float z );
		void AttackTarget();
		void AddMonster( DWORD ID, float X, float Z );
		void UpdateMonster( DWORD ID, float X, float Z );
		void DeleteMonster( DWORD ID );
		void TargetNextMonster();
		float Pythagorean( float X1, float Z1, float X2, float Z2 );
		void PickItem( DWORD ItemID );
		void TargetMonster( DWORD ID );
		void SetPlayerID( DWORD ID );
		void SetHuntingArea( DWORD Radius );
		void CheckMonster( DWORD ID, float X, float Z );
		void ActivateBot();
		void SellItem( BYTE Page, BYTE Place, BYTE Count );
		void IncreaseKillcount();
		void RepairEquipment();
		void AddSkill( BYTE ID, BYTE Level, BYTE Use );
		void BotThread();
		void UseBuff( BYTE Use, DWORD myTarget );
		void UseAttackSkill( BYTE Use, DWORD myTarget );
		void UpdateSkillUse( BYTE ID );
		void IsUsingSkill( BYTE Use, bool IsUsing );
	private:
	};
}
