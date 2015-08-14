package GUI.Components
{
    import Enums.*;
    import GUI.Loca.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;

    public class CancelActionPanel extends Canvas implements IBindingClient
    {
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        private var _3202370hide:Move;
        var _watchers:Array;
        private var _1367724422cancel:StandardButton;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _3529469show:Move;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function CancelActionPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:StandardButton, id:"cancel", propertiesFactory:function () : Object
                {
                    return {null:32};
                }// end function
                })]};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            this._CancelActionPanel_Move2_i();
            this._CancelActionPanel_Move1_i();
            return;
        }// end function

        private function _CancelActionPanel_Move1_i() : Move
        {
            var _loc_1:* = new Move();
            this.show = _loc_1;
            _loc_1.yFrom = -32;
            _loc_1.yTo = 37;
            _loc_1.duration = 300;
            return _loc_1;
        }// end function

        private function _CancelActionPanel_Move2_i() : Move
        {
            var _loc_1:* = new Move();
            this.hide = _loc_1;
            _loc_1.yFrom = 37;
            _loc_1.yTo = -32;
            _loc_1.duration = 300;
            return _loc_1;
        }// end function

        public function set hide(param1:Move) : void
        {
            var _loc_2:* = this._3202370hide;
            if (_loc_2 !== param1)
            {
                this._3202370hide = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "hide", _loc_2, param1));
            }
            return;
        }// end function

        private function _CancelActionPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function ()
            {
                return show;
            }// end function
            , function (param1) : void
            {
                null.setStyle(this, param1);
                return;
            }// end function
            , "this.showEffect");
            result[0] = binding;
            binding = new Binding(this, function ()
            {
                return hide;
            }// end function
            , function (param1) : void
            {
                this.setStyle("hideEffect", param1);
                return;
            }// end function
            , "this.hideEffect");
            result[1] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CancelAction");
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.label = null;
                return;
            }// end function
            , "cancel.label");
            result[2] = binding;
            return result;
        }// end function

        public function get hide() : Move
        {
            return this._3202370hide;
        }// end function

        override public function initialize() : void
        {
            var target:CancelActionPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._CancelActionPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_CancelActionPanelWatcherSetupUtil");
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

        public function set show(param1:Move) : void
        {
            var _loc_2:* = this._3529469show;
            if (_loc_2 !== param1)
            {
                this._3529469show = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "show", _loc_2, param1));
            }
            return;
        }// end function

        private function _CancelActionPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.show;
            _loc_1 = this.hide;
            _loc_1 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "CancelAction");
            return;
        }// end function

        public function set cancel(param1:StandardButton) : void
        {
            var _loc_2:* = this._1367724422cancel;
            if (_loc_2 !== param1)
            {
                this._1367724422cancel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "cancel", _loc_2, param1));
            }
            return;
        }// end function

        public function get cancel() : StandardButton
        {
            return this._1367724422cancel;
        }// end function

        public function get show() : Move
        {
            return this._3529469show;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
