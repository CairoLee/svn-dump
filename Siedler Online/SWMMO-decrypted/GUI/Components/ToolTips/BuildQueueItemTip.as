package GUI.Components.ToolTips
{
    import Enums.*;
    import GO.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import ServerState.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class BuildQueueItemTip extends Canvas implements IDataToolTip
    {
        private var _1215755049nameLabel:Label;
        private var _building:cBuilding;
        private var _252650492costsList:HBox;
        private var _91291148_text:String;
        private var _122527168durationLabel:CustomText;
        private var _documentDescriptor_:UIComponentDescriptor;

        public function BuildQueueItemTip()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {childDescriptors:[new UIComponentDescriptor({type:Label, id:"nameLabel", stylesFactory:function () : void
                {
                    this.top = "5";
                    this.left = "5";
                    this.right = "5";
                    this.fontWeight = "bold";
                    this.color = 16777215;
                    return;
                }// end function
                }), new UIComponentDescriptor({type:CustomText, id:"durationLabel", stylesFactory:function () : void
                {
                    this.top = "20";
                    this.left = "5";
                    this.right = "5";
                    this.fontWeight = "normal";
                    this.color = 16777215;
                    this.bottom = "5";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:HBox, id:"costsList", stylesFactory:function () : void
                {
                    this.left = "5";
                    this.right = "5";
                    this.top = "26";
                    this.bottom = "5";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {height:25};
                }// end function
                })]};
            }// end function
            });
            mx_internal::_document = this;
            this.mouseEnabled = false;
            this.mouseChildren = false;
            this.styleName = "toolTip";
            return;
        }// end function

        public function get durationLabel() : CustomText
        {
            return this._122527168durationLabel;
        }// end function

        public function get costsList() : HBox
        {
            return this._252650492costsList;
        }// end function

        public function set costsList(param1:HBox) : void
        {
            var _loc_2:* = this._252650492costsList;
            if (_loc_2 !== param1)
            {
                this._252650492costsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "costsList", _loc_2, param1));
            }
            return;
        }// end function

        private function get _text() : String
        {
            return this._91291148_text;
        }// end function

        public function set durationLabel(param1:CustomText) : void
        {
            var _loc_2:* = this._122527168durationLabel;
            if (_loc_2 !== param1)
            {
                this._122527168durationLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "durationLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function set nameLabel(param1:Label) : void
        {
            var _loc_2:* = this._1215755049nameLabel;
            if (_loc_2 !== param1)
            {
                this._1215755049nameLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "nameLabel", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        private function set _text(param1:String) : void
        {
            var _loc_2:* = this._91291148_text;
            if (_loc_2 !== param1)
            {
                this._91291148_text = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "_text", _loc_2, param1));
            }
            return;
        }// end function

        public function set toolTipData(param1:Object) : void
        {
            this._building = param1 as cBuilding;
            return;
        }// end function

        public function get text() : String
        {
            return this._text;
        }// end function

        public function set text(param1:String) : void
        {
            var _loc_3:dResource = null;
            var _loc_4:ResourceItemRenderer = null;
            this._text = param1;
            this.nameLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.BUILDINGS, this._text);
            var _loc_2:Number = 0;
            switch(this._building.GetBuildingMode())
            {
                case cBuilding.BUILDING_MODE_SETTLER_WALKS_TO_BUILDING_GROUND_PLACE:
                case cBuilding.BUILDING_MODE_CONSTRUCTION:
                {
                    this.costsList.visible = false;
                    this.durationLabel.visible = true;
                    _loc_2 = this._building.GetRemainingConstructionDuration();
                    this.durationLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TimeRemaining") + "\n" + cLocaManager.GetInstance().FormatDuration(_loc_2);
                    break;
                }
                default:
                {
                    this.costsList.visible = true;
                    this.costsList.removeAllChildren();
                    for each (_loc_3 in global.buildingGroup.GetCostListFromName_vector(this._text))
                    {
                        
                        _loc_4 = new ResourceItemRenderer();
                        _loc_4.data = _loc_3;
                        this.costsList.addChild(_loc_4);
                    }
                    this.durationLabel.visible = false;
                    break;
                }
            }
            return;
        }// end function

        public function get nameLabel() : Label
        {
            return this._1215755049nameLabel;
        }// end function

    }
}
