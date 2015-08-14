package GUI.Components.ItemRenderer
{
    import flash.events.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class FriendsListMenuItemRenderer extends Canvas
    {
        private var _2135689121itemLabel:Label;
        private var _text:String;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var listeners:Array;

        public function FriendsListMenuItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {height:20, childDescriptors:[new UIComponentDescriptor({type:Label, id:"itemLabel", stylesFactory:function () : void
                {
                    null.horizontalCenter = this;
                    this.verticalCenter = "0";
                    this.textAlign = "center";
                    this.color = 4601379;
                    this.fontWeight = "bold";
                    return;
                }// end function
                })]};
            }// end function
            });
            this.listeners = [];
            mx_internal::_document = this;
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                this.borderStyle = "solid";
                this.borderThickness = 0;
                this.backgroundColor = 12623724;
                return;
            }// end function
            ;
            this.percentWidth = 100;
            this.height = 20;
            this.addEventListener("rollOver", this.___FriendsListMenuItemRenderer_Canvas1_rollOver);
            this.addEventListener("rollOut", this.___FriendsListMenuItemRenderer_Canvas1_rollOut);
            return;
        }// end function

        public function get itemLabel() : Label
        {
            return this._2135689121itemLabel;
        }// end function

        public function set itemLabel(param1:Label) : void
        {
            var _loc_2:* = this._2135689121itemLabel;
            if (_loc_2 !== param1)
            {
                this._2135689121itemLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "itemLabel", _loc_2, param1));
            }
            return;
        }// end function

        private function normal(event:Event) : void
        {
            if (this.enabled)
            {
                this.setStyle("backgroundColor", 12623724);
            }
            return;
        }// end function

        public function get text() : String
        {
            return this._text;
        }// end function

        public function ___FriendsListMenuItemRenderer_Canvas1_rollOver(event:MouseEvent) : void
        {
            this.highlight(event);
            return;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        private function highlight(event:Event) : void
        {
            if (this.enabled)
            {
                this.setStyle("backgroundColor", 10979932);
            }
            return;
        }// end function

        public function ___FriendsListMenuItemRenderer_Canvas1_rollOut(event:MouseEvent) : void
        {
            this.normal(event);
            return;
        }// end function

        private function creationCompleteHandler(event:FlexEvent) : void
        {
            this.itemLabel.text = this._text;
            return;
        }// end function

        public function set text(param1:String) : void
        {
            this._text = param1;
            if (this.itemLabel)
            {
                this.itemLabel.text = this._text;
            }
            else
            {
                this.addEventListener(FlexEvent.CREATION_COMPLETE, this.creationCompleteHandler);
            }
            return;
        }// end function

        override public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            super.addEventListener(param1, param2, param3, param4, param5);
            this.listeners.push({type:param1, listener:param2});
            return;
        }// end function

        public function removeAllClickEventListeners() : void
        {
            var _loc_1:int = 0;
            while (_loc_1 < this.listeners.length)
            {
                
                if (this.listeners[_loc_1].type == MouseEvent.CLICK && this.hasEventListener(this.listeners[_loc_1].type))
                {
                    this.removeEventListener(this.listeners[_loc_1].type, this.listeners[_loc_1].listener);
                }
                _loc_1++;
            }
            this.listeners = [];
            return;
        }// end function

    }
}
