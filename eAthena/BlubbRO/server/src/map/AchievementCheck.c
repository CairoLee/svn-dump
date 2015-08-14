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

#include "AchievementBase.h"
#include "AchievementCheck.h"
#include "AchievementReceive.h"
#include "pc.h"

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>


// TACHIEVE_KILL_MOB
#pragma region AchievementCheck_KillMob
bool AchievementCheck_KillMob(struct map_session_data *Player, struct AchievementObject *Achieve, va_list Args) {
	int j, MobID;
	struct mob_db *db;
	bool canUpdate = false, isComplete = true;
	struct AchievementRequireMobObject r;
	
	MobID = va_arg(Args, int);
	if ((db = mob_db(MobID)) == NULL) {
		return 0;
	}

	for (j = 0; j < MAX_ACHIEVE_PARAMS; j++) {
		// no Count, end of Data
		r = Achieve->RequireMob[j];
		if (r.Count == 0) {
			break;
		}
		
		// check for valid killed Mob		
		if (r.ID > 0) {
			if (r.ID != MobID) {
				isComplete = false;
				continue;
			}
			canUpdate = true;
		}
		if (r.Mode > 0) { // we need to kill a special mode
			if (!(db->status.mode & r.Mode) ) {
				isComplete = false;
				continue;
			}
			// Special check for MvPs, check MvP EXP
			if ((r.Mode & MD_BOSS) && db->mexp == 0) {
				isComplete = false;
				continue;
			}
			canUpdate = true;
		}
		if (r.Race > 0) { // need a special race
			if (db->status.race != r.Race) {
				isComplete = false;
				continue;
			}
			canUpdate = true;
		}

		if (canUpdate == true) {
			// increment counter & set as updateable
			achieve_Update(Player, Achieve, j, 1);
		}
	}

	
	// Finished all these requirements?
	if (isComplete == false) {
		return 0;
	}

	// Notify caller that the required mobs are complete
	return achieve_isComplete(Player, Achieve);
}
#pragma endregion

// generic Function
// Param[ 0 ] = Count to check
#pragma region AchievementCheck_GenericCount
bool AchievementCheck_GenericCount( struct map_session_data *Player, struct AchievementObject *Achieve, va_list Args ) {
	int j;
	// increment counter & set as updateable
	achieve_Update(Player, Achieve, 0, 1);
	for (j = 0; j < MAX_ACHIEVE_PARAMS; j++) {
		if (Achieve->RequireMob[j].Count == 0) {
			break;
		}
	}

	// handle Receivement
	achieve_GetReceive( Player, Achieve );
	return 1;
}
#pragma endregion

// generic Function
// Param[ 0 ] = Count to check
// first Param (integer) will be added to .counter
#pragma region AchievementCheck_GenericCountAdd
bool AchievementCheck_GenericCountAdd( struct map_session_data *Player, struct AchievementObject *Achieve, va_list Args ) {
	int j, Add = 0;

	Add = va_arg( Args, int );
	
	// increment counter & set as updateable
	achieve_Update(Player, Achieve, 0, Add);
	for (j = 0; j < MAX_ACHIEVE_PARAMS; j++) {
		if (Achieve->RequireMob[j].Count == 0) {
			break;
		}

	}

	// handle Receivement
	achieve_GetReceive( Player, Achieve );
	return 1;
}
#pragma endregion


// generic Function, .counter will tread as a Timer, checks also Status & val1-4
// Count = Count Seconds to reach
// Param[ 0 ] = Status to have
// Param[ 1 ] = StatusData val1
// Param[ 2 ] = StatusData val2
// Param[ 3 ] = StatusData val3
// Param[ 4 ] = StatusData val4
#pragma region AchievementCheck_GenericStatusTimer
bool AchievementCheck_GenericStatusTimer( struct map_session_data *Player, struct AchievementObject *Achieve, va_list Args ) {
	int state = -1;
	int val1 = -1, val2 = -1, val3 = -1, val4 = -1;
	/*
	if( r.Param[ 0 ][0] != 0 )
		state = atoi(r.Param[ 0 ]);
	if( r.Param[ 1 ][0] != 0 )
		val1 = atoi(r.Param[ 1 ]);
	if( r.Param[ 2 ][0] != 0 )
		val2 = atoi(r.Param[ 2 ]);
	if( r.Param[ 3 ][0] != 0 )
		val3 = atoi(r.Param[ 3 ]);
	if( r.Param[ 4 ][0] != 0 )
		val4 = atoi(r.Param[ 4 ]);

	// do we need a Status?
	if( state > SC_NONE && state < SC_MAX ){
		if( 
			( Player->sc.count == 0 || Player->sc.data[ state ] == NULL ) ||
			( val1 != -1 && Player->sc.data[ state ]->val1 != val1 ) ||
			( val2 != -1 && Player->sc.data[ state ]->val2 != val2 ) ||
			( val3 != -1 && Player->sc.data[ state ]->val3 != val3 ) ||
			( val4 != -1 && Player->sc.data[ state ]->val4 != val4 )
		) {
			Player->status.achieveData[ Achieve->ArrIndex ].counter = 0; // reset Timer, missing required Status
			return 0;
		}
	}

	// all requirements fit, check Timer

	// ever saved the start Time?
	if( Player->status.achieveData[ Achieve->ArrIndex ].counter == 0 ){
		Player->status.achieveData[ Achieve->ArrIndex ].counter = gettick();
		Player->status.achieveData[ Achieve->ArrIndex ].update = true;
	}

	// reached the count of seconds?
	if( DIFF_TICK( gettick(), Player->status.achieveData[ Achieve->ArrIndex ].counter ) < r.Count )
		return 0;
	*/
	return 0;

	// handle Receivement
	achieve_GetReceive( Player, Achieve );
	return 1;
}
#pragma endregion
