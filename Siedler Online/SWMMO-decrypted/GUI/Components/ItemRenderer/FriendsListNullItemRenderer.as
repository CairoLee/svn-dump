package GUI.Components.ItemRenderer
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.core.*;
    import mx.events.*;

    public class FriendsListNullItemRenderer extends Canvas implements IBindingClient
    {
        private var _1148585618addText:CustomText;
        var _bindingsBeginWithWord:Object;
        var _bindingsByDestination:Object;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        var _watchers:Array;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function FriendsListNullItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {width:71, height:87, childDescriptors:[new UIComponentDescriptor({type:CustomText, id:"addText", stylesFactory:function () : void
                {
                    this.verticalCenter = "0";
                    this.horizontalCenter = "0";
                    this.left = "5";
                    this.right = "5";
                    this.color = 3284992;
                    this.fontWeight = "bold";
                    this.textAlign = "center";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {selectable:false};
                }// end function
                })]};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 71;
            this.height = 87;
            this.addEventListener("rollOver", this.___FriendsListNullItemRenderer_Canvas1_rollOver);
            this.addEventListener("rollOut", this.___FriendsListNullItemRenderer_Canvas1_rollOut);
            this.addEventListener("click", this.___FriendsListNullItemRenderer_Canvas1_click);
            return;
        }// end function

        private function _FriendsListNullItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return null.GetClass("AddFriendBackground");
            }// end function
            , function (param1:Object) : void
            {
                this.setStyle("backgroundImage", param1);
                return;
            }// end function
            , "this.backgroundImage");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "AddFriends");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                addText.text = param1;
                return;
            }// end function
            , "addText.text");
            result[1] = binding;
            return result;
        }// end function

        public function ___FriendsListNullItemRenderer_Canvas1_rollOver(event:MouseEvent) : void
        {
            this.setStyle("backgroundImage", gAssetManager.GetClass("AddFriendBackgroundHighlight"));
            return;
        }// end function

        private function _FriendsListNullItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetClass("AddFriendBackground");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "AddFriends");
            return;
        }// end function

        override public function initialize() : void
        {
            var target:FriendsListNullItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._FriendsListNullItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_FriendsListNullItemRendererWatcherSetupUtil");
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

        public function ShowContextMenu(event:MouseEvent) : void
        {
            globalFlash.gui.ShowFriendListMenu(event, null);
            return;
        }// end function

        public function ___FriendsListNullItemRenderer_Canvas1_click(event:MouseEvent) : void
        {
            this.ShowContextMenu(event);
            return;
        }// end function

        public function get addText() : CustomText
        {
            return this._1148585618addText;
        }// end function

        public function set addText(param1:CustomText) : void
        {
            var _loc_2:* = this._1148585618addText;
            if (_loc_2 !== param1)
            {
                this._1148585618addText = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "addText", _loc_2, param1));
            }
            return;
        }// end function

        public function ___FriendsListNullItemRenderer_Canvas1_rollOut(event:MouseEvent) : void
        {
            this.setStyle("backgroundImage", gAssetManager.GetClass("AddFriendBackground"));
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
