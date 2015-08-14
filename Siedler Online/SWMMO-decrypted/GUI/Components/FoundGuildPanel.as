package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class FoundGuildPanel extends BasicPanel implements IBindingClient
    {
        public var _FoundGuildPanel_FormItem1:FormItem;
        private var _1848510178guildName:TextInput;
        public var _FoundGuildPanel_FormItem2:FormItem;
        var _watchers:Array;
        private var _912210348btnBannerRight:Button;
        private var _1306549593guildTag:TextInput;
        private var _2085208710btnFound:StandardButton;
        var _bindingsBeginWithWord:Object;
        var _bindingsByDestination:Object;
        private var _1356381607selectedBanner:Image;
        public var _FoundGuildPanel_Label1:Label;
        var _bindings:Array;
        private var _29608753btnBannerLeft:Button;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function FoundGuildPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:BasicPanel, propertiesFactory:function () : Object
            {
                return {null:null, height:415};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 330;
            this.height = 415;
            this.subComponents = [this._FoundGuildPanel_Canvas1_c(), this._FoundGuildPanel_Canvas2_c(), this._FoundGuildPanel_Canvas3_c()];
            return;
        }// end function

        private function _FoundGuildPanel_TextInput1_i() : TextInput
        {
            var _loc_1:* = new TextInput();
            this.guildName = _loc_1;
            _loc_1.maxChars = 32;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.restrict = "^\\\\";
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("borderStyle", "none");
            _loc_1.setStyle("focusAlpha", 0);
            _loc_1.id = "guildName";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _FoundGuildPanel_Image1_i() : Image
        {
            var _loc_1:* = new Image();
            this.selectedBanner = _loc_1;
            _loc_1.width = 133;
            _loc_1.height = 233;
            _loc_1.scaleContent = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "-18");
            _loc_1.id = "selectedBanner";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnFound(param1:StandardButton) : void
        {
            var _loc_2:* = this._2085208710btnFound;
            if (_loc_2 !== param1)
            {
                this._2085208710btnFound = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnFound", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnFound() : StandardButton
        {
            return this._2085208710btnFound;
        }// end function

        public function set btnBannerLeft(param1:Button) : void
        {
            var _loc_2:* = this._29608753btnBannerLeft;
            if (_loc_2 !== param1)
            {
                this._29608753btnBannerLeft = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnBannerLeft", _loc_2, param1));
            }
            return;
        }// end function

        private function _FoundGuildPanel_Button2_i() : Button
        {
            var _loc_1:* = new Button();
            this.btnBannerRight = _loc_1;
            _loc_1.width = 25;
            _loc_1.height = 23;
            _loc_1.setStyle("right", "10");
            _loc_1.setStyle("verticalCenter", "-20");
            _loc_1.id = "btnBannerRight";
            BindingManager.executeBindings(this, "btnBannerRight", this.btnBannerRight);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _FoundGuildPanel_StandardButton1_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnFound = _loc_1;
            _loc_1.enabled = false;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "0");
            _loc_1.id = "btnFound";
            BindingManager.executeBindings(this, "btnFound", this.btnFound);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _FoundGuildPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildName");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "_FoundGuildPanel_FormItem1.label");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildTag");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "_FoundGuildPanel_FormItem2.label");
            result[1] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildBanner");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_FoundGuildPanel_Label1.text");
            result[2] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowLeft");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnBannerLeft.upSkin");
            result[3] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnBannerLeft.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnBannerLeft.overSkin");
            result[4] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowLeftHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnBannerLeft.downSkin");
            result[5] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowLeftDisabled");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnBannerLeft.disabledSkin");
            result[6] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowRight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnBannerRight.upSkin");
            result[7] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowRightHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnBannerRight.overSkin");
            result[8] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnBannerRight.downSkin");
            result[9] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnBannerRight.disabledSkin");
            result[10] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "GuildFound");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnFound.label");
            result[11] = binding;
            return result;
        }// end function

        public function get guildTag() : TextInput
        {
            return this._1306549593guildTag;
        }// end function

        public function set btnBannerRight(param1:Button) : void
        {
            var _loc_2:* = this._912210348btnBannerRight;
            if (_loc_2 !== param1)
            {
                this._912210348btnBannerRight = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnBannerRight", _loc_2, param1));
            }
            return;
        }// end function

        public function get guildName() : TextInput
        {
            return this._1848510178guildName;
        }// end function

        public function get selectedBanner() : Image
        {
            return this._1356381607selectedBanner;
        }// end function

        override public function initialize() : void
        {
            var target:FoundGuildPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._FoundGuildPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_FoundGuildPanelWatcherSetupUtil");
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

        private function _FoundGuildPanel_Canvas2_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsSubHeader";
            _loc_1.height = 18;
            _loc_1.setStyle("left", "8");
            _loc_1.setStyle("right", "7");
            _loc_1.setStyle("top", "84");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._FoundGuildPanel_Label1_i());
            return _loc_1;
        }// end function

        private function _FoundGuildPanel_Canvas4_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.percentWidth = 100;
            _loc_1.height = 40;
            _loc_1.styleName = "detailsSubContentBox";
            _loc_1.setStyle("bottom", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._FoundGuildPanel_StandardButton1_i());
            return _loc_1;
        }// end function

        private function _FoundGuildPanel_FormItem1_i() : FormItem
        {
            var _loc_1:* = new FormItem();
            this._FoundGuildPanel_FormItem1 = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.id = "_FoundGuildPanel_FormItem1";
            BindingManager.executeBindings(this, "_FoundGuildPanel_FormItem1", this._FoundGuildPanel_FormItem1);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._FoundGuildPanel_TextInput1_i());
            return _loc_1;
        }// end function

        private function _FoundGuildPanel_Form1_c() : Form
        {
            var _loc_1:* = new Form();
            _loc_1.setStyle("left", "0");
            _loc_1.setStyle("right", "0");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._FoundGuildPanel_FormItem1_i());
            _loc_1.addChild(this._FoundGuildPanel_FormItem2_i());
            return _loc_1;
        }// end function

        private function _FoundGuildPanel_TextInput2_i() : TextInput
        {
            var _loc_1:* = new TextInput();
            this.guildTag = _loc_1;
            _loc_1.restrict = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789\\-";
            _loc_1.maxChars = 5;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.setStyle("borderStyle", "none");
            _loc_1.setStyle("focusAlpha", 0);
            _loc_1.id = "guildTag";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set guildTag(param1:TextInput) : void
        {
            var _loc_2:* = this._1306549593guildTag;
            if (_loc_2 !== param1)
            {
                this._1306549593guildTag = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "guildTag", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnBannerLeft() : Button
        {
            return this._29608753btnBannerLeft;
        }// end function

        private function _FoundGuildPanel_Label1_i() : Label
        {
            var _loc_1:* = new Label();
            this._FoundGuildPanel_Label1 = _loc_1;
            _loc_1.setStyle("top", "1");
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.id = "_FoundGuildPanel_Label1";
            BindingManager.executeBindings(this, "_FoundGuildPanel_Label1", this._FoundGuildPanel_Label1);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnBannerRight() : Button
        {
            return this._912210348btnBannerRight;
        }// end function

        public function set selectedBanner(param1:Image) : void
        {
            var _loc_2:* = this._1356381607selectedBanner;
            if (_loc_2 !== param1)
            {
                this._1356381607selectedBanner = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "selectedBanner", _loc_2, param1));
            }
            return;
        }// end function

        private function _FoundGuildPanel_Button1_i() : Button
        {
            var _loc_1:* = new Button();
            this.btnBannerLeft = _loc_1;
            _loc_1.width = 25;
            _loc_1.height = 23;
            _loc_1.setStyle("left", "10");
            _loc_1.setStyle("verticalCenter", "-20");
            _loc_1.id = "btnBannerLeft";
            BindingManager.executeBindings(this, "btnBannerLeft", this.btnBannerLeft);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _FoundGuildPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildName");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildTag");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildBanner");
            _loc_1 = gAssetManager.GetClass("ArrowLeft");
            _loc_1 = gAssetManager.GetClass("ArrowLeftHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowLeftHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowLeftDisabled");
            _loc_1 = gAssetManager.GetClass("ArrowRight");
            _loc_1 = gAssetManager.GetClass("ArrowRightHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowRightHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowRightDisabled");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildFound");
            return;
        }// end function

        public function set guildName(param1:TextInput) : void
        {
            var _loc_2:* = this._1848510178guildName;
            if (_loc_2 !== param1)
            {
                this._1848510178guildName = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "guildName", _loc_2, param1));
            }
            return;
        }// end function

        private function _FoundGuildPanel_Canvas3_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsContentBox";
            _loc_1.clipContent = true;
            _loc_1.horizontalScrollPolicy = "off";
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("left", "9");
            _loc_1.setStyle("right", "8");
            _loc_1.setStyle("top", "102");
            _loc_1.setStyle("bottom", "7");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._FoundGuildPanel_Image1_i());
            _loc_1.addChild(this._FoundGuildPanel_Button1_i());
            _loc_1.addChild(this._FoundGuildPanel_Button2_i());
            _loc_1.addChild(this._FoundGuildPanel_Canvas4_c());
            return _loc_1;
        }// end function

        private function _FoundGuildPanel_Canvas1_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsHeader";
            _loc_1.height = 82;
            _loc_1.horizontalScrollPolicy = "off";
            _loc_1.verticalScrollPolicy = "off";
            _loc_1.setStyle("left", "2");
            _loc_1.setStyle("right", "2");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._FoundGuildPanel_Form1_c());
            return _loc_1;
        }// end function

        private function _FoundGuildPanel_FormItem2_i() : FormItem
        {
            var _loc_1:* = new FormItem();
            this._FoundGuildPanel_FormItem2 = _loc_1;
            _loc_1.percentWidth = 100;
            _loc_1.id = "_FoundGuildPanel_FormItem2";
            BindingManager.executeBindings(this, "_FoundGuildPanel_FormItem2", this._FoundGuildPanel_FormItem2);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._FoundGuildPanel_TextInput2_i());
            return _loc_1;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
