package mx.controls
{
    import flash.events.*;
    import flash.ui.*;
    import mx.core.*;
    import mx.events.*;
    import mx.managers.*;

    public class RadioButton extends Button implements IFocusManagerGroup, IToggleButton
    {
        private var _group:RadioButtonGroup;
        var _groupName:String;
        private var _value:Object;
        private var groupChanged:Boolean = false;
        var indexNumber:int = 0;
        static const VERSION:String = "3.5.0.12683";
        static var createAccessibilityImplementation:Function;

        public function RadioButton()
        {
            _labelPlacement = "";
            _toggle = true;
            groupName = "radioGroup";
            addEventListener(FlexEvent.ADD, addHandler);
            centerContent = false;
            extraSpacing = 8;
            return;
        }// end function

        private function addHandler(event:FlexEvent) : void
        {
            if (!_group && initialized)
            {
                addToGroup();
            }
            return;
        }// end function

        private function setNext(param1:Boolean = true) : void
        {
            var _loc_5:RadioButton = null;
            var _loc_2:* = group;
            var _loc_3:* = focusManager;
            if (_loc_3)
            {
                _loc_3.showFocusIndicator = true;
            }
            var _loc_4:* = indexNumber + 1;
            while (_loc_4 < _loc_2.numRadioButtons)
            {
                
                _loc_5 = _loc_2.getRadioButtonAt(_loc_4);
                if (_loc_5 && _loc_5.enabled)
                {
                    if (param1)
                    {
                        _loc_2.setSelection(_loc_5);
                    }
                    _loc_5.setFocus();
                    return;
                }
                _loc_4++;
            }
            if (param1 && _loc_2.getRadioButtonAt(indexNumber) != _loc_2.selection)
            {
                _loc_2.setSelection(this);
            }
            this.drawFocus(true);
            return;
        }// end function

        private function addToGroup() : Object
        {
            var _loc_1:* = group;
            if (_loc_1)
            {
                _loc_1.addInstance(this);
            }
            return _loc_1;
        }// end function

        override protected function commitProperties() : void
        {
            super.commitProperties();
            if (groupChanged)
            {
                addToGroup();
                groupChanged = false;
            }
            return;
        }// end function

        override protected function clickHandler(event:MouseEvent) : void
        {
            if (!enabled || selected)
            {
                return;
            }
            if (!_group)
            {
                addToGroup();
            }
            super.clickHandler(event);
            group.setSelection(this);
            var _loc_2:* = new ItemClickEvent(ItemClickEvent.ITEM_CLICK);
            _loc_2.label = label;
            _loc_2.index = indexNumber;
            _loc_2.relatedObject = this;
            _loc_2.item = value;
            group.dispatchEvent(_loc_2);
            return;
        }// end function

        override protected function keyUpHandler(event:KeyboardEvent) : void
        {
            super.keyUpHandler(event);
            if (event.keyCode == Keyboard.SPACE && !_toggle)
            {
                _toggle = true;
            }
            return;
        }// end function

        override public function get labelPlacement() : String
        {
            var _loc_1:* = ButtonLabelPlacement.RIGHT;
            if (_labelPlacement != "")
            {
                _loc_1 = _labelPlacement;
            }
            else if (_group && _group.labelPlacement != "")
            {
                _loc_1 = _group.labelPlacement;
            }
            return _loc_1;
        }// end function

        public function set groupName(param1:String) : void
        {
            if (!param1 || param1 == "")
            {
                return;
            }
            deleteGroup();
            _groupName = param1;
            groupChanged = true;
            invalidateProperties();
            invalidateDisplayList();
            dispatchEvent(new Event("groupNameChanged"));
            return;
        }// end function

        override protected function initializeAccessibility() : void
        {
            if (RadioButton.createAccessibilityImplementation != null)
            {
                RadioButton.createAccessibilityImplementation(this);
            }
            return;
        }// end function

        private function setThis() : void
        {
            if (!_group)
            {
                addToGroup();
            }
            var _loc_1:* = group;
            if (_loc_1.selection != this)
            {
                _loc_1.setSelection(this);
            }
            return;
        }// end function

        override public function get emphasized() : Boolean
        {
            return false;
        }// end function

        override public function get toggle() : Boolean
        {
            return super.toggle;
        }// end function

        override protected function measure() : void
        {
            var _loc_1:Number = NaN;
            var _loc_2:Number = NaN;
            var _loc_3:Number = NaN;
            var _loc_4:Number = NaN;
            super.measure();
            if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
            {
                _loc_1 = measureText(label).height;
                _loc_2 = currentIcon ? (currentIcon.height) : (0);
                if (labelPlacement == ButtonLabelPlacement.LEFT || labelPlacement == ButtonLabelPlacement.RIGHT)
                {
                    _loc_3 = Math.max(_loc_1, _loc_2);
                }
                else
                {
                    _loc_3 = _loc_1 + _loc_2;
                    _loc_4 = getStyle("verticalGap");
                    if (_loc_2 != 0 && !isNaN(_loc_4))
                    {
                        _loc_3 = _loc_3 + _loc_4;
                    }
                }
                var _loc_5:* = Math.max(_loc_3, 18);
                measuredHeight = Math.max(_loc_3, 18);
                measuredMinHeight = _loc_5;
            }
            return;
        }// end function

        override public function set toggle(param1:Boolean) : void
        {
            return;
        }// end function

        function deleteGroup() : void
        {
            try
            {
                if (document[groupName])
                {
                    delete document[groupName];
                }
            }
            catch (e:Error)
            {
                try
                {
                    if (document.automaticRadioButtonGroups[groupName])
                    {
                        delete document.automaticRadioButtonGroups[groupName];
                    }
                }
                catch (e1:Error)
                {
                }
                return;
        }// end function

        override protected function keyDownHandler(event:KeyboardEvent) : void
        {
            if (!enabled)
            {
                return;
            }
            switch(event.keyCode)
            {
                case Keyboard.DOWN:
                {
                    setNext(!event.ctrlKey);
                    event.stopPropagation();
                    break;
                }
                case Keyboard.UP:
                {
                    setPrev(!event.ctrlKey);
                    event.stopPropagation();
                    break;
                }
                case Keyboard.LEFT:
                {
                    setPrev(!event.ctrlKey);
                    event.stopPropagation();
                    break;
                }
                case Keyboard.RIGHT:
                {
                    setNext(!event.ctrlKey);
                    event.stopPropagation();
                    break;
                }
                case Keyboard.SPACE:
                {
                    setThis();
                    _toggle = false;
                }
                default:
                {
                    super.keyDownHandler(event);
                    break;
                    break;
                }
            }
            return;
        }// end function

        public function get groupName() : String
        {
            return _groupName;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            if (groupChanged)
            {
                addToGroup();
                groupChanged = false;
            }
            if (_group && _selected && _group.selection != this)
            {
                group.setSelection(this, false);
            }
            return;
        }// end function

        public function get value() : Object
        {
            return _value;
        }// end function

        public function set value(param1:Object) : void
        {
            _value = param1;
            dispatchEvent(new Event("valueChanged"));
            if (selected && group)
            {
                group.dispatchEvent(new FlexEvent(FlexEvent.VALUE_COMMIT));
            }
            return;
        }// end function

        private function setPrev(param1:Boolean = true) : void
        {
            var _loc_5:RadioButton = null;
            var _loc_2:* = group;
            var _loc_3:* = focusManager;
            if (_loc_3)
            {
                _loc_3.showFocusIndicator = true;
            }
            var _loc_4:int = 1;
            while (_loc_4 <= indexNumber)
            {
                
                _loc_5 = _loc_2.getRadioButtonAt(indexNumber - _loc_4);
                if (_loc_5 && _loc_5.enabled)
                {
                    if (param1)
                    {
                        _loc_2.setSelection(_loc_5);
                    }
                    _loc_5.setFocus();
                    return;
                }
                _loc_4++;
            }
            if (param1 && _loc_2.getRadioButtonAt(indexNumber) != _loc_2.selection)
            {
                _loc_2.setSelection(this);
            }
            this.drawFocus(true);
            return;
        }// end function

        public function set group(param1:RadioButtonGroup) : void
        {
            _group = param1;
            return;
        }// end function

        public function get group() : RadioButtonGroup
        {
            var g:RadioButtonGroup;
            if (!document)
            {
                return _group;
            }
            if (!_group)
            {
                if (groupName && groupName != "")
                {
                    try
                    {
                        g = RadioButtonGroup(document[groupName]);
                    }
                    catch (e:Error)
                    {
                        if (document.automaticRadioButtonGroups && document.automaticRadioButtonGroups[groupName])
                        {
                            g = RadioButtonGroup(document.automaticRadioButtonGroups[groupName]);
                        }
                    }
                    if (!g)
                    {
                        g = new RadioButtonGroup(IFlexDisplayObject(document));
                        if (!document.automaticRadioButtonGroups)
                        {
                            document.automaticRadioButtonGroups = {};
                        }
                        document.automaticRadioButtonGroups[groupName] = g;
                    }
                    else if (!(g is RadioButtonGroup))
                    {
                        return null;
                    }
                    _group = g;
                }
            }
            return _group;
        }// end function

    }
}
