package GUI.GAME
{
    import BuffSystem.*;
    import Enums.*;
    import GO.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import Interface.*;
    import Specialists.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import mx.collections.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class cStarMenu extends cBasicPanel
    {
        private var selectedBuff:cBuff;
        private var mGI:cGameInterface;
        private var mResetScrollPosition:Boolean;
        protected var mPanel:StarMenu;
        private var selectedSpecialist:cSpecialist;
        private var mSpecialists:Vector.<cSpecialist>;
        private var mSelectedGroup:int;
        private static const GROUP_BUFFS:int = 2;
        private static const GROUP_ALL:int = 0;
        private static const GROUP_RESOURCES:int = 3;
        public static const CLICK_ITEM:String = "CLICK_ITEM";
        public static const CLICK_DELETE_BUTTON:String = "CLICK_DELETE_BUTTON";
        private static const GROUP_SPECIALISTS:int = 1;
        private static const GROUP_BUILDINGS:int = 4;

        public function cStarMenu()
        {
            return;
        }// end function

        private function ActivateBuff() : void
        {
            var _loc_1:* = this.selectedBuff;
            this.selectedBuff = null;
            this.mGI.mCurrentCursor.mCurrentBuff = _loc_1;
            if (_loc_1.GetBuffDefinition().GetName_string() == "BuildBuilding")
            {
                this.mGI.mCurrentCursor.SetCursorEditMode(COMMAND.SET_BUILDING_BY_BUFF);
                this.mGI.mCurrentCursor.SetCursor(OBJECTTYPE.BUILDING, _loc_1.GetResourceName_string());
            }
            else if (_loc_1.GetBuffDefinition().GetName_string().indexOf("Loottable") == 0)
            {
                globalFlash.gui.mMysteryBoxPanel.SetData(_loc_1);
                globalFlash.gui.mMysteryBoxPanel.ShowConfirmation();
            }
            else if (_loc_1.GetType_string() == "Adventure")
            {
                globalFlash.gui.mAdventurePanel.SetName(_loc_1.GetResourceName_string());
                globalFlash.gui.mAdventurePanel.Show();
            }
            else if (_loc_1.GetType_string() == "PermanentBuildQueueSlot")
            {
                CustomAlert.show("ConfirmAddPermBuildQueueSlot", "ConfirmAddPermBuildQueueSlot", Alert.OK | Alert.CANCEL, null, this.AddPermBuildQueueSlot, null, 4, true);
            }
            else
            {
                this.mGI.mCurrentCursor.SetCursorEditMode(COMMAND.APPLY_BUFF);
            }
            this.Hide();
            return;
        }// end function

        private function ClosePanel(event:MouseEvent) : void
        {
            this.Hide();
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

        private function AddPermBuildQueueSlot(event:CloseEvent) : void
        {
            if (event.detail != Alert.OK)
            {
                return;
            }
            var _loc_2:* = this.mGI.mCurrentCursor.mCurrentBuff;
            this.mGI.SendServerAction(COMMAND.APPLY_BUFF, 0, this.mGI.mCurrentPlayerZone.mStreetDataMap.GetMayorHouse().GetBuildingGrid(), 0, _loc_2.GetUniqueId());
            this.mGI.mCurrentCursor.mCurrentBuff = null;
            return;
        }// end function

        private function ItemClick(event:ItemClickEvent) : void
        {
            var _loc_2:cSpecialist = null;
            var _loc_3:int = 0;
            if (!event.item || this.selectedBuff || this.selectedSpecialist)
            {
                return;
            }
            if (event.item is cSpecialist)
            {
                _loc_2 = event.item as cSpecialist;
                _loc_3 = _loc_2.GetGarrisonGridIdx();
                if (Application.application.mGeneralInterface.mCurrentPlayerZone.IsPositionInsideZoneGridPos(_loc_3))
                {
                    Application.application.mGeneralInterface.mCurrentPlayerZone.ScrollToGrid(_loc_2.GetGarrisonGridIdx());
                }
                if (_loc_2.GetBaseType() == SPECIALIST_TYPE.GENERAL && _loc_2.GetGarrison() == null && _loc_2.GetTask() == null)
                {
                    this.selectedSpecialist = _loc_2;
                    this.MoveGarisson();
                }
                else if (_loc_2.GetBaseType() == SPECIALIST_TYPE.GENERAL)
                {
                    if (_loc_2.GetGarrison())
                    {
                        this.mGI.SelectBuilding(_loc_2.GetGarrison());
                    }
                }
                else if (_loc_2.GetTask() == null)
                {
                    globalFlash.gui.mSpecialistPanel.SetData(_loc_2);
                    globalFlash.gui.mSpecialistPanel.Show();
                }
                else if (_loc_2.DisplayTaskProgress() && _loc_2.GetType() != SPECIALIST_TYPE.TMP_ARMY_TRANSPORTER)
                {
                    globalFlash.gui.mSpecialistCooldownPanel.SetData(_loc_2);
                    globalFlash.gui.mSpecialistCooldownPanel.Show();
                }
            }
            else if (event.item is cBuff)
            {
                if (!(event.item as cBuff).GetWaitingForServer())
                {
                    this.selectedBuff = event.item as cBuff;
                    this.ActivateBuff();
                }
            }
            return;
        }// end function

        private function FilterList(event:ItemClickEvent) : void
        {
            var _loc_2:* = event ? (event.index) : (0);
            this.mSelectedGroup = (this.mPanel.buttonBar.dataProvider as ArrayCollection).getItemAt(_loc_2).group as int;
            this.ResetScrollPosition();
            this.Refresh();
            return;
        }// end function

        private function RemoveBuff(event:CloseEvent) : void
        {
            if (!this.selectedBuff)
            {
                return;
            }
            var _loc_2:* = this.selectedBuff;
            this.selectedBuff = null;
            if (event.detail != Alert.OK)
            {
                return;
            }
            _loc_2.SetWaitingForServer();
            globalFlash.gui.mStarMenu.Refresh();
            this.mGI.SendServerAction(COMMAND.REMOVE_BUFF, 0, 0, 0, _loc_2.GetUniqueId());
            return;
        }// end function

        override public function Show() : void
        {
            globalFlash.gui.mActionBar.HideStarAnim();
            this.Refresh();
            super.Show();
            return;
        }// end function

        private function MoveGarisson() : void
        {
            this.mGI.UnselectBuilding();
            this.mGI.mCurrentCursor.mCurrentSpecialist = this.selectedSpecialist;
            this.mGI.mCurrentCursor.SetCursorEditMode(COMMAND.MOVE_GARISSON);
            this.selectedSpecialist = null;
            this.Hide();
            return;
        }// end function

        public function ResetScrollPosition() : void
        {
            this.mResetScrollPosition = true;
            return;
        }// end function

        public function Init(param1:StarMenu) : void
        {
            this.mGI = global.ui as cGameInterface;
            openSound = "MenuOpenStar";
            AddBaseElement(param1);
            this.mPanel = param1;
            this.selectedSpecialist = null;
            this.selectedBuff = null;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.mPanel.addEventListener(cStarMenu.CLICK_ITEM, this.ItemClick);
            this.mPanel.addEventListener(cStarMenu.CLICK_DELETE_BUTTON, this.RemoveButtonClick);
            this.mPanel.buttonBar.addEventListener(ListEvent.ITEM_CLICK, this.FilterList);
            this.mPanel.buttonBar.dataProvider = [{label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "All"), group:cStarMenu.GROUP_ALL}, {label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Specialists"), group:cStarMenu.GROUP_SPECIALISTS}, {label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Buffs"), group:cStarMenu.GROUP_BUFFS}, {label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Resources"), group:cStarMenu.GROUP_RESOURCES}, {label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Misc"), group:cStarMenu.GROUP_BUILDINGS}];
            return;
        }// end function

        private function RemoveButtonClick(event:ItemClickEvent) : void
        {
            var _loc_2:String = null;
            if (!event.item || this.selectedBuff)
            {
                return;
            }
            this.selectedBuff = event.item as cBuff;
            if (this.selectedBuff.GetBuffDefinition().GetName_string() == "Adventure")
            {
                _loc_2 = cLocaManager.GetInstance().GetText(LOCA_GROUP.ADVENTURE_NAME, this.selectedBuff.GetResourceName_string());
            }
            else
            {
                _loc_2 = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, this.selectedBuff.GetType_string(), [this.selectedBuff.GetAmount(), this.selectedBuff.GetResourceName_string()]);
            }
            CustomAlert.show(cLocaManager.GetInstance().GetText(LOCA_GROUP.ALERT_MESSAGES, "ConfirmRemoveBuff", [_loc_2]), cLocaManager.GetInstance().GetText(LOCA_GROUP.ALERT_TITLES, "ConfirmRemoveBuff"), Alert.OK | Alert.CANCEL, null, this.RemoveBuff, null, 4, false);
            return;
        }// end function

        public function Refresh() : void
        {
            var _loc_5:cBuff = null;
            var _loc_8:cSpecialist = null;
            var _loc_9:int = 0;
            var _loc_10:cGOSpriteLibContainer = null;
            var _loc_1:* = this.mPanel.itemList.verticalScrollPosition;
            var _loc_2:Array = [];
            if (this.mSelectedGroup == cStarMenu.GROUP_ALL || this.mSelectedGroup == cStarMenu.GROUP_SPECIALISTS)
            {
                for each (_loc_8 in this.mGI.mCurrentPlayerZone.GetSpecialists_vector())
                {
                    
                    if (_loc_8.GetPlayerID() == this.mGI.mCurrentPlayer.GetPlayerId())
                    {
                        _loc_2.push(_loc_8);
                    }
                }
                _loc_2.sort(this.SortSpecialistList);
            }
            var _loc_3:* = new Vector.<cBuff>;
            var _loc_4:* = this.mGI.getZoneTypes(this.mGI.mCurrentPlayer.GetPlayerId());
            for each (_loc_5 in this.mGI.mCurrentPlayer.mAvailableBuffs_vector)
            {
                
                if ((_loc_4 & _loc_5.GetBuffDefinition().getTargetZoneTypes()) > 0)
                {
                    _loc_3.push(_loc_5);
                }
            }
            if (this.mSelectedGroup == cStarMenu.GROUP_ALL || this.mSelectedGroup == cStarMenu.GROUP_BUFFS)
            {
                for each (_loc_5 in _loc_3)
                {
                    
                    if (!(_loc_5.GetRemaining() == 0 && _loc_5.GetAmount() > 0) && _loc_5.GetBuffDefinition().GetName_string() != "BuildBuilding" && _loc_5.GetBuffDefinition().GetName_string() != "Adventure" && _loc_5.GetBuffDefinition().GetName_string().indexOf("AddResource") == -1 && _loc_5.GetBuffDefinition().GetName_string().indexOf("FillDeposit") == -1)
                    {
                        _loc_5.MarkAsDeletable();
                        _loc_2.push(_loc_5);
                    }
                }
            }
            if (this.mSelectedGroup == cStarMenu.GROUP_ALL || this.mSelectedGroup == cStarMenu.GROUP_RESOURCES)
            {
                for each (_loc_5 in _loc_3)
                {
                    
                    if (!(_loc_5.GetRemaining() == 0 && _loc_5.GetAmount() > 0) && (_loc_5.GetBuffDefinition().GetName_string().indexOf("AddResource") > -1 || _loc_5.GetBuffDefinition().GetName_string().indexOf("FillDeposit") > -1))
                    {
                        _loc_5.MarkAsDeletable();
                        _loc_2.push(_loc_5);
                    }
                }
            }
            if (this.mSelectedGroup == cStarMenu.GROUP_ALL || this.mSelectedGroup == cStarMenu.GROUP_BUILDINGS)
            {
                for each (_loc_5 in _loc_3)
                {
                    
                    if (!(_loc_5.GetRemaining() == 0 && _loc_5.GetAmount() > 0) && _loc_5.GetBuffDefinition().GetName_string() == "BuildBuilding" || _loc_5.GetBuffDefinition().GetName_string() == "Adventure")
                    {
                        _loc_9 = global.buildingGroup.GetNrFromName(_loc_5.GetResourceName_string());
                        _loc_10 = global.buildingGroup.GetGoSpriteLibContainerFromNr(_loc_9);
                        if (_loc_5.GetBuffDefinition().GetName_string() != "BuildBuilding" || _loc_10.mEnumGoSubType == GO_SUBTYPE.DECORATION)
                        {
                            _loc_5.MarkAsDeletable();
                        }
                        _loc_2.push(_loc_5);
                    }
                }
            }
            var _loc_6:int = 0;
            if (_loc_2.length < 18)
            {
                _loc_6 = 18 - _loc_2.length;
            }
            else
            {
                _loc_6 = 6 - _loc_2.length % 6;
            }
            var _loc_7:int = 0;
            while (_loc_7 < _loc_6)
            {
                
                _loc_2.push(null);
                _loc_7++;
            }
            this.mPanel.itemList.dataProvider = _loc_2;
            if (_loc_1 > 0 && !this.mResetScrollPosition)
            {
                this.mPanel.itemList.verticalScrollPosition = _loc_1;
            }
            this.mResetScrollPosition = false;
            return;
        }// end function

    }
}
