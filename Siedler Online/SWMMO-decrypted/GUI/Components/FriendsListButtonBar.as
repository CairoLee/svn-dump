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

    public class FriendsListButtonBar extends Canvas implements IBindingClient
    {
        private var _1955813973btnReturnHome:Button;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        var _watchers:Array;
        private var _embed_mxml_____data_src_gfx_embedded_friendslist_neighbours_button_invite_friends_png_879654284:Class;
        private var _1033847901btnAddFriend:Button;
        public var _FriendsListButtonBar_Canvas2:Canvas;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _301950085btnInvite:Button;
        private var _embed_mxml_____data_src_gfx_embedded_friendslist_neighbours_button_add_friends_png_1516657938:Class;
        private var _embed_mxml_____data_src_gfx_embedded_friendslist_neighbours_button_home_png_1286016308:Class;
        public static const ALL:int = 0;
        public static const GUILD:int = 3;
        private static var _watcherSetupUtil:IWatcherSetupUtil;
        public static const FRIENDS:int = 1;
        public static const ZONES:int = 2;

        public function FriendsListButtonBar()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"_FriendsListButtonBar_Canvas2", stylesFactory:function () : void
                {
                    null.top = this;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {width:71, height:88, childDescriptors:[new UIComponentDescriptor({type:Button, id:"btnAddFriend", events:{toolTipCreate:"__btnAddFriend_toolTipCreate"}, stylesFactory:function () : void
                    {
                        null.icon = this;
                        this.left = "2";
                        this.top = "2";
                        this.color = 3284992;
                        this.themeColor = 3284992;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {width:65, height:20, styleName:"filterFriendsList"};
                    }// end function
                    }), new UIComponentDescriptor({type:Button, id:"btnInvite", events:{toolTipCreate:"__btnInvite_toolTipCreate"}, stylesFactory:function () : void
                    {
                        null.icon = this;
                        this.left = "2";
                        this.top = "22";
                        this.color = 3284992;
                        this.themeColor = 3284992;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {width:65, height:20, styleName:"filterFriendsList"};
                    }// end function
                    }), new UIComponentDescriptor({type:Button, id:"btnReturnHome", events:{toolTipCreate:"__btnReturnHome_toolTipCreate"}, stylesFactory:function () : void
                    {
                        null.icon = this;
                        this.left = "2";
                        this.top = "42";
                        this.color = 3284992;
                        this.themeColor = 3284992;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, height:40, styleName:"returnHome"};
                    }// end function
                    })]};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_friendslist_neighbours_button_add_friends_png_1516657938 = FriendsListButtonBar__embed_mxml_____data_src_gfx_embedded_friendslist_neighbours_button_add_friends_png_1516657938;
            this._embed_mxml_____data_src_gfx_embedded_friendslist_neighbours_button_home_png_1286016308 = FriendsListButtonBar__embed_mxml_____data_src_gfx_embedded_friendslist_neighbours_button_home_png_1286016308;
            this._embed_mxml_____data_src_gfx_embedded_friendslist_neighbours_button_invite_friends_png_879654284 = FriendsListButtonBar__embed_mxml_____data_src_gfx_embedded_friendslist_neighbours_button_invite_friends_png_879654284;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            return;
        }// end function

        public function __btnAddFriend_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get btnInvite() : Button
        {
            return this._301950085btnInvite;
        }// end function

        public function set btnAddFriend(param1:Button) : void
        {
            var _loc_2:* = this._1033847901btnAddFriend;
            if (_loc_2 !== param1)
            {
                this._1033847901btnAddFriend = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnAddFriend", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnReturnHome_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        override public function initialize() : void
        {
            var target:FriendsListButtonBar;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._FriendsListButtonBar_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_FriendsListButtonBarWatcherSetupUtil");
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

        public function set btnInvite(param1:Button) : void
        {
            var _loc_2:* = this._301950085btnInvite;
            if (_loc_2 !== param1)
            {
                this._301950085btnInvite = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnInvite", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnReturnHome(param1:Button) : void
        {
            var _loc_2:* = this._1955813973btnReturnHome;
            if (_loc_2 !== param1)
            {
                this._1955813973btnReturnHome = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnReturnHome", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnAddFriend() : Button
        {
            return this._1033847901btnAddFriend;
        }// end function

        public function __btnInvite_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function _FriendsListButtonBar_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetClass("FriendFilterBackground");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "AddFriend");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "InviteByMail");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ReturnHome");
            return;
        }// end function

        public function get btnReturnHome() : Button
        {
            return this._1955813973btnReturnHome;
        }// end function

        private function _FriendsListButtonBar_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Object) : void
            {
                _FriendsListButtonBar_Canvas2.setStyle("backgroundImage", param1);
                return;
            }// end function
            , "_FriendsListButtonBar_Canvas2.backgroundImage");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "AddFriend");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnAddFriend.toolTip = param1;
                return;
            }// end function
            , "btnAddFriend.toolTip");
            result[1] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "InviteByMail");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnInvite.toolTip = param1;
                return;
            }// end function
            , "btnInvite.toolTip");
            result[2] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "ReturnHome");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnReturnHome.toolTip = param1;
                return;
            }// end function
            , "btnReturnHome.toolTip");
            result[3] = binding;
            return result;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
