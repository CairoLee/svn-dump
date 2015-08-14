package 
{
    import BuffSystem.*;
    import GO.*;
    import GOSets.*;
    import Interface.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import mx.events.*;
    import nLib.*;

    public class global extends Object implements IEventDispatcher
    {
        private var _bindingEventDispatcher:EventDispatcher;
        public static var CHEAT_KEYS:Boolean = true;
        public static const map_BuffName_BuffDefinition:Object = new Object();
        public static var latestChangesIdentifier:String;
        public static var screenWidthHalf:int;
        public static var gameSettingsVersionNr:int;
        public static var tradeOfferDuration:int;
        public static var repairRate:int = 10;
        public static const streetGridXFloat:Number = 117;
        public static var buffingBlockedUntil:int = 0;
        public static var playerInitialLevel:int;
        public static const buildingGroup:cGOGroup = new cGOGroup();
        public static var visibleResources_vector:Vector.<String> = new Vector.<String>;
        public static var returnRate:int;
        public static var tipOfTheDayCount:int;
        public static var autoLoadLevel_vector:Vector.<String> = null;
        public static var buildingDefaultParameterXP:int = 0;
        public static var buildingInfoIconDelay:int = 0;
        public static const settlerGroup:cGOGroup = new cGOGroup();
        public static var activateDebugQuestGui:Boolean = false;
        public static const streetGroup:cGOGroup = new cGOGroup();
        public static var mailLifetimes_vector:Vector.<int>;
        public static const streetGridYHalfFloat:Number = 36;
        public static var defaultBuildInstantCosts:int = 5;
        public static var zoomSpeed:int = 20;
        public static var GOListScale:int = 0;
        public static const goSetList_vector:Vector.<cGOSetList> = new Vector.<cGOSetList>;
        public static var questSettingsFilename:String = "quest_settings.xml";
        public static var legalTerms:String = "";
        public static var guildJoinCooldown:int;
        public static var guildBannerCount:int;
        public static var buildingDefaultParameterDoNotCountList_dictionary:cStringIntDictionary = new cStringIntDictionary();
        public static var shopSettingsRootXML:cXML = new cXML();
        public static var minZoom:int = 100;
        public static const streetGridXHalf:int = 58;
        public static var gameSettingsFilename:String = "game_settings.xml";
        public static var buildingDefaultFogRemoveList_vector:Vector.<cPosInt> = new Vector.<cPosInt>;
        public static const cityLevels_vector:Vector.<int> = new Vector.<int>;
        public static var playerResources_string:String;
        public static var hiddenBanditCamps_dictionary:cStringIntDictionary = new cStringIntDictionary();
        public static const effectGroup:cGOGroup = new cGOGroup();
        public static var defaultUpgradeInstantBonusPercentage:int = 5;
        public static var guildUpgradeLevels:Object = new Object();
        public static var gfxSettingsRootXML:cXML = new cXML();
        public static var scrollSpeed:int = 25;
        public static const streetGridXHalfFloat:Number = 58;
        public static var defaultMaximumBuildingCount:int = 0;
        public static const landscapeGroup:cGOGroup = new cGOGroup();
        public static var screenHeightHalf:int;
        private static var _staticBindingEventDispatcher:EventDispatcher = new EventDispatcher();
        public static var buildingDefaultParameterDestructionDuration:int = 1;
        public static const guiIconGroup:cGOGroup = new cGOGroup();
        public static const streetGridX:int = 117;
        public static const buffDefinitions_vector:Vector.<cBuffDefinition> = new Vector.<cBuffDefinition>;
        public static var defaultGosetBuffTwinkleName:String;
        public static const buildingUpgradeBonuses_vector:Vector.<cBuffDefinition> = new Vector.<cBuffDefinition>;
        public static var adventures_vector:Vector.<cAdventureDefinition>;
        public static var defaultMaximumBuildingsCountAll:int = 0;
        public static var watchAreas_vector:Vector.<Vector.<cWatchData>>;
        public static var loadingMessageCount:int;
        public static var maxTempSlotsAvailablePerPlayer:int = 5;
        public static var tempSlotDuration:Number = 60;
        public static var lootTableGroups_vector:Vector.<Vector.<cLootTable>>;
        public static var maxZoom:int = 2000;
        public static const streetGridYFloat:Number = 72;
        public static var combatRoundDuration:int = 0;
        public static const playerLevels_vector:Vector.<int> = new Vector.<int>;
        public static var screenHeight:int;
        public static var defaultZoom:int = 1000;
        public static var repairRoundDuration:int = 0;
        public static var adventureZoneLevels_vector:Vector.<String> = null;
        public static var adventureMaximumOwner:int;
        public static const resourceDefinitions_vector:Vector.<String> = new Vector.<String>;
        public static var screenWidth:int;
        private static var _3732ui:cGeneralInterface = null;
        public static var guildMaxSizeLimit:int;
        public static var maxAnimalsOnMap:int = 15;
        public static var guildHighscorePageSize:int;
        public static const goSet_vector:Vector.<cGOSet> = new Vector.<cGOSet>;
        public static var buildingDefaultParameterDoNotShowMissingResourceIcon_dictionary:cStringIntDictionary = new cStringIntDictionary();
        public static const streetGridY:int = 72;
        public static var adventureMaximumGuest:int;
        public static var defaultGosetFriendBuffTwinkleName:String;
        public static var gameSettingsRootXML:cXML = new cXML();
        public static var buildingDefaultParameterConstructionDuration:int = 1;
        public static const animalGroup:cGOGroup = new cGOGroup();
        public static var GAME_STATE:String = "Game";
        public static var repairCostFactor:int = 100;
        public static var initGlobalTimeScale:Number = 100;
        public static var resourceHardcurrencyValues:Object = new Object();
        public static const backgroundGroup:cGOGroup = new cGOGroup();
        public static var hideMouseOverDepositAmount_dictionary:cStringIntDictionary = new cStringIntDictionary();
        public static const streetGridYHalf:int = 36;
        public static var shopConfigFilename:String = "shopconfig.xml";

        public function global()
        {
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public static function set ui(param1:cGeneralInterface) : void
        {
            var _loc_3:IEventDispatcher = null;
            var _loc_2:* = global._3732ui;
            if (_loc_2 !== param1)
            {
                global._3732ui = param1;
                _loc_3 = global.staticEventDispatcher;
                if (_loc_3 != null)
                {
                    _loc_3.dispatchEvent(PropertyChangeEvent.createUpdateEvent(global, "ui", _loc_2, param1));
                }
            }
            return;
        }// end function

        public static function get staticEventDispatcher() : IEventDispatcher
        {
            return _staticBindingEventDispatcher;
        }// end function

        public static function get ui() : cGeneralInterface
        {
            return global._3732ui;
        }// end function

    }
}
