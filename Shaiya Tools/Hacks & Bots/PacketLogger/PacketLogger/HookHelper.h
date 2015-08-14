#include "pch.h"

extern DWORD Address;
extern DWORD ReturnAddress;
extern DWORD Address2;
extern DWORD ReturnAddress2;
extern DWORD Address3;

extern char *direction;
extern short opcode;
extern char *buf;
extern int len;

bool ScanForAddress();
bool Compare( BYTE* binData, BYTE* byteMask, char* charMask );
DWORD SearchMask( DWORD baseAddress, DWORD SearchLen, BYTE *ByteMask, char *CharMask );

