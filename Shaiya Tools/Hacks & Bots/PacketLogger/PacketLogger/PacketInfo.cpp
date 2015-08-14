#include "pch.h"
#include "DebugLog.h"
#include "PacketInfo.h"



void DisplayPacket( char *direction, WORD opcode, char *buffer, int length ){
	static FILE *fp = NULL;
	int i, j;

	fp = fopen( "Packets.log", "a" );
	
	fprintf_s( fp, "         %s: 0x%04hX [%04u] ------------------------      ASCII ----------", direction, opcode, length );
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

	CreateDump( direction, opcode, buffer, length );
}



void CreateDump( char *direction, WORD opcode, char *buffer, int length ){
	FILE *fp = NULL;
	char filePath[ 256 ];
	int i;

	// Dump_OpCode_Length
	sprintf( filePath, "Packets/Dump_%c_0x%04hX.log", direction[ 0 ], opcode, length );
	fp = fopen( filePath, "a" );
	for( i = 2; i < length; i++ )
		fprintf_s( fp, "%c", buffer[ i ] );
	fclose( fp );
}
