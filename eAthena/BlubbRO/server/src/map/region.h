#ifndef _REGION_H_
#define _REGION_H_

#include "../common/mmo.h"

struct region {
	char name[ ITEM_NAME_LENGTH ], map_name[ MAP_NAME_LENGTH ];
	int users, map_count, index, guild_id;
	bool state;
};

struct dungeon {
	char name[ ITEM_NAME_LENGTH ], map[ MAP_NAME_LENGTH ];
	int map_count, users, x, y, index;
	bool state;
};


struct dungeon *dungeon_data[ MAX_DUNGEON ];
struct region *region_data[ MAX_REGION ];
struct dungeon *dungeon_db( int index );
struct region *region_db( int index );

void region_release( int guild_id );


void region_read( void );
void dungeon_read( void );

#endif /* _REGION_H_ */
