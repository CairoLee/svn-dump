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
#include "AchievementReceive.h"
#include "pc.h"

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>




// TACHIEVE_RECEIVE_BASEEXP
int AchievementReceive_BaseEXP( struct map_session_data *Player, struct AchievementObject *Achieve, struct AchievementDataObject *ReceiveObject, va_list Args ) {
	int j, exp = 0;

	if( ReceiveObject->Type != TACHIEVE_RECEIVE_BASEEXP )
		return 0;

	for( j = 0; j < MAX_ACHIEVE_PARAMS; j += 2 ) {
		if( ReceiveObject->Param[ j ] == 0 )
			break;

		// %?
		if( atoi(ReceiveObject->Param[ j + 1 ]) == 1 ){
			int percent = atoi(ReceiveObject->Param[ j ]);
			exp += ( pc_nextbaseexp( Player ) * percent ) / 100;
		} else
			exp += atoi(ReceiveObject->Param[ j ]);
	}

	return exp;
}

// TACHIEVE_RECEIVE_JOBEXP
int AchievementReceive_JobEXP( struct map_session_data *Player, struct AchievementObject *Achieve, struct AchievementDataObject *ReceiveObject, va_list Args ) {
	int j, exp = 0;

	if( ReceiveObject->Type != TACHIEVE_RECEIVE_JOBEXP )
		return 0;

	for( j = 0; j < MAX_ACHIEVE_PARAMS; j += 2 ) {
		if( ReceiveObject->Param[ j ] == 0 )
			break;

		// %?
		if( atoi(ReceiveObject->Param[ j + 1 ]) == 1 ){
			int percent = atoi(ReceiveObject->Param[ j ]);
			exp += ( pc_nextjobexp( Player ) * percent ) / 100;
		} else
			exp += atoi(ReceiveObject->Param[ j ]);
	}

	return exp;
}

// TACHIEVE_RECEIVE_ZENY
int AchievementReceive_Zeny( struct map_session_data *Player, struct AchievementObject *Achieve, struct AchievementDataObject *ReceiveObject, va_list Args ) {
	int j;
	int zeny = 0;

	if( ReceiveObject->Type != TACHIEVE_RECEIVE_ZENY )
		return 0;

	for( j = 0; j < MAX_ACHIEVE_PARAMS; j++ ) {
		if( ReceiveObject->Param[ j ][0] == 0 )
			break;

		zeny += atoi(ReceiveObject->Param[ j ]);
	}

	return zeny;
}

// TACHIEVE_RECEIVE_ITEM
int AchievementReceive_Item( struct map_session_data *Player, struct AchievementObject *Achieve, struct AchievementDataObject *ReceiveObject, va_list Args ) {
	int j, itemID, amount;

	if( ReceiveObject->Type != TACHIEVE_RECEIVE_ITEM )
		return 0;

	for( j = 0; j < MAX_ACHIEVE_PARAMS; j += 2 ) {
		if( ReceiveObject->Param[ j ][0] == 0 )
			break;

		itemID = atoi(ReceiveObject->Param[ j ]);
		amount = atoi(ReceiveObject->Param[ j + 1 ]);
		if(amount < 1) {
			amount = 1;
		} else if(amount >= MAX_AMOUNT) {
			amount = MAX_AMOUNT - 1;
		}

		if( itemdb_exists(itemID) == NULL) {
			ShowWarning("Achivement receivement %d -ItemID - not found: %d\n", j, itemID);
			continue;
		}

		{
			struct item tmp_item;
			memset(&tmp_item,0,sizeof(tmp_item));
			tmp_item.nameid = itemID;
			tmp_item.amount = amount;
			tmp_item.identify = 1;
			pc_additem(Player, &tmp_item, amount);
		}
	}

	return 1;
}





