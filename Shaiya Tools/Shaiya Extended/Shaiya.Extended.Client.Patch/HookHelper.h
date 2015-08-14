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
bool Compare( const BYTE *pData, const BYTE *bMask, const char *szMask );
DWORD SearchMask( DWORD dwAddress, DWORD dwLen, BYTE *bMask, char *szMask );

