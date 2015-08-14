#ifndef _ACHIEVEMENTBASE_H_
#define _ACHIEVEMENTBASE_H_

enum AchieveType {
	TACHIEVE_START = 0,

	// kill 20 Mobs
	TACHIEVE_KILL_MOB,
	// kill 20 Player
	TACHIEVE_KILL_PLAYER,
	// kill 10 Homunculus
	TACHIEVE_KILL_HOMUN,
	// kill 2 Mercenaries
	TACHIEVE_KILL_MERC,

	// get Baselevel 50
	TACHIEVE_LEVEL_BASE,
	// get Joblevel 10
	TACHIEVE_LEVEL_JOB,

	// explore Prontera Region
	TACHIEVE_EXPLORE_REGION,
	// explore Lighthalzen Biolab
	TACHIEVE_EXPLORE_DUNGEON,
	
	// first 2-2 Job reached
	TACHIEVE_JOBCHANGE,
	
	// 3h Overweight Status
	TACHIEVE_STATUS_ACTIVE,
	
	// died 10 times
	TACHIEVE_DIE,
	// get 10 Ressurections
	TACHIEVE_RESURECT,
	
	// use 10 Novice Potion
	TACHIEVE_ITEM_USE,
	// get 5 Yggdrassil Berry
	TACHIEVE_ITEM_GET,

	// finish 100 Quests
	TACHIEVE_QUEST_FINISH,

	// use 50 times Kafra NPC
	TACHIEVE_USE_NPC_KAFRA,

	// use 100 times fire bolt
	TACHIEVE_USESKILL_ID,

	// place for specail script-given achieves
	TACHIEVE_EVENT_SPECIAL,

	// kill player in opponents castle
	TACHIEVE_KILL_PLAYER_CASTLE_OP,

	// kill player in your castle
	TACHIEVE_KILL_PLAYER_CASTLE_MY,

	// gib 10.000 zeny für items im NPC aus
	TACHIEVE_PAY_ZENY,

	// get 10.000 from vending sold
	TACHIEVE_GET_ZENY_VENDING,

	TACHIEVE_MAX,
};

enum AchieveReceiveType {
	TACHIEVE_RECEIVE_NONE = 0,

	TACHIEVE_RECEIVE_BASEEXP,
	TACHIEVE_RECEIVE_JOBEXP,
	TACHIEVE_RECEIVE_ZENY,
	TACHIEVE_RECEIVE_ITEM,

	TACHIEVE_RECEIVE_MAX,
};



struct AchievementObject;
struct AchievementDataObject;
struct map_session_data;

// dynamic Functions
// <try to be as global as possible>
typedef bool ( *AchieveCheckFunc )( struct map_session_data *Player, struct AchievementObject *Achieve, va_list Args );
typedef int ( *AchieveReceiveFunc )( struct map_session_data *Player, struct AchievementObject *Achieve, struct AchievementDataObject *ReceiveObject, va_list Args );
#define ACHIEVECHECK_FUNC( x ) int AchievementCheck_ ## x ( struct map_session_data *Player, struct AchievementObject *Achieve, va_list Args )
#define ACHIEVERECIEVE_FUNC( x ) int AchievementReceive_ ## x ( struct map_session_data *Player, struct AchievementObject *Achieve, struct AchievementDataObject *ReceiveObject, va_list Args )



struct AchievementDataObject {
	int ID, Count;

	enum AchieveReceiveType Type;
	AchieveReceiveFunc ReceiveFunc;

	char Param[MAX_ACHIEVE_PARAMS][55];
};

struct AchievementRequireMobObject {
	int ID;
	int Count;
	int Level;
	int Mode;
	int Race;
	int Element;
};

struct AchievementObject {
	int ID; // Sql Key/ID
	char Name[255]; // Display name
	char NameCutin[255];
	char Description[255];
	enum AchieveType Type; // Achieve Type from <AchieveType> Enumeration

	struct AchievementRequireMobObject RequireMob[MAX_ACHIEVE_PARAMS]; // Required Mobs
	AchieveCheckFunc CheckFunc; // called to check if Achievement Criteria got reached

	struct AchievementDataObject ReceiveObject[MAX_ACHIEVE_ROWS]; // Receive Data

	int ArrIndex; // Index in internal array
	bool Active;
};




/*****************************************
 ********* Functions
 *****************************************/

struct AchievementObject *AchieveDB( int Type, int AchieveID );
struct AchievementObject *AchieveSearch( int Type );

void achieve_CheckType( struct map_session_data *Player, int AchieveType, ... );
void achieve_GetReceive( struct map_session_data *Player, struct AchievementObject *Achieve, ... );
void achieve_Update( struct map_session_data *Player, struct AchievementObject *Achieve, int RequireIndex, int Count );
bool achieve_isComplete(struct map_session_data *Player, struct AchievementObject *Achieve);

void achive_SetReceiveFunc( struct AchievementObject *ach, struct AchievementDataObject *dataObj );
void achive_SetCheckFunc( struct AchievementObject *ach );
bool achive_ParseDBRow( struct AchievementObject *ach );
void achive_ReadDB();
void achieve_reload();

void do_init_achievement();
void do_final_achievement();


#endif /* _ACHIEVEMENTBASE_H_ */
