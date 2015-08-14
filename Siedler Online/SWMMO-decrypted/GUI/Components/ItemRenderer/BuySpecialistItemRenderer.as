package GUI.Components.ItemRenderer
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import ServerState.*;
    import Specialists.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class BuySpecialistItemRenderer extends Canvas implements IBindingClient
    {
        private var _498671946specialistIcon:Frame;
        private var _499020811specialistType:Label;
        var _bindingsBeginWithWord:Object;
        var _watchers:Array;
        private var _252650492costsList:HBox;
        var _bindingsByDestination:Object;
        private var costsToBuy:Vector.<dResource>;
        private var _1378837878btnBuy:StandardButton;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var lastTimeUpdated:Number = 0;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function BuySpecialistItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:230, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    this.left = "10";
                    this.right = "10";
                    this.top = "3";
                    this.bottom = "3";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {styleName:"detailsContentBox", childDescriptors:[new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {styleName:"detailsSubContentBox", percentWidth:100, height:22, childDescriptors:[new UIComponentDescriptor({type:Label, id:"specialistType", stylesFactory:function () : void
                        {
                            this.horizontalCenter = "0";
                            this.verticalCenter = "0";
                            return;
                        }// end function
                        })]};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:Frame, id:"specialistIcon", propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:StandardButton, id:"btnBuy", events:{click:"__btnBuy_click", toolTipCreate:"__btnBuy_toolTipCreate"}, stylesFactory:function () : void
                {
                    this.right = "0";
                    this.top = "2";
                    this.bottom = "2";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {enabled:false, width:45};
                }// end function
                }), new UIComponentDescriptor({type:HBox, id:"costsList", stylesFactory:function () : void
                {
                    this.top = "32";
                    this.horizontalCenter = "0";
                    return;
                }// end function
                })]};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 230;
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            trace("BuySpecialistItemRenderer::data");
            super.data = param1;
            if (this.specialistIcon && this.btnBuy && this.specialistType)
            {
                this.displayData();
            }
            else
            {
                this.addEventListener(FlexEvent.CREATION_COMPLETE, this.displayData);
            }
            return;
        }// end function

        public function get specialistIcon() : Frame
        {
            return this._498671946specialistIcon;
        }// end function

        private function setCosts() : void
        {
            var _loc_4:dResource = null;
            var _loc_5:cResources = null;
            var _loc_6:ResourceItemRenderer = null;
            var _loc_1:* = global.ui.mCurrentPlayer;
            var _loc_2:* = data as cSpecialistDescription;
            cSpecialist.GetCostsToBuy_vector(_loc_2.GetType(), _loc_1.GetSpecialistAmount(_loc_2.GetType()));
            var _loc_3:* = cSpecialist.GetCostsToBuy_vector(_loc_2.GetType(), _loc_1.GetSpecialistAmount(_loc_2.GetType()));
            if (_loc_3)
            {
                this.costsList.removeAllChildren();
                this.costsToBuy = _loc_3;
                for each (_loc_4 in this.costsToBuy)
                {
                    
                    _loc_6 = new ResourceItemRenderer();
                    _loc_6.data = _loc_4;
                    this.costsList.addChild(_loc_6);
                }
                _loc_5 = global.ui.mCurrentPlayerZone.GetResources(global.ui.mCurrentPlayer);
                this.btnBuy.enabled = _loc_5.HasPlayerResourcesInListOne(this.costsToBuy);
            }
            else
            {
                this.btnBuy.enabled = false;
            }
            return;
        }// end function

        public function set specialistIcon(param1:Frame) : void
        {
            var _loc_2:* = this._498671946specialistIcon;
            if (_loc_2 !== param1)
            {
                this._498671946specialistIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "specialistIcon", _loc_2, param1));
            }
            return;
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

        public function get costsList() : HBox
        {
            return this._252650492costsList;
        }// end function

        private function displayData(event:Event = null) : void
        {
            this.removeEventListener(FlexEvent.CREATION_COMPLETE, this.displayData);
            switch(data.GetType())
            {
                case SPECIALIST_TYPE.GENERAL:
                {
                    this.specialistIcon.content = "IconGeneral";
                    this.btnBuy.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BuySpecialist", ["General"]);
                    this.specialistType.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.SPECIALISTS, "General");
                    break;
                }
                case SPECIALIST_TYPE.EXPLORER:
                {
                    this.specialistIcon.content = "IconExplorer";
                    this.btnBuy.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BuySpecialist", ["Explorer"]);
                    this.specialistType.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.SPECIALISTS, "Explorer");
                    break;
                }
                case SPECIALIST_TYPE.GEOLOGIST:
                {
                    this.specialistIcon.content = "IconGeologist";
                    this.btnBuy.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BuySpecialist", ["Geologist"]);
                    this.specialistType.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.SPECIALISTS, "Geologist");
                    break;
                }
                default:
                {
                    this.specialistIcon.content = null;
                    this.btnBuy.toolTip = "";
                    this.specialistType.text = "";
                    break;
                }
            }
            this.setCosts();
            return;
        }// end function

        override public function initialize() : void
        {
            var target:BuySpecialistItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._BuySpecialistItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_BuySpecialistItemRendererWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return null[param1];
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

        public function refresh() : void
        {
            this.setCosts();
            return;
        }// end function

        public function set specialistType(param1:Label) : void
        {
            var _loc_2:* = this._499020811specialistType;
            if (_loc_2 !== param1)
            {
                this._499020811specialistType = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "specialistType", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuySpecialistItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonIconPay");
            }// end function
            , function (param1:Class) : void
            {
                btnBuy.setStyle("icon", param1);
                return;
            }// end function
            , "btnBuy.icon");
            result[0] = binding;
            return result;
        }// end function

        private function Buy() : void
        {
            this.btnBuy.enabled = false;
            dispatchEvent(new ListEvent("BuySpecialist", true, false, -1, data.GetType()));
            return;
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

        private function _BuySpecialistItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetClass("ButtonIconPay");
            return;
        }// end function

        public function __btnBuy_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get btnBuy() : StandardButton
        {
            return this._1378837878btnBuy;
        }// end function

        public function get specialistType() : Label
        {
            return this._499020811specialistType;
        }// end function

        public function __btnBuy_click(event:MouseEvent) : void
        {
            this.Buy();
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
