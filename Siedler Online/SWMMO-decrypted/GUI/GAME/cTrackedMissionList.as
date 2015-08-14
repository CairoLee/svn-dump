package GUI.GAME
{
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import GUI.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import Interface.*;
    import flash.events.*;
    import mx.core.*;
    import mx.events.*;

    public class cTrackedMissionList extends cGuiBaseElement
    {
        private var clickOffsetY:int;
        private var _itemRendererMap:Object;
        private var mGI:cGameInterface;
        protected var mPanel:TrackedMissionList;
        private var clickOffsetX:int;

        public function cTrackedMissionList()
        {
            this._itemRendererMap = {};
            return;
        }// end function

        private function MouseDownHandler(event:MouseEvent) : void
        {
            this.mPanel.setConstraintValue("right", null);
            this.mPanel.setConstraintValue("top", null);
            this.clickOffsetX = event.target.x + event.localX;
            this.clickOffsetY = event.target.y + event.localY;
            Application.application.addEventListener(MouseEvent.MOUSE_UP, this.MouseUpHandler);
            Application.application.stage.addEventListener(Event.MOUSE_LEAVE, this.MouseUpHandler);
            Application.application.addEventListener(MouseEvent.MOUSE_MOVE, this.MouseMoveHandler);
            return;
        }// end function

        private function MouseUpHandler(event:Event) : void
        {
            Application.application.removeEventListener(MouseEvent.MOUSE_UP, this.MouseUpHandler);
            Application.application.stage.removeEventListener(Event.MOUSE_LEAVE, this.MouseUpHandler);
            Application.application.removeEventListener(MouseEvent.MOUSE_MOVE, this.MouseMoveHandler);
            return;
        }// end function

        public function Init(param1:TrackedMissionList) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.topOrnamental.addEventListener(MouseEvent.MOUSE_DOWN, this.MouseDownHandler);
            this.mPanel.bottomOrnamental.addEventListener(MouseEvent.MOUSE_DOWN, this.MouseDownHandler);
            this.mPanel.addEventListener(ResizeEvent.RESIZE, this.ResizeHandler);
            Application.application.addEventListener(ResizeEvent.RESIZE, this.ResizeHandler);
            return;
        }// end function

        private function MouseMoveHandler(event:MouseEvent) : void
        {
            this.mPanel.x = event.stageX - this.clickOffsetX;
            this.mPanel.y = event.stageY - this.clickOffsetY;
            if (this.mPanel.x < 0)
            {
                this.mPanel.x = 0;
            }
            if (this.mPanel.y < 0)
            {
                this.mPanel.y = 0;
            }
            if (this.mPanel.x > Application.application.stage.stageWidth - this.mPanel.width)
            {
                this.mPanel.x = Application.application.stage.stageWidth - this.mPanel.width;
            }
            if (this.mPanel.y > Application.application.stage.stageHeight - this.mPanel.height)
            {
                this.mPanel.y = Application.application.stage.stageHeight - this.mPanel.height;
            }
            return;
        }// end function

        private function ResizeHandler(event:ResizeEvent) : void
        {
            if (this.mPanel.x < 0)
            {
                this.mPanel.x = 0;
            }
            if (this.mPanel.y < 0)
            {
                this.mPanel.y = 0;
            }
            if (this.mPanel.x > Application.application.stage.stageWidth - this.mPanel.width)
            {
                this.mPanel.x = Application.application.stage.stageWidth - this.mPanel.width;
            }
            if (this.mPanel.y > Application.application.stage.stageHeight - this.mPanel.height)
            {
                this.mPanel.y = Application.application.stage.stageHeight - this.mPanel.height;
            }
            return;
        }// end function

        public function Refresh() : void
        {
            var _loc_1:TrackedMissionItemRenderer = null;
            var _loc_4:dQuestElementVO = null;
            var _loc_5:dAdventureClientInfoVO = null;
            var _loc_6:String = null;
            if (!this.mGI.mQuestClientCallbacks.GetClientQuestPool())
            {
                return;
            }
            var _loc_2:Object = {};
            var _loc_3:int = 0;
            for each (_loc_4 in this.mGI.mQuestClientCallbacks.GetClientQuestPool().mQuestVO_vector)
            {
                
                if (_loc_4.mQuestDefinition != null)
                {
                    if (_loc_4.IsQuestModeAllowedForQuestList())
                    {
                        if (_loc_4.mQuestDefinition.showQuestWindow || _loc_4.mQuestDefinition.showRewardWindow)
                        {
                            if (_loc_4.mIsTrackedMission)
                            {
                                if (this._itemRendererMap[_loc_4.mQuestName_string])
                                {
                                    _loc_1 = this._itemRendererMap[_loc_4.mQuestName_string];
                                }
                                else
                                {
                                    _loc_1 = new TrackedMissionItemRenderer();
                                    this._itemRendererMap[_loc_4.mQuestName_string] = _loc_1;
                                    this.mPanel.list.addChild(_loc_1);
                                }
                                _loc_1.data = _loc_4;
                                _loc_2[_loc_4.mQuestName_string] = _loc_4;
                                _loc_3++;
                            }
                        }
                    }
                }
            }
            for each (_loc_5 in globalFlash.gui.mFriendsList.GetAdventures())
            {
                
                if (_loc_5.isTrackedMission)
                {
                    if (this._itemRendererMap[_loc_5.adventureName + _loc_5.zoneID])
                    {
                        _loc_1 = this._itemRendererMap[_loc_5.adventureName + _loc_5.zoneID];
                    }
                    else
                    {
                        _loc_1 = new TrackedMissionItemRenderer();
                        this._itemRendererMap[_loc_5.adventureName + _loc_5.zoneID] = _loc_1;
                        this.mPanel.list.addChild(_loc_1);
                    }
                    _loc_1.data = _loc_5;
                    _loc_2[_loc_5.adventureName + _loc_5.zoneID] = _loc_5;
                    _loc_3++;
                }
            }
            for (_loc_6 in this._itemRendererMap)
            {
                
                if (!_loc_2[_loc_6])
                {
                    this.mPanel.list.removeChild(this._itemRendererMap[_loc_6]);
                    delete this._itemRendererMap[_loc_6];
                }
            }
            if (this.mPanel.list.numChildren > 0)
            {
                Show();
            }
            else
            {
                Hide();
            }
            return;
        }// end function

    }
}
