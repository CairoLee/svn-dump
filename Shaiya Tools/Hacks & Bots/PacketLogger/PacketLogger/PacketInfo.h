#include "pch.h"

void DisplayPacket( char *direction, WORD opcode, char *buffer, int len );
void CreateDump( char *direction, WORD opcode, char *buffer, int length );

struct RecvPacketStruct {
	char Data[ 8192 ];
	DWORD len;
	RecvPacketStruct *ptr;
};

struct PacketStruct {
	char *Data;
	DWORD len;
};
