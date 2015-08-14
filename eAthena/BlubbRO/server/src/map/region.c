
#include "../common/showmsg.h"
#include "../common/strlib.h"
#include "../common/malloc.h"

#include "region.h"
#include "map.h"
#include "clif.h"
#include "guild.h"
#include "mapreg.h"
#include "script.h"
#include "pc.h"

#include <stdio.h>
#include <string.h>
#include <stdlib.h>


struct dungeon *dungeon_dummy = NULL;
struct region *region_dummy = NULL;

struct dungeon *dungeon_db( int index ) { 
	if( index <= 0 || index >= MAX_DUNGEON )
		return dungeon_dummy; 
	else if( dungeon_data[ index ] == NULL ) {
		ShowError( "dungeon_db: Index %d does not exist\n", index );
		return dungeon_dummy; 
	}
	return dungeon_data[ index ]; 
}

struct region *region_db( int index ) { 
	if( index <= 0 || index >= MAX_REGION )
		return region_dummy; 
	else if( region_data[ index ] == NULL ) {
		ShowError( "region_db: Index %d does not exist\n", index );
		return region_dummy; 
	}
	return region_data[ index ]; 
}


#pragma region region_release() to free up the Guild, not yet? used
void region_release( int guild_id ) {
	char output[128];
	struct region *r = NULL;
	int i;

	for( i = 1; i < MAX_REGION; i++ ) {
		if( ( r = region_db( i ) ) == NULL )
			continue;
		if( r->guild_id == 0 || r->guild_id != guild_id )
			continue;

		sprintf( output, "[Region '%s' is untaken]", r->name );
		clif_broadcast( NULL, output, strlen( output ) + 1, 0x00CCFF, ALL_CLIENT );

		mapreg_setreg( add_str( "$Region" )+( i<<24 ), 0 );
		mapreg_setreg( add_str( "$Region_Guildzeny" )+( i<<24 ), 0 );

	}
}
#pragma endregion






void dungeon_read( void ) {
	int c = 0;
	struct dungeon db;
	SqlStmt *stmt, *stmtr;

	memset( dungeon_data, 0, sizeof( dungeon_data ) );
	memset( &db, 0, sizeof( db ) );

	stmt = SqlStmt_Malloc( mmysql_handle );
	stmtr = SqlStmt_Malloc( mmysql_handle );
	if( stmt == NULL || stmtr == NULL ){
		if( stmt == NULL )
			SqlStmt_ShowDebug( stmt );
		if( stmtr == NULL )
			SqlStmt_ShowDebug( stmtr );
		return;
	}
	
	if( 
		SQL_ERROR == SqlStmt_Prepare( stmt, "SELECT `DungeonID`, `Name`, `Mapname` FROM `area_dungeon_db` ORDER BY DungeonID" ) 
		||	SQL_ERROR == SqlStmt_Execute( stmt )
		||	SQL_ERROR == SqlStmt_BindColumn( stmt, 0, SQLDT_INT, &db.index,   0, NULL, NULL )
		||  SQL_ERROR == SqlStmt_BindColumn( stmt, 1, SQLDT_STRING, &db.name, sizeof( db.name ), NULL, NULL )
		||  SQL_ERROR == SqlStmt_BindColumn( stmt, 2, SQLDT_STRING, &db.map, sizeof( db.map ), NULL, NULL )
	){
		SqlStmt_ShowDebug( stmt );
		SqlStmt_Free( stmt );
		return;
	}
	
	while( SqlStmt_NextRow( stmt ) == SQL_SUCCESS ){	
		if( db.index < 1 )
			continue;
		if( db.index >= MAX_DUNGEON ) {
			ShowError( "read_dungeondb : Wrong index value %d.\n", db.index );
			continue;
		}

		if( dungeon_data[ db.index ] == NULL ) {
			dungeon_data[ db.index ] = ( struct dungeon* )aCalloc( 1, sizeof ( struct dungeon ) );
		}
	
		db.state = true;
		c++;
		memcpy( dungeon_data[ db.index ], &db, sizeof( struct dungeon ) );
	}

	SqlStmt_Free( stmt );
	SqlStmt_Free( stmtr );

	ShowStatus( "'"CL_WHITE"%d"CL_RESET"' Dungeons loaded\n", c );
	return;
}




void region_read( void ) {
	int c = 0;
	struct region db;
	SqlStmt *stmt, *stmtr;

	memset( region_data, 0, sizeof( region_data ) );
	memset( &db, 0, sizeof( db ) );

	// init dummy
	dungeon_dummy = ( struct dungeon* )aCalloc( 1, sizeof ( struct dungeon ) );
	region_dummy = ( struct region* )aCalloc( 1, sizeof ( struct region ) );

	stmt = SqlStmt_Malloc( mmysql_handle );
	stmtr = SqlStmt_Malloc( mmysql_handle );
	if( stmt == NULL || stmtr == NULL ){
		if( stmt == NULL )
			SqlStmt_ShowDebug( stmt );
		if( stmtr == NULL )
			SqlStmt_ShowDebug( stmtr );
		return;
	}
	
	if( 
		SQL_ERROR == SqlStmt_Prepare( stmt, "SELECT `RegionID`, `Name`, `Mapname` FROM `area_region_db` ORDER BY RegionID" ) 
		||	SQL_ERROR == SqlStmt_Execute( stmt )
		||	SQL_ERROR == SqlStmt_BindColumn( stmt, 0, SQLDT_INT, &db.index,   0, NULL, NULL )
		||  SQL_ERROR == SqlStmt_BindColumn( stmt, 1, SQLDT_STRING, &db.name, sizeof( db.name ), NULL, NULL )
		||  SQL_ERROR == SqlStmt_BindColumn( stmt, 2, SQLDT_STRING, &db.map_name, sizeof( db.map_name ), NULL, NULL )
	){
		SqlStmt_ShowDebug( stmt );
		SqlStmt_Free( stmt );
		return;
	}
	
	while( SqlStmt_NextRow( stmt ) == SQL_SUCCESS ){	
		if( db.index < 1 )
			continue;
		if( db.index >= MAX_REGION ) {
			ShowError( "read_regiondb : Wrong index value %d.\n", db.index );
			continue;
		}

		if( region_data[ db.index ] == NULL )
			region_data[ db.index ] = ( struct region* )aCalloc( 1, sizeof ( struct region ) );
	
		db.state = true;
		c++;
		memcpy( region_data[ db.index ], &db, sizeof( struct region ) );
	}

	SqlStmt_Free( stmt );
	SqlStmt_Free( stmtr );

	ShowStatus( "'"CL_WHITE"%d"CL_RESET"' Regions loaded\n", c );
	return;
}
