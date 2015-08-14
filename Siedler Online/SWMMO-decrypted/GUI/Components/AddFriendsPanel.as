package GUI.Components
{
    import Enums.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class AddFriendsPanel extends BasicPanel implements IBindingClient
    {
        private var _94069048btnOK:StandardButton;
        var _watchers:Array;
        private var _940821457avatarPreview:AvatarListItemRenderer;
        private var _356806342usersList:List;
        var _bindingsByDestination:Object;
        private var _559723774searchInput:TextInput;
        private var _1545879345enterNameLabel:Text;
        private var _145482051namePreview:Label;
        var _bindingsBeginWithWord:Object;
        private var _117924854btnCancel:StandardButton;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function AddFriendsPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:BasicPanel, propertiesFactory:function () : Object
            {
                return {null:320, height:235};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.width = 320;
            this.height = 235;
            this.subComponents = [this._AddFriendsPanel_Canvas1_c(), this._AddFriendsPanel_HBox1_c(), this._AddFriendsPanel_Canvas2_c(), this._AddFriendsPanel_Canvas3_c()];
            return;
        }// end function

        private function _AddFriendsPanel_Text1_i() : Text
        {
            var _loc_1:* = new Text();
            this.enterNameLabel = _loc_1;
            _loc_1.selectable = false;
            _loc_1.setStyle("left", "15");
            _loc_1.setStyle("right", "15");
            _loc_1.setStyle("top", "8");
            _loc_1.setStyle("bottom", "25");
            _loc_1.id = "enterNameLabel";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get searchInput() : TextInput
        {
            return this._559723774searchInput;
        }// end function

        private function _AddFriendsPanel_AvatarListItemRenderer1_i() : AvatarListItemRenderer
        {
            var _loc_1:* = new AvatarListItemRenderer();
            this.avatarPreview = _loc_1;
            _loc_1.setStyle("horizontalCenter", "0");
            _loc_1.setStyle("verticalCenter", "-10");
            _loc_1.id = "avatarPreview";
            BindingManager.executeBindings(this, "avatarPreview", this.avatarPreview);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set searchInput(param1:TextInput) : void
        {
            var _loc_2:* = this._559723774searchInput;
            if (_loc_2 !== param1)
            {
                this._559723774searchInput = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "searchInput", _loc_2, param1));
            }
            return;
        }// end function

        public function set usersList(param1:List) : void
        {
            var _loc_2:* = this._356806342usersList;
            if (_loc_2 !== param1)
            {
                this._356806342usersList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "usersList", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:AddFriendsPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._AddFriendsPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_AddFriendsPanelWatcherSetupUtil");
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

        private function _AddFriendsPanel_StandardButton1_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnOK = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.id = "btnOK";
            BindingManager.executeBindings(this, "btnOK", this.btnOK);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _AddFriendsPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Boolean
            {
                return usersList.selectedItem != null;
            }// end function
            , function (param1:Boolean) : void
            {
                null.enabled = null;
                return;
            }// end function
            , "btnOK.enabled");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnOK.label");
            result[1] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = param1;
                return;
            }// end function
            , "btnCancel.label");
            result[2] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return null != null;
            }// end function
            , function (param1:Boolean) : void
            {
                avatarPreview.visible = param1;
                return;
            }// end function
            , "avatarPreview.visible");
            result[3] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return null != null;
            }// end function
            , function (param1:Boolean) : void
            {
                namePreview.visible = param1;
                return;
            }// end function
            , "namePreview.visible");
            result[4] = binding;
            return result;
        }// end function

        private function _AddFriendsPanel_HBox1_c() : HBox
        {
            var _loc_1:* = new HBox();
            _loc_1.setStyle("right", "12");
            _loc_1.setStyle("bottom", "8");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._AddFriendsPanel_StandardButton1_i());
            _loc_1.addChild(this._AddFriendsPanel_StandardButton2_i());
            return _loc_1;
        }// end function

        public function get avatarPreview() : AvatarListItemRenderer
        {
            return this._940821457avatarPreview;
        }// end function

        private function _AddFriendsPanel_Canvas2_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.width = 127;
            _loc_1.height = 135;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.setStyle("left", "8");
            _loc_1.setStyle("bottom", "9");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._AddFriendsPanel_List1_i());
            return _loc_1;
        }// end function

        public function get enterNameLabel() : Text
        {
            return this._1545879345enterNameLabel;
        }// end function

        private function _AddFriendsPanel_Label1_i() : Label
        {
            var _loc_1:* = new Label();
            this.namePreview = _loc_1;
            _loc_1.setStyle("fontWeight", "bold");
            _loc_1.setStyle("color", 16777215);
            _loc_1.setStyle("left", "5");
            _loc_1.setStyle("right", "5");
            _loc_1.setStyle("textAlign", "center");
            _loc_1.setStyle("bottom", "10");
            _loc_1.id = "namePreview";
            BindingManager.executeBindings(this, "namePreview", this.namePreview);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function get btnOK() : StandardButton
        {
            return this._94069048btnOK;
        }// end function

        public function get namePreview() : Label
        {
            return this._145482051namePreview;
        }// end function

        public function get usersList() : List
        {
            return this._356806342usersList;
        }// end function

        private function _AddFriendsPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.usersList.selectedItem != null;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OK");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Cancel");
            _loc_1 = this.usersList.selectedItem != null;
            _loc_1 = this.usersList.selectedItem != null;
            return;
        }// end function

        public function set avatarPreview(param1:AvatarListItemRenderer) : void
        {
            var _loc_2:* = this._940821457avatarPreview;
            if (_loc_2 !== param1)
            {
                this._940821457avatarPreview = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "avatarPreview", _loc_2, param1));
            }
            return;
        }// end function

        private function _AddFriendsPanel_StandardButton2_i() : StandardButton
        {
            var _loc_1:* = new StandardButton();
            this.btnCancel = _loc_1;
            _loc_1.width = 70;
            _loc_1.height = 32;
            _loc_1.id = "btnCancel";
            BindingManager.executeBindings(this, "btnCancel", this.btnCancel);
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set enterNameLabel(param1:Text) : void
        {
            var _loc_2:* = this._1545879345enterNameLabel;
            if (_loc_2 !== param1)
            {
                this._1545879345enterNameLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "enterNameLabel", _loc_2, param1));
            }
            return;
        }// end function

        private function _AddFriendsPanel_TextInput1_i() : TextInput
        {
            var _loc_1:* = new TextInput();
            this.searchInput = _loc_1;
            _loc_1.styleName = "standardInput";
            _loc_1.height = 20;
            _loc_1.setStyle("left", "18");
            _loc_1.setStyle("right", "18");
            _loc_1.setStyle("bottom", "7");
            _loc_1.id = "searchInput";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        private function _AddFriendsPanel_List1_i() : List
        {
            var _loc_1:* = new List();
            this.usersList = _loc_1;
            _loc_1.labelField = "username";
            _loc_1.percentWidth = 100;
            _loc_1.percentHeight = 100;
            _loc_1.setStyle("selectionColor", 12623724);
            _loc_1.setStyle("rollOverColor", 9401419);
            _loc_1.setStyle("fontWeight", "normal");
            _loc_1.setStyle("backgroundAlpha", 0);
            _loc_1.setStyle("borderThickness", 0);
            _loc_1.id = "usersList";
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            return _loc_1;
        }// end function

        public function set btnOK(param1:StandardButton) : void
        {
            var _loc_2:* = this._94069048btnOK;
            if (_loc_2 !== param1)
            {
                this._94069048btnOK = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnOK", _loc_2, param1));
            }
            return;
        }// end function

        private function _AddFriendsPanel_Canvas3_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.height = 100;
            _loc_1.styleName = "detailsContentBox";
            _loc_1.setStyle("left", "141");
            _loc_1.setStyle("right", "7");
            _loc_1.setStyle("bottom", "44");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._AddFriendsPanel_AvatarListItemRenderer1_i());
            _loc_1.addChild(this._AddFriendsPanel_Label1_i());
            return _loc_1;
        }// end function

        public function set btnCancel(param1:StandardButton) : void
        {
            var _loc_2:* = this._117924854btnCancel;
            if (_loc_2 !== param1)
            {
                this._117924854btnCancel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnCancel", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnCancel() : StandardButton
        {
            return this._117924854btnCancel;
        }// end function

        public function set namePreview(param1:Label) : void
        {
            var _loc_2:* = this._145482051namePreview;
            if (_loc_2 !== param1)
            {
                this._145482051namePreview = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "namePreview", _loc_2, param1));
            }
            return;
        }// end function

        private function _AddFriendsPanel_Canvas1_c() : Canvas
        {
            var _loc_1:* = new Canvas();
            _loc_1.styleName = "detailsHeader";
            _loc_1.setStyle("left", "2");
            _loc_1.setStyle("right", "2");
            _loc_1.setStyle("top", "0");
            _loc_1.setStyle("bottom", "149");
            if (!_loc_1.document)
            {
                _loc_1.document = this;
            }
            _loc_1.addChild(this._AddFriendsPanel_Text1_i());
            _loc_1.addChild(this._AddFriendsPanel_TextInput1_i());
            return _loc_1;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
