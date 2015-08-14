#include "pch.h"

void RecvPacket( char *buf, DWORD len );
void SendPacket( char *buf, int len );
void LogPacket( char *direction, WORD opcode, char *buffer, int len );
void LogBuf( char *buffer, int length );

struct RecvPacketStruct {
	char Data[ 8192 ];
	DWORD len;
	RecvPacketStruct *ptr;
};

struct PacketStruct {
	char *Data;
	DWORD len;
};
