#include "pch.h"
#include "DebugLog.h"
#include "PacketInfo.h"
#include "HookHelper.h"



void RecvPacket( char *buf, DWORD len ){
	RecvPacketStruct *Packet = new RecvPacketStruct;
	memcpy( Packet->Data, buf, len );
	Packet->len = len;
	Packet->ptr = (RecvPacketStruct *)( (DWORD)Packet + 2 );

	WORD Opcode;
	memcpy( &Opcode, Packet, sizeof( WORD ) );

	void (* ReceivePacketPtr)( WORD Opcode, RecvPacketStruct *Packet ) = ( void (__cdecl *)( WORD, RecvPacketStruct *) )Address3;
	(* ReceivePacketPtr)( Opcode, Packet );

	delete Packet;
}

void SendPacket( char *buf, int len ){	
	void ( * InternalCall )( char *, int ) = ( void ( __cdecl * )( char *, int ) )Address;
	( * InternalCall )( buf, len );
}





void LogPacket( char *direction, WORD opcode, char *buffer, int length ){
	static FILE *fp = NULL;
	int i, j;

	fp = fopen( "Packets.log", "a" );

	fprintf_s( fp, "         %s: 0x%04hX [%04d] ------------------------      ASCII ----------", direction, opcode, length );
	for( i = 2; i < length; i += 16 ){
		fprintf_s( fp, "\n%p ", &buffer[ i ] );
		for( j = i; j < i + 16; j++ ){
			if( j < length )
				fprintf_s( fp, "%02hX ", (unsigned char)buffer[ j ] );
			else
				fprintf_s( fp, "   " );
		}

		fprintf_s( fp, "  |  " );

		for( j = i; j < i + 16; j++ ){
			if( j < length ){
				if( buffer[ j ] > 31 && buffer[ j ] < 127 )
					fprintf_s( fp, "%c", buffer[ j ] );
				else
					fprintf_s( fp, "." );
			} else
				fprintf_s( fp, " " );
		}
	}

	fprintf_s( fp, "\n" );
	fclose( fp );
}


void LogBuf( char *buffer, int length ){
	static FILE *fp = NULL;
	int i, j;

	fp = fopen( "Packets.log", "a" );

	fprintf_s( fp, "         BUFF>>: %04d ---------------------------------      ASCII ----------", length );
	for( i = 2; i < length; i += 16 ){
		fprintf_s( fp, "\n%p ", &buffer[ i ] );
		for( j = i; j < i + 16; j++ ){
			if( j < length )
				fprintf_s( fp, "%02hX ", (unsigned char)buffer[ j ] );
			else
				fprintf_s( fp, "   " );
		}

		fprintf_s( fp, "  |  " );

		for( j = i; j < i + 16; j++ ){
			if( j < length ){
				if( buffer[ j ] > 31 && buffer[ j ] < 127 )
					fprintf_s( fp, "%c", buffer[ j ] );
				else
					fprintf_s( fp, "." );
			} else
				fprintf_s( fp, " " );
		}
	}

	fprintf_s( fp, "\n" );
	fclose( fp );
}
