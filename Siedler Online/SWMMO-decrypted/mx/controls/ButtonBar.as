package mx.controls
{
    import flash.display.*;
    import flash.events.*;
    import flash.ui.*;
    import mx.containers.*;
    import mx.controls.buttonBarClasses.*;
    import mx.core.*;
    import mx.events.*;
    import mx.managers.*;
    import mx.styles.*;

    public class ButtonBar extends NavBar implements IFocusManagerComponent
    {
        var simulatedClickTriggerEvent:Event = null;
        var focusedIndex:int = 0;
        private var directionChanged:Boolean = false;
        var buttonWidthProp:String = "buttonWidth";
        private var oldUnscaledHeight:Number;
        var buttonStyleNameProp:String = "buttonStyleName";
        var lastButtonStyleNameProp:String = "lastButtonStyleName";
        private var recalcButtonWidths:Boolean = false;
        private var oldUnscaledWidth:Number;
        private var recalcButtonHeights:Boolean = false;
        var buttonHeightProp:String = "buttonHeight";
        var firstButtonStyleNameProp:String = "firstButtonStyleName";
        static const VERSION:String = "3.5.0.12683";

        public function ButtonBar()
        {
            tabEnabled = true;
            navItemFactory = new ClassFactory(ButtonBarButton);
            addEventListener("scaleXChanged", scaleChangedHandler);
            addEventListener("scaleYChanged", scaleChangedHandler);
            addEventListener(ChildExistenceChangedEvent.CHILD_REMOVE, childRemoveHandler);
            return;
        }// end function

        override public function get borderMetrics() : EdgeMetrics
        {
            return EdgeMetrics.EMPTY;
        }// end function

        protected function resetButtonHeights() : void
        {
            var _loc_2:Button = null;
            var _loc_1:int = 0;
            while (_loc_1 < numChildren)
            {
                
                _loc_2 = getChildAt(_loc_1) as Button;
                if (_loc_2)
                {
                    _loc_2.explicitHeight = NaN;
                    _loc_2.minHeight = NaN;
                    _loc_2.maxHeight = NaN;
                }
                _loc_1++;
            }
            return;
        }// end function

        override protected function keyUpHandler(event:KeyboardEvent) : void
        {
            var _loc_2:Button = null;
            if (event.eventPhase != EventPhase.AT_TARGET)
            {
                return;
            }
            switch(event.keyCode)
            {
                case Keyboard.SPACE:
                {
                    if (focusedIndex != -1)
                    {
                        _loc_2 = Button(getChildAt(focusedIndex));
                        _loc_2.dispatchEvent(event);
                    }
                    event.stopPropagation();
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        function nextIndex(param1:int) : int
        {
            var _loc_2:* = numChildren;
            if (_loc_2 == 0)
            {
                return -1;
            }
            return param1 == (_loc_2 - 1) ? (0) : ((param1 + 1));
        }// end function

        private function calcFullWidth() : Number
        {
            var _loc_6:Number = NaN;
            var _loc_8:Number = NaN;
            var _loc_1:* = numChildren;
            var _loc_2:Number = 0;
            if (_loc_1 == 0)
            {
                return 0;
            }
            if (_loc_1 > 1)
            {
                _loc_2 = getStyle("horizontalGap");
            }
            var _loc_3:* = direction == BoxDirection.HORIZONTAL;
            var _loc_4:* = getStyle(buttonWidthProp);
            var _loc_5:* = IUIComponent(getChildAt(0));
            if (_loc_4)
            {
                _loc_6 = isNaN(_loc_5.explicitWidth) ? (_loc_4) : (_loc_5.explicitWidth);
            }
            else
            {
                _loc_6 = _loc_5.getExplicitOrMeasuredWidth();
            }
            var _loc_7:int = 1;
            while (_loc_7 < _loc_1)
            {
                
                _loc_5 = IUIComponent(getChildAt(_loc_7));
                if (_loc_4)
                {
                    _loc_8 = isNaN(_loc_5.explicitWidth) ? (_loc_4) : (_loc_5.explicitWidth);
                }
                else
                {
                    _loc_8 = _loc_5.getExplicitOrMeasuredWidth();
                }
                if (_loc_3)
                {
                    _loc_6 = _loc_6 + (_loc_2 + _loc_8);
                }
                else
                {
                    _loc_6 = Math.max(_loc_6, _loc_8);
                }
                _loc_7++;
            }
            return _loc_6;
        }// end function

        override protected function clickHandler(event:MouseEvent) : void
        {
            if (simulatedClickTriggerEvent == null)
            {
                focusedIndex = getChildIndex(DisplayObject(event.currentTarget));
                drawButtonFocus(focusedIndex, true);
            }
            super.clickHandler(event);
            return;
        }// end function

        override protected function createNavItem(param1:String, param2:Class = null) : IFlexDisplayObject
        {
            var _loc_3:* = Button(navItemFactory.newInstance());
            _loc_3.focusEnabled = false;
            _loc_3.label = param1;
            _loc_3.setStyle("icon", param2);
            _loc_3.addEventListener(MouseEvent.CLICK, clickHandler);
            addChild(_loc_3);
            var _loc_4:Boolean = true;
            recalcButtonHeights = true;
            recalcButtonWidths = _loc_4;
            return _loc_3;
        }// end function

        override public function styleChanged(param1:String) : void
        {
            var _loc_2:* = param1 == null || param1 == "styleName";
            super.styleChanged(param1);
            if (_loc_2 || param1 == buttonStyleNameProp || param1 == firstButtonStyleNameProp || param1 == lastButtonStyleNameProp)
            {
                resetNavItems();
            }
            else if (param1 == buttonWidthProp)
            {
                recalcButtonWidths = true;
            }
            else if (param1 == buttonHeightProp)
            {
                recalcButtonHeights = true;
            }
            else if (StyleManager.isInheritingStyle(param1) && StyleManager.isSizeInvalidatingStyle(param1))
            {
                var _loc_3:Boolean = true;
                recalcButtonHeights = true;
                recalcButtonWidths = _loc_3;
            }
            return;
        }// end function

        protected function resetButtonWidths() : void
        {
            var _loc_2:Button = null;
            var _loc_1:int = 0;
            while (_loc_1 < numChildren)
            {
                
                _loc_2 = getChildAt(_loc_1) as Button;
                if (_loc_2)
                {
                    _loc_2.explicitWidth = NaN;
                    _loc_2.minWidth = NaN;
                    _loc_2.maxWidth = NaN;
                }
                _loc_1++;
            }
            return;
        }// end function

        override protected function commitProperties() : void
        {
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            super.commitProperties();
            if (directionChanged)
            {
                directionChanged = false;
                _loc_1 = numChildren;
                _loc_2 = 0;
                while (_loc_2 < _loc_1)
                {
                    
                    Button(getChildAt(_loc_2)).changeSkins();
                    _loc_2++;
                }
            }
            if (recalcButtonHeights)
            {
                resetButtonHeights();
            }
            if (recalcButtonWidths)
            {
                resetButtonWidths();
            }
            return;
        }// end function

        private function calcFullHeight() : Number
        {
            var _loc_2:Number = NaN;
            var _loc_6:Number = NaN;
            var _loc_8:Number = NaN;
            var _loc_1:* = numChildren;
            if (_loc_1 == 0)
            {
                return 0;
            }
            if (_loc_1 > 1)
            {
                _loc_2 = getStyle("verticalGap");
            }
            var _loc_3:* = direction == BoxDirection.VERTICAL;
            var _loc_4:* = getStyle(buttonHeightProp);
            var _loc_5:* = IUIComponent(getChildAt(0));
            if (_loc_4)
            {
                _loc_6 = isNaN(_loc_5.explicitHeight) ? (_loc_4) : (_loc_5.explicitHeight);
            }
            else
            {
                _loc_6 = _loc_5.getExplicitOrMeasuredHeight();
            }
            var _loc_7:int = 1;
            while (_loc_7 < _loc_1)
            {
                
                _loc_5 = IUIComponent(getChildAt(_loc_7));
                if (_loc_4)
                {
                    _loc_8 = isNaN(_loc_5.explicitHeight) ? (_loc_4) : (_loc_5.explicitHeight);
                }
                else
                {
                    _loc_8 = _loc_5.getExplicitOrMeasuredHeight();
                }
                if (_loc_3)
                {
                    _loc_6 = _loc_6 + (_loc_2 + _loc_8);
                }
                else
                {
                    _loc_6 = Math.max(_loc_6, _loc_8);
                }
                _loc_7++;
            }
            return _loc_6;
        }// end function

        override protected function resetNavItems() : void
        {
            var _loc_4:Button = null;
            var _loc_1:* = getStyle(buttonStyleNameProp);
            var _loc_2:* = getStyle(firstButtonStyleNameProp);
            var _loc_3:* = getStyle(lastButtonStyleNameProp);
            if (!_loc_1)
            {
                _loc_1 = "ButtonBarButton";
            }
            if (!_loc_2)
            {
                _loc_2 = _loc_1;
            }
            if (!_loc_3)
            {
                _loc_3 = _loc_1;
            }
            var _loc_5:* = numChildren;
            var _loc_6:int = 0;
            while (_loc_6 < _loc_5)
            {
                
                _loc_4 = Button(getChildAt(_loc_6));
                if (_loc_6 == 0)
                {
                    _loc_4.styleName = _loc_2;
                }
                else if (_loc_6 == (_loc_5 - 1))
                {
                    _loc_4.styleName = _loc_3;
                }
                else
                {
                    _loc_4.styleName = _loc_1;
                }
                _loc_4.changeSkins();
                _loc_4.invalidateDisplayList();
                _loc_6++;
            }
            var _loc_7:Boolean = true;
            recalcButtonHeights = true;
            recalcButtonWidths = _loc_7;
            invalidateDisplayList();
            return;
        }// end function

        override public function get viewMetrics() : EdgeMetrics
        {
            return EdgeMetrics.EMPTY;
        }// end function

        function prevIndex(param1:int) : int
        {
            var _loc_2:* = numChildren;
            return param1 == 0 ? ((_loc_2 - 1)) : ((param1 - 1));
        }// end function

        private function scaleChangedHandler(event:Event) : void
        {
            resetButtonHeights();
            resetButtonWidths();
            return;
        }// end function

        function drawButtonFocus(param1:int, param2:Boolean) : void
        {
            var _loc_3:Button = null;
            if (numChildren > 0 && param1 < numChildren)
            {
                _loc_3 = Button(getChildAt(param1));
                _loc_3.drawFocus(param2 && focusManager.showFocusIndicator);
                if (param2)
                {
                    dispatchEvent(new Event("focusDraw"));
                }
                if (!param2 && _loc_3.phase != ButtonPhase.UP)
                {
                    _loc_3.phase = ButtonPhase.UP;
                }
            }
            return;
        }// end function

        override protected function keyDownHandler(event:KeyboardEvent) : void
        {
            var _loc_2:Button = null;
            if (event.eventPhase != EventPhase.AT_TARGET)
            {
                return;
            }
            switch(event.keyCode)
            {
                case Keyboard.DOWN:
                case Keyboard.RIGHT:
                {
                    focusManager.showFocusIndicator = true;
                    drawButtonFocus(focusedIndex, false);
                    focusedIndex = nextIndex(focusedIndex);
                    if (focusedIndex != -1)
                    {
                        drawButtonFocus(focusedIndex, true);
                    }
                    event.stopPropagation();
                    break;
                }
                case Keyboard.UP:
                case Keyboard.LEFT:
                {
                    focusManager.showFocusIndicator = true;
                    drawButtonFocus(focusedIndex, false);
                    focusedIndex = prevIndex(focusedIndex);
                    if (focusedIndex != -1)
                    {
                        drawButtonFocus(focusedIndex, true);
                    }
                    event.stopPropagation();
                    break;
                }
                case Keyboard.SPACE:
                {
                    if (focusedIndex != -1)
                    {
                        _loc_2 = Button(getChildAt(focusedIndex));
                        _loc_2.dispatchEvent(event);
                    }
                    event.stopPropagation();
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        override protected function measure() : void
        {
            var _loc_1:EdgeMetrics = null;
            super.measure();
            _loc_1 = viewMetricsAndPadding;
            measuredWidth = calcFullWidth() + _loc_1.left + _loc_1.right;
            measuredHeight = calcFullHeight() + _loc_1.top + _loc_1.bottom;
            if (getStyle(buttonWidthProp))
            {
                measuredMinWidth = measuredWidth;
            }
            if (getStyle(buttonHeightProp))
            {
                measuredMinHeight = measuredHeight;
            }
            return;
        }// end function

        private function childRemoveHandler(event:ChildExistenceChangedEvent) : void
        {
            var _loc_8:Button = null;
            var _loc_2:* = event.relatedObject;
            var _loc_3:* = getChildIndex(_loc_2);
            var _loc_4:* = numChildren;
            if (numChildren < 2)
            {
                return;
            }
            var _loc_5:* = getStyle(buttonStyleNameProp);
            var _loc_6:* = getStyle(firstButtonStyleNameProp);
            var _loc_7:* = getStyle(lastButtonStyleNameProp);
            if (!_loc_5)
            {
                _loc_5 = "buttonBarButtonStyle";
            }
            if (!_loc_6)
            {
                _loc_6 = _loc_5;
            }
            if (!_loc_7)
            {
                _loc_7 = _loc_5;
            }
            if (_loc_3 == 0 || _loc_3 == (_loc_4 - 1))
            {
                _loc_8 = Button(getChildAt(_loc_3 == (_loc_4 - 1) ? (_loc_4 - 2) : (0)));
                _loc_8.styleName = _loc_3 == 0 ? (_loc_6) : (_loc_7);
                _loc_8.changeSkins();
                _loc_8.invalidateDisplayList();
            }
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_3:Boolean = false;
            var _loc_16:int = 0;
            var _loc_17:Button = null;
            var _loc_18:Number = NaN;
            var _loc_19:int = 0;
            var _loc_20:int = 0;
            var _loc_21:Number = NaN;
            var _loc_22:int = 0;
            var _loc_23:int = 0;
            var _loc_24:int = 0;
            var _loc_25:Number = NaN;
            _loc_3 = direction == BoxDirection.HORIZONTAL;
            var _loc_4:* = !_loc_3;
            var _loc_5:* = getStyle(buttonWidthProp);
            var _loc_6:* = getStyle(buttonHeightProp);
            var _loc_7:* = getStyle(buttonHeightProp);
            var _loc_8:* = viewMetricsAndPadding;
            var _loc_9:* = numChildren;
            var _loc_10:* = getStyle("horizontalGap");
            var _loc_11:* = getStyle("verticalGap");
            var _loc_12:* = _loc_3 && numChildren > 0 ? (_loc_10 * (_loc_9 - 1)) : (0);
            var _loc_13:* = _loc_4 && numChildren > 0 ? (_loc_11 * (_loc_9 - 1)) : (0);
            var _loc_14:* = param1 - _loc_8.left - _loc_8.right - _loc_12;
            var _loc_15:* = param2 - _loc_8.top - _loc_8.bottom - _loc_13;
            if (!_loc_14 || !_loc_15)
            {
                return;
            }
            if (border)
            {
                border.visible = false;
            }
            if (param1 != oldUnscaledWidth)
            {
                recalcButtonWidths = true;
                oldUnscaledWidth = param1;
            }
            if (param2 != oldUnscaledHeight)
            {
                recalcButtonHeights = true;
                oldUnscaledHeight = param2;
            }
            if (recalcButtonWidths)
            {
                recalcButtonWidths = false;
                if (isNaN(_loc_5) && _loc_4)
                {
                    _loc_5 = _loc_14;
                }
                _loc_18 = _loc_14 - (calcFullWidth() - _loc_12);
                _loc_19 = _loc_9 > 0 ? (_loc_14 / _loc_9) : (0);
                _loc_20 = 0;
                _loc_21 = 0;
                _loc_22 = 0;
                if (_loc_18 != 0 && _loc_3)
                {
                    _loc_16 = 0;
                    while (_loc_16 < _loc_9)
                    {
                        
                        _loc_17 = Button(getChildAt(_loc_16));
                        if (isNaN(_loc_17.explicitWidth))
                        {
                            _loc_23 = _loc_17.measuredWidth;
                            _loc_21 = _loc_21 + _loc_23;
                            if (_loc_23 > _loc_19)
                            {
                                _loc_20++;
                            }
                            else
                            {
                                _loc_22 = _loc_22 + _loc_23;
                            }
                        }
                        _loc_16++;
                    }
                }
                else
                {
                    _loc_21 = _loc_14;
                }
                _loc_16 = 0;
                while (_loc_16 < _loc_9)
                {
                    
                    _loc_17 = Button(getChildAt(_loc_16));
                    if (isNaN(_loc_17.explicitWidth))
                    {
                        _loc_17.minWidth = 0;
                        if (!isNaN(_loc_5))
                        {
                            var _loc_26:* = _loc_5;
                            _loc_17.maxWidth = _loc_5;
                            _loc_17.minWidth = _loc_26;
                            _loc_17.percentWidth = _loc_5 / Math.min(_loc_14, _loc_21) * 100;
                        }
                        else if (_loc_18 < 0)
                        {
                            _loc_24 = _loc_17.measuredWidth;
                            if (_loc_24 > _loc_19)
                            {
                                _loc_24 = (_loc_14 - _loc_22) / _loc_20;
                            }
                            _loc_17.percentWidth = Number(_loc_24) / _loc_14 * 100;
                        }
                        else if (_loc_18 > 0)
                        {
                            _loc_17.percentWidth = _loc_17.measuredWidth / _loc_21 * 100;
                        }
                        else
                        {
                            _loc_17.percentWidth = NaN;
                        }
                        if (_loc_4)
                        {
                            _loc_17.percentWidth = 100;
                        }
                    }
                    _loc_16++;
                }
            }
            if (recalcButtonHeights)
            {
                recalcButtonHeights = false;
                if (isNaN(_loc_7) && _loc_3)
                {
                    _loc_7 = _loc_15;
                }
                _loc_18 = _loc_15 - (calcFullHeight() - _loc_13);
                _loc_25 = 0;
                if (_loc_18 != 0 && _loc_4)
                {
                    _loc_16 = 0;
                    while (_loc_16 < _loc_9)
                    {
                        
                        _loc_17 = Button(getChildAt(_loc_16));
                        if (isNaN(_loc_17.explicitHeight))
                        {
                            _loc_25 = _loc_25 + _loc_17.measuredHeight;
                        }
                        _loc_16++;
                    }
                }
                _loc_16 = 0;
                while (_loc_16 < _loc_9)
                {
                    
                    _loc_17 = Button(getChildAt(_loc_16));
                    if (isNaN(_loc_17.explicitHeight))
                    {
                        _loc_17.minHeight = 0;
                        if (!isNaN(_loc_7))
                        {
                            _loc_17.minHeight = _loc_7;
                            _loc_17.percentHeight = _loc_7 / Math.min(_loc_25, _loc_15) * 100;
                        }
                        if (!isNaN(_loc_6))
                        {
                            _loc_17.maxHeight = _loc_6;
                        }
                        if (_loc_3)
                        {
                            _loc_17.percentHeight = 100;
                        }
                        else if (_loc_18 < 0)
                        {
                            _loc_17.percentHeight = _loc_17.measuredHeight / _loc_25 * 100;
                        }
                        else if (_loc_18 > 0)
                        {
                            _loc_17.percentHeight = _loc_17.measuredHeight / _loc_25 * 100;
                        }
                        else
                        {
                            _loc_17.percentHeight = NaN;
                        }
                    }
                    _loc_16++;
                }
            }
            super.updateDisplayList(param1, param2);
            return;
        }// end function

        override public function drawFocus(param1:Boolean) : void
        {
            drawButtonFocus(focusedIndex, param1);
            return;
        }// end function

        override public function set direction(param1:String) : void
        {
            if (initialized && param1 != direction)
            {
                directionChanged = true;
                invalidateProperties();
            }
            super.direction = param1;
            return;
        }// end function

    }
}
