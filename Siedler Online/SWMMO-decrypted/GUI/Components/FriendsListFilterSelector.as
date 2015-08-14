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
    import mx.events.*;

    public class FriendsListFilterSelector extends Canvas implements IBindingClient
    {
        public var _FriendsListFilterSelector_Canvas2:Canvas;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        var _watchers:Array;
        private var _11548545buttonBar:ToggleButtonBar;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        public static const ALL:int = 0;
        public static const GUILD:int = 3;
        private static var _watcherSetupUtil:IWatcherSetupUtil;
        public static const FRIENDS:int = 1;
        public static const ZONES:int = 2;

        public function FriendsListFilterSelector()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"_FriendsListFilterSelector_Canvas2", stylesFactory:function () : void
                {
                    null.top = this;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {width:71, height:88, childDescriptors:[new UIComponentDescriptor({type:ToggleButtonBar, id:"buttonBar", events:{creationComplete:"__buttonBar_creationComplete", updateComplete:"__buttonBar_updateComplete"}, stylesFactory:function () : void
                    {
                        this.left = "2";
                        this.top = "2";
                        this.color = 3284992;
                        this.themeColor = 3284992;
                        this.buttonStyleName = "filterFriendsList";
                        this.buttonHeight = 20;
                        this.buttonWidth = 66;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, height:80, direction:"vertical"};
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
            this.addEventListener("creationComplete", this.___FriendsListFilterSelector_Canvas1_creationComplete);
            return;
        }// end function

        public function __buttonBar_updateComplete(event:FlexEvent) : void
        {
            this.assignToolTips(event);
            return;
        }// end function

        public function get buttonBar() : ToggleButtonBar
        {
            return this._11548545buttonBar;
        }// end function

        public function set buttonBar(param1:ToggleButtonBar) : void
        {
            var _loc_2:* = this._11548545buttonBar;
            if (_loc_2 !== param1)
            {
                this._11548545buttonBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "buttonBar", _loc_2, param1));
            }
            return;
        }// end function

        private function createToolTip(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function _FriendsListFilterSelector_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetClass("FriendFilterBackground");
            return;
        }// end function

        private function init() : void
        {
            var _loc_1:Array = [{selection:ALL, label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "All")}, {selection:FRIENDS, label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Friends")}, {selection:GUILD, label:cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Guild")}, {selection:null, label:"", enabled:false}];
            this.buttonBar.dataProvider = _loc_1;
            this.buttonBar.selectedIndex = 0;
            return;
        }// end function

        public function ___FriendsListFilterSelector_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.init();
            return;
        }// end function

        override public function initialize() : void
        {
            var target:FriendsListFilterSelector;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._FriendsListFilterSelector_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_FriendsListFilterSelectorWatcherSetupUtil");
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

        private function _FriendsListFilterSelector_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return gAssetManager.GetClass("FriendFilterBackground");
            }// end function
            , function (param1:Object) : void
            {
                _FriendsListFilterSelector_Canvas2.setStyle("backgroundImage", param1);
                return;
            }// end function
            , "_FriendsListFilterSelector_Canvas2.backgroundImage");
            result[0] = binding;
            return result;
        }// end function

        public function __buttonBar_creationComplete(event:FlexEvent) : void
        {
            this.assignToolTips(event);
            return;
        }// end function

        private function assignToolTips(event:FlexEvent) : void
        {
            var _loc_2:Button = null;
            if (this.buttonBar.getChildren() == null)
            {
                return;
            }
            for each (_loc_2 in this.buttonBar.getChildren())
            {
                
                _loc_2.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, this.createToolTip);
                if (_loc_2.label == "")
                {
                    _loc_2.enabled = false;
                }
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
