package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class Avatar extends Canvas implements IBindingClient
    {
        private var _1413116727animXP:SpriteLibAnimation;
        var _watchers:Array;
        private var _1131509414progressBar:Canvas;
        private var _embed_mxml_____data_src_gfx_embedded_avatar_background_png_533492966:Class;
        private var _655478139btnNewMail:Button;
        private var _193276766tutorial:Canvas;
        private var _102865796level:Label;
        private var _376760194avatarImage:Image;
        private var _729192978animLevelUp:SpriteLibAnimation;
        private var _345909401avatarBackground:Image;
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        private var _311478402otherPlayers:TileList;
        private var _2095657228playerName:Label;
        public var _Avatar_Label3:Label;
        private var _embed_mxml__1101889401:Class;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _1851166703btnQuestBook:TwinkleButton;
        private var _1065377929xpTooltipMask:Canvas;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function Avatar()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {width:160, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"progressBar", stylesFactory:function () : void
                {
                    this.left = "17";
                    this.top = "110";
                    this.backgroundColor = 9830144;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:30, width:100};
                }// end function
                }), new UIComponentDescriptor({type:Image, stylesFactory:function () : void
                {
                    this.left = "2";
                    this.top = "70";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:_embed_mxml_____data_src_gfx_embedded_avatar_background_png_533492966};
                }// end function
                }), new UIComponentDescriptor({type:Image, id:"avatarBackground"}), new UIComponentDescriptor({type:Image, id:"avatarImage"}), new UIComponentDescriptor({type:Canvas, id:"xpTooltipMask", events:{toolTipCreate:"__xpTooltipMask_toolTipCreate"}, stylesFactory:function () : void
                {
                    null.left = this;
                    this.top = "110";
                    this.backgroundColor = 16777215;
                    this.backgroundAlpha = 0;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, width:100};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"playerName", stylesFactory:function () : void
                {
                    this.left = "10";
                    this.textAlign = "center";
                    this.fontWeight = "bold";
                    this.color = 16777215;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {y:147, width:113};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"level", stylesFactory:function () : void
                {
                    null.left = this;
                    this.textAlign = "center";
                    this.fontWeight = "bold";
                    this.color = 16777215;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {y:165, width:113};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"tutorial", events:{toolTipCreate:"__tutorial_toolTipCreate"}, stylesFactory:function () : void
                {
                    this.horizontalCenter = "-13";
                    this.top = "179";
                    this.backgroundSize = "100%";
                    this.backgroundImage = _embed_mxml__1101889401;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {visible:false, height:29, childDescriptors:[new UIComponentDescriptor({type:Label, id:"_Avatar_Label3", stylesFactory:function () : void
                    {
                        this.fontWeight = "bold";
                        this.color = 16777215;
                        this.left = "16";
                        this.right = "16";
                        this.top = "3";
                        return;
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:SpriteLibAnimation, id:"animXP", propertiesFactory:function () : Object
                {
                    return {null:false, x:5, y:95, width:131, height:69, animationName:"guianim_avatar_xp"};
                }// end function
                }), new UIComponentDescriptor({type:SpriteLibAnimation, id:"animLevelUp", propertiesFactory:function () : Object
                {
                    return {visible:false, x:15, y:153, width:120, height:50, animationName:"guianim_avatar_levelup"};
                }// end function
                }), new UIComponentDescriptor({type:TileList, id:"otherPlayers", stylesFactory:function () : void
                {
                    null.useRollOver = this;
                    this.horizontalCenter = "0";
                    this.backgroundAlpha = 0;
                    this.borderThickness = 0;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:false, width:120, y:253, itemRenderer:_Avatar_ClassFactory1_c()};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnNewMail", stylesFactory:function () : void
                {
                    null.right = this;
                    this.top = "40";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {visible:false, width:32, height:24};
                }// end function
                }), new UIComponentDescriptor({type:TwinkleButton, id:"btnQuestBook", stylesFactory:function () : void
                {
                    this.right = "0";
                    this.top = "110";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {twinkle:false, visible:true, width:67, height:66};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml__1101889401 = Avatar__embed_mxml__1101889401;
            this._embed_mxml_____data_src_gfx_embedded_avatar_background_png_533492966 = Avatar__embed_mxml_____data_src_gfx_embedded_avatar_background_png_533492966;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 160;
            return;
        }// end function

        public function get tutorial() : Canvas
        {
            return this._193276766tutorial;
        }// end function

        public function get avatarImage() : Image
        {
            return this._376760194avatarImage;
        }// end function

        public function set avatarImage(param1:Image) : void
        {
            var _loc_2:* = this._376760194avatarImage;
            if (_loc_2 !== param1)
            {
                this._376760194avatarImage = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "avatarImage", _loc_2, param1));
            }
            return;
        }// end function

        public function set xpTooltipMask(param1:Canvas) : void
        {
            var _loc_2:* = this._1065377929xpTooltipMask;
            if (_loc_2 !== param1)
            {
                this._1065377929xpTooltipMask = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "xpTooltipMask", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnQuestBook() : TwinkleButton
        {
            return this._1851166703btnQuestBook;
        }// end function

        public function set level(param1:Label) : void
        {
            var _loc_2:* = this._102865796level;
            if (_loc_2 !== param1)
            {
                this._102865796level = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "level", _loc_2, param1));
            }
            return;
        }// end function

        public function get otherPlayers() : TileList
        {
            return this._311478402otherPlayers;
        }// end function

        public function get level() : Label
        {
            return this._102865796level;
        }// end function

        public function get playerName() : Label
        {
            return this._2095657228playerName;
        }// end function

        override public function initialize() : void
        {
            var target:Avatar;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._Avatar_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_AvatarWatcherSetupUtil");
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

        public function set animXP(param1:SpriteLibAnimation) : void
        {
            var _loc_2:* = this._1413116727animXP;
            if (_loc_2 !== param1)
            {
                this._1413116727animXP = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "animXP", _loc_2, param1));
            }
            return;
        }// end function

        public function set otherPlayers(param1:TileList) : void
        {
            var _loc_2:* = this._311478402otherPlayers;
            if (_loc_2 !== param1)
            {
                this._311478402otherPlayers = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "otherPlayers", _loc_2, param1));
            }
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

        private function _Avatar_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "Tutorial");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = null;
                return;
            }// end function
            , "tutorial.toolTip");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Tutorial");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_Avatar_Label3.text");
            result[1] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ButtonIconNewMail");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnNewMail.upSkin");
            result[2] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnNewMail.downSkin");
            result[3] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ButtonIconNewMail");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnNewMail.overSkin");
            result[4] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnNewMail.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnNewMail.disabledSkin");
            result[5] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("IconQuest");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnQuestBook.upSkin");
            result[6] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnQuestBook.downSkin");
            result[7] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnQuestBook.overSkin");
            result[8] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("IconQuestHighlight");
            }// end function
            , function (param1:Class) : void
            {
                btnQuestBook.setStyle("selectedUpSkin", param1);
                return;
            }// end function
            , "btnQuestBook.selectedUpSkin");
            result[9] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("IconQuestHighlight");
            }// end function
            , function (param1:Class) : void
            {
                btnQuestBook.setStyle("selectedOverSkin", param1);
                return;
            }// end function
            , "btnQuestBook.selectedOverSkin");
            result[10] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnQuestBook.setStyle("selectedDownSkin", param1);
                return;
            }// end function
            , "btnQuestBook.selectedDownSkin");
            result[11] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("IconQuest");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnQuestBook.disabledSkin");
            result[12] = binding;
            return result;
        }// end function

        public function get progressBar() : Canvas
        {
            return this._1131509414progressBar;
        }// end function

        public function __xpTooltipMask_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.MULTILINE_string, event);
            return;
        }// end function

        public function set tutorial(param1:Canvas) : void
        {
            var _loc_2:* = this._193276766tutorial;
            if (_loc_2 !== param1)
            {
                this._193276766tutorial = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "tutorial", _loc_2, param1));
            }
            return;
        }// end function

        public function get animXP() : SpriteLibAnimation
        {
            return this._1413116727animXP;
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

        public function set progressBar(param1:Canvas) : void
        {
            var _loc_2:* = this._1131509414progressBar;
            if (_loc_2 !== param1)
            {
                this._1131509414progressBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "progressBar", _loc_2, param1));
            }
            return;
        }// end function

        private function _Avatar_ClassFactory1_c() : ClassFactory
        {
            var _loc_1:* = new ClassFactory();
            _loc_1.generator = AvatarListItemRenderer;
            return _loc_1;
        }// end function

        public function set btnQuestBook(param1:TwinkleButton) : void
        {
            var _loc_2:* = this._1851166703btnQuestBook;
            if (_loc_2 !== param1)
            {
                this._1851166703btnQuestBook = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnQuestBook", _loc_2, param1));
            }
            return;
        }// end function

        public function set animLevelUp(param1:SpriteLibAnimation) : void
        {
            var _loc_2:* = this._729192978animLevelUp;
            if (_loc_2 !== param1)
            {
                this._729192978animLevelUp = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "animLevelUp", _loc_2, param1));
            }
            return;
        }// end function

        public function get animLevelUp() : SpriteLibAnimation
        {
            return this._729192978animLevelUp;
        }// end function

        public function get xpTooltipMask() : Canvas
        {
            return this._1065377929xpTooltipMask;
        }// end function

        private function _Avatar_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, "Tutorial");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Tutorial");
            _loc_1 = gAssetManager.GetClass("ButtonIconNewMail");
            _loc_1 = gAssetManager.GetClass("ButtonIconNewMail");
            _loc_1 = gAssetManager.GetClass("ButtonIconNewMail");
            _loc_1 = gAssetManager.GetClass("ButtonIconNewMail");
            _loc_1 = gAssetManager.GetClass("IconQuest");
            _loc_1 = gAssetManager.GetClass("IconQuestHighlight");
            _loc_1 = gAssetManager.GetClass("IconQuestHighlight");
            _loc_1 = gAssetManager.GetClass("IconQuestHighlight");
            _loc_1 = gAssetManager.GetClass("IconQuestHighlight");
            _loc_1 = gAssetManager.GetClass("IconQuestHighlight");
            _loc_1 = gAssetManager.GetClass("IconQuest");
            return;
        }// end function

        public function get btnNewMail() : Button
        {
            return this._655478139btnNewMail;
        }// end function

        public function set btnNewMail(param1:Button) : void
        {
            var _loc_2:* = this._655478139btnNewMail;
            if (_loc_2 !== param1)
            {
                this._655478139btnNewMail = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnNewMail", _loc_2, param1));
            }
            return;
        }// end function

        public function __tutorial_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.MULTILINE_string, event);
            return;
        }// end function

        public function get avatarBackground() : Image
        {
            return this._345909401avatarBackground;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
