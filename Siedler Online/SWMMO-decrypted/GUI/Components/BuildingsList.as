package GUI.Components
{
    import GUI.Components.ItemRenderer.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.collections.*;
    import mx.core.*;
    import mx.events.*;

    public class BuildingsList extends BasicPanel implements IBindingClient
    {
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        private var _339742651dataProvider:ArrayCollection;
        var _watchers:Array;
        private var _2106232724tileList:CustomTileList;
        var _bindings:Array;
        private var basicHeight:int;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var basicWidth:int;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function BuildingsList()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:BasicPanel, propertiesFactory:function () : Object
            {
                return {null:null, height:218};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 212;
            this.height = 218;
            this.subComponents = [this._BuildingsList_CustomTileList1_i()];
            this.addEventListener("creationComplete", this.___BuildingsList_BasicPanel1_creationComplete);
            this.addEventListener("show", this.___BuildingsList_BasicPanel1_show);
            return;
        }// end function

        public function ___BuildingsList_BasicPanel1_show(event:FlexEvent) : void
        {
            this.Resize();
            return;
        }// end function

        public function ___BuildingsList_BasicPanel1_creationComplete(event:FlexEvent) : void
        {
            this.Init();
            return;
        }// end function

        public function set dataProvider(param1:ArrayCollection) : void
        {
            var _loc_2:* = this._339742651dataProvider;
            if (_loc_2 !== param1)
            {
                this._339742651dataProvider = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "dataProvider", _loc_2, param1));
            }
            return;
        }// end function

        public function get tileList() : CustomTileList
        {
            return this._2106232724tileList;
        }// end function

        override public function initialize() : void
        {
            var target:BuildingsList;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._BuildingsList_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_BuildingsListWatcherSetupUtil");
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

        public function get dataProvider() : ArrayCollection
        {
            return this._339742651dataProvider;
        }// end function

        private function Resize() : void
        {
            var _loc_1:int = 0;
            if ((this.tileList.dataProvider as ArrayCollection).length > 6)
            {
                _loc_1 = Math.floor((this.tileList.dataProvider as ArrayCollection).length / 3);
                if ((this.tileList.dataProvider as ArrayCollection).length % 3 > 0)
                {
                    _loc_1++;
                }
                this.height = this.basicHeight + (_loc_1 - 3) * this.tileList.rowHeight;
            }
            return;
        }// end function

        private function _BuildingsList_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.dataProvider;
            return;
        }// end function

        private function _BuildingsList_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = BuildingsListItemRenderer;
            return _loc_1;
        }// end function

        public function set tileList(param1:CustomTileList) : void
        {
            var _loc_2:* = this._2106232724tileList;
            if (_loc_2 !== param1)
            {
                this._2106232724tileList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "tileList", _loc_2, param1));
            }
            return;
        }// end function

        private function _BuildingsList_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return dataProvider;
            }// end function
            , function (param1:Object) : void
            {
                null.dataProvider = null;
                return;
            }// end function
            , "tileList.dataProvider");
            result[0] = binding;
            return result;
        }// end function

        private function Init() : void
        {
            this.basicWidth = this.width;
            this.basicHeight = this.height;
            return;
        }// end function

        private function _BuildingsList_CustomTileList1_i() : CustomTileList
        {
            var _loc_1:* = new CustomTileList();
            this.tileList = _loc_1;
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.columnWidth = 65;
            _loc_1.rowHeight = 58;
            _loc_1.styleName = "buildingsList";
            _loc_1.itemRenderer = this._BuildingsList_ClassFactory1_c();
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "0");
            _loc_1.setStyle("top", "2");
            _loc_1.setStyle("bottom", "0");
            _loc_1.id = "tileList";
            BindingManager.executeBindings(this, "tileList", this.tileList);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
