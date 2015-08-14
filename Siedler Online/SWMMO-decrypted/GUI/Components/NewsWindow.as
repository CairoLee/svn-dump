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
    import mx.effects.easing.*;
    import mx.events.*;

    public class NewsWindow extends Canvas implements IBindingClient
    {
        private var _1282133823fadeIn:Fade;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _94069048btnOK:StandardButton;
        var _watchers:Array;
        private var _1091436750fadeOut:Fade;
        private var _100313435image:Image;
        private var _tipText:String;
        private var _1393759000loadingLabel:Label;
        private var _912608249hideTip:Fade;
        private var _559784120completedHeader:Canvas;
        var _bindingsBeginWithWord:Object;
        var _bindingsByDestination:Object;
        private var _1059651549tipOfTheDay:Text;
        private var _1671859379lastChanges:Text;
        private var _225929018pulsate:Sequence;
        public var _NewsWindow_Label2:Label;
        private var _951530617content:Canvas;
        private var _1115058732headline:Label;
        var _bindings:Array;
        private var _2067279966showTip:Fade;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function NewsWindow()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {width:500, height:380, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
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
                    null.left = this;
                    this.right = "0";
                    this.top = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {styleName:"questPanelHeader", height:82, visible:true};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "5";
                    this.bottom = "-5";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, height:80};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"headline", stylesFactory:function () : void
                {
                    this.left = "46";
                    this.top = "10";
                    this.fontWeight = "bold";
                    this.textAlign = "center";
                    this.right = "46";
                    this.color = 0;
                    return;
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
                    return {childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.left = "2";
                        this.right = "2";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {styleName:"detailsHeader", height:102, childDescriptors:[new UIComponentDescriptor({type:Image, id:"image", stylesFactory:function () : void
                        {
                            this.left = "15";
                            this.top = "20";
                            return;
                        }// end function
                        }), new UIComponentDescriptor({type:Text, id:"tipOfTheDay", stylesFactory:function () : void
                        {
                            null.left = this;
                            this.right = "10";
                            this.top = "10";
                            this.bottom = "5";
                            this.color = 16777215;
                            this.fontWeight = "normal";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:null};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.left = "7";
                        this.right = "6";
                        this.top = "105";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {styleName:"detailsSubHeader", height:18, childDescriptors:[new UIComponentDescriptor({type:Label, id:"_NewsWindow_Label2", stylesFactory:function () : void
                        {
                            this.top = "1";
                            this.horizontalCenter = "0";
                            this.color = 16777215;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.left = "8";
                        this.right = "7";
                        this.top = "123";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {styleName:"detailsContentBox", height:135, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                        {
                            this.left = "10";
                            this.top = "10";
                            this.right = "10";
                            this.bottom = "11";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {verticalScrollPolicy:"auto", horizontalScrollPolicy:"off", childDescriptors:[new UIComponentDescriptor({type:Text, id:"lastChanges", stylesFactory:function () : void
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
                    }), new UIComponentDescriptor({type:Label, id:"loadingLabel", stylesFactory:function () : void
                    {
                        null.color = this;
                        this.fontWeight = "bold";
                        this.horizontalCenter = "0";
                        this.bottom = "23";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:StandardButton, id:"btnOK", stylesFactory:function () : void
                    {
                        null.horizontalCenter = this;
                        this.bottom = "19";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, visible:false, label:"Ok", width:70, height:26};
                    }// end function
                    })]};
                }// end function
                })]};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 500;
            this.height = 380;
            this.cacheAsBitmap = true;
            this.horizontalScrollPolicy = "off";
            this.verticalScrollPolicy = "off";
            this.clipContent = false;
            this._NewsWindow_Fade1_i();
            this._NewsWindow_Fade2_i();
            this._NewsWindow_Fade4_i();
            this._NewsWindow_Sequence1_i();
            this._NewsWindow_Fade3_i();
            return;
        }// end function

        public function get hideTip() : Fade
        {
            return this._912608249hideTip;
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

        public function set hideTip(param1:Fade) : void
        {
            var _loc_2:* = this._912608249hideTip;
            if (_loc_2 !== param1)
            {
                this._912608249hideTip = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "hideTip", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:NewsWindow;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._NewsWindow_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_NewsWindowWatcherSetupUtil");
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

        public function set pulsate(param1:Sequence) : void
        {
            var _loc_2:* = this._225929018pulsate;
            if (_loc_2 !== param1)
            {
                this._225929018pulsate = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "pulsate", _loc_2, param1));
            }
            return;
        }// end function

        public function set lastChanges(param1:Text) : void
        {
            var _loc_2:* = this._1671859379lastChanges;
            if (_loc_2 !== param1)
            {
                this._1671859379lastChanges = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "lastChanges", _loc_2, param1));
            }
            return;
        }// end function

        public function get loadingLabel() : Label
        {
            return this._1393759000loadingLabel;
        }// end function

        private function _NewsWindow_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            _loc_1.addEventListener("effectEnd", this.__fadeOut_effectEnd);
            return _loc_1;
        }// end function

        private function _NewsWindow_Fade4_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.hideTip = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            _loc_1.addEventListener("effectEnd", this.__hideTip_effectEnd);
            return _loc_1;
        }// end function

        private function _NewsWindow_Fade6_c() : Fade
        {
            var _loc_1:* = new Fade();
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0.5;
            _loc_1.duration = 800;
            _loc_1.easingFunction = Cubic.easeIn;
            return _loc_1;
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

        public function set tipOfTheDay(param1:Text) : void
        {
            var _loc_2:* = this._1059651549tipOfTheDay;
            if (_loc_2 !== param1)
            {
                this._1059651549tipOfTheDay = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "tipOfTheDay", _loc_2, param1));
            }
            return;
        }// end function

        public function set showTip(param1:Fade) : void
        {
            var _loc_2:* = this._2067279966showTip;
            if (_loc_2 !== param1)
            {
                this._2067279966showTip = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "showTip", _loc_2, param1));
            }
            return;
        }// end function

        public function set image(param1:Image) : void
        {
            var _loc_2:* = this._100313435image;
            if (_loc_2 !== param1)
            {
                this._100313435image = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "image", _loc_2, param1));
            }
            return;
        }// end function

        public function get completedHeader() : Canvas
        {
            return this._559784120completedHeader;
        }// end function

        public function get fadeIn() : Fade
        {
            return this._1282133823fadeIn;
        }// end function

        public function get pulsate() : Sequence
        {
            return this._225929018pulsate;
        }// end function

        public function set loadingLabel(param1:Label) : void
        {
            var _loc_2:* = this._1393759000loadingLabel;
            if (_loc_2 !== param1)
            {
                this._1393759000loadingLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "loadingLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function get lastChanges() : Text
        {
            return this._1671859379lastChanges;
        }// end function

        public function get fadeOut() : Fade
        {
            return this._1091436750fadeOut;
        }// end function

        public function set tipText(param1:String) : void
        {
            if (this.tipOfTheDay.text == "")
            {
                this.tipOfTheDay.text = param1;
            }
            else
            {
                this._tipText = param1;
                this.tipOfTheDay.visible = false;
            }
            return;
        }// end function

        public function __fadeOut_effectEnd(event:EffectEvent) : void
        {
            globalFlash.gui.ShowQuestWindowDelayed();
            return;
        }// end function

        public function get showTip() : Fade
        {
            return this._2067279966showTip;
        }// end function

        private function _NewsWindow_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeIn = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        public function get headline() : Label
        {
            return this._1115058732headline;
        }// end function

        public function __hideTip_effectEnd(event:EffectEvent) : void
        {
            var event:* = event;
            this.tipOfTheDay.text = this._tipText;
            setInterval(function () : void
            {
                null.visible = null;
                return;
            }// end function
            , 50);
            return;
        }// end function

        private function _NewsWindow_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.fadeIn;
            _loc_1 = this.fadeOut;
            _loc_1 = this.loadingLabel;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "TipOfTheDay");
            _loc_1 = gAssetManager.GetBitmap("QuestAdvisor");
            _loc_1 = this.showTip;
            _loc_1 = this.hideTip;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LatestChanges");
            return;
        }// end function

        private function _NewsWindow_Fade5_c() : Fade
        {
            var _loc_1:* = new Fade();
            _loc_1.alphaFrom = 0.5;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 500;
            _loc_1.easingFunction = Cubic.easeOut;
            return _loc_1;
        }// end function

        public function get image() : Image
        {
            return this._100313435image;
        }// end function

        private function _NewsWindow_Fade3_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.showTip = _loc_1;
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

        private function _NewsWindow_bindingsSetup() : Array
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
            binding = new Binding(this, function () : Object
            {
                return loadingLabel;
            }// end function
            , function (param1:Object) : void
            {
                pulsate.target = param1;
                return;
            }// end function
            , "pulsate.target");
            result[2] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "TipOfTheDay");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                headline.text = param1;
                return;
            }// end function
            , "headline.text");
            result[3] = binding;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap("QuestAdvisor");
            }// end function
            , function (param1:Object) : void
            {
                null.source = null;
                return;
            }// end function
            , "image.source");
            result[4] = binding;
            binding = new Binding(this, function ()
            {
                return showTip;
            }// end function
            , function (param1) : void
            {
                tipOfTheDay.setStyle("showEffect", param1);
                return;
            }// end function
            , "tipOfTheDay.showEffect");
            result[5] = binding;
            binding = new Binding(this, function ()
            {
                return hideTip;
            }// end function
            , function (param1) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "tipOfTheDay.hideEffect");
            result[6] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "LatestChanges");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_NewsWindow_Label2.text");
            result[7] = binding;
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

        public function get tipOfTheDay() : Text
        {
            return this._1059651549tipOfTheDay;
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

        public function get content() : Canvas
        {
            return this._951530617content;
        }// end function

        private function _NewsWindow_Sequence1_i() : Sequence
        {
            var _loc_1:* = new Sequence();
            this.pulsate = _loc_1;
            _loc_1.repeatCount = 0;
            _loc_1.children = [this._NewsWindow_Fade5_c(), this._NewsWindow_Fade6_c()];
            BindingManager.executeBindings(this, "pulsate", this.pulsate);
            return _loc_1;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
