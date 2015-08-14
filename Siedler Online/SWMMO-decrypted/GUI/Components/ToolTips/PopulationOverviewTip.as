package GUI.Components.ToolTips
{
    import BuffSystem.*;
    import Enums.*;
    import GO.*;
    import GUI.Loca.*;
    import ServerState.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class PopulationOverviewTip extends Canvas implements IBindingClient, IToolTip
    {
        public var _PopulationOverviewTip_FormItem3:FormItem;
        var _bindingsByDestination:Object;
        private var _text:String;
        var _bindings:Array;
        var _bindingsBeginWithWord:Object;
        var _watchers:Array;
        private var _1049693754assignedLabel:Label;
        private var _1767219207limitLabel:Label;
        public var _PopulationOverviewTip_FormItem1:FormItem;
        public var _PopulationOverviewTip_FormItem2:FormItem;
        public var _PopulationOverviewTip_FormItem4:FormItem;
        private var _122527168durationLabel:Label;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _451568664freeLabel:Label;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function PopulationOverviewTip()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:Form, stylesFactory:function () : void
                {
                    this.paddingTop = 5;
                    this.paddingLeft = 5;
                    this.paddingRight = 5;
                    this.paddingBottom = 5;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {childDescriptors:[new UIComponentDescriptor({type:FormItem, id:"_PopulationOverviewTip_FormItem1", stylesFactory:function () : void
                    {
                        null.labelStyleName = this;
                        this.horizontalAlign = "right";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {percentWidth:100, childDescriptors:[new UIComponentDescriptor({type:Label, id:"freeLabel", stylesFactory:function () : void
                        {
                            null.fontWeight = this;
                            this.color = 16777215;
                            this.textAlign = "right";
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:FormItem, id:"_PopulationOverviewTip_FormItem2", stylesFactory:function () : void
                    {
                        this.labelStyleName = "populationTipLabel";
                        this.horizontalAlign = "right";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {percentWidth:100, childDescriptors:[new UIComponentDescriptor({type:Label, id:"assignedLabel", stylesFactory:function () : void
                        {
                            this.fontWeight = "bold";
                            this.color = 16777215;
                            this.textAlign = "right";
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:FormItem, id:"_PopulationOverviewTip_FormItem3", stylesFactory:function () : void
                    {
                        this.labelStyleName = "populationTipLabel";
                        this.horizontalAlign = "right";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {percentWidth:100, childDescriptors:[new UIComponentDescriptor({type:Label, id:"limitLabel", stylesFactory:function () : void
                        {
                            null.fontWeight = this;
                            this.color = 16777215;
                            this.textAlign = "right";
                            return;
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:FormItem, id:"_PopulationOverviewTip_FormItem4", stylesFactory:function () : void
                    {
                        this.labelStyleName = "populationTipLabel";
                        this.horizontalAlign = "right";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {percentWidth:100, childDescriptors:[new UIComponentDescriptor({type:Label, id:"durationLabel", stylesFactory:function () : void
                        {
                            null.fontWeight = this;
                            this.color = 16777215;
                            this.textAlign = "right";
                            return;
                        }// end function
                        })]};
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
            this.mouseEnabled = false;
            this.mouseChildren = false;
            this.styleName = "toolTip";
            return;
        }// end function

        public function get durationLabel() : Label
        {
            return this._122527168durationLabel;
        }// end function

        private function _PopulationOverviewTip_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "FreePopulation");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _PopulationOverviewTip_FormItem1.label = param1;
                return;
            }// end function
            , "_PopulationOverviewTip_FormItem1.label");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "AssignedPopulation");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "_PopulationOverviewTip_FormItem2.label");
            result[1] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "PopulationLimit");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "_PopulationOverviewTip_FormItem3.label");
            result[2] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "NextSettler");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "_PopulationOverviewTip_FormItem4.label");
            result[3] = binding;
            return result;
        }// end function

        public function set durationLabel(param1:Label) : void
        {
            var _loc_2:* = this._122527168durationLabel;
            if (_loc_2 !== param1)
            {
                this._122527168durationLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "durationLabel", _loc_2, param1));
            }
            return;
        }// end function

        private function _PopulationOverviewTip_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FreePopulation");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "AssignedPopulation");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "PopulationLimit");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "NextSettler");
            return;
        }// end function

        public function get assignedLabel() : Label
        {
            return this._1049693754assignedLabel;
        }// end function

        override public function initialize() : void
        {
            var target:PopulationOverviewTip;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._PopulationOverviewTip_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ToolTips_PopulationOverviewTipWatcherSetupUtil");
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

        public function set text(param1:String) : void
        {
            var _loc_4:cResourceCreation = null;
            var _loc_5:int = 0;
            var _loc_6:BuffAppliance = null;
            var _loc_7:Number = NaN;
            this._text = param1;
            var _loc_2:* = global.ui.mCurrentPlayerZone.GetResources(global.ui.mCurrentPlayer);
            this.freeLabel.text = _loc_2.GetNumberOfUnassignedPopulation().toString();
            this.assignedLabel.text = _loc_2.GetNumberOfAssignedPopulation().toString();
            this.limitLabel.text = _loc_2.GetPlayerResource("Population").maxLimit.toString();
            var _loc_3:* = global.ui.mCurrentPlayerZone.mStreetDataMap.GetMayorHouse();
            if (_loc_3 != null)
            {
                _loc_5 = 1;
                for each (_loc_6 in _loc_3.mBuffs_vector)
                {
                    
                    _loc_5 = _loc_5 * _loc_6.GetBuffDefinition().getRecruitingTime() / 100;
                }
            }
            for each (_loc_4 in global.ui.mComputeResourceCreation.mResourceCreation_vector)
            {
                
                if (_loc_4.GetResourceCreationDefinition().typeEnumResourceType == RESOURCE_TYPE.CREATED_ALWAYS && _loc_4.GetResourceCreationDefinition().defaultSetting.resourceName_string == defines.POPULATION_RESOURCE_NAME_string)
                {
                    break;
                }
            }
            if (_loc_2.IsMaxLimitOfPopulationReached())
            {
                this.durationLabel.text = "-";
            }
            else
            {
                _loc_7 = (_loc_4.GetResourceCreationDefinition().amountRemoved * 1000 - _loc_4.pathPos) / global.ui.mGlobalTimeScale / _loc_5;
                this.durationLabel.text = cLocaManager.GetInstance().FormatDuration(_loc_7);
            }
            return;
        }// end function

        public function set assignedLabel(param1:Label) : void
        {
            var _loc_2:* = this._1049693754assignedLabel;
            if (_loc_2 !== param1)
            {
                this._1049693754assignedLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "assignedLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function set limitLabel(param1:Label) : void
        {
            var _loc_2:* = this._1767219207limitLabel;
            if (_loc_2 !== param1)
            {
                this._1767219207limitLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "limitLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function get text() : String
        {
            return this._text;
        }// end function

        public function get freeLabel() : Label
        {
            return this._451568664freeLabel;
        }// end function

        public function get limitLabel() : Label
        {
            return this._1767219207limitLabel;
        }// end function

        public function set freeLabel(param1:Label) : void
        {
            var _loc_2:* = this._451568664freeLabel;
            if (_loc_2 !== param1)
            {
                this._451568664freeLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "freeLabel", _loc_2, param1));
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
