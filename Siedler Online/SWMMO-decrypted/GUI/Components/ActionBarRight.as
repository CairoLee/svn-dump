package GUI.Components
{
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class ActionBarRight extends ButtonBar implements IBindingClient
    {
        private var _1731615545btnActionBar06:Button;
        var _bindingsByDestination:Object;
        private var _1731615543btnActionBar08:Button;
        private var _1731615544btnActionBar07:Button;
        var _watchers:Array;
        private var _1731615542btnActionBar09:Button;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        var _bindingsBeginWithWord:Object;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function ActionBarRight()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:ButtonBar, propertiesFactory:function () : Object
            {
                return {childDescriptors:[new UIComponentDescriptor({type:Button, id:"btnActionBar06", events:{toolTipCreate:"__btnActionBar06_toolTipCreate", toolTipShow:"__btnActionBar06_toolTipShow"}, propertiesFactory:function () : Object
                {
                    return {null:66, height:86};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnActionBar07", events:{toolTipCreate:"__btnActionBar07_toolTipCreate", toolTipShow:"__btnActionBar07_toolTipShow"}, propertiesFactory:function () : Object
                {
                    return {width:66, height:86};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnActionBar08", events:{toolTipCreate:"__btnActionBar08_toolTipCreate", toolTipShow:"__btnActionBar08_toolTipShow"}, propertiesFactory:function () : Object
                {
                    return {null:66, height:86};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnActionBar09", events:{toolTipCreate:"__btnActionBar09_toolTipCreate", toolTipShow:"__btnActionBar09_toolTipShow"}, propertiesFactory:function () : Object
                {
                    return {null:66, height:86};
                }// end function
                })]};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                this.bottom = "0";
                return;
            }// end function
            ;
            this.styleName = "actionBarRight";
            return;
        }// end function

        public function get btnActionBar06() : Button
        {
            return this._1731615545btnActionBar06;
        }// end function

        public function get btnActionBar07() : Button
        {
            return this._1731615544btnActionBar07;
        }// end function

        public function get btnActionBar08() : Button
        {
            return this._1731615543btnActionBar08;
        }// end function

        public function set btnActionBar06(param1:Button) : void
        {
            var _loc_2:* = this._1731615545btnActionBar06;
            if (_loc_2 !== param1)
            {
                this._1731615545btnActionBar06 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnActionBar06", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:ActionBarRight;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._ActionBarRight_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ActionBarRightWatcherSetupUtil");
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

        public function get btnActionBar09() : Button
        {
            return this._1731615542btnActionBar09;
        }// end function

        public function set btnActionBar08(param1:Button) : void
        {
            var _loc_2:* = this._1731615543btnActionBar08;
            if (_loc_2 !== param1)
            {
                this._1731615543btnActionBar08 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnActionBar08", _loc_2, param1));
            }
            return;
        }// end function

        private function _ActionBarRight_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = global.ui.mCurrentPlayer.mIsPlayerZone;
            _loc_1 = gAssetManager.GetClass("ActionBarIcon06");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon06Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon06Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon06Deactivated");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ComingSoon");
            _loc_1 = global.ui.mCurrentPlayer.mIsPlayerZone;
            _loc_1 = gAssetManager.GetClass("ActionBarIcon07");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon07Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon07Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon07Deactivated");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "Guilds");
            _loc_1 = global.ui.mCurrentPlayer.mIsPlayerZone;
            _loc_1 = gAssetManager.GetClass("ActionBarIcon08");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon08Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon08Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon08Deactivated");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "ViewMailWindow");
            _loc_1 = global.ui.mCurrentPlayer.mIsPlayerZone && !global.ui.mCurrentPlayer.mIsAdventureZone;
            _loc_1 = gAssetManager.GetClass("ActionBarIcon09");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon09Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon09Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon09Deactivated");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "PayShop");
            return;
        }// end function

        public function set btnActionBar07(param1:Button) : void
        {
            var _loc_2:* = this._1731615544btnActionBar07;
            if (_loc_2 !== param1)
            {
                this._1731615544btnActionBar07 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnActionBar07", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnActionBar09(param1:Button) : void
        {
            var _loc_2:* = this._1731615542btnActionBar09;
            if (_loc_2 !== param1)
            {
                this._1731615542btnActionBar09 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnActionBar09", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnActionBar06_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function __btnActionBar06_toolTipShow(event:ToolTipEvent) : void
        {
            cToolTipUtil.positionActionBarTip(event);
            return;
        }// end function

        public function __btnActionBar07_toolTipShow(event:ToolTipEvent) : void
        {
            cToolTipUtil.positionActionBarTip(event);
            return;
        }// end function

        public function __btnActionBar08_toolTipShow(event:ToolTipEvent) : void
        {
            cToolTipUtil.positionActionBarTip(event);
            return;
        }// end function

        public function __btnActionBar09_toolTipShow(event:ToolTipEvent) : void
        {
            cToolTipUtil.positionActionBarTip(event);
            return;
        }// end function

        private function _ActionBarRight_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Boolean
            {
                return null.ui.mCurrentPlayer.mIsPlayerZone;
            }// end function
            , function (param1:Boolean) : void
            {
                null.enabled = param1;
                return;
            }// end function
            , "btnActionBar06.enabled");
            result[0] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnActionBar06.upSkin");
            result[1] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon06Highlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnActionBar06.downSkin");
            result[2] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon06Highlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnActionBar06.overSkin");
            result[3] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ActionBarIcon06Deactivated");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnActionBar06.disabledSkin");
            result[4] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "ComingSoon");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = param1;
                return;
            }// end function
            , "btnActionBar06.toolTip");
            result[5] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return null.mCurrentPlayer.mIsPlayerZone;
            }// end function
            , function (param1:Boolean) : void
            {
                btnActionBar07.enabled = param1;
                return;
            }// end function
            , "btnActionBar07.enabled");
            result[6] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ActionBarIcon07");
            }// end function
            , function (param1:Class) : void
            {
                btnActionBar07.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnActionBar07.upSkin");
            result[7] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ActionBarIcon07Highlight");
            }// end function
            , function (param1:Class) : void
            {
                btnActionBar07.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnActionBar07.downSkin");
            result[8] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon07Highlight");
            }// end function
            , function (param1:Class) : void
            {
                btnActionBar07.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnActionBar07.overSkin");
            result[9] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ActionBarIcon07Deactivated");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnActionBar07.disabledSkin");
            result[10] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "Guilds");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = param1;
                return;
            }// end function
            , "btnActionBar07.toolTip");
            result[11] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return null.ui.mCurrentPlayer.mIsPlayerZone;
            }// end function
            , function (param1:Boolean) : void
            {
                null.enabled = null;
                return;
            }// end function
            , "btnActionBar08.enabled");
            result[12] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon08");
            }// end function
            , function (param1:Class) : void
            {
                btnActionBar08.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnActionBar08.upSkin");
            result[13] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ActionBarIcon08Highlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnActionBar08.downSkin");
            result[14] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon08Highlight");
            }// end function
            , function (param1:Class) : void
            {
                btnActionBar08.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnActionBar08.overSkin");
            result[15] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnActionBar08.disabledSkin");
            result[16] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "ViewMailWindow");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = param1;
                return;
            }// end function
            , "btnActionBar08.toolTip");
            result[17] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return global.ui.mCurrentPlayer.mIsPlayerZone && !global.ui.mCurrentPlayer.mIsAdventureZone;
            }// end function
            , function (param1:Boolean) : void
            {
                null.enabled = null;
                return;
            }// end function
            , "btnActionBar09.enabled");
            result[18] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon09");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnActionBar09.upSkin");
            result[19] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnActionBar09.downSkin");
            result[20] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnActionBar09.overSkin");
            result[21] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon09Deactivated");
            }// end function
            , function (param1:Class) : void
            {
                btnActionBar09.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnActionBar09.disabledSkin");
            result[22] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "PayShop");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = param1;
                return;
            }// end function
            , "btnActionBar09.toolTip");
            result[23] = binding;
            return result;
        }// end function

        public function __btnActionBar07_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function __btnActionBar08_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function __btnActionBar09_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
