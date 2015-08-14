
#include "stdafx.h"
#include "resource.h"
#include "Bot.h"
#include "stdio.h"
#include <vector>
#include <math.h>

void SendPacket(char *buf, int len);
void RecvPacket(char *buf, DWORD len);

extern HWND FormHandle3;

using namespace std;

bool IsBotting = false;
DWORD Target = 0;
Creature Player;
vector<Creature> Monster;
vector<Skill> Skills;
bool LoggedIn = false;
bool PickItems = true;
bool DoSellItems = false;
bool DoRepairEquipment = true;
bool UseOnlySkills = false;
bool BotReady = false;
CRITICAL_SECTION cs;
CRITICAL_SECTION cs2;
DWORD Killcount = 0;
DWORD Repaircount = -1;

float HuntingX = 0;
float HuntingZ = 0;
DWORD HuntingRadius = 20;
DWORD AttackDistance = 5;


void BotThread()
{
	while (true)
	{
		if (IsBotting)
		{
			vector<Skill>::iterator it;
			EnterCriticalSection(&cs2);
			for (it = Skills.begin(); it < Skills.end(); it++)
			{
				if ((it->Type == 1) && (it->CastingSkill) && (GetTickCount() - it->LastUsage >= 1000))
				{
					char Packet[17];
					memcpy(Packet, "\x01\x05\x84\x66\x01", 5);
					memcpy(Packet + 5, &(Player.X), 4);
					memcpy(Packet + 9, &(Player.Y), 4);
					memcpy(Packet + 13, &(Player.Z), 4);
					SendPacket(Packet, 17);

					UseBuff(it->Use, 0);
				}

				if ((it->Type == 2) && (it->CastingSkill) && (GetTickCount() - it->LastUsage >= 1000))
					UseAttackSkill(it->Use, Target);	

				if ((it->Type == 1) && (it->IsUsed) && ((!(it->LastUsage)) || (GetTickCount() - it->LastUsage >= it->Cooldown * 1000)))
				{			
					char Packet[17];
					memcpy(Packet, "\x01\x05\x84\x66\x01", 5);
					memcpy(Packet + 5, &(Player.X), 4);
					memcpy(Packet + 9, &(Player.Y), 4);
					memcpy(Packet + 13, &(Player.Z), 4);
					SendPacket(Packet, 17);

					UseBuff(it->Use, 0);
				}

				if ((it->Type == 2) && (it->IsUsed) && ((!(it->LastUsage)) || (GetTickCount() - it->LastUsage >= it->Cooldown * 1000)) && (Target))
					UseAttackSkill(it->Use, Target);	
			}
			LeaveCriticalSection(&cs2);
		}
		Sleep(1);
	}
}

void UpdatePlayerPos(float x, float y, float z)
{
	Player.X = x;
	Player.Y = y;
	Player.Z = z;
	char xs[10];
	char ys[10];
	char zs[10];
	sprintf_s(xs, "%.3f", x);
	sprintf_s(ys, "%.3f", y);
	sprintf_s(zs, "%.3f", z);
	SetWindowText(GetDlgItem(FormHandle3, IDC_EDIT1), xs);
	SetWindowText(GetDlgItem(FormHandle3, IDC_EDIT2), ys);
	SetWindowText(GetDlgItem(FormHandle3, IDC_EDIT3), zs);
}

void AttackTarget()
{
	float X, Z;
	vector<Creature>::iterator it;
	EnterCriticalSection(&cs);
	for (it = Monster.begin(); it < Monster.end(); it++)
	{
		if (it->ID == Target)
		{
			X = it->X;
			Z = it->Z;
		}
	}
	LeaveCriticalSection(&cs);

	float temp = Pythagorean(Player.X, Player.Z, X, Z);
	temp /= AttackDistance;
	X -= ((X - Player.X) / temp);
	Z -= ((Z - Player.Z) / temp);

	char *Packet = new char[50];
	SendPacket("\x12\x02", 2);
	memcpy(Packet, "\x01\x05\x84\x66\x01", 5);
	memcpy(Packet + 5, &(X), 4);
	memcpy(Packet + 9, &(Player.Y), 4);
	memcpy(Packet + 13, &(Z), 4);
	SendPacket(Packet, 17);
	if (!UseOnlySkills)
	{
		memcpy(Packet, "\x03\x05", 2);
		memcpy(Packet + 2, &Target, 4);
		SendPacket(Packet, 6);
	}
	delete Packet;
}

void AddMonster(DWORD ID, float X, float Z)
{
	Creature myMonster;
	myMonster.ID = ID;
	myMonster.X = X;
	myMonster.Z = Z;
	EnterCriticalSection(&cs);
	Monster.push_back(myMonster);
	LeaveCriticalSection(&cs);
}

void UpdateMonster(DWORD ID, float X, float Z)
{
	vector<Creature>::iterator it;
	EnterCriticalSection(&cs);
	for (it = Monster.begin(); it < Monster.end(); it++)
	{
		if (it->ID == ID)
		{
			it->X = X;
			it->Z = Z;
			LeaveCriticalSection(&cs);
			return;
		}
	}
	LeaveCriticalSection(&cs);
}

void DeleteMonster(DWORD ID)
{
	vector<Creature>::iterator it;
	EnterCriticalSection(&cs);
	for (it = Monster.begin(); it < Monster.end(); it++)
	{
		if (it->ID == ID)
		{	
			Monster.erase(it);
			LeaveCriticalSection(&cs);
			return;
		}
	}
	LeaveCriticalSection(&cs);
}

void TargetNextMonster()
{	
	if ((Killcount % 30 == 0) && (DoRepairEquipment) && (Repaircount != Killcount))
	{
		Repaircount = Killcount;
		RepairEquipment();
	}
	float Distance = 0;
	float Distance2 = 0;
	DWORD ID = 0;
	float Radius = 0;
	
	vector<Creature>::iterator it;
	EnterCriticalSection(&cs);
	for (it = Monster.begin(); it < Monster.end(); it++)
	{
		Distance = Pythagorean(it->X, it->Z, Player.X, Player.Z);
		Radius = Pythagorean(it->X, it->Z, HuntingX, HuntingZ);
		if (((Distance2 == 0) || (Distance < Distance2)) && (Radius <= HuntingRadius))
		{
			Distance2 = Distance;
			ID = it->ID;
		}
	}
	LeaveCriticalSection(&cs);
	if (ID)
		TargetMonster(ID);
	else
		Target = 0;
}

float Pythagorean(float X1, float Z1, float X2, float Z2)
{
	return sqrt(abs(X2 - X1) * abs(X2 - X1) + abs(Z2 - Z1) * abs(Z2 - Z1));
}

void PickItem(DWORD ItemID)
{
	char *Packet = new char[6];
	memcpy(Packet, "\x05\x02", 2);
	memcpy(Packet + 2, &ItemID, 4);
	SendPacket(Packet, 6);
	delete Packet;
}

void TargetMonster(DWORD ID)
{
	Target = ID;
	char *Packet = new char[6];
	memcpy(Packet, "\x05\x03", 2);
	memcpy(Packet + 2, &ID, 4);
	SendPacket(Packet, 6);
	delete Packet;
}

void SetPlayerID(DWORD ID)
{
	Player.ID = ID;
	char c[20];
	sprintf_s(c, 20, "%d", ID);
	SetWindowText(GetDlgItem(FormHandle3, IDC_EDIT4), c);
}

void SetHuntingArea(DWORD Radius)
{
	HuntingX = Player.X;
	HuntingZ = Player.Z;
	HuntingRadius = Radius;
}

void CheckMonster(DWORD ID, float X, float Z)
{
	if (Pythagorean(X, Z, HuntingX, HuntingZ) <= HuntingRadius)
		TargetMonster(ID);
}

void ActivateBot()
{
	if (LoggedIn)
	{
		BotReady = true;
		EnableWindow(GetDlgItem(FormHandle3, IDC_BUTTON1), true);
	}
}

void SellItem(BYTE Page, BYTE Place, BYTE Count)
{
	char Packet[5];
	memcpy(Packet, "\x03\x07", 2);
	Packet[2] = Page;
	Packet[3] = Place;
	Packet[4] = Count;
	SendPacket(Packet, 5);
}

void IncreaseKillcount()
{
	Killcount++;
	char c[20];
	sprintf_s(c, 20, "%d", Killcount);
	SetWindowText(GetDlgItem(FormHandle3, IDC_EDIT6), c);	
}

void RepairEquipment()
{
	SendPacket("\x54\x05\xFF\xFF", 4);
}

void AddSkill(BYTE ID, BYTE Level, BYTE Use)
{
	char Path[MAX_PATH];
	GetCurrentDirectory(MAX_PATH, Path);
	strcat_s(Path, MAX_PATH, "\\skills.ini");

	char c[100];	
	sprintf_s(c, 100, "%d.%d", ID, Level);

	Skill mySkill;
	mySkill.ID = ID;
	mySkill.IsUsed = false;
	mySkill.LastUsage = 0;
	mySkill.Level = Level;
	mySkill.Type = GetPrivateProfileInt(c, "Type", 0, Path);
	mySkill.Use = Use;
	mySkill.Cooldown = GetPrivateProfileInt(c, "Cooldown", 1, Path);
	EnterCriticalSection(&cs2);
	Skills.push_back(mySkill);
	LeaveCriticalSection(&cs2);

	char Skillname[100];
	GetPrivateProfileString(c, "Name", c, Skillname, 100, Path);
	SendMessage(GetDlgItem(FormHandle3, IDC_LIST1), LB_ADDSTRING, NULL, (LPARAM)Skillname);
}

void UseBuff(BYTE Use, DWORD myTarget)
{
	vector<Skill>::iterator it;
	EnterCriticalSection(&cs2);
	for (it = Skills.begin(); it < Skills.end(); it++)
	{
		if (it->Use == Use)
		{
			it->LastUsage = GetTickCount();
			it->CastingSkill = true;
		}
	}
	LeaveCriticalSection(&cs2);

	char Packet[7];
	memcpy(Packet, "\x11\x05", 2);
	Packet[2] = Use;
	memcpy(Packet + 3, &myTarget, 4);
	SendPacket(Packet, 7);
}

void UseAttackSkill(BYTE Use, DWORD myTarget)
{
	vector<Skill>::iterator it;
	EnterCriticalSection(&cs2);
	for (it = Skills.begin(); it < Skills.end(); it++)
	{
		if (it->Use == Use)
		{
			it->LastUsage = GetTickCount();
			it->CastingSkill = true;
		}
	}
	LeaveCriticalSection(&cs2);

	char Packet[7];
	memcpy(Packet, "\x17\x05", 2);
	Packet[2] = Use;
	memcpy(Packet + 3, &myTarget, 4);
	SendPacket(Packet, 7);
}

void UpdateSkillUse(BYTE ID)
{
	vector<Skill>::iterator it;
	EnterCriticalSection(&cs2);
	for (it = Skills.begin(); it < Skills.end(); it++)
	{
		if (it->ID == ID)
		{
			it->LastUsage = GetTickCount();
			it->CastingSkill = false;
			LeaveCriticalSection(&cs2);
			return;
		}
	}
	LeaveCriticalSection(&cs2);
	if (IsBotting)
		AttackTarget();
}

void IsUsingSkill(BYTE Use, bool IsUsing)
{
	vector<Skill>::iterator it;
	EnterCriticalSection(&cs2);
	for (it = Skills.begin(); it < Skills.end(); it++)
	{
		if (it->Use == Use)
			it->IsUsed = IsUsing;
	}
	LeaveCriticalSection(&cs2);
}

void StartBot()
{
	EnableWindow(GetDlgItem(FormHandle3, IDC_EDIT5), false);
	EnableWindow(GetDlgItem(FormHandle3, IDC_EDIT7), false);
	char c[50];
	char *temp;
	GetWindowText(GetDlgItem(FormHandle3, IDC_EDIT5), c, 50);
	HuntingRadius = strtol(c, &temp, 10);
	SetHuntingArea(HuntingRadius);
	GetWindowText(GetDlgItem(FormHandle3, IDC_EDIT7), c, 50);
	AttackDistance = strtol(c, &temp, 10);
	RecvPacket("\x0B\xF9\x0B\x42ot started", 0x0E);
	RecvPacket("\x0B\xF9\x3APlease don't move your character while the bot is running!", 0x3D);
	SetWindowText(GetDlgItem(FormHandle3, IDC_BUTTON1), "Stop Bot [F6]");
	TargetNextMonster();
}

void StopBot()
{
	EnableWindow(GetDlgItem(FormHandle3, IDC_EDIT5), true);
	EnableWindow(GetDlgItem(FormHandle3, IDC_EDIT7), true);
	RecvPacket("\x0B\xF9\x0B\x42ot stopped", 0x0E);
	SetWindowText(GetDlgItem(FormHandle3, IDC_BUTTON1), "Start Bot [F6]");
}