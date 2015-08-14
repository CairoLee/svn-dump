package GUI.Components
{
    import Enums.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;

    public class OptionsPanel extends Canvas implements IBindingClient
    {
        private var _embed_mxml_____data_src_gfx_embedded_options_menu_open_standard_png_9531772:Class;
        private var _embed_mxml_____data_src_gfx_embedded_options_music_off_mouseover_png_865045412:Class;
        private var _1250687443btnSupport:OptionsMenuButton;
        private var _388320006btnLogout:Button;
        private var _embed_mxml_____data_src_gfx_embedded_options_sound_off_mouseover_png_1066382256:Class;
        var _watchers:Array;
        private var _embed_mxml_____data_src_gfx_embedded_options_menu_inactive_png_820276500:Class;
        private var _1289167206expand:Resize;
        private var _embed_mxml_____data_src_gfx_embedded_options_music_inactive_png_1162099678:Class;
        private var _embed_mxml_____data_src_gfx_embedded_options_menu_close_standard_png_1062171582:Class;
        private var _117897377btnCamera:Button;
        private var _embed_mxml_____data_src_gfx_embedded_options_login_inactive_png_1706308558:Class;
        private var _632085587collapse:Resize;
        private var _361683485btnExpandCollapse:Button;
        private var _embed_mxml_____data_src_gfx_embedded_options_music_mouseover_png_1118762660:Class;
        private var _embed_mxml_____data_src_gfx_embedded_options_menu_open_mouseover_png_995095486:Class;
        private var _embed_mxml_____data_src_gfx_embedded_options_sound_off_png_191985252:Class;
        var _bindingsBeginWithWord:Object;
        private var _embed_mxml_____data_src_gfx_embedded_options_sound_standard_png_1696084878:Class;
        private var _2085206053btnForum:OptionsMenuButton;
        private var _embed_mxml_____data_src_gfx_embedded_options_music_off_png_863646816:Class;
        var _bindingsByDestination:Object;
        private var _embed_mxml_____data_src_gfx_embedded_options_camera_inactive_png_2058188480:Class;
        private var _embed_mxml_____data_src_gfx_embedded_options_camera_standard_png_1085206564:Class;
        private var _embed_mxml_____data_src_gfx_embedded_options_sound_inactive_png_2057618674:Class;
        private var _embed_mxml_____data_src_gfx_embedded_options_sound_mouseover_png_2142030000:Class;
        private var _embed_mxml_____data_src_gfx_embedded_options_logout_mouseover_png_172655008:Class;
        private var _343748447btnToggleLoops:Button;
        private var _embed_mxml_____data_src_gfx_embedded_options_logout_standard_png_1071582050:Class;
        private var _1740871186btnToggleEffects:Button;
        private var _embed_mxml_____data_src_gfx_embedded_options_menu_close_mouseover_png_393516028:Class;
        private var _embed_mxml_____data_src_gfx_embedded_options_music_standard_png_1167199038:Class;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _embed_mxml_____data_src_gfx_embedded_options_camera_mouseover_png_172662094:Class;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function OptionsPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {width:116, height:48, childDescriptors:[new UIComponentDescriptor({type:Canvas, stylesFactory:function () : void
                {
                    null.left = this;
                    this.top = "5";
                    this.bottom = "22";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {childDescriptors:[new UIComponentDescriptor({type:Button, id:"btnToggleLoops", events:{toolTipCreate:"__btnToggleLoops_toolTipCreate"}, stylesFactory:function () : void
                    {
                        this.left = "0";
                        this.bottom = "60";
                        this.upSkin = _embed_mxml_____data_src_gfx_embedded_options_music_standard_png_1167199038;
                        this.downSkin = _embed_mxml_____data_src_gfx_embedded_options_music_mouseover_png_1118762660;
                        this.overSkin = _embed_mxml_____data_src_gfx_embedded_options_music_mouseover_png_1118762660;
                        this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_options_music_inactive_png_1162099678;
                        this.selectedUpSkin = _embed_mxml_____data_src_gfx_embedded_options_music_off_png_863646816;
                        this.selectedDownSkin = _embed_mxml_____data_src_gfx_embedded_options_music_off_mouseover_png_865045412;
                        this.selectedOverSkin = _embed_mxml_____data_src_gfx_embedded_options_music_off_mouseover_png_865045412;
                        this.selectedDisabledSkin = _embed_mxml_____data_src_gfx_embedded_options_music_inactive_png_1162099678;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {toggle:true, width:30, height:31};
                    }// end function
                    }), new UIComponentDescriptor({type:Button, id:"btnToggleEffects", events:{toolTipCreate:"__btnToggleEffects_toolTipCreate"}, stylesFactory:function () : void
                    {
                        null.left = this;
                        this.bottom = "60";
                        this.upSkin = _embed_mxml_____data_src_gfx_embedded_options_sound_standard_png_1696084878;
                        this.downSkin = _embed_mxml_____data_src_gfx_embedded_options_sound_mouseover_png_2142030000;
                        this.overSkin = _embed_mxml_____data_src_gfx_embedded_options_sound_mouseover_png_2142030000;
                        this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_options_sound_inactive_png_2057618674;
                        this.selectedUpSkin = _embed_mxml_____data_src_gfx_embedded_options_sound_off_png_191985252;
                        this.selectedDownSkin = _embed_mxml_____data_src_gfx_embedded_options_sound_off_mouseover_png_1066382256;
                        this.selectedOverSkin = _embed_mxml_____data_src_gfx_embedded_options_sound_off_mouseover_png_1066382256;
                        this.selectedDisabledSkin = _embed_mxml_____data_src_gfx_embedded_options_sound_inactive_png_2057618674;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:true, width:30, height:31};
                    }// end function
                    }), new UIComponentDescriptor({type:Button, id:"btnCamera", events:{toolTipCreate:"__btnCamera_toolTipCreate"}, stylesFactory:function () : void
                    {
                        this.left = "58";
                        this.bottom = "60";
                        this.upSkin = _embed_mxml_____data_src_gfx_embedded_options_camera_standard_png_1085206564;
                        this.downSkin = _embed_mxml_____data_src_gfx_embedded_options_camera_mouseover_png_172662094;
                        this.overSkin = _embed_mxml_____data_src_gfx_embedded_options_camera_mouseover_png_172662094;
                        this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_options_camera_inactive_png_2058188480;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, height:31};
                    }// end function
                    }), new UIComponentDescriptor({type:OptionsMenuButton, id:"btnSupport", stylesFactory:function () : void
                    {
                        this.left = "0";
                        this.bottom = "40";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:OptionsMenuButton, id:"btnForum", stylesFactory:function () : void
                    {
                        null.left = this;
                        this.bottom = "20";
                        return;
                    }// end function
                    }), new UIComponentDescriptor({type:Button, id:"btnExpandCollapse", events:{toolTipCreate:"__btnExpandCollapse_toolTipCreate"}, stylesFactory:function () : void
                    {
                        this.bottom = "0";
                        this.left = "0";
                        this.upSkin = _embed_mxml_____data_src_gfx_embedded_options_menu_open_standard_png_9531772;
                        this.downSkin = _embed_mxml_____data_src_gfx_embedded_options_menu_open_mouseover_png_995095486;
                        this.overSkin = _embed_mxml_____data_src_gfx_embedded_options_menu_open_mouseover_png_995095486;
                        this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_options_menu_inactive_png_820276500;
                        this.selectedUpSkin = _embed_mxml_____data_src_gfx_embedded_options_menu_close_standard_png_1062171582;
                        this.selectedDownSkin = _embed_mxml_____data_src_gfx_embedded_options_menu_close_mouseover_png_393516028;
                        this.selectedOverSkin = _embed_mxml_____data_src_gfx_embedded_options_menu_close_mouseover_png_393516028;
                        this.selectedDisabledSkin = _embed_mxml_____data_src_gfx_embedded_options_menu_inactive_png_820276500;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, width:44, height:21};
                    }// end function
                    }), new UIComponentDescriptor({type:Button, id:"btnLogout", events:{toolTipCreate:"__btnLogout_toolTipCreate"}, stylesFactory:function () : void
                    {
                        this.bottom = "0";
                        this.left = "44";
                        this.upSkin = _embed_mxml_____data_src_gfx_embedded_options_logout_standard_png_1071582050;
                        this.downSkin = _embed_mxml_____data_src_gfx_embedded_options_logout_mouseover_png_172655008;
                        this.overSkin = _embed_mxml_____data_src_gfx_embedded_options_logout_mouseover_png_172655008;
                        this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_options_login_inactive_png_1706308558;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {null:null, height:21};
                    }// end function
                    })]};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_options_camera_inactive_png_2058188480 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_camera_inactive_png_2058188480;
            this._embed_mxml_____data_src_gfx_embedded_options_camera_mouseover_png_172662094 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_camera_mouseover_png_172662094;
            this._embed_mxml_____data_src_gfx_embedded_options_camera_standard_png_1085206564 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_camera_standard_png_1085206564;
            this._embed_mxml_____data_src_gfx_embedded_options_login_inactive_png_1706308558 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_login_inactive_png_1706308558;
            this._embed_mxml_____data_src_gfx_embedded_options_logout_mouseover_png_172655008 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_logout_mouseover_png_172655008;
            this._embed_mxml_____data_src_gfx_embedded_options_logout_standard_png_1071582050 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_logout_standard_png_1071582050;
            this._embed_mxml_____data_src_gfx_embedded_options_menu_close_mouseover_png_393516028 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_menu_close_mouseover_png_393516028;
            this._embed_mxml_____data_src_gfx_embedded_options_menu_close_standard_png_1062171582 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_menu_close_standard_png_1062171582;
            this._embed_mxml_____data_src_gfx_embedded_options_menu_inactive_png_820276500 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_menu_inactive_png_820276500;
            this._embed_mxml_____data_src_gfx_embedded_options_menu_open_mouseover_png_995095486 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_menu_open_mouseover_png_995095486;
            this._embed_mxml_____data_src_gfx_embedded_options_menu_open_standard_png_9531772 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_menu_open_standard_png_9531772;
            this._embed_mxml_____data_src_gfx_embedded_options_music_inactive_png_1162099678 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_music_inactive_png_1162099678;
            this._embed_mxml_____data_src_gfx_embedded_options_music_mouseover_png_1118762660 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_music_mouseover_png_1118762660;
            this._embed_mxml_____data_src_gfx_embedded_options_music_off_mouseover_png_865045412 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_music_off_mouseover_png_865045412;
            this._embed_mxml_____data_src_gfx_embedded_options_music_off_png_863646816 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_music_off_png_863646816;
            this._embed_mxml_____data_src_gfx_embedded_options_music_standard_png_1167199038 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_music_standard_png_1167199038;
            this._embed_mxml_____data_src_gfx_embedded_options_sound_inactive_png_2057618674 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_sound_inactive_png_2057618674;
            this._embed_mxml_____data_src_gfx_embedded_options_sound_mouseover_png_2142030000 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_sound_mouseover_png_2142030000;
            this._embed_mxml_____data_src_gfx_embedded_options_sound_off_mouseover_png_1066382256 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_sound_off_mouseover_png_1066382256;
            this._embed_mxml_____data_src_gfx_embedded_options_sound_off_png_191985252 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_sound_off_png_191985252;
            this._embed_mxml_____data_src_gfx_embedded_options_sound_standard_png_1696084878 = OptionsPanel__embed_mxml_____data_src_gfx_embedded_options_sound_standard_png_1696084878;
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this.horizontalScrollPolicy = "off";
            this.verticalScrollPolicy = "off";
            this.styleName = "optionsPanel";
            this.cacheAsBitmap = true;
            this.width = 116;
            this.height = 48;
            this._OptionsPanel_Resize2_i();
            this._OptionsPanel_Resize1_i();
            return;
        }// end function

        public function __btnExpandCollapse_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get btnLogout() : Button
        {
            return this._388320006btnLogout;
        }// end function

        private function _OptionsPanel_Resize2_i() : Resize
        {
            var _loc_1:* = new Resize();
            this.collapse = _loc_1;
            _loc_1.heightFrom = 117;
            _loc_1.heightTo = 48;
            BindingManager.executeBindings(this, "collapse", this.collapse);
            return _loc_1;
        }// end function

        public function get btnToggleEffects() : Button
        {
            return this._1740871186btnToggleEffects;
        }// end function

        private function _OptionsPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this;
            _loc_1 = this;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ToggleSoundLoop");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ToggleSoundEffects");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ToggleCameraPanel");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Support");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Forum");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "OptionsExpandCollapse");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Logout");
            return;
        }// end function

        override public function initialize() : void
        {
            var target:OptionsPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._OptionsPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_OptionsPanelWatcherSetupUtil");
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

        public function set btnLogout(param1:Button) : void
        {
            var _loc_2:* = this._388320006btnLogout;
            if (_loc_2 !== param1)
            {
                this._388320006btnLogout = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnLogout", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnForum() : OptionsMenuButton
        {
            return this._2085206053btnForum;
        }// end function

        public function set btnSupport(param1:OptionsMenuButton) : void
        {
            var _loc_2:* = this._1250687443btnSupport;
            if (_loc_2 !== param1)
            {
                this._1250687443btnSupport = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnSupport", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnCamera() : Button
        {
            return this._117897377btnCamera;
        }// end function

        public function get expand() : Resize
        {
            return this._1289167206expand;
        }// end function

        public function set btnToggleEffects(param1:Button) : void
        {
            var _loc_2:* = this._1740871186btnToggleEffects;
            if (_loc_2 !== param1)
            {
                this._1740871186btnToggleEffects = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnToggleEffects", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnToggleEffects_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set btnToggleLoops(param1:Button) : void
        {
            var _loc_2:* = this._343748447btnToggleLoops;
            if (_loc_2 !== param1)
            {
                this._343748447btnToggleLoops = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnToggleLoops", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnToggleLoops_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function __btnCamera_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function set expand(param1:Resize) : void
        {
            var _loc_2:* = this._1289167206expand;
            if (_loc_2 !== param1)
            {
                this._1289167206expand = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "expand", _loc_2, param1));
            }
            return;
        }// end function

        public function get collapse() : Resize
        {
            return this._632085587collapse;
        }// end function

        public function set btnCamera(param1:Button) : void
        {
            var _loc_2:* = this._117897377btnCamera;
            if (_loc_2 !== param1)
            {
                this._117897377btnCamera = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnCamera", _loc_2, param1));
            }
            return;
        }// end function

        private function _OptionsPanel_Resize1_i() : Resize
        {
            var _loc_1:* = new Resize();
            this.expand = _loc_1;
            _loc_1.heightFrom = 48;
            _loc_1.heightTo = 117;
            BindingManager.executeBindings(this, "expand", this.expand);
            return _loc_1;
        }// end function

        public function get btnSupport() : OptionsMenuButton
        {
            return this._1250687443btnSupport;
        }// end function

        public function set btnExpandCollapse(param1:Button) : void
        {
            var _loc_2:* = this._361683485btnExpandCollapse;
            if (_loc_2 !== param1)
            {
                this._361683485btnExpandCollapse = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnExpandCollapse", _loc_2, param1));
            }
            return;
        }// end function

        public function get btnToggleLoops() : Button
        {
            return this._343748447btnToggleLoops;
        }// end function

        private function _OptionsPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return this;
            }// end function
            , function (param1:Object) : void
            {
                expand.target = param1;
                return;
            }// end function
            , "expand.target");
            result[0] = binding;
            binding = new Binding(this, function () : Object
            {
                return this;
            }// end function
            , function (param1:Object) : void
            {
                null.target = null;
                return;
            }// end function
            , "collapse.target");
            result[1] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ToggleSoundLoop");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnToggleLoops.toolTip = param1;
                return;
            }// end function
            , "btnToggleLoops.toolTip");
            result[2] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ToggleSoundEffects");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = param1;
                return;
            }// end function
            , "btnToggleEffects.toolTip");
            result[3] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "ToggleCameraPanel");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = null;
                return;
            }// end function
            , "btnCamera.toolTip");
            result[4] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Support");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnSupport.label");
            result[5] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Forum");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "btnForum.label");
            result[6] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "OptionsExpandCollapse");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = null;
                return;
            }// end function
            , "btnExpandCollapse.toolTip");
            result[7] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "Logout");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = param1;
                return;
            }// end function
            , "btnLogout.toolTip");
            result[8] = binding;
            return result;
        }// end function

        public function __btnLogout_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function get btnExpandCollapse() : Button
        {
            return this._361683485btnExpandCollapse;
        }// end function

        public function set collapse(param1:Resize) : void
        {
            var _loc_2:* = this._632085587collapse;
            if (_loc_2 !== param1)
            {
                this._632085587collapse = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "collapse", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnForum(param1:OptionsMenuButton) : void
        {
            var _loc_2:* = this._2085206053btnForum;
            if (_loc_2 !== param1)
            {
                this._2085206053btnForum = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnForum", _loc_2, param1));
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
