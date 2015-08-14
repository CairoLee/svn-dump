package GUI.Components.ToolTips
{
    import BuffSystem.*;
    import Enums.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import MilitarySystem.*;
    import TimedProduction.*;
    import mx.containers.*;
    import mx.core.*;
    import mx.events.*;

    public class TimedProductionOrderTip extends Canvas implements IDataToolTip
    {
        private var _91291148_text:String;
        private var _122527168durationLabel:CustomText;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _production:cTimedProduction;

        public function TimedProductionOrderTip()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:250, childDescriptors:[new UIComponentDescriptor({type:CustomText, id:"durationLabel", stylesFactory:function () : void
                {
                    this.top = "5";
                    this.left = "5";
                    this.right = "5";
                    this.fontWeight = "normal";
                    this.color = 16777215;
                    this.bottom = "5";
                    return;
                }// end function
                })]};
            }// end function
            });
            mx_internal::_document = this;
            this.width = 250;
            this.mouseEnabled = false;
            this.mouseChildren = false;
            this.styleName = "toolTip";
            return;
        }// end function

        public function get durationLabel() : CustomText
        {
            return this._122527168durationLabel;
        }// end function

        private function get _text() : String
        {
            return this._91291148_text;
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

        public function set text(param1:String) : void
        {
            var _loc_6:String = null;
            var _loc_7:cTimedProductionQueue = null;
            var _loc_8:cTimedProduction = null;
            var _loc_9:int = 0;
            this._text = param1;
            var _loc_2:* = cLocaManager.GetInstance();
            var _loc_3:Number = 0;
            var _loc_4:Number = 0;
            var _loc_5:Number = 0;
            if (this._production.GetProductionOrder() is cBuffProductionOrder)
            {
                _loc_7 = global.ui.mCurrentPlayerZone.GetBuffProductionQueue();
                _loc_6 = "NextBuff";
            }
            else if (this._production.GetProductionOrder() is cMilitaryUnitProductionOrder)
            {
                _loc_7 = global.ui.mCurrentPlayerZone.GetMilitaryUnitRecruitments();
                _loc_6 = "NextUnit";
            }
            for each (_loc_8 in _loc_7.mTimedProductions_vector)
            {
                
                _loc_9 = global.ui.mGlobalTimeScale * _loc_8.GetProductionOrder().GetTimeBonus(global.ui);
                if (_loc_8.HasStarted())
                {
                    _loc_3 = (_loc_8.GetProductionTime() - _loc_8.GetCollectedTime()) / _loc_9;
                    _loc_4 = (_loc_8.GetAmount() - _loc_8.GetProducedItems() - 1) * _loc_8.GetProductionTime() / _loc_9;
                    _loc_5 = _loc_5 + (_loc_4 + _loc_3);
                }
                else
                {
                    _loc_4 = _loc_8.GetAmount() * _loc_8.GetProductionTime() / _loc_9;
                    _loc_5 = _loc_5 + _loc_4;
                }
                if (_loc_8 == this._production)
                {
                    if (_loc_8.HasStarted())
                    {
                        this.durationLabel.text = _loc_2.GetText(LOCA_GROUP.LABELS, _loc_6, [_loc_2.FormatDuration(_loc_3)]);
                    }
                    this.durationLabel.text = this.durationLabel.text + _loc_2.GetText(LOCA_GROUP.LABELS, "OrderCompleted", [_loc_2.FormatDuration(_loc_5)]);
                    break;
                }
            }
            return;
        }// end function

        public function get text() : String
        {
            return this._text;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function set toolTipData(param1:Object) : void
        {
            this._production = param1 as cTimedProduction;
            return;
        }// end function

    }
}
