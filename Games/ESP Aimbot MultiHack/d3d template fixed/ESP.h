#pragma once
//Credits To Kn4cker for the World2Screen function and AngleVectors
#include <string.h>
#include <iostream>
#include <Windows.h>
#include "PlayerInfo.h"
#include "I_O.h"
#include "Drawing.h"
#include <vector> //Necessary for "Greater" when sorting Floats
#define MAXPLAYERS 64
//this below is used when drawing the health, if for example your game variable has a maximum of 250 health than that's what you would change it to
#define MAXHEALTH 100
//WRITE THE NAME OF YOUR GAME WINDOW HERE, MAKE SURE ITS CASE SENSITIVE
#define GAMENAME "Call of Duty 4"

class ESP
{
public:
	void Esp_Aimbot(bool Esp_box_Name, bool health, bool distance, bool snapLine, bool aimbot);
	ESP();
	void SetupDirect3D(IDirect3DDevice9 *d3dDevice, LPD3DXFONT * m_font);
	Vect3d SubVectorDist(PlayerDataVec &playerFrom, PlayerDataVec &playerTo);
	Vect3d SubVectorDist(Vect3d &playerFrom, Vect3d &playerTo);
	bool WorldToScreen(Vect3d &WorldLocation, Vect3d &mypos);
	void AngleVectors();
	void DrawESP(int x, int y, Color color, int crosshairChoice);
	void DrawESPBox(int x, int y, int w, int h, int thickness, D3DCOLOR Colour, IDirect3DDevice9 *pDevice);
	void DrawFilledRect(int x, int y, int w, int h, D3DCOLOR color, IDirect3DDevice9* dev);
	void UpdateResolution();
	void DrawMyHealth();
	void DrawEnemyHealth(int x, int y, int w, int h, int health);
	D3DCOLOR GetHealthColor(int currentHealth);
	float Get3dDistance(PlayerDataVec to, PlayerDataVec from);
	int FindClosestEnemyIndex(PlayerDataVec * enemiesDataVec, int enemiesDvLength, PlayerDataVec myPosition);
	//Function taken from UC
	void DrawLine(float StartX, float StartY, float EndX, float EndY, D3DCOLOR dColor );
};