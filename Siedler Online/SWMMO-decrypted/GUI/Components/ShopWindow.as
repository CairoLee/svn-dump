package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import ServerState.*;
    import ShopSystem.*;
    import flash.display.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.controls.dataGridClasses.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;
    import mx.states.*;
    import mx.styles.*;

    public class ShopWindow extends Canvas implements IBindingClient
    {
        private var _1282133823fadeIn:Fade;
        public var _ShopWindow_SetStyle1:SetStyle;
        public var _ShopWindow_SetStyle2:SetStyle;
        public var _ShopWindow_SetStyle3:SetStyle;
        public var _ShopWindow_RemoveChild1:RemoveChild;
        public var _ShopWindow_RemoveChild3:RemoveChild;
        public var _ShopWindow_RemoveChild2:RemoveChild;
        private var _956114622costBox:HBox;
        private var _1378837878btnBuy:StandardButton;
        private var _1091436750fadeOut:Fade;
        private var _667706966bannerSmall1:Image;
        private var _733902135available:HBox;
        private var _1956358520btnAddCash:Button;
        private var _embed_mxml_____data_src_gfx_embedded_shop_categories_item_bg_png_2082963656:Class;
        var _bindingsByDestination:Object;
        private var _1023804335itemDetails:Canvas;
        private var _embed_mxml_____data_src_gfx_embedded_shop_categories_bg_png_1495999360:Class;
        private var _1684601372hardCurrency:HBox;
        public var _ShopWindow_SetProperty1:SetProperty;
        private var _252650492costsList:HBox;
        private var _embed_mxml_____data_src_gfx_embedded_shop_buy_item_headline_png_1182593105:Class;
        private var _667706967bannerSmall2:Image;
        private var _1237460524groups:Canvas;
        private var _456722082bannerLarge1:Image;
        private var _1408974168itemsStack:ViewStack;
        private var _1299772562groupsList:List;
        private var _951530617content:Canvas;
        private var _584999212headerContent:HBox;
        public var _ShopWindow_Label1:Label;
        public var _ShopWindow_Label3:Label;
        public var _ShopWindow_Label6:Label;
        private var _embed_mxml_____data_src_gfx_embedded_shop_buy_item_info_png_1289153212:Class;
        private var _1463740125shopHeader:Canvas;
        private var _138848857remainingItemsBadge:Canvas;
        private var _1215755049nameLabel:Label;
        private var _456722083bannerLarge2:Image;
        private var _97692013frame:Frame;
        private var _1727280797resourceIconHardCurrency:Image;
        private var _1323778541dragon:Image;
        private var _344172350resourceLabelHardCurrency:Label;
        private var _2110834281itemDescription2:Text;
        private var _2110834282itemDescription3:Text;
        private var _807254620giftPlayerName:Label;
        private var _2124052886shopItems:CustomTileList;
        private var _2033148026collapsedState:State;
        public var _ShopWindow_StandardButton2:StandardButton;
        private var _757514318costsLabel:Label;
        private var _2110834280itemDescription1:Text;
        private var _1368298346remainingItems:Label;
        var _watchers:Array;
        private var _520958960shopHeaderBar:Canvas;
        private var _456722084bannerLarge3:Image;
        private var _2082343164btnClose:CloseButton;
        var _bindingsBeginWithWord:Object;
        private var _1246042165giftTo:Label;
        private var _embed_mxml_____data_src_gfx_embedded_starmenu_dragon_png_1318781028:Class;
        private var _1970515734giftPlayerAvatar:AvatarListItemRenderer;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function ShopWindow()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {width:739, height:642, childDescriptors:[new UIComponentDescriptor({type:Image, id:"dragon", stylesFactory:function () : void
                {
                    this.top = "0";
                    this.horizontalCenter = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:_embed_mxml_____data_src_gfx_embedded_starmenu_dragon_png_1318781028};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"content", stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "18";
                    this.top = "104";
                    this.bottom = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {clipContent:false, horizontalScrollPolicy:"off", verticalScrollPolicy:"off", styleName:"basicPanel", childDescriptors:[new UIComponentDescriptor({type:CloseButton, id:"btnClose", stylesFactory:function () : void
                    {
                        this.top = "5";
                        this.right = "15";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:Label, id:"_ShopWindow_Label1", stylesFactory:function () : void
                    {
                        null.left = this;
                        this.top = "8";
                        this.fontWeight = "bold";
                        this.textAlign = "center";
                        this.right = "46";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.bottom = "0";
                        this.left = "7";
                        this.backgroundImage = _embed_mxml_____data_src_gfx_embedded_shop_categories_bg_png_1495999360;
                        this.backgroundSize = "100%";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:176, height:428};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.bottom = "-1";
                        this.left = "7";
                        this.right = "5";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, styleName:"shopFooter"};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, id:"shopHeader", stylesFactory:function () : void
                    {
                        null.left = this;
                        this.right = "2";
                        this.top = "27";
                        this.backgroundImage = _embed_mxml_____data_src_gfx_embedded_shop_buy_item_headline_png_1182593105;
                        this.backgroundSize = "100%";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {height:85, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"shopHeaderBar", stylesFactory:function () : void
                        {
                            this.backgroundColor = 0;
                            this.backgroundAlpha = 0.22;
                            this.left = "2";
                            this.right = "4";
                            this.top = "28";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {height:32, childDescriptors:[new UIComponentDescriptor({type:Label, id:"giftTo", stylesFactory:function () : void
                            {
                                null.horizontalCenter = this;
                                this.verticalCenter = "0";
                                return;
                            }// end function
                            }), new UIComponentDescriptor({type:HBox, id:"available", stylesFactory:function () : void
                            {
                                null.horizontalCenter = this;
                                this.verticalAlign = "middle";
                                this.verticalCenter = "0";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                var _loc_1:String = null;
                                return {childDescriptors:[new UIComponentDescriptor({type:Label, id:"_ShopWindow_Label3"}), new UIComponentDescriptor({type:HBox, id:"hardCurrency", events:{toolTipCreate:"__hardCurrency_toolTipCreate"}, stylesFactory:function () : void
                                {
                                    this.verticalAlign = "middle";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    var _loc_1:String = null;
                                    return {toolTip:"HardCurrency", childDescriptors:[new UIComponentDescriptor({type:Image, id:"resourceIconHardCurrency"}), new UIComponentDescriptor({type:Label, id:"resourceLabelHardCurrency", stylesFactory:function () : void
                                    {
                                        this.color = 16777215;
                                        this.fontWeight = "bold";
                                        return;
                                    }// end function
                                    })]};
                                }// end function
                                })]};
                            }// end function
                            }), new UIComponentDescriptor({type:Button, id:"btnAddCash", stylesFactory:function () : void
                            {
                                this.verticalCenter = "0";
                                this.right = "40";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {labelPlacement:"right", width:56, height:31};
                            }// end function
                            })]};
                        }// end function
                        }), new UIComponentDescriptor({type:AvatarListItemRenderer, id:"giftPlayerAvatar", stylesFactory:function () : void
                        {
                            this.horizontalCenter = "0";
                            this.verticalCenter = "-8";
                            return;
                        }// end function
                        }), new UIComponentDescriptor({type:Label, id:"giftPlayerName", stylesFactory:function () : void
                        {
                            null.horizontalCenter = this;
                            this.verticalCenter = "29";
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, id:"groups", stylesFactory:function () : void
                    {
                        this.bottom = "221";
                        this.left = "13";
                        this.backgroundSize = "100%";
                        this.backgroundImage = _embed_mxml_____data_src_gfx_embedded_shop_categories_item_bg_png_2082963656;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {width:156, height:200, childDescriptors:[new UIComponentDescriptor({type:Label, id:"_ShopWindow_Label6", stylesFactory:function () : void
                        {
                            this.color = 0;
                            this.top = "3";
                            this.horizontalCenter = "0";
                            return;
                        }// end function
                        }), new UIComponentDescriptor({type:List, id:"groupsList", events:{itemClick:"__groupsList_itemClick"}, stylesFactory:function () : void
                        {
                            this.textSelectedColor = 16777215;
                            this.textRollOverColor = 0;
                            this.leading = -2;
                            this.verticalAlign = "middle";
                            this.color = 0;
                            this.rollOverColor = 8811353;
                            this.selectionColor = 8087114;
                            this.borderThickness = 0;
                            this.backgroundAlpha = 0;
                            this.top = "35";
                            this.bottom = "5";
                            this.left = "3";
                            this.right = "3";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:null, labelFunction:GetGroupName};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:ViewStack, id:"itemsStack", stylesFactory:function () : void
                    {
                        this.left = "184";
                        this.right = "9";
                        this.bottom = "85";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {height:336, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                        {
                            this.left = "184";
                            this.right = "9";
                            this.bottom = "85";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {height:336, childDescriptors:[new UIComponentDescriptor({type:CustomTileList, id:"shopItems", stylesFactory:function () : void
                            {
                                null.paddingBottom = this;
                                this.paddingTop = 0;
                                this.paddingLeft = 0;
                                this.paddingRight = 0;
                                this.backgroundAlpha = 0;
                                this.borderThickness = 0;
                                this.useRollOver = false;
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {percentWidth:100, percentHeight:100, selectable:true, itemRenderer:_ShopWindow_ClassFactory1_c()};
                            }// end function
                            })]};
                        }// end function
                        }), new UIComponentDescriptor({type:Canvas, id:"itemDetails", propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {percentWidth:100, percentHeight:100, horizontalScrollPolicy:"off", verticalScrollPolicy:"off", styleName:"shopItemDetails", childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                            {
                                null.top = this;
                                this.left = "0";
                                this.right = "6";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                var _loc_1:String = null;
                                return {height:88, styleName:"shopFooter", childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"remainingItemsBadge", events:{toolTipCreate:"__remainingItemsBadge_toolTipCreate"}, stylesFactory:function () : void
                                {
                                    this.verticalCenter = "0";
                                    this.right = "20";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    var _loc_1:String = null;
                                    return {childDescriptors:[new UIComponentDescriptor({type:Image, propertiesFactory:function () : Object
                                    {
                                        return {null:_embed_mxml_____data_src_gfx_embedded_shop_buy_item_info_png_1289153212};
                                    }// end function
                                    }), new UIComponentDescriptor({type:Label, id:"remainingItems", stylesFactory:function () : void
                                    {
                                        this.fontWeight = "bold";
                                        this.fontSize = 28;
                                        this.color = 16777215;
                                        this.horizontalCenter = "2";
                                        this.verticalCenter = "-5";
                                        return;
                                    }// end function
                                    , propertiesFactory:function () : Object
                                    {
                                        return {rotation:7};
                                    }// end function
                                    })]};
                                }// end function
                                }), new UIComponentDescriptor({type:HBox, id:"headerContent", stylesFactory:function () : void
                                {
                                    this.horizontalCenter = "0";
                                    this.verticalCenter = "0";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    var _loc_1:String = null;
                                    return {childDescriptors:[new UIComponentDescriptor({type:Frame, id:"frame", propertiesFactory:function () : Object
                                    {
                                        return {null:null, contentType:"shopitem"};
                                    }// end function
                                    }), new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                                    {
                                        var _loc_1:String = null;
                                        return {height:60, childDescriptors:[new UIComponentDescriptor({type:Label, id:"nameLabel", stylesFactory:function () : void
                                        {
                                            null.color = this;
                                            this.fontWeight = "bold";
                                            this.fontSize = 20;
                                            return;
                                        }// end function
                                        }), new UIComponentDescriptor({type:HBox, id:"costBox", stylesFactory:function () : void
                                        {
                                            null.verticalAlign = this;
                                            this.top = "30";
                                            return;
                                        }// end function
                                        , propertiesFactory:function () : Object
                                        {
                                            var _loc_1:String = null;
                                            return {childDescriptors:[new UIComponentDescriptor({type:Label, id:"costsLabel", stylesFactory:function () : void
                                            {
                                                null.fontWeight = this;
                                                this.color = 0;
                                                return;
                                            }// end function
                                            }), new UIComponentDescriptor({type:HBox, id:"costsList"})]};
                                        }// end function
                                        })]};
                                    }// end function
                                    })]};
                                }// end function
                                })]};
                            }// end function
                            }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                            {
                                this.left = "20";
                                this.right = "10";
                                this.top = "96";
                                this.bottom = "96";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                var _loc_1:String = null;
                                return {horizontalScrollPolicy:"off", verticalScrollPolicy:"auto", childDescriptors:[new UIComponentDescriptor({type:VBox, stylesFactory:function () : void
                                {
                                    this.verticalGap = 8;
                                    this.left = "0";
                                    this.right = "15";
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    return {childDescriptors:[new UIComponentDescriptor({type:Text, id:"itemDescription1", stylesFactory:function () : void
                                    {
                                        this.fontWeight = "normal";
                                        return;
                                    }// end function
                                    , propertiesFactory:function () : Object
                                    {
                                        return {null:100, selectable:false};
                                    }// end function
                                    }), new UIComponentDescriptor({type:Text, id:"itemDescription2", stylesFactory:function () : void
                                    {
                                        this.textAlign = "center";
                                        return;
                                    }// end function
                                    , propertiesFactory:function () : Object
                                    {
                                        return {null:100, selectable:false, styleName:"specialClaim"};
                                    }// end function
                                    }), new UIComponentDescriptor({type:Text, id:"itemDescription3", stylesFactory:function () : void
                                    {
                                        this.fontWeight = "normal";
                                        return;
                                    }// end function
                                    , propertiesFactory:function () : Object
                                    {
                                        return {null:null, selectable:false};
                                    }// end function
                                    })]};
                                }// end function
                                })]};
                            }// end function
                            }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                            {
                                this.bottom = "6";
                                this.left = "0";
                                this.right = "6";
                                this.backgroundColor = 9271383;
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {height:88, childDescriptors:[new UIComponentDescriptor({type:HBox, stylesFactory:function () : void
                                {
                                    this.horizontalCenter = "0";
                                    this.verticalCenter = "0";
                                    this.horizontalGap = 15;
                                    return;
                                }// end function
                                , propertiesFactory:function () : Object
                                {
                                    var _loc_1:String = null;
                                    return {childDescriptors:[new UIComponentDescriptor({type:StandardButton, id:"btnBuy", events:{toolTipCreate:"__btnBuy_toolTipCreate"}, propertiesFactory:function () : Object
                                    {
                                        return {null:110, height:40};
                                    }// end function
                                    }), new UIComponentDescriptor({type:StandardButton, id:"_ShopWindow_StandardButton2", events:{click:"___ShopWindow_StandardButton2_click"}, propertiesFactory:function () : Object
                                    {
                                        return {width:110, height:40};
                                    }// end function
                                    })]};
                                }// end function
                                })]};
                            }// end function
                            })]};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Image, id:"bannerSmall1", stylesFactory:function () : void
                    {
                        this.left = "13";
                        this.bottom = "152";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, width:157, height:66};
                    }// end function
                    }), new UIComponentDescriptor({type:Image, id:"bannerSmall2", stylesFactory:function () : void
                    {
                        this.left = "13";
                        this.bottom = "84";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {scaleContent:false, width:157, height:66};
                    }// end function
                    }), new UIComponentDescriptor({type:Image, id:"bannerLarge1", stylesFactory:function () : void
                    {
                        this.left = "10";
                        this.bottom = "6";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, width:227, height:70};
                    }// end function
                    }), new UIComponentDescriptor({type:Image, id:"bannerLarge2", stylesFactory:function () : void
                    {
                        this.horizontalCenter = "1";
                        this.bottom = "6";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {scaleContent:false, width:227, height:70};
                    }// end function
                    }), new UIComponentDescriptor({type:Image, id:"bannerLarge3", stylesFactory:function () : void
                    {
                        this.right = "8";
                        this.bottom = "6";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:false, width:227, height:70};
                    }// end function
                    })]};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_shop_buy_item_headline_png_1182593105 = ShopWindow__embed_mxml_____data_src_gfx_embedded_shop_buy_item_headline_png_1182593105;
            this._embed_mxml_____data_src_gfx_embedded_shop_buy_item_info_png_1289153212 = ShopWindow__embed_mxml_____data_src_gfx_embedded_shop_buy_item_info_png_1289153212;
            this._embed_mxml_____data_src_gfx_embedded_shop_categories_bg_png_1495999360 = ShopWindow__embed_mxml_____data_src_gfx_embedded_shop_categories_bg_png_1495999360;
            this._embed_mxml_____data_src_gfx_embedded_shop_categories_item_bg_png_2082963656 = ShopWindow__embed_mxml_____data_src_gfx_embedded_shop_categories_item_bg_png_2082963656;
            this._embed_mxml_____data_src_gfx_embedded_starmenu_dragon_png_1318781028 = ShopWindow__embed_mxml_____data_src_gfx_embedded_starmenu_dragon_png_1318781028;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 739;
            this.height = 642;
            this.states = [this._ShopWindow_State1_i()];
            this._ShopWindow_Fade1_i();
            this._ShopWindow_Fade2_i();
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

        private function _ShopWindow_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = ShopItemRenderer;
            return _loc_1;
        }// end function

        public function get dragon() : Image
        {
            return this._1323778541dragon;
        }// end function

        private function _ShopWindow_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function ()
            {
                return fadeIn;
            }// end function
            , function (param1) : void
            {
                null.setStyle(this, param1);
                return;
            }// end function
            , "this.showEffect");
            result[0] = binding;
            binding = new Binding(this, function ()
            {
                return fadeOut;
            }// end function
            , function (param1) : void
            {
                null.setStyle(this, param1);
                return;
            }// end function
            , "this.hideEffect");
            result[1] = binding;
            binding = new Binding(this, function () : Object
            {
                return shopHeader;
            }// end function
            , function (param1:Object) : void
            {
                null.target = null;
                return;
            }// end function
            , "_ShopWindow_SetProperty1.target");
            result[2] = binding;
            binding = new Binding(this, function () : IStyleClient
            {
                return shopHeaderBar;
            }// end function
            , function (param1:IStyleClient) : void
            {
                null.target = param1;
                return;
            }// end function
            , "_ShopWindow_SetStyle1.target");
            result[3] = binding;
            binding = new Binding(this, function () : IStyleClient
            {
                return shopHeaderBar;
            }// end function
            , function (param1:IStyleClient) : void
            {
                _ShopWindow_SetStyle2.target = param1;
                return;
            }// end function
            , "_ShopWindow_SetStyle2.target");
            result[4] = binding;
            binding = new Binding(this, function () : DisplayObject
            {
                return giftPlayerAvatar;
            }// end function
            , function (param1:DisplayObject) : void
            {
                _ShopWindow_RemoveChild1.target = param1;
                return;
            }// end function
            , "_ShopWindow_RemoveChild1.target");
            result[5] = binding;
            binding = new Binding(this, function () : DisplayObject
            {
                return giftPlayerName;
            }// end function
            , function (param1:DisplayObject) : void
            {
                null.target = param1;
                return;
            }// end function
            , "_ShopWindow_RemoveChild2.target");
            result[6] = binding;
            binding = new Binding(this, function () : DisplayObject
            {
                return giftTo;
            }// end function
            , function (param1:DisplayObject) : void
            {
                _ShopWindow_RemoveChild3.target = param1;
                return;
            }// end function
            , "_ShopWindow_RemoveChild3.target");
            result[7] = binding;
            binding = new Binding(this, function () : IStyleClient
            {
                return available;
            }// end function
            , function (param1:IStyleClient) : void
            {
                null.target = param1;
                return;
            }// end function
            , "_ShopWindow_SetStyle3.target");
            result[8] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:String = null;
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _ShopWindow_Label1.text = param1;
                return;
            }// end function
            , "_ShopWindow_Label1.text");
            result[9] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "MakeAGift");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                giftTo.text = param1;
                return;
            }// end function
            , "giftTo.text");
            result[10] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Available");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_ShopWindow_Label3.text");
            result[11] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonIconHardCurrency");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnAddCash.icon");
            result[12] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonAddCashUp");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnAddCash.upSkin");
            result[13] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonAddCashOver");
            }// end function
            , function (param1:Class) : void
            {
                btnAddCash.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnAddCash.downSkin");
            result[14] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonAddCashOver");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnAddCash.overSkin");
            result[15] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonAddCashDisabled");
            }// end function
            , function (param1:Class) : void
            {
                btnAddCash.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnAddCash.disabledSkin");
            result[16] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Categories");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_ShopWindow_Label6.text");
            result[17] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Buy");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnBuy.label");
            result[18] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _ShopWindow_StandardButton2.label = param1;
                return;
            }// end function
            , "_ShopWindow_StandardButton2.label");
            result[19] = binding;
            return result;
        }// end function

        public function get hardCurrency() : HBox
        {
            return this._1684601372hardCurrency;
        }// end function

        public function set dragon(param1:Image) : void
        {
            var _loc_2:* = this._1323778541dragon;
            if (_loc_2 !== param1)
            {
                this._1323778541dragon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "dragon", _loc_2, param1));
            }
            return;
        }// end function

        public function set hardCurrency(param1:HBox) : void
        {
            var _loc_2:* = this._1684601372hardCurrency;
            if (_loc_2 !== param1)
            {
                this._1684601372hardCurrency = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "hardCurrency", _loc_2, param1));
            }
            return;
        }// end function

        public function set shopHeader(param1:Canvas) : void
        {
            var _loc_2:* = this._1463740125shopHeader;
            if (_loc_2 !== param1)
            {
                this._1463740125shopHeader = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "shopHeader", _loc_2, param1));
            }
            return;
        }// end function

        public function get costsLabel() : Label
        {
            return this._757514318costsLabel;
        }// end function

        public function get bannerSmall1() : Image
        {
            return this._667706966bannerSmall1;
        }// end function

        public function set headerContent(param1:HBox) : void
        {
            var _loc_2:* = this._584999212headerContent;
            if (_loc_2 !== param1)
            {
                this._584999212headerContent = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "headerContent", _loc_2, param1));
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

        public function get giftPlayerName() : Label
        {
            return this._807254620giftPlayerName;
        }// end function

        public function get bannerSmall2() : Image
        {
            return this._667706967bannerSmall2;
        }// end function

        public function get remainingItemsBadge() : Canvas
        {
            return this._138848857remainingItemsBadge;
        }// end function

        private function GetContent(param1:cShopItem, param2:DataGridColumn) : String
        {
            var _loc_4:cItemContent = null;
            var _loc_3:String = "";
            for each (_loc_4 in param1.GetShopItemContent_vector())
            {
                
                _loc_3 = _loc_3 + (_loc_4.GetCount() + " " + _loc_4.GetName_string() + "\n");
            }
            return _loc_3;
        }// end function

        public function set fadeOut(param1:Fade) : void
        {
            var _loc_2:* = this._1091436750fadeOut;
            if (_loc_2 !== param1)
            {
                this._1091436750fadeOut = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "fadeOut", _loc_2, param1));
            }
            return;
        }// end function

        public function get itemDescription2() : Text
        {
            return this._2110834281itemDescription2;
        }// end function

        public function get itemDescription3() : Text
        {
            return this._2110834282itemDescription3;
        }// end function

        public function get itemDescription1() : Text
        {
            return this._2110834280itemDescription1;
        }// end function

        public function get shopItems() : CustomTileList
        {
            return this._2124052886shopItems;
        }// end function

        public function get content() : Canvas
        {
            return this._951530617content;
        }// end function

        public function get collapsedState() : State
        {
            return this._2033148026collapsedState;
        }// end function

        private function _ShopWindow_State1_i() : State
        {
            var _loc_1:* = new State();
            this.collapsedState = _loc_1;
            _loc_1.name = "collapsed";
            _loc_1.overrides = [this._ShopWindow_SetProperty1_i(), this._ShopWindow_SetStyle1_i(), this._ShopWindow_SetStyle2_i(), this._ShopWindow_RemoveChild1_i(), this._ShopWindow_RemoveChild2_i(), this._ShopWindow_RemoveChild3_i(), this._ShopWindow_SetStyle3_i(), this._ShopWindow_SetProperty2_c()];
            return _loc_1;
        }// end function

        public function get btnBuy() : StandardButton
        {
            return this._1378837878btnBuy;
        }// end function

        public function get groupsList() : List
        {
            return this._1299772562groupsList;
        }// end function

        public function set costsLabel(param1:Label) : void
        {
            var _loc_2:* = this._757514318costsLabel;
            if (_loc_2 !== param1)
            {
                this._757514318costsLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "costsLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function get bannerLarge1() : Image
        {
            return this._456722082bannerLarge1;
        }// end function

        public function get bannerLarge2() : Image
        {
            return this._456722083bannerLarge2;
        }// end function

        public function get bannerLarge3() : Image
        {
            return this._456722084bannerLarge3;
        }// end function

        public function __groupsList_itemClick(event:ListEvent) : void
        {
            this.itemsStack.selectedIndex = 0;
            return;
        }// end function

        public function get itemsStack() : ViewStack
        {
            return this._1408974168itemsStack;
        }// end function

        public function set remainingItemsBadge(param1:Canvas) : void
        {
            var _loc_2:* = this._138848857remainingItemsBadge;
            if (_loc_2 !== param1)
            {
                this._138848857remainingItemsBadge = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "remainingItemsBadge", _loc_2, param1));
            }
            return;
        }// end function

        public function set bannerSmall1(param1:Image) : void
        {
            var _loc_2:* = this._667706966bannerSmall1;
            if (_loc_2 !== param1)
            {
                this._667706966bannerSmall1 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "bannerSmall1", _loc_2, param1));
            }
            return;
        }// end function

        public function set bannerSmall2(param1:Image) : void
        {
            var _loc_2:* = this._667706967bannerSmall2;
            if (_loc_2 !== param1)
            {
                this._667706967bannerSmall2 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "bannerSmall2", _loc_2, param1));
            }
            return;
        }// end function

        private function GetCosts(param1:cShopItem, param2:DataGridColumn) : String
        {
            var _loc_4:dResource = null;
            var _loc_3:String = "";
            for each (_loc_4 in param1.GetCosts_vector())
            {
                
                _loc_3 = _loc_3 + (_loc_4.amount + " " + _loc_4.name_string + "\n");
            }
            return _loc_3;
        }// end function

        public function set giftPlayerName(param1:Label) : void
        {
            var _loc_2:* = this._807254620giftPlayerName;
            if (_loc_2 !== param1)
            {
                this._807254620giftPlayerName = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "giftPlayerName", _loc_2, param1));
            }
            return;
        }// end function

        public function get costBox() : HBox
        {
            return this._956114622costBox;
        }// end function

        private function _ShopWindow_RemoveChild3_i() : RemoveChild
        {
            var _loc_1:* = new RemoveChild();
            this._ShopWindow_RemoveChild3 = _loc_1;
            BindingManager.executeBindings(this, "_ShopWindow_RemoveChild3", this._ShopWindow_RemoveChild3);
            return _loc_1;
        }// end function

        public function get resourceLabelHardCurrency() : Label
        {
            return this._344172350resourceLabelHardCurrency;
        }// end function

        public function set resourceIconHardCurrency(param1:Image) : void
        {
            var _loc_2:* = this._1727280797resourceIconHardCurrency;
            if (_loc_2 !== param1)
            {
                this._1727280797resourceIconHardCurrency = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceIconHardCurrency", _loc_2, param1));
            }
            return;
        }// end function

        public function get fadeIn() : Fade
        {
            return this._1282133823fadeIn;
        }// end function

        public function get available() : HBox
        {
            return this._733902135available;
        }// end function

        public function set itemDescription1(param1:Text) : void
        {
            var _loc_2:* = this._2110834280itemDescription1;
            if (_loc_2 !== param1)
            {
                this._2110834280itemDescription1 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "itemDescription1", _loc_2, param1));
            }
            return;
        }// end function

        public function set itemDescription2(param1:Text) : void
        {
            var _loc_2:* = this._2110834281itemDescription2;
            if (_loc_2 !== param1)
            {
                this._2110834281itemDescription2 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "itemDescription2", _loc_2, param1));
            }
            return;
        }// end function

        public function set itemDescription3(param1:Text) : void
        {
            var _loc_2:* = this._2110834282itemDescription3;
            if (_loc_2 !== param1)
            {
                this._2110834282itemDescription3 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "itemDescription3", _loc_2, param1));
            }
            return;
        }// end function

        public function set frame(param1:Frame) : void
        {
            var _loc_2:* = this._97692013frame;
            if (_loc_2 !== param1)
            {
                this._97692013frame = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "frame", _loc_2, param1));
            }
            return;
        }// end function

        public function set remainingItems(param1:Label) : void
        {
            var _loc_2:* = this._1368298346remainingItems;
            if (_loc_2 !== param1)
            {
                this._1368298346remainingItems = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "remainingItems", _loc_2, param1));
            }
            return;
        }// end function

        public function __fadeOut_effectEnd(event:EffectEvent) : void
        {
            globalFlash.gui.ShowQuestWindowDelayed();
            return;
        }// end function

        private function GetName(param1:cShopItem, param2:DataGridColumn) : String
        {
            return param1.GetName_string();
        }// end function

        public function set shopItems(param1:CustomTileList) : void
        {
            var _loc_2:* = this._2124052886shopItems;
            if (_loc_2 !== param1)
            {
                this._2124052886shopItems = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "shopItems", _loc_2, param1));
            }
            return;
        }// end function

        public function get giftPlayerAvatar() : AvatarListItemRenderer
        {
            return this._1970515734giftPlayerAvatar;
        }// end function

        public function set btnAddCash(param1:Button) : void
        {
            var _loc_2:* = this._1956358520btnAddCash;
            if (_loc_2 !== param1)
            {
                this._1956358520btnAddCash = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnAddCash", _loc_2, param1));
            }
            return;
        }// end function

        public function set content(param1:Canvas) : void
        {
            var _loc_2:* = this._951530617content;
            if (_loc_2 !== param1)
            {
                this._951530617content = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "content", _loc_2, param1));
            }
            return;
        }// end function

        public function set collapsedState(param1:State) : void
        {
            var _loc_2:* = this._2033148026collapsedState;
            if (_loc_2 !== param1)
            {
                this._2033148026collapsedState = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "collapsedState", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnClose() : CloseButton
        {
            return this._2082343164btnClose;
        }// end function

        private function _ShopWindow_RemoveChild2_i() : RemoveChild
        {
            var _loc_1:* = new RemoveChild();
            this._ShopWindow_RemoveChild2 = _loc_1;
            BindingManager.executeBindings(this, "_ShopWindow_RemoveChild2", this._ShopWindow_RemoveChild2);
            return _loc_1;
        }// end function

        private function GetGroupName(param1:cShopItemGroup) : String
        {
            return cLocaManager.GetInstance().GetText(LOCA_GROUP.SHOP_GROUPS, param1.name_string);
        }// end function

        public function set btnBuy(param1:StandardButton) : void
        {
            var _loc_2:* = this._1378837878btnBuy;
            if (_loc_2 !== param1)
            {
                this._1378837878btnBuy = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnBuy", _loc_2, param1));
            }
            return;
        }// end function

        public function get shopHeader() : Canvas
        {
            return this._1463740125shopHeader;
        }// end function

        public function set groupsList(param1:List) : void
        {
            var _loc_2:* = this._1299772562groupsList;
            if (_loc_2 !== param1)
            {
                this._1299772562groupsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "groupsList", _loc_2, param1));
            }
            return;
        }// end function

        public function get nameLabel() : Label
        {
            return this._1215755049nameLabel;
        }// end function

        public function get fadeOut() : Fade
        {
            return this._1091436750fadeOut;
        }// end function

        private function _ShopWindow_SetProperty2_c() : SetProperty
        {
            var _loc_1:* = new SetProperty();
            _loc_1.name = "height";
            _loc_1.value = 595;
            return _loc_1;
        }// end function

        private function _ShopWindow_RemoveChild1_i() : RemoveChild
        {
            var _loc_1:* = new RemoveChild();
            this._ShopWindow_RemoveChild1 = _loc_1;
            BindingManager.executeBindings(this, "_ShopWindow_RemoveChild1", this._ShopWindow_RemoveChild1);
            return _loc_1;
        }// end function

        public function set bannerLarge2(param1:Image) : void
        {
            var _loc_2:* = this._456722083bannerLarge2;
            if (_loc_2 !== param1)
            {
                this._456722083bannerLarge2 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "bannerLarge2", _loc_2, param1));
            }
            return;
        }// end function

        public function set bannerLarge3(param1:Image) : void
        {
            var _loc_2:* = this._456722084bannerLarge3;
            if (_loc_2 !== param1)
            {
                this._456722084bannerLarge3 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "bannerLarge3", _loc_2, param1));
            }
            return;
        }// end function

        public function set bannerLarge1(param1:Image) : void
        {
            var _loc_2:* = this._456722082bannerLarge1;
            if (_loc_2 !== param1)
            {
                this._456722082bannerLarge1 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "bannerLarge1", _loc_2, param1));
            }
            return;
        }// end function

        public function set itemsStack(param1:ViewStack) : void
        {
            var _loc_2:* = this._1408974168itemsStack;
            if (_loc_2 !== param1)
            {
                this._1408974168itemsStack = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "itemsStack", _loc_2, param1));
            }
            return;
        }// end function

        private function _ShopWindow_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.fadeIn;
            _loc_1 = this.fadeOut;
            _loc_1 = this.shopHeader;
            _loc_1 = this.shopHeaderBar;
            _loc_1 = this.shopHeaderBar;
            _loc_1 = this.giftPlayerAvatar;
            _loc_1 = this.giftPlayerName;
            _loc_1 = this.giftTo;
            _loc_1 = this.available;
            _loc_1 = label;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "MakeAGift");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Available");
            _loc_1 = gAssetManager.GetClass("ButtonIconHardCurrency");
            _loc_1 = gAssetManager.GetClass("ButtonAddCashUp");
            _loc_1 = gAssetManager.GetClass("ButtonAddCashOver");
            _loc_1 = gAssetManager.GetClass("ButtonAddCashOver");
            _loc_1 = gAssetManager.GetClass("ButtonAddCashDisabled");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Categories");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Buy");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
            return;
        }// end function

        public function set itemDetails(param1:Canvas) : void
        {
            var _loc_2:* = this._1023804335itemDetails;
            if (_loc_2 !== param1)
            {
                this._1023804335itemDetails = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "itemDetails", _loc_2, param1));
            }
            return;
        }// end function

        public function get resourceIconHardCurrency() : Image
        {
            return this._1727280797resourceIconHardCurrency;
        }// end function

        public function get headerContent() : HBox
        {
            return this._584999212headerContent;
        }// end function

        public function get remainingItems() : Label
        {
            return this._1368298346remainingItems;
        }// end function

        public function get frame() : Frame
        {
            return this._97692013frame;
        }// end function

        private function _ShopWindow_SetStyle3_i() : SetStyle
        {
            var _loc_1:* = new SetStyle();
            this._ShopWindow_SetStyle3 = _loc_1;
            _loc_1.name = "horizontalCenter";
            _loc_1.value = 0;
            BindingManager.executeBindings(this, "_ShopWindow_SetStyle3", this._ShopWindow_SetStyle3);
            return _loc_1;
        }// end function

        public function get btnAddCash() : Button
        {
            return this._1956358520btnAddCash;
        }// end function

        public function __remainingItemsBadge_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set costBox(param1:HBox) : void
        {
            var _loc_2:* = this._956114622costBox;
            if (_loc_2 !== param1)
            {
                this._956114622costBox = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "costBox", _loc_2, param1));
            }
            return;
        }// end function

        private function _ShopWindow_SetProperty1_i() : SetProperty
        {
            var _loc_1:* = new SetProperty();
            this._ShopWindow_SetProperty1 = _loc_1;
            _loc_1.name = "height";
            _loc_1.value = 38;
            BindingManager.executeBindings(this, "_ShopWindow_SetProperty1", this._ShopWindow_SetProperty1);
            return _loc_1;
        }// end function

        public function set resourceLabelHardCurrency(param1:Label) : void
        {
            var _loc_2:* = this._344172350resourceLabelHardCurrency;
            if (_loc_2 !== param1)
            {
                this._344172350resourceLabelHardCurrency = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceLabelHardCurrency", _loc_2, param1));
            }
            return;
        }// end function

        private function _ShopWindow_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            _loc_1.addEventListener("effectEnd", this.__fadeOut_effectEnd);
            return _loc_1;
        }// end function

        public function set fadeIn(param1:Fade) : void
        {
            var _loc_2:* = this._1282133823fadeIn;
            if (_loc_2 !== param1)
            {
                this._1282133823fadeIn = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "fadeIn", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:ShopWindow;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._ShopWindow_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ShopWindowWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return target[param1];
            }// end function
            , bindings, watchers);
            var i:uint;
            while (i < bindings.length)
            {
                
                Binding(bindings[i]).execute();
                i = (i + 1);
            }
            mx_internal::_bindings = mx_internal::_bindings.concat(bindings);
            mx_internal::_watchers = mx_internal::_watchers.concat(watchers);
            super.initialize();
            return;
        }// end function

        public function ___ShopWindow_StandardButton2_click(event:MouseEvent) : void
        {
            this.itemsStack.selectedIndex = 0;
            return;
        }// end function

        public function set giftTo(param1:Label) : void
        {
            var _loc_2:* = this._1246042165giftTo;
            if (_loc_2 !== param1)
            {
                this._1246042165giftTo = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "giftTo", _loc_2, param1));
            }
            return;
        }// end function

        public function set available(param1:HBox) : void
        {
            var _loc_2:* = this._733902135available;
            if (_loc_2 !== param1)
            {
                this._733902135available = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "available", _loc_2, param1));
            }
            return;
        }// end function

        public function set groups(param1:Canvas) : void
        {
            var _loc_2:* = this._1237460524groups;
            if (_loc_2 !== param1)
            {
                this._1237460524groups = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "groups", _loc_2, param1));
            }
            return;
        }// end function

        public function get itemDetails() : Canvas
        {
            return this._1023804335itemDetails;
        }// end function

        private function _ShopWindow_SetStyle2_i() : SetStyle
        {
            var _loc_1:* = new SetStyle();
            this._ShopWindow_SetStyle2 = _loc_1;
            _loc_1.name = "top";
            _loc_1.value = 2;
            BindingManager.executeBindings(this, "_ShopWindow_SetStyle2", this._ShopWindow_SetStyle2);
            return _loc_1;
        }// end function

        public function __btnBuy_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnBuy.enabled);
            return;
        }// end function

        public function __hardCurrency_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get giftTo() : Label
        {
            return this._1246042165giftTo;
        }// end function

        private function _ShopWindow_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeIn = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        public function set giftPlayerAvatar(param1:AvatarListItemRenderer) : void
        {
            var _loc_2:* = this._1970515734giftPlayerAvatar;
            if (_loc_2 !== param1)
            {
                this._1970515734giftPlayerAvatar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "giftPlayerAvatar", _loc_2, param1));
            }
            return;
        }// end function

        public function get groups() : Canvas
        {
            return this._1237460524groups;
        }// end function

        public function set shopHeaderBar(param1:Canvas) : void
        {
            var _loc_2:* = this._520958960shopHeaderBar;
            if (_loc_2 !== param1)
            {
                this._520958960shopHeaderBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "shopHeaderBar", _loc_2, param1));
            }
            return;
        }// end function

        public function get shopHeaderBar() : Canvas
        {
            return this._520958960shopHeaderBar;
        }// end function

        private function _ShopWindow_SetStyle1_i() : SetStyle
        {
            var _loc_1:* = new SetStyle();
            this._ShopWindow_SetStyle1 = _loc_1;
            _loc_1.name = "backgroundAlpha";
            _loc_1.value = 0;
            BindingManager.executeBindings(this, "_ShopWindow_SetStyle1", this._ShopWindow_SetStyle1);
            return _loc_1;
        }// end function

        public function set btnClose(param1:CloseButton) : void
        {
            var _loc_2:* = this._2082343164btnClose;
            if (_loc_2 !== param1)
            {
                this._2082343164btnClose = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnClose", _loc_2, param1));
            }
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
