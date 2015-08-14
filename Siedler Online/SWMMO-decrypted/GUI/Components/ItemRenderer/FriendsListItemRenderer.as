package GUI.Components.ItemRenderer
{
    import AdventureSystem.*;
    import Communication.VO.*;
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class FriendsListItemRenderer extends Canvas implements IBindingClient
    {
        private var _539145507playerLevel:Label;
        private var _1159866405onlineStatus:Image;
        var _bindingsBeginWithWord:Object;
        var _watchers:Array;
        private var _1405959847avatar:Image;
        var _bindingsByDestination:Object;
        private var _2095657228playerName:Label;
        private var _142472865currentZoneMarker:Image;
        var _bindings:Array;
        private var _2006986763typeIndicator:Image;
        private var mBackground:Class;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function FriendsListItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:71, height:88, childDescriptors:[new UIComponentDescriptor({type:Image, id:"typeIndicator", stylesFactory:function () : void
                {
                    null.bottom = this;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:71, height:20};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"currentZoneMarker", stylesFactory:function () : void
                {
                    this.top = "4";
                    this.left = "4";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"avatar", stylesFactory:function () : void
                {
                    null.top = this;
                    this.horizontalCenter = "0";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"onlineStatus", stylesFactory:function () : void
                {
                    this.left = "5";
                    this.top = "5";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"playerName", events:{toolTipCreate:"__playerName_toolTipCreate"}, stylesFactory:function () : void
                {
                    this.horizontalCenter = "0";
                    this.top = "49";
                    this.fontWeight = "bold";
                    this.textAlign = "center";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"playerLevel", events:{toolTipCreate:"__playerLevel_toolTipCreate"}, stylesFactory:function () : void
                {
                    this.horizontalCenter = "0";
                    this.top = "66";
                    this.color = 16777215;
                    this.fontWeight = "bold";
                    this.textAlign = "center";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:67};
                }// end function
                })]};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.horizontalScrollPolicy = "off";
            this.verticalScrollPolicy = "off";
            this.width = 71;
            this.height = 88;
            this.addEventListener("rollOver", this.___FriendsListItemRenderer_Canvas1_rollOver);
            this.addEventListener("rollOut", this.___FriendsListItemRenderer_Canvas1_rollOut);
            this.addEventListener("click", this.___FriendsListItemRenderer_Canvas1_click);
            return;
        }// end function

        public function __playerLevel_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set playerLevel(param1:Label) : void
        {
            var _loc_2:* = this._539145507playerLevel;
            if (_loc_2 !== param1)
            {
                this._539145507playerLevel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "playerLevel", _loc_2, param1));
            }
            return;
        }// end function

        public function get onlineStatus() : Image
        {
            return this._1159866405onlineStatus;
        }// end function

        public function get typeIndicator() : Image
        {
            return this._2006986763typeIndicator;
        }// end function

        override public function initialize() : void
        {
            var target:FriendsListItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._FriendsListItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_FriendsListItemRendererWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return null[null];
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
            globalFlash.gui.ShowFriendListMenu(event, data as dPlayerListItemVO);
            return;
        }// end function

        public function get playerName() : Label
        {
            return this._2095657228playerName;
        }// end function

        public function __playerName_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function _FriendsListItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap(null);
            }// end function
            , function (param1:Object) : void
            {
                currentZoneMarker.source = param1;
                return;
            }// end function
            , "currentZoneMarker.source");
            result[0] = binding;
            return result;
        }// end function

        override public function set data(param1:Object) : void
        {
            var _loc_2:cAdventureDefinition = null;
            var _loc_3:Number = NaN;
            super.data = param1;
            this.setStyle("backgroundImage", gAssetManager.GetClass("FriendBackground"));
            if (data.id > -1)
            {
                this.avatar.source = gAssetManager.GetAvatarUrl(data.avatarId, AVATAR_SIZE.SMALL);
                this.typeIndicator.source = globalFlash.gui.mFriendsList.IsGuildMember(data as dPlayerListItemVO) ? (gAssetManager.GetBitmap("FriendIndicatorGuild")) : (null);
                this.playerLevel.text = data.playerLevel == 0 ? ("1") : (data.playerLevel);
                this.playerLevel.toolTip = "";
            }
            else
            {
                _loc_2 = cAdventureDefinition.FindAdventureDefinition(data.adventureVO.adventureName);
                this.typeIndicator.source = gAssetManager.GetBitmap("FriendIndicatorAdventure");
                this.avatar.source = _loc_2.GetAvatarImage();
                _loc_3 = data.adventureVO.totalDuration - data.adventureVO.collectedTime;
                this.playerLevel.text = cLocaManager.GetInstance().FormatDuration(_loc_3 > 0 ? (_loc_3) : (0), cLocaManager.DURATION_FORMAT_NUMERIC);
                this.playerLevel.toolTip = cLocaManager.GetInstance().FormatDuration(_loc_3 > 0 ? (_loc_3) : (0), cLocaManager.DURATION_FORMAT_NORMAL);
            }
            this.onlineStatus.visible = data.id > -1 && data.onlineStatus;
            this.onlineStatus.source = data.onlineStatus ? (gAssetManager.GetBitmap("OnlineStatusGreen")) : (gAssetManager.GetBitmap("OnlineStatusRed"));
            this.playerName.text = data.id > 0 ? (data.username) : (cLocaManager.GetInstance().GetText(LOCA_GROUP.ADVENTURE_NAME, (data as dPlayerListItemVO).adventureVO.adventureName));
            this.currentZoneMarker.visible = data.id == global.ui.mCurrentViewedZoneID;
            if (data.id == global.ui.mCurrentPlayer.GetPlayerId())
            {
                this.playerName.setStyle("color", 16777215);
            }
            else
            {
                this.playerName.setStyle("color", 3284992);
            }
            return;
        }// end function

        public function get playerLevel() : Label
        {
            return this._539145507playerLevel;
        }// end function

        public function get currentZoneMarker() : Image
        {
            return this._142472865currentZoneMarker;
        }// end function

        public function get avatar() : Image
        {
            return this._1405959847avatar;
        }// end function

        public function ___FriendsListItemRenderer_Canvas1_rollOver(event:MouseEvent) : void
        {
            this.setStyle("backgroundImage", gAssetManager.GetClass("FriendBackgroundHighlight"));
            return;
        }// end function

        public function ___FriendsListItemRenderer_Canvas1_click(event:MouseEvent) : void
        {
            this.ShowContextMenu(event);
            return;
        }// end function

        private function _FriendsListItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetBitmap("FriendVisit");
            return;
        }// end function

        public function set playerName(param1:Label) : void
        {
            var _loc_2:* = this._2095657228playerName;
            if (_loc_2 !== param1)
            {
                this._2095657228playerName = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "playerName", _loc_2, param1));
            }
            return;
        }// end function

        public function set typeIndicator(param1:Image) : void
        {
            var _loc_2:* = this._2006986763typeIndicator;
            if (_loc_2 !== param1)
            {
                this._2006986763typeIndicator = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "typeIndicator", _loc_2, param1));
            }
            return;
        }// end function

        public function ___FriendsListItemRenderer_Canvas1_rollOut(event:MouseEvent) : void
        {
            this.setStyle("backgroundImage", gAssetManager.GetClass("FriendBackground"));
            return;
        }// end function

        public function set onlineStatus(param1:Image) : void
        {
            var _loc_2:* = this._1159866405onlineStatus;
            if (_loc_2 !== param1)
            {
                this._1159866405onlineStatus = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "onlineStatus", _loc_2, param1));
            }
            return;
        }// end function

        public function set avatar(param1:Image) : void
        {
            var _loc_2:* = this._1405959847avatar;
            if (_loc_2 !== param1)
            {
                this._1405959847avatar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "avatar", _loc_2, param1));
            }
            return;
        }// end function

        public function set currentZoneMarker(param1:Image) : void
        {
            var _loc_2:* = this._142472865currentZoneMarker;
            if (_loc_2 !== param1)
            {
                this._142472865currentZoneMarker = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "currentZoneMarker", _loc_2, param1));
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
