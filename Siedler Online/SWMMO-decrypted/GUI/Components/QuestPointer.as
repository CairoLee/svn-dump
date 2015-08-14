package GUI.Components
{
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class QuestPointer extends Canvas implements IBindingClient
    {
        public var _QuestPointer_Label1:Label;
        private var _1332194002background:Class;
        var _bindingsBeginWithWord:Object;
        var _bindings:Array;
        private var UpSkinCompleted:Class;
        var _watchers:Array;
        private var OverSkinNormal:Class;
        private var _type:String = "normal";
        private var UpSkinNormal:Class;
        var _bindingsByDestination:Object;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var OverSkinCompleted:Class;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function QuestPointer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {height:51, childDescriptors:[new UIComponentDescriptor({type:Label, id:"_QuestPointer_Label1", stylesFactory:function () : void
                {
                    null.left = this;
                    this.right = "15";
                    this.verticalCenter = "-3";
                    this.color = 16777215;
                    return;
                }// end function
                })]};
            }// end function
            });
            this.UpSkinNormal = QuestPointer_UpSkinNormal;
            this.OverSkinNormal = QuestPointer_OverSkinNormal;
            this.UpSkinCompleted = QuestPointer_UpSkinCompleted;
            this.OverSkinCompleted = QuestPointer_OverSkinCompleted;
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
                this.backgroundSize = "100%";
                return;
            }// end function
            ;
            this.height = 51;
            this.addEventListener("click", this.___QuestPointer_Canvas1_click);
            this.addEventListener("rollOver", this.___QuestPointer_Canvas1_rollOver);
            this.addEventListener("rollOut", this.___QuestPointer_Canvas1_rollOut);
            this.addEventListener("creationComplete", this.___QuestPointer_Canvas1_creationComplete);
            return;
        }// end function

        public function get type() : String
        {
            return this._type;
        }// end function

        private function _QuestPointer_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.background;
            _loc_1 = label;
            return;
        }// end function

        public function ___QuestPointer_Canvas1_creationComplete(event:FlexEvent) : void
        {
            this.onRollOut(null);
            return;
        }// end function

        override public function initialize() : void
        {
            var target:QuestPointer;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._QuestPointer_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_QuestPointerWatcherSetupUtil");
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

        private function _QuestPointer_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : Object
            {
                return background;
            }// end function
            , function (param1:Object) : void
            {
                null.setStyle(this, param1);
                return;
            }// end function
            , "this.backgroundImage");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:String = null;
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_QuestPointer_Label1.text");
            result[1] = binding;
            return result;
        }// end function

        private function set background(param1:Class) : void
        {
            var _loc_2:* = this._1332194002background;
            if (_loc_2 !== param1)
            {
                this._1332194002background = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "background", _loc_2, param1));
            }
            return;
        }// end function

        public function ___QuestPointer_Canvas1_click(event:MouseEvent) : void
        {
            globalFlash.gui.mQuestBook.Show();
            return;
        }// end function

        public function ___QuestPointer_Canvas1_rollOut(event:MouseEvent) : void
        {
            this.onRollOut(event);
            return;
        }// end function

        private function get background() : Class
        {
            return this._1332194002background;
        }// end function

        protected function onRollOver(event:MouseEvent) : void
        {
            switch(this._type)
            {
                case "normal":
                {
                    this.background = this.OverSkinNormal;
                    break;
                }
                case "completed":
                {
                    this.background = this.OverSkinCompleted;
                    break;
                }
                default:
                {
                    break;
                }
            }
            this.validateNow();
            return;
        }// end function

        protected function onRollOut(event:MouseEvent) : void
        {
            switch(this._type)
            {
                case "normal":
                {
                    this.background = this.UpSkinNormal;
                    break;
                }
                case "completed":
                {
                    this.background = this.UpSkinCompleted;
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        public function set type(param1:String) : void
        {
            this._type = param1;
            return;
        }// end function

        public function ___QuestPointer_Canvas1_rollOver(event:MouseEvent) : void
        {
            this.onRollOver(event);
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
