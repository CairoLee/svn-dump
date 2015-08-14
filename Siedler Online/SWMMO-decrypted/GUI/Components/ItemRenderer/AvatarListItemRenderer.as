package GUI.Components.ItemRenderer
{
    import Communication.VO.*;
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import ServerState.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class AvatarListItemRenderer extends Canvas implements IBindingClient
    {
        public var _AvatarListItemRenderer_Image3:Image;
        var _watchers:Array;
        private var _1405959847avatar:Image;
        private var _active:Boolean = true;
        public var toolTipType:String = "Simple";
        private var _useContextMenu:Boolean = false;
        var _bindingsBeginWithWord:Object;
        private var _colorIndex:int = 0;
        private var _345909401avatarBackground:Image;
        var _bindingsByDestination:Object;
        private var _1209439397_addMode:Boolean = false;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _738043469iconPlus:Image;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function AvatarListItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:60, height:60, childDescriptors:[new UIComponentDescriptor({type:Image, id:"avatarBackground", propertiesFactory:function () : Object
                {
                    return {percentWidth:100, percentHeight:100, scaleContent:false};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"avatar", propertiesFactory:function () : Object
                {
                    return {null:100, percentHeight:100, scaleContent:false};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"_AvatarListItemRenderer_Image3", propertiesFactory:function () : Object
                {
                    return {null:null, percentHeight:100, scaleContent:false};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"iconPlus", stylesFactory:function () : void
                {
                    this.right = "0";
                    this.bottom = "0";
                    return;
                }// end function
                })]};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 60;
            this.height = 60;
            this.addEventListener("creationComplete", this.___AvatarListItemRenderer_Canvas1_creationComplete);
            this.addEventListener("click", this.___AvatarListItemRenderer_Canvas1_click);
            this.addEventListener("toolTipCreate", this.___AvatarListItemRenderer_Canvas1_toolTipCreate);
            return;
        }// end function

        public function GetColorIndex() : int
        {
            return this._colorIndex;
        }// end function

        public function get active() : Boolean
        {
            return this._active;
        }// end function

        public function ___AvatarListItemRenderer_Canvas1_click(event:MouseEvent) : void
        {
            this.ShowContextMenu(event);
            return;
        }// end function

        override public function initialize() : void
        {
            var target:AvatarListItemRenderer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._AvatarListItemRenderer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ItemRenderer_AvatarListItemRendererWatcherSetupUtil");
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

        public function set active(param1:Boolean) : void
        {
            this._active = param1;
            if (data == null || this.avatar == null)
            {
                return;
            }
            if (this._active)
            {
                this.avatar.filters = [];
            }
            else
            {
                this.avatar.filters = [gAssetManager.inactiveFilter];
            }
            return;
        }// end function

        private function _AvatarListItemRenderer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetBitmap("AvatarBackgroundSmall00");
            _loc_1 = this._addMode;
            _loc_1 = gAssetManager.GetBitmap("AvatarAdd");
            return;
        }// end function

        private function Display(event:Event = null) : void
        {
            this.removeEventListener(FlexEvent.CREATION_COMPLETE, this.Display);
            this._addMode = false;
            if (data is cPlayerData)
            {
                this._colorIndex = global.ui.mCurrentPlayerZone.GetPlayerColorIdx(data.GetPlayerId()) + 1;
                this.avatarBackground.source = gAssetManager.GetBitmap("AvatarBackgroundSmall0" + this._colorIndex);
                this.avatar.source = gAssetManager.GetAvatarUrl(data.GetAvatarId(), AVATAR_SIZE.SMALL);
                toolTip = cPlayerData(data).GetPlayerName_string();
            }
            else if (data is dPlayerListItemVO)
            {
                this._colorIndex = global.ui.mCurrentPlayerZone.GetPlayerColorIdx(data.id) + 1;
                this.avatarBackground.source = gAssetManager.GetBitmap(this._colorIndex < 10 ? ("AvatarBackgroundSmall0" + this._colorIndex) : ("AvatarBackgroundSmall" + this._colorIndex));
                if (data.avatarId < 0)
                {
                    this.avatar.source = gAssetManager.GetBitmap(Math.abs(data.avatarId) < 10 ? ("AvatarBanditSmall0" + Math.abs(data.avatarId)) : ("AvatarBanditSmall" + Math.abs(data.avatarId)));
                }
                else
                {
                    this.avatar.source = gAssetManager.GetAvatarUrl(data.avatarId, AVATAR_SIZE.SMALL);
                }
                if (data is dAdventurePlayerListItemVO && data.status == ADVENTURE_INVITATION_STATUS.PENDING)
                {
                    this.toolTipType = cToolTipUtil.MULTILINE_string;
                    toolTip = data.username + "\n\n" + cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "AdventureInviteTimeoutHelp");
                }
                else
                {
                    toolTip = data.username;
                    this.toolTipType = cToolTipUtil.SIMPLE_string;
                }
            }
            if (this._active)
            {
                this.avatar.filters = [];
            }
            else
            {
                this.avatar.filters = [gAssetManager.inactiveFilter];
            }
            return;
        }// end function

        protected function Initialize() : void
        {
            if (data != null)
            {
                return;
            }
            this.avatarBackground.source = gAssetManager.GetBitmap("AvatarBackgroundSmall13");
            this.avatar.source = gAssetManager.GetBitmap("AvatarSmall00");
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

        public function get iconPlus() : Image
        {
            return this._738043469iconPlus;
        }// end function

        private function get _addMode() : Boolean
        {
            return this._1209439397_addMode;
        }// end function

        public function set addMode(param1:Boolean) : void
        {
            this._addMode = param1;
            this.toolTipType = cToolTipUtil.MULTILINE_string;
            toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "InvitePlayer") + "\n\n" + cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "AdventureInviteTimeoutHelp");
            return;
        }// end function

        public function ___AvatarListItemRenderer_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(this.toolTipType, event);
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            if (this.avatarBackground && this.avatar)
            {
                this.Display();
            }
            else
            {
                this.addEventListener(FlexEvent.CREATION_COMPLETE, this.Display);
            }
            return;
        }// end function

        public function set avatarBackground(param1:Image) : void
        {
            var _loc_2:* = this._345909401avatarBackground;
            if (_loc_2 !== param1)
            {
                this._345909401avatarBackground = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "avatarBackground", _loc_2, param1));
            }
            return;
        }// end function

        public function ShowContextMenu(event:MouseEvent) : void
        {
            if (!this._useContextMenu)
            {
                return;
            }
            var _loc_2:* = new dPlayerListItemVO();
            _loc_2.username = cPlayerData(data).GetPlayerName_string();
            _loc_2.id = cPlayerData(data).GetPlayerId();
            globalFlash.gui.ShowFriendListMenu(event, _loc_2);
            return;
        }// end function

        public function ___AvatarListItemRenderer_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.Initialize();
            return;
        }// end function

        private function set _addMode(param1:Boolean) : void
        {
            var _loc_2:* = this._1209439397_addMode;
            if (_loc_2 !== param1)
            {
                this._1209439397_addMode = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "_addMode", _loc_2, param1));
            }
            return;
        }// end function

        public function get addMode() : Boolean
        {
            return this._addMode;
        }// end function

        public function set iconPlus(param1:Image) : void
        {
            var _loc_2:* = this._738043469iconPlus;
            if (_loc_2 !== param1)
            {
                this._738043469iconPlus = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "iconPlus", _loc_2, param1));
            }
            return;
        }// end function

        public function get avatarBackground() : Image
        {
            return this._345909401avatarBackground;
        }// end function

        public function get avatar() : Image
        {
            return this._1405959847avatar;
        }// end function

        private function _AvatarListItemRenderer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap(null);
            }// end function
            , function (param1:Object) : void
            {
                null.source = null;
                return;
            }// end function
            , "_AvatarListItemRenderer_Image3.source");
            result[0] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return _addMode;
            }// end function
            , function (param1:Boolean) : void
            {
                null.visible = null;
                return;
            }// end function
            , "iconPlus.visible");
            result[1] = binding;
            binding = new Binding(this, function () : Object
            {
                return null.GetBitmap(null);
            }// end function
            , function (param1:Object) : void
            {
                null.source = param1;
                return;
            }// end function
            , "iconPlus.source");
            result[2] = binding;
            return result;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
