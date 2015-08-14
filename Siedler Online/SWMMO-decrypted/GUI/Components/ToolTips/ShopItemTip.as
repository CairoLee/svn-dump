package GUI.Components.ToolTips
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import ShopSystem.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class ShopItemTip extends Canvas implements IDataToolTip
    {
        private var _shopItem:cShopItem;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _1115058732headline:Label;
        private var _text:String;
        private var _1724546052description:CustomText;

        public function ShopItemTip()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:Label, id:"headline", stylesFactory:function () : void
                {
                    this.top = "5";
                    this.left = "5";
                    this.right = "5";
                    this.fontWeight = "bold";
                    this.color = 16777215;
                    return;
                }// end function
                }), new UIComponentDescriptor({type:CustomText, id:"description", stylesFactory:function () : void
                {
                    null.color = this;
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
            this.minWidth = 180;
            this.mouseEnabled = false;
            this.mouseChildren = false;
            this.styleName = "toolTip";
            return;
        }// end function

        public function set text(param1:String) : void
        {
            var _loc_3:cItemContent = null;
            var _loc_4:String = null;
            this._text = param1;
            var _loc_2:Array = [];
            for each (_loc_3 in this._shopItem.GetShopItemContent_vector())
            {
                
                _loc_2.push(_loc_3.GetCount().toString());
                _loc_2.push(_loc_3.GetResourceName_string());
            }
            _loc_4 = this._shopItem.GetToolTipIdentifier_string() != "" ? (this._shopItem.GetToolTipIdentifier_string()) : (this._text);
            this.headline.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.SHOP_ITEMS, this._text);
            this.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.SHOP_ITEM_TOOLTIPS, _loc_4, _loc_2);
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

        public function set toolTipData(param1:Object) : void
        {
            this._shopItem = param1 as cShopItem;
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
