package GUI.Components.ToolTips
{
    import Enums.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class ProductionDurationTip extends Canvas implements IDataToolTip
    {
        private var _remainingTime:Number;
        private var _91291148_text:String;
        private var _122527168durationLabel:Label;
        private var _documentDescriptor_:UIComponentDescriptor;

        public function ProductionDurationTip()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:Label, id:"durationLabel", stylesFactory:function () : void
                {
                    this.top = "2";
                    this.bottom = "2";
                    this.left = "5";
                    this.right = "5";
                    this.fontWeight = "bold";
                    this.color = 16777215;
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

        public function get durationLabel() : Label
        {
            return this._122527168durationLabel;
        }// end function

        public function set durationLabel(param1:Label) : void
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
            this._text = param1;
            var _loc_2:* = cLocaManager.GetInstance();
            this.durationLabel.text = this.durationLabel.text + _loc_2.GetText(LOCA_GROUP.LABELS, this._text, [_loc_2.FormatDuration(this._remainingTime)]);
            return;
        }// end function

        public function get text() : String
        {
            return this._text;
        }// end function

        private function get _text() : String
        {
            return this._91291148_text;
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
            this._remainingTime = param1 as Number;
            return;
        }// end function

    }
}
