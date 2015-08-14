#include "../common/cbasetypes.h"
#include "../common/mmo.h"
#include "../common/timer.h"
#include "../common/nullpo.h"
#include "../common/core.h"
#include "../common/showmsg.h"
#include "../common/malloc.h"
#include "../common/socket.h"
#include "../common/strlib.h"
#include "../common/utils.h"
#include "../common/strlib.h"

#include "map.h"
#include "pc.h"
#include "npc.h"
#include "AchievementBase.h"
#include "AchievementReceive.h"
#include "AchievementCheck.h"

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

struct AchievementObject *AchievementData[TACHIEVE_MAX][MAX_ACHIEVEMENTS];
struct AchievementObject *AchievementDummy = NULL;


/**
 * <summary>Searchs an Achievement by Type and ID</summary>
**/
struct AchievementObject *AchieveDB( int AchieveType, int AchieveID ) {
	int i;
	if (AchieveID < 0) {
		return AchievementDummy;
	}
	if (AchieveType < 0 || AchieveType >= TACHIEVE_MAX) {
		return AchievementDummy;
	}
	
	for (i = 0; i < MAX_ACHIEVEMENTS; i++){
		if (AchievementData[AchieveType][i] == NULL) { // end of data
			return AchievementDummy;
		}

		if (AchievementData[AchieveType][i]->ID == AchieveID) {
			return AchievementData[AchieveType][i];
		}
	}

	return AchievementDummy;
}






void achieve_CheckType(struct map_session_data *Player, int AchieveType, ...){
	int i, finished;
	va_list args;
	
	va_start(args, AchieveType);

	for (i = 0, finished = 0; i < MAX_ACHIEVEMENTS; i++) {
		// end of data
		if (AchievementData[AchieveType][i] == NULL) {
			break; // all are sorted one by one, reached end of data
		}
		// not active | has finished
		if (AchievementData[AchieveType][i]->Active == false || Player->status.achieveData[AchievementData[AchieveType][i]->ArrIndex].finished == true) {
			continue;
		}

		if (AchievementData[AchieveType][i]->CheckFunc(Player, AchievementData[AchieveType][i], args) == true) {
			// Handle receive	
			achieve_GetReceive(Player, AchievementData[AchieveType][i]);
		}
	}

	va_end(args);
}

bool achieve_isComplete(struct map_session_data *Player, struct AchievementObject *Achieve){
	int j;

	if (Achieve == NULL) {
		return false;
	}

	// Check required Mobs
	for (j = 0; j < MAX_ACHIEVE_PARAMS; j++) {
		if (Achieve->RequireMob[j].Count == 0) {
			break;
		}
		// Required count not reached, achievement not finished
		if (Player->status.achieveData[Achieve->ArrIndex].count[j] < Achieve->RequireMob[j].Count) {
			return false;
		}
	}

	// Check other types (items, player conditions, ect)


	return true;
}


void achieve_GetReceive( struct map_session_data *Player, struct AchievementObject *Achieve, ... ){
	int i, zeny = 0, bexp = 0, jexp = 0;

	// mark Achieve as finished
	Player->status.achieveData[ Achieve->ArrIndex ].finished = true;

	// call NPC to inform Player
	pc_setreg( Player, add_str( "@AchieveID" ), Achieve->ID );
	pc_setreg( Player, add_str( "@AchieveType" ), (int)Achieve->Type );
	npc_event( Player, "AchieveEvent::OnFinish", 0 );

	// search for Receivements
	for( i = 0; i < MAX_ACHIEVE_ROWS; i++ ){
		if( Achieve->ReceiveObject[ i ].ID == 0 )
			break;

		if( Achieve->ReceiveObject[ i ].Type != TACHIEVE_RECEIVE_NONE && Achieve->ReceiveObject[ i ].ReceiveFunc != NULL ) {
			int ret = 0;
			va_list args;

			va_start( args, Achieve );
			ret = Achieve->ReceiveObject[ i ].ReceiveFunc( Player, Achieve, &Achieve->ReceiveObject[ i ], args );
			if( Achieve->ReceiveObject[ i ].Type == TACHIEVE_RECEIVE_BASEEXP )
				bexp += ret;
			else if( Achieve->ReceiveObject[ i ].Type == TACHIEVE_RECEIVE_JOBEXP )
				jexp += ret;
			else if( Achieve->ReceiveObject[ i ].Type == TACHIEVE_RECEIVE_ZENY )
				zeny += ret;
			va_end( args );
		}
	}

	if( bexp || jexp ) {
		pc_gainexp( Player, NULL, bexp, jexp, 0 );
	}

	if( zeny ) {
		pc_getzeny( Player, zeny );
	}

}

void achieve_Update( struct map_session_data *Player, struct AchievementObject *Achieve, int RequireIndex, int Count ) {
	Player->status.achieveData[ Achieve->ArrIndex ].AchieveID = Achieve->ID;
	Player->status.achieveData[ Achieve->ArrIndex ].count[RequireIndex] += Count;
	Player->status.achieveData[ Achieve->ArrIndex ].update = true;
	
	if( Player->gmlevel >= 20 ) {
		// Development Debug, trigger NPC to inform about updated Achieve
		pc_setreg( Player, add_str( "@AchieveID" ), Achieve->ID );
		pc_setreg( Player, add_str( "@AchieveType" ), (int)Achieve->Type );
		pc_setreg( Player, add_str( "@AchieveCount" ), Count );
		pc_setreg( Player, add_str( "@AchieveNow" ), Player->status.achieveData[ Achieve->ArrIndex ].count[RequireIndex] );
		npc_event( Player, "AchieveEvent::OnUpdate", 0 );
	}
}









void achive_SetReceiveFunc( struct AchievementObject *ach, struct AchievementDataObject *obj ) {
	if( obj->Type == TACHIEVE_RECEIVE_NONE ) {
		obj->ReceiveFunc = NULL;
		return;
	}

	switch( obj->Type ) {
		case TACHIEVE_RECEIVE_BASEEXP:
			obj->ReceiveFunc = AchievementReceive_BaseEXP;
			break;
		case TACHIEVE_RECEIVE_JOBEXP:
			obj->ReceiveFunc = AchievementReceive_JobEXP;
			break;
		case TACHIEVE_RECEIVE_ZENY:
			obj->ReceiveFunc = AchievementReceive_Zeny;
			break;
		case TACHIEVE_RECEIVE_ITEM:
			obj->ReceiveFunc = AchievementReceive_Item;
			break;

		default:
			obj = NULL;
			break;
	}
}

void achive_SetCheckFunc( struct AchievementObject *ach ) {
	if( ach->Type == TACHIEVE_START ) {
		ach->CheckFunc = NULL;
		return;
	}

	switch( ach->Type ) {
		case TACHIEVE_KILL_MOB:
			ach->CheckFunc = AchievementCheck_KillMob;
			break;

		// only Generic Count Function with 1 Param needed
		case TACHIEVE_JOBCHANGE:
		case TACHIEVE_ITEM_USE:
		case TACHIEVE_ITEM_GET:
			
		case TACHIEVE_LEVEL_BASE:
		case TACHIEVE_LEVEL_JOB:

		// Skill things
		case TACHIEVE_USESKILL_ID:
		case TACHIEVE_EXPLORE_REGION:
		case TACHIEVE_EXPLORE_DUNGEON:
			//ach->CheckFunc = AchievementCheck_GenericCountParam1;
			break;

		// only Generic Count Function needed
		case TACHIEVE_KILL_PLAYER:
		case TACHIEVE_KILL_HOMUN:
		case TACHIEVE_KILL_MERC:
		case TACHIEVE_DIE:
		case TACHIEVE_RESURECT:
		case TACHIEVE_QUEST_FINISH:
		case TACHIEVE_USE_NPC_KAFRA:
		case TACHIEVE_EVENT_SPECIAL:
		case TACHIEVE_KILL_PLAYER_CASTLE_OP:
		case TACHIEVE_KILL_PLAYER_CASTLE_MY:
			ach->CheckFunc = AchievementCheck_GenericCount;
			break;

		case TACHIEVE_PAY_ZENY:
		case TACHIEVE_GET_ZENY_VENDING:
			ach->CheckFunc = AchievementCheck_GenericCountAdd;
			break;

		// Status timer things
		case TACHIEVE_STATUS_ACTIVE:
			ach->CheckFunc = AchievementCheck_GenericStatusTimer;
			break;

		default:
			break;
	}
}




int achieve_ReadParams( char *Params, struct AchievementDataObject *Obj ) {		
	char* fields[ MAX_ACHIEVE_PARAMS ];
	int colCount = sv_split( Params, strlen( Params ), 0, ',', fields, ARRAYLENGTH( fields ), 0 );
	int i;

	// error?
	if( colCount > MAX_ACHIEVE_PARAMS ) {
		colCount = MAX_ACHIEVE_PARAMS;
	}

	for (i = 1; i < colCount + 1; i++) {
		safestrncpy(Obj->Param[i - 1], trim(fields[i]), sizeof(Obj->Param[ i - 1 ]));
	}

	return colCount;
}


void achive_ReadDB( void ) {
	SqlStmt *stmt, *stmtr;
	uint32 count = 0;
	uint32 i, aCount[ TACHIEVE_MAX ];
	struct AchievementObject ach;

	for( i = 0; i < TACHIEVE_MAX; i++ ) {
		aCount[ i ] = 0;
	}
	
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
		SQL_ERROR == SqlStmt_Prepare( stmt, "SELECT `ID`, `AchieveType`, `Name`, `NameCutin`, `Active`, `Description` FROM `achieve_db` ORDER BY ID"	) 
		||	SQL_ERROR == SqlStmt_Execute( stmt )
		||	SQL_ERROR == SqlStmt_BindColumn( stmt, 0, SQLDT_INT, &ach.ID,   0, NULL, NULL )
		||  SQL_ERROR == SqlStmt_BindColumn( stmt, 1, SQLDT_INT, &ach.Type, 0, NULL, NULL )
		||  SQL_ERROR == SqlStmt_BindColumn( stmt, 2, SQLDT_STRING, &ach.Name, sizeof( ach.Name ), NULL, NULL )
		||  SQL_ERROR == SqlStmt_BindColumn( stmt, 3, SQLDT_STRING, &ach.NameCutin, sizeof( ach.NameCutin ), NULL, NULL )
		||  SQL_ERROR == SqlStmt_BindColumn( stmt, 4, SQLDT_INT, &ach.Active, 0, NULL, NULL )
		||  SQL_ERROR == SqlStmt_BindColumn( stmt, 5, SQLDT_STRING, &ach.Description, sizeof( ach.Description ), NULL, NULL )
	){
		SqlStmt_ShowDebug( stmt );
		SqlStmt_Free( stmt );
		return;
	}
	
	while( SqlStmt_NextRow( stmt ) == SQL_SUCCESS ){
		int mobID, mobCount, mobLevel, mobMode, mobRace, mobElement;
		char rParam[ 255 ];
		if( ach.Type <= TACHIEVE_START || ach.Type >= TACHIEVE_MAX ) {
			ShowWarning( "Achiement %d has an invalid Type: %d.\n", ach.ID, ach.Type );
			continue;
		}

		memset( rParam, 0, sizeof( rParam ) );

		if ( AchievementData[ ach.Type ][ aCount[ ach.Type ] ] == NULL )
			AchievementData[ ach.Type ][ aCount[ ach.Type ] ] = ( struct AchievementObject* )aCalloc( 1, sizeof ( struct AchievementObject ) );

		ach.ArrIndex = aCount[ ach.Type ];		
		achive_SetCheckFunc( &ach );
		

		/**********************
		 * Requirements: Mobs
		 **********************/

		if( 
			SQL_ERROR == SqlStmt_Prepare( stmtr, "SELECT `MobID`, `MobCount`, `MobLevel`, `MobMode`, `MobRace`, `MobElement` FROM `achieve_require_db_mob` WHERE AchieveID = %d", ach.ID ) 
			||	SQL_ERROR == SqlStmt_Execute( stmtr )
			||	SQL_ERROR == SqlStmt_BindColumn( stmtr, 0, SQLDT_INT, &mobID, 0, NULL, NULL )
			||	SQL_ERROR == SqlStmt_BindColumn( stmtr, 1, SQLDT_INT, &mobCount, 0, NULL, NULL )
			||	SQL_ERROR == SqlStmt_BindColumn( stmtr, 2, SQLDT_INT, &mobLevel, 0, NULL, NULL )
			||	SQL_ERROR == SqlStmt_BindColumn( stmtr, 3, SQLDT_INT, &mobMode, 0, NULL, NULL )
			||	SQL_ERROR == SqlStmt_BindColumn( stmtr, 4, SQLDT_INT, &mobRace, 0, NULL, NULL )
			||	SQL_ERROR == SqlStmt_BindColumn( stmtr, 5, SQLDT_INT, &mobElement, 0, NULL, NULL )
		){
			SqlStmt_ShowDebug( stmtr );
			SqlStmt_Free( stmtr );

			AchievementData[ ach.Type ][ aCount[ ach.Type ] ] = NULL;
			continue;
		} else {
			int row = 0;
			while( SqlStmt_NextRow( stmtr ) == SQL_SUCCESS && row < MAX_ACHIEVE_ROWS ){
				int count = 0;

				if (mobCount == 0) {
					AchievementData[ ach.Type ][ aCount[ ach.Type ] ] = NULL;
					continue;
				}
			
				ach.RequireMob[row].ID = mobID;
				ach.RequireMob[row].Count = mobCount;
				ach.RequireMob[row].Level = mobLevel;
				ach.RequireMob[row].Mode = mobMode;
				ach.RequireMob[row].Race = mobRace;
				ach.RequireMob[row].Element = mobElement;

				row++;
			}

			// Nothing found -> clear object
			if (row == 0) {
				memset( &ach.RequireMob, 0, sizeof( ach.RequireMob ) );
			}

		}

		
		/**********************
		 * Requirements: Items
		 **********************/
		

		/**********************
		 * Requirements: Maps
		 **********************/


		// Copy object to array
		memcpy( AchievementData[ ach.Type ][ aCount[ ach.Type ] ], &ach, sizeof( struct AchievementObject ) );

		ShowDebug( " - Achieve '%s', ID %d\n", ach.Name, ach.ID );
		aCount[ ach.Type ]++;
		count++;
	}
	
	SqlStmt_Free( stmt );
	SqlStmt_Free( stmtr );
	
	ShowStatus( "Done reading '"CL_WHITE"%lu"CL_RESET"' Achievements.\n", count );
	count = 0;
}




void achieve_reload( void ) {
	do_final_achievement();
	do_init_achievement();
	achive_ReadDB();
}


void do_init_achievement( void ){
	memset( AchievementData, 0, sizeof( AchievementData ) );

	achive_ReadDB();
}

void do_final_achievement( void ){
	int i, t;

	if ( AchievementDummy ){
		aFree( AchievementDummy );
		AchievementDummy = NULL;
	}

	for( t = 0; t < TACHIEVE_MAX; t++ ) {
		for( i = 0; i < MAX_ACHIEVEMENTS; i++ ) {
			if( AchievementData[ t ][ i ] != NULL ){
				aFree( AchievementData[ t ][ i ] );
				AchievementData[ t ][ i ] = NULL;
			}
		}
	}	

}
