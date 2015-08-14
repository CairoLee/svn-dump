package GUI.Components
{
    import flash.display.*;
    import flash.events.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class BattleHealthBar extends Canvas implements IBindingClient
    {
        private var _value2:Number;
        private var _720764878redBarMask:Canvas;
        private const ANIM_FRAMES:int = 10;
        var _watchers:Array;
        private var _embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card_healthbar_full01_png_92067752:Class;
        private var _stepWidth1:Number;
        private var _stepWidth2:Number;
        private var _1442597470hitpointsLabel:Label;
        private var _currentValue2:Number;
        private var _currentValue1:Number;
        var _bindingsByDestination:Object;
        private var _maxValue:Number;
        var _bindingsBeginWithWord:Object;
        private var _embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card_healthbar_tarnished01_png_1479436088:Class;
        private var _205206032greenBar:Canvas;
        private var _934922814redBar:Canvas;
        private var _945300764greenBarMask:Canvas;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _value1:Number;
        private static var _watcherSetupUtil:IWatcherSetupUtil;

        public function BattleHealthBar()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:69, height:16, childDescriptors:[new UIComponentDescriptor({type:Canvas, id:"redBar", stylesFactory:function () : void
                {
                    null.backgroundImage = this;
                    this.backgroundSize = "100%";
                    this.top = "0";
                    this.bottom = "0";
                    this.left = "0";
                    this.right = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:true};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"greenBar", stylesFactory:function () : void
                {
                    null.backgroundImage = this;
                    this.backgroundSize = "100%";
                    this.top = "0";
                    this.bottom = "0";
                    this.left = "0";
                    this.right = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:true};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"redBarMask", events:{creationComplete:"__redBarMask_creationComplete"}, stylesFactory:function () : void
                {
                    this.backgroundColor = 16777215;
                    this.top = "0";
                    this.bottom = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:0, width:0};
                }// end function
                }), new UIComponentDescriptor({type:Canvas, id:"greenBarMask", events:{creationComplete:"__greenBarMask_creationComplete"}, stylesFactory:function () : void
                {
                    this.backgroundColor = 16777215;
                    this.top = "0";
                    this.bottom = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:0, width:0};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"hitpointsLabel", stylesFactory:function () : void
                {
                    this.textAlign = "center";
                    this.horizontalCenter = "0";
                    this.color = 16777215;
                    this.fontWeight = "normal";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card_healthbar_full01_png_92067752 = BattleHealthBar__embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card_healthbar_full01_png_92067752;
            this._embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card_healthbar_tarnished01_png_1479436088 = BattleHealthBar__embed_mxml_____data_src_gfx_embedded_battlewindow_battle_card_healthbar_tarnished01_png_1479436088;
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
                this.backgroundColor = 0;
                return;
            }// end function
            ;
            this.width = 69;
            this.height = 16;
            return;
        }// end function

        public function set redBar(param1:Canvas) : void
        {
            var _loc_2:* = this._934922814redBar;
            if (_loc_2 !== param1)
            {
                this._934922814redBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "redBar", _loc_2, param1));
            }
            return;
        }// end function

        public function __greenBarMask_creationComplete(event:FlexEvent) : void
        {
            this.updateBarMask(event);
            return;
        }// end function

        public function get greenBarMask() : Canvas
        {
            return this._945300764greenBarMask;
        }// end function

        private function updateBarMask(event:Event) : void
        {
            var _loc_2:Number = NaN;
            var _loc_3:Number = NaN;
            if (this._currentValue1 - this._stepWidth1 < this._value1)
            {
                this._currentValue1 = this._value1;
            }
            else
            {
                this._currentValue1 = this._currentValue1 - this._stepWidth1;
            }
            if (this._currentValue2 - this._stepWidth2 < this._value2)
            {
                this._currentValue2 = this._value2;
            }
            else
            {
                this._currentValue2 = this._currentValue2 - this._stepWidth2;
            }
            if (this._maxValue == 0)
            {
                _loc_2 = 0;
            }
            else if (this._currentValue1 > this._maxValue)
            {
                _loc_2 = 1;
            }
            else
            {
                _loc_2 = this._currentValue1 / this._maxValue;
            }
            if (this._maxValue == 0)
            {
                _loc_3 = 0;
            }
            else if (this._currentValue2 > this._maxValue)
            {
                _loc_3 = 1;
            }
            else
            {
                _loc_3 = this._currentValue2 / this._maxValue;
            }
            if (this.redBarMask && this.greenBarMask)
            {
                this.greenBarMask.width = this.greenBar.width * _loc_2;
                this.redBarMask.width = this.redBar.width * _loc_3;
            }
            if (this._currentValue1 == this._value1 && this._currentValue2 == this._value2)
            {
                this.removeEventListener(Event.ENTER_FRAME, this.updateBarMask);
            }
            return;
        }// end function

        private function _BattleHealthBar_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = this.redBarMask;
            _loc_1 = this.greenBarMask;
            return;
        }// end function

        public function set greenBar(param1:Canvas) : void
        {
            var _loc_2:* = this._205206032greenBar;
            if (_loc_2 !== param1)
            {
                this._205206032greenBar = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "greenBar", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            var target:BattleHealthBar;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._BattleHealthBar_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_BattleHealthBarWatcherSetupUtil");
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

        public function set redBarMask(param1:Canvas) : void
        {
            var _loc_2:* = this._720764878redBarMask;
            if (_loc_2 !== param1)
            {
                this._720764878redBarMask = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "redBarMask", _loc_2, param1));
            }
            return;
        }// end function

        public function __redBarMask_creationComplete(event:FlexEvent) : void
        {
            this.updateBarMask(event);
            return;
        }// end function

        public function get greenBar() : Canvas
        {
            return this._205206032greenBar;
        }// end function

        public function set hitpointsLabel(param1:Label) : void
        {
            var _loc_2:* = this._1442597470hitpointsLabel;
            if (_loc_2 !== param1)
            {
                this._1442597470hitpointsLabel = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "hitpointsLabel", _loc_2, param1));
            }
            return;
        }// end function

        public function set greenBarMask(param1:Canvas) : void
        {
            var _loc_2:* = this._945300764greenBarMask;
            if (_loc_2 !== param1)
            {
                this._945300764greenBarMask = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "greenBarMask", _loc_2, param1));
            }
            return;
        }// end function

        public function set value1(param1:Number) : void
        {
            var _loc_2:* = this._value1;
            if (param1 < 0)
            {
                this._value1 = 0;
            }
            else
            {
                this._value1 = param1;
            }
            this._stepWidth1 = (this._currentValue1 - this._value1) / this.ANIM_FRAMES;
            if (_loc_2 != this._value1 && !this.hasEventListener(Event.ENTER_FRAME))
            {
                this.addEventListener(Event.ENTER_FRAME, this.updateBarMask);
            }
            return;
        }// end function

        public function set value2(param1:Number) : void
        {
            var _loc_2:* = this._value2;
            if (param1 < 0)
            {
                this._value2 = 0;
            }
            else
            {
                this._value2 = param1;
            }
            this.hitpointsLabel.text = Math.floor(this._value2).toString();
            this._stepWidth2 = (this._currentValue2 - this._value2) / this.ANIM_FRAMES;
            if (_loc_2 != this._value2 && !this.hasEventListener(Event.ENTER_FRAME))
            {
                this.addEventListener(Event.ENTER_FRAME, this.updateBarMask);
            }
            return;
        }// end function

        public function get redBar() : Canvas
        {
            return this._934922814redBar;
        }// end function

        public function get redBarMask() : Canvas
        {
            return this._720764878redBarMask;
        }// end function

        public function get hitpointsLabel() : Label
        {
            return this._1442597470hitpointsLabel;
        }// end function

        public function get value1() : Number
        {
            return this._value1;
        }// end function

        public function set maxValue(param1:Number) : void
        {
            if (param1 < 0)
            {
                this.maxValue = 0;
            }
            else
            {
                this._maxValue = param1;
            }
            this._value1 = param1;
            this._value2 = param1;
            this._currentValue1 = param1;
            this._currentValue2 = param1;
            this._stepWidth1 = 0;
            this._stepWidth2 = 0;
            this.hitpointsLabel.text = Math.floor(this._value2).toString();
            this.updateBarMask(null);
            return;
        }// end function

        public function get value2() : Number
        {
            return this._value2;
        }// end function

        public function get maxValue() : Number
        {
            return this._maxValue;
        }// end function

        private function _BattleHealthBar_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : DisplayObject
            {
                return redBarMask;
            }// end function
            , function (param1:DisplayObject) : void
            {
                redBar.mask = param1;
                return;
            }// end function
            , "redBar.mask");
            result[0] = binding;
            binding = new Binding(this, function () : DisplayObject
            {
                return greenBarMask;
            }// end function
            , function (param1:DisplayObject) : void
            {
                null.mask = null;
                return;
            }// end function
            , "greenBar.mask");
            result[1] = binding;
            return result;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            BattleHealthBar._watcherSetupUtil = param1;
            return;
        }// end function

    }
}
