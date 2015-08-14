package GUI.Components.ToolTips
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import ServerState.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class BuildingsListTip extends Canvas implements IDataToolTip, IBindingClient
    {
        private var _data:Object;
        var _watchers:Array;
        private var _252650492costsList:HBox;
        private var _956114622costBox:HBox;
        private var _757514318costsLabel:Label;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        private var _1724546052description:CustomText;
        private var _1706723208inputList:VBox;
        private var _1335041744productionArrow:Image;
        private var _1274191590outputIcon:Image;
        private var _91291148_text:String;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        public var _BuildingsListTip_Label1:Label;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function BuildingsListTip()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {childDescriptors:[new UIComponentDescriptor({type:Label, id:"_BuildingsListTip_Label1", stylesFactory:function () : void
                {
                    this.top = "9";
                    this.left = "13";
                    this.right = "60";
                    this.fontWeight = "bold";
                    this.color = 16777215;
                    this.textAlign = "center";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:HBox, id:"costBox", stylesFactory:function () : void
                {
                    this.verticalAlign = "middle";
                    this.left = "10";
                    this.right = "50";
                    this.bottom = "8";
                    this.paddingLeft = 5;
                    this.paddingRight = 5;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {height:26, childDescriptors:[new UIComponentDescriptor({type:Label, id:"costsLabel", stylesFactory:function () : void
                    {
                        this.fontWeight = "bold";
                        this.color = 16777215;
                        this.textAlign = "left";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:HBox, id:"costsList"})]};
                }// end function
                }), new UIComponentDescriptor({type:CustomText, id:"description", stylesFactory:function () : void
                {
                    this.left = "14";
                    this.right = "56";
                    this.top = "26";
                    this.bottom = "43";
                    this.color = 16777215;
                    return;
                }// end function
                }), new UIComponentDescriptor({type:VBox, stylesFactory:function () : void
                {
                    this.right = "8";
                    this.top = "10";
                    this.bottom = "10";
                    this.horizontalAlign = "center";
                    this.verticalAlign = "middle";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {childDescriptors:[new UIComponentDescriptor({type:VBox, id:"inputList"}), new UIComponentDescriptor({type:Image, id:"productionArrow"}), new UIComponentDescriptor({type:Image, id:"outputIcon", propertiesFactory:function () : Object
                    {
                        return {height:25};
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
            this.minHeight = 130;
            this.minWidth = 220;
            this.styleName = "buildingListToolTip";
            return;
        }// end function

        public function get description() : CustomText
        {
            return this._1724546052description;
        }// end function

        public function get costsList() : HBox
        {
            return this._252650492costsList;
        }// end function

        public function set toolTipData(param1:Object) : void
        {
            this._data = param1;
            return;
        }// end function

        public function set costsList(param1:HBox) : void
        {
            var _loc_2:* = this._252650492costsList;
            if (_loc_2 !== param1)
            {
                this._252650492costsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "costsList", _loc_2, param1));
            }
            return;
        }// end function

        private function get _text() : String
        {
            return this._91291148_text;
        }// end function

        public function get inputList() : VBox
        {
            return this._1706723208inputList;
        }// end function

        override public function initialize() : void
        {
            var target:BuildingsListTip;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._BuildingsListTip_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ToolTips_BuildingsListTipWatcherSetupUtil");
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

        public function get outputIcon() : Image
        {
            return this._1274191590outputIcon;
        }// end function

        public function set costsLabel(param1:Label) : void
        {
            var _loc_2:* = this._757514318costsLabel;
            if (_loc_2 !== param1)
            {
                this._757514318costsLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "costsLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function set productionArrow(param1:Image) : void
        {
            var _loc_2:* = this._1335041744productionArrow;
            if (_loc_2 !== param1)
            {
                this._1335041744productionArrow = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "productionArrow", _loc_2, param1));
            }
            return;
        }// end function

        private function set _text(param1:String) : void
        {
            var _loc_2:* = this._91291148_text;
            if (_loc_2 !== param1)
            {
                this._91291148_text = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "_text", _loc_2, param1));
            }
            return;
        }// end function

        public function set inputList(param1:VBox) : void
        {
            var _loc_2:* = this._1706723208inputList;
            if (_loc_2 !== param1)
            {
                this._1706723208inputList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "inputList", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingsListTip_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = _text;
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _BuildingsListTip_Label1.text = param1;
                return;
            }// end function
            , "_BuildingsListTip_Label1.text");
            result[0] = binding;
            binding = new Binding(this, function () : Object
            {
                return gAssetManager.GetBitmap("ProductionArrowDown");
            }// end function
            , function (param1:Object) : void
            {
                null.source = param1;
                return;
            }// end function
            , "productionArrow.source");
            result[1] = binding;
            return result;
        }// end function

        public function get text() : String
        {
            return this._text;
        }// end function

        private function _BuildingsListTip_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this._text;
            _loc_1 = gAssetManager.GetBitmap("ProductionArrowDown");
            return;
        }// end function

        public function get costBox() : HBox
        {
            return this._956114622costBox;
        }// end function

        public function get costsLabel() : Label
        {
            return this._757514318costsLabel;
        }// end function

        public function get productionArrow() : Image
        {
            return this._1335041744productionArrow;
        }// end function

        public function set outputIcon(param1:Image) : void
        {
            var _loc_2:* = this._1274191590outputIcon;
            if (_loc_2 !== param1)
            {
                this._1274191590outputIcon = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "outputIcon", _loc_2, param1));
            }
            return;
        }// end function

        public function set text(param1:String) : void
        {
            var _loc_2:dResource = null;
            var _loc_5:Image = null;
            var _loc_6:ResourceItemRenderer = null;
            this._text = cLocaManager.GetInstance().GetText(LOCA_GROUP.BUILDINGS, param1);
            var _loc_3:* = gEconomics.GetResourcesCreationDefinitionForBuilding(param1);
            if (_loc_3)
            {
                if (_loc_3.amountRemoved > 0)
                {
                    this.outputIcon.source = gAssetManager.GetResourceIcon(_loc_3.defaultSetting.resourceName_string);
                    if (_loc_3.externalResource_string == "")
                    {
                        for each (_loc_2 in _loc_3.necessaryResources_vector)
                        {
                            
                            _loc_5 = new Image();
                            _loc_5.source = gAssetManager.GetResourceIcon(_loc_2.name_string);
                            _loc_5.width = 26;
                            _loc_5.height = 25;
                            this.inputList.addChild(_loc_5);
                        }
                    }
                    else
                    {
                        _loc_5 = new Image();
                        _loc_5.source = gAssetManager.GetResourceIcon("Deposit" + _loc_3.externalResource_string);
                        _loc_5.width = 26;
                        _loc_5.height = 25;
                        this.inputList.addChild(_loc_5);
                    }
                }
                else
                {
                    this.outputIcon.source = gAssetManager.GetResourceIcon("Deposit" + _loc_3.externalResource_string);
                    if (param1.indexOf("Forester") > -1)
                    {
                        _loc_5 = new Image();
                        _loc_5.source = gAssetManager.GetResourceIcon("Seed");
                        _loc_5.width = 26;
                        _loc_5.height = 25;
                        this.inputList.addChild(_loc_5);
                    }
                }
                this.productionArrow.visible = true;
            }
            else
            {
                this.productionArrow.visible = false;
            }
            var _loc_4:int = 0;
            this.costsList.removeAllChildren();
            for each (_loc_2 in global.buildingGroup.GetCostListFromName_vector(param1))
            {
                
                _loc_6 = new ResourceItemRenderer();
                _loc_6.data = _loc_2;
                this.costsList.addChild(_loc_6);
                _loc_4++;
            }
            if (_loc_4 > 0)
            {
                this.costsLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Costs");
            }
            else
            {
                this.costsLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CostsFree");
                this.costBox.removeChild(this.costsList);
            }
            if (global.ui.mCurrentPlayer.mBuildQueue.IsFull())
            {
                this.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "FullBuildQueue");
                this.description.setStyle("color", 16711680);
            }
            else if (this._data.playerLevel > global.ui.mCurrentPlayer.GetPlayerLevel())
            {
                this.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LevelRequired", [this._data.playerLevel.toString()]);
                this.description.setStyle("color", 16711680);
            }
            else if (global.ui.mCurrentPlayer.IsMaximumPlacedBuildingCountReached(param1))
            {
                this.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "MaxBuildingCountReached");
                this.description.setStyle("color", 16711680);
            }
            else
            {
                this.description.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, param1);
                this.description.setStyle("color", 16777215);
            }
            return;
        }// end function

        public function set description(param1:CustomText) : void
        {
            var _loc_2:* = this._1724546052description;
            if (_loc_2 !== param1)
            {
                this._1724546052description = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "description", _loc_2, param1));
            }
            return;
        }// end function

        public function set costBox(param1:HBox) : void
        {
            var _loc_2:* = this._956114622costBox;
            if (_loc_2 !== param1)
            {
                this._956114622costBox = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "costBox", _loc_2, param1));
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
