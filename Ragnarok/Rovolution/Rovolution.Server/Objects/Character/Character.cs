using System.Collections.Generic;
using System.Data;
using Rovolution.Server.Geometry;
using Rovolution.Server.Helper;

namespace Rovolution.Server.Objects {

	public class Character : WorldObjectUnit {
		public struct CharacterState {
			// Marks Active Player (Not Active Is Logging In/Out, Or Changing Map Servers)
			public bool Active;
			// If A Script Is Waiting For Feedback From The Player
			public bool MenuOrInput;
			public byte DeadSit;
			public bool LrFlag;
			public bool ConnectNew;
			public bool ArrowAtk;
			public bool Gangsterparadise;
			public bool Rest;
			// 0: Closed, 1: Normal Storage Open, 2: Guild Storage Open
			public byte Storage_flag;
			// Explosion Spirits On Death: 0 Off, 1 Used.
			public bool SnoviceDeadFlag;
			public bool AbraFlag;
			// Autospell Flag
			public bool Autocast;
			public bool Autotrade;
			// Marks Whether Registry Variables Have Been Saved Or Not Yet
			public byte RegDirty;
			public bool Showdelay;
			public bool Showexp;
			public bool Showzeny;
			public bool Mainchat;
			public bool Noask;
			//  Is 1 Only After A Trade Has Started.
			public bool Trading;
			// 1: Clicked On Ok. 2: Clicked On Trade
			public byte DealLocked;
			// For Monsters To Ignore A Character 
			public bool MonsterIgnore;
			// For Tiny/Large Types
			public ESize Size;
			// Holds Whether Or Not The Player Currently Has The Si_night Effect On. 
			public bool Night;
			public bool Blockedmove;
			public bool UsingFakeNpc;
			// Signals That A Player Should Warp As Soon As He Is Done Loading A Map.
			public bool Rewarp;
			public bool Killer;
			public bool Killable;
			public bool Doridori;
			public bool Ignoreall;
			public bool Buyingstore;
			public bool Lesseffect;
			public bool Vending;
			public byte Noks;
			public bool Changemap;
			// Previous Map On Map Change
			public short Pmap;
			public ushort Autoloot;
			public ushort AutolootID;
			// Flag To Indicate If An Autobonus Is Activated
			public ushort Autobonus;
			public Guild GMasterFlag;
		}

		public struct SpecialCharacterState {
			public byte NoWeaponDamage;
			public byte NoMagicDamage;
			public byte NoMiscDamage;
			public bool RestartFullRecover;
			public bool NoCastCancel;
			public bool NoCastCancel2;
			public bool NoSizefix;
			public bool NoGemstone;
			// Maya Purple Card effect 
			public bool intravision;
			public bool PerfectHiding;
			public bool NoKnockBack;
			public bool BonusComa;
		}

		public struct ItemDelayEntry {
			public DatabaseID NameID;
			public long Tick;
		}

		public struct SkillBonusEntry {
			public ushort ID;
			public short Value;
		}

		public struct StatusVariationData : IClearable {
			public short Value;
			public int Rate;
			public long Tick;

			public void Clear() {
				Value = 0;
				Rate = 0;
				Tick = 0;
			}
		}

		public struct DefenceBonusEntry {
			public short Class;
			public short Rate;
		}

		public struct ItemHealRateData {
			public int NameID;
			public int Rate;
		}

		public struct SubElementData {
			public short Flag;
			public short Rate;
			public EElement Element;
		}

		public struct CharacterDealData {
			public struct DealDataItem {
				public short Index;
				public short Amount;
			}

			public DealDataItem[] Item;
		}

		public struct AutoSpellData {
			public short ID;
			public short Level;
			public short Rate;
			public short CardID;
			public short Flag;
			// bAutoSpellOnSkill: blocks autospell from triggering again, while being executed
			public bool Block;
		}

		public struct AddEffectData {
			public EStatusChange ID;
			public short Rate;
			public short ArrowRate;
			public byte Flag;
		}

		public struct AddEffectOnSkillData {
			public EStatusChange ID;
			public short Rate;
			public short Skill;
			public byte Target;
		}

		public struct AddDropData {
			public short ID;
			public short Group;
			public int Race;
			public int Rate;
		}

		public struct AutoBonusData {
			public short Rate;
			public short AtkType;
			public uint Duration;
			//char *bonus_script, *other_script;
			public int Active;
			public ushort Pos;
		}

		public struct AuctionData {
			public int Index;
			public int Amount;
		}

		public struct VendingData {
			public short Index;
			public short Amount;
			public uint Value;
		}

		public struct MailData {
			public DatabaseID NameID;
			public int Index;
			public int Amount;
			public int Zeny;
			public MailHelper.MailData Inbox;
			public bool Changed;
		}


		public CharacterState State;
		public SpecialCharacterState SpecialState;


		public int LoginID1 {
			get;
			set;
		}
		public int LoginID2 {
			get;
			set;
		}

		/// <summary>
		/// This is the internal job ID used by the map server to simplify comparisons/queries/etc
		/// </summary>
		public EClass Class {
			get;
			set;
		}

		public int GMLevel {
			get;
			set;
		}
		// 5: old, 6: 7july04, 7: 13july04, 8: 26july04, 9: 9aug04/16aug04/17aug04, 10: 6sept04, 11: 21sept04, 12: 18oct04, 13: 25oct04 ... 18
		public int PacketVer {
			get;
			set;
		}

		public CharacterRegistry Registry {
			get;
			set;
		}

		public ItemInventory Inventory = new ItemInventory();

		public short[] EquipIndex = new short[(int)EItemEquipIndex.Max];

		public uint Weight {
			get;
			set;
		}

		public uint MaxWeight {
			get;
			set;
		}

		public int CartWeight {
			get;
			set;
		}

		public int CartNum {
			get;
			set;
		}

		public EHeadDirection HeadDir {
			get;
			set;
		}
		public long ClientTick {
			get;
			set;
		}
		public WorldID NpcID {
			get;
			set;
		}
		public WorldID AreaNpcID {
			get;
			set;
		}
		public WorldID NpcShopID {
			get;
			set;
		}
		public WorldID TouchingID {
			get;
			set;
		}

		//Marks the npc_id with which you can use items during interactions with said npc (see script command enable_itemuse)
		public int NpcItemFlag {
			get;
			set;
		}
		public int NpcMenu {
			get;
			set;
		}
		public int NpcAmount {
			get;
			set;
		}
		public string NpcString {
			get;
			set;
		}
		//For player attached npc timers. [Skotlex]
		public Timer NpcTimer {
			get;
			set;
		}
		public WorldID ChatID {
			get;
			set;
		}
		public long Idletime {
			get;
			set;
		}

		public WorldID ProgressbarNpcID {
			get;
			set;
		}
		public uint ProgressbarTimeout {
			get;
			set;
		}
		public List<string> IgnoreList {
			get;
			set;
		}
		public Timer FollowTimer {
			get;
			set;
		}
		public WorldID FollowTarget {
			get;
			set;
		}


		// to limit flood with emotion packets
		public long LastEmotionTime {
			get;
			set;
		}

		public short SkillItem {
			get;
			set;
		}
		public short SkillItemLv {
			get;
			set;
		}
		public short SkillIDOld {
			get;
			set;
		}
		public short SkillLvOld {
			get;
			set;
		}
		public short SkillIDDance {
			get;
			set;
		}
		public short SkillLvDance {
			get;
			set;
		}

		// range: [0,1999]
		public short CookMaster {
			get;
			set;
		}
		public byte[] BlockSkill {
			get;
			set;
		}
		public int CloneSkillID {
			get;
			set;
		}
		public int MenuSkillID {
			get;
			set;
		}
		public int MenuSkillValue {
			get;
			set;
		}

		public Timer InvisibleTimer {
			get;
			set;
		}

		public long CanLogTick {
			get;
			set;
		}
		public long CanUseItemTick {
			get;
			set;
		}
		public long CanUseCashFoodTick {
			get;
			set;
		}
		public long CanEquipTick {
			get;
			set;
		}
		public long CanTalkTick {
			get;
			set;
		}
		public long CanSendMailTick {
			get;
			set;
		}
		public long KsFloodprotectTick {
			get;
			set;
		}

		public List<ItemDelayEntry> ItemDelay {
			get;
			set;
		}

		public short Weapontype1 {
			get;
			set;
		}
		public short Weapontype2 {
			get;
			set;
		}
		public short Disguise {
			get;
			set;
		}
		public WeaponData WeaponRight {
			get;
			set;
		}
		public WeaponData WeaponLeft {
			get;
			set;
		}

		// here start arrays to be globally zeroed at the beginning of status_calc_pc()
		/// <summary>
		/// 
		/// </summary>
		public int[] ParamBonus = new int[6];
		/// <summary>
		/// 
		/// </summary>
		public int[] ParamEquip = new int[6];
		/// <summary>
		/// 
		/// </summary>
		public int[] Subele = new int[(int)EElement.Max];
		/// <summary>
		/// 
		/// </summary>
		public int[] Subrace = new int[(int)ERace.Max];
		/// <summary>
		/// 
		/// </summary>
		public int[] Subrace2 = new int[(int)ERace.Max];
		/// <summary>
		/// 
		/// </summary>
		public int[] Subsize = new int[(int)ESize.Max];
		/// <summary>
		/// 
		/// </summary>
		public int[] Reseff = new int[(int)((int)EStatusChange.CommonMax - (int)EStatusChange.CommonMax + 1)];
		/// <summary>
		/// 
		/// </summary>
		public int[] WeaponComaEle = new int[(int)EElement.Max];
		/// <summary>
		/// 
		/// </summary>
		public int[] WeaponComaRace = new int[(int)ERace.Max];
		/// <summary>
		/// 
		/// </summary>
		public int[] WeaponAtk = new int[16];
		/// <summary>
		/// 
		/// </summary>
		public int[] WeaponAtkRate = new int[16];
		/// <summary>
		/// 
		/// </summary>
		public int[] ArrowAddEle = new int[(int)EElement.Max];
		/// <summary>
		/// 
		/// </summary>
		public int[] ArrowAddRace = new int[(int)ERace.Max];
		/// <summary>
		/// 
		/// </summary>
		public int[] ArrowAddSize = new int[(int)ESize.Max];
		/// <summary>
		/// 
		/// </summary>
		public int[] MagicAddEle = new int[(int)EElement.Max];
		/// <summary>
		/// 
		/// </summary>
		public int[] MagicAddRace = new int[(int)ERace.Max];
		/// <summary>
		/// 
		/// </summary>
		public int[] MagicAddSize = new int[(int)ESize.Max];
		/// <summary>
		/// 
		/// </summary>
		public int[] CritAddRace = new int[(int)ERace.Max];
		/// <summary>
		/// 
		/// </summary>
		public int[] ExpAddRace = new int[(int)ERace.Max];
		/// <summary>
		/// 
		/// </summary>
		public int[] IgnoreDef = new int[(int)ERace.Max];
		/// <summary>
		/// 
		/// </summary>
		public int[] IgnoreMdef = new int[(int)ERace.Max];
		/// <summary>
		/// 
		/// </summary>
		public List<int> ItemGroupHealRate = new List<int>();
		/// <summary>
		/// 
		/// </summary>
		public short[] SpGainRace = new short[(int)ERace.Max];

		// zeroed arrays end here
		// zeroed structures start here

		public AutoSpellData[] AutoSpell = new AutoSpellData[15];
		public AutoSpellData[] AutoSpell2 = new AutoSpellData[15];
		public AutoSpellData[] AutoSpell3 = new AutoSpellData[15];
		public List<AddEffectData> AddEff = new List<AddEffectData>();
		public List<AddEffectData> AddEff2 = new List<AddEffectData>();
		public List<AddEffectOnSkillData> AddEff3 = new List<AddEffectOnSkillData>();
		/// <summary>
		/// Raises bonus dmg% of skills
		/// </summary>
		public List<SkillBonusEntry> SkillAtk = new List<SkillBonusEntry>();
		/// <summary>
		/// Increases heal%
		/// </summary>
		public List<SkillBonusEntry> SkillHeal = new List<SkillBonusEntry>();
		/// <summary>
		/// Increases heal%
		/// </summary>
		public List<SkillBonusEntry> SkillHeal2 = new List<SkillBonusEntry>();
		/// <summary>
		/// Increases bonus blewcount for some skills
		/// </summary>
		public List<SkillBonusEntry> SkillBlown = new List<SkillBonusEntry>();
		/// <summary>
		/// 
		/// </summary>
		public List<SkillBonusEntry> SkillCast = new List<SkillBonusEntry>();
		public StatusVariationData HPLoss;
		public StatusVariationData SPLoss;
		public StatusVariationData HPRegen;
		public StatusVariationData SPRegen;
		public List<DefenceBonusEntry> AddDef = new List<DefenceBonusEntry>();
		public List<DefenceBonusEntry> AddMDef = new List<DefenceBonusEntry>();
		public List<DefenceBonusEntry> AddMDamage = new List<DefenceBonusEntry>();
		public List<AddDropData> AddDrop = new List<AddDropData>();
		public List<ItemHealRateData> ItemHealRate = new List<ItemHealRateData>();
		public List<SubElementData> SubEle2 = new List<SubElementData>();

		// zeroed structures end here
		// manually zeroed structures start here.
		/// <summary>
		///  Auto script on attack..
		/// </summary>
		public List<AutoBonusData> AutoBonus = new List<AutoBonusData>();
		/// <summary>
		/// Auto script when attacked, on skill usage
		/// </summary>
		public List<AutoBonusData> AutoBonus2 = new List<AutoBonusData>();
		/// <summary>
		/// Auto script on skill usage
		/// </summary>
		public List<AutoBonusData> AutoBonus3 = new List<AutoBonusData>();
		// manually zeroed structures end here.
		// zeroed vars start here.
		public int AtkRate {
			get;
			set;
		}
		public int ArrowAtk {
			get;
			set;
		}
		public int ArrowEle {
			get;
			set;
		}
		public int ArrowCri {
			get;
			set;
		}
		public int ArrowHit {
			get;
			set;
		}
		public int Nsshealhp {
			get;
			set;
		}
		public int Nsshealsp {
			get;
			set;
		}
		public int CriticalDef {
			get;
			set;
		}
		public int DoubleRate {
			get;
			set;
		}
		public int LongAttackAtkRate {
			get;
			set;
		}
		public int NearAttackDefRate {
			get;
			set;
		}
		public int LongAttackDefRate {
			get;
			set;
		}
		public int MagicDefRate {
			get;
			set;
		}
		public int MiscDefRate {
			get;
			set;
		}
		public int IgnoreMdefEle {
			get;
			set;
		}
		public int IgnoreMdefRace {
			get;
			set;
		}
		public int PerfectHit {
			get;
			set;
		}
		public int PerfectHitAdd {
			get;
			set;
		}
		public int GetZenyRate {
			get;
			set;
		}
		public int GetZenyNum {
			get;
			set;
		}
		public int DoubleAddRate {
			get;
			set;
		}
		public int ShortWeaponDamageReturn {
			get;
			set;
		}
		public int LongWeaponDamageReturn {
			get;
			set;
		}
		public int MagicDamageReturn {
			get;
			set;
		}
		public int RandomAttackIncreaseAdd {
			get;
			set;
		}
		public int RandomAttackIncreasePer {
			get;
			set;
		}
		public int BreakWeaponRate {
			get;
			set;
		}
		public int BreakArmorRate {
			get;
			set;
		}
		public int CritAtkRate {
			get;
			set;
		}
		public int Classchange {
			get;
			set;
		}
		public int SpeedRate {
			get;
			set;
		}
		public int SpeedAddRate {
			get;
			set;
		}
		public int AspdAdd {
			get;
			set;
		}
		public int Itemhealrate2 {
			get;
			set;
		}

		public uint SetitemHash {
			get;
			set;
		}
		public uint SetitemHash2 {
			get;
			set;
		}

		public short SplashRange {
			get;
			set;
		}
		public short SplashAddRange {
			get;
			set;
		}
		public short AddStealRate {
			get;
			set;
		}
		public short AddHealRate {
			get;
			set;
		}
		public short AddHeal2Rate {
			get;
			set;
		}
		public short SpGainValue {
			get;
			set;
		}
		public short HpGainValue {
			get;
			set;
		}
		public short MagicSpGainValue {
			get;
			set;
		}
		public short MagicHpGainValue {
			get;
			set;
		}
		public short SpVanishRate {
			get;
			set;
		}
		public short SpVanishPer {
			get;
			set;
		}

		// chance to prevent ANY equipment breaking [celest]
		public ushort Unbreakable {
			get;
			set;
		}
		public ushort UnbreakableEquip {
			get;
			set;
		}
		public ushort UnstripableEquip {
			get;
			set;
		}

		// zeroed vars end here.

		public int CastRate {
			get;
			set;
		}
		public int DelayRate {
			get;
			set;
		}
		public int HPRate {
			get;
			set;
		}
		public int SPRate {
			get;
			set;
		}
		public int DSPRate {
			get;
			set;
		}

		public int HPRecoverRate {
			get;
			set;
		}
		public int SPRecoverRate {
			get;
			set;
		}
		public int MatkRate {
			get;
			set;
		}
		public int CriticalRate {
			get;
			set;
		}
		public int HitRate {
			get;
			set;
		}
		public int FleeRate {
			get;
			set;
		}
		public int Flee2Rate {
			get;
			set;
		}
		public int DefRate {
			get;
			set;
		}
		public int Def2Rate {
			get;
			set;
		}
		public int MdefRate {
			get;
			set;
		}
		public int Mdef2Rate {
			get;
			set;
		}

		public int ItemID {
			get;
			set;
		}
		public int ItemIndex {
			get;
			set;
		}

		public short CatchTargetClass {
			get;
			set;
		}

		public short Spiritball {
			get;
			set;
		}
		public short SpiritBallOld {
			get;
			set;
		}

		public List<Timer> SpiritTimer {
			get;
			set;
		}

		public byte PotionSuccessCounter {
			get;
			set;
		}
		public byte MissionCount {
			get;
			set;
		}
		public short MissionMobID {
			get;
			set;
		}

		public int DieCounter {
			get;
			set;
		}

		public WorldID[] Devotion {
			get;
			set;
		}

		public WorldID TradePartner {
			get;
			set;
		}


		public CharacterDealData Deal;

		public bool PartyCreating {
			get;
			set;
		}
		public bool PartyJooining {
			get;
			set;
		}

		public WorldID PartyInvite {
			get;
			set;
		}

		public WorldID AdoptInvite {
			get;
			set;
		}

		public WorldID GuildInvite {
			get;
			set;
		}

		public int GuildEmblemID {
			get;
			set;
		}
		public WorldID GuildAlliance {
			get;
			set;
		}

		public Point2D GuildPosition {
			get;
			set;
		}
		public Point2D GuildSpy {
			get;
			set;
		}

		public WorldID VendedID {
			get;
			set;
		}
		public WorldID VenderID {
			get;
			set;
		}
		public int VendNum {
			get;
			set;
		}
		public string Mesage {
			get;
			set;
		}

		public List<VendingData> Vending {
			get;
			set;
		}

		// uid of open buying store
		public WorldID BuyerID {
			get;
			set;
		}
		public BuyingStoreHelper.BuyingStoreData BuyingStore;

		public SearchStoreHelper.SearchStoreInfo SearchStore;

		public Pet Pet {
			get;
			set;
		}
		public Homunculus Homu {
			get;
			set;
		}
		public Mercenary Mercenary {
			get;
			set;
		}

		// 0 - Sun, 1 - Moon, 2 - Stars
		public List<WorldID> FeelMap {
			get;
			set;
		}
		public short[] HateMob {
			get;
			set;
		}

		public Timer PvpTimer {
			get;
			set;
		}
		public short PvpPoint {
			get;
			set;
		}
		public ushort PvpRank {
			get;
			set;
		}
		public ushort PvpLastUsers {
			get;
			set;
		}
		public ushort PvpWon {
			get;
			set;
		}
		public ushort PvpLost {
			get;
			set;
		}

		//char eventqueue[MAX_EVENTQUEUE][EVENT_NAME_LENGTH];
		public List<Timer> EventTimer {
			get;
			set;
		}
		public byte ChangeLevel {
			get;
			set;
		}
		public string FakeName {
			get;
			set;
		}

		public int DuelGrpup {
			get;
			set;
		}
		public WorldID DuelInvite {
			get;
			set;
		}

		public WorldID KillerID {
			get;
			set;
		}
		public WorldID KilledID {
			get;
			set;
		}

		public int CashPoints {
			get;
			set;
		}
		public int KafraPoints {
			get;
			set;
		}

		public Timer RentalTimer {
			get;
			set;
		}

		public AuctionData Auction;
		public MailData Mail;
		//Quest log system 
		public int QuestNum {
			get;
			set;
		}
		public int QuestAvailable {
			get;
			set;
		}
		public int[] QuestIndex {
			get;
			set;
		}
		public QuestHelper.QuestData[] QuestLog;
		public bool QuestSave {
			get;
			set;
		}

		public WorldID BgID {
			get;
			set;
		}
		public ushort UserFont {
			get;
			set;
		}


		public CharacterDatabaseData Status {
			get;
			protected set;
		}

		// TODO: I know eA use them, but do we need them too?
		public WorldObjectStatus BaseStatus {
			get;
			set;
		}

		public WorldObjectStatus BattleStatus {
			get;
			set;
		}

		public WorldObjectViewData ViewData {
			get;
			set;
		}

		public WorldObjectStatusChangeList StatusChange {
			get;
			set;
		}

		public WorldObjectRegenerationData Regen {
			get;
			set;
		}

		public CharacterRegenerationData SRegen {
			get;
			set;
		}

		public CharacterRegenerationData SSRegen {
			get;
			set;
		}



		public Account Parent {
			get;
			internal set;
		}

		public Account Account {
			get { return Parent; }
			internal set { Parent = value; }
		}

		public uint AccountID {
			get { return Account.ID; }
		}



		public Character(DatabaseID dbID, bool addToWorld)
			: base(dbID, addToWorld) {
			BaseStatus = new WorldObjectStatus(this);
			BattleStatus = new WorldObjectStatus(this);
			ViewData = new WorldObjectViewData();
			StatusChange = new WorldObjectStatusChangeList();

			// TODO: i dont where eAthena initialize them realy..
			//		 they using struct, which cant be null x.x
			Regen = new WorldObjectRegenerationData(this);
			HPRegen = new StatusVariationData();
			SPRegen = new StatusVariationData();
			SRegen = new CharacterRegenerationData();
			SSRegen = new CharacterRegenerationData();
		}

		public Character(DatabaseID dbID)
			: this(dbID, false) {
		}


		public static void Initialize() {
			// Load HP modifer and job_db
		}


		public static Character Load(Account account, DataRow row) {
			Character c = new Character(DatabaseID.Zero, false);
			// Load basic character data
			c.Status = new CharacterDatabaseData(row);

			// Update WorldID (same as Serial/DatabaseID)
			c.WorldID = new WorldID(c.Status.Serial.ID, c.Status.Serial.Type);
			// Update location
			c.Location = c.Status.Location;
			// Update account
			c.Parent = account;

			return c;
		}

		public static ECharacterCreationResult Create(Account account, string name, byte slot, byte str, byte agi, byte vit, byte int_, byte dex, byte luk, short hairColor, short hairStyle, out Character newChar) {
			newChar = null;

			if (name.Length > 24) {
				name = name.Substring(0, 24);
			}
			//name = name.Replace('\032', ' ').Replace('\t', ' ').Replace('\x0A', ' ').Replace('\x0D', ' ');

			if (
				(slot >= Global.MAX_SLOTS) ||
				(str + agi + vit + int_ + dex + luk != 6 * 5) ||
				(str < 1 || str > 9 || agi < 1 || agi > 9 || vit < 1 || vit > 9 || int_ < 1 || int_ > 9 || dex < 1 || dex > 9 || luk < 1 || luk > 9) ||
				(str + int_ != 10 || agi + luk != 10 || vit + dex != 10)
			) {
				return ECharacterCreationResult.CharCreationDenied; // invalid input
			}

			// Check for max character count on this account
			if (account.Chars.Count >= Global.MAX_SLOTS) {
				return ECharacterCreationResult.CharCreationDenied; // character account limit exceeded
			}
			// Check for existing char with this name
			if (Core.Database.Query("SELECT charID FROM `char` WHERE `name` = '{0}'", name.MysqlEscape()).Rows.Count > 0) {
				return ECharacterCreationResult.CharnameAlreadyExists;
			}
			// Check for existing char on this slot
			foreach (Character tmpChar in account.Chars.Values) {
				if (tmpChar.Status.Slot == slot) {
					return ECharacterCreationResult.CharCreationDenied;
				}
			}

			// TODO: this has to be in CharacterDatabaseStatus, nor?
			//		 CharacterDatabaseData represents the character in the character server
			//		 so..
			newChar = new Character(DatabaseID.Zero, false);
			newChar.Parent = account;
			newChar.Status.Name = name;
			newChar.Status.Slot = slot;
			newChar.Status.Zeny = Config.StartZeny;
			newChar.Status.Str = str;
			newChar.Status.Agi = agi;
			newChar.Status.Dex = dex;
			newChar.Status.Vit = vit;
			newChar.Status.Int = int_;
			newChar.Status.Luk = luk;
			newChar.Status.HPMax = newChar.Status.HP = (40 * (100 + vit) / 100);
			newChar.Status.SPMax = newChar.Status.SP = (11 * (100 + int_) / 100);
			newChar.Status.HairStyle = hairStyle;
			newChar.Status.HairColor = hairColor;
			newChar.Status.SavePoint = new Location(Mapcache.GetID(Config.StartMap), Config.StartMapX, Config.StartMapY);
			newChar.Status.Location = new Location(newChar.Status.SavePoint.Map.ID, newChar.Status.SavePoint.Point.X, newChar.Status.SavePoint.Point.Y);

			// Save it
			CharacterDatabaseData status = newChar.Status;
			string query =
				string.Format(
					"INSERT INTO `char` (" +
						"`accountID`, `slot`, `name`, `zeny`, `str`, `agi`, `vit`, `int`, `dex`, `luk`, `hpMax`, `hp`," +
						"`spMax`, `sp`, `hair`, `hairColor`, `lastMap`, `lastX`, `lastY`, `saveMap`, `saveX`, `saveY`" +
					") VALUES (" +
						"{0}, {1}, '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}'," +
						"'{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}'" +
					")"
					,
					account.WorldID.ID, slot, name.MysqlEscape(), status.Zeny, status.Str, status.Agi, status.Vit,
					status.Int, status.Dex, status.Luk, status.HPMax, status.HP, status.SPMax, status.SP,
					status.HairStyle, status.HairColor, status.Location.Map, status.Location.Point.X, status.Location.Point.Y,
					status.SavePoint.Map, status.SavePoint.Point.X, status.SavePoint.Point.X
				);
			Core.Database.Query(query);
			uint charID = (uint)Core.Database.GetLastInsertID();
			if (charID == 0) {
				// Failed to add character?
				return ECharacterCreationResult.CharCreationDenied;
			}
			// save Serial/CharID
			newChar.UpdateDatabaseID(charID, EDatabaseType.Char);
			newChar.WorldID = new WorldID(charID, EDatabaseType.Char);
			// Add it to account dictionary
			account.Chars.Add(newChar.WorldID, newChar);

			return ECharacterCreationResult.Success;
		}

		public static bool CheckID(int classID) {
			if (
				(classID < (int)EClass.MaxBase) ||
				(classID >= (int)EClass.NoviceHigh && classID < (int)EClass.Max)
			) {
				return true;
			}

			return false;
		}


		public void LoadFull() {
			// Should be called after character select
			Status.LoadInventory();
			Status.LoadCart();
			Status.LoadStorage();
			Status.LoadSkills();
			Status.LoadPet();
			Status.LoadMercenary();
			Status.LoadOther();
		}


		public void SetOnline() {
			Core.Database.QuerySimple("UPDATE char SET isOnline = 1 WHERE charIID = {0}", WorldID.ID);
		}

		public void SetOffline() {
			Core.Database.QuerySimple("UPDATE char SET isOnline = 0 WHERE charID = {0}", WorldID.ID);
		}


		// Some helper.. taken from pc.h #defines
		public bool IsDead() {
			return State.DeadSit == 1;
		}

		public bool IsSit() {
			return ViewData.DeadSit == 2;
		}

		public bool IsIdle() {
			return (
				ChatID != null ||
				State.Vending == true ||
				State.Buyingstore == true
				// TODO: or idletime
			);
		}

		public bool IsTrading() {
			return (NpcID != null || State.Vending || State.Buyingstore || State.Trading);
		}

		public bool CantAct() {
			return (
				!(NpcID is WorldID) &&
				!State.Vending &&
				!State.Buyingstore &&
				!(ChatID is WorldID) &&
				StatusChange.Option1 == EStatusOption1.None &&
				!State.Trading &&
				State.Storage_flag == 0
			);
		}

		public bool IsHiding() {
			EStatusOption hiddenOptions = (EStatusOption.Hide | EStatusOption.Cloak | EStatusOption.Chasewalk);
			return (StatusChange.Option & hiddenOptions) > 0;
		}

		public bool IsCloaking() {
			return (StatusChange.Option & EStatusOption.Cloak) > 0;
		}

		public bool IsChasewalk() {
			return (StatusChange.Option & EStatusOption.Chasewalk) > 0;
		}

		public bool IsCartOn() {
			return (StatusChange.Option & EStatusOption.Cart) > 0;
		}

		public bool IsFalcon() {
			return (StatusChange.Option & EStatusOption.Falcon) > 0;
		}

		public bool IsRiding() {
			return (StatusChange.Option & EStatusOption.Riding) > 0;
		}

		public bool IsVisible() {
			return (StatusChange.Option & EStatusOption.Invisible) > 0;
		}

		public bool IsOverweight50() {
			return (Weight >= MaxWeight);
		}

		public bool IsOverweight90() {
			return (Weight * 10 >= MaxWeight * 9);
		}


		public void SetDead() {
			State.DeadSit = ViewData.DeadSit = 1;
		}

		public void SetSit() {
			State.DeadSit = ViewData.DeadSit = 2;
		}

		public void SetStand() {
			//status_change_end(&sd->bl, SC_TENSIONRELAX, INVALID_TIMER);

			// Reset sitting tick
			SSRegen.TickHP = SSRegen.TickSP = 0;
			State.DeadSit = ViewData.DeadSit = 0;
		}

		public void SetDir(EDirection bodyDir, EHeadDirection headDir) {
			Location.Direction = bodyDir;
			HeadDir = headDir;
		}

		public void SetChat() {
		}


		public void ResetInvisibleTimer() {
			if (Timer.IsValid(InvisibleTimer) == true) {
				InvisibleTimer = null;
				//skill_unit_move(&sd->bl, gettick(), 1);
			}
		}


		private ushort CheckSkill(ESkill sid) {
			if ((int)sid >= (int)ESkill.GdSkillbase) {
				//if( sd->status.guild_id>0 && (g=guild_search(sd->status.guild_id))!=NULL)
				//	return guild_checkskill(g,skill_id);
				return 0;
			}

			if (Status.Skills[sid].ID > 0) {
				return Status.Skills[sid].Level;
			}

			return 0;
		}

		private int CalculateSkillpoints() {
			int i, skill, skill_point = 0;
			ESkillInf2 inf2;

			// TODO: Why starting on index 1?
			for (i = 1; i < Status.Skills.Length; i++) {
				ESkill sid = (ESkill)i;
				if ((skill = CheckSkill(sid)) > 0) {
					inf2 = (World.Database.Skill[sid] as SkillDatabaseData).Inf2;
					// TODO: configs
					if (((inf2 & ESkillInf2.Quest) != ESkillInf2.Quest/* || battle_config.quest_skill_learn*/) &&
						!((inf2 & (ESkillInf2.Wedding | ESkillInf2.Spirit)) > 0) //Do not count wedding/link skills
					) {
						if (Status.Skills[sid].Flag == ESkillFlag.Permanent) {
							skill_point += skill;
						} else if ((int)Status.Skills[sid].Flag >= (int)ESkillFlag.ReplacedLv0) {
							skill_point += ((int)Status.Skills[sid].Flag - (int)ESkillFlag.ReplacedLv0);
						}
					}
				}
			}

			return skill_point;
		}

		/// <summary>
		/// From pc_calc_skilltree_normalize_job(), normalize the class based on the skills.
		/// Checks for basic skill and asumes its a novice or s novice.
		/// TODO: this is the only check, how about checks for falcon and shit for Hunter, i.e.?
		/// </summary>
		/// <returns></returns>
		private EClass SkillTreeNormalizeJob() {
			int skill_point;
			EClass c = Class;

			//if (!battle_config.skillup_limit)
			//	return c;

			skill_point = CalculateSkillpoints();
			// Consider Novice Tree when you don't have NV_BASIC maxed.
			if (CheckSkill(ESkill.NvBasic) < 9) {
				c = EClass.Novice;
			} else {
				//Do not send S. Novices to first class (Novice)
				if ((Class & EClass.JOBl_2) > 0 &&
					(Class & EClass.UPPERMASK) != EClass.Super_Novice &&
					Status.SkillPoints >= Status.LevelJob &&
					((ChangeLevel > 0 && skill_point < (ChangeLevel + 8)) || skill_point < 58)
				) {
					//Send it to first class.
					c &= EClass.BASEMASK;
				}
			}

			if ((Class & EClass.JOBl_UPPER) > 0) {
				//Convert to Upper
				c |= EClass.JOBl_UPPER;
			} else if ((Class & EClass.JOBl_BABY) > 0) {
				//Convert to Baby
				c |= EClass.JOBl_BABY;
			}

			return c;
		}

		public void CalculateSkillTree() {
			EClientClass c;

			EClass normalClass = SkillTreeNormalizeJob();
			c = normalClass.Convert();
			// Clear skills first (set ID = 0)
			Status.Skills.Clear();

			Status.Skills.CalculateTree(this, normalClass, c);
		}


		public override bool Save() {
			// Update main data
			bool result = Status.UpdateDatabase("char", "charID", ID);
			// Update other things ?

			return result;
		}


		public int ToStream(Network.PacketWriter Writer) {
			int pos = (int)Writer.BaseStream.Position;
			Writer.Write((uint)WorldID.ID);
			Writer.Write((int)Status.ExpBase);
			Writer.Write((int)Status.Zeny);
			Writer.Write((int)Status.ExpJob); // jobExp
			Writer.Write((int)Status.LevelJob); // jobLevel

			Writer.Write((int)0); // probably opt1
			Writer.Write((int)0); // probably opt2
			Writer.Write((int)Status.Option); // option
			Writer.Write((int)Status.Karma); // karma
			Writer.Write((int)Status.Manner); // manner
			Writer.Write((short)Status.StatusPoints); // statuspoints

			// if PACKETVER > 20081217
			Writer.Write((int)Status.HP);
			Writer.Write((int)Status.HPMax);
			// else
			// hp & maxHP => short!
			// endif
			Writer.Write((short)Status.SP); // sp
			Writer.Write((short)Status.SPMax); // maxSP
			Writer.Write((short)Global.DEFAULT_WALK_SPEED); // DEFAULT_WALK_SPEED
			Writer.Write((short)Status.Class); // class
			Writer.Write((short)Status.HairStyle); // hairStyle
			short opt = (short)((Status.Option & EStatusOption.Riding) > 0 ? Status.Weapon : 0);
			Writer.Write((short)opt); // When the weapon is sent and your option is riding, the client crashes on login!?
			Writer.Write((short)Status.LevelBase); // baseLevel
			Writer.Write((short)Status.SkillPoints); // skillpoints
			Writer.Write((short)Status.HeadBottom); // headBottom
			Writer.Write((short)Status.Shield); // shield
			Writer.Write((short)Status.HeadTop); // headTop
			Writer.Write((short)Status.HeadMid); // headMid
			Writer.Write((short)Status.HairColor); // hairColor
			Writer.Write((short)Status.ClothColor); // clothColor
			Writer.Write(Status.Name, 24); // name
			Writer.Write((byte)Status.Str); // str
			Writer.Write((byte)Status.Agi); // agi
			Writer.Write((byte)Status.Vit); // vit
			Writer.Write((byte)Status.Int); // int
			Writer.Write((byte)Status.Dex); // dex
			Writer.Write((byte)Status.Luk); // luk
			Writer.Write((short)Status.Slot); // slot

			// if PACKETVER >= 20061023
			Writer.Write((short)Status.Rename); // rename
			// endif
			// if (PACKETVER >= 20100720 && PACKETVER <= 20100727) || PACKETVER >= 20100803
			//mapindex_getmapname_ext(mapindex_id2name(p->last_point.map), (char*)WBUFP(buf, 108));
			//offset += MAP_NAME_LENGTH_EXT;
			// endif

			// if PACKETVER >= 20100803
			//WBUFL(buf, 124) = TOL(p->delete_date);
			//offset += 4;
			// endif

			int length = ((int)Writer.BaseStream.Position - pos);
			return length;
		}

	}


}
