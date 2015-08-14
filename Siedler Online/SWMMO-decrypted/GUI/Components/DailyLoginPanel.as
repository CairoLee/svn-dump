package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;

    public class DailyLoginPanel extends Canvas implements IBindingClient
    {
        private var _1282133823fadeIn:Fade;
        private var _94069048btnOK:StandardButton;
        private var _640616456day7result:Image;
        private var _991839797day4result:Image;
        private var _3076121day5:Frame;
        private var _22126794daysLabels:HBox;
        private var _1440444646day6label:Label;
        private var _3076123day7:Frame;
        private var _1091436750fadeOut:Fade;
        private var _1411815495day7label:Label;
        public var _DailyLoginPanel_Image1:Image;
        private var _1528120137day6result:Image;
        var _bindingsByDestination:Object;
        private var _1724546052description:Text;
        private var _572567713daysRemaining:Text;
        private var _3076117day1:Frame;
        private var _3076119day3:Frame;
        private var _3076120day4:Frame;
        private var _3076122day6:Frame;
        var _watchers:Array;
        private var _1526332099day3label:Label;
        private var _1497702948day4label:Label;
        public var _DailyLoginPanel_Label2:Label;
        private var _104336116day3result:Image;
        private var _783167565day2result:Image;
        private var _1670671246day1result:Image;
        private var _1583590401day1label:Label;
        private var _1879343478day5result:Image;
        private var _1554961250day2label:Label;
        var _bindingsBeginWithWord:Object;
        private var _915835362rewardsList:HBox;
        private var _951530617content:Canvas;
        private var _1115058732headline:Label;
        var _bindings:Array;
        private var _3076118day2:Frame;
        private var _1469073797day5label:Label;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function DailyLoginPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {width:470, height:312, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    this.top = "5";
                    this.left = "5";
                    this.right = "9";
                    this.bottom = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "0";
                    this.top = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, height:82};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"_DailyLoginPanel_Image1", stylesFactory:function () : void
                {
                    this.horizontalCenter = "0";
                    this.top = "-35";
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
                        return {styleName:"detailsHeader", height:66, horizontalScrollPolicy:"off", verticalScrollPolicy:"off", childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                        {
                            null.left = this;
                            this.right = "15";
                            this.top = "9";
                            this.bottom = "5";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {horizontalScrollPolicy:"off", verticalScrollPolicy:"auto", childDescriptors:[new UIComponentDescriptor({type:Text, id:"description", stylesFactory:function () : void
                            {
                                this.color = 16777215;
                                this.fontWeight = "normal";
                                this.textAlign = "center";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {selectable:false, percentWidth:100};
                            }// end function
                            })]};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        this.left = "7";
                        this.right = "6";
                        this.top = "69";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {styleName:"detailsSubHeader", height:18, childDescriptors:[new UIComponentDescriptor({type:Label, id:"_DailyLoginPanel_Label2", stylesFactory:function () : void
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
                        this.left = "8";
                        this.right = "7";
                        this.top = "87";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {styleName:"detailsContentBox", height:90, childDescriptors:[new UIComponentDescriptor({type:HBox, id:"rewardsList", stylesFactory:function () : void
                        {
                            this.horizontalCenter = "0";
                            this.top = "3";
                            this.horizontalGap = 2;
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:[new UIComponentDescriptor({type:Frame, id:"day1", events:{toolTipCreate:"__day1_toolTipCreate"}}), new UIComponentDescriptor({type:Frame, id:"day2", events:{toolTipCreate:"__day2_toolTipCreate"}}), new UIComponentDescriptor({type:Frame, id:"day3", events:{toolTipCreate:"__day3_toolTipCreate"}}), new UIComponentDescriptor({type:Frame, id:"day4", events:{toolTipCreate:"__day4_toolTipCreate"}}), new UIComponentDescriptor({type:Frame, id:"day5", events:{toolTipCreate:"__day5_toolTipCreate"}}), new UIComponentDescriptor({type:Frame, id:"day6", events:{toolTipCreate:"__day6_toolTipCreate"}}), new UIComponentDescriptor({type:Frame, id:"day7", events:{toolTipCreate:"__day7_toolTipCreate"}})]};
                        }// end function
                        }), new UIComponentDescriptor({type:HBox, stylesFactory:function () : void
                        {
                            this.horizontalCenter = "-2";
                            this.top = "5";
                            this.horizontalGap = 4;
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {childDescriptors:[new UIComponentDescriptor({type:Image, id:"day1result", propertiesFactory:function () : Object
                            {
                                return {width:54, height:65, scaleContent:false, visible:false};
                            }// end function
                            }), new UIComponentDescriptor({type:Image, id:"day2result", propertiesFactory:function () : Object
                            {
                                return {width:54, height:65, scaleContent:false, visible:false};
                            }// end function
                            }), new UIComponentDescriptor({type:Image, id:"day3result", propertiesFactory:function () : Object
                            {
                                return {null:54, height:65, scaleContent:false, visible:false};
                            }// end function
                            }), new UIComponentDescriptor({type:Image, id:"day4result", propertiesFactory:function () : Object
                            {
                                return {null:54, height:65, scaleContent:false, visible:false};
                            }// end function
                            }), new UIComponentDescriptor({type:Image, id:"day5result", propertiesFactory:function () : Object
                            {
                                return {width:54, height:65, scaleContent:false, visible:false};
                            }// end function
                            }), new UIComponentDescriptor({type:Image, id:"day6result", propertiesFactory:function () : Object
                            {
                                return {null:54, height:65, scaleContent:false, visible:false};
                            }// end function
                            }), new UIComponentDescriptor({type:Image, id:"day7result", propertiesFactory:function () : Object
                            {
                                return {null:null, height:65, scaleContent:false, visible:false};
                            }// end function
                            })]};
                        }// end function
                        }), new UIComponentDescriptor({type:HBox, id:"daysLabels", stylesFactory:function () : void
                        {
                            this.horizontalCenter = "0";
                            this.top = "71";
                            this.horizontalGap = 2;
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {childDescriptors:[new UIComponentDescriptor({type:Label, id:"day1label", stylesFactory:function () : void
                            {
                                this.textAlign = "center";
                                this.color = 16777215;
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:56};
                            }// end function
                            }), new UIComponentDescriptor({type:Label, id:"day2label", stylesFactory:function () : void
                            {
                                this.textAlign = "center";
                                this.color = 16777215;
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:56};
                            }// end function
                            }), new UIComponentDescriptor({type:Label, id:"day3label", stylesFactory:function () : void
                            {
                                this.textAlign = "center";
                                this.color = 16777215;
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {width:56};
                            }// end function
                            }), new UIComponentDescriptor({type:Label, id:"day4label", stylesFactory:function () : void
                            {
                                null.textAlign = this;
                                this.color = 16777215;
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:null};
                            }// end function
                            }), new UIComponentDescriptor({type:Label, id:"day5label", stylesFactory:function () : void
                            {
                                this.textAlign = "center";
                                this.color = 16777215;
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {width:56};
                            }// end function
                            }), new UIComponentDescriptor({type:Label, id:"day6label", stylesFactory:function () : void
                            {
                                this.textAlign = "center";
                                this.color = 16777215;
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:null};
                            }// end function
                            }), new UIComponentDescriptor({type:Label, id:"day7label", stylesFactory:function () : void
                            {
                                this.textAlign = "center";
                                this.color = 16777215;
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {null:56};
                            }// end function
                            })]};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                    {
                        null.left = this;
                        this.right = "6";
                        this.top = "180";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {styleName:"detailsSubHeader", height:42, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                        {
                            this.left = "15";
                            this.right = "15";
                            this.top = "5";
                            this.bottom = "1";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            var _loc_1:String = null;
                            return {horizontalScrollPolicy:"off", verticalScrollPolicy:"auto", childDescriptors:[new UIComponentDescriptor({type:Text, id:"daysRemaining", stylesFactory:function () : void
                            {
                                this.color = 16777215;
                                this.fontWeight = "normal";
                                this.textAlign = "center";
                                return;
                            }// end function
                            , propertiesFactory:function () : Object
                            {
                                return {selectable:false, percentWidth:100};
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
                        return {null:null, width:70, height:26};
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
            this.width = 470;
            this.height = 312;
            this.cacheAsBitmap = true;
            this.clipContent = false;
            this._DailyLoginPanel_Fade1_i();
            this._DailyLoginPanel_Fade2_i();
            return;
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

        public function get description() : Text
        {
            return this._1724546052description;
        }// end function

        public function get day1() : Frame
        {
            return this._3076117day1;
        }// end function

        public function get day2() : Frame
        {
            return this._3076118day2;
        }// end function

        public function get day3() : Frame
        {
            return this._3076119day3;
        }// end function

        public function get day6() : Frame
        {
            return this._3076122day6;
        }// end function

        public function get day7() : Frame
        {
            return this._3076123day7;
        }// end function

        public function set day5result(param1:Image) : void
        {
            var _loc_2:* = this._1879343478day5result;
            if (_loc_2 !== param1)
            {
                this._1879343478day5result = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day5result", _loc_2, param1));
            }
            return;
        }// end function

        public function get day5() : Frame
        {
            return this._3076121day5;
        }// end function

        public function get day6label() : Label
        {
            return this._1440444646day6label;
        }// end function

        public function set day1(param1:Frame) : void
        {
            var _loc_2:* = this._3076117day1;
            if (_loc_2 !== param1)
            {
                this._3076117day1 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day1", _loc_2, param1));
            }
            return;
        }// end function

        public function set day3(param1:Frame) : void
        {
            var _loc_2:* = this._3076119day3;
            if (_loc_2 !== param1)
            {
                this._3076119day3 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day3", _loc_2, param1));
            }
            return;
        }// end function

        public function set day5label(param1:Label) : void
        {
            var _loc_2:* = this._1469073797day5label;
            if (_loc_2 !== param1)
            {
                this._1469073797day5label = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day5label", _loc_2, param1));
            }
            return;
        }// end function

        public function set day5(param1:Frame) : void
        {
            var _loc_2:* = this._3076121day5;
            if (_loc_2 !== param1)
            {
                this._3076121day5 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day5", _loc_2, param1));
            }
            return;
        }// end function

        public function set day2(param1:Frame) : void
        {
            var _loc_2:* = this._3076118day2;
            if (_loc_2 !== param1)
            {
                this._3076118day2 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day2", _loc_2, param1));
            }
            return;
        }// end function

        public function set day6(param1:Frame) : void
        {
            var _loc_2:* = this._3076122day6;
            if (_loc_2 !== param1)
            {
                this._3076122day6 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day6", _loc_2, param1));
            }
            return;
        }// end function

        private function _DailyLoginPanel_Fade1_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeIn = _loc_1;
            _loc_1.alphaFrom = 0;
            _loc_1.alphaTo = 1;
            _loc_1.duration = 150;
            return _loc_1;
        }// end function

        public function __day2_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
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

        public function __day6_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set day6label(param1:Label) : void
        {
            var _loc_2:* = this._1440444646day6label;
            if (_loc_2 !== param1)
            {
                this._1440444646day6label = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day6label", _loc_2, param1));
            }
            return;
        }// end function

        public function set day2label(param1:Label) : void
        {
            var _loc_2:* = this._1554961250day2label;
            if (_loc_2 !== param1)
            {
                this._1554961250day2label = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day2label", _loc_2, param1));
            }
            return;
        }// end function

        public function get day3label() : Label
        {
            return this._1526332099day3label;
        }// end function

        public function get day4result() : Image
        {
            return this._991839797day4result;
        }// end function

        public function get day4() : Frame
        {
            return this._3076120day4;
        }// end function

        public function set day4(param1:Frame) : void
        {
            var _loc_2:* = this._3076120day4;
            if (_loc_2 !== param1)
            {
                this._3076120day4 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day4", _loc_2, param1));
            }
            return;
        }// end function

        public function set day7(param1:Frame) : void
        {
            var _loc_2:* = this._3076123day7;
            if (_loc_2 !== param1)
            {
                this._3076123day7 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day7", _loc_2, param1));
            }
            return;
        }// end function

        public function get daysLabels() : HBox
        {
            return this._22126794daysLabels;
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

        public function set day4result(param1:Image) : void
        {
            var _loc_2:* = this._991839797day4result;
            if (_loc_2 !== param1)
            {
                this._991839797day4result = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day4result", _loc_2, param1));
            }
            return;
        }// end function

        public function set daysLabels(param1:HBox) : void
        {
            var _loc_2:* = this._22126794daysLabels;
            if (_loc_2 !== param1)
            {
                this._22126794daysLabels = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "daysLabels", _loc_2, param1));
            }
            return;
        }// end function

        public function set day2result(param1:Image) : void
        {
            var _loc_2:* = this._783167565day2result;
            if (_loc_2 !== param1)
            {
                this._783167565day2result = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day2result", _loc_2, param1));
            }
            return;
        }// end function

        public function set day6result(param1:Image) : void
        {
            var _loc_2:* = this._1528120137day6result;
            if (_loc_2 !== param1)
            {
                this._1528120137day6result = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day6result", _loc_2, param1));
            }
            return;
        }// end function

        public function get day1result() : Image
        {
            return this._1670671246day1result;
        }// end function

        public function get day5result() : Image
        {
            return this._1879343478day5result;
        }// end function

        public function __day3_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get content() : Canvas
        {
            return this._951530617content;
        }// end function

        public function set day3label(param1:Label) : void
        {
            var _loc_2:* = this._1526332099day3label;
            if (_loc_2 !== param1)
            {
                this._1526332099day3label = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day3label", _loc_2, param1));
            }
            return;
        }// end function

        public function __day7_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
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

        public function set day7label(param1:Label) : void
        {
            var _loc_2:* = this._1411815495day7label;
            if (_loc_2 !== param1)
            {
                this._1411815495day7label = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day7label", _loc_2, param1));
            }
            return;
        }// end function

        private function _DailyLoginPanel_bindingsSetup() : Array
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
                return gAssetManager.GetBitmap("DailyLoginHeaderOrnamental");
            }// end function
            , function (param1:Object) : void
            {
                _DailyLoginPanel_Image1.source = param1;
                return;
            }// end function
            , "_DailyLoginPanel_Image1.source");
            result[2] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:String = null;
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
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Rewards");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_DailyLoginPanel_Label2.text");
            result[4] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "DailyLoginDay", ["1"]);
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                day1label.text = param1;
                return;
            }// end function
            , "day1label.text");
            result[5] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DailyLoginDay", ["2"]);
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = param1;
                return;
            }// end function
            , "day2label.text");
            result[6] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "DailyLoginDay", ["3"]);
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "day3label.text");
            result[7] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "DailyLoginDay", ["4"]);
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "day4label.text");
            result[8] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "DailyLoginDay", ["5"]);
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                day5label.text = param1;
                return;
            }// end function
            , "day5label.text");
            result[9] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "DailyLoginDay", ["6"]);
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "day6label.text");
            result[10] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DailyLoginDay", ["7"]);
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "day7label.text");
            result[11] = binding;
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
            result[12] = binding;
            return result;
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

        public function get day5label() : Label
        {
            return this._1469073797day5label;
        }// end function

        override public function initialize() : void
        {
            var target:DailyLoginPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._DailyLoginPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_DailyLoginPanelWatcherSetupUtil");
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

        public function get day2label() : Label
        {
            return this._1554961250day2label;
        }// end function

        public function get day6result() : Image
        {
            return this._1528120137day6result;
        }// end function

        public function get day7label() : Label
        {
            return this._1411815495day7label;
        }// end function

        public function get day2result() : Image
        {
            return this._783167565day2result;
        }// end function

        public function __day4_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
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

        public function get daysRemaining() : Text
        {
            return this._572567713daysRemaining;
        }// end function

        public function set rewardsList(param1:HBox) : void
        {
            var _loc_2:* = this._915835362rewardsList;
            if (_loc_2 !== param1)
            {
                this._915835362rewardsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "rewardsList", _loc_2, param1));
            }
            return;
        }// end function

        public function set daysRemaining(param1:Text) : void
        {
            var _loc_2:* = this._572567713daysRemaining;
            if (_loc_2 !== param1)
            {
                this._572567713daysRemaining = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "daysRemaining", _loc_2, param1));
            }
            return;
        }// end function

        public function set day4label(param1:Label) : void
        {
            var _loc_2:* = this._1497702948day4label;
            if (_loc_2 !== param1)
            {
                this._1497702948day4label = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day4label", _loc_2, param1));
            }
            return;
        }// end function

        public function get fadeIn() : Fade
        {
            return this._1282133823fadeIn;
        }// end function

        public function get headline() : Label
        {
            return this._1115058732headline;
        }// end function

        public function get day4label() : Label
        {
            return this._1497702948day4label;
        }// end function

        public function __fadeOut_effectEnd(event:EffectEvent) : void
        {
            globalFlash.gui.ShowQuestWindowDelayed();
            return;
        }// end function

        private function _DailyLoginPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.fadeIn;
            _loc_1 = this.fadeOut;
            _loc_1 = gAssetManager.GetBitmap("DailyLoginHeaderOrnamental");
            _loc_1 = label;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Rewards");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DailyLoginDay", ["1"]);
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DailyLoginDay", ["2"]);
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DailyLoginDay", ["3"]);
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DailyLoginDay", ["4"]);
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DailyLoginDay", ["5"]);
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DailyLoginDay", ["6"]);
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "DailyLoginDay", ["7"]);
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
            return;
        }// end function

        public function set day1result(param1:Image) : void
        {
            var _loc_2:* = this._1670671246day1result;
            if (_loc_2 !== param1)
            {
                this._1670671246day1result = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day1result", _loc_2, param1));
            }
            return;
        }// end function

        public function set day3result(param1:Image) : void
        {
            var _loc_2:* = this._104336116day3result;
            if (_loc_2 !== param1)
            {
                this._104336116day3result = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day3result", _loc_2, param1));
            }
            return;
        }// end function

        public function set day7result(param1:Image) : void
        {
            var _loc_2:* = this._640616456day7result;
            if (_loc_2 !== param1)
            {
                this._640616456day7result = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day7result", _loc_2, param1));
            }
            return;
        }// end function

        public function get rewardsList() : HBox
        {
            return this._915835362rewardsList;
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

        public function __day1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function _DailyLoginPanel_Fade2_i() : Fade
        {
            var _loc_1:* = new Fade();
            this.fadeOut = _loc_1;
            _loc_1.alphaFrom = 1;
            _loc_1.alphaTo = 0;
            _loc_1.duration = 150;
            _loc_1.addEventListener("effectEnd", this.__fadeOut_effectEnd);
            return _loc_1;
        }// end function

        public function get day7result() : Image
        {
            return this._640616456day7result;
        }// end function

        public function __day5_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get day3result() : Image
        {
            return this._104336116day3result;
        }// end function

        public function set day1label(param1:Label) : void
        {
            var _loc_2:* = this._1583590401day1label;
            if (_loc_2 !== param1)
            {
                this._1583590401day1label = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "day1label", _loc_2, param1));
            }
            return;
        }// end function

        public function get day1label() : Label
        {
            return this._1583590401day1label;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
