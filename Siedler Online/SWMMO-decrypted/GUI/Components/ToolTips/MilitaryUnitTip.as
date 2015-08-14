package GUI.Components.ToolTips
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class MilitaryUnitTip extends Canvas implements IToolTip
    {
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _1115058732headline:Label;
        private var _text:String;
        private var _1724546052description:CustomText;

        public function MilitaryUnitTip()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:180, childDescriptors:[new UIComponentDescriptor({type:Label, id:"headline", stylesFactory:function () : void
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
                    this.bottom = "5";
                    return;
                }// end function
                })]};
            }// end function
            });
            mx_internal::_document = this;
            this.mouseEnabled = false;
            this.mouseChildren = false;
            this.width = 180;
            this.styleName = "toolTip";
            return;
        }// end function

        public function set text(param1:String) : void
        {
            this._text = param1;
            this.headline.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, this._text);
            this.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, this._text);
            return;
        }// end function

        public function get description() : CustomText
        {
            return this._1724546052description;
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

        public function get headline() : Label
        {
            return this._1115058732headline;
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

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

    }
}
