package GUI.Components.ToolTips
{
    import Enums.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class MoveBuildingTip extends VBox implements IDataToolTip
    {
        private var _252650492costsList:HBox;
        private var _91291148_text:String;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _movementResources:Vector.<dResource>;
        private var _1115058732headline:Text;

        public function MoveBuildingTip()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:VBox, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:Text, id:"headline", stylesFactory:function () : void
                {
                    this.top = "5";
                    this.left = "5";
                    this.right = "5";
                    this.fontWeight = "bold";
                    this.color = 16777215;
                    return;
                }// end function
                }), new UIComponentDescriptor({type:HBox, id:"costsList", stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "5";
                    this.top = "26";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                })]};
            }// end function
            });
            mx_internal::_document = this;
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                null.paddingLeft = this;
                this.paddingRight = 5;
                this.paddingTop = 5;
                this.paddingBottom = 10;
                return;
            }// end function
            ;
            this.minWidth = 200;
            this.mouseEnabled = false;
            this.mouseChildren = false;
            this.styleName = "toolTip";
            return;
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

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function get headline() : Text
        {
            return this._1115058732headline;
        }// end function

        public function set toolTipData(param1:Object) : void
        {
            this._movementResources = param1 as Vector.<dResource>;
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

        public function set headline(param1:Text) : void
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

        public function set text(param1:String) : void
        {
            var _loc_2:dResource = null;
            var _loc_3:ResourceItemRenderer = null;
            this._text = param1;
            this.headline.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, this._text);
            this.costsList.removeAllChildren();
            for each (_loc_2 in this._movementResources)
            {
                
                _loc_3 = new ResourceItemRenderer();
                _loc_2.amount = Math.floor(_loc_2.amount);
                _loc_3.data = _loc_2;
                this.costsList.addChild(_loc_3);
            }
            return;
        }// end function

    }
}
