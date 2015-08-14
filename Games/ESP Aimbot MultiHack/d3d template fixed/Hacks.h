	#pragma once

	#include <Windows.h>
	#include "d3d9.h"
	#include <ctime> //for the clock
	#include "Drawing.h"
	#include <iostream>
	#include <math.h>
	#include <algorithm> //USED FOR OUR SORTING ALGORITHM	
	#define D3DHOOK_TEXTURES //comment this to disable texture hooking
	#define MAX_MENU_ITEMS 6 //so you limit up to make sure everything else run smoothly

	//MOVE THESE to the top
	//these are just examples you can do your own
	#define ESP_BOX_NAME 0
	#define ESP_HEALTH 1
	#define ESP_DISTANCE 2
	#define SNAP_LINE 3
	#define AIMBOT_HK 4
	#define HIDE_MENU 5

	class Hacks
	{
	public:
		int m_Stride;
		/*Function prototypes*/
		void Hacks::CreateFont(IDirect3DDevice9 *d3dDevice, std::string choiceFont);
		void Hacks::InitializeMenuItems();
		void Hacks::DrawMenu(IDirect3DDevice9 *d3dDevice);
		void Hacks::KeyboardInput();

		//our colours For the chams textures
		//Spetznas and opfor
		LPDIRECT3DTEXTURE9 texRed;
		LPDIRECT3DTEXTURE9 texGreen;

		//Marines and SAS
		LPDIRECT3DTEXTURE9 texBlue; 
		LPDIRECT3DTEXTURE9 texWhite; 

		//used to get window size and other info
		D3DVIEWPORT9 g_ViewPort;

		//our font
		LPD3DXFONT m_font;

		//everything each hack needs bay bay
		struct d3dMenuHack
		{
			bool on;
			std::string name;
		};

		d3dMenuHack hack[MAX_MENU_ITEMS];
	};

	//We send these over to see whether we turn something on or not
	struct ESP_Options
	{
		bool box_Plus_Name;
		bool health;
		bool distance;
		bool snapLine;
		bool aimbot;
	};












