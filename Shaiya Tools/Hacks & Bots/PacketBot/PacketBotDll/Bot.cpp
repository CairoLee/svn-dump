#include "resource.h"
#include "pch.h"
#include "Shaiya.h"

void SendPacket( char *buf, int len );
void RecvPacket( char *buf, DWORD len );

extern HWND FormHandle3;

using namespace std;



void BotThread(){
	while( true ){
		if( IsBotting ){
			vector<Shaiya::Skill>::iterator it;
			EnterCriticalSection( &cs2 );
			for( it = SkillList.begin(); it < SkillList.end(); it++ ){
				if( it->Type == 1 && it->CastingSkill && ( GetTickCount() - it->LastUsage ) >= 1000 ){
					char Packet[ 17 ];
					memcpy( Packet, "\x01\x05\x84\x66\x01", 5 );
					memcpy( Packet + 5, &(Player.X), 4 );
					memcpy( Packet + 9, &(Player.Y), 4 );
					memcpy( Packet + 13, &(Player.Z), 4 );
					SendPacket( Packet, 17 );

					UseBuff( it->Use, 0 );
				}

				if( it->Type == 2 && it->CastingSkill && ( GetTickCount() - it->LastUsage ) >= 1000 )
					UseAttackSkill( it->Use, Target );	

				if( it->Type == 1 && it->IsUsed && ( !it->LastUsage || ( GetTickCount() - it->LastUsage ) >= ( it->Cooldown * 1000 ) ) ){			
					char Packet[ 17 ];
					memcpy( Packet, "\x01\x05\x84\x66\x01", 5 );
					memcpy( Packet + 5, &(Player.X), 4 );
					memcpy( Packet + 9, &(Player.Y), 4 );
					memcpy( Packet + 13, &(Player.Z), 4 );
					SendPacket( Packet, 17 );

					UseBuff( it->Use, 0 );
				}

				if( it->Type == 2 && it->IsUsed && ( !it->LastUsage || ( GetTickCount() - it->LastUsage ) >= ( it->Cooldown * 1000 ) ) && Target )
					UseAttackSkill( it->Use, Target );	
			}
			LeaveCriticalSection( &cs2 );
		}
		Sleep( 1 );
	}
}


void StartBot(){
	EnableWindow( GetDlgItem( FormHandle3, IDC_EDIT5 ), false );
	EnableWindow( GetDlgItem( FormHandle3, IDC_EDIT7 ), false );
	char c[ 50 ];
	char *temp;
	GetWindowText( GetDlgItem( FormHandle3, IDC_EDIT5 ), c, 50 );
	HuntingRadius = strtol(c, &temp, 10);
	SetHuntingArea( HuntingRadius );
	GetWindowText( GetDlgItem( FormHandle3, IDC_EDIT7 ), c, 50 );
	AttackDistance = strtol( c, &temp, 10 );
	RecvPacket( "\x0B\xF9\x0B\x42ot started", 0x0E );
	RecvPacket( "\x0B\xF9\x3APlease don't move your character while the bot is running!", 0x3D );
	SetWindowText( GetDlgItem( FormHandle3, IDC_BUTTON1 ), "Stop Bot [F6]" );
	TargetNextMonster();
}

void StopBot(){
	EnableWindow( GetDlgItem( FormHandle3, IDC_EDIT5 ), true );
	EnableWindow( GetDlgItem( FormHandle3, IDC_EDIT7 ), true );
	RecvPacket( "\x0B\xF9\x0B\x42ot stopped", 0x0E );
	SetWindowText( GetDlgItem( FormHandle3, IDC_BUTTON1 ), "Start Bot [F6]") ;
}
