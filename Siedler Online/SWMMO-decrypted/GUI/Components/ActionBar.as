package GUI.Components
{
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class ActionBar extends HBox implements IBindingClient
    {
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        private var _1016014670actionBarCenter:ActionBarCenter;
        var _watchers:Array;
        private var _1681377761actionBarRight:ActionBarRight;
        private var _1427251797backgroundLeft:Canvas;
        var _bindings:Array;
        private var _1053958052actionBarLeft:ActionBarLeft;
        private var _documentDescriptor_:UIComponentDescriptor;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function ActionBar()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:HBox, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"backgroundLeft", propertiesFactory:function () : Object
                {
                    return {null:100, percentWidth:100, styleName:"actionBarBackground"};
                }// end function
                }), new UIComponentDescriptor({type:ActionBarLeft, id:"actionBarLeft"}), new UIComponentDescriptor({type:ActionBarCenter, id:"actionBarCenter"}), new UIComponentDescriptor({type:ActionBarRight, id:"actionBarRight"}), new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
                {
                    return {null:null, percentWidth:100, styleName:"actionBarBackground"};
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
                this.verticalAlign = "bottom";
                this.horizontalGap = 0;
                return;
            }// end function
            ;
            this.percentWidth = 100;
            return;
        }// end function

        public function set actionBarLeft(param1:ActionBarLeft) : void
        {
            var _loc_2:* = this._1053958052actionBarLeft;
            if (_loc_2 !== param1)
            {
                this._1053958052actionBarLeft = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "actionBarLeft", _loc_2, param1));
            }
            return;
        }// end function

        public function getAnchorX(param1:Button) : uint
        {
            return this.actionBarLeft.x + param1.x + param1.width / 2;
        }// end function

        public function getAnchorY(param1:Button) : uint
        {
            return this.actionBarLeft.y;
        }// end function

        override public function initialize() : void
        {
            var target:ActionBar;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._ActionBar_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_ActionBarWatcherSetupUtil");
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

        public function get backgroundLeft() : Canvas
        {
            return this._1427251797backgroundLeft;
        }// end function

        private function _ActionBar_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = Application.application.blueFireComponent.width - 30;
            return;
        }// end function

        public function get actionBarRight() : ActionBarRight
        {
            return this._1681377761actionBarRight;
        }// end function

        public function set actionBarCenter(param1:ActionBarCenter) : void
        {
            var _loc_2:* = this._1016014670actionBarCenter;
            if (_loc_2 !== param1)
            {
                this._1016014670actionBarCenter = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "actionBarCenter", _loc_2, param1));
            }
            return;
        }// end function

        public function set backgroundLeft(param1:Canvas) : void
        {
            var _loc_2:* = this._1427251797backgroundLeft;
            if (_loc_2 !== param1)
            {
                this._1427251797backgroundLeft = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "backgroundLeft", _loc_2, param1));
            }
            return;
        }// end function

        public function get actionBarLeft() : ActionBarLeft
        {
            return this._1053958052actionBarLeft;
        }// end function

        private function _ActionBar_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Number
            {
                return Application.application.blueFireComponent.width - 30;
            }// end function
            , function (param1:Number) : void
            {
                backgroundLeft.minWidth = param1;
                return;
            }// end function
            , "backgroundLeft.minWidth");
            result[0] = binding;
            return result;
        }// end function

        public function get actionBarCenter() : ActionBarCenter
        {
            return this._1016014670actionBarCenter;
        }// end function

        public function set actionBarRight(param1:ActionBarRight) : void
        {
            var _loc_2:* = this._1681377761actionBarRight;
            if (_loc_2 !== param1)
            {
                this._1681377761actionBarRight = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "actionBarRight", _loc_2, param1));
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
