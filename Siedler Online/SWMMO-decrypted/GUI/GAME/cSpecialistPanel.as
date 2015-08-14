package GUI.GAME
{
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Loca.*;
    import Interface.*;
    import MilitarySystem.*;
    import ServerState.*;
    import Specialists.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import flash.events.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.events.*;
    import mx.utils.*;
    import nLib.*;

    public class cSpecialistPanel extends cBasicPanel
    {
        private var mPreviousUnitsAmount:int = 0;
        private var mLandmark:cGO;
        private var mSpecialist:cSpecialist;
        private var mGI:cGameInterface;
        private var mDepositToSearch:String;
        protected var mPanel:SpecialistPanel;
        private var mSelectedTaskType:int;

        public function cSpecialistPanel()
        {
            return;
        }// end function

        private function UpdateUnitsAmounts(event:FlexEvent) : void
        {
            var _loc_3:Object = null;
            var _loc_2:int = 0;
            for each (_loc_3 in this.mPanel.manageArmyList.dataProvider)
            {
                
                _loc_2 = _loc_2 + _loc_3.current;
            }
            this.mPanel.manageUnitsAmountLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "UnitsAttached", [_loc_2.toString(), this.mSpecialist.GetMaxMilitaryUnits().toString()]);
            this.mPanel.manageUnitsAmountLabel.setStyle("color", _loc_2 > this.mSpecialist.GetMaxMilitaryUnits() ? (16711680) : (16777215));
            this.mPanel.btnCommitArmyChanges.enabled = this.mPreviousUnitsAmount != _loc_2 && _loc_2 <= this.mSpecialist.GetMaxMilitaryUnits();
            this.mPanel.btnResetArmyChanges.enabled = this.mPreviousUnitsAmount != _loc_2;
            this.mPreviousUnitsAmount = _loc_2;
            return;
        }// end function

        private function SendExplorer(event:MouseEvent) : void
        {
            this.mSpecialist.SetTask(new cSpecialistTask_WaitForConfirmation(this.mGI, this.mSpecialist, 0));
            this.mGI.SendServerAction(COMMAND.SET_TASK, this.mSelectedTaskType, 0, 0, this.mSpecialist.GetUniqueID());
            this.mPanel.btnOK.removeEventListener(MouseEvent.CLICK, this.SendExplorer);
            this.Hide();
            return;
        }// end function

        private function CreateCostsList(param1) : DisplayObject
        {
            var _loc_3:dResource = null;
            var _loc_4:ResourceItemRenderer = null;
            var _loc_2:* = new HBox();
            for each (_loc_3 in param1)
            {
                
                _loc_4 = new ResourceItemRenderer();
                _loc_4.data = _loc_3;
                _loc_2.addChild(_loc_4);
            }
            return _loc_2;
        }// end function

        public function SetData(param1:cSpecialist) : void
        {
            this.mSpecialist = param1;
            this.mPanel.specialistFrame.content = "Icon" + SPECIALIST_TYPE.toString(this.mSpecialist.GetType());
            this.mPanel.title.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.SPECIALISTS, SPECIALIST_TYPE.toString(this.mSpecialist.GetType()));
            this.mPanel.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, SPECIALIST_TYPE.toString(this.mSpecialist.GetType()));
            switch(this.mSpecialist.GetBaseType())
            {
                case SPECIALIST_TYPE.GENERAL:
                {
                    if (this.mPanel.currentState == "General")
                    {
                        this.EnterGeneralState(null);
                    }
                    else
                    {
                        this.mPanel.currentState = "General";
                    }
                    break;
                }
                case SPECIALIST_TYPE.GEOLOGIST:
                {
                    this.mPanel.currentState = "Geologist";
                    break;
                }
                case SPECIALIST_TYPE.EXPLORER:
                {
                    this.mPanel.currentState = "Explorer";
                    break;
                }
                default:
                {
                    gMisc.Assert(false, "Could not interpret specialist type " + this.mSpecialist.GetType());
                    break;
                }
            }
            return;
        }// end function

        private function EnterGeologistState(event:FlexEvent) : void
        {
            if (this.mPanel.costsHolder.numChildren > 1)
            {
                this.mPanel.costsHolder.removeChildAt(0);
            }
            this.mPanel.taskDuration.text = "";
            this.mPanel.btnOK.removeEventListener(MouseEvent.CLICK, this.SendExplorer);
            this.mPanel.btnOK.addEventListener(MouseEvent.CLICK, this.SearchSelectedDeposit);
            this.mPanel.btnOK.enabled = false;
            this.mPanel.btnFindDepositBronzeOre.addEventListener(MouseEvent.CLICK, this.SelectDeposit);
            this.mPanel.btnFindDepositBronzeOre.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("BronzeOre");
            if (this.mPanel.btnFindDepositBronzeOre.enabled)
            {
                this.mPanel.btnFindDepositBronzeOre.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositBronze");
            }
            else
            {
                this.mPanel.btnFindDepositBronzeOre.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("BronzeOre").toString()]);
            }
            this.mPanel.btnFindDepositIronOre.addEventListener(MouseEvent.CLICK, this.SelectDeposit);
            this.mPanel.btnFindDepositIronOre.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("IronOre");
            if (this.mPanel.btnFindDepositIronOre.enabled)
            {
                this.mPanel.btnFindDepositIronOre.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositIron");
            }
            else
            {
                this.mPanel.btnFindDepositIronOre.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("IronOre").toString()]);
            }
            this.mPanel.btnFindDepositGoldOre.addEventListener(MouseEvent.CLICK, this.SelectDeposit);
            this.mPanel.btnFindDepositGoldOre.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("GoldOre");
            if (this.mPanel.btnFindDepositGoldOre.enabled)
            {
                this.mPanel.btnFindDepositGoldOre.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositGold");
            }
            else
            {
                this.mPanel.btnFindDepositGoldOre.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("GoldOre").toString()]);
            }
            this.mPanel.btnFindDepositCoal.addEventListener(MouseEvent.CLICK, this.SelectDeposit);
            this.mPanel.btnFindDepositCoal.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("Coal");
            if (this.mPanel.btnFindDepositCoal.enabled)
            {
                this.mPanel.btnFindDepositCoal.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositCoal");
            }
            else
            {
                this.mPanel.btnFindDepositCoal.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("Coal").toString()]);
            }
            this.mPanel.btnFindDepositTitaniumOre.addEventListener(MouseEvent.CLICK, this.SelectDeposit);
            this.mPanel.btnFindDepositTitaniumOre.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("TitaniumOre");
            if (this.mPanel.btnFindDepositTitaniumOre.enabled)
            {
                this.mPanel.btnFindDepositTitaniumOre.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositAlloy");
            }
            else
            {
                this.mPanel.btnFindDepositTitaniumOre.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("TitaniumOre").toString()]);
            }
            this.mPanel.btnFindDepositStone.addEventListener(MouseEvent.CLICK, this.SelectDeposit);
            this.mPanel.btnFindDepositStone.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("Stone");
            if (this.mPanel.btnFindDepositStone.enabled)
            {
                this.mPanel.btnFindDepositStone.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositStone");
            }
            else
            {
                this.mPanel.btnFindDepositStone.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("Stone").toString()]);
            }
            this.mPanel.btnFindDepositGranite.addEventListener(MouseEvent.CLICK, this.SelectDeposit);
            this.mPanel.btnFindDepositGranite.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("Granite");
            if (this.mPanel.btnFindDepositGranite.enabled)
            {
                this.mPanel.btnFindDepositGranite.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositGranite");
            }
            else
            {
                this.mPanel.btnFindDepositGranite.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("Granite").toString()]);
            }
            this.mPanel.btnFindDepositMarble.addEventListener(MouseEvent.CLICK, this.SelectDeposit);
            this.mPanel.btnFindDepositMarble.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("Marble");
            if (this.mPanel.btnFindDepositMarble.enabled)
            {
                this.mPanel.btnFindDepositMarble.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositMarble");
            }
            else
            {
                this.mPanel.btnFindDepositMarble.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("Marble").toString()]);
            }
            this.mPanel.btnFindDepositSalpeter.addEventListener(MouseEvent.CLICK, this.SelectDeposit);
            this.mPanel.btnFindDepositSalpeter.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("Salpeter");
            if (this.mPanel.btnFindDepositSalpeter.enabled)
            {
                this.mPanel.btnFindDepositSalpeter.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindDepositSalpeter");
            }
            else
            {
                this.mPanel.btnFindDepositSalpeter.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindDeposit.GetPlayerLevelForDeposit("Salpeter").toString()]);
            }
            return;
        }// end function

        private function ClosePanel(event:MouseEvent) : void
        {
            this.Hide();
            return;
        }// end function

        private function CommitArmyChanges(event:MouseEvent) : void
        {
            var _loc_3:Object = null;
            var _loc_2:* = new Vector.<dSquadVO>;
            for each (_loc_3 in this.mPanel.manageArmyList.dataProvider)
            {
                
                if (_loc_3.current > 0)
                {
                    _loc_2.push(new dSquadVO().init(_loc_3.name_string, _loc_3.current, cMilitaryUnitDescription.GetUnitDescriptionForType(_loc_3.name_string).GetHitPoints()));
                }
            }
            this.mPanel.btnCommitArmyChanges.enabled = false;
            this.mPanel.btnResetArmyChanges.enabled = false;
            this.mPanel.btnAttack.enabled = false;
            this.mPanel.btnRetreat.enabled = false;
            this.mPanel.btnTransfer.enabled = false;
            this.mPanel.busy = true;
            this.mSpecialist.SetWaitingForServer(true);
            cMilitaryUtil.SendRaiseArmyToServer(this.mGI, this.mSpecialist, _loc_2);
            return;
        }// end function

        private function SearchSelectedDeposit(event:MouseEvent) : void
        {
            var _loc_2:* = new dFindDepositTaskVO();
            _loc_2.search_string = this.mDepositToSearch;
            _loc_2.uniqueID = this.mSpecialist.GetUniqueID();
            this.mGI.SendServerAction(COMMAND.SET_TASK, this.mSelectedTaskType, 0, 0, _loc_2);
            this.mSpecialist.SetTask(new cSpecialistTask_WaitForConfirmation(this.mGI, this.mSpecialist, 0));
            this.mPanel.btnOK.removeEventListener(MouseEvent.CLICK, this.SearchSelectedDeposit);
            this.Hide();
            return;
        }// end function

        private function SelectExplorerTask(event:MouseEvent) : void
        {
            var _loc_2:* = 1 / this.mSpecialist.GetSpecialistDescription().GetTimeBonus() * 100;
            var _loc_3:Vector.<dResource> = null;
            if (this.mPanel.costsHolder.numChildren > 1)
            {
                this.mPanel.costsHolder.removeChildAt(0);
            }
            ;
            
            this.mSelectedTaskType = SPECIALIST_TASK_TYPES.EXPLORE_SECTOR;
            _loc_2 = _loc_2 * cSpecialistTask_ExploreSector.TIME_TO_EXPLORE_SECTOR;
            ;
            
            this.mSelectedTaskType = SPECIALIST_TASK_TYPES.FIND_TREASURE_SHORT;
            _loc_2 = _loc_2 * cSpecialistTask_FindTreasure.TIME_TO_FIND_TREASURE_SHORT;
            ;
            
            this.mSelectedTaskType = SPECIALIST_TASK_TYPES.FIND_TREASURE_MEDIUM;
            _loc_2 = _loc_2 * cSpecialistTask_FindTreasure.TIME_TO_FIND_TREASURE_MEDIUM;
            ;
            
            this.mSelectedTaskType = SPECIALIST_TASK_TYPES.FIND_TREASURE_LONG;
            _loc_2 = _loc_2 * cSpecialistTask_FindTreasure.TIME_TO_FIND_TREASURE_LONG;
            ;
            
            this.mSelectedTaskType = SPECIALIST_TASK_TYPES.FIND_TREASURE_EVEN_LONGER;
            _loc_2 = _loc_2 * cSpecialistTask_FindTreasure.TIME_TO_FIND_TREASURE_EVEN_LONGER;
            ;
            
            this.mSelectedTaskType = SPECIALIST_TASK_TYPES.FIND_ADVENTURE_ZONE_SHORT;
            _loc_2 = _loc_2 * cSpecialistTask_FindEventZone.TIME_TO_FIND_ADVENTURE_ZONE_SHORT;
            _loc_3 = cSpecialistTask_FindEventZone.PERFORM_TASK_COSTS_SHORT_vector;
            ;
            
            this.mSelectedTaskType = SPECIALIST_TASK_TYPES.FIND_ADVENTURE_ZONE_MEDIUM;
            _loc_2 = _loc_2 * cSpecialistTask_FindEventZone.TIME_TO_FIND_ADVENTURE_ZONE_MEDIUM;
            _loc_3 = cSpecialistTask_FindEventZone.PERFORM_TASK_COSTS_MEDIUM_vector;
            ;
            
            this.mSelectedTaskType = SPECIALIST_TASK_TYPES.FIND_ADVENTURE_ZONE_LONG;
            _loc_2 = _loc_2 * cSpecialistTask_FindEventZone.TIME_TO_FIND_ADVENTURE_ZONE_LONG;
            _loc_3 = cSpecialistTask_FindEventZone.PERFORM_TASK_COSTS_LONG_vector;
            ;
            
            gMisc.ConsoleOut("Could not interpret currentTarget: " + ObjectUtil.toString(event.currentTarget));
            return;
        }// end function

        private function MoveGarisson(event:MouseEvent) : void
        {
            this.mGI.mCurrentCursor.mCurrentSpecialist = this.mSpecialist;
            this.mGI.mCurrentCursor.SetCursorEditMode(COMMAND.MOVE_GARISSON);
            this.Hide();
            return;
        }// end function

        private function SelectDeposit(event:MouseEvent) : void
        {
            if (event.currentTarget == this.mPanel.btnFindDepositBronzeOre)
            {
                this.mDepositToSearch = "BronzeOre";
            }
            else if (event.currentTarget == this.mPanel.btnFindDepositIronOre)
            {
                this.mDepositToSearch = "IronOre";
            }
            else if (event.currentTarget == this.mPanel.btnFindDepositCoal)
            {
                this.mDepositToSearch = "Coal";
            }
            else if (event.currentTarget == this.mPanel.btnFindDepositGoldOre)
            {
                this.mDepositToSearch = "GoldOre";
            }
            else if (event.currentTarget == this.mPanel.btnFindDepositTitaniumOre)
            {
                this.mDepositToSearch = "TitaniumOre";
            }
            else if (event.currentTarget == this.mPanel.btnFindDepositStone)
            {
                this.mDepositToSearch = "Stone";
            }
            else if (event.currentTarget == this.mPanel.btnFindDepositGranite)
            {
                this.mDepositToSearch = "Granite";
            }
            else if (event.currentTarget == this.mPanel.btnFindDepositMarble)
            {
                this.mDepositToSearch = "Marble";
            }
            else if (event.currentTarget == this.mPanel.btnFindDepositSalpeter)
            {
                this.mDepositToSearch = "Salpeter";
            }
            else
            {
                gMisc.ConsoleOut("Could not interpret currentTarget: " + ObjectUtil.toString(event.currentTarget));
                return;
            }
            this.mSelectedTaskType = SPECIALIST_TASK_TYPES.DEPOSIT_SEARCH;
            this.ToggleGeologistButtons(event);
            var _loc_2:* = cSpecialistTask_FindDeposit.GetSearchDurationForDeposit(this.mDepositToSearch) / this.mSpecialist.GetSpecialistDescription().GetTimeBonus() * 100;
            this.mPanel.taskDuration.text = cLocaManager.GetInstance().FormatDuration(_loc_2);
            this.mPanel.btnOK.enabled = true;
            return;
        }// end function

        override public function Hide() : void
        {
            this.mPanel.currentState = "";
            if (this.mLandmark != null)
            {
                this.mGI.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[gCalculations.ConvertPixelPosToStreetGridPos(this.mLandmark.GetXInt(), this.mLandmark.GetYInt())].mLandmark = null;
                this.mLandmark = null;
            }
            this.mDepositToSearch = "";
            switch(this.mSpecialist.GetBaseType())
            {
                case SPECIALIST_TYPE.EXPLORER:
                {
                    this.ToggleExplorerButtons();
                    break;
                }
                case SPECIALIST_TYPE.GEOLOGIST:
                {
                    this.ToggleGeologistButtons();
                    break;
                }
                default:
                {
                    break;
                }
            }
            super.Hide();
            return;
        }// end function

        private function SetCurrentAssignedUnits(event:MouseEvent = null) : void
        {
            var _loc_4:cMilitaryUnitDescription = null;
            var _loc_5:Object = null;
            var _loc_6:cSquad = null;
            var _loc_7:int = 0;
            this.mPanel.btnCommitArmyChanges.enabled = false;
            this.mPanel.btnResetArmyChanges.enabled = false;
            var _loc_2:* = this.mGI.mCurrentPlayerZone.GetArmy(this.mGI.mCurrentPlayer.GetPlayerId()).GetSquads_vector();
            var _loc_3:Array = [];
            for each (_loc_4 in cMilitaryUnitDescription.GetAllUnitDescriptions(true))
            {
                
                _loc_5 = {};
                _loc_5.name_string = _loc_4.GetType_string();
                _loc_5.current = 0;
                _loc_5.available = 0;
                _loc_5.enabled = this.mSpecialist.GetTask() == null;
                for each (_loc_6 in _loc_2)
                {
                    
                    if (_loc_6.GetType_string() == _loc_5.name_string)
                    {
                        _loc_5.available = _loc_5.available + _loc_6.GetAmount();
                    }
                }
                _loc_7 = 0;
                for each (_loc_6 in this.mSpecialist.GetArmy().GetSquads_vector())
                {
                    
                    if (_loc_6.GetType_string() == _loc_5.name_string)
                    {
                        _loc_5.current = _loc_5.current + _loc_6.GetAmount();
                    }
                    _loc_7 = _loc_7 + _loc_5.current;
                }
                _loc_5.available = _loc_5.available + _loc_5.current;
                _loc_3.push(_loc_5);
            }
            this.mPreviousUnitsAmount = _loc_7;
            this.mPanel.manageArmyList.dataProvider = _loc_3;
            this.UpdateUnitsAmounts(null);
            return;
        }// end function

        public function Init(param1:SpecialistPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.close.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.stateGeologist.addEventListener(FlexEvent.ENTER_STATE, this.EnterGeologistState);
            this.mPanel.stateExplorer.addEventListener(FlexEvent.ENTER_STATE, this.EnterExplorerState);
            this.mPanel.stateGeneral.addEventListener(FlexEvent.ENTER_STATE, this.EnterGeneralState);
            this.mPanel.btnCancel.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            return;
        }// end function

        private function ToggleExplorerButtons(event:MouseEvent = null) : void
        {
            this.mPanel.btnExploreSector.selected = false;
            this.mPanel.btnFindWildZone.selected = false;
            this.mPanel.btnFindAdventureShort.selected = false;
            this.mPanel.btnFindAdventureMedium.selected = false;
            this.mPanel.btnFindAdventureLong.selected = false;
            this.mPanel.btnFindTreasureShort.selected = false;
            this.mPanel.btnFindTreasureMedium.selected = false;
            this.mPanel.btnFindTreasureLong.selected = false;
            this.mPanel.btnFindTreasureEvenLonger.selected = false;
            this.mPanel.textExploreSector.setStyle("color", 16777215);
            this.mPanel.textFindWildZone.setStyle("color", 16777215);
            this.mPanel.textFindAdventureZoneShort.setStyle("color", 16777215);
            this.mPanel.textFindAdventureZoneMedium.setStyle("color", 16777215);
            this.mPanel.textFindAdventureZoneLong.setStyle("color", 16777215);
            this.mPanel.textFindTreasureShort.setStyle("color", 16777215);
            this.mPanel.textFindTreasureMedium.setStyle("color", 16777215);
            this.mPanel.textFindTreasureLong.setStyle("color", 16777215);
            this.mPanel.textFindTreasureEvenLonger.setStyle("color", 16777215);
            if (!event)
            {
                return;
            }
            (event.currentTarget as Button).selected = true;
            (this.mPanel["text" + SPECIALIST_TASK_TYPES.toString(this.mSelectedTaskType)] as Text).setStyle("color", 16772864);
            return;
        }// end function

        private function Retreat(event:MouseEvent) : void
        {
            var _loc_2:int = 0;
            if (this.mSpecialist.GetTask() && this.mSpecialist.GetTask() is cSpecialistTask_AttackBuilding)
            {
                _loc_2 = (this.mSpecialist.GetTask() as cSpecialistTask_AttackBuilding).GetArmyDestinationGridIdx();
                this.mGI.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_2].mLandmark = null;
                (this.mSpecialist.GetTask() as cSpecialistTask_AttackBuilding).Retreat();
            }
            this.Hide();
            return;
        }// end function

        private function EnterGeneralState(event:FlexEvent) : void
        {
            var _loc_2:cBuilding = null;
            var _loc_3:Number = NaN;
            var _loc_4:Number = NaN;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            if (this.mSpecialist.GetTask() != null && this.mSpecialist.GetTask() is cSpecialistTask_AttackBuilding)
            {
                _loc_2 = (this.mSpecialist.GetTask() as cSpecialistTask_AttackBuilding).GetArmyDestination();
                if (_loc_2 != null)
                {
                    _loc_3 = _loc_2.GetX();
                    _loc_4 = _loc_2.GetY();
                    _loc_5 = _loc_2.GetBuildingGrid();
                    this.mLandmark = cStreet.CreateFromString(this.mGI.mCurrentPlayer, global.streetGroup, "Street_AttackCursor", this.mGI);
                    this.mLandmark.SetPosition(_loc_3, _loc_4 - global.streetGridYHalf);
                    this.mGI.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_5].mLandmark = this.mLandmark;
                }
            }
            this.mPanel.busy = this.mSpecialist.GetWaitingForServer();
            this.mPanel.btnAttack.enabled = this.mSpecialist.HasUnits() && this.mSpecialist.GetTask() == null;
            this.mPanel.btnAttack.addEventListener(MouseEvent.CLICK, this.AttackBuilding);
            this.mPanel.btnTransfer.enabled = this.mSpecialist.GetTask() == null;
            this.mPanel.btnTransfer.addEventListener(MouseEvent.CLICK, this.MoveGarisson);
            this.mPanel.btnRetreat.enabled = false;
            if (!this.mSpecialist.GetWaitingForServer() && this.mSpecialist.GetTask() != null && this.mSpecialist.GetTask() is cSpecialistTask_AttackBuilding)
            {
                _loc_6 = (this.mSpecialist.GetTask() as cSpecialistTask_AttackBuilding).GetTaskPhase();
                if (_loc_6 == TASK_PHASES_ATTACK_BUILDING.GO_TO_TARGET || _loc_6 == TASK_PHASES_ATTACK_BUILDING.WAIT_AT_TARGET)
                {
                    this.mPanel.btnRetreat.enabled = true;
                }
            }
            this.mPanel.btnRetreat.addEventListener(MouseEvent.CLICK, this.Retreat);
            if (this.mSpecialist.GetTask())
            {
                this.mPanel.currentTask.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SpecialistTask" + this.mSpecialist.GetTask().GetType());
            }
            else
            {
                this.mPanel.currentTask.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SpecialistTaskNone");
            }
            this.mPanel.progress.visible = this.mSpecialist.DisplayTaskProgress();
            if (this.mSpecialist.GetTask())
            {
                this.mPanel.progressProxy.progress = this.mSpecialist.GetTaskProgress();
            }
            this.mPanel.btnCommitArmyChanges.addEventListener(MouseEvent.CLICK, this.CommitArmyChanges);
            this.mPanel.btnResetArmyChanges.addEventListener(MouseEvent.CLICK, this.SetCurrentAssignedUnits);
            this.mPanel.manageArmyList.addEventListener(FlexEvent.DATA_CHANGE, this.UpdateUnitsAmounts);
            this.SetCurrentAssignedUnits();
            return;
        }// end function

        private function EnterExplorerState(event:FlexEvent) : void
        {
            if (this.mPanel.costsHolder.numChildren > 1)
            {
                this.mPanel.costsHolder.removeChildAt(0);
            }
            this.mPanel.taskDuration.text = "";
            this.mPanel.btnOK.removeEventListener(MouseEvent.CLICK, this.SearchSelectedDeposit);
            this.mPanel.btnOK.addEventListener(MouseEvent.CLICK, this.SendExplorer);
            this.mPanel.btnOK.enabled = false;
            this.mPanel.subContentExplorerBase.visible = true;
            this.mPanel.subContentFindAdventure.visible = false;
            this.mPanel.subContentFindTreasure.visible = false;
            this.mPanel.btnExploreSector.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_ExploreSector.PLAYER_LEVEL;
            this.mPanel.btnExploreSector.addEventListener(MouseEvent.CLICK, this.SelectExplorerTask);
            if (this.mPanel.btnExploreSector.enabled)
            {
                this.mPanel.btnExploreSector.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ExploreSector");
            }
            else
            {
                this.mPanel.btnExploreSector.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_ExploreSector.PLAYER_LEVEL.toString()]);
            }
            this.mPanel.btnFindTreasure.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindTreasure.PLAYER_LEVEL_SHORT;
            if (this.mPanel.btnFindTreasure.enabled)
            {
                this.mPanel.btnFindTreasure.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindTreasure");
            }
            else
            {
                this.mPanel.btnFindTreasure.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindTreasure.PLAYER_LEVEL_SHORT.toString()]);
            }
            this.mPanel.btnFindTreasureShort.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindTreasure.PLAYER_LEVEL_SHORT;
            this.mPanel.btnFindTreasureShort.addEventListener(MouseEvent.CLICK, this.SelectExplorerTask);
            if (this.mPanel.btnFindTreasureShort.enabled)
            {
                this.mPanel.btnFindTreasureShort.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "FindTreasureShort");
            }
            else
            {
                this.mPanel.btnFindTreasureShort.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindTreasure.PLAYER_LEVEL_SHORT.toString()]);
            }
            this.mPanel.btnFindTreasureMedium.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindTreasure.PLAYER_LEVEL_MEDIUM;
            this.mPanel.btnFindTreasureMedium.addEventListener(MouseEvent.CLICK, this.SelectExplorerTask);
            if (this.mPanel.btnFindTreasureMedium.enabled)
            {
                this.mPanel.btnFindTreasureMedium.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "FindTreasureMedium");
            }
            else
            {
                this.mPanel.btnFindTreasureMedium.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindTreasure.PLAYER_LEVEL_MEDIUM.toString()]);
            }
            this.mPanel.btnFindTreasureLong.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindTreasure.PLAYER_LEVEL_LONG;
            this.mPanel.btnFindTreasureLong.addEventListener(MouseEvent.CLICK, this.SelectExplorerTask);
            if (this.mPanel.btnFindTreasureLong.enabled)
            {
                this.mPanel.btnFindTreasureLong.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "FindTreasureLong");
            }
            else
            {
                this.mPanel.btnFindTreasureLong.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindTreasure.PLAYER_LEVEL_LONG.toString()]);
            }
            this.mPanel.btnFindTreasureEvenLonger.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindTreasure.PLAYER_LEVEL_EVEN_LONGER;
            this.mPanel.btnFindTreasureEvenLonger.addEventListener(MouseEvent.CLICK, this.SelectExplorerTask);
            if (this.mPanel.btnFindTreasureEvenLonger.enabled)
            {
                this.mPanel.btnFindTreasureEvenLonger.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "FindTreasureEvenLonger");
            }
            else
            {
                this.mPanel.btnFindTreasureEvenLonger.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindTreasure.PLAYER_LEVEL_EVEN_LONGER.toString()]);
            }
            this.mPanel.btnFindWildZone.enabled = false;
            this.mPanel.btnFindWildZone.addEventListener(MouseEvent.CLICK, this.SelectExplorerTask);
            this.mPanel.btnFindWildZone.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ComingSoon");
            this.mPanel.btnFindAdventure.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindEventZone.PLAYER_LEVEL_SHORT;
            if (this.mPanel.btnFindAdventure.enabled)
            {
                this.mPanel.btnFindAdventure.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FindAdventure");
            }
            else
            {
                this.mPanel.btnFindAdventure.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindEventZone.PLAYER_LEVEL_SHORT.toString()]);
            }
            this.mPanel.btnFindAdventureShort.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindEventZone.PLAYER_LEVEL_SHORT;
            this.mPanel.btnFindAdventureShort.addEventListener(MouseEvent.CLICK, this.SelectExplorerTask);
            if (this.mPanel.btnFindAdventureShort.enabled)
            {
                this.mPanel.btnFindAdventureShort.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "FindAdventureShort");
            }
            else
            {
                this.mPanel.btnFindAdventureShort.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindEventZone.PLAYER_LEVEL_SHORT.toString()]);
            }
            this.mPanel.btnFindAdventureMedium.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindEventZone.PLAYER_LEVEL_MEDIUM;
            this.mPanel.btnFindAdventureMedium.addEventListener(MouseEvent.CLICK, this.SelectExplorerTask);
            if (this.mPanel.btnFindAdventureMedium.enabled)
            {
                this.mPanel.btnFindAdventureMedium.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "FindAdventureMedium");
            }
            else
            {
                this.mPanel.btnFindAdventureMedium.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindEventZone.PLAYER_LEVEL_MEDIUM.toString()]);
            }
            this.mPanel.btnFindAdventureLong.enabled = this.mGI.mCurrentPlayer.GetPlayerLevel() >= cSpecialistTask_FindEventZone.PLAYER_LEVEL_LONG;
            this.mPanel.btnFindAdventureLong.addEventListener(MouseEvent.CLICK, this.SelectExplorerTask);
            if (this.mPanel.btnFindAdventureLong.enabled)
            {
                this.mPanel.btnFindAdventureLong.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "FindAdventureLong");
            }
            else
            {
                this.mPanel.btnFindAdventureLong.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [cSpecialistTask_FindEventZone.PLAYER_LEVEL_LONG.toString()]);
            }
            return;
        }// end function

        public function Refresh(param1:cSpecialist) : void
        {
            if (param1 != this.mSpecialist || !this.IsVisible())
            {
                return;
            }
            switch(this.mPanel.currentState)
            {
                case "General":
                {
                    this.EnterGeneralState(null);
                    break;
                }
                case "Geologist":
                {
                    this.EnterGeologistState(null);
                    break;
                }
                case "Explorer":
                {
                    this.EnterExplorerState(null);
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        private function AttackBuilding(event:MouseEvent) : void
        {
            this.mGI.mCurrentCursor.mCurrentSpecialist = this.mSpecialist;
            this.mGI.mCurrentCursor.SetCursorEditMode(COMMAND.ATTACK_BUILDING);
            this.Hide();
            return;
        }// end function

        private function ToggleGeologistButtons(event:MouseEvent = null) : void
        {
            this.mPanel.btnFindDepositBronzeOre.selected = false;
            this.mPanel.btnFindDepositIronOre.selected = false;
            this.mPanel.btnFindDepositCoal.selected = false;
            this.mPanel.btnFindDepositGoldOre.selected = false;
            this.mPanel.btnFindDepositTitaniumOre.selected = false;
            this.mPanel.btnFindDepositStone.selected = false;
            this.mPanel.btnFindDepositGranite.selected = false;
            this.mPanel.btnFindDepositMarble.selected = false;
            this.mPanel.btnFindDepositSalpeter.selected = false;
            this.mPanel.textFindDepositBronzeOre.setStyle("color", 16777215);
            this.mPanel.textFindDepositIronOre.setStyle("color", 16777215);
            this.mPanel.textFindDepositCoal.setStyle("color", 16777215);
            this.mPanel.textFindDepositGoldOre.setStyle("color", 16777215);
            this.mPanel.textFindDepositTitaniumOre.setStyle("color", 16777215);
            this.mPanel.textFindDepositStone.setStyle("color", 16777215);
            this.mPanel.textFindDepositGranite.setStyle("color", 16777215);
            this.mPanel.textFindDepositMarble.setStyle("color", 16777215);
            this.mPanel.textFindDepositSalpeter.setStyle("color", 16777215);
            if (!event)
            {
                return;
            }
            (event.currentTarget as Button).selected = true;
            (this.mPanel["textFindDeposit" + this.mDepositToSearch] as Text).setStyle("color", 16772864);
            return;
        }// end function

    }
}
