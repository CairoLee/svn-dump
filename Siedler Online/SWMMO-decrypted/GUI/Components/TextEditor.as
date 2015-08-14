package GUI.Components
{
    import Enums.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class TextEditor extends Canvas implements IBindingClient
    {
        private var _text:String;
        private var _206185977btnSave:Button;
        private var _embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_disable_png_639665702:Class;
        private var _1880432102editPanel:Canvas;
        var _watchers:Array;
        private var _embed_mxml_____data_src_gfx_embedded_guild_checkmark_mouseover_png_232320834:Class;
        private var _embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_mouseover_png_2116628968:Class;
        private var _embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_disable_png_232772064:Class;
        private var _editMode:Boolean = false;
        private var _481854114btnDiscard:Button;
        private var _embed_mxml_____data_src_gfx_embedded_guild_checkmark_standard_png_1382152580:Class;
        private var _embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_mouseover_png_664613118:Class;
        private var _embed_mxml_____data_src_gfx_embedded_guild_checkmark_push_png_1073021234:Class;
        private var _embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_push_png_181730546:Class;
        private var _embed_mxml_____data_src_gfx_embedded_guild_checkmark_disable_png_98462628:Class;
        private var _editable:Boolean = false;
        var _bindingsBeginWithWord:Object;
        private var _205771398btnEdit:Button;
        private var _1031434259textfield:TextArea;
        private var _embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_push_png_1727123388:Class;
        private var _472396344_maxChars:int = 0;
        var _bindings:Array;
        private var _embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_standard_png_1495349248:Class;
        private var _embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_standard_png_770916986:Class;
        private var _documentDescriptor_:UIComponentDescriptor;
        var _bindingsByDestination:Object;
        private var _681210700highlight:Canvas;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function TextEditor()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"highlight", stylesFactory:function () : void
                {
                    this.backgroundColor = 16777215;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {visible:false, alpha:0.2, percentWidth:100, percentHeight:100};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"editPanel", stylesFactory:function () : void
                {
                    this.right = "0";
                    this.top = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {visible:false, width:23, childDescriptors:[new UIComponentDescriptor({type:Button, id:"btnEdit", events:{click:"__btnEdit_click", toolTipCreate:"__btnEdit_toolTipCreate"}, stylesFactory:function () : void
                    {
                        this.horizontalCenter = "0";
                        this.upSkin = _embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_standard_png_1495349248;
                        this.downSkin = _embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_push_png_181730546;
                        this.overSkin = _embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_mouseover_png_664613118;
                        this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_disable_png_232772064;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {visible:true, width:27, height:21};
                    }// end function
                    }), new UIComponentDescriptor({type:Button, id:"btnSave", events:{click:"__btnSave_click", toolTipCreate:"__btnSave_toolTipCreate"}, stylesFactory:function () : void
                    {
                        this.horizontalCenter = "0";
                        this.upSkin = _embed_mxml_____data_src_gfx_embedded_guild_checkmark_standard_png_1382152580;
                        this.downSkin = _embed_mxml_____data_src_gfx_embedded_guild_checkmark_push_png_1073021234;
                        this.overSkin = _embed_mxml_____data_src_gfx_embedded_guild_checkmark_mouseover_png_232320834;
                        this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_guild_checkmark_disable_png_98462628;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, width:27, height:21};
                    }// end function
                    }), new UIComponentDescriptor({type:Button, id:"btnDiscard", events:{click:"__btnDiscard_click", toolTipCreate:"__btnDiscard_toolTipCreate"}, stylesFactory:function () : void
                    {
                        null.horizontalCenter = this;
                        this.top = "23";
                        this.upSkin = _embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_standard_png_770916986;
                        this.downSkin = _embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_push_png_1727123388;
                        this.overSkin = _embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_mouseover_png_2116628968;
                        this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_disable_png_639665702;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:false, width:27, height:21};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    null.left = this;
                    this.top = "5";
                    this.right = "25";
                    this.bottom = "3";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {horizontalScrollPolicy:"off", verticalScrollPolicy:"auto", childDescriptors:[new UIComponentDescriptor({type:TextArea, id:"textfield", stylesFactory:function () : void
                    {
                        this.paddingRight = 10;
                        this.backgroundAlpha = 0;
                        this.borderThickness = 0;
                        this.focusAlpha = 0;
                        this.color = 16777215;
                        this.fontWeight = "normal";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {restrict:"^\\\\", percentWidth:100, percentHeight:100, editable:false, selectable:false};
                    }// end function
                    })]};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_guild_checkmark_disable_png_98462628 = TextEditor__embed_mxml_____data_src_gfx_embedded_guild_checkmark_disable_png_98462628;
            this._embed_mxml_____data_src_gfx_embedded_guild_checkmark_mouseover_png_232320834 = TextEditor__embed_mxml_____data_src_gfx_embedded_guild_checkmark_mouseover_png_232320834;
            this._embed_mxml_____data_src_gfx_embedded_guild_checkmark_push_png_1073021234 = TextEditor__embed_mxml_____data_src_gfx_embedded_guild_checkmark_push_png_1073021234;
            this._embed_mxml_____data_src_gfx_embedded_guild_checkmark_standard_png_1382152580 = TextEditor__embed_mxml_____data_src_gfx_embedded_guild_checkmark_standard_png_1382152580;
            this._embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_disable_png_232772064 = TextEditor__embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_disable_png_232772064;
            this._embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_mouseover_png_664613118 = TextEditor__embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_mouseover_png_664613118;
            this._embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_push_png_181730546 = TextEditor__embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_push_png_181730546;
            this._embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_standard_png_1495349248 = TextEditor__embed_mxml_____data_src_gfx_embedded_guild_icon_pencil_standard_png_1495349248;
            this._embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_disable_png_639665702 = TextEditor__embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_disable_png_639665702;
            this._embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_mouseover_png_2116628968 = TextEditor__embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_mouseover_png_2116628968;
            this._embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_push_png_1727123388 = TextEditor__embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_push_png_1727123388;
            this._embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_standard_png_770916986 = TextEditor__embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_standard_png_770916986;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            return;
        }// end function

        public function set btnSave(param1:Button) : void
        {
            var _loc_2:* = this._206185977btnSave;
            if (_loc_2 !== param1)
            {
                this._206185977btnSave = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnSave", _loc_2, param1));
            }
            return;
        }// end function

        public function set textfield(param1:TextArea) : void
        {
            var _loc_2:* = this._1031434259textfield;
            if (_loc_2 !== param1)
            {
                this._1031434259textfield = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "textfield", _loc_2, param1));
            }
            return;
        }// end function

        public function get highlight() : Canvas
        {
            return this._681210700highlight;
        }// end function

        private function _TextEditor_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildEdit");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = null;
                return;
            }// end function
            , "btnEdit.toolTip");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildSave");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnSave.toolTip = param1;
                return;
            }// end function
            , "btnSave.toolTip");
            result[1] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildDiscard");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = param1;
                return;
            }// end function
            , "btnDiscard.toolTip");
            result[2] = binding;
            binding = new Binding(this, function () : int
            {
                return _maxChars;
            }// end function
            , function (param1:int) : void
            {
                null.maxChars = null;
                return;
            }// end function
            , "textfield.maxChars");
            result[3] = binding;
            return result;
        }// end function

        private function edit() : void
        {
            this.editMode = true;
            return;
        }// end function

        public function __btnDiscard_click(event:MouseEvent) : void
        {
            this.discard();
            return;
        }// end function

        public function get btnEdit() : Button
        {
            return this._205771398btnEdit;
        }// end function

        override public function initialize() : void
        {
            var target:TextEditor;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._TextEditor_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_TextEditorWatcherSetupUtil");
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

        public function set btnEdit(param1:Button) : void
        {
            var _loc_2:* = this._205771398btnEdit;
            if (_loc_2 !== param1)
            {
                this._205771398btnEdit = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnEdit", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnSave_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function set editMode(param1:Boolean) : void
        {
            this._editMode = param1;
            this.btnEdit.visible = !param1;
            this.btnSave.visible = param1;
            this.btnDiscard.visible = param1;
            this.highlight.visible = param1;
            this.textfield.editable = param1;
            this.textfield.selectable = param1;
            this.textfield.setFocus();
            this.textfield.selectionBeginIndex = 0;
            this.textfield.selectionEndIndex = param1 ? (this.textfield.text.length) : (0);
            return;
        }// end function

        private function discard() : void
        {
            if (this.textfield.text == this._text)
            {
                this.editMode = false;
                return;
            }
            CustomAlert.show("ConfirmDiscardChanges", "ConfirmDiscardChanges", Alert.OK | Alert.CANCEL, null, this.discardChanges);
            return;
        }// end function

        public function get btnDiscard() : Button
        {
            return this._481854114btnDiscard;
        }// end function

        public function get editPanel() : Canvas
        {
            return this._1880432102editPanel;
        }// end function

        public function __btnEdit_click(event:MouseEvent) : void
        {
            this.edit();
            return;
        }// end function

        public function set maxChars(param1:int) : void
        {
            this._maxChars = param1;
            return;
        }// end function

        public function get text() : String
        {
            return this._text;
        }// end function

        public function __btnDiscard_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        private function discardChanges(event:CloseEvent) : void
        {
            if (event.detail != Alert.OK)
            {
                return;
            }
            this.textfield.text = this._text;
            this.editMode = false;
            return;
        }// end function

        private function get _maxChars() : int
        {
            return this._472396344_maxChars;
        }// end function

        public function set editable(param1:Boolean) : void
        {
            this._editable = param1;
            this.editPanel.visible = param1;
            return;
        }// end function

        public function set btnDiscard(param1:Button) : void
        {
            var _loc_2:* = this._481854114btnDiscard;
            if (_loc_2 !== param1)
            {
                this._481854114btnDiscard = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnDiscard", _loc_2, param1));
            }
            return;
        }// end function

        public function set editPanel(param1:Canvas) : void
        {
            var _loc_2:* = this._1880432102editPanel;
            if (_loc_2 !== param1)
            {
                this._1880432102editPanel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "editPanel", _loc_2, param1));
            }
            return;
        }// end function

        public function get maxChars() : int
        {
            return this._maxChars;
        }// end function

        private function _TextEditor_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildEdit");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildSave");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "GuildDiscard");
            _loc_1 = this._maxChars;
            return;
        }// end function

        public function set text(param1:String) : void
        {
            this._text = param1;
            this.editMode = false;
            this.textfield.text = this._text;
            return;
        }// end function

        public function __btnSave_click(event:MouseEvent) : void
        {
            this.save();
            return;
        }// end function

        public function get editable() : Boolean
        {
            return this._editable;
        }// end function

        public function __btnEdit_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set highlight(param1:Canvas) : void
        {
            var _loc_2:* = this._681210700highlight;
            if (_loc_2 !== param1)
            {
                this._681210700highlight = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "highlight", _loc_2, param1));
            }
            return;
        }// end function

        private function set _maxChars(param1:int) : void
        {
            var _loc_2:* = this._472396344_maxChars;
            if (_loc_2 !== param1)
            {
                this._472396344_maxChars = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "_maxChars", _loc_2, param1));
            }
            return;
        }// end function

        public function get textfield() : TextArea
        {
            return this._1031434259textfield;
        }// end function

        public function get btnSave() : Button
        {
            return this._206185977btnSave;
        }// end function

        private function save() : void
        {
            this.editMode = false;
            if (this._text == this.textfield.text)
            {
                return;
            }
            this._text = this.textfield.text;
            dispatchEvent(new Event("SaveChanges"));
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
