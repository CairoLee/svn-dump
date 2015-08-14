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

    public class ActionBarLeft extends ButtonBar implements IBindingClient
    {
        var _bindingsBeginWithWord:Object;
        private var _1731615548btnActionBar03:Button;
        var _bindingsByDestination:Object;
        private var _1731615549btnActionBar02:Button;
        var _watchers:Array;
        private var _1731615550btnActionBar01:Button;
        private var _1731615547btnActionBar04:Button;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function ActionBarLeft()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:ButtonBar, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:Button, id:"btnActionBar01", events:{toolTipCreate:"__btnActionBar01_toolTipCreate", toolTipShow:"__btnActionBar01_toolTipShow"}, propertiesFactory:function () : Object
                {
                    return {null:null, height:86};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnActionBar02", events:{toolTipCreate:"__btnActionBar02_toolTipCreate", toolTipShow:"__btnActionBar02_toolTipShow"}, propertiesFactory:function () : Object
                {
                    return {width:66, height:86};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnActionBar03", events:{toolTipCreate:"__btnActionBar03_toolTipCreate", toolTipShow:"__btnActionBar03_toolTipShow"}, propertiesFactory:function () : Object
                {
                    return {width:66, height:86};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnActionBar04", events:{toolTipCreate:"__btnActionBar04_toolTipCreate", toolTipShow:"__btnActionBar04_toolTipShow"}, propertiesFactory:function () : Object
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
            this.styleName = "actionBarLeft";
            return;
        }// end function

        public function get btnActionBar01() : Button
        {
            return this._1731615550btnActionBar01;
        }// end function

        public function get btnActionBar02() : Button
        {
            return this._1731615549btnActionBar02;
        }// end function

        public function set btnActionBar03(param1:Button) : void
        {
            var _loc_2:* = this._1731615548btnActionBar03;
            if (_loc_2 !== param1)
            {
                this._1731615548btnActionBar03 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnActionBar03", _loc_2, param1));
            }
            return;
        }// end function

        public function set btnActionBar01(param1:Button) : void
        {
            var _loc_2:* = this._1731615550btnActionBar01;
            if (_loc_2 !== param1)
            {
                this._1731615550btnActionBar01 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnActionBar01", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:ActionBarLeft;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._ActionBarLeft_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ActionBarLeftWatcherSetupUtil");
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

        public function set btnActionBar04(param1:Button) : void
        {
            var _loc_2:* = this._1731615547btnActionBar04;
            if (_loc_2 !== param1)
            {
                this._1731615547btnActionBar04 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnActionBar04", _loc_2, param1));
            }
            return;
        }// end function

        private function _ActionBarLeft_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = global.ui.mCurrentPlayer.mIsPlayerZone && !global.ui.mCurrentPlayer.mIsAdventureZone;
            _loc_1 = gAssetManager.GetClass("ActionBarIcon01");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon01Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon01Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon01Deactivated");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CL01Buildings");
            _loc_1 = global.ui.mCurrentPlayer.mIsPlayerZone && !global.ui.mCurrentPlayer.mIsAdventureZone;
            _loc_1 = gAssetManager.GetClass("ActionBarIcon02");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon02Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon02Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon02Deactivated");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CL2Buildings");
            _loc_1 = global.ui.mCurrentPlayer.mIsPlayerZone && !global.ui.mCurrentPlayer.mIsAdventureZone;
            _loc_1 = gAssetManager.GetClass("ActionBarIcon03");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon03Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon03Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon03Deactivated");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CL3Buildings");
            _loc_1 = global.ui.mCurrentPlayer.mIsPlayerZone && !global.ui.mCurrentPlayer.mIsAdventureZone;
            _loc_1 = gAssetManager.GetClass("ActionBarIcon04");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon04Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon04Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon04Deactivated");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CLSBuildings");
            return;
        }// end function

        private function _ActionBarLeft_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Boolean
            {
                return null.mCurrentPlayer.mIsPlayerZone && !global.ui.mCurrentPlayer.mIsAdventureZone;
            }// end function
            , function (param1:Boolean) : void
            {
                null.enabled = param1;
                return;
            }// end function
            , "btnActionBar01.enabled");
            result[0] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon01");
            }// end function
            , function (param1:Class) : void
            {
                btnActionBar01.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnActionBar01.upSkin");
            result[1] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon01Highlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnActionBar01.downSkin");
            result[2] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon01Highlight");
            }// end function
            , function (param1:Class) : void
            {
                btnActionBar01.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnActionBar01.overSkin");
            result[3] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ActionBarIcon01Deactivated");
            }// end function
            , function (param1:Class) : void
            {
                btnActionBar01.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnActionBar01.disabledSkin");
            result[4] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "CL01Buildings");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = param1;
                return;
            }// end function
            , "btnActionBar01.toolTip");
            result[5] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return null.ui.mCurrentPlayer.mIsPlayerZone && !global.ui.mCurrentPlayer.mIsAdventureZone;
            }// end function
            , function (param1:Boolean) : void
            {
                btnActionBar02.enabled = param1;
                return;
            }// end function
            , "btnActionBar02.enabled");
            result[6] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ActionBarIcon02");
            }// end function
            , function (param1:Class) : void
            {
                btnActionBar02.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnActionBar02.upSkin");
            result[7] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon02Highlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnActionBar02.downSkin");
            result[8] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon02Highlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnActionBar02.overSkin");
            result[9] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ActionBarIcon02Deactivated");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnActionBar02.disabledSkin");
            result[10] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "CL2Buildings");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnActionBar02.toolTip = param1;
                return;
            }// end function
            , "btnActionBar02.toolTip");
            result[11] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return null.ui.mCurrentPlayer.mIsPlayerZone && !global.ui.mCurrentPlayer.mIsAdventureZone;
            }// end function
            , function (param1:Boolean) : void
            {
                null.enabled = null;
                return;
            }// end function
            , "btnActionBar03.enabled");
            result[12] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnActionBar03.upSkin");
            result[13] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnActionBar03.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnActionBar03.downSkin");
            result[14] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon03Highlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnActionBar03.overSkin");
            result[15] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon03Deactivated");
            }// end function
            , function (param1:Class) : void
            {
                btnActionBar03.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnActionBar03.disabledSkin");
            result[16] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetText(LOCA_GROUP.LABELS, "CL3Buildings");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                btnActionBar03.toolTip = param1;
                return;
            }// end function
            , "btnActionBar03.toolTip");
            result[17] = binding;
            binding = new Binding(this, function () : Boolean
            {
                return null.ui.mCurrentPlayer.mIsPlayerZone && !global.ui.mCurrentPlayer.mIsAdventureZone;
            }// end function
            , function (param1:Boolean) : void
            {
                btnActionBar04.enabled = param1;
                return;
            }// end function
            , "btnActionBar04.enabled");
            result[18] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon04");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnActionBar04.upSkin");
            result[19] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnActionBar04.downSkin");
            result[20] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ActionBarIcon04Highlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnActionBar04.overSkin");
            result[21] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("disabledSkin", param1);
                return;
            }// end function
            , "btnActionBar04.disabledSkin");
            result[22] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CLSBuildings");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = param1;
                return;
            }// end function
            , "btnActionBar04.toolTip");
            result[23] = binding;
            return result;
        }// end function

        public function get btnActionBar03() : Button
        {
            return this._1731615548btnActionBar03;
        }// end function

        public function get btnActionBar04() : Button
        {
            return this._1731615547btnActionBar04;
        }// end function

        public function __btnActionBar01_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function __btnActionBar01_toolTipShow(event:ToolTipEvent) : void
        {
            cToolTipUtil.positionActionBarTip(event);
            return;
        }// end function

        public function __btnActionBar02_toolTipShow(event:ToolTipEvent) : void
        {
            cToolTipUtil.positionActionBarTip(event);
            return;
        }// end function

        public function __btnActionBar03_toolTipShow(event:ToolTipEvent) : void
        {
            cToolTipUtil.positionActionBarTip(event);
            return;
        }// end function

        public function __btnActionBar04_toolTipShow(event:ToolTipEvent) : void
        {
            cToolTipUtil.positionActionBarTip(event);
            return;
        }// end function

        public function set btnActionBar02(param1:Button) : void
        {
            var _loc_2:* = this._1731615549btnActionBar02;
            if (_loc_2 !== param1)
            {
                this._1731615549btnActionBar02 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnActionBar02", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnActionBar02_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function __btnActionBar03_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function __btnActionBar04_toolTipCreate(event:ToolTipEvent) : void
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
