package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;
    import mx.styles.*;

    public class SpecialistCooldownPanel extends Canvas implements IBindingClient
    {
        private var _2096649492specialistRenderer:StarMenuItemRenderer;
        private var _1282133823fadeIn:Fade;
        private var _94069048btnOK:StandardButton;
        private var _3327265loca:cLocaManager;
        public var _SpecialistCooldownPanel_Text2:Text;
        public var _SpecialistCooldownPanel_Label2:Label;
        public var _SpecialistCooldownPanel_Label3:Label;
        var _watchers:Array;
        private var _1091436750fadeOut:Fade;
        private var _1378825044btnPay:StandardButton;
        private var _447426607descriptionBox:HBox;
        private var _94755854clock:Image;
        private var _embed_mxml_____data_src_gfx_embedded_specialists_specialist_ornamental_top_png_971772316:Class;
        private var _559784120completedHeader:Canvas;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        private var _2082343164btnClose:CloseButton;
        private var _951530617content:Canvas;
        private var _1115058732headline:Label;
        private var _1724546052description:Text;
        private var _1516759348ornament:Image;
        var _bindings:Array;
        private var _750646169timeRemain:Label;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function SpecialistCooldownPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:370, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    this.top = "17";
                    this.left = "5";
                    this.right = "9";
                    this.bottom = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:"basicPanel"};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"completedHeader", stylesFactory:function () : void
                {
                    this.left = "0";
                    this.right = "0";
                    this.top = "17";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, height:82, visible:false};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"ornament", stylesFactory:function () : void
                {
                    null.top = this;
                    this.horizontalCenter = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {source:_embed_mxml_____data_src_gfx_embedded_specialists_specialist_ornamental_top_png_971772316};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    this.left = "10";
                    this.right = "10";
                    this.bottom = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:"questPanelFooter", height:60};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"headline", stylesFactory:function () : void
                {
                    this.left = "46";
                    this.top = "25";
                    this.fontWeight = "bold";
                    this.textAlign = "center";
                    this.right = "46";
                    this.color = 16777215;
                    return;
                }// end function
                }), new UIComponentDescriptor({type:CloseButton, id:"btnClose", stylesFactory:function () : void
                {
                    null.top = this;
                    this.right = "24";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"content", stylesFactory:function () : void
                {
                    this.top = "48";
                    this.bottom = "60";
                    this.left = "19";
                    this.right = "19";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {height:187, percentWidth:100, childDescriptors:[new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {styleName:"detailsHeader", horizontalScrollPolicy:"off", verticalScrollPolicy:"off", percentWidth:100, childDescriptors:[new UIComponentDescriptor({type:HBox, id:"descriptionBox", stylesFactory:function () : void
                        {
                            this.left = "10";
                            this.top = "7";
                            this.right = "15";
                            this.verticalGap = 5;
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {height:70, childDescriptors:[new UIComponentDescriptor({type:StarMenuItemRenderer, id:"specialistRenderer"}), new UIComponentDescriptor({type:Text, id:"description", stylesFactory:function () : void
                            {
                                this.color = 16777215;
                                this.fontWeight = "normal";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:null, percentWidth:100, percentHeight:100};
                            }// end function
                            })]};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.left = "4";
                        this.right = "4";
                        this.top = "79";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {styleName:"detailsSubHeader", height:20, percentWidth:100, childDescriptors:[new UIComponentDescriptor({type:Label, id:"_SpecialistCooldownPanel_Label2", stylesFactory:function () : void
                        {
                            null.top = this;
                            this.horizontalCenter = "0";
                            this.color = 16777215;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.left = "5";
                        this.right = "5";
                        this.top = "99";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {styleName:"detailsContentBox", height:40, percentWidth:100, childDescriptors:[new UIComponentDescriptor({type:Image, id:"clock", stylesFactory:function () : void
                        {
                            this.top = "1";
                            this.left = "20";
                            return;
                        }// end function
                        }), new UIComponentDescriptor({type:Label, id:"_SpecialistCooldownPanel_Label3", stylesFactory:function () : void
                        {
                            this.top = "1";
                            this.left = "30";
                            this.horizontalCenter = "0";
                            this.color = 16777215;
                            return;
                        }// end function
                        }), new UIComponentDescriptor({type:Label, id:"timeRemain", stylesFactory:function () : void
                        {
                            this.top = "20";
                            this.left = "30";
                            this.horizontalCenter = "0";
                            this.color = 16777215;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.left = "4";
                        this.right = "4";
                        this.top = "142";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {styleName:"detailsSubHeader", height:45, percentWidth:100, childDescriptors:[new UIComponentDescriptor({type:StandardButton, id:"btnPay", stylesFactory:function () : void
                        {
                            this.left = "40";
                            this.top = "10";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:"HalveTimeCost", playSound:false, width:70, height:26};
                        }// end function
                        }), new UIComponentDescriptor({type:Text, id:"_SpecialistCooldownPanel_Text2", stylesFactory:function () : void
                        {
                            null.left = this;
                            this.top = "6";
                            this.color = 16777215;
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {width:160, selectable:false};
                        }// end function
                        })]};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:StandardButton, id:"btnOK", stylesFactory:function () : void
                {
                    this.horizontalCenter = "0";
                    this.bottom = "10";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:false, width:70, height:26};
                }// end function
                })]};
            }// end function
            });
            this._3327265loca = cLocaManager.GetInstance();
            this._embed_mxml_____data_src_gfx_embedded_specialists_specialist_ornamental_top_png_971772316 = SpecialistCooldownPanel__embed_mxml_____data_src_gfx_embedded_specialists_specialist_ornamental_top_png_971772316;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                this.horizontalCenter = "0";
                this.verticalCenter = "0";
                return;
            }// end function
            ;
            this.width = 370;
            this.cacheAsBitmap = true;
            this._SpecialistCooldownPanel_Fade1_i();
            this._SpecialistCooldownPanel_Fade2_i();
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

        public function set btnPay(param1:StandardButton) : void
        {
            var _loc_2:* = this._1378825044btnPay;
            if (_loc_2 !== param1)
            {
                this._1378825044btnPay = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnPay", _loc_2, param1));
            }
            return;
        }// end function

        private function _SpecialistCooldownPanel_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            _loc_1.addEventListener("effectEnd", this.__fadeOut_effectEnd);
            return _loc_1;
        }// end function

        public function get description() : Text
        {
            return this._1724546052description;
        }// end function

        override public function initialize() : void
        {
            var target:SpecialistCooldownPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._SpecialistCooldownPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_SpecialistCooldownPanelWatcherSetupUtil");
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

        private function _SpecialistCooldownPanel_bindingsSetup() : Array
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
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "ProductionStatus");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_SpecialistCooldownPanel_Label2.text");
            result[2] = binding;
            binding = new Binding(this, function () : Object
            {
                return gAssetManager.GetBitmap("DetailsIconOverallTime");
            }// end function
            , function (param1:Object) : void
            {
                null.source = param1;
                return;
            }// end function
            , "clock.source");
            result[3] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "NotAvailableText");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_SpecialistCooldownPanel_Label3.text");
            result[4] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonIconHalfTheTime");
            }// end function
            , function (param1:Class) : void
            {
                btnPay.setStyle("icon", param1);
                return;
            }// end function
            , "btnPay.icon");
            result[5] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = loca.GetText(LOCA_GROUP.LABELS, "HalfTheTime");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _SpecialistCooldownPanel_Text2.text = param1;
                return;
            }// end function
            , "_SpecialistCooldownPanel_Text2.text");
            result[6] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnOK.label");
            result[7] = binding;
            return result;
        }// end function

        public function get clock() : Image
        {
            return this._94755854clock;
        }// end function

        public function set timeRemain(param1:Label) : void
        {
            var _loc_2:* = this._750646169timeRemain;
            if (_loc_2 !== param1)
            {
                this._750646169timeRemain = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "timeRemain", _loc_2, param1));
            }
            return;
        }// end function

        public function set clock(param1:Image) : void
        {
            var _loc_2:* = this._94755854clock;
            if (_loc_2 !== param1)
            {
                this._94755854clock = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "clock", _loc_2, param1));
            }
            return;
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

        public function get descriptionBox() : HBox
        {
            return this._447426607descriptionBox;
        }// end function

        public function get timeRemain() : Label
        {
            return this._750646169timeRemain;
        }// end function

        public function get specialistRenderer() : StarMenuItemRenderer
        {
            return this._2096649492specialistRenderer;
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

        public function get btnOK() : StandardButton
        {
            return this._94069048btnOK;
        }// end function

        public function get fadeOut() : Fade
        {
            return this._1091436750fadeOut;
        }// end function

        public function get completedHeader() : Canvas
        {
            return this._559784120completedHeader;
        }// end function

        public function set specialistRenderer(param1:StarMenuItemRenderer) : void
        {
            var _loc_2:* = this._2096649492specialistRenderer;
            if (_loc_2 !== param1)
            {
                this._2096649492specialistRenderer = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "specialistRenderer", _loc_2, param1));
            }
            return;
        }// end function

        public function get fadeIn() : Fade
        {
            return this._1282133823fadeIn;
        }// end function

        public function get btnPay() : StandardButton
        {
            return this._1378825044btnPay;
        }// end function

        private function _SpecialistCooldownPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.fadeIn;
            _loc_1 = this.fadeOut;
            _loc_1 = this.loca.GetText(LOCA_GROUP.LABELS, "ProductionStatus");
            _loc_1 = gAssetManager.GetBitmap("DetailsIconOverallTime");
            _loc_1 = this.loca.GetText(LOCA_GROUP.LABELS, "NotAvailableText");
            _loc_1 = gAssetManager.GetClass("ButtonIconHalfTheTime");
            _loc_1 = this.loca.GetText(LOCA_GROUP.LABELS, "HalfTheTime");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
            return;
        }// end function

        private function set loca(param1:cLocaManager) : void
        {
            var _loc_2:* = this._3327265loca;
            if (_loc_2 !== param1)
            {
                this._3327265loca = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "loca", _loc_2, param1));
            }
            return;
        }// end function

        public function get headline() : Label
        {
            return this._1115058732headline;
        }// end function

        public function get ornament() : Image
        {
            return this._1516759348ornament;
        }// end function

        public function __fadeOut_effectEnd(event:EffectEvent) : void
        {
            globalFlash.gui.ShowQuestWindowDelayed();
            return;
        }// end function

        public function set descriptionBox(param1:HBox) : void
        {
            var _loc_2:* = this._447426607descriptionBox;
            if (_loc_2 !== param1)
            {
                this._447426607descriptionBox = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "descriptionBox", _loc_2, param1));
            }
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

        private function _SpecialistCooldownPanel_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeIn = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
            return _loc_1;
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

        private function get loca() : cLocaManager
        {
            return this._3327265loca;
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

        public function get content() : Canvas
        {
            return this._951530617content;
        }// end function

        public function get btnClose() : CloseButton
        {
            return this._2082343164btnClose;
        }// end function

        public function set description(param1:Text) : void
        {
            var _loc_2:* = this._1724546052description;
            if (_loc_2 !== param1)
            {
                this._1724546052description = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "description", _loc_2, param1));
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
