package GUI.Components
{
    import GUI.Components.ItemRenderer.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;

    public class StarMenu extends Canvas implements IBindingClient
    {
        private var _1282133823fadeIn:Fade;
        var _watchers:Array;
        private var _embed_mxml__171358266:Class;
        private var _1091436750fadeOut:Fade;
        private var _11548545buttonBar:CustomToggleButtonBar;
        private var _1177280081itemList:CustomTileList;
        private var _1332194002background:Canvas;
        var _bindingsBeginWithWord:Object;
        private var _2082343164btnClose:CloseButton;
        var _bindingsByDestination:Object;
        private var _embed_mxml_____data_src_gfx_embedded_starmenu_dragon_png_1318781028:Class;
        private var _1323778541dragon:Image;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function StarMenu()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {width:426, height:359, childDescriptors:[new UIComponentDescriptor({type:Image, id:"dragon", stylesFactory:function () : void
                {
                    this.top = "0";
                    this.horizontalCenter = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"background", stylesFactory:function () : void
                {
                    null.backgroundSize = this;
                    this.backgroundImage = _embed_mxml__171358266;
                    this.left = "18";
                    this.right = "18";
                    this.top = "104";
                    this.bottom = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {childDescriptors:[new UIComponentDescriptor({type:CloseButton, id:"btnClose", stylesFactory:function () : void
                    {
                        null.top = this;
                        this.right = "1";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:CustomTileList, id:"itemList", stylesFactory:function () : void
                    {
                        null.useRollOver = this;
                        this.borderThickness = 0;
                        this.backgroundAlpha = 0;
                        this.paddingLeft = 0;
                        this.paddingRight = 0;
                        this.paddingTop = 0;
                        this.paddingBottom = 0;
                        this.left = "11";
                        this.right = "24";
                        this.top = "13";
                        this.bottom = "32";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null._StarMenu_ClassFactory1_c(), itemRenderer:_StarMenu_ClassFactory2_c(), rowHeight:70, columnWidth:56};
                    }// end function
                    }), new UIComponentDescriptor({type:CustomToggleButtonBar, id:"buttonBar", stylesFactory:function () : void
                    {
                        this.buttonStyleName = "tab";
                        this.selectedButtonTextStyleName = "tabSelected";
                        this.bottom = "0";
                        this.left = "5";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {width:380};
                    }// end function
                    })]};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml__171358266 = StarMenu__embed_mxml__171358266;
            this._embed_mxml_____data_src_gfx_embedded_starmenu_dragon_png_1318781028 = StarMenu__embed_mxml_____data_src_gfx_embedded_starmenu_dragon_png_1318781028;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 426;
            this.height = 359;
            this._StarMenu_Fade1_i();
            this._StarMenu_Fade2_i();
            return;
        }// end function

        public function get buttonBar() : CustomToggleButtonBar
        {
            return this._11548545buttonBar;
        }// end function

        public function set buttonBar(param1:CustomToggleButtonBar) : void
        {
            var _loc_2:* = this._11548545buttonBar;
            if (_loc_2 !== param1)
            {
                this._11548545buttonBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buttonBar", _loc_2, param1));
            }
            return;
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
            var target:StarMenu;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._StarMenu_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_StarMenuWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return null[null];
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

        private function _StarMenu_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            _loc_1.addEventListener("effectEnd", this.__fadeOut_effectEnd);
            return _loc_1;
        }// end function

        public function get dragon() : Image
        {
            return this._1323778541dragon;
        }// end function

        private function _StarMenu_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = StarMenuNullItemRenderer;
            return _loc_1;
        }// end function

        public function set itemList(param1:CustomTileList) : void
        {
            var _loc_2:* = this._1177280081itemList;
            if (_loc_2 !== param1)
            {
                this._1177280081itemList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "itemList", _loc_2, param1));
            }
            return;
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

        private function _StarMenu_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.fadeIn;
            _loc_1 = this.fadeOut;
            return;
        }// end function

        public function get background() : Canvas
        {
            return this._1332194002background;
        }// end function

        public function get fadeOut() : Fade
        {
            return this._1091436750fadeOut;
        }// end function

        public function get fadeIn() : Fade
        {
            return this._1282133823fadeIn;
        }// end function

        private function _StarMenu_ClassFactory2_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = StarMenuItemRenderer;
            return _loc_1;
        }// end function

        private function _StarMenu_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeIn = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        public function get itemList() : CustomTileList
        {
            return this._1177280081itemList;
        }// end function

        public function set background(param1:Canvas) : void
        {
            var _loc_2:* = this._1332194002background;
            if (_loc_2 !== param1)
            {
                this._1332194002background = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "background", _loc_2, param1));
            }
            return;
        }// end function

        public function __fadeOut_effectEnd(event:EffectEvent) : void
        {
            globalFlash.gui.ShowQuestWindowDelayed();
            return;
        }// end function

        private function _StarMenu_bindingsSetup() : Array
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
                this.setStyle("hideEffect", param1);
                return;
            }// end function
            , "this.hideEffect");
            result[1] = binding;
            return result;
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

        private function ScrollStarMenu(event:ScrollEvent) : void
        {
            this.itemList.verticalScrollPosition = event.position;
            return;
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

        public function get btnClose() : CloseButton
        {
            return this._2082343164btnClose;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
