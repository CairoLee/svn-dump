package GUI.Components
{
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class InfoBar extends HBox implements IBindingClient
    {
        private var _596388007resourceLabelBuildings:Label;
        private var _958789483resourceIcon2:Image;
        private var _1983070744resource6:HBox;
        private var _1424606067resourceLabelPopulation:Label;
        private var _258650770resourceLabel4:Label;
        private var _1983070745resource5:HBox;
        private var _1956358520btnAddCash:Button;
        private var _2023558323population:HBox;
        var _bindingsByDestination:Object;
        private var _258650768resourceLabel6:Label;
        private var _1983070746resource4:HBox;
        private var _958789485resourceIcon4:Image;
        private var _1727280797resourceIconHardCurrency:Image;
        private var _258650771resourceLabel3:Label;
        private var _1983070747resource3:HBox;
        private var _958789482resourceIcon1:Image;
        private var _1920340568resourceIconBuildings:Image;
        private var _344172350resourceLabelHardCurrency:Label;
        private var _1983070748resource2:HBox;
        private var _1684601372hardCurrency:HBox;
        private var _258650769resourceLabel5:Label;
        var _watchers:Array;
        private var _958789487resourceIcon6:Image;
        private var _258650772resourceLabel2:Label;
        private var _1983070749resource1:HBox;
        private var _958789484resourceIcon3:Image;
        var _bindingsBeginWithWord:Object;
        private var _1400355777buildings:HBox;
        private var _258650773resourceLabel1:Label;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _958789486resourceIcon5:Image;
        private var _2133780564resourceIconPopulation:Image;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function InfoBar()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:HBox, propertiesFactory:function () : Object
            {
                return {childDescriptors:[new UIComponentDescriptor({type:HBox, propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {height:42, styleName:"infoBarLeft", childDescriptors:[new UIComponentDescriptor({type:HBox, id:"population", events:{toolTipCreate:"__population_toolTipCreate"}, stylesFactory:function () : void
                    {
                        this.verticalAlign = "middle";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {toolTip:"Population", childDescriptors:[new UIComponentDescriptor({type:Image, id:"resourceIconPopulation"}), new UIComponentDescriptor({type:Label, id:"resourceLabelPopulation", stylesFactory:function () : void
                        {
                            null.color = this;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:HBox, id:"buildings", events:{toolTipCreate:"__buildings_toolTipCreate"}, stylesFactory:function () : void
                    {
                        this.verticalAlign = "middle";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {childDescriptors:[new UIComponentDescriptor({type:Image, id:"resourceIconBuildings"}), new UIComponentDescriptor({type:Label, id:"resourceLabelBuildings", stylesFactory:function () : void
                        {
                            this.color = 16777215;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        })]};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:HBox, propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {height:42, styleName:"infoBarMiddle", childDescriptors:[new UIComponentDescriptor({type:HBox, id:"resource1", events:{toolTipCreate:"__resource1_toolTipCreate"}, stylesFactory:function () : void
                    {
                        this.horizontalGap = 2;
                        this.verticalAlign = "middle";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {childDescriptors:[new UIComponentDescriptor({type:Image, id:"resourceIcon1"}), new UIComponentDescriptor({type:Label, id:"resourceLabel1", stylesFactory:function () : void
                        {
                            null.color = this;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:null};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:HBox, id:"resource2", events:{toolTipCreate:"__resource2_toolTipCreate"}, stylesFactory:function () : void
                    {
                        this.horizontalGap = 2;
                        this.verticalAlign = "middle";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {childDescriptors:[new UIComponentDescriptor({type:Image, id:"resourceIcon2"}), new UIComponentDescriptor({type:Label, id:"resourceLabel2", stylesFactory:function () : void
                        {
                            this.color = 16777215;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:null};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:HBox, id:"resource3", events:{toolTipCreate:"__resource3_toolTipCreate"}, stylesFactory:function () : void
                    {
                        null.horizontalGap = this;
                        this.verticalAlign = "middle";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {childDescriptors:[new UIComponentDescriptor({type:Image, id:"resourceIcon3"}), new UIComponentDescriptor({type:Label, id:"resourceLabel3", stylesFactory:function () : void
                        {
                            this.color = 16777215;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:"0"};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:HBox, id:"resource4", events:{toolTipCreate:"__resource4_toolTipCreate"}, stylesFactory:function () : void
                    {
                        this.horizontalGap = 2;
                        this.verticalAlign = "middle";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {childDescriptors:[new UIComponentDescriptor({type:Image, id:"resourceIcon4"}), new UIComponentDescriptor({type:Label, id:"resourceLabel4", stylesFactory:function () : void
                        {
                            this.color = 16777215;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:"0"};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:HBox, id:"resource5", events:{toolTipCreate:"__resource5_toolTipCreate"}, stylesFactory:function () : void
                    {
                        null.horizontalGap = this;
                        this.verticalAlign = "middle";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {childDescriptors:[new UIComponentDescriptor({type:Image, id:"resourceIcon5"}), new UIComponentDescriptor({type:Label, id:"resourceLabel5", stylesFactory:function () : void
                        {
                            this.color = 16777215;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:null};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:HBox, id:"resource6", events:{toolTipCreate:"__resource6_toolTipCreate"}, stylesFactory:function () : void
                    {
                        this.horizontalGap = 2;
                        this.verticalAlign = "middle";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {childDescriptors:[new UIComponentDescriptor({type:Image, id:"resourceIcon6"}), new UIComponentDescriptor({type:Label, id:"resourceLabel6", stylesFactory:function () : void
                        {
                            null.color = this;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:"0"};
                        }// end function
                        })]};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:HBox, stylesFactory:function () : void
                {
                    this.paddingTop = 6;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {height:42, styleName:"infoBarRight", childDescriptors:[new UIComponentDescriptor({type:HBox, id:"hardCurrency", events:{toolTipCreate:"__hardCurrency_toolTipCreate"}, stylesFactory:function () : void
                    {
                        this.paddingTop = 2;
                        this.verticalAlign = "middle";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {childDescriptors:[new UIComponentDescriptor({type:Image, id:"resourceIconHardCurrency"}), new UIComponentDescriptor({type:Label, id:"resourceLabelHardCurrency", stylesFactory:function () : void
                        {
                            this.color = 16777215;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:Button, id:"btnAddCash", propertiesFactory:function () : Object
                    {
                        return {null:56, height:31};
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
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                this.horizontalGap = 0;
                return;
            }// end function
            ;
            return;
        }// end function

        public function set resourceLabel5(param1:Label) : void
        {
            var _loc_2:* = this._258650769resourceLabel5;
            if (_loc_2 !== param1)
            {
                this._258650769resourceLabel5 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceLabel5", _loc_2, param1));
            }
            return;
        }// end function

        public function __resource3_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function _InfoBar_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetClass("ButtonIconHardCurrency");
            _loc_1 = gAssetManager.GetClass("ButtonAddCashUp");
            _loc_1 = gAssetManager.GetClass("ButtonAddCashOver");
            _loc_1 = gAssetManager.GetClass("ButtonAddCashOver");
            _loc_1 = gAssetManager.GetClass("ButtonAddCashDisabled");
            return;
        }// end function

        public function get hardCurrency() : HBox
        {
            return this._1684601372hardCurrency;
        }// end function

        public function __population_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.POPULATION_OVERVIEW_string, event);
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

        public function get buildings() : HBox
        {
            return this._1400355777buildings;
        }// end function

        private function _InfoBar_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconHardCurrency");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("icon", param1);
                return;
            }// end function
            , "btnAddCash.icon");
            result[0] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnAddCash.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnAddCash.upSkin");
            result[1] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonAddCashOver");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnAddCash.downSkin");
            result[2] = binding;
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
            result[3] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonAddCashDisabled");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnAddCash.disabledSkin");
            result[4] = binding;
            return result;
        }// end function

        public function __resource4_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get resourceLabelBuildings() : Label
        {
            return this._596388007resourceLabelBuildings;
        }// end function

        public function get resourceIconPopulation() : Image
        {
            return this._2133780564resourceIconPopulation;
        }// end function

        public function get resourceIconBuildings() : Image
        {
            return this._1920340568resourceIconBuildings;
        }// end function

        public function get population() : HBox
        {
            return this._2023558323population;
        }// end function

        public function get resourceIcon1() : Image
        {
            return this._958789482resourceIcon1;
        }// end function

        public function get resourceIcon2() : Image
        {
            return this._958789483resourceIcon2;
        }// end function

        public function get resourceIcon4() : Image
        {
            return this._958789485resourceIcon4;
        }// end function

        public function get resourceIcon6() : Image
        {
            return this._958789487resourceIcon6;
        }// end function

        public function get resourceLabel6() : Label
        {
            return this._258650768resourceLabel6;
        }// end function

        public function get resourceIcon3() : Image
        {
            return this._958789484resourceIcon3;
        }// end function

        public function get resourceLabel3() : Label
        {
            return this._258650771resourceLabel3;
        }// end function

        public function get resourceIcon5() : Image
        {
            return this._958789486resourceIcon5;
        }// end function

        public function get resourceLabel5() : Label
        {
            return this._258650769resourceLabel5;
        }// end function

        public function get btnAddCash() : Button
        {
            return this._1956358520btnAddCash;
        }// end function

        public function get resourceIconHardCurrency() : Image
        {
            return this._1727280797resourceIconHardCurrency;
        }// end function

        public function get resourceLabel4() : Label
        {
            return this._258650770resourceLabel4;
        }// end function

        public function set buildings(param1:HBox) : void
        {
            var _loc_2:* = this._1400355777buildings;
            if (_loc_2 !== param1)
            {
                this._1400355777buildings = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buildings", _loc_2, param1));
            }
            return;
        }// end function

        public function get resourceLabelPopulation() : Label
        {
            return this._1424606067resourceLabelPopulation;
        }// end function

        public function __resource1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get resourceLabel2() : Label
        {
            return this._258650772resourceLabel2;
        }// end function

        public function __resource5_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get resourceLabel1() : Label
        {
            return this._258650773resourceLabel1;
        }// end function

        public function set population(param1:HBox) : void
        {
            var _loc_2:* = this._2023558323population;
            if (_loc_2 !== param1)
            {
                this._2023558323population = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "population", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:InfoBar;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._InfoBar_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_InfoBarWatcherSetupUtil");
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

        public function set resourceIconPopulation(param1:Image) : void
        {
            var _loc_2:* = this._2133780564resourceIconPopulation;
            if (_loc_2 !== param1)
            {
                this._2133780564resourceIconPopulation = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceIconPopulation", _loc_2, param1));
            }
            return;
        }// end function

        public function set resourceLabelBuildings(param1:Label) : void
        {
            var _loc_2:* = this._596388007resourceLabelBuildings;
            if (_loc_2 !== param1)
            {
                this._596388007resourceLabelBuildings = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceLabelBuildings", _loc_2, param1));
            }
            return;
        }// end function

        public function __hardCurrency_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set resourceIconBuildings(param1:Image) : void
        {
            var _loc_2:* = this._1920340568resourceIconBuildings;
            if (_loc_2 !== param1)
            {
                this._1920340568resourceIconBuildings = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceIconBuildings", _loc_2, param1));
            }
            return;
        }// end function

        public function get resourceLabelHardCurrency() : Label
        {
            return this._344172350resourceLabelHardCurrency;
        }// end function

        public function __resource2_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function __resource6_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set resource3(param1:HBox) : void
        {
            var _loc_2:* = this._1983070747resource3;
            if (_loc_2 !== param1)
            {
                this._1983070747resource3 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resource3", _loc_2, param1));
            }
            return;
        }// end function

        public function set resource5(param1:HBox) : void
        {
            var _loc_2:* = this._1983070745resource5;
            if (_loc_2 !== param1)
            {
                this._1983070745resource5 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resource5", _loc_2, param1));
            }
            return;
        }// end function

        public function set resource2(param1:HBox) : void
        {
            var _loc_2:* = this._1983070748resource2;
            if (_loc_2 !== param1)
            {
                this._1983070748resource2 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resource2", _loc_2, param1));
            }
            return;
        }// end function

        public function set resource6(param1:HBox) : void
        {
            var _loc_2:* = this._1983070744resource6;
            if (_loc_2 !== param1)
            {
                this._1983070744resource6 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resource6", _loc_2, param1));
            }
            return;
        }// end function

        public function set resource4(param1:HBox) : void
        {
            var _loc_2:* = this._1983070746resource4;
            if (_loc_2 !== param1)
            {
                this._1983070746resource4 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resource4", _loc_2, param1));
            }
            return;
        }// end function

        public function set resourceIcon1(param1:Image) : void
        {
            var _loc_2:* = this._958789482resourceIcon1;
            if (_loc_2 !== param1)
            {
                this._958789482resourceIcon1 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceIcon1", _loc_2, param1));
            }
            return;
        }// end function

        public function set resource1(param1:HBox) : void
        {
            var _loc_2:* = this._1983070749resource1;
            if (_loc_2 !== param1)
            {
                this._1983070749resource1 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resource1", _loc_2, param1));
            }
            return;
        }// end function

        public function set resourceIcon2(param1:Image) : void
        {
            var _loc_2:* = this._958789483resourceIcon2;
            if (_loc_2 !== param1)
            {
                this._958789483resourceIcon2 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceIcon2", _loc_2, param1));
            }
            return;
        }// end function

        public function set resourceIcon3(param1:Image) : void
        {
            var _loc_2:* = this._958789484resourceIcon3;
            if (_loc_2 !== param1)
            {
                this._958789484resourceIcon3 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceIcon3", _loc_2, param1));
            }
            return;
        }// end function

        public function set resourceIcon5(param1:Image) : void
        {
            var _loc_2:* = this._958789486resourceIcon5;
            if (_loc_2 !== param1)
            {
                this._958789486resourceIcon5 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceIcon5", _loc_2, param1));
            }
            return;
        }// end function

        public function set resourceLabel1(param1:Label) : void
        {
            var _loc_2:* = this._258650773resourceLabel1;
            if (_loc_2 !== param1)
            {
                this._258650773resourceLabel1 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceLabel1", _loc_2, param1));
            }
            return;
        }// end function

        public function set resourceIcon6(param1:Image) : void
        {
            var _loc_2:* = this._958789487resourceIcon6;
            if (_loc_2 !== param1)
            {
                this._958789487resourceIcon6 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceIcon6", _loc_2, param1));
            }
            return;
        }// end function

        public function __buildings_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.MULTILINE_string, event);
            return;
        }// end function

        public function set resourceLabel6(param1:Label) : void
        {
            var _loc_2:* = this._258650768resourceLabel6;
            if (_loc_2 !== param1)
            {
                this._258650768resourceLabel6 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceLabel6", _loc_2, param1));
            }
            return;
        }// end function

        public function set resourceIcon4(param1:Image) : void
        {
            var _loc_2:* = this._958789485resourceIcon4;
            if (_loc_2 !== param1)
            {
                this._958789485resourceIcon4 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceIcon4", _loc_2, param1));
            }
            return;
        }// end function

        public function get resource1() : HBox
        {
            return this._1983070749resource1;
        }// end function

        public function get resource3() : HBox
        {
            return this._1983070747resource3;
        }// end function

        public function get resource4() : HBox
        {
            return this._1983070746resource4;
        }// end function

        public function get resource5() : HBox
        {
            return this._1983070745resource5;
        }// end function

        public function get resource6() : HBox
        {
            return this._1983070744resource6;
        }// end function

        public function set resourceLabel3(param1:Label) : void
        {
            var _loc_2:* = this._258650771resourceLabel3;
            if (_loc_2 !== param1)
            {
                this._258650771resourceLabel3 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceLabel3", _loc_2, param1));
            }
            return;
        }// end function

        public function get resource2() : HBox
        {
            return this._1983070748resource2;
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

        public function set resourceLabel4(param1:Label) : void
        {
            var _loc_2:* = this._258650770resourceLabel4;
            if (_loc_2 !== param1)
            {
                this._258650770resourceLabel4 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceLabel4", _loc_2, param1));
            }
            return;
        }// end function

        public function set resourceLabel2(param1:Label) : void
        {
            var _loc_2:* = this._258650772resourceLabel2;
            if (_loc_2 !== param1)
            {
                this._258650772resourceLabel2 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceLabel2", _loc_2, param1));
            }
            return;
        }// end function

        public function set resourceLabelPopulation(param1:Label) : void
        {
            var _loc_2:* = this._1424606067resourceLabelPopulation;
            if (_loc_2 !== param1)
            {
                this._1424606067resourceLabelPopulation = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "resourceLabelPopulation", _loc_2, param1));
            }
            return;
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

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
