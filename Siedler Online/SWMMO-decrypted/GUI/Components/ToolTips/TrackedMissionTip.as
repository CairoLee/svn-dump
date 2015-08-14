package GUI.Components.ToolTips
{
    import Communication.VO.*;
    import Enums.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import Interface.*;
    import NewQuestSystem.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class TrackedMissionTip extends Canvas implements IDataToolTip
    {
        private var _gi:cGameInterface;
        private var _text:String;
        private var _quest:dQuestElementVO;
        private var _681189770triggerList:VBox;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _1115058732headline:Label;

        public function TrackedMissionTip()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {childDescriptors:[new UIComponentDescriptor({type:Label, id:"headline", stylesFactory:function () : void
                {
                    null.top = this;
                    this.left = "5";
                    this.right = "5";
                    this.fontWeight = "bold";
                    this.color = 16777215;
                    this.textAlign = "center";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    this.left = "5";
                    this.right = "5";
                    this.top = "25";
                    this.backgroundColor = 12303291;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:1};
                }// end function
                }), new UIComponentDescriptor({type:VBox, id:"triggerList", stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "5";
                    this.bottom = "5";
                    this.top = "28";
                    return;
                }// end function
                })]};
            }// end function
            });
            mx_internal::_document = this;
            this.styleName = "toolTip";
            this.mouseEnabled = false;
            this.mouseChildren = false;
            return;
        }// end function

        private function SetData(event:FlexEvent = null) : void
        {
            var _loc_3:dQuestDefinitionTriggerVO = null;
            var _loc_4:dQuestTriggerVO = null;
            var _loc_5:int = 0;
            var _loc_6:Object = null;
            var _loc_7:QuestTriggerTooltipItemRenderer = null;
            var _loc_8:int = 0;
            this._gi = global.ui as cGameInterface;
            this.removeEventListener(FlexEvent.CREATION_COMPLETE, this.SetData);
            var _loc_2:int = 0;
            while (_loc_2 < this._quest.mQuestDefinition.questTriggers_vector.length)
            {
                
                _loc_3 = this._quest.mQuestDefinition.questTriggers_vector[_loc_2];
                _loc_4 = this._quest.mQuestTriggersFinished_vector[_loc_2];
                if (_loc_3.type == QuestManagerStatic.TYPE_PAY_FOR_QUEST_FINISH)
                {
                    _loc_8 = _loc_3.amount - this._gi.mCurrentPlayerZone.GetResources(this._gi.mCurrentPlayer).GetPlayerResource(_loc_3.name_string).amount;
                }
                else
                {
                    _loc_8 = this._gi.mQuestClientCallbacks.GetRemainingValuesForQuestTrigger(this._gi.mCurrentPlayer, this._quest, _loc_2);
                }
                _loc_5 = this._gi.mQuestClientCallbacks.GetTotalValuesForQuestTrigger(this._gi.mCurrentPlayer, this._quest, _loc_2);
                _loc_6 = {definition:_loc_3, trigger:_loc_4, remaining:_loc_8, total:_loc_5};
                _loc_7 = new QuestTriggerTooltipItemRenderer();
                _loc_7.data = _loc_6;
                this.triggerList.addChild(_loc_7);
                _loc_2++;
            }
            return;
        }// end function

        public function get headline() : Label
        {
            return this._1115058732headline;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function set toolTipData(param1:Object) : void
        {
            this._quest = param1 as dQuestElementVO;
            if (this.headline)
            {
                this.SetData();
            }
            else
            {
                this.addEventListener(FlexEvent.CREATION_COMPLETE, this.SetData);
            }
            return;
        }// end function

        public function set text(param1:String) : void
        {
            this._text = param1;
            this.headline.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.QUEST_LABELS, this._text);
            return;
        }// end function

        public function get text() : String
        {
            return this._text;
        }// end function

        public function set headline(param1:Label) : void
        {
            var _loc_2:* = this._1115058732headline;
            if (_loc_2 !== param1)
            {
                this._1115058732headline = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "headline", _loc_2, param1));
            }
            return;
        }// end function

        public function set triggerList(param1:VBox) : void
        {
            var _loc_2:* = this._681189770triggerList;
            if (_loc_2 !== param1)
            {
                this._681189770triggerList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "triggerList", _loc_2, param1));
            }
            return;
        }// end function

        public function get triggerList() : VBox
        {
            return this._681189770triggerList;
        }// end function

    }
}
