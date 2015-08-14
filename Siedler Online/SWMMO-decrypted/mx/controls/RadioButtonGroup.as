package mx.controls
{
    import flash.events.*;
    import mx.core.*;
    import mx.events.*;

    public class RadioButtonGroup extends EventDispatcher implements IMXMLObject
    {
        private var radioButtons:Array;
        private var _selection:RadioButton;
        private var _selectedValue:Object;
        private var document:IFlexDisplayObject;
        private var _labelPlacement:String = "right";
        private var indexNumber:int = 0;
        static const VERSION:String = "3.5.0.12683";

        public function RadioButtonGroup(param1:IFlexDisplayObject = null)
        {
            radioButtons = [];
            return;
        }// end function

        public function get enabled() : Boolean
        {
            var _loc_1:Number = 0;
            var _loc_2:* = numRadioButtons;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                _loc_1 = _loc_1 + getRadioButtonAt(_loc_3).enabled;
                _loc_3++;
            }
            if (_loc_1 == 0)
            {
                return false;
            }
            if (_loc_1 == _loc_2)
            {
                return true;
            }
            return false;
        }// end function

        public function set enabled(param1:Boolean) : void
        {
            var _loc_2:* = numRadioButtons;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                getRadioButtonAt(_loc_3).enabled = param1;
                _loc_3++;
            }
            dispatchEvent(new Event("enabledChanged"));
            return;
        }// end function

        private function radioButton_removedHandler(event:Event) : void
        {
            var _loc_2:* = event.target as RadioButton;
            if (_loc_2)
            {
                _loc_2.removeEventListener(Event.REMOVED, radioButton_removedHandler);
                removeInstance(RadioButton(event.target));
            }
            return;
        }// end function

        public function set selectedValue(param1:Object) : void
        {
            var _loc_4:RadioButton = null;
            _selectedValue = param1;
            var _loc_2:* = numRadioButtons;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                _loc_4 = getRadioButtonAt(_loc_3);
                if (_loc_4.value == param1 || _loc_4.label == param1)
                {
                    changeSelection(_loc_3, false);
                    break;
                }
                _loc_3++;
            }
            dispatchEvent(new FlexEvent(FlexEvent.VALUE_COMMIT));
            return;
        }// end function

        private function getValue() : String
        {
            if (selection)
            {
                return selection.value && selection.value is String && String(selection.value).length != 0 ? (String(selection.value)) : (selection.label);
                ;
            }
            return null;
        }// end function

        public function get labelPlacement() : String
        {
            return _labelPlacement;
        }// end function

        public function get selection() : RadioButton
        {
            return _selection;
        }// end function

        public function get selectedValue() : Object
        {
            if (selection)
            {
                return selection.value != null ? (selection.value) : (selection.label);
            }
            return null;
        }// end function

        public function set selection(param1:RadioButton) : void
        {
            setSelection(param1, false);
            return;
        }// end function

        function setSelection(param1:RadioButton, param2:Boolean = true) : void
        {
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            if (param1 == null && _selection != null)
            {
                _selection.selected = false;
                _selection = null;
                if (param2)
                {
                    dispatchEvent(new Event(Event.CHANGE));
                }
            }
            else
            {
                _loc_3 = numRadioButtons;
                _loc_4 = 0;
                while (_loc_4 < _loc_3)
                {
                    
                    if (param1 == getRadioButtonAt(_loc_4))
                    {
                        changeSelection(_loc_4, param2);
                        break;
                    }
                    _loc_4++;
                }
            }
            dispatchEvent(new FlexEvent(FlexEvent.VALUE_COMMIT));
            return;
        }// end function

        public function initialized(param1:Object, param2:String) : void
        {
            this.document = param1 ? (IFlexDisplayObject(param1)) : (IFlexDisplayObject(Application.application));
            return;
        }// end function

        function addInstance(param1:RadioButton) : void
        {
            param1.indexNumber = indexNumber + 1;
            param1.addEventListener(Event.REMOVED, radioButton_removedHandler);
            radioButtons.push(param1);
            if (_selectedValue != null)
            {
                selectedValue = _selectedValue;
            }
            dispatchEvent(new Event("numRadioButtonsChanged"));
            return;
        }// end function

        public function set labelPlacement(param1:String) : void
        {
            _labelPlacement = param1;
            var _loc_2:* = numRadioButtons;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                getRadioButtonAt(_loc_3).labelPlacement = param1;
                _loc_3++;
            }
            return;
        }// end function

        public function get numRadioButtons() : int
        {
            return radioButtons.length;
        }// end function

        public function getRadioButtonAt(param1:int) : RadioButton
        {
            return RadioButton(radioButtons[param1]);
        }// end function

        function removeInstance(param1:RadioButton) : void
        {
            var _loc_2:Boolean = false;
            var _loc_3:int = 0;
            var _loc_4:RadioButton = null;
            if (param1)
            {
                _loc_2 = false;
                _loc_3 = 0;
                while (_loc_3 < numRadioButtons)
                {
                    
                    _loc_4 = getRadioButtonAt(_loc_3);
                    if (_loc_2)
                    {
                        var _loc_5:* = _loc_4;
                        var _loc_6:* = _loc_4.indexNumber - 1;
                        _loc_5.indexNumber = _loc_6;
                    }
                    else if (_loc_4 == param1)
                    {
                        _loc_4.group = null;
                        if (param1 == _selection)
                        {
                            _selection = null;
                        }
                        radioButtons.splice(_loc_3, 1);
                        _loc_2 = true;
                        var _loc_6:* = indexNumber - 1;
                        indexNumber = _loc_6;
                        _loc_3 = _loc_3 - 1;
                    }
                    _loc_3++;
                }
                if (_loc_2)
                {
                    dispatchEvent(new Event("numRadioButtonsChanged"));
                }
            }
            return;
        }// end function

        private function changeSelection(param1:int, param2:Boolean = true) : void
        {
            if (getRadioButtonAt(param1))
            {
                if (selection)
                {
                    selection.selected = false;
                }
                _selection = getRadioButtonAt(param1);
                _selection.selected = true;
                if (param2)
                {
                    dispatchEvent(new Event(Event.CHANGE));
                }
            }
            return;
        }// end function

    }
}
