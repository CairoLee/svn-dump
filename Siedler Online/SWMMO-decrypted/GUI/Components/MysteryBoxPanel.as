package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;

    public class MysteryBoxPanel extends Canvas implements IBindingClient
    {
        private var _1282133823fadeIn:Fade;
        var _watchers:Array;
        private var _1091436750fadeOut:Fade;
        private var _embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental3_png_1841140076:Class;
        private var _559784120completedHeader:Canvas;
        private var _embed_mxml_____data_src_gfx_embedded_mysterybox_mystery_box_png_1189798084:Class;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        private var _1133386838busyAnim:SpriteLibAnimation;
        private var _1516759348ornament:Image;
        private var _951530617content:Canvas;
        private var _embed_mxml_____data_src_gfx_embedded_mysterybox_ornamental_png_592763563:Class;
        private var _1691212028rewardText:Text;
        private var _2123879298itemsList:HBox;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _94069048btnOK:StandardButton;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function MysteryBoxPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:428, height:345, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    null.top = this;
                    this.left = "5";
                    this.right = "9";
                    this.bottom = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"completedHeader", stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "0";
                    this.top = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:"questPanelHeader", height:82};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"ornament", stylesFactory:function () : void
                {
                    null.top = this;
                    this.horizontalCenter = "0";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "10";
                    this.bottom = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:"questPanelFooter", height:60};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"content", stylesFactory:function () : void
                {
                    this.top = "35";
                    this.bottom = "1";
                    this.left = "17";
                    this.right = "19";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {clipContent:false, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        null.left = this;
                        this.right = "8";
                        this.top = "92";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {styleName:"detailsContentBox", height:105, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                        {
                            null.left = this;
                            this.right = "12";
                            this.verticalCenter = "2";
                            this.backgroundImage = _embed_mxml_____data_src_gfx_embedded_mysterybox_ornamental_png_592763563;
                            this.backgroundSize = "100%";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {height:80, childDescriptors:[new UIComponentDescriptor({type:HBox, id:"itemsList", stylesFactory:function () : void
                            {
                                this.horizontalCenter = "0";
                                this.verticalCenter = "0";
                                return;
                            }// end function
                            })]};
                        }// end function
                        }), new UIComponentDescriptor({type:SpriteLibAnimation, id:"busyAnim", stylesFactory:function () : void
                        {
                            this.horizontalCenter = "4";
                            this.verticalCenter = "4";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:null, loop:true, visible:false, width:48, height:48};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.top = "88";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, percentWidth:100, height:10};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.left = "8";
                        this.right = "8";
                        this.top = "202";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {styleName:"detailsSubHeader", height:50, childDescriptors:[new UIComponentDescriptor({type:Text, id:"rewardText", stylesFactory:function () : void
                        {
                            this.left = "10";
                            this.right = "10";
                            this.top = "10";
                            this.bottom = "3";
                            this.textAlign = "center";
                            this.color = 16777215;
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:false};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.top = "200";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, percentWidth:100, height:10};
                    }// end function
                    }), new UIComponentDescriptor({type:Image, stylesFactory:function () : void
                    {
                        this.horizontalCenter = "0";
                        this.top = "194";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {source:_embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental3_png_1841140076};
                    }// end function
                    }), new UIComponentDescriptor({type:Image, stylesFactory:function () : void
                    {
                        null.horizontalCenter = this;
                        this.top = "-32";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null};
                    }// end function
                    }), new UIComponentDescriptor({type:StandardButton, id:"btnOK", stylesFactory:function () : void
                    {
                        this.horizontalCenter = "0";
                        this.bottom = "10";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {playSound:false, width:70, height:26};
                    }// end function
                    })]};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_mysterybox_mystery_box_png_1189798084 = MysteryBoxPanel__embed_mxml_____data_src_gfx_embedded_mysterybox_mystery_box_png_1189798084;
            this._embed_mxml_____data_src_gfx_embedded_mysterybox_ornamental_png_592763563 = MysteryBoxPanel__embed_mxml_____data_src_gfx_embedded_mysterybox_ornamental_png_592763563;
            this._embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental3_png_1841140076 = MysteryBoxPanel__embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental3_png_1841140076;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 428;
            this.height = 345;
            this.cacheAsBitmap = true;
            this.clipContent = false;
            this._MysteryBoxPanel_Fade1_i();
            this._MysteryBoxPanel_Fade2_i();
            return;
        }// end function

        private function _MysteryBoxPanel_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeIn = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
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

        public function get rewardText() : Text
        {
            return this._1691212028rewardText;
        }// end function

        override public function initialize() : void
        {
            var target:MysteryBoxPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._MysteryBoxPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_MysteryBoxPanelWatcherSetupUtil");
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

        private function _MysteryBoxPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.fadeIn;
            _loc_1 = this.fadeOut;
            _loc_1 = gAssetManager.GetBitmap("DailyLoginHeaderOrnamental");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
            return;
        }// end function

        public function get busyAnim() : SpriteLibAnimation
        {
            return this._1133386838busyAnim;
        }// end function

        public function get completedHeader() : Canvas
        {
            return this._559784120completedHeader;
        }// end function

        public function get fadeOut() : Fade
        {
            return this._1091436750fadeOut;
        }// end function

        private function _MysteryBoxPanel_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            _loc_1.addEventListener("effectEnd", this.__fadeOut_effectEnd);
            return _loc_1;
        }// end function

        public function get ornament() : Image
        {
            return this._1516759348ornament;
        }// end function

        public function get btnOK() : StandardButton
        {
            return this._94069048btnOK;
        }// end function

        public function get fadeIn() : Fade
        {
            return this._1282133823fadeIn;
        }// end function

        public function set busyAnim(param1:SpriteLibAnimation) : void
        {
            var _loc_2:* = this._1133386838busyAnim;
            if (_loc_2 !== param1)
            {
                this._1133386838busyAnim = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "busyAnim", _loc_2, param1));
            }
            return;
        }// end function

        public function __fadeOut_effectEnd(event:EffectEvent) : void
        {
            globalFlash.gui.ShowQuestWindowDelayed();
            return;
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

        private function _MysteryBoxPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function ()
            {
                return fadeIn;
            }// end function
            , function (param1) : void
            {
                this.setStyle("showEffect", param1);
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
                return null.GetBitmap(null);
            }// end function
            , function (param1:Object) : void
            {
                ornament.source = param1;
                return;
            }// end function
            , "ornament.source");
            result[2] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnOK.label");
            result[3] = binding;
            return result;
        }// end function

        public function set ornament(param1:Image) : void
        {
            var _loc_2:* = this._1516759348ornament;
            if (_loc_2 !== param1)
            {
                this._1516759348ornament = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "ornament", _loc_2, param1));
            }
            return;
        }// end function

        public function set completedHeader(param1:Canvas) : void
        {
            var _loc_2:* = this._559784120completedHeader;
            if (_loc_2 !== param1)
            {
                this._559784120completedHeader = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "completedHeader", _loc_2, param1));
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

        public function set btnOK(param1:StandardButton) : void
        {
            var _loc_2:* = this._94069048btnOK;
            if (_loc_2 !== param1)
            {
                this._94069048btnOK = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnOK", _loc_2, param1));
            }
            return;
        }// end function

        public function set rewardText(param1:Text) : void
        {
            var _loc_2:* = this._1691212028rewardText;
            if (_loc_2 !== param1)
            {
                this._1691212028rewardText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rewardText", _loc_2, param1));
            }
            return;
        }// end function

        public function get content() : Canvas
        {
            return this._951530617content;
        }// end function

        public function set itemsList(param1:HBox) : void
        {
            var _loc_2:* = this._2123879298itemsList;
            if (_loc_2 !== param1)
            {
                this._2123879298itemsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "itemsList", _loc_2, param1));
            }
            return;
        }// end function

        public function get itemsList() : HBox
        {
            return this._2123879298itemsList;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
