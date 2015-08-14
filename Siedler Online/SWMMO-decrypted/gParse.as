package 
{
    import AdventureSystem.*;
    import BuffSystem.*;
    import Enums.*;
    import GO.*;
    import GUI.GAME.*;
    import GUI.Loca.*;
    import LootTableSystem.*;
    import MilitarySystem.*;
    import ServerState.*;
    import ShopSystem.*;
    import Specialists.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import flash.net.*;
    import mx.core.*;
    import nLib.*;

    public class gParse extends Object
    {
        private static var mDispatcherGameSettings:cCustomDispatcher = new cCustomDispatcher();
        private static var mDispatcherGfxSettings:cCustomDispatcher = new cCustomDispatcher();
        private static var mDispatcherShopConfig:cCustomDispatcher = new cCustomDispatcher();
        private static var mDispatcherQuestSettings:cCustomDispatcher = new cCustomDispatcher();
        private static const SHOW_XML_INFO:Boolean = false;

        public function gParse()
        {
            return;
        }// end function

        public static function ConvertStringListToVector(param1:String, param2) : void
        {
            var _loc_4:String = null;
            param2.length = 0;
            var _loc_3:* = param1.split(",");
            for each (_loc_4 in _loc_3)
            {
                
                param2.push(_loc_4);
            }
            return;
        }// end function

        private static function DispatcherShopConfig(event:Event) : void
        {
            var root:cXML;
            var paymentXML:cXML;
            var trackingXML:cXML;
            var shopItemsXml:cXML;
            var shopItemGroupsXml_vector:Vector.<cXML>;
            var readShopItemIDs_vector:Vector.<int>;
            var shopItemGroupXml:cXML;
            var shopBannersXml:cXML;
            var shopBannersGroupsXml_vector:Vector.<cXML>;
            var banners:Vector.<dBanner>;
            var shopBannerGroupXml:cXML;
            var shopItemGroup:cShopItemGroup;
            var shopItemsXml_vector:Vector.<cXML>;
            var shopItemXml:cXML;
            var shopItem:cShopItem;
            var banner:dBanner;
            var event:* = event;
            var loader:* = event.target as URLLoader;
            Application.application.mMemoryMonitor.RegisterLoadedXML(loader.bytesTotal);
            try
            {
                root = new cXML();
                root.SetXMLString(String(loader.data));
                global.shopSettingsRootXML = root;
                paymentXML = root.MoveToSubNode("Payment");
                defines.PAYMENT_URL = paymentXML.GetAttributeString_string("url");
                trackingXML = root.MoveToSubNode("Tracking");
                defines.TRACKING_ID = trackingXML.GetAttributeString_string("analyticsId");
                shopItemsXml = root.MoveToSubNode("ShopItems");
                shopItemGroupsXml_vector = shopItemsXml.CreateChildrenArray();
                readShopItemIDs_vector = new Vector.<int>;
                var _loc_3:int = 0;
                var _loc_4:* = shopItemGroupsXml_vector;
                while (_loc_4 in _loc_3)
                {
                    
                    shopItemGroupXml = _loc_4[_loc_3];
                    shopItemGroup = cShopItemGroup.ReadShopItemGroupFromXml(shopItemGroupXml);
                    shopItemsXml_vector = shopItemGroupXml.CreateChildrenArray();
                    var _loc_5:int = 0;
                    var _loc_6:* = shopItemsXml_vector;
                    while (_loc_6 in _loc_5)
                    {
                        
                        shopItemXml = _loc_6[_loc_5];
                        shopItem = cShopItem.CreateShopItemFromXml(shopItemXml, shopItemGroup.GetId());
                        shopItemGroup.AddShopItem(shopItem);
                        gMisc.Assert(readShopItemIDs_vector.indexOf(shopItem.GetId()) == -1, "Shop item id " + shopItem.GetId() + " already exists!");
                        readShopItemIDs_vector.push(shopItem.GetId());
                    }
                }
                shopBannersXml = root.MoveToSubNode("Banners");
                shopBannersGroupsXml_vector = shopBannersXml.CreateChildrenArray();
                banners = new Vector.<dBanner>;
                var _loc_3:int = 0;
                var _loc_4:* = shopBannersGroupsXml_vector;
                while (_loc_4 in _loc_3)
                {
                    
                    shopBannerGroupXml = _loc_4[_loc_3];
                    banner = new dBanner();
                    banner.url = gGfxResource.GetGfxFolder_string() + shopBannerGroupXml.GetAttributeString_string("url");
                    banner.slot = shopBannerGroupXml.GetAttributeInt("slot");
                    banner.target = shopBannerGroupXml.GetAttributeString_string("target");
                    banner.linkType = shopBannerGroupXml.GetAttributeString_string("linkType");
                    banner.id = shopBannerGroupXml.GetAttributeInt("id");
                    banners.push(banner);
                }
                cShopWindow.SetBanners(banners);
            }
            catch (error:Error)
            {
                gErrorMessages.ShowErrorMessage("Error Parsing shop config: " + error);
            }
            mDispatcherShopConfig.doAction();
            return;
        }// end function

        private static function ioErrorHandler(event:IOErrorEvent) : void
        {
            gErrorMessages.ShowErrorMessage("ioErrorHandler: " + event);
            return;
        }// end function

        public static function ParseShopConfig(param1:String, param2:Function) : void
        {
            mDispatcherShopConfig.addEventListener(cCustomDispatcher.mAction_string, param2);
            var _loc_3:* = new cXML();
            _loc_3.LoadFile(param1, DispatcherShopConfig, false, definesMaster.LOAD_ENC);
            return;
        }// end function

        public static function ParseGameSettings(param1:String, param2:Function) : void
        {
            mDispatcherGameSettings.addEventListener(cCustomDispatcher.mAction_string, param2);
            var _loc_3:* = new cXML();
            _loc_3.LoadFile(param1, DispatcherGameSettings, false, definesMaster.LOAD_ENC);
            return;
        }// end function

        public static function ParseCosts(param1:cXML)
        {
            var _loc_4:cXML = null;
            var _loc_5:dResource = null;
            var _loc_2:* = new Vector.<dResource>;
            var _loc_3:* = param1.CreateChildrenArray();
            for each (_loc_4 in _loc_3)
            {
                
                _loc_5 = new dResource();
                _loc_5.name_string = _loc_4.GetAttributeString_string("name");
                _loc_5.amount = _loc_4.GetAttributeInt("count");
                _loc_2.push(_loc_5);
            }
            return _loc_2;
        }// end function

        private static function DispatcherGfxSettings(event:Event) : void
        {
            var t:Number;
            var root:cXML;
            var globals:cXML;
            var gameObjectsList:cXML;
            var defaultZoom:Number;
            var adventuresXml_vector:Vector.<cXML>;
            var adventureXml:cXML;
            var event:* = event;
            var loader:* = event.target as URLLoader;
            Application.application.mMemoryMonitor.RegisterLoadedXML(loader.bytesTotal);
            try
            {
                root = new cXML();
                root.SetXMLString(String(loader.data));
                global.gfxSettingsRootXML = root;
                globals = root.MoveToSubNode("Globals");
                gameObjectsList = root.MoveToSubNode("GameObjects");
                defaultZoom = gameObjectsList.GetAttributeFloatingPoint("DefaultZoom");
                global.defaultGosetBuffTwinkleName = gameObjectsList.GetAttributeString_string("gosetBuffTwinkleName");
                global.defaultGosetFriendBuffTwinkleName = gameObjectsList.GetAttributeString_string("gosetForeignBuffTwinkleName");
                global.backgroundGroup.defaultZoom = int(defaultZoom);
                global.streetGroup.defaultZoom = int(defaultZoom);
                global.buildingGroup.defaultZoom = int(defaultZoom);
                global.settlerGroup.defaultZoom = int(defaultZoom);
                global.animalGroup.defaultZoom = int(defaultZoom);
                global.guiIconGroup.SetGfxXML("GuiIcons");
                global.backgroundGroup.SetGfxXML("Backgrounds");
                global.streetGroup.SetGfxXML("Streets");
                global.buildingGroup.SetGfxXML("Buildings");
                global.landscapeGroup.SetGfxXML("Landscapes");
                global.settlerGroup.SetGfxXML("Settlers");
                global.animalGroup.SetGfxXML("Animals");
                global.effectGroup.SetGfxXML("Effects");
                adventuresXml_vector = root.MoveToSubNode("GameObjects").MoveToSubNode("Adventures").CreateChildrenArray();
                var _loc_3:int = 0;
                var _loc_4:* = adventuresXml_vector;
                while (_loc_4 in _loc_3)
                {
                    
                    adventureXml = _loc_4[_loc_3];
                    cAdventureDefinition.mTeaserImages[adventureXml.GetAttributeString_string("name")] = gGfxResource.GetGfxFolder_string() + "adventures/teasers/" + adventureXml.GetAttributeString_string("teaserImage");
                    cAdventureDefinition.mAvatarImages[adventureXml.GetAttributeString_string("name")] = gGfxResource.GetGfxFolder_string() + "adventures/avatars/" + adventureXml.GetAttributeString_string("avatarImage");
                }
            }
            catch (error:Error)
            {
                gErrorMessages.ShowErrorMessage("Error Parsing gfx_settings.xml: " + error);
            }
            mDispatcherGfxSettings.doAction();
            return;
        }// end function

        public static function ParseGfxSettings(param1:String, param2:Function) : void
        {
            mDispatcherGfxSettings.addEventListener(cCustomDispatcher.mAction_string, param2);
            var _loc_3:* = new cXML();
            _loc_3.LoadFile(param1, DispatcherGfxSettings, false, definesMaster.LOAD_ENC);
            return;
        }// end function

        public static function ConvertStringListToStringIntDictionary(param1:String, param2:cStringIntDictionary) : void
        {
            var _loc_4:String = null;
            var _loc_3:* = param1.split(",");
            param2.Reset();
            for each (_loc_4 in _loc_3)
            {
                
                param2.Put(_loc_4, 1);
            }
            return;
        }// end function

        private static function securityErrorHandler(event:SecurityErrorEvent) : void
        {
            gErrorMessages.ShowErrorMessage("securityErrorHandler: " + event);
            return;
        }// end function

        private static function DispatcherGameSettings(event:Event) : void
        {
            var root:cXML;
            var globals:cXML;
            var stringTemp:String;
            var intTemp:int;
            var doubleTemp:Number;
            var i:int;
            var playerLevels:cXML;
            var ar:Vector.<cXML>;
            var level:cXML;
            var watchAreas_vector:Vector.<Vector.<cWatchData>>;
            var watchAreasXml:cXML;
            var watchAreasXml_vector:Vector.<cXML>;
            var watchAreaXml:cXML;
            var mailLifetimes_vector:Vector.<int>;
            var mailLifetimesXml_vector:Vector.<cXML>;
            var mailLifetimeXml:cXML;
            var adventures_vector:Vector.<cAdventureDefinition>;
            var adventuresXml_vector:Vector.<cXML>;
            var adventureXml:cXML;
            var lootTableGroups_vector:Vector.<Vector.<cLootTable>>;
            var LootTablesXml:cXML;
            var lootTableGroupsXml_vector:Vector.<cXML>;
            var lootTableGroupXml:cXML;
            var buildingUpgradeBonusesListXml:cXML;
            var buildingUpgradeBonusesXml_vector:Vector.<cXML>;
            var upgradeBuffXml:cXML;
            var availableBuffsListXml:cXML;
            var availableBuffsXml_vector:Vector.<cXML>;
            var buffXml:cXML;
            var xmlBuildingDefaultParameter:cXML;
            var doNotCount_string:String;
            var doNotShowMissingResourceIcon_string:String;
            var hiddenBanditCamps_string:String;
            var hideMouseOverDepositAmount_string:String;
            var autoLoadLevels:Vector.<cXML>;
            var autoLoadLevel_string:String;
            var autoLoadLevel:cXML;
            var adventureZoneLevels:Vector.<cXML>;
            var adventureZoneLevel_string:String;
            var adventureZoneLevel:cXML;
            var upgradeLevels:Vector.<cXML>;
            var xml:cXML;
            var taskDurationsXml:cXML;
            var taskDurationsXml_vector:Vector.<cXML>;
            var taskDurationXml:cXML;
            var xml3:cXML;
            var watchArea:Vector.<cWatchData>;
            var id:int;
            var gridsXml:cXML;
            var grids_vector:Vector.<cXML>;
            var gridXml:cXML;
            var watchData:cWatchData;
            var mailType:int;
            var lifeTime:int;
            var adventureDefinition:cAdventureDefinition;
            var lootTableGroup_vector:Vector.<cLootTable>;
            var lootTableGroupId:int;
            var lootTablesXml_vector:Vector.<cXML>;
            var lootTableXml:cXML;
            var lootTable:cLootTable;
            var buildingUpgradeBonuses:cBuffDefinition;
            var buff:cBuffDefinition;
            var taskName_string:String;
            var successLootTableGroupId:int;
            var failureLootTableGroupId:int;
            var taskDuration:int;
            var playerLevel:int;
            var depositName:String;
            var name_string:String;
            var value:Number;
            var event:* = event;
            var loader:* = event.target as URLLoader;
            try
            {
                root = new cXML();
                root.SetXMLString(String(loader.data));
                globals = root.MoveToSubNode("Globals");
                global.gameSettingsRootXML = root;
                global.gameSettingsVersionNr = globals.MoveToSubNode("Version").GetAttributeInt("nr");
                global.GAME_STATE = globals.MoveToSubNode("GameState").GetAttributeString_string("mode");
                if (definesMaster.MASTER_VERSION)
                {
                    global.GAME_STATE = "Game";
                }
                if (Application.application.parameters.lang)
                {
                    cLocaManager.GetInstance().SetDefaultLanguage(Application.application.parameters.lang);
                }
                else
                {
                    cLocaManager.GetInstance().SetDefaultLanguage(globals.MoveToSubNode("DefaultLanguage").GetAttributeString_string("name"));
                }
                if (gLog.isInfoEnabled(LOG_TYPE.COMMON))
                {
                    gLog.logInfo(LOG_TYPE.COMMON, "GameSettings Version: " + global.gameSettingsVersionNr);
                }
                var _loc_3:* = globals.MoveToSubNode("PlayerInitialResources").GetAttributeString_string("Resource");
                stringTemp = globals.MoveToSubNode("PlayerInitialResources").GetAttributeString_string("Resource");
                global.playerResources_string = _loc_3;
                var _loc_3:* = globals.MoveToSubNode("PlayerInitialLevel").GetAttributeInt("Level");
                intTemp = globals.MoveToSubNode("PlayerInitialLevel").GetAttributeInt("Level");
                global.playerInitialLevel = _loc_3;
                var _loc_3:* = globals.MoveToSubNode("ChatTradeOfferDuration").GetAttributeInt("value");
                intTemp = globals.MoveToSubNode("ChatTradeOfferDuration").GetAttributeInt("value");
                global.tradeOfferDuration = _loc_3;
                global.defaultBuildInstantCosts = globals.MoveToSubNode("DefaultBuildInstantCosts").GetAttributeInt("HardCurrency");
                global.defaultUpgradeInstantBonusPercentage = globals.MoveToSubNode("DefaultInstantUpgradeBonusPercentage").GetAttributeInt("value");
                playerLevels = root.MoveToSubNode("PlayerLevels");
                ar = playerLevels.CreateChildrenArray();
                var _loc_3:int = 0;
                var _loc_4:* = ar;
                while (_loc_4 in _loc_3)
                {
                    
                    level = _loc_4[_loc_3];
                    global.playerLevels_vector.push(level.GetAttributeInt("xp"));
                    if (level.GetAttributeInt("cl") > 0)
                    {
                        global.cityLevels_vector.push(level.GetAttributeInt("xp"));
                    }
                }
                var _loc_3:* = globals.MoveToSubNode("GlobalTimeScale").GetAttributeFloatingPoint("factor");
                doubleTemp = globals.MoveToSubNode("GlobalTimeScale").GetAttributeFloatingPoint("factor");
                global.initGlobalTimeScale = _loc_3;
                global.combatRoundDuration = globals.MoveToSubNode("CombatRoundDuration").GetAttributeInt("seconds") * 1000;
                global.buildingInfoIconDelay = globals.MoveToSubNode("BuildingInfoIconDelay").GetAttributeInt("value") * 1000;
                global.repairRoundDuration = globals.MoveToSubNode("RepairRoundDuration").GetAttributeInt("seconds") * 1000;
                global.repairRate = globals.MoveToSubNode("RepairRate").GetAttributeInt("hitPoints");
                global.repairCostFactor = globals.MoveToSubNode("RepairCostFactor").GetAttributeInt("percent");
                cMilitaryUnitDescription.InitData(root.MoveToSubNode("MilitaryUnits"));
                global.maxTempSlotsAvailablePerPlayer = globals.MoveToSubNode("TempBuildSlots").GetAttributeInt("perPlayer");
                global.tempSlotDuration = globals.MoveToSubNode("TempBuildSlots").GetAttributeInt("durationInSeconds") * 1000;
                watchAreas_vector = new Vector.<Vector.<cWatchData>>;
                watchAreasXml = root.MoveToSubNode("WatchAreas");
                watchAreasXml_vector = watchAreasXml.CreateChildrenArray();
                var _loc_3:int = 0;
                var _loc_4:* = watchAreasXml_vector;
                while (_loc_4 in _loc_3)
                {
                    
                    watchAreaXml = _loc_4[_loc_3];
                    watchArea = new Vector.<cWatchData>;
                    id = watchAreaXml.GetAttributeInt("id");
                    gridsXml = watchAreaXml.MoveToSubNode("Grids");
                    grids_vector = gridsXml.CreateChildrenArray();
                    var _loc_5:int = 0;
                    var _loc_6:* = grids_vector;
                    while (_loc_6 in _loc_5)
                    {
                        
                        gridXml = _loc_6[_loc_5];
                        watchData = new cWatchData(gridXml);
                        watchArea.push(watchData);
                    }
                    if (id != watchAreas_vector.length)
                    {
                        gMisc.Assert(false, "Want to add watch area at the wrong position: " + id + " != " + watchAreas_vector.length + ". Please check the game settings!");
                    }
                    watchAreas_vector.push(watchArea);
                }
                global.watchAreas_vector = watchAreas_vector;
                mailLifetimes_vector = new Vector.<int>;
                mailLifetimesXml_vector = root.MoveToSubNode("MailLifetimes").CreateChildrenArray();
                var _loc_3:int = 0;
                var _loc_4:* = mailLifetimesXml_vector;
                while (_loc_4 in _loc_3)
                {
                    
                    mailLifetimeXml = _loc_4[_loc_3];
                    mailType = MAIL_TYPE.parse(mailLifetimeXml.GetAttributeString_string("type"));
                    lifeTime = mailLifetimeXml.GetAttributeInt("timeHours") * 1000 * 60 * 60;
                    if (mailType != mailLifetimes_vector.length)
                    {
                        gMisc.Assert(false, "Lifetime for mail type " + MAIL_TYPE.toString(mailType) + " is at wrong position: " + mailLifetimes_vector.length + "!");
                        break;
                    }
                    mailLifetimes_vector.push(lifeTime);
                }
                global.mailLifetimes_vector = mailLifetimes_vector;
                global.adventureMaximumOwner = root.MoveToSubNode("Adventures").GetAttributeInt("maximumConcurrentOwner");
                global.adventureMaximumGuest = root.MoveToSubNode("Adventures").GetAttributeInt("maximumConcurrentGuest");
                adventures_vector = new Vector.<cAdventureDefinition>;
                adventuresXml_vector = root.MoveToSubNode("Adventures").CreateChildrenArray();
                var _loc_3:int = 0;
                var _loc_4:* = adventuresXml_vector;
                while (_loc_4 in _loc_3)
                {
                    
                    adventureXml = _loc_4[_loc_3];
                    adventureDefinition = cAdventureDefinition.CreateFromXML(adventureXml);
                    gMisc.Assert(adventureDefinition.mId == adventures_vector.length, "Wrong ID for adventure \'" + adventureDefinition.mName_string + "\'! It\'s ID should be " + adventures_vector.length + "!");
                    adventures_vector.push(adventureDefinition);
                }
                global.adventures_vector = adventures_vector;
                lootTableGroups_vector = new Vector.<Vector.<cLootTable>>;
                LootTablesXml = root.MoveToSubNode("LootTables");
                lootTableGroupsXml_vector = LootTablesXml.CreateChildrenArray();
                var _loc_3:int = 0;
                var _loc_4:* = lootTableGroupsXml_vector;
                while (_loc_4 in _loc_3)
                {
                    
                    lootTableGroupXml = _loc_4[_loc_3];
                    lootTableGroup_vector = new Vector.<cLootTable>;
                    lootTableGroupId = lootTableGroupXml.GetAttributeInt("id");
                    lootTablesXml_vector = lootTableGroupXml.CreateChildrenArray();
                    var _loc_5:int = 0;
                    var _loc_6:* = lootTablesXml_vector;
                    while (_loc_6 in _loc_5)
                    {
                        
                        lootTableXml = _loc_6[_loc_5];
                        lootTable = cLootTable.CreateLootTableFromXml(lootTableXml);
                        lootTableGroup_vector.push(lootTable);
                    }
                    if (lootTableGroupId != lootTableGroups_vector.length)
                    {
                        gMisc.Assert(false, "Want to add loot table at the wrong position: " + lootTableGroupId + " != " + lootTableGroups_vector.length + ". Please check the game settings!");
                    }
                    lootTableGroups_vector.push(lootTableGroup_vector);
                }
                global.lootTableGroups_vector = lootTableGroups_vector;
                buildingUpgradeBonusesListXml = root.MoveToSubNode("BuildingUpgradeBonuses");
                buildingUpgradeBonusesXml_vector = buildingUpgradeBonusesListXml.CreateChildrenArray();
                var _loc_3:int = 0;
                var _loc_4:* = buildingUpgradeBonusesXml_vector;
                while (_loc_4 in _loc_3)
                {
                    
                    upgradeBuffXml = _loc_4[_loc_3];
                    buildingUpgradeBonuses = cBuffDefinition.CreateBuffDefinitionFromXml(upgradeBuffXml);
                    if (buildingUpgradeBonuses.getUpgradeLevel() != global.buildingUpgradeBonuses_vector.length)
                    {
                        gMisc.Assert(false, "Want to add upgrade bonuses at the wrong position: " + buildingUpgradeBonuses.getUpgradeLevel() + " != " + global.buildingUpgradeBonuses_vector.length + ". Please check the game settings!");
                    }
                    global.buildingUpgradeBonuses_vector.push(buildingUpgradeBonuses);
                }
                availableBuffsListXml = root.MoveToSubNode("AvailableBuffs");
                availableBuffsXml_vector = availableBuffsListXml.CreateChildrenArray();
                var _loc_3:int = 0;
                var _loc_4:* = availableBuffsXml_vector;
                while (_loc_4 in _loc_3)
                {
                    
                    buffXml = _loc_4[_loc_3];
                    buff = cBuffDefinition.CreateBuffDefinitionFromXml(buffXml);
                    gMisc.Assert(buff.GetId() == global.buffDefinitions_vector.length, "Buff \'" + buff.GetType_string() + "\' has wrong ID! It should be " + global.buffDefinitions_vector.length + "!");
                    global.buffDefinitions_vector.push(buff);
                    global.map_BuffName_BuffDefinition[buff.GetType_string()] = buff;
                }
                var _loc_3:* = globals.MoveToSubNode("GOList").GetAttributeInt("scale");
                intTemp = globals.MoveToSubNode("GOList").GetAttributeInt("scale");
                global.GOListScale = _loc_3;
                xmlBuildingDefaultParameter = globals.MoveToSubNode("BuildingDefaultParameter");
                var _loc_3:* = xmlBuildingDefaultParameter.GetAttributeInt("constructionDuration");
                intTemp = xmlBuildingDefaultParameter.GetAttributeInt("constructionDuration");
                global.buildingDefaultParameterConstructionDuration = _loc_3;
                var _loc_3:* = xmlBuildingDefaultParameter.GetAttributeInt("destructionDuration");
                intTemp = xmlBuildingDefaultParameter.GetAttributeInt("destructionDuration");
                global.buildingDefaultParameterDestructionDuration = _loc_3;
                var _loc_3:* = xmlBuildingDefaultParameter.GetAttributeInt("xp");
                intTemp = xmlBuildingDefaultParameter.GetAttributeInt("xp");
                global.buildingDefaultParameterXP = _loc_3;
                doNotCount_string = xmlBuildingDefaultParameter.GetAttributeString_string("doNotCount");
                ConvertStringListToStringIntDictionary(doNotCount_string, global.buildingDefaultParameterDoNotCountList_dictionary);
                doNotShowMissingResourceIcon_string = xmlBuildingDefaultParameter.GetAttributeString_string("doNotShowMissingResourceIcon");
                ConvertStringListToStringIntDictionary(doNotShowMissingResourceIcon_string, global.buildingDefaultParameterDoNotShowMissingResourceIcon_dictionary);
                hiddenBanditCamps_string = xmlBuildingDefaultParameter.GetAttributeString_string("hiddenBanditCamps");
                ConvertStringListToStringIntDictionary(hiddenBanditCamps_string, global.hiddenBanditCamps_dictionary);
                hideMouseOverDepositAmount_string = xmlBuildingDefaultParameter.GetAttributeString_string("hideMouseOverDepositAmount");
                ConvertStringListToStringIntDictionary(hideMouseOverDepositAmount_string, global.hideMouseOverDepositAmount_dictionary);
                global.buildingDefaultFogRemoveList_vector = gCalculations.CalculateTileListFromRadius(globals.MoveToSubNode("BuildingDefaultParameter").GetAttributeInt("removeFogAttribute"));
                var _loc_3:* = globals.MoveToSubNode("Zoom").GetAttributeInt("min");
                intTemp = globals.MoveToSubNode("Zoom").GetAttributeInt("min");
                global.minZoom = _loc_3;
                var _loc_3:* = globals.MoveToSubNode("Zoom").GetAttributeInt("max");
                intTemp = globals.MoveToSubNode("Zoom").GetAttributeInt("max");
                global.maxZoom = _loc_3;
                var _loc_3:* = globals.MoveToSubNode("Zoom").GetAttributeInt("default");
                intTemp = globals.MoveToSubNode("Zoom").GetAttributeInt("default");
                global.defaultZoom = _loc_3;
                var _loc_3:* = globals.MoveToSubNode("Zoom").GetAttributeInt("speed");
                intTemp = globals.MoveToSubNode("Zoom").GetAttributeInt("speed");
                global.zoomSpeed = _loc_3;
                var _loc_3:* = globals.MoveToSubNode("Scrolling").GetAttributeInt("speed");
                intTemp = globals.MoveToSubNode("Scrolling").GetAttributeInt("speed");
                global.scrollSpeed = _loc_3;
                global.defaultMaximumBuildingCount = globals.MoveToSubNode("DefaultMaximumBuildingsCount").GetAttributeInt("value");
                global.defaultMaximumBuildingsCountAll = globals.MoveToSubNode("DefaultMaximumBuildingsCountAll").GetAttributeInt("value");
                global.scrollSpeed = 50;
                global.questSettingsFilename = globals.MoveToSubNode("Quests").GetAttributeString_string("FileName");
                if (globals.MoveToSubNode("Quests").GetAttributeString_string("DebugGui") == "true")
                {
                    global.activateDebugQuestGui = true;
                }
                else
                {
                    global.activateDebugQuestGui = false;
                }
                global.autoLoadLevel_vector = new Vector.<String>;
                autoLoadLevels = globals.CreateChildrenArray();
                var _loc_3:int = 0;
                var _loc_4:* = autoLoadLevels;
                while (_loc_4 in _loc_3)
                {
                    
                    autoLoadLevel = _loc_4[_loc_3];
                    if (autoLoadLevel.GetName_string() == "AutoLoad")
                    {
                        var _loc_5:* = autoLoadLevel.GetAttributeString_string("Level");
                        stringTemp = autoLoadLevel.GetAttributeString_string("Level");
                        autoLoadLevel_string = _loc_5;
                        global.autoLoadLevel_vector.push(autoLoadLevel_string);
                    }
                }
                global.adventureZoneLevels_vector = new Vector.<String>;
                adventureZoneLevels = globals.CreateChildrenArray();
                var _loc_3:int = 0;
                var _loc_4:* = adventureZoneLevels;
                while (_loc_4 in _loc_3)
                {
                    
                    adventureZoneLevel = _loc_4[_loc_3];
                    if (adventureZoneLevel.GetName_string() == "AdventureZone")
                    {
                        var _loc_5:* = adventureZoneLevel.GetAttributeString_string("Level");
                        stringTemp = adventureZoneLevel.GetAttributeString_string("Level");
                        adventureZoneLevel_string = _loc_5;
                        global.adventureZoneLevels_vector.push(adventureZoneLevel_string);
                    }
                }
                var _loc_3:* = globals.MoveToSubNode("Animals").GetAttributeInt("MaxAnimalsOnMap");
                intTemp = globals.MoveToSubNode("Animals").GetAttributeInt("MaxAnimalsOnMap");
                global.maxAnimalsOnMap = _loc_3;
                global.latestChangesIdentifier = globals.MoveToSubNode("News").GetAttributeString_string("LatestChanges");
                global.tipOfTheDayCount = globals.MoveToSubNode("News").GetAttributeInt("TipOfTheDayCount");
                global.loadingMessageCount = globals.MoveToSubNode("News").GetAttributeInt("LoadingMessageCount");
                global.guildHighscorePageSize = globals.MoveToSubNode("Guild").GetAttributeInt("HighscorePageSize");
                global.guildBannerCount = globals.MoveToSubNode("Guild").GetAttributeInt("BannerCount");
                global.guildJoinCooldown = globals.MoveToSubNode("Guild").GetAttributeInt("JoinCooldown");
                global.guildMaxSizeLimit = globals.MoveToSubNode("Guild").GetAttributeInt("MaxSizeLimit");
                upgradeLevels = globals.MoveToSubNode("Guild").CreateChildrenArray();
                var _loc_3:int = 0;
                var _loc_4:* = upgradeLevels;
                while (_loc_4 in _loc_3)
                {
                    
                    xml = _loc_4[_loc_3];
                    global.guildUpgradeLevels[xml.GetAttributeInt("level")] = xml.GetAttributeInt("maxSize");
                }
                defines.FORUM_URL = globals.MoveToSubNode("ForumUrl").GetAttributeString_string("value");
                defines.SUPPORT_URL = globals.MoveToSubNode("SupportUrl").GetAttributeString_string("value");
                defines.INVITE_URL = globals.MoveToSubNode("InviteUrl").GetAttributeString_string("value");
                defines.KEEP_ALIVE_URL = globals.MoveToSubNode("KeepAlive").GetAttributeString_string("url");
                defines.KEEP_ALIVE_INTERVAL = globals.MoveToSubNode("KeepAlive").GetAttributeInt("interval");
                global.guiIconGroup.SetGameXML("GuiIcons");
                global.backgroundGroup.SetGameXML("Backgrounds");
                global.streetGroup.SetGameXML("Streets");
                global.buildingGroup.SetGameXML("Buildings");
                global.landscapeGroup.SetGameXML("Landscapes");
                global.settlerGroup.SetGameXML("Settlers");
                global.animalGroup.SetGameXML("Animals");
                global.effectGroup.SetGameXML("Effects");
                cSpecialist.InitData(root.MoveToSubNode("Specialists"), root.MoveToSubNode("SpecialistCostLists"));
                taskDurationsXml = root.MoveToSubNode("SpecialistTaskDurations");
                taskDurationsXml_vector = taskDurationsXml.CreateChildrenArray();
                var _loc_3:int = 0;
                var _loc_4:* = taskDurationsXml_vector;
                while (_loc_4 in _loc_3)
                {
                    
                    taskDurationXml = _loc_4[_loc_3];
                    taskName_string = taskDurationXml.GetAttributeString_string("name");
                    successLootTableGroupId = taskDurationXml.GetAttributeInt("successLootTableGroupId");
                    failureLootTableGroupId = taskDurationXml.GetAttributeInt("failureLootTableGroupId");
                    taskDuration = taskDurationXml.GetAttributeInt("durationSeconds") * 1000;
                    playerLevel = taskDurationXml.GetAttributeInt("playerLevel");
                    if (taskName_string == "FindDeposit")
                    {
                        depositName = taskDurationXml.GetAttributeString_string("deposit");
                        cSpecialistTask_FindDeposit.AddFindDepositData(depositName, taskDuration, playerLevel, taskDurationXml.GetAttributeInt("speedUpCosts"), taskDurationXml.GetAttributeInt("speedUpFactor"));
                        cSpecialistTask.AddLootTableGroupData(SPECIALIST_TASK_TYPES.DEPOSIT_SEARCH, successLootTableGroupId, failureLootTableGroupId);
                        continue;
                    }
                    if (taskName_string == "FindDepositCalculationHeadstart")
                    {
                        cSpecialistTask_FindDeposit.FIND_DEPOSIT_CALCULATION_HEADSTART = taskDuration;
                        continue;
                    }
                    if (taskName_string == "Recover")
                    {
                        cSpecialistTask_Recover.TIME_TO_RECOVER = taskDuration;
                        cSpecialistTask.AddLootTableGroupData(SPECIALIST_TASK_TYPES.RECOVER, successLootTableGroupId, failureLootTableGroupId);
                        cSpecialistTask.AddSpeedUpData(SPECIALIST_TASK_TYPES.parse(taskName_string), taskDurationXml.GetAttributeInt("speedUpCosts"), taskDurationXml.GetAttributeInt("speedUpFactor"));
                        continue;
                    }
                    if (taskName_string == "ExploreSector")
                    {
                        cSpecialistTask_ExploreSector.TIME_TO_EXPLORE_SECTOR = taskDuration;
                        cSpecialistTask_ExploreSector.PLAYER_LEVEL = playerLevel;
                        cSpecialistTask.AddLootTableGroupData(SPECIALIST_TASK_TYPES.EXPLORE_SECTOR, successLootTableGroupId, failureLootTableGroupId);
                        cSpecialistTask.AddSpeedUpData(SPECIALIST_TASK_TYPES.parse(taskName_string), taskDurationXml.GetAttributeInt("speedUpCosts"), taskDurationXml.GetAttributeInt("speedUpFactor"));
                        continue;
                    }
                    if (taskName_string == "ExploreSectorCalculationHeadstart")
                    {
                        cSpecialistTask_ExploreSector.EXPLORE_SECTOR_CALCULATION_HEADSTART = taskDuration;
                        continue;
                    }
                    if (taskName_string == "FindTreasureShort")
                    {
                        cSpecialistTask_FindTreasure.TIME_TO_FIND_TREASURE_SHORT = taskDuration;
                        cSpecialistTask_FindTreasure.PLAYER_LEVEL_SHORT = playerLevel;
                        cSpecialistTask.AddLootTableGroupData(SPECIALIST_TASK_TYPES.FIND_TREASURE_SHORT, successLootTableGroupId, failureLootTableGroupId);
                        cSpecialistTask.AddSpeedUpData(SPECIALIST_TASK_TYPES.parse(taskName_string), taskDurationXml.GetAttributeInt("speedUpCosts"), taskDurationXml.GetAttributeInt("speedUpFactor"));
                        continue;
                    }
                    if (taskName_string == "FindTreasureMedium")
                    {
                        cSpecialistTask_FindTreasure.TIME_TO_FIND_TREASURE_MEDIUM = taskDuration;
                        cSpecialistTask_FindTreasure.PLAYER_LEVEL_MEDIUM = playerLevel;
                        cSpecialistTask.AddLootTableGroupData(SPECIALIST_TASK_TYPES.FIND_TREASURE_MEDIUM, successLootTableGroupId, failureLootTableGroupId);
                        cSpecialistTask.AddSpeedUpData(SPECIALIST_TASK_TYPES.parse(taskName_string), taskDurationXml.GetAttributeInt("speedUpCosts"), taskDurationXml.GetAttributeInt("speedUpFactor"));
                        continue;
                    }
                    if (taskName_string == "FindTreasureLong")
                    {
                        cSpecialistTask_FindTreasure.TIME_TO_FIND_TREASURE_LONG = taskDuration;
                        cSpecialistTask_FindTreasure.PLAYER_LEVEL_LONG = playerLevel;
                        cSpecialistTask.AddLootTableGroupData(SPECIALIST_TASK_TYPES.FIND_TREASURE_LONG, successLootTableGroupId, failureLootTableGroupId);
                        cSpecialistTask.AddSpeedUpData(SPECIALIST_TASK_TYPES.parse(taskName_string), taskDurationXml.GetAttributeInt("speedUpCosts"), taskDurationXml.GetAttributeInt("speedUpFactor"));
                        continue;
                    }
                    if (taskName_string == "FindTreasureEvenLonger")
                    {
                        cSpecialistTask_FindTreasure.TIME_TO_FIND_TREASURE_EVEN_LONGER = taskDuration;
                        cSpecialistTask_FindTreasure.PLAYER_LEVEL_EVEN_LONGER = playerLevel;
                        cSpecialistTask.AddLootTableGroupData(SPECIALIST_TASK_TYPES.FIND_TREASURE_EVEN_LONGER, successLootTableGroupId, failureLootTableGroupId);
                        cSpecialistTask.AddSpeedUpData(SPECIALIST_TASK_TYPES.parse(taskName_string), taskDurationXml.GetAttributeInt("speedUpCosts"), taskDurationXml.GetAttributeInt("speedUpFactor"));
                        continue;
                    }
                    if (taskName_string == "FindTreasureCalculationHeadstart")
                    {
                        cSpecialistTask_FindTreasure.FIND_TREASURE_CALCULATION_HEADSTART = taskDuration;
                        continue;
                    }
                    if (taskName_string == "FindAdventureZoneShort")
                    {
                        cSpecialistTask_FindEventZone.TIME_TO_FIND_ADVENTURE_ZONE_SHORT = taskDuration;
                        cSpecialistTask_FindEventZone.PLAYER_LEVEL_SHORT = playerLevel;
                        cSpecialistTask_FindEventZone.PERFORM_TASK_COSTS_SHORT_vector = ParseCosts(taskDurationXml.MoveToSubNode("Costs"));
                        cSpecialistTask.AddLootTableGroupData(SPECIALIST_TASK_TYPES.FIND_ADVENTURE_ZONE_SHORT, successLootTableGroupId, failureLootTableGroupId);
                        cSpecialistTask.AddSpeedUpData(SPECIALIST_TASK_TYPES.parse(taskName_string), taskDurationXml.GetAttributeInt("speedUpCosts"), taskDurationXml.GetAttributeInt("speedUpFactor"));
                        continue;
                    }
                    if (taskName_string == "FindAdventureZoneMedium")
                    {
                        cSpecialistTask_FindEventZone.TIME_TO_FIND_ADVENTURE_ZONE_MEDIUM = taskDuration;
                        cSpecialistTask_FindEventZone.PLAYER_LEVEL_MEDIUM = playerLevel;
                        cSpecialistTask_FindEventZone.PERFORM_TASK_COSTS_MEDIUM_vector = ParseCosts(taskDurationXml.MoveToSubNode("Costs"));
                        cSpecialistTask.AddLootTableGroupData(SPECIALIST_TASK_TYPES.FIND_ADVENTURE_ZONE_MEDIUM, successLootTableGroupId, failureLootTableGroupId);
                        cSpecialistTask.AddSpeedUpData(SPECIALIST_TASK_TYPES.parse(taskName_string), taskDurationXml.GetAttributeInt("speedUpCosts"), taskDurationXml.GetAttributeInt("speedUpFactor"));
                        continue;
                    }
                    if (taskName_string == "FindAdventureZoneLong")
                    {
                        cSpecialistTask_FindEventZone.TIME_TO_FIND_ADVENTURE_ZONE_LONG = taskDuration;
                        cSpecialistTask_FindEventZone.PLAYER_LEVEL_LONG = playerLevel;
                        cSpecialistTask_FindEventZone.PERFORM_TASK_COSTS_LONG_vector = ParseCosts(taskDurationXml.MoveToSubNode("Costs"));
                        cSpecialistTask.AddLootTableGroupData(SPECIALIST_TASK_TYPES.FIND_ADVENTURE_ZONE_LONG, successLootTableGroupId, failureLootTableGroupId);
                        cSpecialistTask.AddSpeedUpData(SPECIALIST_TASK_TYPES.parse(taskName_string), taskDurationXml.GetAttributeInt("speedUpCosts"), taskDurationXml.GetAttributeInt("speedUpFactor"));
                        continue;
                    }
                    if (taskName_string == "TravelToZone")
                    {
                        cSpecialistTask_TravelToZone.TIME_TO_TRAVEL_TO_ZONE = taskDuration;
                        cSpecialistTask_TravelToZone.PLAYER_LEVEL = playerLevel;
                        cSpecialistTask.AddSpeedUpData(SPECIALIST_TASK_TYPES.parse(taskName_string), taskDurationXml.GetAttributeInt("speedUpCosts"), taskDurationXml.GetAttributeInt("speedUpFactor"));
                        continue;
                    }
                    if (taskName_string == "FindAdventureZoneCalculationHeadstart")
                    {
                        cSpecialistTask_FindEventZone.FIND_ADVENTURE_ZONE_CALCULATION_HEADSTART = taskDuration;
                        continue;
                    }
                    gMisc.Assert(false, "Could not interpret task-name \'" + taskName_string + "\'!");
                }
                var _loc_3:int = 0;
                var _loc_4:* = globals.MoveToSubNode("ResourceHardcurrencyValues").CreateChildrenArray();
                while (_loc_4 in _loc_3)
                {
                    
                    xml3 = _loc_4[_loc_3];
                    name_string = xml3.GetAttributeString_string("name");
                    value = xml3.GetAttributeFloatingPoint("value");
                    global.resourceHardcurrencyValues[name_string] = value;
                }
                PostProcess();
            }
            catch (error:Error)
            {
                gErrorMessages.ShowErrorMessage("Error Parsing GameSettings.xml: " + error);
            }
            mDispatcherGameSettings.doAction();
            return;
        }// end function

        private static function PostProcess() : void
        {
            if (SHOW_XML_INFO)
            {
                gErrorMessages.ShowInfoMessage("StreetGridsize x,y: " + global.streetGridX + "," + global.streetGridY + "\n" + "GOListScale: " + global.GOListScale + "\n" + "Zoom min,max,default,speed: " + global.minZoom + "," + global.maxZoom + "," + global.defaultZoom + "," + global.zoomSpeed + "\n" + "Scrollspeed: " + global.scrollSpeed + "\n" + "DefaultZoom:" + global.backgroundGroup.defaultZoom + "\n");
            }
            return;
        }// end function

    }
}
