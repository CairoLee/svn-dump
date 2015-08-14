package GUI.Components.ItemRenderer
{
    import GUI.Components.ToolTips.*;
    import flash.display.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.utils.*;

    public class BuildingsListItemRenderer extends Canvas implements IBindingClient
    {
        public var _BuildingsListItemRenderer_Image1:Image;
        public var _BuildingsListItemRenderer_Image3:Image;
        public var _BuildingsListItemRenderer_Image2:Image;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        var _watchers:Array;
        private var _377281308dataProxy:ObjectProxy;
        var _bindings:Array;
        private var _embed_mxml_____data_src_gfx_embedded_buildingmenu_bg_item_highlight_png_1431771365:Class;
        private var _embed_mxml_____data_src_gfx_embedded_buildingmenu_bg_item_png_105768027:Class;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function BuildingsListItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:65, height:58, childDescriptors:[new UIComponentDescriptor({type:Image, id:"_BuildingsListItemRenderer_Image1", propertiesFactory:function () : Object
                {
                    return {null:_embed_mxml_____data_src_gfx_embedded_buildingmenu_bg_item_png_105768027, percentWidth:100, percentHeight:100};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"_BuildingsListItemRenderer_Image2", propertiesFactory:function () : Object
                {
                    return {null:null, percentWidth:100, percentHeight:100};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"_BuildingsListItemRenderer_Image3", propertiesFactory:function () : Object
                {
                    return {null:59, height:51};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_buildingmenu_bg_item_highlight_png_1431771365 = BuildingsListItemRenderer__embed_mxml_____data_src_gfx_embedded_buildingmenu_bg_item_highlight_png_1431771365;
            this._embed_mxml_____data_src_gfx_embedded_buildingmenu_bg_item_png_105768027 = BuildingsListItemRenderer__embed_mxml_____data_src_gfx_embedded_buildingmenu_bg_item_png_105768027;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.horizontalScrollPolicy = "off";
            this.verticalScrollPolicy = "off";
            this.width = 65;
            this.height = 58;
            this.addEventListener("rollOver", this.___BuildingsListItemRenderer_Canvas1_rollOver);
            this.addEventListener("rollOut", this.___BuildingsListItemRenderer_Canvas1_rollOut);
            this.addEventListener("toolTipCreate", this.___BuildingsListItemRenderer_Canvas1_toolTipCreate);
            return;
        }// end function

        private function set dataProxy(param1:ObjectProxy) : void
        {
            var _loc_2:* = this._377281308dataProxy;
            if (_loc_2 !== param1)
            {
                this._377281308dataProxy = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "dataProxy", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingsListItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = dataProxy.label;
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = this;
                return;
            }// end function
            , "this.toolTip");
            result[0] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return !null.highlighted;
            }// end function
            , function (param1:Boolean) : void
            {
                null.visible = null;
                return;
            }// end function
            , "_BuildingsListItemRenderer_Image1.visible");
            result[1] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return dataProxy.highlighted;
            }// end function
            , function (param1:Boolean) : void
            {
                _BuildingsListItemRenderer_Image2.visible = param1;
                return;
            }// end function
            , "_BuildingsListItemRenderer_Image2.visible");
            result[2] = binding;
            binding = new Binding(this, function () : Object
            {
                return dataProxy.bitmap;
            }// end function
            , function (param1:Object) : void
            {
                null.source = null;
                return;
            }// end function
            , "_BuildingsListItemRenderer_Image3.source");
            result[3] = binding;
            return result;
        }// end function

        public function ___BuildingsListItemRenderer_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.BUILDINGS_LIST_string, event, data);
            return;
        }// end function

        override public function initialize() : void
        {
            var target:BuildingsListItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._BuildingsListItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_BuildingsListItemRendererWatcherSetupUtil");
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

        public function ___BuildingsListItemRenderer_Canvas1_rollOver(event:MouseEvent) : void
        {
            this.dataProxy.highlighted = true;
            return;
        }// end function

        private function _BuildingsListItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.dataProxy.label;
            _loc_1 = !this.dataProxy.highlighted;
            _loc_1 = this.dataProxy.highlighted;
            _loc_1 = this.dataProxy.bitmap;
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            if (param1 != null)
            {
                super.data = param1;
                this.dataProxy = new ObjectProxy();
                this.dataProxy.highlighted = false;
                this.dataProxy.label = data.label;
                this.dataProxy.bitmap = new Bitmap(data.bitmapData);
            }
            dispatchEvent(new FlexEvent(FlexEvent.DATA_CHANGE));
            return;
        }// end function

        public function ___BuildingsListItemRenderer_Canvas1_rollOut(event:MouseEvent) : void
        {
            this.dataProxy.highlighted = false;
            return;
        }// end function

        private function get dataProxy() : ObjectProxy
        {
            return this._377281308dataProxy;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
