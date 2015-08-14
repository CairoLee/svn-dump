package GUI.GAME
{
    import Enums.*;
    import GO.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import Interface.*;
    import MilitarySystem.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import mx.events.*;

    public class cEnemyBuildingInfoPanel extends cBasicInfoPanel
    {
        protected var mBuilding:cBuilding;
        protected var mPanel:EnemyBuildingInfoPanel;
        private var mGI:cGameInterface;

        public function cEnemyBuildingInfoPanel()
        {
            return;
        }// end function

        private function CreateUpgradeToolTip(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.UPGRADE_BUILDING_string, event, this.mBuilding);
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

        override public function SetData(param1:cBuilding) : void
        {
            var _loc_3:Array = null;
            var _loc_5:cSquad = null;
            var _loc_6:dResource = null;
            var _loc_2:* = param1.GetContainerName_string();
            this.mBuilding = param1;
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.BUILDINGS, _loc_2);
            this.mPanel.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, _loc_2);
            this.mPanel.image.source = gAssetManager.GetBuildingIcon(_loc_2);
            _loc_3 = [];
            var _loc_4:* = this.mBuilding.GetArmy().GetSquads_vector();
            this.mBuilding.GetArmy().GetSquads_vector().sort(this.SortSquads);
            for each (_loc_5 in _loc_4)
            {
                
                _loc_6 = new dResource();
                _loc_6.name_string = _loc_5.GetType_string();
                _loc_6.amount = _loc_5.GetAmount();
                _loc_3.push(_loc_6);
            }
            this.mPanel.unitsList.dataProvider = _loc_3;
            return;
        }// end function

        public function Init(param1:EnemyBuildingInfoPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            return;
        }// end function

        private function ClosePanel(event:Event) : void
        {
            this.Hide();
            return;
        }// end function

        private function SortSquads(param1:cSquad, param2:cSquad) : int
        {
            return param1.GetSortIndex() - param2.GetSortIndex();
        }// end function

        private function RemoveBuilding(event:Event) : void
        {
            this.mGI.mCurrentPlayerZone.SendDestructBuildingCommand(this.mBuilding.GetBuildingGrid());
            this.Hide();
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
            super.Show();
            return;
        }// end function

        private function UpgradeBuilding(event:Event) : void
        {
            this.mGI.mCurrentPlayerZone.UpgradeBuildingOnGridPosition(this.mBuilding.GetBuildingGrid());
            this.Hide();
            return;
        }// end function

    }
}
