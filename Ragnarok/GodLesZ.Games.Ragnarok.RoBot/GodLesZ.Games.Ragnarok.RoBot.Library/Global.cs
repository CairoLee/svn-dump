using Rovolution.Server.Geometry;

namespace GodLesZ.Games.Ragnarok.RoBot.Library {

	public static class Global {
		public static int PACKETVER = 20100714;

		/// <summary>
		/// Max length of a name.
		/// For character names, title names, guilds, maps, etc.
		/// </summary>
		public static int NAME_LENGTH = (23 + 1);
		/// <summary>
		/// Max length of item names, which tend to have much longer names.
		/// </summary>
		public static int ITEM_NAME_LENGTH = 50;
		/// <summary>
		/// Max length of a map name, which the client considers to be 16 in length including the .gat extension
		/// <para>Note: This is without extensions!</para>
		/// </summary>
		public static int MAP_NAME_LENGTH = (11 + 1);
		/// <summary>
		/// Max length of a map name, which the client considers to be 16 in length including the .gat extension
		/// <para>Note: This is with extensions!</para>
		/// </summary>
		public static int MAP_NAME_LENGTH_EXT = (MAP_NAME_LENGTH + 4);

		/// <summary>
		/// Max size for inputs to Graffiti, Talkie Box and Vending text prompts
		/// </summary>
		public static int MESSAGE_SIZE = 80;
		/// <summary>
		/// String length you can write in the 'talking box'
		/// </summary>
		public static int CHATBOX_SIZE = 71;
		/// <summary>
		/// Chatroom-related string sizes
		/// </summary>
		public static int CHATROOM_TITLE_SIZE = 37;
		/// <summary>
		/// Chatroom password string size
		/// </summary>
		public static int CHATROOM_PASS_SIZE = 9;
		/// <summary>
		/// Max allowed chat text length
		/// </summary>
		public static int CHAT_SIZE_MAX = 256;

		/// <summary>
		/// Default world saving interval in ms (5min)
		/// </summary>
		public static int DEFAULT_AUTOSAVE_INTERVAL = 300000;


		/// <summary>
		/// Max number of hotkeys
		/// </summary>
		public static int MAX_HOTKEYS = 38;

		/// <summary>
		/// Max number of items inthe inventory
		/// </summary>
		public static int MAX_INVENTORY = 100;
		/// <summary>
		/// Max items in a cart
		/// </summary>
		public static int MAX_CART = 100;
		/// <summary>
		/// Max items in a account storage
		/// </summary>
		public static int MAX_STORAGE = 600;
		/// <summary>
		/// Max items in a guild storage
		/// </summary>
		public static int MAX_GUILD_STORAGE = 600;

		/// <summary>
		/// Max number of characters per account. 
		/// <para>
		/// Note: that changing this setting alone is not enough 
		/// if the client is not hexed to support more characters as well.
		/// </para>
		/// </summary>
		public static int MAX_CHARS = 9;
		/// <summary>
		/// Number of slots carded equipment can have. 
		/// Never set to less than 4 as they are also used to keep the data of forged items/equipment.
		/// <para>
		/// Note: The client seems unable to receive data for more than 4 slots due to all related packets having a fixed size.
		/// </para>
		/// </summary>
		public static int MAX_SLOTS = 4;

		/// <summary>
		/// Max amount of a item stack
		/// </summary>
		public static int MAX_AMOUNT = 30000;
		/// <summary>
		/// Max zeny on a character
		/// </summary>
		public static int MAX_ZENY = 1000000000;
		/// <summary>
		/// Max fame points per character
		/// </summary>
		public static int MAX_FAME = 1000000000;
		/// <summary>
		/// Max number of skills (per char?)
		/// </summary>
		public static int MAX_SKILL = 2536;

		/// <summary>
		/// Default walkspeed
		/// </summary>
		public static int DEFAULT_WALK_SPEED = 150;
		/// <summary>
		/// Min walkspeed
		/// </summary>
		public static int MIN_WALK_SPEED = 0;
		/// <summary>
		/// Max walkspeed
		/// </summary>
		public static int MAX_WALK_SPEED = 1000;

		/// <summary>
		/// Max player in a party
		/// </summary>
		public static int MAX_PARTY = 12;
		/// <summary>
		/// Max player in a guild (increased max guild members +6 per 1 extension levels)
		/// </summary>
		public static int MAX_GUILD = 16 + 10 * 6;
		/// <summary>
		/// Max amount of guild positions
		/// </summary>
		public static int MAX_GUILDPOSITION = 20;
		/// <summary>
		/// 
		/// </summary>
		public static int MAX_GUILDEXPULSION = 32;
		/// <summary>
		/// 
		/// </summary>
		public static int MAX_GUILDALLIANCE = 16;
		/// <summary>
		/// Max number of skills of a guild
		/// </summary>
		public static int MAX_GUILDSKILL = 15; // increased max guild skills because of new skills [Sara-chan];
		/// <summary>
		/// Max guild castles in the server (needed? Oo)
		/// </summary>
		public static int MAX_GUILDCASTLE = 34;
		/// <summary>
		/// Max guild level
		/// </summary>
		public static int MAX_GUILDLEVEL = 50;
		/// <summary>
		/// Max amount of guardians per castle
		/// </summary>
		public static int MAX_GUARDIANS = 8;
		/// <summary>
		/// Max number of quests per server (needed?)
		/// </summary>
		public static int MAX_QUEST_DB = 2000;
		/// <summary>
		/// Max quest objectives per quest
		/// </summary>
		public static int MAX_QUEST_OBJECTIVES = 3;


		public static int MIN_ATTRIBUTE = 0;
		public static int MAX_ATTRIBUTE = 4;
		public static int ATTRIBUTE_NORMAL = 0;
		public static int MIN_STAR = 0;
		public static int MAX_STAR = 3;

		public static int MAX_STATUS_TYPE = 5;

		public static int WEDDING_RING_M = 2634;
		public static int WEDDING_RING_F = 2635;

		/// <summary>
		/// Max amount of friends per player
		/// </summary>
		public static int MAX_FRIENDS = 40;
		/// <summary>
		/// Max amount of memo points per player
		/// </summary>
		public static int MAX_MEMOPOINTS = 3;

		/// <summary>
		/// Max player in a fame list
		/// </summary>
		public static int MAX_FAME_LIST = 10;

		// Limits to avoid ID collision with other game objects
		public static int START_ACCOUNT_NUM = 2000000;
		public static int END_ACCOUNT_NUM = 100000000;
		public static int START_CHAR_NUM = 150000;

		// Guilds
		public static int MAX_GUILDMES1 = 60;
		public static int MAX_GUILDMES2 = 120;

		// Base Homun skill
		public static int HM_SKILLBASE = 8001;
		public static int MAX_HOMUNSKILL = 16;
		public static int MAX_HOMUNCULUS_CLASS = 16;
		public static int HM_CLASS_BASE = 6001;
		public static int HM_CLASS_MAX = (HM_CLASS_BASE + MAX_HOMUNCULUS_CLASS - 1);

		// Mail System
		public static int MAIL_MAX_INBOX = 30;
		public static int MAIL_TITLE_LENGTH = 40;
		public static int MAIL_BODY_LENGTH = 200;

		// Mercenary System
		public static int MC_SKILLBASE = 8201;
		public static int MAX_MERCSKILL = 40;
		public static int MAX_MERCENARY_CLASS = 40;


		public static int MAX_NPC_PER_MAP = 512;
		public static int BLOCK_SIZE = 8;
		public static int AREA_SIZE = 14;
		public static Point2D AREA_SIZE_POINT = new Point2D(AREA_SIZE, AREA_SIZE);
		public static int DAMAGELOG_SIZE = 30;
		public static int LOOTITEM_SIZE = 10;
		public static int MAX_MOBSKILL = 50;
		public static int MAX_MOB_LIST_PER_MAP = 128;
		public static int MAX_EVENTQUEUE = 2;
		public static int MAX_EVENTTIMER = 32;
		public static int NATURAL_HEAL_INTERVAL = 500;
		public static int MIN_FLOORITEM = 2;
		public static int MAX_FLOORITEM = START_ACCOUNT_NUM;
		public static int MAX_LEVEL = 99;
		public static int MAX_DROP_PER_MAP = 48;
		public static int MAX_IGNORE_LIST = 20;
		public static int MAX_VENDING = 12;
		public static int MAX_MAP_SIZE = 262144;
		public static int MOBID_EMPERIUM = 1288;
		// Definitions for WoESE objects
		public static int MOBID_BARRICADE1 = 1905;
		public static int MOBID_BARRICADE2 = 1906;
		public static int MOBID_GUARIDAN_STONE1 = 1907;
		public static int MOBID_GUARIDAN_STONE2 = 1908;

		public static int MAX_REFINE_BONUS = 5;
		public static int MAX_REFINE = 10;

		/// <summary>
		/// Read some configs and caches them
		/// </summary>
		public static void Initialize() {

		}

	}

}
