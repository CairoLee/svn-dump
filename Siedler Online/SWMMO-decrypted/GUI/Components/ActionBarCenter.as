package GUI.Components
{
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
    import mx.styles.*;

    public class ActionBarCenter extends Canvas implements IBindingClient
    {
        private var _1731615546btnActionBar05:Button;
        var _bindingsByDestination:Object;
        private var arrowDown:Boolean = true;
        private var _632279438toggleFrindsList:Button;
        var _bindingsBeginWithWord:Object;
        var _watchers:Array;
        private var _795620349animStar:SpriteLibAnimation;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function ActionBarCenter()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {width:84, childDescriptors:[new UIComponentDescriptor({type:SpriteLibAnimation, id:"animStar", stylesFactory:function () : void
                {
                    this.horizontalCenter = "2";
                    this.top = "-17";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:0.5, visible:false, width:98, height:98, loop:true, animationName:"guianim_star"};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"btnActionBar05", events:{toolTipCreate:"__btnActionBar05_toolTipCreate", toolTipShow:"__btnActionBar05_toolTipShow"}, stylesFactory:function () : void
                {
                    null.horizontalCenter = this;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, height:95};
                }// end function
                }), new UIComponentDescriptor({type:Button, id:"toggleFrindsList", events:{click:"__toggleFrindsList_click"}, stylesFactory:function () : void
                {
                    this.horizontalCenter = "0";
                    this.bottom = "3";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {width:25, height:23};
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
                null.bottom = this;
                return;
            }// end function
            ;
            this.clipContent = false;
            this.horizontalScrollPolicy = "off";
            this.verticalScrollPolicy = "off";
            this.width = 84;
            this.styleName = "actionBarCenter";
            return;
        }// end function

        public function get animStar() : SpriteLibAnimation
        {
            return this._795620349animStar;
        }// end function

        private function _ActionBarCenter_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = gAssetManager.GetClass("ActionBarIcon05");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon05Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon05Highlight");
            _loc_1 = gAssetManager.GetClass("ActionBarIcon05Deactivated");
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "StarMenu");
            _loc_1 = gAssetManager.GetClass("ArrowDown");
            _loc_1 = gAssetManager.GetClass("ArrowDownHighlight");
            _loc_1 = gAssetManager.GetClass("ArrowDownHighlight");
            return;
        }// end function

        override public function initialize() : void
        {
            var target:ActionBarCenter;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._ActionBarCenter_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ActionBarCenterWatcherSetupUtil");
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

        public function set animStar(param1:SpriteLibAnimation) : void
        {
            var _loc_2:* = this._795620349animStar;
            if (_loc_2 !== param1)
            {
                this._795620349animStar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "animStar", _loc_2, param1));
            }
            return;
        }// end function

        public function __toggleFrindsList_click(event:MouseEvent) : void
        {
            this.Toggle();
            return;
        }// end function

        public function get btnActionBar05() : Button
        {
            return this._1731615546btnActionBar05;
        }// end function

        private function _ActionBarCenter_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ActionBarIcon05");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("upSkin", param1);
                return;
            }// end function
            , "btnActionBar05.upSkin");
            result[0] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "btnActionBar05.downSkin");
            result[1] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass(null);
            }// end function
            , function (param1:Class) : void
            {
                btnActionBar05.setStyle("overSkin", param1);
                return;
            }// end function
            , "btnActionBar05.overSkin");
            result[2] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ActionBarIcon05Deactivated");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "btnActionBar05.disabledSkin");
            result[3] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.GetInstance().GetText(LOCA_GROUP.LABELS, "StarMenu");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.toolTip = param1;
                return;
            }// end function
            , "btnActionBar05.toolTip");
            result[4] = binding;
            binding = new Binding(this, function () : Class
            {
                return null.GetClass("ArrowDown");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle(null, param1);
                return;
            }// end function
            , "toggleFrindsList.upSkin");
            result[5] = binding;
            binding = new Binding(this, function () : Class
            {
                return gAssetManager.GetClass("ArrowDownHighlight");
            }// end function
            , function (param1:Class) : void
            {
                null.setStyle("downSkin", param1);
                return;
            }// end function
            , "toggleFrindsList.downSkin");
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
            , "toggleFrindsList.overSkin");
            result[7] = binding;
            return result;
        }// end function

        public function set btnActionBar05(param1:Button) : void
        {
            var _loc_2:* = this._1731615546btnActionBar05;
            if (_loc_2 !== param1)
            {
                this._1731615546btnActionBar05 = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnActionBar05", _loc_2, param1));
            }
            return;
        }// end function

        public function __btnActionBar05_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
            return;
        }// end function

        public function __btnActionBar05_toolTipShow(event:ToolTipEvent) : void
        {
            cToolTipUtil.positionActionBarTip(event);
            return;
        }// end function

        public function set toggleFrindsList(param1:Button) : void
        {
            var _loc_2:* = this._632279438toggleFrindsList;
            if (_loc_2 !== param1)
            {
                this._632279438toggleFrindsList = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "toggleFrindsList", _loc_2, param1));
            }
            return;
        }// end function

        public function get toggleFrindsList() : Button
        {
            return this._632279438toggleFrindsList;
        }// end function

        private function Toggle() : void
        {
            this.arrowDown = !this.arrowDown;
            if (this.arrowDown)
            {
                this.toggleFrindsList.setStyle("upSkin", gAssetManager.GetClass("ArrowDown"));
                this.toggleFrindsList.setStyle("overSkin", gAssetManager.GetClass("ArrowDownHighlight"));
                this.toggleFrindsList.setStyle("downSkin", gAssetManager.GetClass("ArrowDownHighlight"));
            }
            else
            {
                this.toggleFrindsList.setStyle("upSkin", gAssetManager.GetClass("ArrowUp"));
                this.toggleFrindsList.setStyle("overSkin", gAssetManager.GetClass("ArrowUpHighlight"));
                this.toggleFrindsList.setStyle("downSkin", gAssetManager.GetClass("ArrowUpHighlight"));
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
