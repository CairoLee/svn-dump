
#include "stdafx.h"
#include "AnalyzePacket.h"
#include <stdio.h>

void TryToLogin(char *user);
void LoginSuccessful();
void EnteredWorld();
void RecvPacket(char *buf, DWORD len);
void UpdatePlayerPos(float x, float y, float z);
void AttackTarget();
void AddMonster(DWORD ID, float X, float Z);
void UpdateMonster(DWORD ID, float X, float Z);
void DeleteMonster(DWORD ID);
void TargetNextMonster();
void PickItem(DWORD ItemID);
void TargetMonster(DWORD ID);
void SetPlayerID(DWORD ID);
void CheckMonster(DWORD ID, float X, float Z);
void ActivateBot();
void SellItem(BYTE Page, BYTE Place, BYTE Count);
void IncreaseKillcount();
void AddSkill(BYTE ID, BYTE Level, BYTE Use);
void UpdateSkillUse(BYTE ID);

DWORD PlayerID;

extern DWORD Target;
extern bool IsBotting;
extern bool PickItems;
extern bool DoSellItems;
extern bool CastingSkill;


void AnalyzePacket(char *direction, WORD opcode, char *buf, int len)
{
	if (direction[0] == 'S')
	{
		float x, y, z;
		switch (opcode)
		{
			case 0x0104:
				DWORD ID;
				memcpy(&ID, buf + 2, 4);
				PlayerID = ID;
				SetPlayerID(ID);
				break;

			case 0x0201:
				if (len == 2)
					EnteredWorld();
				break;

			case 0x0305:
				memcpy(&Target, buf + 2, sizeof(DWORD));
				if (IsBotting)
					AttackTarget();
				break;

			case 0x0501:
				memcpy(&x, buf + 5, 4);
				memcpy(&y, buf + 9, 4);
				memcpy(&z, buf + 13, 4);
				UpdatePlayerPos(x, y, z);
				break;

			case 0x0503:
				memcpy(&Target, buf + 2, sizeof(DWORD));
				break;

			case 0xA102:
				TryToLogin(buf + 2);		
				break;
		}
	}

	if (direction[0] == 'R')
	{
		DWORD ID;
		BYTE SkillID;
		float X, Y, Z;
		switch (opcode)
		{
			case 0x0108:
				for (int i = 0; i < ((len - 3) / 6); i++)
				{
					BYTE ID = buf[3 + (i * 6)];
					BYTE Level =  buf[5 + (i * 6)];
					BYTE Use =  buf[6 + (i * 6)];
					AddSkill(ID, Level, Use);
				}
				break;

			case 0x0201:
				if (!memcmp(buf + 2, &PlayerID, 4))
				{
					memcpy(&X, buf + 9, 4);
					memcpy(&Y, buf + 13, 4);
					memcpy(&Z, buf + 17, 4);
					UpdatePlayerPos(X, Y, Z);
					ActivateBot();
				}
			break;

			case 0x0205:
				if ((IsBotting) && (PickItems) && (DoSellItems))
				{
					BYTE Page = buf[2];
					BYTE Place = buf[3];
					WORD Type;
					memcpy(&Type, buf + 4, 2);
					BYTE Count = buf[6];
					if (Type != 0x1A)
						SellItem(Page, Place, Count);
				}
				break;

			case 0x0305:
				if ((IsBotting) && (!memcmp(buf + 2, &Target, 4)) && (!memcmp(buf + 6, "\x00\x00\x00\x00", 4)))
					TargetNextMonster();

				break;

			case 0x0401:
				DWORD ItemID;
				memcpy(&ItemID, buf + 2, 4);
				if ((IsBotting) && (PickItems))
					PickItem(ItemID);
				break;

			case 0x0511:
				if (!memcmp(buf + 3, &PlayerID, 4))
				{
					SkillID = buf[11];
					UpdateSkillUse(SkillID);
				}
				break;

			case 0x0517:
				if (!memcmp(buf + 3, &PlayerID, 4))
				{
					SkillID = buf[11];
					UpdateSkillUse(SkillID);
				}
				break;

			case 0x0601:		
				memcpy(&ID, buf + 2, 4);
				memcpy(&X, buf + 9, 4);
				memcpy(&Z, buf + 13, 4);
				AddMonster(ID, X, Z);

				if ((IsBotting) && (!Target))
					CheckMonster(ID, X, Z);
				break;

			case 0x0602:
				memcpy(&ID, buf + 2, 4);
				if ((ID == Target) && (IsBotting))
				{
					Target = 0;
					IncreaseKillcount();
					TargetNextMonster();
				}			
				DeleteMonster(ID);
				break;

			case 0x0603:
				memcpy(&ID, buf + 2, 4);
				memcpy(&X, buf + 7, 4);
				memcpy(&Z, buf + 11, 4);
				UpdateMonster(ID, X, Z);

				if ((IsBotting) && (!Target))
					CheckMonster(ID, X, Z);
				break;

			case 0x0605:
/*				if (IsBotting)
				{
					memcpy(&ID, buf + 3, 4);
					TargetMonster(ID);
				}*/
				break;

			case 0x0606:
				memcpy(&ID, buf + 2, 4);
				if ((ID == Target) && (IsBotting))
				{
					Target = 0;
					IncreaseKillcount();
					TargetNextMonster();
				}			
				DeleteMonster(ID);
				break;

			case 0xA102:
				if (buf[2] == 0x00)
					LoginSuccessful();
				break;
		}
	}

}

void EnteredWorld()
{
	RecvPacket("\x0B\xF9\x12Welcome to Shaiya!", 0x15);
	RecvPacket("\x0B\xF9\x61If you find any bugs in the tool, please report them in the Shaiya-Section of www.elitepvpers.de!", 0x64);
}