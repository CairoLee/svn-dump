package GUI.GAME
{
    import BuffSystem.*;
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Loca.*;
    import Interface.*;
    import Specialists.*;
    import flash.events.*;
    import mx.controls.*;
    import mx.events.*;

    public class cMysteryBoxPanel extends cBasicPanel
    {
        private var mBuff:cBuff;
        private var mLM:cLocaManager;
        private var mGI:cGameInterface;
        protected var mPanel:MysteryBoxPanel;

        public function cMysteryBoxPanel()
        {
            this.mLM = cLocaManager.GetInstance();
            return;
        }// end function

        public function SetData(param1:cBuff) : void
        {
            this.mBuff = param1;
            this.mPanel.busyAnim.visible = true;
            this.mPanel.rewardText.text = "";
            this.mPanel.itemsList.removeAllChildren();
            return;
        }// end function

        public function Init(param1:MysteryBoxPanel) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnOK.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            return;
        }// end function

        public function ShowConfirmation() : void
        {
            CustomAlert.show("ConfirmOpenMysteryBox", "ConfirmOpenMysteryBox", Alert.CANCEL | Alert.OK, null, this.OpenMysteryBox);
            return;
        }// end function

        private function ClosePanel(event:Event) : void
        {
            this.Hide();
            return;
        }// end function

        private function OpenMysteryBox(event:CloseEvent) : void
        {
            if (event.detail != Alert.OK)
            {
                return;
            }
            var _loc_2:* = this.mGI.mCurrentCursor.mCurrentBuff;
            this.mGI.SendServerAction(COMMAND.APPLY_BUFF, 0, this.mGI.mCurrentPlayerZone.mStreetDataMap.GetMayorHouse().GetBuildingGrid(), 0, _loc_2.GetUniqueId());
            _loc_2.IncWaitingForServerCount();
            this.mGI.mCurrentCursor.mCurrentBuff = null;
            this.mGI.mCurrentCursor.SetCursorEditMode(COMMAND.SELECT_BUILDING);
            Show();
            return;
        }// end function

        public function SetResult(param1:dLootItemsVO) : void
        {
            var vo:*;
            var item:*;
            var frame:Frame;
            var renderer:StarMenuItemRenderer;
            var _items:* = param1;
            if (!this.mBuff.GetUniqueId().eq(_items.uniqueID))
            {
                return;
            }
            this.mPanel.busyAnim.visible = false;
            var _loc_3:int = 0;
            var _loc_4:* = _items.items;
            while (_loc_4 in _loc_3)
            {
                
                vo = _loc_4[_loc_3];
                if (vo is dResourcesVO && vo.name_string == "XP")
                {
                    item = vo;
                    frame = new Frame();
                    frame.contentType = Frame.CONTENT_TYPE_RESOURCE;
                    frame.amount = vo.amount;
                    frame.content = vo.name_string;
                    frame.toolTip = this.mLM.GetText(LOCA_GROUP.RESOURCES, vo.name_string);
                    frame.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, function (event:ToolTipEvent) : void
            {
                null.createToolTip(null.SIMPLE_string, event);
                return;
            }// end function
            );
                    this.mPanel.itemsList.addChild(frame);
                    continue;
                }
                if (vo is dBuffVO)
                {
                    item = cBuff.CreateBuffFromVO(vo);
                }
                else if (vo is dSpecialistVO)
                {
                    item = cSpecialist.CreateSpecialistFromVO(this.mGI, vo, false);
                }
                renderer = new StarMenuItemRenderer();
                renderer.data = item;
                this.mPanel.itemsList.addChild(renderer);
            }
            this.mPanel.rewardText.text = this.mLM.GetText(LOCA_GROUP.DESCRIPTIONS, "ContentMysteryBox");
            return;
        }// end function

    }
}
