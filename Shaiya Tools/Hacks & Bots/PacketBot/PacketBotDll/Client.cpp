#include "pch.h"
#include "Client.h"

namespace Shaiya {
	Client::Client( void ){		
		IsBotting = false;
		Target = 0;
		LoggedIn = false;
		PickItems = true;
		DoSellItems = false;
		DoRepairEquipment = true;
		UseOnlySkills = false;
		BotReady = false;
		Killcount = 0;
		Repaircount = -1;

		HuntingX = 0;
		HuntingZ = 0;
		HuntingRadius = 20;
		AttackDistance = 5;
	}

	Client::~Client( void ){
	}


	
	void Client::UpdatePlayerPos( float x, float y, float z ){
		Player.X = x;
		Player.Y = y;
		Player.Z = z;
		char xs[10];
		char ys[10];
		char zs[10];
		sprintf_s( xs, "%.3f", x );
		sprintf_s( ys, "%.3f", y );
		sprintf_s( zs, "%.3f", z );
		SetWindowText( GetDlgItem( FormHandle3, IDC_EDIT1 ), xs );
		SetWindowText( GetDlgItem( FormHandle3, IDC_EDIT2 ), ys );
		SetWindowText( GetDlgItem( FormHandle3, IDC_EDIT3 ), zs );
	}

	void Client::AttackTarget(){
		float X, Z;
		vector<Shaiya::Monster>::iterator it;
		EnterCriticalSection( &cs );
		for( it = MonsterList.begin(); it < MonsterList.end(); it++ ){
			if( it->ID == Target ){
				X = it->X;
				Z = it->Z;
			}
		}
		LeaveCriticalSection( &cs );

		float temp = Pythagorean( Player.X, Player.Z, X, Z );
		temp /= AttackDistance;
		X -= ( ( X - Player.X ) / temp );
		Z -= ( ( Z - Player.Z ) / temp );

		char *Packet = new char[ 50 ];
		SendPacket( "\x12\x02", 2 );
		memcpy( Packet, "\x01\x05\x84\x66\x01", 5 );
		memcpy( Packet + 5, &(X), 4 );
		memcpy( Packet + 9, &(Player.Y), 4 );
		memcpy( Packet + 13, &(Z), 4 );
		SendPacket( Packet, 17 );
		if( !UseOnlySkills ){
			memcpy( Packet, "\x03\x05", 2 );
			memcpy( Packet + 2, &Target, 4 );
			SendPacket( Packet, 6 );
		}
		delete Packet;
	}

	void Client::AddMonster( DWORD ID, float X, float Z ){
		Creature myMonster;
		myMonster.ID = ID;
		myMonster.X = X;
		myMonster.Z = Z;
		EnterCriticalSection( &cs );
		MonsterList.push_back( myMonster );
		LeaveCriticalSection( &cs );
	}

	void Client::UpdateMonster( DWORD ID, float X, float Z ){
		vector<Shaiya::Monster>::iterator it;
		EnterCriticalSection( &cs );
		for( it = MonsterList.begin(); it < MonsterList.end(); it++ ){
			if( it->ID == ID ){
				it->X = X;
				it->Z = Z;
				LeaveCriticalSection( &cs );
				return;
			}
		}
		LeaveCriticalSection( &cs );
	}

	void Client::DeleteMonster( DWORD ID ){
		vector<Shaiya::Monster>::iterator it;
		EnterCriticalSection(&cs);
		for( it = MonsterList.begin(); it < MonsterList.end(); it++ ){
			if( it->ID == ID ){	
				MonsterList.erase( it );
				LeaveCriticalSection( &cs );
				return;
			}
		}
		LeaveCriticalSection(&cs);
	}

	void Client::TargetNextMonster(){	
		if( ( Killcount % 30 == 0 ) && DoRepairEquipment && Repaircount != Killcount ){
			Repaircount = Killcount;
			RepairEquipment();
		}

		float Distance = 0;
		float Distance2 = 0;
		DWORD ID = 0;
		float Radius = 0;
		
		vector<Shaiya::Monster>::iterator it;
		EnterCriticalSection( &cs );
		for( it = MonsterList.begin(); it < MonsterList.end(); it++ ){
			Distance = Pythagorean( it->X, it->Z, Player.X, Player.Z );
			Radius = Pythagorean( it->X, it->Z, HuntingX, HuntingZ );
			if( ( Distance2 == 0 || Distance < Distance2 ) && Radius <= HuntingRadius ){
				Distance2 = Distance;
				ID = it->ID;
			}
		}
		LeaveCriticalSection( &cs );
		if( ID )
			TargetMonster( ID );
		else
			Target = 0;
	}

	float Client::Pythagorean( float X1, float Z1, float X2, float Z2 ){
		return sqrt( abs( X2 - X1 ) * abs( X2 - X1 ) + abs( Z2 - Z1 ) * abs( Z2 - Z1 ) );
	}

	void Client::PickItem( DWORD ItemID ){
		char *Packet = new char[ 6 ];
		memcpy( Packet, "\x05\x02", 2 );
		memcpy( Packet + 2, &ItemID, 4 );
		SendPacket( Packet, 6 );
		delete Packet;
	}

	void Client::TargetMonster( DWORD ID ){
		Target = ID;
		char *Packet = new char[ 6 ];
		memcpy( Packet, "\x05\x03", 2 );
		memcpy( Packet + 2, &ID, 4 );
		SendPacket( Packet, 6 );
		delete Packet;
	}

	void Client::SetPlayerID( DWORD ID ){
		Player.ID = ID;
		char c[ 20 ];
		sprintf_s( c, 20, "%d", ID );
		SetWindowText( GetDlgItem( FormHandle3, IDC_EDIT4 ), c );
	}

	void Client::SetHuntingArea( DWORD Radius ){
		HuntingX = Player.X;
		HuntingZ = Player.Z;
		HuntingRadius = Radius;
	}

	void Client::CheckMonster( DWORD ID, float X, float Z ){
		if( Pythagorean( X, Z, HuntingX, HuntingZ ) <= HuntingRadius )
			TargetMonster( ID );
	}

	void Client::ActivateBot(){
		if( LoggedIn ){
			BotReady = true;
			EnableWindow( GetDlgItem( FormHandle3, IDC_BUTTON1 ), true );
		}
	}

	void Client::SellItem( BYTE Page, BYTE Place, BYTE Count ){
		char Packet[ 5 ];
		memcpy( Packet, "\x03\x07", 2 );
		Packet[ 2 ] = Page;
		Packet[ 3 ] = Place;
		Packet[ 4 ] = Count;
		SendPacket( Packet, 5 );
	}

	void Client::IncreaseKillcount(){
		Killcount++;
		char c[ 20 ];
		sprintf_s( c, 20, "%d", Killcount );
		SetWindowText( GetDlgItem( FormHandle3, IDC_EDIT6 ), c );	
	}

	void Client::RepairEquipment(){
		SendPacket( "\x54\x05\xFF\xFF", 4 );
	}

	void Client::AddSkill( BYTE ID, BYTE Level, BYTE Use ){
		char Path[ MAX_PATH ];
		GetCurrentDirectory( MAX_PATH, Path );
		strcat_s( Path, MAX_PATH, "\\SkillList.ini" );

		char c[ 100 ];	
		sprintf_s( c, 100, "%d.%d", ID, Level );

		Skill mySkill;
		mySkill.ID = ID;
		mySkill.IsUsed = false;
		mySkill.LastUsage = 0;
		mySkill.Level = Level;
		mySkill.Type = GetPrivateProfileInt( c, "Type", 0, Path );
		mySkill.Use = Use;
		mySkill.Cooldown = GetPrivateProfileInt( c, "Cooldown", 1, Path );
		EnterCriticalSection( &cs2 );
		SkillList.push_back( mySkill );
		LeaveCriticalSection( &cs2 );

		char Skillname[ 100 ];
		GetPrivateProfileString( c, "Name", c, Skillname, 100, Path );
		SendMessage( GetDlgItem( FormHandle3, IDC_LIST1 ), LB_ADDSTRING, NULL, (LPARAM)Skillname );
	}

	void Client::UseBuff( BYTE Use, DWORD myTarget ){
		vector<Shaiya::Skill>::iterator it;
		EnterCriticalSection(&cs2);
		for( it = SkillList.begin(); it < SkillList.end(); it++ ){
			if( it->Use == Use ){
				it->LastUsage = GetTickCount();
				it->CastingSkill = true;
			}
		}
		LeaveCriticalSection( &cs2 );

		char Packet[ 7 ];
		memcpy( Packet, "\x11\x05", 2 );
		Packet[ 2 ] = Use;
		memcpy( Packet + 3, &myTarget, 4 );
		SendPacket( Packet, 7 );
	}

	void Client::UseAttackSkill( BYTE Use, DWORD myTarget ){
		vector<Shaiya::Skill>::iterator it;
		EnterCriticalSection( &cs2 );
		for( it = SkillList.begin(); it < SkillList.end(); it++ ){
			if( it->Use == Use ){
				it->LastUsage = GetTickCount();
				it->CastingSkill = true;
			}
		}
		LeaveCriticalSection( &cs2 );

		char Packet[ 7 ];
		memcpy( Packet, "\x17\x05", 2 );
		Packet[ 2 ] = Use;
		memcpy( Packet + 3, &myTarget, 4 );
		SendPacket( Packet, 7 );
	}

	void Client::UpdateSkillUse( BYTE ID ){
		vector<Shaiya::Skill>::iterator it;
		EnterCriticalSection( &cs2 );
		for( it = SkillList.begin(); it < SkillList.end(); it++ ){
			if( it->ID == ID ){
				it->LastUsage = GetTickCount();
				it->CastingSkill = false;
				LeaveCriticalSection( &cs2 );
				return;
			}
		}
		LeaveCriticalSection( &cs2 );
		if( IsBotting )
			AttackTarget();
	}

	void Client::IsUsingSkill( BYTE Use, bool IsUsing ){
		vector<Shaiya::Skill>::iterator it;
		EnterCriticalSection( &cs2 );
		for( it = SkillList.begin(); it < SkillList.end(); it++ ){
			if( it->Use == Use )
				it->IsUsed = IsUsing;
		}
		LeaveCriticalSection( &cs2 );
	}

}