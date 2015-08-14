package GUI.Components
{
    import Enums.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;

    public class AdventurePanel extends Canvas implements IBindingClient
    {
        private var _478093857durationBar:HealthBar;
        private var _1067478618objectives:Canvas;
        private var _761451283buttonsFinished:HBox;
        private var _94069048btnOK:StandardButton;
        private var _1282133823fadeIn:Fade;
        private var _1354452517playerListPanel:Canvas;
        private var _1091436750fadeOut:Fade;
        private var _2097344358btnStart:StandardButton;
        private var _1187372404playerListHeader:Canvas;
        private var _531613159buttonsActive:HBox;
        private var _1955813973btnReturnHome:StandardButton;
        var _bindingsByDestination:Object;
        private var _714806460playerCount2:Label;
        private var _1516759348ornament:Image;
        private var _1447389419teaserImage:Image;
        private var _3565638todo:Text;
        private var _117924854btnCancel:StandardButton;
        private var _1805383481missionHeader:Canvas;
        private var _embed_mxml_____data_src_gfx_embedded_adventure_adventure_ornamental_top_png_1619304060:Class;
        private var _73027624missionPanel:Canvas;
        public var _AdventurePanel_Label1:Label;
        public var _AdventurePanel_Label2:Label;
        public var _AdventurePanel_Label3:Label;
        private var _2022321142playerCountPanel:Canvas;
        private var _2095605535playerList:HBox;
        var _watchers:Array;
        private var _1440651116difficultyIndicator:AdventureDifficultyIndicator;
        var _bindingsBeginWithWord:Object;
        private var _1740929901buttonsInitialized:HBox;
        private var _714806461playerCount1:Label;
        private var _2082343164btnClose:CloseButton;
        private var _951530617content:Canvas;
        var _bindings:Array;
        private var _1010579337opener:Text;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function AdventurePanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:460, height:588, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"content", stylesFactory:function () : void
                {
                    this.left = "18";
                    this.right = "18";
                    this.top = "88";
                    this.bottom = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {clipContent:false, horizontalScrollPolicy:"off", verticalScrollPolicy:"off", styleName:"basicPanel", childDescriptors:[new UIComponentDescriptor({type:CloseButton, id:"btnClose", stylesFactory:function () : void
                    {
                        this.top = "5";
                        this.right = "15";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:Label, id:"_AdventurePanel_Label1", stylesFactory:function () : void
                    {
                        this.left = "42";
                        this.top = "8";
                        this.fontWeight = "bold";
                        this.textAlign = "center";
                        this.right = "46";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:Image, id:"teaserImage", stylesFactory:function () : void
                    {
                        null.top = this;
                        this.left = "15";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, height:167, scaleContent:false};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.left = "160";
                        this.right = "13";
                        this.top = "33";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {height:166, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                        {
                            this.left = "10";
                            this.top = "11";
                            this.right = "5";
                            this.bottom = "12";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {horizontalScrollPolicy:"off", verticalScrollPolicy:"auto", childDescriptors:[new UIComponentDescriptor({type:Text, id:"opener", stylesFactory:function () : void
                            {
                                this.paddingRight = 15;
                                this.color = 16777215;
                                this.fontWeight = "normal";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:100, selectable:false};
                            }// end function
                            })]};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:AdventureDifficultyIndicator, id:"difficultyIndicator", stylesFactory:function () : void
                    {
                        null.left = this;
                        this.right = "13";
                        this.top = "202";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, id:"missionHeader", stylesFactory:function () : void
                    {
                        null.left = this;
                        this.right = "13";
                        this.top = "237";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {styleName:"detailsSubHeader", height:18, childDescriptors:[new UIComponentDescriptor({type:Label, id:"_AdventurePanel_Label2", stylesFactory:function () : void
                        {
                            null.top = this;
                            this.horizontalCenter = "0";
                            this.color = 16777215;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, id:"missionPanel", stylesFactory:function () : void
                    {
                        null.left = this;
                        this.right = "14";
                        this.top = "255";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {styleName:"detailsContentBox", height:90, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"objectives", stylesFactory:function () : void
                        {
                            this.left = "10";
                            this.top = "7";
                            this.right = "5";
                            this.bottom = "7";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {horizontalScrollPolicy:"off", verticalScrollPolicy:"auto", childDescriptors:[new UIComponentDescriptor({type:Text, id:"todo", stylesFactory:function () : void
                            {
                                this.paddingRight = 10;
                                this.color = 16777215;
                                this.fontWeight = "normal";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:100, selectable:false};
                            }// end function
                            })]};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, id:"playerListHeader", stylesFactory:function () : void
                    {
                        null.left = this;
                        this.right = "13";
                        this.top = "347";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {styleName:"detailsSubHeader", height:18, childDescriptors:[new UIComponentDescriptor({type:Label, id:"_AdventurePanel_Label3", stylesFactory:function () : void
                        {
                            this.top = "1";
                            this.horizontalCenter = "0";
                            this.color = 16777215;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, id:"playerListPanel", stylesFactory:function () : void
                    {
                        this.left = "16";
                        this.right = "14";
                        this.top = "365";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {styleName:"detailsContentBox", height:75, childDescriptors:[new UIComponentDescriptor({type:HBox, id:"playerList", stylesFactory:function () : void
                        {
                            this.horizontalCenter = "0";
                            this.verticalCenter = "0";
                            this.horizontalGap = 15;
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, id:"playerCountPanel", stylesFactory:function () : void
                    {
                        this.left = "16";
                        this.right = "14";
                        this.top = "440";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {styleName:"detailsContentBox", height:25, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                        {
                            this.bottom = "0";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {styleName:"detailsSubContentBox", percentWidth:100, height:25, childDescriptors:[new UIComponentDescriptor({type:Label, id:"playerCount1", stylesFactory:function () : void
                            {
                                this.left = "10";
                                this.verticalCenter = "0";
                                return;
                            }// end function
                            }), new UIComponentDescriptor({type:Label, id:"playerCount2", stylesFactory:function () : void
                            {
                                null.right = this;
                                this.verticalCenter = "0";
                                this.textAlign = "right";
                                return;
                            }// end function
                            })]};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:HealthBar, id:"durationBar", events:{toolTipCreate:"__durationBar_toolTipCreate"}, stylesFactory:function () : void
                    {
                        this.left = "8";
                        this.right = "6";
                        this.top = "470";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:HBox, id:"buttonsInitialized", stylesFactory:function () : void
                    {
                        this.horizontalCenter = "0";
                        this.bottom = "7";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {childDescriptors:[new UIComponentDescriptor({type:StandardButton, id:"btnStart", events:{toolTipCreate:"__btnStart_toolTipCreate"}, propertiesFactory:function () : Object
                        {
                            return {null:150, height:32};
                        }// end function
                        }), new UIComponentDescriptor({type:StandardButton, id:"btnCancel", propertiesFactory:function () : Object
                        {
                            return {null:150, height:32};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:HBox, id:"buttonsActive", stylesFactory:function () : void
                    {
                        null.horizontalCenter = this;
                        this.bottom = "7";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {visible:false, childDescriptors:[new UIComponentDescriptor({type:StandardButton, id:"btnOK", propertiesFactory:function () : Object
                        {
                            return {null:null, height:32};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:HBox, id:"buttonsFinished", stylesFactory:function () : void
                    {
                        null.horizontalCenter = this;
                        this.bottom = "7";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {visible:false, childDescriptors:[new UIComponentDescriptor({type:StandardButton, id:"btnReturnHome", propertiesFactory:function () : Object
                        {
                            return {null:null};
                        }// end function
                        })]};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"ornament", stylesFactory:function () : void
                {
                    null.top = this;
                    this.horizontalCenter = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_adventure_adventure_ornamental_top_png_1619304060 = AdventurePanel__embed_mxml_____data_src_gfx_embedded_adventure_adventure_ornamental_top_png_1619304060;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 460;
            this.height = 588;
            this._AdventurePanel_Fade1_i();
            this._AdventurePanel_Fade2_i();
            return;
        }// end function

        public function get playerCountPanel() : Canvas
        {
            return this._2022321142playerCountPanel;
        }// end function

        public function set playerCountPanel(param1:Canvas) : void
        {
            var _loc_2:* = this._2022321142playerCountPanel;
            if (_loc_2 !== param1)
            {
                this._2022321142playerCountPanel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "playerCountPanel", _loc_2, param1));
            }
            return;
        }// end function

        public function get buttonsFinished() : HBox
        {
            return this._761451283buttonsFinished;
        }// end function

        public function set playerListHeader(param1:Canvas) : void
        {
            var _loc_2:* = this._1187372404playerListHeader;
            if (_loc_2 !== param1)
            {
                this._1187372404playerListHeader = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "playerListHeader", _loc_2, param1));
            }
            return;
        }// end function

        public function get playerList() : HBox
        {
            return this._2095605535playerList;
        }// end function

        public function get playerListPanel() : Canvas
        {
            return this._1354452517playerListPanel;
        }// end function

        public function set buttonsFinished(param1:HBox) : void
        {
            var _loc_2:* = this._761451283buttonsFinished;
            if (_loc_2 !== param1)
            {
                this._761451283buttonsFinished = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buttonsFinished", _loc_2, param1));
            }
            return;
        }// end function

        public function set buttonsInitialized(param1:HBox) : void
        {
            var _loc_2:* = this._1740929901buttonsInitialized;
            if (_loc_2 !== param1)
            {
                this._1740929901buttonsInitialized = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buttonsInitialized", _loc_2, param1));
            }
            return;
        }// end function

        public function set difficultyIndicator(param1:AdventureDifficultyIndicator) : void
        {
            var _loc_2:* = this._1440651116difficultyIndicator;
            if (_loc_2 !== param1)
            {
                this._1440651116difficultyIndicator = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "difficultyIndicator", _loc_2, param1));
            }
            return;
        }// end function

        public function get fadeOut() : Fade
        {
            return this._1091436750fadeOut;
        }// end function

        public function get btnOK() : StandardButton
        {
            return this._94069048btnOK;
        }// end function

        public function get missionHeader() : Canvas
        {
            return this._1805383481missionHeader;
        }// end function

        public function get ornament() : Image
        {
            return this._1516759348ornament;
        }// end function

        public function set playerList(param1:HBox) : void
        {
            var _loc_2:* = this._2095605535playerList;
            if (_loc_2 !== param1)
            {
                this._2095605535playerList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "playerList", _loc_2, param1));
            }
            return;
        }// end function

        public function get playerCount1() : Label
        {
            return this._714806461playerCount1;
        }// end function

        public function get playerCount2() : Label
        {
            return this._714806460playerCount2;
        }// end function

        private function _AdventurePanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.fadeIn;
            _loc_1 = this.fadeOut;
            _loc_1 = label;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Mission");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "AttendingPlayers");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "StartAdventure");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ReturnHome");
            return;
        }// end function

        public function get todo() : Text
        {
            return this._3565638todo;
        }// end function

        public function set playerListPanel(param1:Canvas) : void
        {
            var _loc_2:* = this._1354452517playerListPanel;
            if (_loc_2 !== param1)
            {
                this._1354452517playerListPanel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "playerListPanel", _loc_2, param1));
            }
            return;
        }// end function

        private function _AdventurePanel_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            _loc_1.addEventListener("effectEnd", this.__fadeOut_effectEnd);
            return _loc_1;
        }// end function

        public function set btnReturnHome(param1:StandardButton) : void
        {
            var _loc_2:* = this._1955813973btnReturnHome;
            if (_loc_2 !== param1)
            {
                this._1955813973btnReturnHome = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnReturnHome", _loc_2, param1));
            }
            return;
        }// end function

        public function get objectives() : Canvas
        {
            return this._1067478618objectives;
        }// end function

        private function _AdventurePanel_bindingsSetup() : Array
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
            binding = new Binding(this, function () : String
            {
                var _loc_1:String = null;
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_AdventurePanel_Label1.text");
            result[2] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Mission");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _AdventurePanel_Label2.text = param1;
                return;
            }// end function
            , "_AdventurePanel_Label2.text");
            result[3] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "AttendingPlayers");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "_AdventurePanel_Label3.text");
            result[4] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "StartAdventure");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnStart.label");
            result[5] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnCancel.label = param1;
                return;
            }// end function
            , "btnCancel.label");
            result[6] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
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
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ReturnHome");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnReturnHome.label");
            result[8] = binding;
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

        public function get btnStart() : StandardButton
        {
            return this._2097344358btnStart;
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

        public function set missionHeader(param1:Canvas) : void
        {
            var _loc_2:* = this._1805383481missionHeader;
            if (_loc_2 !== param1)
            {
                this._1805383481missionHeader = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "missionHeader", _loc_2, param1));
            }
            return;
        }// end function

        public function get opener() : Text
        {
            return this._1010579337opener;
        }// end function

        public function get content() : Canvas
        {
            return this._951530617content;
        }// end function

        public function __durationBar_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
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

        public function __btnStart_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_ERROR_string, event, !this.btnStart.enabled);
            return;
        }// end function

        public function set playerCount2(param1:Label) : void
        {
            var _loc_2:* = this._714806460playerCount2;
            if (_loc_2 !== param1)
            {
                this._714806460playerCount2 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "playerCount2", _loc_2, param1));
            }
            return;
        }// end function

        public function get playerListHeader() : Canvas
        {
            return this._1187372404playerListHeader;
        }// end function

        public function set playerCount1(param1:Label) : void
        {
            var _loc_2:* = this._714806461playerCount1;
            if (_loc_2 !== param1)
            {
                this._714806461playerCount1 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "playerCount1", _loc_2, param1));
            }
            return;
        }// end function

        private function _AdventurePanel_Fade1_i() : Fade
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
            var target:AdventurePanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._AdventurePanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_AdventurePanelWatcherSetupUtil");
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

        public function get buttonsInitialized() : HBox
        {
            return this._1740929901buttonsInitialized;
        }// end function

        public function get difficultyIndicator() : AdventureDifficultyIndicator
        {
            return this._1440651116difficultyIndicator;
        }// end function

        public function set todo(param1:Text) : void
        {
            var _loc_2:* = this._3565638todo;
            if (_loc_2 !== param1)
            {
                this._3565638todo = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "todo", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnReturnHome() : StandardButton
        {
            return this._1955813973btnReturnHome;
        }// end function

        public function set objectives(param1:Canvas) : void
        {
            var _loc_2:* = this._1067478618objectives;
            if (_loc_2 !== param1)
            {
                this._1067478618objectives = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "objectives", _loc_2, param1));
            }
            return;
        }// end function

        public function set missionPanel(param1:Canvas) : void
        {
            var _loc_2:* = this._73027624missionPanel;
            if (_loc_2 !== param1)
            {
                this._73027624missionPanel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "missionPanel", _loc_2, param1));
            }
            return;
        }// end function

        public function set durationBar(param1:HealthBar) : void
        {
            var _loc_2:* = this._478093857durationBar;
            if (_loc_2 !== param1)
            {
                this._478093857durationBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "durationBar", _loc_2, param1));
            }
            return;
        }// end function

        public function get fadeIn() : Fade
        {
            return this._1282133823fadeIn;
        }// end function

        public function set btnStart(param1:StandardButton) : void
        {
            var _loc_2:* = this._2097344358btnStart;
            if (_loc_2 !== param1)
            {
                this._2097344358btnStart = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnStart", _loc_2, param1));
            }
            return;
        }// end function

        public function set buttonsActive(param1:HBox) : void
        {
            var _loc_2:* = this._531613159buttonsActive;
            if (_loc_2 !== param1)
            {
                this._531613159buttonsActive = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buttonsActive", _loc_2, param1));
            }
            return;
        }// end function

        public function set teaserImage(param1:Image) : void
        {
            var _loc_2:* = this._1447389419teaserImage;
            if (_loc_2 !== param1)
            {
                this._1447389419teaserImage = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "teaserImage", _loc_2, param1));
            }
            return;
        }// end function

        public function get missionPanel() : Canvas
        {
            return this._73027624missionPanel;
        }// end function

        public function __fadeOut_effectEnd(event:EffectEvent) : void
        {
            globalFlash.gui.ShowQuestWindowDelayed();
            return;
        }// end function

        public function get durationBar() : HealthBar
        {
            return this._478093857durationBar;
        }// end function

        public function get buttonsActive() : HBox
        {
            return this._531613159buttonsActive;
        }// end function

        public function get teaserImage() : Image
        {
            return this._1447389419teaserImage;
        }// end function

        public function set btnCancel(param1:StandardButton) : void
        {
            var _loc_2:* = this._117924854btnCancel;
            if (_loc_2 !== param1)
            {
                this._117924854btnCancel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnCancel", _loc_2, param1));
            }
            return;
        }// end function

        public function set opener(param1:Text) : void
        {
            var _loc_2:* = this._1010579337opener;
            if (_loc_2 !== param1)
            {
                this._1010579337opener = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "opener", _loc_2, param1));
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

        public function get btnCancel() : StandardButton
        {
            return this._117924854btnCancel;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
