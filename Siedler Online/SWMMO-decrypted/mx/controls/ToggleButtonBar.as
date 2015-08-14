package mx.controls
{
    import flash.events.*;
    import flash.ui.*;
    import mx.core.*;
    import mx.events.*;

    public class ToggleButtonBar extends ButtonBar
    {
        var selectedButtonTextStyleNameProp:String = "selectedButtonTextStyleName";
        private var initializeSelectedButton:Boolean = true;
        private var _toggleOnClick:Boolean = false;
        private var _selectedIndex:int = -2;
        private var selectedIndexChanged:Boolean = false;
        static const VERSION:String = "3.5.0.12683";

        public function ToggleButtonBar()
        {
            return;
        }// end function

        override protected function createNavItem(param1:String, param2:Class = null) : IFlexDisplayObject
        {
            var _loc_3:* = Button(super.createNavItem(param1, param2));
            _loc_3.toggle = true;
            return _loc_3;
        }// end function

        override public function styleChanged(param1:String) : void
        {
            var _loc_3:Button = null;
            var _loc_4:String = null;
            var _loc_2:* = param1 == null || param1 == "styleName";
            super.styleChanged(param1);
            if (_loc_2 || param1 == selectedButtonTextStyleNameProp)
            {
                if (selectedIndex != -1 && selectedIndex < numChildren)
                {
                    _loc_3 = Button(getChildAt(selectedIndex));
                    if (_loc_3)
                    {
                        _loc_4 = getStyle(selectedButtonTextStyleNameProp);
                        _loc_3.getTextField().styleName = _loc_4 ? (_loc_4) : ("activeButtonStyle");
                    }
                }
            }
            return;
        }// end function

        override protected function resetNavItems() : void
        {
            var _loc_4:Button = null;
            var _loc_1:* = getStyle(selectedButtonTextStyleNameProp);
            var _loc_2:* = numChildren;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                _loc_4 = Button(getChildAt(_loc_3));
                if (_loc_3 == selectedIndex)
                {
                    _loc_4.selected = true;
                    _loc_4.getTextField().styleName = _loc_1 ? (_loc_1) : ("activeButtonStyle");
                }
                else
                {
                    _loc_4.selected = false;
                    _loc_4.getTextField().styleName = _loc_4;
                }
                _loc_3++;
            }
            super.resetNavItems();
            return;
        }// end function

        function selectButton(param1:int, param2:Boolean = false, param3:Event = null) : void
        {
            _selectedIndex = param1;
            if (param2)
            {
                drawButtonFocus(focusedIndex, false);
                focusedIndex = param1;
                drawButtonFocus(focusedIndex, false);
            }
            var _loc_4:* = Button(getChildAt(param1));
            simulatedClickTriggerEvent = param3;
            _loc_4.dispatchEvent(new MouseEvent(MouseEvent.CLICK));
            simulatedClickTriggerEvent = null;
            return;
        }// end function

        override protected function keyUpHandler(event:KeyboardEvent) : void
        {
            return;
        }// end function

        override protected function commitProperties() : void
        {
            super.commitProperties();
            if (selectedIndexChanged)
            {
                hiliteSelectedNavItem(_selectedIndex);
                super.selectedIndex = _selectedIndex;
                selectedIndexChanged = false;
            }
            return;
        }// end function

        override protected function hiliteSelectedNavItem(param1:int) : void
        {
            var _loc_2:Button = null;
            var _loc_3:String = null;
            if (selectedIndex != -1 && selectedIndex < numChildren)
            {
                _loc_2 = Button(getChildAt(selectedIndex));
                _loc_2.selected = false;
                _loc_2.getTextField().styleName = _loc_2;
                _loc_2.invalidateDisplayList();
                _loc_2.invalidateSize();
            }
            super.selectedIndex = param1;
            _selectedIndex = param1;
            if (param1 > -1)
            {
                _loc_2 = Button(getChildAt(selectedIndex));
                _loc_2.selected = true;
                _loc_3 = getStyle(selectedButtonTextStyleNameProp);
                _loc_2.getTextField().styleName = _loc_3 ? (_loc_3) : ("activeButtonStyle");
                _loc_2.invalidateDisplayList();
            }
            return;
        }// end function

        override protected function clickHandler(event:MouseEvent) : void
        {
            var _loc_2:* = getChildIndex(Button(event.currentTarget));
            _selectedIndex = _loc_2;
            if (_toggleOnClick && _loc_2 == selectedIndex)
            {
                selectedIndex = -1;
                hiliteSelectedNavItem(-1);
            }
            else
            {
                hiliteSelectedNavItem(_loc_2);
            }
            super.clickHandler(event);
            return;
        }// end function

        override protected function keyDownHandler(event:KeyboardEvent) : void
        {
            var _loc_2:int = -1;
            var _loc_3:Boolean = true;
            var _loc_4:* = numChildren;
            switch(event.keyCode)
            {
                case Keyboard.PAGE_DOWN:
                {
                    _loc_2 = nextIndex(selectedIndex);
                    break;
                }
                case Keyboard.PAGE_UP:
                {
                    if (selectedIndex != -1)
                    {
                        _loc_2 = prevIndex(selectedIndex);
                    }
                    else if (_loc_4 > 0)
                    {
                        _loc_2 = 0;
                    }
                    break;
                }
                case Keyboard.HOME:
                {
                    if (_loc_4 > 0)
                    {
                        _loc_2 = 0;
                    }
                    break;
                }
                case Keyboard.END:
                {
                    if (_loc_4 > 0)
                    {
                        _loc_2 = _loc_4 - 1;
                    }
                    break;
                }
                case Keyboard.SPACE:
                case Keyboard.ENTER:
                {
                    if (focusedIndex != -1)
                    {
                        _loc_2 = focusedIndex;
                        _loc_3 = false;
                    }
                    break;
                }
                default:
                {
                    super.keyDownHandler(event);
                    break;
                }
            }
            if (_loc_2 != -1)
            {
                selectButton(_loc_2, _loc_3, event);
            }
            event.stopPropagation();
            return;
        }// end function

        public function set toggleOnClick(param1:Boolean) : void
        {
            _toggleOnClick = param1;
            return;
        }// end function

        override public function set selectedIndex(param1:int) : void
        {
            if (param1 == selectedIndex && param1 != -1)
            {
                return;
            }
            if (numChildren == 0)
            {
                _selectedIndex = param1;
                selectedIndexChanged = true;
            }
            if (param1 < numChildren)
            {
                _selectedIndex = param1;
                selectedIndexChanged = true;
                invalidateProperties();
                dispatchEvent(new FlexEvent(FlexEvent.VALUE_COMMIT));
            }
            return;
        }// end function

        public function get toggleOnClick() : Boolean
        {
            return _toggleOnClick;
        }// end function

        override public function get selectedIndex() : int
        {
            return super.selectedIndex;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_3:int = 0;
            super.updateDisplayList(param1, param2);
            if (initializeSelectedButton)
            {
                initializeSelectedButton = false;
                _loc_3 = _selectedIndex;
                if (_loc_3 == -2)
                {
                    if (numChildren > 0)
                    {
                        _loc_3 = 0;
                    }
                    else
                    {
                        _loc_3 = -1;
                    }
                }
                hiliteSelectedNavItem(_loc_3);
            }
            return;
        }// end function

    }
}
