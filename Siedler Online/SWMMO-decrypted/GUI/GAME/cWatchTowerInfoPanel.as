package GUI.GAME
{
    import Communication.VO.*;
    import Enums.*;
    import GO.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import Interface.*;
    import MilitarySystem.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import mx.controls.*;
    import mx.events.*;

    public class cWatchTowerInfoPanel extends cBasicInfoPanel
    {
        protected var mBuilding:cBuilding;
        protected var mPanel:WatchTowerInfoPanel;
        private var mGI:cGameInterface;

        public function cWatchTowerInfoPanel()
        {
            return;
        }// end function

        private function RepairBuilding(event:Event) : void
        {
            this.mBuilding.SetRecoveringHitPoints(global.repairRate);
            this.Hide();
            return;
        }// end function

        override public function Hide() : void
        {
            super.Hide();
            return;
        }// end function

        private function CreateKnockDownToolTip(event:ToolTipEvent) : void
        {
            if (this.mBuilding.GetRecurringBuff() != null)
            {
                cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            }
            else
            {
                cToolTipUtil.createToolTip(cToolTipUtil.DEMOLISH_BUILDING_string, event, this.mBuilding);
            }
            return;
        }// end function

        override public function SetData(param1:cBuilding) : void
        {
            var _loc_3:dResource = null;
            var _loc_4:Array = null;
            var _loc_5:Vector.<cSquad> = null;
            var _loc_6:cSquad = null;
            var _loc_7:ResourceItemRenderer = null;
            var _loc_2:* = param1.GetContainerName_string();
            this.mBuilding = param1;
            this.mPanel.label = _loc_2;
            this.mPanel.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, _loc_2);
            this.mPanel.image.source = gAssetManager.GetBuildingIcon(_loc_2);
            if (param1.GetUpgradeDuration() > 0)
            {
                this.mPanel.btnUpgrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "UpgradeWatchtower");
            }
            else
            {
                this.mPanel.btnUpgrade.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "NotPossible");
            }
            this.mPanel.btnUpgrade.enabled = param1.IsUpgradeAllowed(true);
            this.mPanel.btnKnockDown.enabled = param1.IsKnockdownAllowed();
            if (this.mBuilding.GetRecurringBuff() != null)
            {
                this.mPanel.btnKnockDown.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "KnockDownRecurring");
            }
            else
            {
                this.mPanel.btnKnockDown.toolTip = "KnockDown";
            }
            this.mPanel.levelLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Level", [param1.GetUpgradeLevel().toString()]);
            this.mPanel.upgradeTime.text = cLocaManager.GetInstance().FormatDuration(param1.GetUpgradeDuration());
            this.mPanel.upgradeTime.visible = param1.GetUpgradeDuration() > 0;
            this.mPanel.integrity.value = param1.GetHealthBar();
            this.mPanel.btnRepair.enabled = param1.GetRepairCosts().length > 0;
            this.mPanel.costsList.removeAllChildren();
            for each (_loc_3 in param1.GetUpgradeCosts_vector())
            {
                
                _loc_7 = new ResourceItemRenderer();
                _loc_7.data = _loc_3;
                this.mPanel.costsList.addChild(_loc_7);
            }
            _loc_4 = [];
            _loc_5 = this.mBuilding.GetArmy().GetSquads_vector();
            _loc_5.sort(this.SortSquads);
            for each (_loc_6 in _loc_5)
            {
                
                _loc_4.push(_loc_6);
            }
            this.mPanel.unitsList.dataProvider = _loc_4;
            return;
        }// end function

        public function Init(param1:WatchTowerInfoPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnKnockDown.addEventListener(MouseEvent.CLICK, this.ConfirmRemoveBuilding);
            this.mPanel.btnUpgrade.addEventListener(MouseEvent.CLICK, this.UpgradeBuilding);
            this.mPanel.btnKnockDown.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.CreateKnockDownToolTip);
            this.mPanel.stateManageArmy.addEventListener(FlexEvent.ENTER_STATE, this.EnterManageArmyState);
            this.mPanel.btnRepair.addEventListener(MouseEvent.CLICK, this.RepairBuilding);
            return;
        }// end function

        private function UpgradeBuilding(event:Event) : void
        {
            this.mGI.mCurrentPlayerZone.UpgradeBuildingOnGridPosition(this.mBuilding.GetBuildingGrid());
            this.Hide();
            return;
        }// end function

        private function ClosePanel(event:Event) : void
        {
            this.Hide();
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
            this.mPanel.manageUnitsAmountLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "UnitsAttached", [_loc_2.toString(), this.mBuilding.GetMaxMilitaryUnits().toString()]);
            this.mPanel.manageUnitsAmountLabel.setStyle("color", _loc_2 > this.mBuilding.GetMaxMilitaryUnits() ? (16711680) : (16777215));
            this.mPanel.btnCommitArmyChanges.enabled = _loc_2 <= this.mBuilding.GetMaxMilitaryUnits();
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
                    _loc_2.push(new dSquadVO().init(_loc_3.name_string, _loc_3.current, cMilitaryUnitDescription.GetHitPointsForUnit(_loc_3.name_string)));
                }
            }
            cMilitaryUtil.SendRaiseArmyToServer(this.mGI, this.mBuilding, _loc_2);
            this.Refresh();
            return;
        }// end function

        private function SortSquads(param1:cSquad, param2:cSquad) : int
        {
            return param1.GetSortIndex() - param2.GetSortIndex();
        }// end function

        private function ConfirmRemoveBuilding(event:Event) : void
        {
            var _loc_2:* = CustomAlert.show("ConfirmTeardown", "ConfirmTeardown", Alert.CANCEL | Alert.OK, this.mPanel, this.RemoveBuilding);
            _loc_2.addEventListener(CloseEvent.CLOSE, this.RemoveBuilding);
            return;
        }// end function

        private function EnterManageArmyState(event:FlexEvent) : void
        {
            var _loc_4:cMilitaryUnitDescription = null;
            var _loc_5:Object = null;
            var _loc_6:cSquad = null;
            this.mPanel.btnCommitArmyChanges.addEventListener(MouseEvent.CLICK, this.CommitArmyChanges);
            this.mPanel.manageArmyList.addEventListener(FlexEvent.DATA_CHANGE, this.UpdateUnitsAmounts);
            var _loc_2:* = this.mGI.mCurrentPlayerZone.GetArmy(this.mGI.mCurrentPlayer.GetPlayerId()).GetSquads_vector();
            var _loc_3:Array = [];
            for each (_loc_4 in cMilitaryUnitDescription.GetAllUnitDescriptions(true))
            {
                
                _loc_5 = {};
                _loc_5.name_string = _loc_4.GetType_string();
                _loc_5.current = 0;
                _loc_5.available = 0;
                for each (_loc_6 in _loc_2)
                {
                    
                    if (_loc_6.GetType_string() == _loc_5.name_string)
                    {
                        _loc_5.available = _loc_5.available + _loc_6.GetAmount();
                    }
                }
                for each (_loc_6 in this.mBuilding.GetArmy().GetSquads_vector())
                {
                    
                    if (_loc_6.GetType_string() == _loc_5.name_string)
                    {
                        _loc_5.current = _loc_5.current + _loc_6.GetAmount();
                    }
                }
                _loc_5.available = _loc_5.available + _loc_5.current;
                _loc_3.push(_loc_5);
            }
            this.mPanel.manageArmyList.dataProvider = _loc_3;
            return;
        }// end function

        public function Refresh() : void
        {
            if (this.mBuilding)
            {
                this.SetData(this.mBuilding);
            }
            return;
        }// end function

        override public function Show() : void
        {
            this.mPanel.currentState = "";
            super.Show();
            return;
        }// end function

        private function RemoveBuilding(event:CloseEvent) : void
        {
            if (event.detail != Alert.OK)
            {
                return;
            }
            this.mGI.mCurrentPlayerZone.SendDestructBuildingCommand(this.mBuilding.GetBuildingGrid());
            this.Hide();
            return;
        }// end function

    }
}
