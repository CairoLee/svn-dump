package GUI.GAME
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Loca.*;
    import Interface.*;
    import Specialists.*;
    import flash.events.*;
    import mx.collections.*;
    import mx.events.*;

    public class cSpecialistTravelPanel extends cBasicPanel
    {
        private var mTargetZoneId:int;
        private var mGI:cGameInterface;
        protected var mPanel:SpecialistTravelPanel;
        private var mSelectedSpecialist:cSpecialist;

        public function cSpecialistTravelPanel()
        {
            return;
        }// end function

        private function SendSpecialist(event:MouseEvent) : void
        {
            this.mSelectedSpecialist.SetTask(new cSpecialistTask_WaitForConfirmation(this.mGI, this.mSelectedSpecialist, 0));
            this.mGI.SendServerAction(COMMAND.SET_TASK, SPECIALIST_TASK_TYPES.TRAVEL_TO_ZONE, this.mGI.mCurrentPlayer.mIsAdventureZone && this.mTargetZoneId == this.mGI.mCurrentViewedZoneID ? (this.mGI.mCurrentPlayer.GetHomeZoneId()) : (this.mTargetZoneId), 0, this.mSelectedSpecialist.GetUniqueID());
            this.Hide();
            return;
        }// end function

        public function SetData(param1:int) : void
        {
            var _loc_3:cSpecialist = null;
            this.mTargetZoneId = param1;
            this.mPanel.label = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SendArmy");
            var _loc_2:Array = [];
            this.mSelectedSpecialist = null;
            this.ClearHighlights();
            for each (_loc_3 in this.mGI.mCurrentPlayerZone.GetSpecialists_vector())
            {
                
                if (_loc_3.GetPlayerID() == this.mGI.mCurrentPlayer.GetPlayerId() && _loc_3.GetTask() == null && _loc_3.GetBaseType() == SPECIALIST_TYPE.GENERAL)
                {
                    _loc_2.push(_loc_3);
                }
            }
            _loc_2.sort(this.SortSpecialistList);
            this.mPanel.availabelSpecialists.dataProvider = _loc_2;
            this.mPanel.btnOK.enabled = false;
            return;
        }// end function

        private function SortSpecialistList(param1:cSpecialist, param2:cSpecialist) : Number
        {
            var _loc_3:* = param1.GetSortIndex();
            var _loc_4:* = param2.GetSortIndex();
            if (_loc_3 > _loc_4)
            {
                return 1;
            }
            if (_loc_3 < _loc_4)
            {
                return -1;
            }
            return 0;
        }// end function

        public function Init(param1:SpecialistTravelPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnCancel.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.btnOK.addEventListener(MouseEvent.CLICK, this.SendSpecialist);
            this.mPanel.availabelSpecialists.addEventListener(ListEvent.ITEM_CLICK, this.SelectSpecialist);
            return;
        }// end function

        public function ClosePanel(event:MouseEvent) : void
        {
            this.Hide();
            return;
        }// end function

        private function SelectSpecialist(event:ListEvent) : void
        {
            this.ClearHighlights();
            this.mSelectedSpecialist = this.mPanel.availabelSpecialists.selectedItem as cSpecialist;
            this.mPanel.btnOK.enabled = this.mSelectedSpecialist != null;
            if (!this.mSelectedSpecialist)
            {
                return;
            }
            var _loc_2:* = cSpecialistTask_TravelToZone.TIME_TO_TRAVEL_TO_ZONE / this.mSelectedSpecialist.GetSpecialistDescription().GetTimeBonus() * 100;
            this.mPanel.taskDuration.text = cLocaManager.GetInstance().FormatDuration(_loc_2);
            var _loc_3:* = event.itemRenderer as SpecialistTravelItemRenderer;
            _loc_3.selected = true;
            return;
        }// end function

        private function ClearHighlights() : void
        {
            var _loc_2:SpecialistTravelItemRenderer = null;
            if (!this.mPanel.availabelSpecialists.dataProvider)
            {
                return;
            }
            var _loc_1:int = 0;
            while (_loc_1 < (this.mPanel.availabelSpecialists.dataProvider as ArrayCollection).length)
            {
                
                _loc_2 = this.mPanel.availabelSpecialists.indexToItemRenderer(_loc_1) as SpecialistTravelItemRenderer;
                if (_loc_2)
                {
                    _loc_2.selected = false;
                }
                _loc_1++;
            }
            return;
        }// end function

        override public function Show() : void
        {
            super.Show();
            return;
        }// end function

    }
}
