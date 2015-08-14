namespace GodLesZ.Games.Ragnarok.RoBot.Library {

	/// <summary>
	/// TODO: check all config comments and fix the "bool" on zeroed once
	///		  or implement some logic in comment parsing in the config converter
	/// </summary>
	public static class Config {


		/*******************************************************
		 * Character
		 ******************************************************/

		/*******************************************************
		 * battle.conf
		 * Battle
		 ******************************************************/
		/// <summary>
		///  Who should have a baseatk value (makes str affect damage)? (Note 3)
		/// </summary>
		public static int EnableBaseatk = 9;
		/// <summary>
		///  Who can have perfect flee? (Note 3)
		/// </summary>
		public static bool EnablePerfectFlee = true;
		/// <summary>
		///  Who can have critical attacks? (Note 3)
		/// <para> (Note that there are some skills that always do critical hit regardless of this)</para>
		/// </summary>
		public static bool EnableCritical = true;
		/// <summary>
		///  Critical adjustment rate for non-players (Note 2)
		/// </summary>
		public static int MobCriticalRate = 100;
		public static int CriticalRate = 100;
		/// <summary>
		///  Should normal attacks give you a walk delay? (Note 3)
		/// <para> If no, characters can move as soon as they start an attack (attack animation</para>
		/// <para> or walk animation may be omitted client-side, causing cropped attacks or</para>
		/// <para> monsters that teleport to you)</para>
		/// <para> Otherwise, the delay is equal to the 'attack animation' (amotion)</para>
		/// </summary>
		public static int AttackWalkDelay = 15;
		/// <summary>
		///  Move-delay adjustment after being hit. (Note 2)
		/// <para> The 'can't walk' delay after being hit is calculated as a percentage of the damage animation duration.</para>
		/// <para> NOTE: Only affects the normal delay from a single attack, not the delay added by the multihit_delay option below.</para>
		/// </summary>
		public static int PcDamageWalkDelayRate = 20;
		public static int DamageWalkDelayRate = 100;
		/// <summary>
		///  Move-delay adjustment for multi-hitting attacks.
		/// <para> When hit by a multi-hitting skill like Lord of Vermillion or Jupitel Thunder, characters will be</para>
		/// <para> unable to move for an additional "(number of hits -1) * multihit_delay" milliseconds.</para>
		/// <para> 80 is the setting that feels like Aegis (vs Sonic Blows)</para>
		/// <para> 230 is the setting that makes walkdelay last until the last hit (vs Jupitel thunder)</para>
		/// </summary>
		public static int MultihitDelay = 80;
		/// <summary>
		///  Damaged delay rate for players (Note 2)
		/// <para> (Setting to no/0  will be like always endure)</para>
		/// </summary>
		public static int PlayerDamageDelayRate = 100;
		/// <summary>
		///  Should race or element be used to consider someone undead?
		/// <para> 0 = element undead</para>
		/// <para> 1 = race undead</para>
		/// <para> 2 = both (either one works)</para>
		/// </summary>
		public static bool UndeadDetectType = false;
		/// <summary>
		///  Does HP recover if hit by an attribute that's same as your own? (Note 1)
		/// </summary>
		public static bool AttributeRecover = false;
		/// <summary>
		///  What is the minimum and maximum hitrate of normal attacks?
		/// </summary>
		public static int MinHitrate = 5;
		public static int MaxHitrate = 100;
		/// <summary>
		///  Type of penalty that is applied to FLEE when more than agi_penalty_count monsters are targetting player
		/// <para> 0 = no penalty is applied</para>
		/// <para> 1 = agi_penalty_num is reduced from FLEE as a %</para>
		/// <para> 2 = agi_penalty_num is reduced from FLEE as an exact amount</para>
		/// </summary>
		public static bool AgiPenaltyType = true;
		/// <summary>
		///  When agi penalty is enabled, to whom it should apply to? (Note 3)
		/// <para> By default, only players get the penalty.</para>
		/// </summary>
		public static bool AgiPenaltyTarget = true;
		/// <summary>
		///  Amount of enemies required to be targetting player before FLEE begins to be penalized
		/// </summary>
		public static int AgiPenaltyCount = 3;
		/// <summary>
		///  Amount of FLEE penalized per each attacking monster more than agi_penalty_count
		/// </summary>
		public static int AgiPenaltyNum = 10;
		/// <summary>
		///  Type of penalty that is applied to both equipment and vit DEF when more than vit_penalty_count monsters are targetting player
		/// <para> 0 = no penalty is applied</para>
		/// <para> 1 = vit_penalty_num is reduced from DEF as a %</para>
		/// <para> 2 = vit_penalty_num is reduced from DEF as an exact amount</para>
		/// </summary>
		public static bool VitPenaltyType = true;
		/// <summary>
		///  When vit penalty is enabled, to whom it should apply to? (Note 3)
		/// <para> By default, only players get the penalty.</para>
		/// </summary>
		public static bool VitPenaltyTarget = true;
		/// <summary>
		///  Amount of enemies required to be targetting player before defense begins to be penalized
		/// </summary>
		public static int VitPenaltyCount = 3;
		/// <summary>
		///  Amount of VIT defense penalized per each attacking monster more than vit_penalty_count
		/// </summary>
		public static int VitPenaltyNum = 5;
		/// <summary>
		///  Use alternate method of DEF calculation for physical attacks.
		/// <para> With 0, disabled (use normal def% reduction with further def2 reduction)</para>
		/// <para> At 1 or more defense is substraction of (DEF* value).</para>
		/// <para> eg: 10 + 50 def becomes 0 + (10*type + 50)</para>
		/// </summary>
		public static bool WeaponDefenseType = false;
		/// <summary>
		/// MDEFï¿½same as above....(MDEF*value)
		/// </summary>
		public static bool MagicDefenseType = false;
		/// <summary>
		///  How to count the number of attackers when applying agi penalty ? (choose one)
		/// <para> 1-: Count every attack attempt (even those that were dodged/lucky-dodged)</para>
		/// <para> 2 : Count every non-lucky-dodged attack attempt</para>
		/// <para> 3 : Count attacks that miss due to element/race modifier</para>
		/// <para> 4 : Count attacks whose damages are blocked by skills</para>
		/// <para> 5 : Count only attacks that actually connect</para>
		/// <para> 6+: None of the above, count will always be 0</para>
		/// </summary>
		public static int AgiPenaltyCountLv = 2;
		/// <summary>
		///  How to count the number of attackers when applying vit penalty ? (choose one)
		/// <para> 1-: Count every attack attempt (even those that were dodged/lucky-dodged)</para>
		/// <para> 2 : Count every non-lucky-dodged attack attempt</para>
		/// <para> 3 : Count attacks that miss due to element/race modifier</para>
		/// <para> 4 : Count attacks whose damages are blocked by skills</para>
		/// <para> 5 : Count only attacks that actually connect</para>
		/// <para> 6+: None of the above, count will always be 0</para>
		/// </summary>
		public static int VitPenaltyCountLv = 3;
		/// <summary>
		///  Change attacker's direction to face opponent on every attack? (Note 3)
		/// </summary>
		public static int AttackDirectionChange = 15;
		/// <summary>
		///  For those who is set, their innate attack element is "not elemental"
		/// <para> (100% versus on all defense-elements) (Note 3)</para>
		/// <para> NOTE: This is the setting that makes it so non-players can hit for full</para>
		/// <para> damage against Ghost-type targets with normal attacks (eg: vs. Ghostring).</para>
		/// </summary>
		public static int AttackAttrNone = 14;
		/// <summary>
		///  Rate at which equipment can break (base rate before it's modified by any skills)
		/// <para> 1 = 0.01% chance. Default for official servers: 0</para>
		/// </summary>
		public static bool EquipNaturalBreakRate = false;
		/// <summary>
		///  Overall rate of which your own equipment can break. (Note 2)
		/// <para> This rate affects penalty breaking rate of skills such as power-thrust and your natural breaking rate</para>
		/// <para> (from equip_natural_break_rate). If a Sage's endow skill fails and this is above 0, the selected char's</para>
		/// <para> weapon will be broken.</para>
		/// </summary>
		public static int EquipSelfBreakRate = 100;
		/// <summary>
		///  Overall rate at which you can break target's equipment. (Note 2)
		/// <para> This affects the behaviour of skills like acid terror and meltdown</para>
		/// </summary>
		public static int EquipSkillBreakRate = 100;
		/// <summary>
		///  Do weapon attacks have a attack speed delay before actual damage is applied? (Note 1)
		/// <para> NOTE: The official setting is yes, even thought it degrades performance a bit.</para>
		/// </summary>
		public static bool DelayBattleDamage = true;
		/// <summary>
		///  Are arrows/ammo consumed when used on a bow/gun?
		/// <para> 0 = No</para>
		/// <para> 1 = Yes</para>
		/// <para> 2 = Yes even for skills that do not specify arrow consumption when said</para>
		/// <para>     skill is weapon-based and used with ranged weapons (auto-guesses which</para>
		/// <para>     skills should consume ammo when it's acquired via a card or plagiarize)</para>
		/// </summary>
		public static bool ArrowDecrement = true;
		/// <summary>
		///  Should the item script bonus 'Autospell' check for range/obstacles before casting?
		/// <para> Official behavior is "no", setting this to "yes" will make skills use their defined</para>
		/// <para> range. For example, Sonic Blow requires a 2 cell distance before autocasting is allowed.</para>
		/// <para> This setting also affects autospellwhenhit.</para>
		/// </summary>
		public static bool AutospellCheckRange = false;


		/*******************************************************
		 * battleground.conf
		 * Battleground
		 ******************************************************/
		/// <summary>
		///  Melee damage adjustments (non skills) for Battleground maps (Note 2)
		/// </summary>
		public static int BgShortAttackDamageRate = 80;
		/// <summary>
		///  Ranged damage adjustments (non skills) for Battleground maps (Note 2)
		/// </summary>
		public static int BgLongAttackDamageRate = 80;
		/// <summary>
		///  Weapon skills damage adjustments for Battleground maps (Note 2)
		/// </summary>
		public static int BgWeaponAttackDamageRate = 60;
		/// <summary>
		///  Magic skills damage adjustments for Battleground maps (Note 2)
		/// </summary>
		public static int BgMagicAttackDamageRate = 60;
		/// <summary>
		///  Misc skills damage adjustments for Battleground maps (Note 2)
		/// </summary>
		public static int BgMiscAttackDamageRate = 60;
		/// <summary>
		///  Flee penalty on BG grounds.
		/// <para> NOTE: It's %, not absolute, so 20 is -20% of your total flee</para>
		/// </summary>
		public static int BgFleePenalty = 20;
		/// <summary>
		///  Interval before updating the bg-member map mini-dots (milliseconds)
		/// </summary>
		public static int BgUpdateInterval = 1000;


		/*******************************************************
		 * client.conf
		 * Client
		 ******************************************************/
		/// <summary>
		///  Set here which client version do you accept. Add all values of clients:
		/// <para> Clients older than accepted versions, and versions not set to 'accepted'</para>
		/// <para> here will be rejected when logging in</para>
		/// <para> 0x00001: Clients older than 2004-09-06aSakray (packet versions 5-9)</para>
		/// <para> 0x00002: 2004-09-06aSakexe (version 10)</para>
		/// <para> 0x00004: 2004-09-20aSakexe (version 11)</para>
		/// <para> 0x00008: 2004-10-05aSakexe (version 12)</para>
		/// <para> 0x00010: 2004-10-25aSakexe (version 13)</para>
		/// <para> 0x00020: 2004-11-29aSakexe (version 14)</para>
		/// <para> 0x00040: 2005-01-10bSakexe (version 15)</para>
		/// <para> 0x00080: 2005-05-09aSakexe (version 16)</para>
		/// <para> 0x00100: 2005-06-28aSakexe (version 17)</para>
		/// <para> 0x00200: 2005-07-18aSakexe (version 18)</para>
		/// <para> 0x00400: 2005-07-19bSakexe (version 19)</para>
		/// <para> 0x00800: 2006-03-27aSakexe (version 20)</para>
		/// <para> 0x01000: 2007-01-08aSakexe (version 21)</para>
		/// <para> 0x02000: 2007-02-12aSakexe (version 22)</para>
		/// <para> 0x04000: 2008-09-10aSakexe (version 23)</para>
		/// <para> 0x08000: 2008-08-27aRagexeRE (version 24)</para>
		/// <para> 0x10000: 2008-09-10aRagexeRE (version 25)</para>
		/// <para> default value: 0xFFFFF (all clients)</para>
		/// </summary>
		public static int PacketVerFlag = 0xFFFFF;
		/// <summary>
		///  Minimum delay between whisper/global/party/guild messages (in ms)
		/// <para> Messages that break this threshold are silently omitted.</para>
		/// </summary>
		public static bool MinChatDelay = false;
		/// <summary>
		///  valid range of dye's and styles on the client
		/// </summary>
		public static bool MinHairStyle = false;
		public static int MaxHairStyle = 27;
		public static bool MinHairColor = false;
		public static int MaxHairColor = 8;
		public static bool MinClothColor = false;
		public static int MaxClothColor = 4;
		/// <summary>
		///  When set to yes, the damage field in packets sent from woe maps will be set
		/// <para> to -1, making it impossible for GMs, Bots and Hexed clients to know the</para>
		/// <para> actual damage caused by attacks. (Note 1)</para>
		/// </summary>
		public static bool HideWoeDamage = false;
		/// <summary>
		///  "hair style" number that identifies pet.
		/// <para> NOTE: The client uses the "hair style" field in the mob packet to tell them apart from mobs.</para>
		/// <para> This value is always higher than the max hair-style available in said client.</para>
		/// <para> Known values to work (all 2005 clients):</para>
		/// <para> older sakexes: 20</para>
		/// <para> sakexe 0614: 24</para>
		/// <para> sakexe 0628 (and later): 100</para>
		/// </summary>
		public static int PetHairStyle = 100;
		/// <summary>
		///  Visible area size (how many squares away from a player can they see)
		/// </summary>
		public static int AreaSize = 14;
		/// <summary>
		///  Maximum allowed 'level' value that can be sent in unit packets.
		/// <para> Use together with the aura_lv setting to tell when exactly to show the aura.</para>
		/// <para> NOTE: You also need to adjust the client if you want this to work.</para>
		/// <para> NOTE: Default is 99. Values above 127 will probably behave incorrectly.</para>
		/// <para> NOTE: If you don't know what this does, don't change it!!!</para>
		/// </summary>
		public static int MaxLv = 99;
		/// <summary>
		///  Level required to display an aura.
		/// <para> NOTE: This assumes that sending max_lv to the client will display the aura.</para>
		/// <para> NOTE: aura_lv must not be less than max_lv.</para>
		/// <para> Example: If max_lv is 99 and aura_lv is 150, characters with level 99~149</para>
		/// <para>          will be sent as being all level 98, and only characters with level</para>
		/// <para>          150 or more will be reported as having level 99 and show an aura.</para>
		/// </summary>
		public static int AuraLv = 99;
		/// <summary>
		///  Units types affected by max_lv and aura_lv settings. (Note 3)
		/// <para> Note: If an unit type, which normally does not show an aura, is</para>
		/// <para>       set it will obtain an aura when it meets the level requirement.</para>
		/// <para> Default: 0 (none)</para>
		/// </summary>
		public static bool ClientLimitUnitLv = false;
		/// <summary>
		///  Will tuxedo and wedding dresses be shown when worn? (Note 1)
		/// </summary>
		public static bool WeddingModifydisplay = false;
		/// <summary>
		///  Save Clothes color. (This will degrade performance) (Note 1)
		/// </summary>
		public static bool SaveClothcolor = true;
		/// <summary>
		///  Do not display cloth colors for the wedding class?
		/// <para> Note: Both save_clothcolor and wedding_modifydisplay have to be enabled</para>
		/// <para> for this option to take effect. Set this to yes if your cloth palettes</para>
		/// <para> pack doesn't has wedding palettes (or has less than the other jobs)</para>
		/// </summary>
		public static bool WeddingIgnorepalette = false;
		/// <summary>
		///  Do not display cloth colors for the Xmas class?
		/// <para> Set this to yes if your cloth palettes pack doesn't has Xmas palettes (or has less than the other jobs)</para>
		/// </summary>
		public static bool XmasIgnorepalette = false;
		/// <summary>
		///  Do not display cloth colors for the Summer class?
		/// <para> Set this to yes if your cloth palettes pack doesn't has Summer palettes (or has less than the other jobs)</para>
		/// </summary>
		public static bool SummerIgnorepalette = false;
		/// <summary>
		///  Set this to 1 if your clients have langtype problems and can't display motd properly
		/// </summary>
		public static bool MotdType = false;
		/// <summary>
		///  Show eAthena version to users when the login?
		/// </summary>
		public static bool DisplayVersion = true;
		/// <summary>
		///  When affected with the "Hallucination" status effect, send the effect to client? (Note 1)
		/// <para> Note: Set to 'no' if the client lags due to the "Wavy" screen effect.</para>
		/// </summary>
		public static bool DisplayHallucination = true;
		/// <summary>
		///  Set this to 1 if your client supports status change timers and you want to use them
		/// <para> Clients from 2009 onward support this</para>
		/// </summary>
		public static bool DisplayStatusTimers = true;
		/// <summary>
		///  Randomizes the dice emoticon server-side, to prevent clients from forging
		/// <para> packets for the desired number. (Note 1)</para>
		/// </summary>
		public static bool ClientReshuffleDice = false;
		/// <summary>
		///  Sorts the character and guild storage before it is sent to the client.
		/// <para> Official servers do not sort storage. (Note 1)</para>
		/// <para> NOTE: Enabling this option degrades performance.</para>
		/// </summary>
		public static bool ClientSortStorage = false;


		/*******************************************************
		 * drops.conf
		 * Drops
		 ******************************************************/
		/// <summary>
		///  If an item is dropped, does it go stright into the users inventory? (Note 1)
		/// </summary>
		public static bool ItemAutoGet = false;
		/// <summary>
		///  How long does it take for an item to disappear from the floor after it is dropped? (in miliseconds)
		/// </summary>
		public static int FlooritemLifetime = 60000;
		/// <summary>
		///  Grace time during which only the person who did the most damage to a monster can get the item? (in milliseconds)
		/// </summary>
		public static int ItemFirstGetTime = 3000;
		/// <summary>
		///  Grace time during which only the first and second person who did the most damage to a monster can get the item? (in milliseconds)
		/// <para> (Takes effect after item_first_get_time elapses)</para>
		/// </summary>
		public static int ItemSecondGetTime = 1000;
		/// <summary>
		///  Grace time during which only the first, second and third person who did the most damage to a monster can get the item? (in milliseconds)
		/// <para> (Takes effect after the item_second_get_time elapses)</para>
		/// </summary>
		public static int ItemThirdGetTime = 1000;
		/// <summary>
		///  Grace time to apply to MvP reward items when the Most Valuable Player can't get the prize item and it drops on the ground? (in milliseconds)
		/// </summary>
		public static int MvpItemFirstGetTime = 10000;
		/// <summary>
		///  Grace time for the first and second MvP so they can get the item? (in milliseconds)
		/// <para> (Takes effect after mvp_item_first_get_time elapses)</para>
		/// </summary>
		public static int MvpItemSecondGetTime = 10000;
		/// <summary>
		///  Grace time for the first, second and third MvP so they can get the item? (in milliseconds)
		/// <para> (Takes effect after mvp_item_second_get_time elapses)</para>
		/// </summary>
		public static int MvpItemThirdGetTime = 2000;
		/// <summary>
		///  Item drop rates (Note 2)
		/// <para> The rate the common items are dropped (Items that are in the ETC tab, besides card)</para>
		/// </summary>
		public static int ItemRateCommon = 100;
		public static int ItemRateCommonBoss = 100;
		public static bool ItemDropCommonMin = true;
		public static int ItemDropCommonMax = 10000;
		/// <summary>
		///  The rate healing items are dropped (items that restore HP or SP)
		/// </summary>
		public static int ItemRateHeal = 100;
		public static int ItemRateHealBoss = 100;
		public static bool ItemDropHealMin = true;
		public static int ItemDropHealMax = 10000;
		/// <summary>
		///  The rate at which usable items (in the item tab) other then healing items are dropped.
		/// </summary>
		public static int ItemRateUse = 100;
		public static int ItemRateUseBoss = 100;
		public static bool ItemDropUseMin = true;
		public static int ItemDropUseMax = 10000;
		/// <summary>
		///  The rate at which equipment is dropped.
		/// </summary>
		public static int ItemRateEquip = 100;
		public static int ItemRateEquipBoss = 100;
		public static bool ItemDropEquipMin = true;
		public static int ItemDropEquipMax = 10000;
		/// <summary>
		///  The rate at which cards are dropped
		/// </summary>
		public static int ItemRateCard = 100;
		public static int ItemRateCardBoss = 100;
		public static bool ItemDropCardMin = true;
		public static int ItemDropCardMax = 10000;
		/// <summary>
		///  The rate adjustment for the MVP items that the MVP gets directly in their inventory
		/// </summary>
		public static int ItemRateMvp = 100;
		public static bool ItemDropMvpMin = true;
		public static int ItemDropMvpMax = 10000;
		/// <summary>
		///  The rate adjustment for card-granted item drops.
		/// </summary>
		public static int ItemRateAdddrop = 100;
		public static bool ItemDropAddMin = true;
		public static int ItemDropAddMax = 10000;
		/// <summary>
		///  Rate adjustment for Treasure Box drops (these override all other modifiers)
		/// </summary>
		public static int ItemRateTreasure = 100;
		public static bool ItemDropTreasureMin = true;
		public static int ItemDropTreasureMax = 10000;
		/// <summary>
		///  Use logarithmic drops? (Note 1)
		/// <para> Logarithmic drops scale drop rates in a non-linear fashion using the equation</para>
		/// <para> Droprate(x,y) = x * (5 - log(x)) ^ (ln(y) / ln(5))</para>
		/// <para> Where x is the original drop rate and y is the drop_rate modifier (the previously mentioned item_rate* variables)</para>
		/// <para> Use the following table for an idea of how the rate will affect drop rates when logarithmic drops are used:</para>
		/// <para> Y: Original Drop Rate</para>
		/// <para> X: Rate drop modifier (eg: item_rate_equip)</para>
		/// <para>  X\Y | 0.01 0.02  0.05  0.10  0.20  0.50  1.00  2.00  5.00 10.00 20.00</para>
		/// <para> -----+---------------------------------------------------------------</para>
		/// <para>   50 | 0.01 0.01  0.03  0.06  0.11  0.30  0.62  1.30  3.49  7.42 15.92</para>
		/// <para>  100 | 0.01 0.02  0.05  0.10  0.20  0.50  1.00  2.00  5.00 10.00 20.00</para>
		/// <para>  200 | 0.02 0.04  0.09  0.18  0.35  0.84  1.61  3.07  7.16 13.48 25.13</para>
		/// <para>  500 | 0.05 0.09  0.22  0.40  0.74  1.65  3.00  5.40 11.51 20.00 33.98</para>
		/// <para> 1000 | 0.10 0.18  0.40  0.73  1.30  2.76  4.82  8.28 16.47 26.96 42.69</para>
		/// <para> 2000 | 0.20 0.36  0.76  1.32  2.28  4.62  7.73 12.70 23.58 36.33 53.64</para>
		/// <para> 5000 | 0.50 0.86  1.73  2.91  4.81  9.11 14.45 22.34 37.90 53.91 72.53</para>
		/// <para>10000 | 1.00 1.67  3.25  5.28  8.44 15.24 23.19 34.26 54.57 72.67 91.13</para>
		/// <para>20000 | 2.00 3.26  6.09  9.59 14.83 25.49 37.21 52.55 77.70 97.95  100%</para>
		/// <para>50000 | 5.00 7.87 13.98 21.12 31.23 50.31 69.56 92.48  100%  100%  100%</para>
		/// </summary>
		public static bool ItemLogarithmicDrops = false;
		/// <summary>
		///  Can the monster's drop rate become 0? (Note 1)
		/// <para> Default: no (as in official servers).</para>
		/// </summary>
		public static bool DropRate0item = false;
		/// <summary>
		///  Makes your LUK value affect drop rates on an absolute basis.
		/// <para> Setting to 100 means each luk adds 0.01% chance to find items</para>
		/// <para> (regardless of item's base drop rate).</para>
		/// </summary>
		public static bool DropsByLuk = false;
		/// <summary>
		///  Makes your LUK value affect drop rates on a relative basis.
		/// <para> Setting to 100 means each luk adds 1% chance to find items</para>
		/// <para> (So at 100 luk, everything will have double chance of dropping).</para>
		/// </summary>
		public static bool DropsByLuk2 = false;
		/// <summary>
		///  The rate of monsters dropping ores by the skill Ore Discovery (Default is 100)
		/// </summary>
		public static int FindingOreRate = 100;
		/// <summary>
		///  Whether or not Marine Spheres and Floras summoned by Alchemist drop items?
		/// <para> This setting has three available values:</para>
		/// <para> 0: Nothing drops.</para>
		/// <para> 1: Only marine spheres drop items.</para>
		/// <para> 2: All alchemist summons drop items.</para>
		/// </summary>
		public static bool AlchemistSummonReward = true;
		/// <summary>
		///  Make broadcast ** Player1 won Pupa's Pupa Card (chance 0.01%) ***
		/// <para> Note: It also announces STEAL skill usage with rare items</para>
		/// <para> 0 = don't show announces at all</para>
		/// <para> 1 = show announces for 0.01% drop chance items</para>
		/// <para> 333 = show announces for 3.33% or lower drop chance items</para>
		/// <para> 10000 = show announces for all items</para>
		/// </summary>
		public static bool RareDropAnnounce = false;


		/*******************************************************
		 * exp.conf
		 * Exp
		 ******************************************************/
		/// <summary>
		///  Rate at which exp. is given. (Note 2)
		/// </summary>
		public static int BaseExpRate = 100;
		/// <summary>
		///  Rate at which job exp. is given. (Note 2)
		/// </summary>
		public static int JobExpRate = 100;
		/// <summary>
		///  Turn this on to allow a player to level up more than once from a kill. (Note 1)
		/// </summary>
		public static bool MultiLevelUp = false;
		/// <summary>
		///  Setting this can cap the max experience one can get per kill specified as a
		/// <para> % of the current exp bar. (Every 10 = 1.0%)</para>
		/// <para> For example, set it to 500 and no matter how much exp the mob gives,</para>
		/// <para> it can never give you above half of your current exp bar.</para>
		/// </summary>
		public static bool MaxExpGainRate = false;
		/// <summary>
		///  Method of calculating earned experience when defeating a monster:
		/// <para> 0 = uses damage given / total damage as damage ratio</para>
		/// <para> 1 = uses damage given / max_hp as damage ratio</para>
		/// <para> NOTE: Using type 1 disables the bonus where the first attacker gets</para>
		/// <para>       his share of the exp doubled when multiple people attack the mob.</para>
		/// </summary>
		public static bool ExpCalcType = false;
		/// <summary>
		///  Experience increase per attacker. That is, every additional attacker to the
		/// <para> monster makes it give this much more experience</para>
		/// <para> (eg: 5 people attack with 25 here, +(25*4)% -> +100% exp)</para>
		/// </summary>
		public static int ExpBonusAttacker = 25;
		/// <summary>
		///  Max number of attackers at which exp bonus is capped
		/// <para> (eg: if set at 5, the max bonus is 4*bonus-per-char regardless of attackers)</para>
		/// </summary>
		public static int ExpBonusMaxAttacker = 12;
		/// <summary>
		///  MVP bonus exp rate. (Note 2)
		/// </summary>
		public static int MvpExpRate = 100;
		/// <summary>
		///  Rate of base/job exp given by NPCs. (Note 2)
		/// </summary>
		public static int QuestExpRate = 100;
		/// <summary>
		///  The rate of job exp. from using Heal skill (100 is the same as the heal amount, 200 is double.
		/// <para> The balance of the exp. rate is best used with 5 to 10)</para>
		/// </summary>
		public static bool HealExp = false;
		/// <summary>
		///  The rate of exp. that is gained by the process of resurrection, a unit is 0.01%.
		/// <para> Experience calculations for the experience value * level difference of the person revived / 100 * resurrection_exp/10000 which the revived player has can be got.</para>
		/// </summary>
		public static bool ResurrectionExp = false;
		/// <summary>
		///  The rate of job exp. when using discount and overcharge on an NPC
		/// <para> (in 0.01% increments - 100 is 1%, 10000 is normal, 20000 is double.)</para>
		/// <para> The way it is calculated is (money received * skill lv) * shop_exp / 10000.</para>
		/// </summary>
		public static bool ShopExp = false;
		/// <summary>
		///  PVP exp.  Do players get exp in PvP maps
		/// <para> (Note: NOT exp from players, but from normal leveling)</para>
		/// </summary>
		public static bool PvpExp = true;
		/// <summary>
		///  When a player dies, how should we penalize them?
		/// <para> 0 = No penalty.</para>
		/// <para> 1 = Lose % of current level when killed.</para>
		/// <para> 2 = Lose % of total experience when killed.</para>
		/// </summary>
		public static bool DeathPenaltyType = true;
		/// <summary>
		///  Base exp. penalty rate (Each 100 is 1% of their exp)
		/// </summary>
		public static int DeathPenaltyBase = 100;
		/// <summary>
		///  Job exp. penalty rate (Each 100 is 1% of their exp)
		/// </summary>
		public static int DeathPenaltyJob = 100;
		/// <summary>
		///  When a player dies, how much zeny should we penalize them with?
		/// <para> NOTE: It is a percentage of their zeny, so 100 = 1%</para>
		/// </summary>
		public static bool ZenyPenalty = false;
		/// <summary>
		///  Will display experience gained from killing a monster. (Note 1)
		/// </summary>
		public static bool DispExperience = false;
		/// <summary>
		///  Will display zeny earned (from mobs, trades, etc) (Note 1)
		/// </summary>
		public static bool DispZeny = false;
		/// <summary>
		///  Use the contents of db/statpoint.txt when doing a stats reset and leveling up? (Note 1)
		/// <para> If no, an equation will be used which preserves statpoints earned/lost</para>
		/// <para> through external means (ie: stat point buyers/sellers)</para>
		/// </summary>
		public static bool UseStatpointTable = true;


		/*******************************************************
		 * feature.conf
		 * Feature
		 ******************************************************/
		/// <summary>
		///  Buying store (Note 1)
		/// <para> Requires: 2010-04-27aRagexeRE or later</para>
		/// </summary>
		public static bool FeatureBuyingStore = true;
		/// <summary>
		///  Search stores (Note 1)
		/// <para> Requires: 2010-08-03aRagexeRE or later</para>
		/// </summary>
		public static bool FeatureSearchStores = true;


		/*******************************************************
		 * gm.conf
		 * Gm
		 ******************************************************/
		/// <summary>
		///  The maximum quantity of monsters that can be summoned per GM command (0 denotes an unlimited quantity)
		/// </summary>
		public static int AtcommandSpawnQuantityLimit = 100;
		/// <summary>
		///  Maximum number of slave-clones that can be have by using the @slaveclone at command. (0 denotes unlimited quantity)
		/// </summary>
		public static int AtcommandSlaveCloneLimit = 25;
		/// <summary>
		///  If 'no', commands require exact player name. If 'yes', entering a partial
		/// <para> name will work, as long as there's only one match from all players in the</para>
		/// <para> current map server.</para>
		/// </summary>
		public static bool PartialNameScan = true;
		/// <summary>
		///  The level at which a player with access is considered a GM.
		/// <para> An account with an access level lower than this is not effected</para>
		/// <para> by gm_can_drop_lv (battle_athena.conf).</para>
		/// </summary>
		public static int LowestGmLevel = 1;
		/// <summary>
		///  [GM] Can use all skills? (No or mimimum GM level)
		/// </summary>
		public static int GmAllSkill = 0;
		/// <summary>
		///  [GM] Can equip anything? (No or minimum GM level, can cause client errors.)
		/// </summary>
		public static int GmAllEquipment = 0;
		/// <summary>
		///  [GM] Can use skills without meeting the required conditions (items, etc...)?
		/// <para> 'no' or minimum GM level to bypass requirements.</para>
		/// </summary>
		public static int GmSkillUnconditional = 0;
		/// <summary>
		///  [GM] Can join a password protected chat? (No or mimimum GM level)
		/// </summary>
		public static int GmJoinChat = 0;
		/// <summary>
		///  [GM] Can't be kicked from a chat? (No or mimimum GM level)
		/// </summary>
		public static int GmKickChat = 0;
		/// <summary>
		///  (@) GM Commands available only to GM's? (Note 1)
		/// <para> set to 'No', Normal players (gm level 0) can use GM commands _IF_ you set the command level to 0.</para>
		/// <para> set to 'Yes', Normal players (gm level 0) can never use a GM command even if you set the command level to 0.</para>
		/// </summary>
		public static bool AtcommandGmOnly = false;
		/// <summary>
		///  Is the character of a GM account set as the object of a display by @ command etc. or not?
		/// </summary>
		public static bool HideGMSession = false;
		/// <summary>
		///  At what GM level can you see GMs and Account/Char IDs in the @who command?
		/// </summary>
		public static int WhoDisplayAid = 40;
		/// <summary>
		///  Ban people that try trade dupe.
		/// <para> Duration of the ban, in minutes (default: 5). To disable the ban, set 0.</para>
		/// </summary>
		public static int BanHackTrade = 5;
		/// <summary>
		///  Set here minimum level of a (online) GM that can receive all informations about any player that try to hack, spoof a name, etc.
		/// <para> Values are from 0 to 100.</para>
		/// <para> 100: disable information</para>
		/// <para> 0: send to any people, including normal players</para>
		/// <para> default: 60, according to GM definition in atcommand_athena.conf</para>
		/// </summary>
		public static int HackInfoGMLevel = 60;
		/// <summary>
		///  The minimum GM level to bypass nowarp and nowarpto mapflags.
		/// <para> This option is mainly used in commands which modify a character's</para>
		/// <para> map/coordinates (like @memo, @warp, @charwarp, @go, @jump, etc...).</para>
		/// <para> default: 20 (first level after normal player or super'normal' player)</para>
		/// </summary>
		public static int AnyWarpGMMinLevel = 20;
		/// <summary>
		///  The minimum level for a GM to be unable to distribute items.
		/// <para> You should set this to the same level @item is set to in the atcommand.conf</para>
		/// <para> NEVER SET THIS VALUE TO 0, or you will block drop/trade for normal players</para>
		/// </summary>
		public static bool GmCantDropMinLv = true;
		/// <summary>
		/// The trust level for your GMs. Any GMs ABOVE this level will be able to distribute items
		/// <para>ie: Use Storage/Guild Storage, Drop Items, Use Vend, Trade items.</para>
		/// </summary>
		public static bool GmCantDropMaxLv = false;
		/// <summary>
		///  Minimum GM level to see the hp of every player? (Default: 60)
		/// <para> no/0 can be used to disable it.</para>
		/// </summary>
		public static bool DispHpmeter = false;
		/// <summary>
		///  Minimum GM level to view players equip regardless of their setting.
		/// <para> (Default: 0 = Disabled).</para>
		/// </summary>
		public static bool GmViewequipMinLv = false;
		/// <summary>
		///  Can GMs invite non GMs to a party? (Note 1)
		/// <para> set to 'No', GMs under the party invite trust level may not invite non GMs to a party.</para>
		/// <para> set to 'Yes', All GMs can invite any player to a party.</para>
		/// <para> Also, as long as this is off, players cannot invite GMs to a party as well.</para>
		/// </summary>
		public static bool GmCanParty = false;
		/// <summary>
		/// The trust level for GMs to invite to a party. Any GMs ABOVE OR EQUAL TO this level will be able to invite normal
		/// <para>players into their party in addittion to other GMs. (regardless of gm_can_party)</para>
		/// </summary>
		public static int GmCantPartyMinLv = 20;
		/// <summary>
		///  Players Titles (check msg_athena.conf for title strings)
		/// <para> You may assign different titles for your Players and GMs</para>
		/// </summary>
		public static bool TitleLvl1 = true;
		public static int TitleLvl2 = 10;
		public static int TitleLvl3 = 20;
		public static int TitleLvl4 = 40;
		public static int TitleLvl5 = 50;
		public static int TitleLvl6 = 60;
		public static int TitleLvl7 = 80;
		public static int TitleLvl8 = 99;
		/// <summary>
		///  Minimum GM level required for client command /check (display character status) to work.
		/// <para> Default: 60</para>
		/// </summary>
		public static int GmCheckMinlevel = 60;


		/*******************************************************
		 * guild.conf
		 * Guild
		 ******************************************************/
		/// <summary>
		///  When making a guild, an Emperium is consumed? (Note 1)
		/// </summary>
		public static bool GuildEmperiumCheck = true;
		/// <summary>
		///  Maximum tax limit on a guild member.
		/// </summary>
		public static int GuildExpLimit = 50;
		/// <summary>
		///  Maximum castles one guild can own (0 = unlimited)
		/// </summary>
		public static bool GuildMaxCastles = false;
		/// <summary>
		///  Activate guild skills delay by relog? (Note 1)
		/// <para> Official setting is "yes", otherwise allow guild leaders to relog to cancel the 5 minute delay.</para>
		/// </summary>
		public static bool GuildSkillRelogDelay = true;
		/// <summary>
		///  Damage adjustments for WOE battles against defending Guild monsters (Note 2)
		/// </summary>
		public static int CastleDefenseRate = 100;
		/// <summary>
		///  Melee damage adjustments (non skills) for WoE battles (Guild Vs Guild) (Note 2)
		/// </summary>
		public static int GvgShortAttackDamageRate = 80;
		/// <summary>
		///  Ranged damage adjustments (non skills) for WoE battles (Guild Vs Guild) (Note 2)
		/// </summary>
		public static int GvgLongAttackDamageRate = 80;
		/// <summary>
		///  Weapon skills damage adjustments for WoE battles (Guild Vs Guild) (Note 2)
		/// </summary>
		public static int GvgWeaponAttackDamageRate = 60;
		/// <summary>
		///  Magic skills damage adjustments for WoE battles (Guild Vs Guild) (Note 2)
		/// </summary>
		public static int GvgMagicAttackDamageRate = 60;
		/// <summary>
		///  Misc skills damage adjustments for WoE battles (Guild Vs Guild) (Note 2)
		/// </summary>
		public static int GvgMiscAttackDamageRate = 60;
		/// <summary>
		///  Flee penalty on gvg grounds. Official value is 20 (Note 2)
		/// <para> NOTE: It's %, not absolute, so 20 is -20% of your total flee</para>
		/// </summary>
		public static int GvgFleePenalty = 20;
		/// <summary>
		///  When the emperium is broken during WoE, how long before the announcement
		/// <para> displaying the new castle-occupants? (in miliseconds)</para>
		/// </summary>
		public static int GvgEliminateTime = 7000;
		/// <summary>
		///  Can the 'Glory of Guild' skill be learnt in the Guild window,
		/// <para> and does changing emblems require it? (Note 1)</para>
		/// <para> P.S: This skill is not implemented on official servers</para>
		/// </summary>
		public static bool RequireGloryGuild = false;
		/// <summary>
		///  Limit Guild alliances. Value is 0 to 3.
		/// <para> If you want to change this value, clear the guild alliance table.</para>
		/// <para> Default is 3</para>
		/// </summary>
		public static int MaxGuildAlliance = 3;


		/*******************************************************
		 * homunc.conf
		 * Homunc
		 ******************************************************/
		/// <summary>
		///  Homunculus setting (Note 3)
		/// <para> Activates various 'quirks' that makes them behave unlike normal characters.</para>
		/// <para> 0x001: Can't be targetted by support skills (except for their master)</para>
		/// <para> 0x004: Mobs will always go after them instead of players until attacked</para>
		/// <para> 0x008: Copy their master's speed on spawn/map-change</para>
		/// <para> 0x010: They display luk/3+1 instead of their actual critical in the</para>
		/// <para>        stat window (by default they don't crit)</para>
		/// <para> 0x020: Their Min-Matk is always the same as their max</para>
		/// <para> 0x040: Skill re-use delay is reset when they are vaporized.</para>
		/// </summary>
		public static int HomSetting = 0xFFFF;
		/// <summary>
		///  The rate a homunculus will get friendly by feeding it. (Note 2)
		/// </summary>
		public static int HomunculusFriendlyRate = 100;
		/// <summary>
		///  Can you name a homunculus more then once? (Note 1)
		/// </summary>
		public static bool HomRename = false;
		/// <summary>
		///  Intimacy needed to use Evolved Vanilmirth's Bio Explosion
		/// </summary>
		public static int HvanExplosionIntimate = 45000;
		/// <summary>
		///  Show stat growth to the owner when an Homunculus levels up
		/// </summary>
		public static bool HomunculusShowGrowth = false;
		/// <summary>
		///  Does autoloot work, when a monster is killed by homunculus only?
		/// </summary>
		public static bool HomunculusAutoloot = true;
		/// <summary>
		///  Should homunculii Vaporize when Master dies?
		/// </summary>
		public static bool HomunculusAutoVapor = true;


		/*******************************************************
		 * items.conf
		 * Items
		 ******************************************************/
		/// <summary>
		///  The highest value at which an item can be sold via the merchant vend skill. (in zeny)
		/// </summary>
		public static int VendingMaxValue = 1000000000;
		/// <summary>
		///  Whether to allow buying from vending chars that are at their max. zeny limit.
		/// <para> If set to yes, the rest of the zeny above the char's capacity will disappear.</para>
		/// </summary>
		public static bool VendingOverMax = true;
		/// <summary>
		///  Tax to apply to all vending transactions (eg: 10000 = 100%, 50 = 0.50%)
		/// <para> When a tax is applied, the item's full price is charged to the buyer, but</para>
		/// <para> the vender will not get the whole price paid (they get 100% - this tax).</para>
		/// </summary>
		public static int VendingTax = 200;
		/// <summary>
		///  Show the buyer's name when successfully vended an item
		/// </summary>
		public static bool BuyerName = true;
		/// <summary>
		///  Forging success rate. (Note 2)
		/// </summary>
		public static int WeaponProduceRate = 100;
		/// <summary>
		///  Prepare Potion success rate. (Note 2)
		/// </summary>
		public static int PotionProduceRate = 100;
		/// <summary>
		///  Do produced items have the maker's name on them? (Note 3)
		/// <para> 0x01: Produced Weapons</para>
		/// <para> 0x02: Produced Potions</para>
		/// <para> 0x04: Produced Arrows</para>
		/// <para> 0x08: Produced Holy Water</para>
		/// <para> 0x10: Produced Deadly Potions</para>
		/// <para> 0x80: Other produced items.</para>
		/// </summary>
		public static int ProduceItemNameInput = 0x03;
		/// <summary>
		///  Is a monster summoned via dead branch aggressive? (Note 1)
		/// </summary>
		public static bool DeadBranchActive = true;
		/// <summary>
		///  Should summoned monsters check the player's base level? (dead branches) (Note 1)
		/// <para> On officials this is no - monsters summoned from dead/bloody branches can be ANY level.</para>
		/// <para> Change to 'yes' to only summon monsters less than or equal to the player's base level.</para>
		/// </summary>
		public static bool RandomMonsterChecklv = false;
		/// <summary>
		///  Can any player equip any item regardless of the gender restrictions
		/// <para> NOTE: Wedding Rings and Whips/Musical Instruments will check gender regardless of setting.</para>
		/// </summary>
		public static bool IgnoreItemsGender = true;
		/// <summary>
		///  Item check? (Note 1)
		/// <para> On map change it will check for items not tagged as "available" and</para>
		/// <para> auto-delete them from inventory/cart.</para>
		/// <para> NOTE: An item is not available if it was not loaded from the item_db or you</para>
		/// <para> specify it as unavailable in db/item_avail.txt</para>
		/// </summary>
		public static bool ItemCheck = false;
		/// <summary>
		///  How much time must pass between item uses?
		/// <para> Only affects the delay between using items, prevents healing item abuse. Recommended ~500 ms</para>
		/// <para> On officials this is 0, but it's set to 100ms as a measure against bots/macros.</para>
		/// </summary>
		public static int ItemUseInterval = 100;
		/// <summary>
		///  How much time must pass between cash food uses? Default: 60000 (1 min)
		/// </summary>
		public static int CashfoodUseInterval = 60000;
		/// <summary>
		///  Required level of bNoMagicDamage before Status Changes are blocked (Golden Thief Bug card).
		/// <para> For example, if left at 50. An item can give bNoMagicDamage,40;</para>
		/// <para> which reduces magic damage by 40%, but does not blocks status changes.</para>
		/// </summary>
		public static int GtbScImmunity = 50;
		/// <summary>
		///  Enable autospell card effects to stack?
		/// <para> NOTE: Different cards that grant the same skill will both</para>
		/// <para> always work independently of each other regardless of setting.</para>
		/// </summary>
		public static bool AutospellStacking = false;


		/*******************************************************
		 * misc.conf
		 * Misc
		 ******************************************************/
		/// <summary>
		///  PK Server Mode.  Turns entire server pvp(excluding towns). Experience loss is doubled if killed by another player.
		/// <para> When players hunt monsters over 20 levels higher, they will receive 15% additional exp., and 25% chance of receiving more items.</para>
		/// <para> There is a nopvp.txt for setting up maps not to have pk on in this mode.  Novices cannot be attacked and cannot attack.</para>
		/// <para> Normal pvp counter and rank display are disabled as well.</para>
		/// <para> Note: If pk_mode is set to 2 instead of 1 (yes), players will receive a</para>
		/// <para>   manner penalty of 5 each time they kill another player (see manner_system</para>
		/// <para>   config to adjust how this will affect players)</para>
		/// </summary>
		public static bool PkMode = false;
		/// <summary>
		///  Manner/karma system configuration. Specifies how does negative manner
		/// <para> (red no chat bubble) affects players (add as needed):</para>
		/// <para>  0: No penalties.</para>
		/// <para>  1: Disables chatting (includes whispers, party/guild msgs, etc)</para>
		/// <para>  2: Disables skill usage</para>
		/// <para>  4: Disables commands usage</para>
		/// <para>  8: Disables item usage/picking/dropping</para>
		/// <para> 16: Disables room creation (chatrooms and vending shops)</para>
		/// </summary>
		public static int MannerSystem = 15;
		/// <summary>
		///  For PK Server Mode. Change this to define the minimum level players can start PK-ing
		/// </summary>
		public static int PkMinLevel = 55;
		/// <summary>
		///  For PK Server Mode. It specifies the maximum level difference between
		/// <para> players to let them attack each other. 0 disables said limit.</para>
		/// </summary>
		public static bool PkLevelRange = false;
		/// <summary>
		///  For PK servers. Damage adjustment settings, these follow the same logic
		/// <para> as their WoE counterparts (see guild.conf)</para>
		/// </summary>
		public static int PkShortAttackDamageRate = 80;
		public static int PkLongAttackDamageRate = 70;
		public static int PkWeaponAttackDamageRate = 60;
		public static int PkMagicAttackDamageRate = 60;
		public static int PkMiscAttackDamageRate = 60;
		/// <summary>
		///  Display skill usage in console? (for debug only) (default: off) (Note 3)
		/// </summary>
		public static bool SkillLog = false;
		/// <summary>
		///  Display battle log? (for debug only) (default: off) (Note 1)
		/// </summary>
		public static bool BattleLog = false;
		/// <summary>
		///  Display save log? (for debug only) (default: off) (Note 1)
		/// </summary>
		public static bool SaveLog = false;
		/// <summary>
		///  Display other stuff? (for debug only) (default: off) (Note 1)
		/// </summary>
		public static bool EtcLog = false;
		/// <summary>
		///  Do you want to debug warp points? If set to yes, warp points will appear as flags.(Note 1)
		/// <para> It will also run on start-up a warp-check to print out which warp points lead directly on</para>
		/// <para> top of on-touch npcs (which can lead to infinite loopback warping situations)</para>
		/// </summary>
		public static bool WarpPointDebug = false;
		/// <summary>
		///  Choose if server begin with night (yes) or day (no)
		/// </summary>
		public static bool NightAtStart = false;
		/// <summary>
		///  Define duration in msec of the day (default: 7200000 = 2 hours)
		/// <para> Set to 0 to disable day cycle (but not @day GM command).</para>
		/// <para> Except 0, minimum is 60000 (1 minute)</para>
		/// </summary>
		public static bool DayDuration = false;
		/// <summary>
		///  Define duration in msec of the night (default: 1800000 = 30 min)
		/// <para> Set to 0 to disable night cycle (but not @night GM command).</para>
		/// <para> Except 0, minimum is 60000 (1 minute)</para>
		/// </summary>
		public static bool NightDuration = false;
		/// <summary>
		///  Using duel on pvp-maps
		/// </summary>
		public static bool DuelAllowPvp = false;
		/// <summary>
		///  Using duel on gvg-maps
		/// </summary>
		public static bool DuelAllowGvg = false;
		/// <summary>
		///  Allow using teleport/warp when dueling
		/// </summary>
		public static bool DuelAllowTeleport = false;
		/// <summary>
		///  Autoleave duel when die
		/// </summary>
		public static bool DuelAutoleaveWhenDie = true;
		/// <summary>
		///  Delay between using @duel in minutes
		/// </summary>
		public static int DuelTimeInterval = 60;
		/// <summary>
		///  Restrict duel usage to same map
		/// </summary>
		public static bool DuelOnlyOnSameMap = false;
		/// <summary>
		///  Determines max number of characters that can stack within a single cell.
		/// <para> NOTE: For this setting to make effect you have to use a server compiled with</para>
		/// <para> Cell Stack Limit support (see src/map/map.h)</para>
		/// </summary>
		public static bool CellStackLimit = true;
		/// <summary>
		///  Allow autrade only in map with autotrade flag?
		/// <para> Set this to "no" will allow autotrade where no "autotrade" mapflag is set</para>
		/// <para> Set this to "yes" to only allow autotrade on maps with "autotrade" mapflag</para>
		/// </summary>
		public static bool AtMapflag = false;
		/// <summary>
		///  Set this to the amount of minutes autotrade chars will be kicked from the server.
		/// </summary>
		public static bool AtTimeout = false;
		/// <summary>
		///  Auction system, fee per hour. Default is 12000
		/// </summary>
		public static int AuctionFeeperhour = 12000;
		/// <summary>
		///  Auction maximum sell price
		/// </summary>
		public static int AuctionMaximumprice = 500000000;
		/// <summary>
		///  Minimum delay between each store search query in seconds.
		/// </summary>
		public static int SearchstoreQuerydelay = 10;
		/// <summary>
		///  Maximum amount of results a store search query may yield, before
		/// <para> it is canceled.</para>
		/// </summary>
		public static int SearchstoreMaxresults = 30;
		/// <summary>
		///  Whether or not gaining and loosing of cash points is displayed (Note 1).
		/// <para> Default: no</para>
		/// </summary>
		public static bool CashshopShowPoints = false;
		/// <summary>
		///  Whether or not mail box status is displayed upon login.
		/// <para> Default: 0</para>
		/// <para> 0 = No</para>
		/// <para> 1 = Yes</para>
		/// <para> 2 = Yes, when there are unread mails</para>
		/// </summary>
		public static bool MailShowStatus = false;


		/*******************************************************
		 * monster.conf
		 * Monster
		 ******************************************************/
		/// <summary>
		///  The HP rate of MVPs. (Note 2)
		/// </summary>
		public static int MvpHpRate = 100;
		/// <summary>
		///  The HP rate of normal monsters (that is monsters that are not MVP's) (Note 2)
		/// </summary>
		public static int MonsterHpRate = 100;
		/// <summary>
		///  The maximum attack speed of a monster
		/// </summary>
		public static int MonsterMaxAspd = 199;
		/// <summary>
		///  Defines various mob AI related settings. (Note 3)
		/// <para> 0x001: When enabled mobs will update their target cell every few iterations</para>
		/// <para>        (normally they never update their target cell until they reach it while</para>
		/// <para>        chasing)</para>
		/// <para> 0x002: Makes mob use their "rude attack" skill (usually warping away) if they</para>
		/// <para>        are attacked and they can't attack back regardless of how they were</para>
		/// <para>        attacked (eg: GrimTooth), otherwise, their rude attack" is only activated</para>
		/// <para>        if they can't melee reach the target (eg: sniping)</para>
		/// <para> 0x004: If not set, mobs that can change target only do so when melee attacked</para>
		/// <para>        (distance player/mob below 3), otherwise mobs may change target and chase</para>
		/// <para>        ranged attackers. This flag also overrides the 'provoke' target.</para>
		/// <para> 0x008: If set, when a mob loses track of their target, they stop walking</para>
		/// <para>        inmediately. Otherwise, they continue to their last target tile. When</para>
		/// <para>        set mobs also scatter as soon as they lose their target. Use this mode</para>
		/// <para>        to make it much harder to mob-train by hiding and collecting them on a</para>
		/// <para>        single spot (ie: GrimTooth training)</para>
		/// <para> 0x010: If set, mob skills defined for friends will also trigger on themselves.</para>
		/// <para> 0x020: When set, the monster ai is executed for all monsters in maps that</para>
		/// <para>        have players on them, instead of only for mobs who are in the vecinity</para>
		/// <para>        of players.</para>
		/// <para> 0x040: When set, when the mob's target changes map, the mob will walk towards</para>
		/// <para>        any npc-warps in it's sight of view (use with mob_warp below)</para>
		/// <para> 0x100: When set, a mob will pick a random skill from it's list and start from</para>
		/// <para>        that instead of checking skills in orders (when unset, if a mob has too</para>
		/// <para>        many skills, the ones near the end will rarely get selected)</para>
		/// <para> 0x200: When set, a mob's skill re-use delay will not be applied to all entries of</para>
		/// <para>        the same skill, instead, only to that particular entry (eg: Mob has heal</para>
		/// <para>        on six lines in the mob_skill_db, only the entry that is actually used</para>
		/// <para>        will receive the delay). This will make monsters harder, especially MvPs.</para>
		/// <para> 0x400: Set this to make mobs have a range of 9 for all skills. Otherwise, they</para>
		/// <para>        will obey the normal skill range rules.</para>
		/// <para> Example: 0x140 -> Chase players through warps + use skills in random order.</para>
		/// </summary>
		public static bool MonsterAi = false;
		/// <summary>
		///  Should mobs be able to be warped (add as needed)?
		/// <para> 0: Disable.</para>
		/// <para> 1: Enable mob-warping when standing on NPC-warps</para>
		/// <para> 2: Enable mob-warping when standing on Priest Warp Portals</para>
		/// <para> 4: Disable warping when the target map is a 'nobranch' map.</para>
		/// </summary>
		public static bool MobWarp = false;
		/// <summary>
		///  If these are set above 0, they define the time (in ms) during which monsters
		/// <para> will have their 'AI' active after all players have left their vecinity.</para>
		/// </summary>
		public static bool MobActiveTime = false;
		public static bool BossActiveTime = false;
		/// <summary>
		///  Mobs and Pets view-range adjustment (range2 column in the mob_db) (Note 2)
		/// </summary>
		public static int ViewRangeRate = 100;
		/// <summary>
		///  Chase Range is the base minimum-chase that a mob gives before giving up
		/// <para> (as long as the target is outside their field of view). This is the range3</para>
		/// <para> column in the mob_db. (Note 2)</para>
		/// </summary>
		public static int ChaseRangeRate = 100;
		/// <summary>
		///  Allow monsters to be aggresive and attack first? (Note 1)
		/// </summary>
		public static bool MonsterActiveEnable = true;
		/// <summary>
		///  Should the mob_db names override the mob names specified in the spawn files?
		/// <para> 0: No</para>
		/// <para> 1: always use the mob_db Name column (english mob name)</para>
		/// <para> 2: always use the mob_db JName column (original Kro mob name)</para>
		/// </summary>
		public static bool OverrideMobNames = false;
		/// <summary>
		///  Monster damage delay rate (Note 1)
		/// <para> Setting to no/0 is like they always have endure.</para>
		/// </summary>
		public static int MonsterDamageDelayRate = 100;
		/// <summary>
		///  Looting monster actions.
		/// <para> 0 = Monster will consume the item.</para>
		/// <para> 1 = Monster will not consume the item.</para>
		/// </summary>
		public static bool MonsterLootType = false;
		/// <summary>
		///  Chance of mob casting a skill (Note 2)
		/// <para> Higher rates lead to 100% mob skill usage with no/few normal attacks.</para>
		/// <para> Set to 0 to disable mob skills.</para>
		/// </summary>
		public static int MobSkillRate = 100;
		/// <summary>
		///  Mob skill delay adjust (Note 2)
		/// <para> After a mob has casted a skill, there is a delay before being able to</para>
		/// <para> re-cast it. Note that skills with a delay of 0 can't be affected by this</para>
		/// <para> setting.</para>
		/// </summary>
		public static int MobSkillDelay = 100;
		/// <summary>
		///  Rate of monsters on a map, 200 would be twice as many as normal. (Note 2)
		/// </summary>
		public static int MobCountRate = 100;
		/// <summary>
		///  Respawn rate of monsters on a map. 50 would make mobs respawn twice as fast (half delay time) (Note 2)
		/// <para>Note: This does not affects mobs with inmediate respawn (most normal mobs)</para>
		/// </summary>
		public static int MobSpawnDelay = 100;
		public static int PlantSpawnDelay = 100;
		public static int BossSpawnDelay = 100;
		/// <summary>
		///  Should mobs not spawn within the viewing range of players?
		/// <para> 0 is disabled, otherwise it is the number of retries before giving up</para>
		/// <para> and spawning the mob within player-view anyway, unless the max (100) is used,</para>
		/// <para> in which case the mob will not be spawned, and it'll be retried again in</para>
		/// <para> 5 seconds.</para>
		/// <para> NOTE: This has no effect on mobs that always spawn on the very same cell</para>
		/// <para> (like ant eggs) except if you set it to the max.</para>
		/// </summary>
		public static bool NoSpawnOnPlayer = false;
		/// <summary>
		///  Should spawn coordinates in the mob-spawn files be ignored? (Note 1)
		/// <para> If set to yes, all monsters will have a random respawn spot across the whole</para>
		/// <para> map regardless of what the mob-spawn file says.</para>
		/// </summary>
		public static bool ForceRandomSpawn = false;
		/// <summary>
		///  Do summon slaves inherit the passive/aggressive traits of their master?
		/// <para> 0: No, retain original mode.</para>
		/// <para> 1: Slaves are always aggressive.</para>
		/// <para> 2: Slaves are always passive.</para>
		/// <para> 3: Same as master's aggressive/passive state.</para>
		/// </summary>
		public static int SlavesInheritMode = 2;
		/// <summary>
		///  Do summon slaves have the same walking speed as their master?
		/// <para> NOTE: The default is 3 for official servers.</para>
		/// <para> 0: Never.</para>
		/// <para> 1: If the master can walk</para>
		/// <para> 2: If the master can't walk (even motionless mobs have a speed</para>
		/// <para>    entry in their mob_db)</para>
		/// <para> 3: Always</para>
		/// </summary>
		public static int SlavesInheritSpeed = 3;
		/// <summary>
		///  Will summoned monsters (alchemists, or @summon'ed monsters) attack cause a
		/// <para> chance of triggering the master's autospell cards? (Note 1)</para>
		/// </summary>
		public static bool SummonsTriggerAutospells = true;
		/// <summary>
		///  When a mob is attacked by another monster, will the mob retaliate against the master of said mob instead of the mob itself?
		/// <para> NOTE: Summoned mobs are both those acquired via @summon and summoned by Alchemists</para>
		/// </summary>
		public static bool RetaliateToMaster = true;
		/// <summary>
		///  Whether mobs should change target temporarily when a skill triggers a counter mob skill (Note 1)
		/// <para> eg: Mob attacks player B, and player A casts a skill C. If set to yes and the</para>
		/// <para> mob has a skill that is triggered by skill C, then A will be the target of</para>
		/// <para> the skill, otherwise B will be targetted by the reaction skill.</para>
		/// </summary>
		public static bool MobChangetargetByskill = false;
		/// <summary>
		///  If monster's class is changed will it fully recover HP? (Note 1)
		/// </summary>
		public static bool MonsterClassChangeFullRecover = true;
		/// <summary>
		///  Display some mob info next to their name? (add as needed)
		/// <para> (does not works on guardian or emperium)</para>
		/// <para> 1: Display mob HP (Hp/MaxHp format)</para>
		/// <para> 2: Display mob HP (Percent of full life format)</para>
		/// <para> 4: Display mob's level</para>
		/// </summary>
		public static short ShowMobInfo = 7;
		/// <summary>
		///  Zeny from mobs
		/// </summary>
		public static bool ZenyFromMobs = false;
		/// <summary>
		///  Monsters level up (monster will level up each time a player is killed and they will grow stronger)
		/// <para> Exp rate is calculated ((monster level-original monster level)*(exp*(mobs_level_up_exp rate/100)))</para>
		/// <para> NOTE: Does not apply to WoE Guardians.</para>
		/// </summary>
		public static bool MobsLevelUp = false;
		public static bool MobsLevelUpExpRate = true;
		/// <summary>
		///  Dynamic Mobs Options
		/// <para> Use dynamic mobs? (recommended for small-medium sized servers)</para>
		/// </summary>
		public static bool DynamicMobs = true;
		/// <summary>
		///  Remove Mobs even if they are hurt
		/// </summary>
		public static bool MobRemoveDamaged = true;
		/// <summary>
		///  Delay before removing mobs from empty maps (default 5 min = 300 secs)
		/// </summary>
		public static int MobRemoveDelay = 300000;
		/// <summary>
		///  Can add a delay before sending monster death packet (time is in milliseconds and default 0 is off)
		/// <para> Increasing this can fix the problem with monster sprites still appearing after it died.  Recommended value: 10.</para>
		/// </summary>
		public static bool MobClearDelay = false;
		/// <summary>
		///  Defines on who the mob npc_event gets executed when a mob is killed.
		/// <para> Type 1: On the player that killed the mob (if killed by a non-player, resorts to type 0)</para>
		/// <para> Type 0: On the player that did the most damage to the mob.</para>
		/// <para> NOTE: This affects who gains the Castle when the Emperium is broken.</para>
		/// </summary>
		public static bool MobNpcEventType = true;
		/// <summary>
		///  Time in milliseconds to actitave protection against Kill Steal
		/// <para> Set to 0 to disable it.</para>
		/// <para> If this is activated and a player is using @noks, damage from others players (KS) not in the party</para>
		/// <para> will be reduced to 0.</para>
		/// </summary>
		public static bool Ksprotection = false;
		/// <summary>
		///  Should MVP slaves retain their target when summoned back to their master?
		/// </summary>
		public static bool MobSlaveKeepTarget = true;


		/*******************************************************
		 * party.conf
		 * Party
		 ******************************************************/
		/// <summary>
		///  If someone steals (gank/steal skills), show name in party? (Note 1)
		/// </summary>
		public static bool ShowStealInSameParty = false;
		/// <summary>
		///  Interval before updating the party-member map mini-dots (milliseconds)
		/// </summary>
		public static int PartyUpdateInterval = 1000;
		/// <summary>
		///  Method used to update party-mate hp-bars:
		/// <para> 0: Aegis - bar is updated every time HP changes (bandwidth intensive)</para>
		/// <para> 1: eAthena - bar is updated with the party map dots (up to 1 second delay)</para>
		/// </summary>
		public static bool PartyHpMode = false;
		/// <summary>
		///  When 'Party Share' item sharing is enabled in a party,
		/// <para> announce in the party which party-member received the item and what's he received? (Note 1)</para>
		/// </summary>
		public static bool ShowPartySharePicker = true;
		/// <summary>
		///  What types of items are going to be announced when 'show_party_share_picker' is active?
		/// <para> 1:   IT_HEALING,  2:   IT_UNKNOWN,  4:    IT_USABLE, 8:    IT_ETC,</para>
		/// <para> 16:  IT_WEAPON,   32:  IT_ARMOR,    64:   IT_CARD,   128:  IT_PETEGG,</para>
		/// <para> 256: IT_PETARMOR, 512: IT_UNKNOWN2, 1024: IT_AMMO,   2048: IT_DELAYCONSUME</para>
		/// <para> 262144: IT_CASH</para>
		/// </summary>
		public static int ShowPickerItemType = 112;
		/// <summary>
		///  Method of distribution when item party share is enabled in a party:
		/// <para></para>
		/// <para> 0: Normal (item goes to a random party member)</para>
		/// <para> 1: Item Share is disabled for non-mob drops (player/pet drops)</para>
		/// <para> 2: Round Robin (items are distributed evenly and in order among members)</para>
		/// <para> 3: 1+2</para>
		/// </summary>
		public static bool PartyItemShareType = false;
		/// <summary>
		///  Is exp/item sharing disabled for idle members in the party?
		/// <para> Set to no, or the amount of seconds (NOT milliseconds) that need to pass before considering</para>
		/// <para> a character idle.</para>
		/// <para> Characters in a chat/vending are always considered idle.</para>
		/// <para> A character's idle status is reset upon item use/skill use/attack (auto attack counts too)/movement.</para>
		/// </summary>
		public static bool IdleNoShare = false;
		/// <summary>
		///  Give additional experience bonus per party-member involved on even-share parties?
		/// <para> (eg: If set to 10, a even-share party of 5 people will receive +40% exp)</para>
		/// </summary>
		public static bool PartyEvenShareBonus = false;
		/// <summary>
		///  Display party name regardless if player is in a guild.
		/// <para> Official servers do not display party name unless the user is in a guild. (Note 1)</para>
		/// </summary>
		public static bool DisplayPartyName = false;


		/*******************************************************
		 * pet.conf
		 * Pet
		 ******************************************************/
		/// <summary>
		///  Rate for catching pets (Note 2)
		/// </summary>
		public static int PetCatchRate = 100;
		/// <summary>
		///  Can you name a pet more then once? (Note 1)
		/// </summary>
		public static bool PetRename = false;
		/// <summary>
		///  The rate a pet will get friendly by feeding it. (Note 2)
		/// </summary>
		public static int PetFriendlyRate = 100;
		/// <summary>
		///  The rate at which a pet will become hungry. (Note 2)
		/// </summary>
		public static int PetHungryDelayRate = 100;
		/// <summary>
		///  If your pet is hungry by how much will the friendlyness decrease by. (Default is 5)
		/// <para> Note: The friendlyness is 0-1000 total, at 0 the pet runs away.</para>
		/// </summary>
		public static int PetHungryFriendlyDecrease = 5;
		/// <summary>
		///  Does the pet need its equipment before it does its skill? (Note 1)
		/// </summary>
		public static bool PetEquipRequired = true;
		/// <summary>
		///  When the master attacks a monster, whether or not the pet will also attack. (Note 1)
		/// </summary>
		public static bool PetAttackSupport = false;
		/// <summary>
		///  When the master receives damage from the monster, whether or not the pet attacks back. (Note 1)
		/// </summary>
		public static bool PetDamageSupport = false;
		/// <summary>
		///  Minimum intimacy necessary for a pet to support their master. Default is 900
		/// <para> (intimacy goes from 0 to 1000). At this minimum, support rate is 50% of pet's normal value.</para>
		/// <para> At max (1000) support rate is 150%.</para>
		/// </summary>
		public static int PetSupportMinFriendly = 900;
		/// <summary>
		///  Same as above, but this is to use the pet_script field with official pet abilities.
		/// </summary>
		public static int PetEquipMinFriendly = 900;
		/// <summary>
		///  Whether or not the pet's will use skills. (Note 1)
		/// <para> Note: Offensive pet skills need at least pet_attack_support or</para>
		/// <para> pet_damage_support to work (they trigger while the pet is attacking).</para>
		/// </summary>
		public static bool PetStatusSupport = false;
		/// <summary>
		///  Rate at which a pet will support it's owner in battle. (Note 2)
		/// <para> Affects pet_attack_support & pet_damage_support.</para>
		/// </summary>
		public static int PetSupportRate = 100;
		/// <summary>
		///  Does the pets owner receive exp from the pets damage?
		/// </summary>
		public static bool PetAttackExpToMaster = false;
		/// <summary>
		///  The rate exp. is gained from the pet attacking monsters
		/// </summary>
		public static int PetAttackExpRate = 100;
		/// <summary>
		///  Pet leveling system. Use 0 to disable (default).
		/// <para> When enabled, a pet's level is a fixed % of the master's. (Note 2)</para>
		/// <para> If 200%, pet has double level, if 50% pet has half your level, etc.</para>
		/// </summary>
		public static bool PetLvRate = false;
		/// <summary>
		///  When pet leveling is enabled, what is the max stats for pets?
		/// </summary>
		public static int PetMaxStats = 99;
		/// <summary>
		///  When pet leveling is enabled, these are the imposed caps on
		/// <para> min/max damage. Note that these only cap atk1 and atk2, if you</para>
		/// <para> enable pet_str, their max damage is then their base_atk + pet_max_atk2</para>
		/// </summary>
		public static int PetMaxAtk1 = 500;
		public static int PetMaxAtk2 = 1000;
		/// <summary>
		///  Are pets disabled during Guild Wars?
		/// <para> If set to yes, pets are automatically returned to egg when entering castles during WoE times</para>
		/// <para> and hatching is forbidden within as well.</para>
		/// </summary>
		public static bool PetDisableInGvg = false;


		/*******************************************************
		 * player.conf
		 * Player
		 ******************************************************/
		public static string StartMap = "prontera";
		public static int StartMapX = 150;
		public static int StartMapY = 150;
		public static int StartZeny = 1000000;
		/// <summary>
		///  Players' maximum HP rate? (Default is 100)
		/// </summary>
		public static int HpRate = 100;
		/// <summary>
		///  Players' maximum SP rate? (Default is 100)
		/// </summary>
		public static int SpRate = 100;
		/// <summary>
		///  Whether or not cards and attributes of the left hand are applied to the right hand attack (Note 1)
		/// <para> (It is 'yes' on official servers)</para>
		/// </summary>
		public static bool LeftCardfixToRight = true;
		/// <summary>
		///  The amount of HP a player will respawn with, 0 is default.
		/// <para> (Unit is in percentage of total HP, 100 is full heal of HP, 0 is respawn with 1HP total.)</para>
		/// </summary>
		public static bool RestartHpRate = false;
		/// <summary>
		///  The amount of SP a player will respawn with, 0 is default.
		/// <para> (Unit is in percentage of total SP, 100 is full heal of SP, 0 is respawn with 1SP total.)</para>
		/// </summary>
		public static bool RestartSpRate = false;
		/// <summary>
		///  Can a normal player by-pass the skill tree? (Note 1)
		/// </summary>
		public static bool PlayerSkillfree = false;
		/// <summary>
		///  When set to yes, forces skill points gained from 1st class to be put into 1st class
		/// <para> skills, and forces novice skill points to be put into the basic skill. (Note 1)</para>
		/// </summary>
		public static bool PlayerSkillupLimit = true;
		/// <summary>
		///  Quest skills can be learned? (Note 1)
		/// <para> Setting this to yes can open an exploit on your server!</para>
		/// </summary>
		public static bool QuestSkillLearn = false;
		/// <summary>
		///  When skills are reset, quest skills are reset as well? (Note 1)
		/// <para> Setting this to yes can open an exploit on your server!</para>
		/// <para> NOTE: If you have quest_skill_learn set to yes, quest skills are always reset.</para>
		/// </summary>
		public static bool QuestSkillReset = false;
		/// <summary>
		///  You must have basic skills to be able to sit, trade, form a party or create a chatroom? (Note 1)
		/// </summary>
		public static bool BasicSkillCheck = true;
		/// <summary>
		///  When teleporting, or spawning to a map, how long before a monster sees you if you don't move? (time is in milliseconds)
		/// <para> That is, when you go to a map and don't move, how long before the monsters will notice you.</para>
		/// <para> If you attack a monster, it will attack you back regaurdless of this setting. (I think)</para>
		/// </summary>
		public static int PlayerInvincibleTime = 5000;
		/// <summary>
		///  The time interval for HP to restore naturally. (in milliseconds)
		/// </summary>
		public static int NaturalHealhpInterval = 6000;
		/// <summary>
		///  The time interval for SP to restore naturally. (in milliseconds)
		/// </summary>
		public static int NaturalHealspInterval = 8000;
		/// <summary>
		///  Automatic healing skill's time interval. (in milliseconds)
		/// </summary>
		public static int NaturalHealSkillInterval = 10000;
		/// <summary>
		///  The maximum weight for a character to carry when the character stops healing naturally. (in %)
		/// </summary>
		public static int NaturalHealWeightRate = 50;
		/// <summary>
		///  Maximum atk speed. (Default 190, Highest allowed 199)
		/// </summary>
		public static int MaxAspd = 190;
		/// <summary>
		///  Maximum walk speed rate (200 would be capped to twice the normal speed)
		/// </summary>
		public static int MaxWalkSpeed = 300;
		/// <summary>
		///  Maximum HP. (Default is 1000000)
		/// </summary>
		public static int MaxHp = 1000000;
		/// <summary>
		///  Maximum SP. (Default is 1000000)
		/// </summary>
		public static int MaxSp = 1000000;
		/// <summary>
		///  Max limit of char stats. (agi, str, etc.)
		/// </summary>
		public static int MaxParameter = 99;
		/// <summary>
		///  Same as max_parameter, but for baby classes.
		/// </summary>
		public static int MaxBabyParameter = 80;
		/// <summary>
		///  Max armor def/mdef
		/// <para> NOTE: does not affects skills and status effects like Mental Strength</para>
		/// <para> If weapon_defense_type is non-zero, it won't apply to max def.</para>
		/// <para> If magic_defense_type is non-zero, it won't apply to max mdef.</para>
		/// </summary>
		public static int MaxDef = 99;
		/// <summary>
		///  Def to Def2 conversion bonus. If the armor def/mdef exceeds max_def,
		/// <para> the remaining is converted to vit def/int mdef using this multiplier</para>
		/// <para> (eg: if set to 10, every armor point above the max becomes 10 vit defense points)</para>
		/// </summary>
		public static bool OverDefBonus = false;
		/// <summary>
		///  Max weight carts can hold.
		/// </summary>
		public static int MaxCartWeight = 8000;
		/// <summary>
		///  Prevent logout of players after being hit for how long (in ms, 0 disables)?
		/// </summary>
		public static int PreventLogout = 10000;
		/// <summary>
		///  Display the drained hp/sp values from normal attacks? (Ie: Hunter Fly card)
		/// </summary>
		public static bool ShowHpSpDrain = false;
		/// <summary>
		///  Display the gained hp/sp values from killing mobs? (Ie: Sky Deleter Card)
		/// </summary>
		public static bool ShowHpSpGain = true;
		/// <summary>
		///  If set, when A accepts B as a friend, B will also be added to A's friend
		/// <para> list, otherwise, only A appears in B's friend list.</para>
		/// <para> NOTE: this setting only enables friend auto-adding; auto-deletion does not work yet</para>
		/// </summary>
		public static bool FriendAutoAdd = true;
		/// <summary>
		///  Are simultaneous trade/party/guild invite requests automatically rejected?
		/// </summary>
		public static bool InviteRequestCheck = true;
		/// <summary>
		///  Players' will drop a 'Skull' when killed?
		/// <para> 0 = Disabled</para>
		/// <para> 1 = Dropped only in PvP maps</para>
		/// <para> 2 = Dropped in all situations</para>
		/// </summary>
		public static bool BoneDrop = false;
		/// <summary>
		///  Do mounted (on Peco) characters increase their size
		/// <para> 0 = no</para>
		/// <para> 1 = only Normal Classes on Peco have Big Size</para>
		/// <para> 2 = only Baby Classes on Peco have Medium Size</para>
		/// <para> 3 = both Normal Classes on Peco have Big Size</para>
		/// <para>	and Baby Classes on Peco have Medium Size</para>
		/// </summary>
		public static int CharacterSize = 0;
		/// <summary>
		///  Idle characters can receive autoloot?
		/// <para> Set to the time in seconds where an idle character will stop receiving</para>
		/// <para> items from Autoloot (0: disabled).</para>
		/// </summary>
		public static bool IdleNoAutoloot = false;


		/*******************************************************
		 * skill.conf
		 * Skill
		 ******************************************************/
		/// <summary>
		///  The rate of time it takes to cast a spell (Note 2, 0 = No casting time)
		/// </summary>
		public static int CastingRate = 100;
		/// <summary>
		///  Delay time after casting (Note 2)
		/// </summary>
		public static int DelayRate = 100;
		/// <summary>
		///  Does the delay time depend on the caster's DEX and/or AGI? (Note 1)
		/// <para> Note: On Official servers, neither Dex nor Agi affect delay time</para>
		/// </summary>
		public static bool DelayDependonDex = false;
		public static bool DelayDependonAgi = false;
		/// <summary>
		///  Minimum allowed delay for ANY skills after casting (in miliseconds) (Note 1)
		/// <para> Note: Setting this to anything above 0 can stop speedhacks.</para>
		/// </summary>
		public static int MinSkillDelayLimit = 100;
		/// <summary>
		///  This delay is the min 'can't walk delay' of all skills.
		/// <para> NOTE: Do not set this too low, if a character starts moving too soon after</para>
		/// <para> doing a skill, the client will not update this, and the player/mob will</para>
		/// <para> appear to "teleport" afterwards.</para>
		/// </summary>
		public static int DefaultWalkDelay = 300;
		/// <summary>
		/// Completely disable skill delay of the following types (Note 3)
		/// <para>NOTE: By default mobs don't have the skill delay as specified in the skill</para>
		/// <para>  database, but follow their own 'reuse' skill delay which is specified on</para>
		/// <para>  the mob skill db. When set, the delay for all skills become</para>
		/// <para>  min_skill_delay_limit.</para>
		/// </summary>
		public static int NoSkillDelay = 2;
		/// <summary>
		///  At what dex does the cast time become zero (instacast)?
		/// </summary>
		public static int CastrateDexScale = 150;
		/// <summary>
		///  Will normal attacks be able to ignore the delay after skills? (Note 1)
		/// </summary>
		public static bool SkillDelayAttackEnable = true;
		/// <summary>
		///  Range added to skills after their cast time finishes.
		/// <para> Decides how far away the target can walk away after the skill began casting before the skill fails.</para>
		/// <para> 0 disables this range checking (default)</para>
		/// </summary>
		public static bool SkillAddRange = false;
		/// <summary>
		///  If the target moves out of range while casting, do we take the items and SP for the skill anyway? (Note 1)
		/// </summary>
		public static bool SkillOutRangeConsume = false;
		/// <summary>
		///  Does the distance between caster and target define if the skill is a ranged skill? (Note 3)
		/// <para> If set, when the distance between caster and target is greater than 3 the skill is considered long-range, otherwise it's a melee range.</para>
		/// <para> If not set, then the range is determined by the skill's range (if it is above 5, the skill is ranged).</para>
		/// <para> Default 14 (mobs + pets + homun)</para>
		/// </summary>
		public static int SkillrangeByDistance = 14;
		/// <summary>
		///  Should the equipped weapon's range override the skill's range defined in the skill_db for most weapon-based skills? (Note 3)
		/// <para> NOTE: Skills affected by this option are those whose range in the skill_db are negative. Note that unless monster_ai&0x400 is</para>
		/// <para> set, the range of all skills is 9 for monsters.</para>
		/// </summary>
		public static int SkillrangeFromWeapon = 30;
		/// <summary>
		///  Should a check on the caster's status be performed in all skill attacks?
		/// <para> When set to yes, meteors, storm gust and any other ground skills will have</para>
		/// <para> no effect while the caster is unable to fight (eg: stunned).</para>
		/// </summary>
		public static bool SkillCasterCheck = true;
		/// <summary>
		///  Should ground placed skills be removed as soon as the caster dies? (Note 3)
		/// </summary>
		public static bool ClearSkillsOnDeath = false;
		/// <summary>
		///  Should ground placed skills be removed when the caster changes maps? (Note 3)
		/// </summary>
		public static int ClearSkillsOnWarp = 15;
		/// <summary>
		/// Setting this to YES will override the target mode of ground-based skills with the flag 0x01 to "No Enemies"
		/// <para>The two skills affected by default are Pneuma and Safety Wall (if set to yes, those two skills will not protect everyone, but only allies)</para>
		/// <para>See db/skill_unit_db.txt for more info.</para>
		/// </summary>
		public static bool DefunitNotEnemy = false;
		/// <summary>
		///  Do skills do at least 'hits' damage when they don't miss/are blocked?
		/// <para>(for example, will firebolts always do "number of bolts" damage versus plants?)</para>
		/// <para>Values (add as appropiate): 1 for weapon-based attacks, 2 for magic attacks, 4 for misc attacks.</para>
		/// </summary>
		public static int SkillMinDamage = 6;
		/// <summary>
		///  The delay rate of monk's combo (Note 2)
		/// </summary>
		public static int ComboDelayRate = 100;
		/// <summary>
		///  Use alternate auto Counter Attack Skill Type? (Note 3)
		/// <para> For those characters on which it is set, 100% Critical,</para>
		/// <para> Otherwise it disregard DEF and HIT+20, CRI*2</para>
		/// </summary>
		public static int AutoCounterType = 15;
		/// <summary>
		///  Can ground skills be placed on top of each other? (Note 3)
		/// <para> By default, skills with UF_NOREITERATION set cannot be stacked on top of</para>
		/// <para> other skills, this setting will override that. (skill_unit_db)</para>
		/// </summary>
		public static bool SkillReiteration = false;
		/// <summary>
		///  Can ground skills NOT be placed underneath/near players/monsters? (Note 3)
		/// <para> If set, only skills with UF_NOFOOTSET set will be affected (skill_unit_db)</para>
		/// </summary>
		public static bool SkillNofootset = true;
		/// <summary>
		///  Should traps (hunter traps + quagmire) change their target to "all" inside gvg/pvp grounds? (Note 3)
		/// <para> Default on official servers: yes for player-traps</para>
		/// </summary>
		public static bool GvgTrapsTargetAll = true;
		/// <summary>
		///  Some traps settings (add as necessary):
		/// <para> 1: Traps are invisible to those who come into view of it. When unset, all traps are visible at all times.</para>
		/// <para>    (Invisible traps can be revealed through Hunter's Detecting skill)</para>
		/// </summary>
		public static bool TrapsSetting = false;
		/// <summary>
		///  Restrictions applied to the Alchemist's Summon Flora skill (add as necessary)
		/// <para> 1: Enable players to damage the floras outside of versus grounds.</para>
		/// <para> 2: Disable having different types out at the same time</para>
		/// <para>    (eg: forbid summoning anything except hydras when there's already</para>
		/// <para>     one hydra out)</para>
		/// </summary>
		public static int SummonFloraSetting = 3;
		/// <summary>
		///  Whether placed down skills will check walls (Note 1)
		/// <para> (Makes it so that Storm Gust/Lord of Vermillion/etc when casted next to a wall, won't hit on the other side)</para>
		/// </summary>
		public static bool SkillWallCheck = true;
		/// <summary>
		///  When cloaking, Whether the wall is checked or not. (Note 1)
		/// <para> Note: When the skill does not checks for walls, you will always be considered</para>
		/// <para>  as if you had a wall-next to you (you always get the wall-based speed).</para>
		/// <para>  Add the settings as required, being hit always uncloaks you.</para>
		/// <para></para>
		/// <para> 0 = doesn't check for walls</para>
		/// <para> 1 = Check for walls</para>
		/// <para> 2 = Cloaking is not cancelled when attacking.</para>
		/// <para> 4 = Cloaking is not cancelled when using skills</para>
		/// </summary>
		public static bool PlayerCloakCheckType = true;
		public static int MonsterCloakCheckType = 4;
		/// <summary>
		///  Can't place unlimited land skills at the same time (Note 3)
		/// </summary>
		public static bool LandSkillLimit = true;
		/// <summary>
		/// Determines which kind of skill-failed messages should be sent:
		/// <para> 1 - Disable all skill-failed messages.</para>
		/// <para> 2 - Disable skill-failed messages due to can-act delays.</para>
		/// <para> 4 - Disable failed message from Snatcher</para>
		/// <para> 8 - Disable failed message from Envenom</para>
		/// </summary>
		public static int DisplaySkillFail = 2;
		/// <summary>
		///  Can a player in chat room (in-game), be warped by a warp portal? (Note 1)
		/// </summary>
		public static bool ChatWarpportal = false;
		/// <summary>
		///  What should the wizard's "Sense" skill display on the defense fields?
		/// <para> 0: Do not show defense</para>
		/// <para> 1: Base defense</para>
		/// <para> 2: Vit/Int defense</para>
		/// <para> 3: Both (the addition of both) [default]</para>
		/// </summary>
		public static int SenseType = 3;
		/// <summary>
		///  Which finger offensive style will be used?
		/// <para> 0 = Aegis style (single multi-hit attack)</para>
		/// <para> 1 = Athena style (multiple consecutive attacks)</para>
		/// </summary>
		public static bool FingerOffensiveType = false;
		/// <summary>
		///  Grandcross Settings (Dont mess with these)
		/// <para> If set to no, hit interval is increased based on the amount of mobs standing on the same cell</para>
		/// <para> (means that when there's stacked mobs in the same cell, they won't receive all hits)</para>
		/// </summary>
		public static bool GxAllhit = false;
		/// <summary>
		///  Grandcross display type (Default 1)
		/// <para> 0: Yellow character</para>
		/// <para> 1: White character</para>
		/// </summary>
		public static bool GxDisptype = true;
		/// <summary>
		///  Max Level Difference for Devotion
		/// </summary>
		public static int DevotionLevelDifference = 10;
		/// <summary>
		///  If no than you can use the ensemble skills alone. (Note 1)
		/// </summary>
		public static bool PlayerSkillPartnerCheck = true;
		/// <summary>
		///  Remove trap type
		/// <para> 0 = Aegis system : Returns 1 'Trap' item</para>
		/// <para> 1 = Athena system : Returns all items used to deploy the trap</para>
		/// </summary>
		public static bool SkillRemovetrapType = false;
		/// <summary>
		///  Does using bow to do a backstab give a 50% damage penalty? (Note 1)
		/// </summary>
		public static bool BackstabBowPenalty = true;
		/// <summary>
		///  How many times you could try to steal from a mob.
		/// <para> Note: It helps to avoid stealing exploit on monsters with few rare items</para>
		/// <para> Use 0 to disable (max allowed value is 255)</para>
		/// </summary>
		public static bool SkillStealMaxTries = false;
		/// <summary>
		///  Can Rogues plagiarize advanced job skills
		/// <para> 0 = no restriction</para>
		/// <para> 1 = only stalker may plagiarize advanced skills</para>
		/// <para> 2 = advanced skills cannot be plagiarized by anyone</para>
		/// <para> Official servers setting: 2</para>
		/// </summary>
		public static int CopyskillRestrict = 2;
		/// <summary>
		///  Does Berserk/Frenzy cancel other self-buffs when used?
		/// </summary>
		public static bool BerserkCancelsBuffs = false;
		/// <summary>
		///  Level and Strength of "MVP heal". When someone casts a heal of this level or
		/// <para> above, the heal formula is bypassed and this value is used instead.</para>
		/// </summary>
		public static int MaxHeal = 9999;
		public static int MaxHealLv = 11;
		/// <summary>
		///  Emergency Recall Guild Skill setting (add as appropiate).
		/// <para> Note that for the skill to be usable at all,</para>
		/// <para> you need at least one of 1/2 and 4/8</para>
		/// <para> 1: Skill is usable outside of woe.</para>
		/// <para> 2: Skill is usable during woe.</para>
		/// <para> 4: Skill is usable outside of GvG grounds</para>
		/// <para> 8: Skill is usable on GvG grounds</para>
		/// <para>16: Disable skill from "nowarpto" maps</para>
		/// <para>    (it will work on GVG castles even if they are set to nowarpto, though)</para>
		/// </summary>
		public static int EmergencyCall = 11;
		/// <summary>
		///  Guild Aura Skills setting (add as appropiate).
		/// <para> (This affects GD_LEADERSHIP, GD_GLORYWOUNDS, GD_SOULCOLD and GD_HAWKEYES)</para>
		/// <para> Note that for the skill to be usable at all,</para>
		/// <para> you need at least one of 1/2 and 4/8</para>
		/// <para> 1: Skill works outside of woe.</para>
		/// <para> 2: Skill works during woe.</para>
		/// <para> 4: Skill works outside of GvG grounds</para>
		/// <para> 8: Skill works on GvG grounds</para>
		/// <para>16: Disable skill from affecting Guild Master</para>
		/// </summary>
		public static int GuildAura = 31;
		/// <summary>
		///  Max Possible Level of Monster skills
		/// <para> Note: If your MVPs are too tough, reduce it to 10.</para>
		/// </summary>
		public static int MobMaxSkilllvl = 100;
		/// <summary>
		///  Allows players to skip menu when casting Teleport level 1
		/// <para> Menu contains two options. "Random" and "Cancel"</para>
		/// </summary>
		public static bool SkipTeleportLv1Menu = false;
		/// <summary>
		///  Allow use of SG skills without proper day (Sun/Moon/Star) ?
		/// </summary>
		public static bool AllowSkillWithoutDay = false;
		/// <summary>
		///  Allow use of ES-type magic on players?
		/// </summary>
		public static bool AllowEsMagicPlayer = false;
		/// <summary>
		///  Miracle of the Sun, Moon and Stars skill ratio (100% = 10000)
		/// </summary>
		public static int SgMiracleSkillRatio = 2;
		/// <summary>
		///  Miracle of the Sun, Moon and Stars skill duration in milliseconds
		/// </summary>
		public static int SgMiracleSkillDuration = 3600000;
		/// <summary>
		///  Angel of the Sun, Moon and Stars skill ratio (100% = 10000)
		/// </summary>
		public static int SgAngelSkillRatio = 10;
		/// <summary>
		///  Skills that bHealPower has effect on
		/// <para> 1: Heal, 2: Sanctuary, 4: Potion Pitcher, 8: Slim Pitcher, 16: Apple of Idun</para>
		/// </summary>
		public static int SkillAddHealRate = 7;
		/// <summary>
		///  Whether the damage of EarthQuake with a single target on screen is able to be reflected.
		/// <para> Note: On offcial server, EQ is reflectable when there is only one target on the screen,</para>
		/// <para>	 which might be an exploit to hunt the MVPs.</para>
		/// </summary>
		public static bool EqSingleTargetReflectable = true;
		/// <summary>
		///  On official server, you will receive damage from Reflection and some Tarot Card even in invincible status.
		/// <para> When this setting is enabled, it allows you to immune to all kinds of damage, including those stated previous.</para>
		/// <para> (The number will show but no actual damage will be done)</para>
		/// </summary>
		public static bool InvincibleNodamage = false;


		/*******************************************************
		 * status.conf
		 * Status
		 ******************************************************/
		/// <summary>
		///  Should skill casting be cancelled when inflicted by curse/stun/sleep/etc (includes silence) (Note 3)?
		/// </summary>
		public static bool StatusCastCancel = false;
		/// <summary>
		///  Will certain skill status-changes be removed on logout?
		/// <para> This mimics official servers, where Extremity Fist's no SP regen,</para>
		/// <para> Strip Equipment, and some other buffs are removed when you logout. Setting is:</para>
		/// <para> 0 = remove nothing.</para>
		/// <para> 1 = remove negative buffs (stripping, EF)</para>
		/// <para> 2 = remove positive buffs (maximize power, steel body...)</para>
		/// <para> 3 = remove both negative and positive buffs.</para>
		/// </summary>
		public static int DebuffOnLogout = 3;
		/// <summary>
		///  Adjustment for the natural rate of resistance from status changes.
		/// <para> If 50, status defense is halved, and you need twice as much stats to block</para>
		/// <para> them (eg: 200 vit to completely block stun)</para>
		/// </summary>
		public static int PcStatusDefRate = 100;
		public static int MobStatusDefRate = 100;
		/// <summary>
		///  Required luk to gain inmunity to status changes.
		/// <para> Luk increases resistance by closing the gap between natural resist and max</para>
		/// <para> linearly. This setting indicates required luk to gain complete immunity.</para>
		/// <para> Eg: 40 vit -> 40% resist. 150 luk -> +50% of the missing gap.</para>
		/// <para>     So 40% + (50% of 60%) = 70%</para>
		/// </summary>
		public static int PcLukStatusDef = 300;
		public static int MobLukStatusDef = 300;
		/// <summary>
		///  Maximum resistance to status changes. (100 = 100%)
		/// <para> NOTE: Cards and equipment can go over this limit, so it only applies to natural resist.</para>
		/// </summary>
		public static int PcMaxStatusDef = 100;
		public static int MobMaxStatusDef = 100;

	}

}
