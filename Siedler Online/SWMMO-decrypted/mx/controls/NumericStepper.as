package mx.controls
{
    import flash.display.*;
    import flash.events.*;
    import flash.text.*;
    import flash.ui.*;
    import mx.controls.listClasses.*;
    import mx.core.*;
    import mx.events.*;
    import mx.managers.*;
    import mx.styles.*;

    public class NumericStepper extends UIComponent implements IDataRenderer, IDropInListItemRenderer, IFocusManagerComponent, IIMESupport, IListItemRenderer
    {
        private var valueChanged:Boolean = false;
        var nextButton:Button;
        private var valueSet:Boolean;
        private var enabledChanged:Boolean = false;
        var prevButton:Button;
        private var _maxChars:int = 0;
        private var _stepSize:Number = 1;
        var inputField:TextInput;
        private var _value:Number = 0;
        private var lastValue:Number = 0;
        private var _data:Object;
        private var maxCharsChanged:Boolean = false;
        private var _tabIndex:int = -1;
        private var proposedValue:Number = 0;
        private var tabIndexChanged:Boolean = false;
        private var _previousValue:Number = 0;
        private var _nextValue:Number = 0;
        private var _imeMode:String = null;
        private var _listData:BaseListData;
        private var _minimum:Number = 0;
        private var _maximum:Number = 10;
        private static var _inputFieldStyleFilters:Object = {backgroundAlpha:"backgroundAlpha", backgroundColor:"backgroundColor", backgroundImage:"backgroundImage", backgroundDisabledColor:"backgroundDisabledColor", backgroundSize:"backgroundSize", borderAlpha:"borderAlpha", borderColor:"borderColor", borderSides:"borderSides", borderSkin:"borderSkin", borderStyle:"borderStyle", borderThickness:"borderThickness", dropShadowColor:"dropShadowColor", dropShadowEnabled:"dropShadowEnabled", embedFonts:"embedFonts", focusAlpha:"focusAlpha", focusBlendMode:"focusBlendMode", focusRoundedCorners:"focusRoundedCorners", focusThickness:"focusThickness", paddingLeft:"paddingLeft", paddingRight:"paddingRight", shadowDirection:"shadowDirection", shadowDistance:"shadowDistance", textDecoration:"textDecoration"};
        private static var _downArrowStyleFilters:Object = {cornerRadius:"cornerRadius", highlightAlphas:"highlightAlphas", downArrowUpSkin:"downArrowUpSkin", downArrowOverSkin:"downArrowOverSkin", downArrowDownSkin:"downArrowDownSkin", downArrowDisabledSkin:"downArrowDisabledSkin", downArrowSkin:"downArrowSkin", repeatDelay:"repeatDelay", repeatInterval:"repeatInterval"};
        static const VERSION:String = "3.5.0.12683";
        private static var _upArrowStyleFilters:Object = {cornerRadius:"cornerRadius", highlightAlphas:"highlightAlphas", upArrowUpSkin:"upArrowUpSkin", upArrowOverSkin:"upArrowOverSkin", upArrowDownSkin:"upArrowDownSkin", upArrowDisabledSkin:"upArrowDisabledSkin", upArrowSkin:"upArrowSkin", repeatDelay:"repeatDelay", repeatInterval:"repeatInterval"};

        public function NumericStepper()
        {
            tabChildren = true;
            return;
        }// end function

        public function get imeMode() : String
        {
            return _imeMode;
        }// end function

        public function set imeMode(param1:String) : void
        {
            _imeMode = param1;
            if (inputField)
            {
                inputField.imeMode = _imeMode;
            }
            return;
        }// end function

        public function get minimum() : Number
        {
            return _minimum;
        }// end function

        override protected function focusOutHandler(event:FocusEvent) : void
        {
            var _loc_2:* = focusManager;
            if (_loc_2)
            {
                _loc_2.defaultButtonEnabled = true;
            }
            super.focusOutHandler(event);
            takeValueFromTextField(event);
            return;
        }// end function

        private function checkRange(param1:Number) : Boolean
        {
            return param1 >= minimum && param1 <= maximum;
        }// end function

        override protected function createChildren() : void
        {
            super.createChildren();
            if (!inputField)
            {
                inputField = new TextInput();
                inputField.styleName = new StyleProxy(this, inputFieldStyleFilters);
                inputField.focusEnabled = false;
                inputField.restrict = "0-9\\-\\.\\,";
                inputField.maxChars = _maxChars;
                inputField.text = String(_value);
                inputField.parentDrawsFocus = true;
                inputField.imeMode = _imeMode;
                inputField.addEventListener(FocusEvent.FOCUS_IN, inputField_focusInHandler);
                inputField.addEventListener(FocusEvent.FOCUS_OUT, inputField_focusOutHandler);
                inputField.addEventListener(KeyboardEvent.KEY_DOWN, inputField_keyDownHandler);
                inputField.addEventListener(Event.CHANGE, inputField_changeHandler);
                addChild(inputField);
            }
            if (!nextButton)
            {
                nextButton = new Button();
                nextButton.styleName = new StyleProxy(this, upArrowStyleFilters);
                nextButton.upSkinName = "upArrowUpSkin";
                nextButton.overSkinName = "upArrowOverSkin";
                nextButton.downSkinName = "upArrowDownSkin";
                nextButton.disabledSkinName = "upArrowDisabledSkin";
                nextButton.skinName = "upArrowSkin";
                nextButton.upIconName = "";
                nextButton.overIconName = "";
                nextButton.downIconName = "";
                nextButton.disabledIconName = "";
                nextButton.focusEnabled = false;
                nextButton.autoRepeat = true;
                nextButton.addEventListener(MouseEvent.CLICK, buttonClickHandler);
                nextButton.addEventListener(FlexEvent.BUTTON_DOWN, buttonDownHandler);
                addChild(nextButton);
            }
            if (!prevButton)
            {
                prevButton = new Button();
                prevButton.styleName = new StyleProxy(this, downArrowStyleFilters);
                prevButton.upSkinName = "downArrowUpSkin";
                prevButton.overSkinName = "downArrowOverSkin";
                prevButton.downSkinName = "downArrowDownSkin";
                prevButton.disabledSkinName = "downArrowDisabledSkin";
                prevButton.skinName = "downArrowSkin";
                prevButton.upIconName = "";
                prevButton.overIconName = "";
                prevButton.downIconName = "";
                prevButton.disabledIconName = "";
                prevButton.focusEnabled = false;
                prevButton.autoRepeat = true;
                prevButton.addEventListener(MouseEvent.CLICK, buttonClickHandler);
                prevButton.addEventListener(FlexEvent.BUTTON_DOWN, buttonDownHandler);
                addChild(prevButton);
            }
            return;
        }// end function

        public function set minimum(param1:Number) : void
        {
            _minimum = param1;
            if (!valueChanged)
            {
                this.value = this.value;
                valueSet = false;
            }
            dispatchEvent(new Event("minimumChanged"));
            return;
        }// end function

        public function get maximum() : Number
        {
            return _maximum;
        }// end function

        private function inputField_focusOutHandler(event:FocusEvent) : void
        {
            focusOutHandler(event);
            dispatchEvent(new FocusEvent(event.type, false, false, event.relatedObject, event.shiftKey, event.keyCode));
            return;
        }// end function

        private function setValue(param1:Number, param2:Boolean = true, param3:Event = null) : void
        {
            var _loc_5:NumericStepperEvent = null;
            var _loc_4:* = checkValidValue(param1);
            if (checkValidValue(param1) == lastValue)
            {
                return;
            }
            var _loc_6:* = _loc_4;
            _value = _loc_4;
            lastValue = _loc_6;
            inputField.text = _loc_4.toString();
            if (param2)
            {
                _loc_5 = new NumericStepperEvent(NumericStepperEvent.CHANGE);
                _loc_5.value = _value;
                _loc_5.triggerEvent = param3;
                dispatchEvent(_loc_5);
            }
            dispatchEvent(new FlexEvent(FlexEvent.VALUE_COMMIT));
            return;
        }// end function

        protected function get downArrowStyleFilters() : Object
        {
            return _downArrowStyleFilters;
        }// end function

        private function takeValueFromTextField(event:Event = null) : void
        {
            var _loc_3:Number = NaN;
            var _loc_2:* = Number(inputField.text);
            if (_loc_2 != lastValue && (Math.abs(_loc_2 - lastValue) >= 1e-006 || isNaN(_loc_2)) || inputField.text == "")
            {
                _loc_3 = checkValidValue(Number(inputField.text));
                inputField.text = _loc_3.toString();
                setValue(_loc_3, event != null, event);
            }
            return;
        }// end function

        private function inputField_focusInHandler(event:FocusEvent) : void
        {
            focusInHandler(event);
            dispatchEvent(new FocusEvent(event.type, false, false, event.relatedObject, event.shiftKey, event.keyCode));
            return;
        }// end function

        override public function get tabIndex() : int
        {
            return _tabIndex;
        }// end function

        public function get nextValue() : Number
        {
            if (checkRange(value + stepSize))
            {
                _nextValue = value + stepSize;
            }
            return _nextValue;
        }// end function

        public function set maximum(param1:Number) : void
        {
            _maximum = param1;
            if (!valueChanged)
            {
                this.value = this.value;
                valueSet = false;
            }
            dispatchEvent(new Event("maximumChanged"));
            return;
        }// end function

        override public function get enabled() : Boolean
        {
            return super.enabled;
        }// end function

        override protected function isOurFocus(param1:DisplayObject) : Boolean
        {
            return param1 == inputField || super.isOurFocus(param1);
        }// end function

        private function buttonPress(param1:Button, param2:Event = null) : void
        {
            var _loc_3:Number = NaN;
            if (enabled)
            {
                takeValueFromTextField();
                _loc_3 = lastValue;
                setValue(param1 == nextButton ? (lastValue + stepSize) : (lastValue - stepSize), true, param2);
                if (_loc_3 != lastValue)
                {
                    inputField.getTextField().setSelection(0, 0);
                }
            }
            return;
        }// end function

        public function set data(param1:Object) : void
        {
            _data = param1;
            if (!valueSet)
            {
                this.value = _listData ? (parseFloat(_listData.label)) : (Number(_data));
                valueSet = false;
            }
            dispatchEvent(new FlexEvent(FlexEvent.DATA_CHANGE));
            return;
        }// end function

        protected function get upArrowStyleFilters() : Object
        {
            return _upArrowStyleFilters;
        }// end function

        private function inputField_keyDownHandler(event:KeyboardEvent) : void
        {
            var _loc_2:Number = NaN;
            var _loc_3:Number = NaN;
            var _loc_4:Number = NaN;
            switch(event.keyCode)
            {
                case Keyboard.DOWN:
                {
                    _loc_2 = value - stepSize;
                    setValue(_loc_2, true);
                    break;
                }
                case Keyboard.UP:
                {
                    _loc_2 = stepSize + value;
                    setValue(_loc_2, true);
                    break;
                }
                case Keyboard.HOME:
                {
                    inputField.text = minimum.toString();
                    setValue(minimum, true);
                    break;
                }
                case Keyboard.END:
                {
                    inputField.text = maximum.toString();
                    setValue(maximum, true);
                    break;
                }
                case Keyboard.ENTER:
                case Keyboard.TAB:
                {
                    _loc_3 = Number(inputField.text);
                    if (_loc_3 != lastValue && (Math.abs(_loc_3 - lastValue) >= 1e-006 || isNaN(_loc_3)))
                    {
                        _loc_4 = checkValidValue(Number(inputField.text));
                        inputField.text = _loc_4.toString();
                        setValue(_loc_4, true);
                    }
                    event.stopImmediatePropagation();
                    break;
                }
                default:
                {
                    break;
                }
            }
            dispatchEvent(event);
            return;
        }// end function

        override protected function measure() : void
        {
            var _loc_5:Number = NaN;
            var _loc_8:Number = NaN;
            super.measure();
            var _loc_1:* = minimum.toString().length > maximum.toString().length ? (minimum) : (maximum);
            _loc_1 = _loc_1 + stepSize;
            var _loc_2:* = measureText(checkValidValue(_loc_1).toString());
            var _loc_3:* = inputField.getExplicitOrMeasuredHeight();
            var _loc_4:* = prevButton.getExplicitOrMeasuredHeight() + nextButton.getExplicitOrMeasuredHeight();
            _loc_5 = Math.max(_loc_3, _loc_4);
            _loc_5 = Math.max(DEFAULT_MEASURED_MIN_HEIGHT, _loc_5);
            var _loc_6:* = _loc_2.width + UITextField.TEXT_WIDTH_PADDING;
            var _loc_7:* = Math.max(prevButton.getExplicitOrMeasuredWidth(), nextButton.getExplicitOrMeasuredWidth());
            _loc_8 = _loc_6 + _loc_7 + 20;
            _loc_8 = Math.max(DEFAULT_MEASURED_MIN_WIDTH, _loc_8);
            measuredMinWidth = DEFAULT_MEASURED_MIN_WIDTH;
            measuredMinHeight = DEFAULT_MEASURED_MIN_HEIGHT;
            measuredWidth = _loc_8;
            measuredHeight = _loc_5;
            return;
        }// end function

        public function get listData() : BaseListData
        {
            return _listData;
        }// end function

        override protected function focusInHandler(event:FocusEvent) : void
        {
            super.focusInHandler(event);
            var _loc_2:* = focusManager;
            if (_loc_2)
            {
                _loc_2.defaultButtonEnabled = false;
            }
            return;
        }// end function

        public function get value() : Number
        {
            return valueChanged ? (proposedValue) : (_value);
        }// end function

        protected function get inputFieldStyleFilters() : Object
        {
            return _inputFieldStyleFilters;
        }// end function

        override public function set tabIndex(param1:int) : void
        {
            if (param1 == _tabIndex)
            {
                return;
            }
            _tabIndex = param1;
            tabIndexChanged = true;
            invalidateProperties();
            return;
        }// end function

        override public function set enabled(param1:Boolean) : void
        {
            super.enabled = param1;
            enabledChanged = true;
            invalidateProperties();
            return;
        }// end function

        override public function get baselinePosition() : Number
        {
            if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
            {
                return inputField ? (inputField.baselinePosition) : (NaN);
            }
            if (!validateBaselinePosition())
            {
                return NaN;
            }
            return inputField.y + inputField.baselinePosition;
        }// end function

        override public function setFocus() : void
        {
            if (stage)
            {
                stage.focus = TextField(inputField.getTextField());
            }
            return;
        }// end function

        public function get data() : Object
        {
            if (!_listData)
            {
                data = this.value;
            }
            return _data;
        }// end function

        public function set maxChars(param1:int) : void
        {
            if (param1 == _maxChars)
            {
                return;
            }
            _maxChars = param1;
            maxCharsChanged = true;
            invalidateProperties();
            dispatchEvent(new Event("maxCharsChanged"));
            return;
        }// end function

        private function buttonDownHandler(event:FlexEvent) : void
        {
            buttonPress(Button(event.currentTarget), event);
            return;
        }// end function

        public function get previousValue() : Number
        {
            if (checkRange(_value - stepSize))
            {
                _previousValue = value - stepSize;
            }
            return _previousValue;
        }// end function

        override protected function commitProperties() : void
        {
            super.commitProperties();
            if (maxCharsChanged)
            {
                maxCharsChanged = false;
                inputField.maxChars = _maxChars;
            }
            if (valueChanged)
            {
                valueChanged = false;
                setValue(isNaN(proposedValue) ? (0) : (proposedValue), false);
            }
            if (enabledChanged)
            {
                enabledChanged = false;
                prevButton.enabled = enabled;
                nextButton.enabled = enabled;
                inputField.enabled = enabled;
            }
            if (tabIndexChanged)
            {
                inputField.tabIndex = _tabIndex;
                tabIndexChanged = false;
            }
            return;
        }// end function

        private function inputField_changeHandler(event:Event) : void
        {
            event.stopImmediatePropagation();
            var _loc_2:* = Number(inputField.text);
            if (_loc_2 != value && (Math.abs(_loc_2 - value) >= 1e-006 || isNaN(_loc_2)) || inputField.text == "")
            {
                _value = checkValidValue(_loc_2);
            }
            return;
        }// end function

        public function set listData(param1:BaseListData) : void
        {
            _listData = param1;
            return;
        }// end function

        public function get maxChars() : int
        {
            return _maxChars;
        }// end function

        public function set stepSize(param1:Number) : void
        {
            _stepSize = param1;
            if (!valueChanged)
            {
                this.value = this.value;
                valueSet = false;
            }
            dispatchEvent(new Event("stepSizeChanged"));
            return;
        }// end function

        public function set value(param1:Number) : void
        {
            valueSet = true;
            proposedValue = param1;
            valueChanged = true;
            invalidateProperties();
            invalidateSize();
            return;
        }// end function

        public function get stepSize() : Number
        {
            return _stepSize;
        }// end function

        private function buttonClickHandler(event:MouseEvent) : void
        {
            inputField.setFocus();
            inputField.getTextField().setSelection(0, 0);
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            var _loc_3:* = nextButton.getExplicitOrMeasuredWidth();
            var _loc_4:* = Math.round(param2 / 2);
            var _loc_5:* = param2 - _loc_4;
            nextButton.x = param1 - _loc_3;
            nextButton.y = 0;
            nextButton.setActualSize(_loc_3, _loc_5);
            prevButton.x = param1 - _loc_3;
            prevButton.y = param2 - _loc_4;
            prevButton.setActualSize(_loc_3, _loc_4);
            inputField.setActualSize(param1 - _loc_3, param2);
            return;
        }// end function

        private function checkValidValue(param1:Number) : Number
        {
            var _loc_4:Number = NaN;
            if (isNaN(param1))
            {
                return this.value;
            }
            var _loc_2:* = stepSize * Math.round(param1 / stepSize);
            var _loc_3:* = new String(1 + stepSize).split(".");
            if (_loc_3.length == 2)
            {
                _loc_4 = Math.pow(10, _loc_3[1].length);
                _loc_2 = Math.round(_loc_2 * _loc_4) / _loc_4;
            }
            if (_loc_2 > maximum)
            {
                return maximum;
            }
            if (_loc_2 < minimum)
            {
                return minimum;
            }
            return _loc_2;
        }// end function

    }
}
