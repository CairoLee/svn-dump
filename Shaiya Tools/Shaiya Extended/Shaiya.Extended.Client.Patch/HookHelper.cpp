#include "pch.h"
#include "DebugLog.h"
#include "HookHelper.h"

DWORD Address = 0;
DWORD ReturnAddress = 0;
DWORD Address2 = 0;
DWORD ReturnAddress2 = 0;
DWORD Address3 = 0;

bool ScanForAddress(){
	DWORD Base = 4194304; // 0x00400000
	DWORD SizeOfCode;

	DWORD i = Base;
	while( memcmp( (void *)i, "PE", 4 ) )
		i++;

	if( i <= ( Base + 4096 ) )
		SizeOfCode = *(DWORD *)( i + 28 );

	BYTE ByteMask[] = { 0x8B, 0xCB, 0x8B, 0xD1, 0xC1, 0xE9, 0x02, 0x8D, 0x43, 0x02, 0x66, 0x89, 0x44, 0x24, 0x20 };
	Address = SearchMask( Base + 0x1000, SizeOfCode, ByteMask, "###############" ) - 0x38; // 15
	ReturnAddress = Address;
	ReturnAddress += 6;

	BYTE ByteMask2[] = { 0xB8, 0x8C, 0x60, 0x00, 0x00, 0xE8 };
	Address2 = SearchMask( Base + 0x1000, SizeOfCode, ByteMask2, "######" ); // 6
	ReturnAddress2 = Address2;
	ReturnAddress2 += 5;
	
	BYTE ByteMask3[] = { 0x8B, 0x54, 0x24, 0x04, 0x0F, 0xB7, 0xC2, 0x3D };
	Address3 = SearchMask( Base + 0x1000, SizeOfCode, ByteMask3, "########" ); // 8

	return ( Address != NULL );
}

bool Compare( BYTE* binData, BYTE* byteMask, char* charMask ){
    for( ; *charMask != NULL; ++charMask, ++binData, ++byteMask )
		if( *charMask == '#' && *binData != *byteMask ) 
            return false;
    return ( *charMask ) == NULL;
}

DWORD SearchMask( DWORD baseAddress, DWORD SearchLen, BYTE *ByteMask, char *CharMask ){
	for( DWORD i = 0; i < SearchLen; i++ ){
        if( Compare( ( BYTE* )( baseAddress + i ), ByteMask, CharMask ) )
            return ( DWORD )( baseAddress + i );
	}
    return 0;
}

