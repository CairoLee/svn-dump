
#include "stdafx.h"
#include "Form.h"
#include "resource.h"
#include <stdio.h>
#include <stdlib.h>


HWND FormHandle = 0;
HWND FormHandle2 = 0;
HWND FormHandle3 = 0;
bool IsDialogVisible = true;
bool IsLoggingPackets = false;

extern bool IsBotting;
extern DWORD Target;
extern DWORD HuntingRadius;
extern bool LoggedIn;
extern bool PickItems;
extern bool DoSellItems;
extern bool DoRepairEquipment;
extern bool UseOnlySkills;
extern bool BotReady;
extern DWORD Killcount;
extern DWORD AttackDistance;

char Account[32] = "";

void SendPacket(char *buf, int len);
void TargetNextMonster();
void AttackTarget();
void SetHuntingArea(DWORD Radius);
void IsUsingSkill(BYTE Use, bool IsUsing);
void StartBot();
void StopBot();

BOOL CALLBACK Dlgproc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	switch(uMsg)
	{
		case WM_COMMAND:
			switch(LOWORD(wParam))
			{
				case IDC_BUTTON1:
					ShowWindow(FormHandle2, SW_HIDE);
					ShowWindow(FormHandle3, SW_SHOW);
					break;

				case IDC_BUTTON5:
					ShowWindow(hWnd, SW_HIDE);
					IsDialogVisible = false;
					break;

				case IDC_BUTTON8:
					ShowWindow(FormHandle2, SW_SHOW);
					ShowWindow(FormHandle3, SW_HIDE);
					break;
			}
	}
	return FALSE;
}

BOOL CALLBACK Dlgproc2(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	switch(uMsg)
	{
		case WM_COMMAND:
			switch(LOWORD(wParam))
			{
				case IDC_BUTTON1:
					SendPacketInEdit(GetDlgItem(hWnd, IDC_EDIT1));
					break;
				case IDC_BUTTON2:
					ClearListBox(GetDlgItem(hWnd, IDC_LIST1));
					break;
				case IDC_BUTTON3:
					SelectedPacketsToClipboard(GetDlgItem(hWnd, IDC_LIST1));
					break;
				case IDC_BUTTON4:
					AllPacketsToClipboard(GetDlgItem(hWnd, IDC_LIST1));
					break;
				case IDC_BUTTON6:
					IsLoggingPackets = true;
					EnableWindow(GetDlgItem(hWnd, IDC_BUTTON6), false);
					EnableWindow(GetDlgItem(hWnd, IDC_BUTTON7), true);
					break;
				case IDC_BUTTON7:
					IsLoggingPackets = false;
					EnableWindow(GetDlgItem(hWnd, IDC_BUTTON6), true);
					EnableWindow(GetDlgItem(hWnd, IDC_BUTTON7), false);
					break;
			}
	}
	return FALSE;
}

BOOL CALLBACK Dlgproc3(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	switch(uMsg)
	{
		case WM_COMMAND:
			switch(LOWORD(wParam))
			{
				case IDC_BUTTON1:
					IsBotting = !IsBotting;				
					if (IsBotting)
						StartBot();
					else
						StopBot();		
					break;

				case IDC_CHECK1:
					PickItems = !PickItems;
					if (PickItems)
						EnableWindow(GetDlgItem(hWnd, IDC_CHECK2), true);
					else
						EnableWindow(GetDlgItem(hWnd, IDC_CHECK2), false);
					break;

				case IDC_CHECK2:
					DoSellItems = !DoSellItems;
					break;

				case IDC_CHECK3:
					DoRepairEquipment = !DoRepairEquipment;
					break;

				case IDC_CHECK4:
					UseOnlySkills = !UseOnlySkills;
					break;

				case IDC_BUTTON4:
					ClearListBox(GetDlgItem(hWnd, IDC_LIST2));
					char c[100];
					DWORD Count = SendMessage(GetDlgItem(hWnd, IDC_LIST1), LB_GETCOUNT, 0, 0);
					if ((Count != 0) && (Count != LB_ERR))
					{		
						for (BYTE i = 0; i < Count; i++)
						{
							if (SendMessage(GetDlgItem(hWnd, IDC_LIST1), LB_GETSEL, i, 0) > 0)
							{
								SendMessage(GetDlgItem(hWnd, IDC_LIST1), LB_GETTEXT, i, (LPARAM)c);
								SendMessage(GetDlgItem(hWnd, IDC_LIST2), LB_ADDSTRING, i, (LPARAM)c);
								IsUsingSkill(i, true);
							}
							else
								IsUsingSkill(i, false);
						}
					}
					break;

			}
	}
	return FALSE;
}

DWORD ShowDialog(HMODULE hInstance)
{
	MSG msg;
	HWND hWnd;
	HWND hWnd2;
	HWND hWnd3;

	hWnd = CreateDialog(hInstance, MAKEINTRESOURCE(IDD_DIALOG1), NULL, (DLGPROC)Dlgproc);
	SetWindowLong(hWnd, GWL_EXSTYLE, GetWindowLong(hWnd, GWL_EXSTYLE) | WS_EX_TOOLWINDOW);
	ShowWindow(hWnd, SW_SHOW);
	FormHandle = hWnd;

	hWnd2 = CreateDialog(hInstance, MAKEINTRESOURCE(IDD_DIALOG2), hWnd, (DLGPROC)Dlgproc2);
	ShowWindow(hWnd2, SW_HIDE);
	FormHandle2 = hWnd2;

	hWnd3 = CreateDialog(hInstance, MAKEINTRESOURCE(IDD_DIALOG3), hWnd, (DLGPROC)Dlgproc3);
	ShowWindow(hWnd3, SW_SHOW);
	FormHandle3 = hWnd3;

	HFONT hFont = CreateFont(9, 0, 0, 0, FW_NORMAL, FALSE, FALSE,FALSE, 0, OUT_DEFAULT_PRECIS, CLIP_DEFAULT_PRECIS, DEFAULT_QUALITY, DEFAULT_PITCH|FF_SWISS, "Lucida Console");
	SendMessage(GetDlgItem(hWnd2, IDC_LIST1), WM_SETFONT, (WPARAM)hFont, 0xFFFFFFFF);
	SetWindowText(GetDlgItem(hWnd3, IDC_EDIT5), "20");
	SendMessage(GetDlgItem(hWnd3, IDC_CHECK1), BM_SETCHECK, (WPARAM)BST_CHECKED, 0);
	SendMessage(GetDlgItem(hWnd3, IDC_CHECK3), BM_SETCHECK, (WPARAM)BST_CHECKED, 0);
	SetWindowText(GetDlgItem(hWnd3, IDC_EDIT6), "0");
	SetWindowText(GetDlgItem(hWnd3, IDC_EDIT7), "5");

	while(GetMessage(&msg, hWnd, 0, 0) > 0)
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	return true;
}

void DisplayPacket(char *direction, char *buf, int len)
{
	if (IsLoggingPackets)
	{
		char *Packet = new char[10000];
		strcpy_s(Packet, 10000, direction);
		CreatePacketString((BYTE *)buf, len, Packet);
		SendMessage(GetDlgItem(FormHandle2, IDC_LIST1), LB_ADDSTRING, NULL, (LPARAM)Packet);
		delete Packet;
	}
}

void CreatePacketString(BYTE *BufferPointer, DWORD BufferLength, char *PacketString)
{
	char PacketByte[4];
	for (DWORD i = 0; i < BufferLength; i++)
	{
		sprintf_s(PacketByte, 4, "%02X ", BufferPointer[i]);
		strcat_s(PacketString, 10000, PacketByte);
	}
}

void FormatMyString(char *src, char *dst)
{
	DWORD i = 0;
	while (src[i])
	{
		dst[i] = toupper(src[i]);
		i++;
	}
	i = 0;
	char temp[1000] = "";
	while (dst[i])
	{
		if ((dst[i] != '0') && (dst[i] != '1') && (dst[i] != '2') && (dst[i] != '3') &&
			(dst[i] != '4') && (dst[i] != '5') && (dst[i] != '6') && (dst[i] != '7') &&
			(dst[i] != '8') && (dst[i] != '9') && (dst[i] != 'A') && (dst[i] != 'B') &&
			(dst[i] != 'C') && (dst[i] != 'D') && (dst[i] != 'E') && (dst[i] != 'F'))
		{
			strcpy_s(temp, 1000, &dst[i+1]);
			strcpy_s(&dst[i], 1000, temp);
		}
		else
			i++;
	}

	i = 2;
	while (dst[i])
	{
		strcpy_s(temp, 1000, &dst[i]);
		strcpy_s(&dst[i+1], 1000, temp);
		dst[i] = ' ';
		i += 3;
	}
}

DWORD StringToByteArray(char *str, char *pbyte)
{
	DWORD ArraySize = ((strlen(str) + 1) / 3);
	char *pEnd = str;
	for (DWORD i = 0; i < ArraySize; i++)
	{
		pbyte[i] = (BYTE)strtol(pEnd, &pEnd, 16);
	}
	return ArraySize;
}

void SendPacketInEdit(HWND Edit)
{
	char *Packet = new char[1000];
	memset(Packet, 0, 1000);
	char PacketString[1000];
	char FormatedPacketString[1000] = "";
	GetWindowText(Edit, PacketString, 1000);
	FormatMyString(PacketString, FormatedPacketString);
	SetWindowText(Edit, FormatedPacketString);
	DWORD PacketLength = StringToByteArray(FormatedPacketString, Packet);
	SendPacket(Packet, PacketLength);
}

void ClearListBox(HWND ListBox)
{
	DWORD ListCount = SendMessage(ListBox, LB_GETCOUNT, NULL, NULL);
	for (DWORD i = 0; i < ListCount; i++)
		PostMessage(ListBox, LB_DELETESTRING, 0, NULL);
}

void SelectedPacketsToClipboard(HWND ListBox)
{
	char *Packet = new char[1000000];
	Packet[0] = '\0';
	DWORD Count = SendMessage(ListBox, LB_GETCOUNT, 0, 0);
	if ((Count != 0) && (Count != LB_ERR))
	{		
		for (DWORD i = 0; i < Count; i++)
		{
			if (SendMessage(ListBox, LB_GETSEL, i, 0) > 0)
			{
				DWORD Size = strlen(Packet);
				if (Size > 0)
				{
					Packet[Size] = '\r';
					Packet[Size+1] = '\n';
					SendMessage(ListBox, LB_GETTEXT, i, (LPARAM)&Packet[Size+2]);
				}
				else
					SendMessage(ListBox, LB_GETTEXT, i, (LPARAM)Packet);
			}
		}
		if (strlen(Packet) > 0)
			CopyToClipboard(Packet);
	}
	delete Packet;
}

void AllPacketsToClipboard(HWND ListBox)
{
	char *Packet = new char[100000];
	Packet[0] = '\0';
	DWORD Count = SendMessage(ListBox, LB_GETCOUNT, 0, 0);
	if ((Count != 0) && (Count != LB_ERR))
	{						
		for (DWORD i = 0; i < Count; i++)
		{
			DWORD Size = strlen(Packet);
			if (Size > 0)
			{
				Packet[Size] = '\r';
				Packet[Size+1] = '\n';
				SendMessage(ListBox, LB_GETTEXT, i, (LPARAM)&Packet[Size+2]);
			}
			else
				SendMessage(ListBox, LB_GETTEXT, i, (LPARAM)Packet);
		}	
		CopyToClipboard(Packet);
	}
	delete Packet;
}

void CopyToClipboard(char *source)
{
	OpenClipboard(NULL);
	EmptyClipboard();
	HANDLE hMem;
	char *lpMem;
	DWORD szSize = strlen(source);
	hMem = GlobalAlloc(GMEM_MOVEABLE, szSize + 1);
	lpMem = (char *)GlobalLock(hMem);
	memcpy(lpMem, source, strlen(source) + 1);
	GlobalUnlock(hMem);
	SetClipboardData(CF_TEXT, hMem);
	CloseClipboard();
}

extern DWORD Target;

void CatchKeystrokes(HWND hWnd)
{
	bool KeyIsPressed = false;
	bool Key2IsPressed = false;
	while (true)
	{
		if (GetAsyncKeyState(VK_F5) < 0)
		{
			if (!KeyIsPressed)
			{
				KeyIsPressed = true;

				if (IsDialogVisible)
					ShowWindow(FormHandle, SW_HIDE);
				else
					ShowWindow(FormHandle, SW_SHOW);
				IsDialogVisible = !IsDialogVisible;
			}
		}
		else
			KeyIsPressed = false;

		if (GetAsyncKeyState(VK_F6) < 0)
		{
			if ((!Key2IsPressed) && (BotReady))
			{
				Key2IsPressed = true;

				IsBotting = !IsBotting;				
				if (IsBotting)
					StartBot();
				else
					StopBot();
			}
		}
		else
			Key2IsPressed = false;

		Sleep(1);
	}
}

void TryToLogin(char *user)
{
	strcpy_s(Account, 32, user);
}

void LoginSuccessful()
{
	LoggedIn = true;
	SetWindowText(FormHandle, Account);
}