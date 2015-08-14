#include <iostream>
#include <Windows.h>
#include "PlayerInfo.h"
#include "d3d9.h"

//the variables that decide our crosshair information
std::string WindowName;

bool _StopThread; //used to stop the crosshair thread from outside
bool threadOver;
int _Scale = 0;

//ESP Vars
float ScreenX, ScreenY;
int resolution[2];
bool GotRes = false;
int screencenter[2];
float fov[2];
Vect3d viewAngles;
Vect3d * vForward, * vRight, * vUpward;
RECT * windowRectangle; // stores our window's data
int _ScaleESP = 1;// Draw all ESP's at medium size

//Aimbot m Esp Vars
//Used to ensure we stay focused on an enemy as long as we hold the HOT KEY, if we let go of it then when pressing again we find a new enemy
bool FocusingOnEnemy = false;
int FocusTarget = -1;
int EspChoice;
//Our Direct 3d drawing device
IDirect3DDevice9 *D3dDevice;
LPD3DXFONT M_font;
//used to draw our snap lines
//ID3DXLine * S_Line;
LPD3DXLINE S_Line;
RECT WindowRect; //Used to find where our window is located for aimbot
HWND Handle; // handle to our window
