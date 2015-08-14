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

    public class LegalPanel extends Canvas implements IBindingClient
    {
        private var _1282133823fadeIn:Fade;
        private var _94069021btnNO:StandardButton;
        private var _242580251InfoText:Text;
        var _watchers:Array;
        private var _1091436750fadeOut:Fade;
        private var _1378817301btnYES:StandardButton;
        private var _embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental3_png_1841140076:Class;
        private var _559784120completedHeader:Canvas;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        private var _1516759348ornament:Image;
        private var _951530617content:Canvas;
        private var _1115058732headline:Label;
        private var _598651502legalterms:Text;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _2011242899questAdvisorMedium:Image;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function LegalPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:428, height:310, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    this.top = "5";
                    this.left = "5";
                    this.right = "9";
                    this.bottom = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {styleName:"basicPanel"};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"completedHeader", stylesFactory:function () : void
                {
                    this.left = "0";
                    this.right = "0";
                    this.top = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {styleName:"questPanelHeader", height:82};
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
                    return {styleName:"questPanelFooter", height:60};
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
                    return {clipContent:false, childDescriptors:[new UIComponentDescriptor({type:Label, id:"headline", stylesFactory:function () : void
                    {
                        this.horizontalCenter = "0";
                        this.top = "-20";
                        this.fontWeight = "bold";
                        this.textAlign = "center";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.left = "5";
                        this.right = "5";
                        this.top = "2";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {styleName:"detailsHeader", childDescriptors:[new UIComponentDescriptor({type:Image, id:"questAdvisorMedium", stylesFactory:function () : void
                        {
                            null.top = this;
                            this.left = "8";
                            return;
                        }// end function
                        }), new UIComponentDescriptor({type:Text, id:"InfoText", stylesFactory:function () : void
                        {
                            this.left = "60";
                            this.top = "10";
                            this.color = 16777215;
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {percentWidth:100, percentHeight:100, selectable:false};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        null.left = this;
                        this.right = "8";
                        this.top = "75";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {styleName:"detailsContentBox", height:140, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                        {
                            this.left = "5";
                            this.right = "5";
                            this.top = "5";
                            this.bottom = "5";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {styleName:"detailsSubHeader", childDescriptors:[new UIComponentDescriptor({type:Text, id:"legalterms", stylesFactory:function () : void
                            {
                                this.left = "5";
                                this.top = "5";
                                this.color = 16777215;
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:null, percentHeight:100, selectable:false};
                            }// end function
                            })]};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.top = "70";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, percentWidth:100, height:10};
                    }// end function
                    }), new UIComponentDescriptor({type:Image, stylesFactory:function () : void
                    {
                        null.horizontalCenter = this;
                        this.top = "60";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.bottom = "55";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, percentWidth:100, height:10};
                    }// end function
                    }), new UIComponentDescriptor({type:HBox, stylesFactory:function () : void
                    {
                        null.horizontalGap = this;
                        this.horizontalCenter = "0";
                        this.bottom = "10";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {childDescriptors:[new UIComponentDescriptor({type:StandardButton, id:"btnYES", stylesFactory:function () : void
                        {
                            null.horizontalCenter = this;
                            this.bottom = "10";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {playSound:false, width:150, height:26};
                        }// end function
                        }), new UIComponentDescriptor({type:StandardButton, id:"btnNO", stylesFactory:function () : void
                        {
                            this.horizontalCenter = "0";
                            this.bottom = "10";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {playSound:false, width:150, height:26};
                        }// end function
                        })]};
                    }// end function
                    })]};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental3_png_1841140076 = LegalPanel__embed_mxml_____data_src_gfx_embedded_quest_quest_ornamental3_png_1841140076;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 428;
            this.height = 310;
            this.cacheAsBitmap = true;
            this.clipContent = false;
            this._LegalPanel_Fade1_i();
            this._LegalPanel_Fade2_i();
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

        private function _LegalPanel_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeIn = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        override public function initialize() : void
        {
            var target:LegalPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._LegalPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_LegalPanelWatcherSetupUtil");
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

        public function get questAdvisorMedium() : Image
        {
            return this._2011242899questAdvisorMedium;
        }// end function

        public function get InfoText() : Text
        {
            return this._242580251InfoText;
        }// end function

        public function get btnNO() : StandardButton
        {
            return this._94069021btnNO;
        }// end function

        public function set questAdvisorMedium(param1:Image) : void
        {
            var _loc_2:* = this._2011242899questAdvisorMedium;
            if (_loc_2 !== param1)
            {
                this._2011242899questAdvisorMedium = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "questAdvisorMedium", _loc_2, param1));
            }
            return;
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

        private function _LegalPanel_bindingsSetup() : Array
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
                this.setStyle("hideEffect", param1);
                return;
            }// end function
            , "this.hideEffect");
            result[1] = binding;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap("InfoOrnamentalTop1");
            }// end function
            , function (param1:Object) : void
            {
                null.source = null;
                return;
            }// end function
            , "ornament.source");
            result[2] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LegalTerms");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "headline.text");
            result[3] = binding;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap("QuestAdvisorMedium");
            }// end function
            , function (param1:Object) : void
            {
                null.source = param1;
                return;
            }// end function
            , "questAdvisorMedium.source");
            result[4] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "LegalInfo");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "InfoText.text");
            result[5] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = "LEGALTERM" + cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "LegalInfo");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "legalterms.text");
            result[6] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "IAgree");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnYES.label = param1;
                return;
            }// end function
            , "btnYES.label");
            result[7] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "IDisagree");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnNO.label");
            result[8] = binding;
            return result;
        }// end function

        private function _LegalPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.fadeIn;
            _loc_1 = this.fadeOut;
            _loc_1 = gAssetManager.GetBitmap("InfoOrnamentalTop1");
            _loc_1 = "HEADLINE" + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LegalTerms");
            _loc_1 = gAssetManager.GetBitmap("QuestAdvisorMedium");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "LegalInfo");
            _loc_1 = "LEGALTERM" + cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "LegalInfo");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "IAgree");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "IDisagree");
            return;
        }// end function

        public function set InfoText(param1:Text) : void
        {
            var _loc_2:* = this._242580251InfoText;
            if (_loc_2 !== param1)
            {
                this._242580251InfoText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "InfoText", _loc_2, param1));
            }
            return;
        }// end function

        public function get completedHeader() : Canvas
        {
            return this._559784120completedHeader;
        }// end function

        public function get fadeOut() : Fade
        {
            return this._1091436750fadeOut;
        }// end function

        public function set btnNO(param1:StandardButton) : void
        {
            var _loc_2:* = this._94069021btnNO;
            if (_loc_2 !== param1)
            {
                this._94069021btnNO = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnNO", _loc_2, param1));
            }
            return;
        }// end function

        public function get ornament() : Image
        {
            return this._1516759348ornament;
        }// end function

        public function get fadeIn() : Fade
        {
            return this._1282133823fadeIn;
        }// end function

        private function _LegalPanel_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            _loc_1.addEventListener("effectEnd", this.__fadeOut_effectEnd);
            return _loc_1;
        }// end function

        public function get headline() : Label
        {
            return this._1115058732headline;
        }// end function

        public function set btnYES(param1:StandardButton) : void
        {
            var _loc_2:* = this._1378817301btnYES;
            if (_loc_2 !== param1)
            {
                this._1378817301btnYES = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnYES", _loc_2, param1));
            }
            return;
        }// end function

        public function set legalterms(param1:Text) : void
        {
            var _loc_2:* = this._598651502legalterms;
            if (_loc_2 !== param1)
            {
                this._598651502legalterms = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "legalterms", _loc_2, param1));
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

        public function get btnYES() : StandardButton
        {
            return this._1378817301btnYES;
        }// end function

        public function get legalterms() : Text
        {
            return this._598651502legalterms;
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

        public function get content() : Canvas
        {
            return this._951530617content;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
