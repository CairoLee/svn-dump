package GUI.Components.ToolTips
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import MilitarySystem.*;
    import ServerState.*;
    import Specialists.*;
    import flash.events.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class SendArmyTip extends Canvas implements IDataToolTip
    {
        private var _text:String;
        private var _1415192613armyList:TileList;
        private var _specialist:cSpecialist;
        private var _1724546052description:CustomText;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _1115058732headline:Label;

        public function SendArmyTip()
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
                    return;
                }// end function
                }), new UIComponentDescriptor({type:CustomText, id:"description", stylesFactory:function () : void
                {
                    this.color = 16777215;
                    this.left = "5";
                    this.right = "5";
                    this.top = "26";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:TileList, id:"armyList", stylesFactory:function () : void
                {
                    this.top = "68";
                    this.bottom = "5";
                    this.left = "5";
                    this.right = "5";
                    this.paddingTop = 0;
                    this.paddingBottom = 0;
                    this.paddingLeft = 0;
                    this.paddingRight = 0;
                    this.backgroundAlpha = 0;
                    this.borderThickness = 0;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:3, columnWidth:70, rowHeight:40, width:210, height:120, itemRenderer:_SendArmyTip_ClassFactory1_c()};
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

        private function CreateDescription() : String
        {
            var _loc_1:String = "";
            _loc_1 = _loc_1 + (cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CurrentMission") + " ");
            if (this._specialist.GetTask())
            {
                _loc_1 = _loc_1 + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SpecialistTask" + this._specialist.GetTask().GetType());
            }
            else
            {
                _loc_1 = _loc_1 + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "SpecialistTaskNone");
            }
            if (this._specialist.GetTask() && this._specialist.GetTask().GetRemainingTime() > -1)
            {
                _loc_1 = _loc_1 + ("\n" + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TimeRemaining") + " " + cLocaManager.GetInstance().FormatDuration(this._specialist.GetTask().GetRemainingTime()));
            }
            return _loc_1;
        }// end function

        public function get description() : CustomText
        {
            return this._1724546052description;
        }// end function

        private function SetData(event:Event = null) : void
        {
            var _loc_2:dResource = null;
            var _loc_4:cMilitaryUnitDescription = null;
            var _loc_5:cSquad = null;
            var _loc_3:Array = [];
            for each (_loc_4 in cMilitaryUnitDescription.GetAllUnitDescriptions(true))
            {
                
                _loc_2 = new dResource();
                _loc_2.group_string = RESOURCE_GROUP.MILITARY;
                _loc_2.name_string = _loc_4.GetType_string();
                _loc_2.amount = 0;
                _loc_3.push(_loc_2);
            }
            for each (_loc_5 in this._specialist.GetArmy().GetSquads_vector())
            {
                
                for each (_loc_2 in _loc_3)
                {
                    
                    if (_loc_2.name_string == _loc_5.GetType_string())
                    {
                        _loc_2.amount = _loc_5.GetAmount();
                        break;
                    }
                }
            }
            this.armyList.dataProvider = _loc_3;
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

        public function set text(param1:String) : void
        {
            this._text = param1;
            this.headline.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.SPECIALISTS, this._text);
            this.description.text = this.CreateDescription();
            return;
        }// end function

        public function get armyList() : TileList
        {
            return this._1415192613armyList;
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

        public function get text() : String
        {
            return this._text;
        }// end function

        public function set toolTipData(param1:Object) : void
        {
            this._specialist = param1 as cSpecialist;
            if (this.armyList)
            {
                this.SetData();
            }
            else
            {
                this.addEventListener(FlexEvent.CREATION_COMPLETE, this.SetData);
            }
            return;
        }// end function

        public function set description(param1:CustomText) : void
        {
            var _loc_2:* = this._1724546052description;
            if (_loc_2 !== param1)
            {
                this._1724546052description = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "description", _loc_2, param1));
            }
            return;
        }// end function

        private function _SendArmyTip_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = TradeResourceItemRenderer;
            return _loc_1;
        }// end function

        public function set armyList(param1:TileList) : void
        {
            var _loc_2:* = this._1415192613armyList;
            if (_loc_2 !== param1)
            {
                this._1415192613armyList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "armyList", _loc_2, param1));
            }
            return;
        }// end function

    }
}
