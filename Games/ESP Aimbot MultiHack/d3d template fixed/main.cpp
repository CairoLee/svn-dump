/*
D3D MultiHack For COD4
Originally Created by [Fleep] or Insert your name Here :)
www.GuidedHacking.com ->Friendly Game Hacking feel free to check us out for many tutorials, Sources like these and Releases

Feel free to use this source for whatever reason you like but if you could leave my name
somewhere in the credits i would be thankful.

Also if you release any hacks publicly then you are welcome to post the hacks/tutorials
on the forums mentioned above, any releases are appreciated.

Thanks and hope you enjoy the code, feel free to adapt your own hook because the one currently used is just for testing
and is most likely detectable in most games. The source is Good though and can easily be adapted to ANY game other than COD4 
as long as you can get the Memory addresses for your own game.

Credits to a couple of People:
KN4CK3R mainly for releasing a couple of very useful functions, also got help from a couple of posts at Unknown cheats 
(sorry don't recall names)
*/

#include <windows.h>
#include <fstream>
#include <stdio.h>
using namespace std;

#include "main.h"
#include "d3d9.h"

//Globals
ofstream ofile;	
char dlldir[320];

bool WINAPI DllMain(HMODULE hDll, DWORD dwReason, PVOID pvReserved)
{
	if(dwReason == DLL_PROCESS_ATTACH)
	{
		DisableThreadLibraryCalls(hDll);
		HMODULE hMod = LoadLibrary("d3d9.dll");		
	
		oDirect3DCreate9 = (tDirect3DCreate9)DetourFunc(
			(BYTE*)GetProcAddress(hMod, "Direct3DCreate9"),
			(BYTE*)hkDirect3DCreate9, 
			5);

		return true;
	}

    return false;
}

void *DetourFunc(BYTE *src, const BYTE *dst, const int len)
{
	BYTE *jmp = (BYTE*)malloc(len+5);
	DWORD dwback;

	VirtualProtect(src, len, PAGE_READWRITE, &dwback);

	memcpy(jmp, src, len);	jmp += len;
	
	jmp[0] = 0xE9;
	*(DWORD*)(jmp+1) = (DWORD)(src+len - jmp) - 5;

	src[0] = 0xE9;
	*(DWORD*)(src+1) = (DWORD)(dst - src) - 5;

	VirtualProtect(src, len, dwback, &dwback);

	return (jmp-len);
}

bool RetourFunc(BYTE *src, BYTE *restore, const int len)
{
	DWORD dwback;
		
	if(!VirtualProtect(src, len, PAGE_READWRITE, &dwback))	{ return false; }
	if(!memcpy(src, restore, len))							{ return false; }

	restore[0] = 0xE9;
	*(DWORD*)(restore+1) = (DWORD)(src - restore) - 5;

	if(!VirtualProtect(src, len, dwback, &dwback))			{ return false; }
	
	return true;
}	
