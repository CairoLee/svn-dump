package GUI.Components.ItemRenderer
{
    import Communication.VO.*;
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import NewQuestSystem.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class QuestTriggerTooltipItemRenderer extends Canvas
    {
        private var _110371416title:CustomText;
        private var _100313435image:Image;
        private var _documentDescriptor_:UIComponentDescriptor;

        public function QuestTriggerTooltipItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {height:54, childDescriptors:[new UIComponentDescriptor({type:Image, id:"image", stylesFactory:function () : void
                {
                    this.left = "0";
                    this.verticalCenter = "-1";
                    this.horizontalAlign = "center";
                    this.verticalAlign = "middle";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:59, height:51, scaleContent:false};
                }// end function
                }), new UIComponentDescriptor({type:CustomText, id:"title", stylesFactory:function () : void
                {
                    this.left = "58";
                    this.verticalCenter = "0";
                    this.fontWeight = "normal";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:250, selectable:false};
                }// end function
                })]};
            }// end function
            });
            mx_internal::_document = this;
            this.height = 54;
            this.verticalScrollPolicy = "off";
            this.horizontalScrollPolicy = "off";
            this.addEventListener("toolTipCreate", this.___QuestTriggerTooltipItemRenderer_Canvas1_toolTipCreate);
            return;
        }// end function

        private function SetData(event:FlexEvent = null) : void
        {
            var _loc_5:Boolean = false;
            removeEventListener(FlexEvent.CREATION_COMPLETE, this.SetData);
            var _loc_2:* = data.trigger as dQuestTriggerVO;
            var _loc_3:* = data.definition as dQuestDefinitionTriggerVO;
            var _loc_4:* = data.total - Math.max(0, data.remaining);
            if (_loc_3.type == QuestManagerStatic.TYPE_PAY_FOR_QUEST_FINISH)
            {
                _loc_5 = _loc_4 == data.total;
            }
            else
            {
                _loc_5 = _loc_2 && _loc_2.status > 0;
            }
            this.image.source = gAssetManager.GetQuestTriggerIcon(_loc_3, !_loc_5);
            this.title.setStyle("color", _loc_5 ? (10066329) : (16777215));
            this.title.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.QUEST_TRIGGERS, _loc_3.toString(), [_loc_4.toString(), data.total.toString()]);
            return;
        }// end function

        public function set image(param1:Image) : void
        {
            var _loc_2:* = this._100313435image;
            if (_loc_2 !== param1)
            {
                this._100313435image = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "image", _loc_2, param1));
            }
            return;
        }// end function

        public function get image() : Image
        {
            return this._100313435image;
        }// end function

        public function set title(param1:CustomText) : void
        {
            var _loc_2:* = this._110371416title;
            if (_loc_2 !== param1)
            {
                this._110371416title = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "title", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function get title() : CustomText
        {
            return this._110371416title;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            if (param1 == null)
            {
                return;
            }
            if (this.image && this.title)
            {
                this.SetData();
            }
            else
            {
                addEventListener(FlexEvent.CREATION_COMPLETE, this.SetData);
            }
            return;
        }// end function

        public function ___QuestTriggerTooltipItemRenderer_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

    }
}
