package GUI.GAME
{
    import Communication.VO.*;
    import GUI.*;
    import GUI.Components.*;
    import Interface.*;
    import flash.events.*;
    import mx.collections.*;
    import mx.events.*;

    public class cQuestNewQuestSystemList extends cGuiBaseElement implements IEventDispatcher
    {
        private var _bindingEventDispatcher:EventDispatcher;
        private var mGI:cGameInterface;
        protected var mPanel:QuestNewQuestSystemList;
        private var _137831375mResourceProductionWindowDataGridDataProvider:ArrayCollection;

        public function cQuestNewQuestSystemList()
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

        private function ShowClicked(event:Event) : void
        {
            var _loc_3:dQuestElementVO = null;
            if (global.ui.mQuestClientCallbacks.GetClientQuestPool() == null)
            {
                return;
            }
            if (this.mPanel.QUEST_LIST_ID.selectedItem == null)
            {
                return;
            }
            if (!global.ui.IsCurrentPlayerQuestPlayer())
            {
                return;
            }
            var _loc_2:* = this.mPanel.QUEST_LIST_ID.selectedItem.questName;
            for each (_loc_3 in global.ui.mQuestClientCallbacks.GetClientQuestPool().GetQuest_vector())
            {
                
                if (_loc_3.mQuestName_string == _loc_2)
                {
                    global.ui.mQuestClientCallbacks.ShowCurrentQuestWindow(_loc_3, true);
                    break;
                }
            }
            return;
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

        public function Refresh(param1:dQuestPoolVO) : void
        {
            var _loc_4:dQuestElementVO = null;
            var _loc_5:String = null;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:String = null;
            if (param1 == null)
            {
                this.Hide();
            }
            else if (!IsVisible())
            {
                this.Show();
            }
            var _loc_2:* = new Array();
            var _loc_3:int = 0;
            while (_loc_3 < param1.GetQuest_vector().length)
            {
                
                _loc_4 = param1.GetQuest_vector()[_loc_3];
                if (_loc_4.mQuestDefinition != null)
                {
                    if (_loc_4.IsQuestModeAllowedForQuestList())
                    {
                        if (_loc_4.mQuestDefinition.showQuestWindow || _loc_4.mQuestDefinition.showRewardWindow)
                        {
                            _loc_5 = _loc_4.mQuestName_string;
                            _loc_6 = 0;
                            _loc_7 = 0;
                            while (_loc_7 < _loc_4.mQuestTriggersFinished_vector.length)
                            {
                                
                                if (_loc_4.mQuestTriggersFinished_vector[_loc_7] != 0)
                                {
                                    _loc_6++;
                                }
                                _loc_7++;
                            }
                            if (_loc_4.IsInFinishedState())
                            {
                                _loc_8 = "Finished!";
                            }
                            else
                            {
                                _loc_8 = _loc_6 + "/" + _loc_4.mQuestTriggersFinished_vector.length;
                            }
                            _loc_2.push({questName:_loc_5, name:_loc_5, triggers:_loc_8});
                        }
                    }
                }
                _loc_3++;
            }
            this.mPanel.QUEST_LIST_ID.dataProvider = _loc_2;
            return;
        }// end function

        public function get mResourceProductionWindowDataGridDataProvider() : ArrayCollection
        {
            return this._137831375mResourceProductionWindowDataGridDataProvider;
        }// end function

        private function CreationComplete(event:Event) : void
        {
            return;
        }// end function

        override public function Show() : void
        {
            super.Show();
            return;
        }// end function

        private function DropClicked(event:Event) : void
        {
            return;
        }// end function

        override public function Hide() : void
        {
            super.Hide();
            return;
        }// end function

        public function set mResourceProductionWindowDataGridDataProvider(param1:ArrayCollection) : void
        {
            var _loc_2:* = this._137831375mResourceProductionWindowDataGridDataProvider;
            if (_loc_2 !== param1)
            {
                this._137831375mResourceProductionWindowDataGridDataProvider = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mResourceProductionWindowDataGridDataProvider", _loc_2, param1));
            }
            return;
        }// end function

        public function Init(param1:QuestNewQuestSystemList) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.addEventListener(FlexEvent.CREATION_COMPLETE, this.CreationComplete);
            this.mPanel.QUEST_DROP_ID.addEventListener(MouseEvent.CLICK, this.DropClicked);
            this.mPanel.QUEST_SHOW_ID.addEventListener(MouseEvent.CLICK, this.ShowClicked);
            return;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

    }
}
