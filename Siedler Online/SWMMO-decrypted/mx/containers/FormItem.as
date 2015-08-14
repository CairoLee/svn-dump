package mx.containers
{
    import flash.display.*;
    import flash.events.*;
    import mx.containers.utilityClasses.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.styles.*;

    public class FormItem extends Container
    {
        private var _direction:String = "vertical";
        private var guessedNumColumns:int;
        private var _required:Boolean = false;
        var verticalLayoutObject:BoxLayout;
        private var labelChanged:Boolean = false;
        private var guessedRowWidth:Number;
        private var labelObj:Label;
        private var numberOfGuesses:int = 0;
        private var indicatorObj:IFlexDisplayObject;
        private var _label:String = "";
        static const VERSION:String = "3.5.0.12683";

        public function FormItem()
        {
            verticalLayoutObject = new BoxLayout();
            _horizontalScrollPolicy = ScrollPolicy.OFF;
            _verticalScrollPolicy = ScrollPolicy.OFF;
            verticalLayoutObject.target = this;
            verticalLayoutObject.direction = BoxDirection.VERTICAL;
            return;
        }// end function

        override public function styleChanged(param1:String) : void
        {
            var _loc_3:String = null;
            var _loc_4:CSSStyleDeclaration = null;
            super.styleChanged(param1);
            var _loc_2:* = param1 == null || param1 == "styleName";
            if (_loc_2 || param1 == "labelStyleName")
            {
                if (labelObj)
                {
                    _loc_3 = getStyle("labelStyleName");
                    if (_loc_3)
                    {
                        _loc_4 = StyleManager.getStyleDeclaration("." + _loc_3);
                        if (_loc_4)
                        {
                            labelObj.styleDeclaration = _loc_4;
                            labelObj.regenerateStyleCache(true);
                        }
                    }
                }
            }
            return;
        }// end function

        function getHorizontalAlignValue() : Number
        {
            var _loc_1:* = getStyle("horizontalAlign");
            if (_loc_1 == "center")
            {
                return 0.5;
            }
            if (_loc_1 == "right")
            {
                return 1;
            }
            return 0;
        }// end function

        private function calcNumColumns(param1:Number) : int
        {
            var _loc_7:IUIComponent = null;
            var _loc_8:Number = NaN;
            var _loc_2:Number = 0;
            var _loc_3:Number = 0;
            var _loc_4:* = getStyle("horizontalGap");
            if (direction != FormItemDirection.HORIZONTAL)
            {
                return 1;
            }
            var _loc_5:* = numChildren;
            var _loc_6:int = 0;
            while (_loc_6 < numChildren)
            {
                
                _loc_7 = IUIComponent(getChildAt(_loc_6));
                if (!_loc_7.includeInLayout)
                {
                    _loc_5 = _loc_5 - 1;
                }
                else
                {
                    _loc_8 = _loc_7.getExplicitOrMeasuredWidth();
                    _loc_3 = Math.max(_loc_3, _loc_8);
                    _loc_2 = _loc_2 + _loc_8;
                    if (_loc_6 > 0)
                    {
                        _loc_2 = _loc_2 + _loc_4;
                    }
                }
                _loc_6++;
            }
            if (isNaN(param1) || _loc_2 <= param1)
            {
                return _loc_5;
            }
            if (_loc_3 * 2 <= param1)
            {
                return 2;
            }
            return 1;
        }// end function

        override protected function commitProperties() : void
        {
            super.commitProperties();
            if (labelChanged)
            {
                labelObj.text = label;
                labelObj.validateSize();
                labelChanged = false;
            }
            return;
        }// end function

        function get labelObject() : Object
        {
            return labelObj;
        }// end function

        private function previousUpdateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_10:int = 0;
            var _loc_11:IUIComponent = null;
            var _loc_12:Number = NaN;
            var _loc_13:Number = NaN;
            var _loc_14:Number = NaN;
            var _loc_15:Number = NaN;
            var _loc_16:Number = NaN;
            var _loc_19:Number = NaN;
            var _loc_20:int = 0;
            var _loc_21:Number = NaN;
            var _loc_22:int = 0;
            var _loc_23:Number = NaN;
            var _loc_24:Number = NaN;
            var _loc_25:Number = NaN;
            var _loc_26:Number = NaN;
            super.updateDisplayList(param1, param2);
            var _loc_3:* = viewMetricsAndPadding;
            var _loc_4:* = _loc_3.left;
            var _loc_5:* = _loc_3.top;
            var _loc_6:* = _loc_3.top;
            var _loc_7:* = calculateLabelWidth();
            var _loc_8:* = getStyle("indicatorGap");
            var _loc_9:* = getStyle("horizontalAlign");
            if (getStyle("horizontalAlign") == "right")
            {
                _loc_16 = 1;
            }
            else if (_loc_9 == "center")
            {
                _loc_16 = 0.5;
            }
            else
            {
                _loc_16 = 0;
            }
            var _loc_17:* = numChildren;
            if (numChildren > 0)
            {
                _loc_11 = IUIComponent(getChildAt(0));
                _loc_12 = _loc_11.baselinePosition;
                if (!isNaN(_loc_12))
                {
                    _loc_6 = _loc_6 + (_loc_12 - labelObj.baselinePosition);
                }
            }
            labelObj.setActualSize(_loc_7, labelObj.getExplicitOrMeasuredHeight());
            labelObj.move(_loc_4, _loc_6);
            _loc_4 = _loc_4 + _loc_7;
            displayIndicator(_loc_4, _loc_6);
            _loc_4 = _loc_4 + _loc_8;
            var _loc_18:* = param1 - _loc_3.right - _loc_4;
            if (param1 - _loc_3.right - _loc_4 < 0)
            {
                _loc_18 = 0;
            }
            if (direction == FormItemDirection.HORIZONTAL)
            {
                _loc_19 = 0;
                _loc_20 = calcNumColumns(_loc_18);
                _loc_22 = 0;
                _loc_14 = getStyle("horizontalGap");
                _loc_15 = getStyle("verticalGap");
                if (_loc_20 != guessedNumColumns && numberOfGuesses == 0)
                {
                    guessedRowWidth = _loc_18;
                    numberOfGuesses = 1;
                    invalidateSize();
                }
                else
                {
                    numberOfGuesses = 0;
                }
                if (_loc_20 == _loc_17)
                {
                    _loc_23 = height - (_loc_5 + _loc_3.bottom);
                    _loc_24 = Flex.flexChildWidthsProportionally(this, _loc_18 - (_loc_17 - 1) * _loc_14, _loc_23);
                    _loc_4 = _loc_4 + _loc_24 * _loc_16;
                    _loc_10 = 0;
                    while (_loc_10 < _loc_17)
                    {
                        
                        _loc_11 = IUIComponent(getChildAt(_loc_10));
                        _loc_11.move(Math.floor(_loc_4), _loc_5);
                        _loc_4 = _loc_4 + (_loc_11.width + _loc_14);
                        _loc_10++;
                    }
                }
                else
                {
                    _loc_10 = 0;
                    while (_loc_10 < _loc_17)
                    {
                        
                        _loc_11 = IUIComponent(getChildAt(_loc_10));
                        _loc_19 = Math.max(_loc_19, _loc_11.getExplicitOrMeasuredWidth());
                        _loc_10++;
                    }
                    _loc_25 = _loc_18 - (_loc_20 * _loc_19 + (_loc_20 - 1) * _loc_14);
                    if (_loc_25 < 0)
                    {
                        _loc_25 = 0;
                    }
                    _loc_4 = _loc_4 + _loc_25 * _loc_16;
                    _loc_21 = _loc_4;
                    _loc_10 = 0;
                    while (_loc_10 < _loc_17)
                    {
                        
                        _loc_11 = IUIComponent(getChildAt(_loc_10));
                        _loc_13 = Math.min(_loc_19, _loc_11.getExplicitOrMeasuredWidth());
                        _loc_11.setActualSize(_loc_13, _loc_11.getExplicitOrMeasuredHeight());
                        _loc_11.move(_loc_21, _loc_5);
                        if (++_loc_22 >= _loc_20)
                        {
                            _loc_21 = _loc_4;
                            ++_loc_22 = 0;
                            _loc_5 = _loc_5 + (_loc_11.height + _loc_15);
                        }
                        else
                        {
                            _loc_21 = _loc_21 + (_loc_19 + _loc_14);
                        }
                        _loc_10++;
                    }
                }
            }
            else
            {
                _loc_15 = getStyle("verticalGap");
                _loc_10 = 0;
                while (_loc_10 < _loc_17)
                {
                    
                    _loc_11 = IUIComponent(getChildAt(_loc_10));
                    if (!isNaN(_loc_11.percentWidth))
                    {
                        _loc_13 = Math.floor(_loc_18 * Math.min(_loc_11.percentWidth, 100) / 100);
                    }
                    else
                    {
                        _loc_13 = _loc_11.getExplicitOrMeasuredWidth();
                        if (isNaN(_loc_11.explicitWidth))
                        {
                            if (_loc_13 < Math.floor(_loc_18 * 0.25))
                            {
                                _loc_13 = Math.floor(_loc_18 * 0.25);
                            }
                            else if (_loc_13 < Math.floor(_loc_18 * 0.5))
                            {
                                _loc_13 = Math.floor(_loc_18 * 0.5);
                            }
                            else if (_loc_13 < Math.floor(_loc_18 * 0.75))
                            {
                                _loc_13 = Math.floor(_loc_18 * 0.75);
                            }
                            else if (_loc_13 < Math.floor(_loc_18))
                            {
                                _loc_13 = Math.floor(_loc_18);
                            }
                        }
                    }
                    _loc_11.setActualSize(_loc_13, _loc_11.getExplicitOrMeasuredHeight());
                    _loc_26 = (_loc_18 - _loc_13) * _loc_16;
                    _loc_11.move(_loc_4 + _loc_26, _loc_5);
                    _loc_5 = _loc_5 + _loc_11.height;
                    _loc_5 = _loc_5 + _loc_15;
                    _loc_10++;
                }
            }
            _loc_6 = _loc_3.top;
            if (_loc_17 > 0)
            {
                _loc_11 = IUIComponent(getChildAt(0));
                _loc_12 = _loc_11.baselinePosition;
                if (!isNaN(_loc_12))
                {
                    _loc_6 = _loc_6 + (_loc_12 - labelObj.baselinePosition);
                }
            }
            labelObj.move(labelObj.x, _loc_6);
            return;
        }// end function

        override protected function createChildren() : void
        {
            var _loc_1:String = null;
            var _loc_2:CSSStyleDeclaration = null;
            super.createChildren();
            if (!labelObj)
            {
                labelObj = new FormItemLabel();
                _loc_1 = getStyle("labelStyleName");
                if (_loc_1)
                {
                    _loc_2 = StyleManager.getStyleDeclaration("." + _loc_1);
                    if (_loc_2)
                    {
                        labelObj.styleDeclaration = _loc_2;
                    }
                }
                rawChildren.addChild(labelObj);
                dispatchEvent(new Event("itemLabelChanged"));
            }
            return;
        }// end function

        function getPreferredLabelWidth() : Number
        {
            if (!label || label == "")
            {
                return 0;
            }
            if (isNaN(labelObj.measuredWidth))
            {
                labelObj.validateSize();
            }
            var _loc_1:* = labelObj.measuredWidth;
            if (isNaN(_loc_1))
            {
                return 0;
            }
            return _loc_1;
        }// end function

        override protected function measure() : void
        {
            if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
            {
                previousMeasure();
                return;
            }
            super.measure();
            if (direction == FormItemDirection.VERTICAL)
            {
                measureVertical();
            }
            else
            {
                measureHorizontal();
            }
            return;
        }// end function

        public function get itemLabel() : Label
        {
            return labelObj;
        }// end function

        public function get required() : Boolean
        {
            return _required;
        }// end function

        private function previousMeasure() : void
        {
            var _loc_12:Number = NaN;
            var _loc_13:Number = NaN;
            var _loc_16:int = 0;
            var _loc_17:IUIComponent = null;
            super.measure();
            var _loc_20:* = calcNumColumns(guessedRowWidth);
            guessedNumColumns = calcNumColumns(guessedRowWidth);
            var _loc_1:* = _loc_20;
            var _loc_2:* = getStyle("horizontalGap");
            var _loc_3:* = getStyle("verticalGap");
            var _loc_4:* = getStyle("indicatorGap");
            var _loc_5:int = 0;
            var _loc_6:Number = 0;
            var _loc_7:Number = 0;
            var _loc_8:Number = 0;
            var _loc_9:Number = 0;
            var _loc_10:Number = 0;
            var _loc_11:Number = 0;
            _loc_12 = 0;
            _loc_13 = 0;
            var _loc_14:Number = 0;
            var _loc_15:* = numChildren;
            if (direction == FormItemDirection.HORIZONTAL && _loc_1 < _loc_15)
            {
                _loc_16 = 0;
                while (_loc_16 < _loc_15)
                {
                    
                    _loc_17 = IUIComponent(getChildAt(_loc_16));
                    _loc_14 = Math.max(_loc_14, _loc_17.getExplicitOrMeasuredWidth());
                    _loc_16++;
                }
            }
            _loc_16 = 0;
            while (_loc_16 < _loc_15)
            {
                
                _loc_17 = IUIComponent(getChildAt(_loc_16));
                if (_loc_5 < _loc_1)
                {
                    _loc_6 = _loc_6 + (!isNaN(_loc_17.percentWidth) ? (_loc_17.minWidth) : (_loc_17.getExplicitOrMeasuredWidth()));
                    _loc_7 = _loc_7 + (_loc_14 > 0 ? (_loc_14) : (_loc_17.getExplicitOrMeasuredWidth()));
                    if (_loc_5 > 0)
                    {
                        _loc_6 = _loc_6 + _loc_2;
                        _loc_7 = _loc_7 + _loc_2;
                    }
                    _loc_8 = Math.max(_loc_8, !isNaN(_loc_17.percentHeight) ? (_loc_17.minHeight) : (_loc_17.getExplicitOrMeasuredHeight()));
                    _loc_9 = Math.max(_loc_9, _loc_17.getExplicitOrMeasuredHeight());
                }
                _loc_5++;
                if (_loc_5 >= _loc_1 || _loc_16 == (_loc_15 - 1))
                {
                    _loc_10 = Math.max(_loc_10, _loc_6);
                    _loc_12 = Math.max(_loc_12, _loc_7);
                    _loc_11 = _loc_11 + _loc_8;
                    _loc_13 = _loc_13 + _loc_9;
                    if (_loc_16 > 0)
                    {
                        _loc_11 = _loc_11 + _loc_3;
                        _loc_13 = _loc_13 + _loc_3;
                    }
                    _loc_5 = 0;
                    _loc_6 = 0;
                    _loc_7 = 0;
                    _loc_8 = 0;
                    _loc_9 = 0;
                }
                _loc_16++;
            }
            var _loc_18:* = calculateLabelWidth() + _loc_4;
            _loc_10 = _loc_10 + _loc_18;
            _loc_12 = _loc_12 + _loc_18;
            if (label != null && label != "")
            {
                _loc_11 = Math.max(_loc_11, labelObj.getExplicitOrMeasuredHeight());
                _loc_13 = Math.max(_loc_13, labelObj.getExplicitOrMeasuredHeight());
            }
            var _loc_19:* = viewMetricsAndPadding;
            _loc_11 = _loc_11 + (_loc_19.top + _loc_19.bottom);
            _loc_10 = _loc_10 + (_loc_19.left + _loc_19.right);
            _loc_13 = _loc_13 + (_loc_19.top + _loc_19.bottom);
            _loc_12 = _loc_12 + (_loc_19.left + _loc_19.right);
            measuredMinWidth = _loc_10;
            measuredMinHeight = _loc_11;
            measuredWidth = _loc_12;
            measuredHeight = _loc_13;
            return;
        }// end function

        private function measureHorizontal() : void
        {
            var _loc_10:Number = NaN;
            var _loc_12:Number = NaN;
            var _loc_14:int = 0;
            var _loc_16:IUIComponent = null;
            var _loc_20:* = calcNumColumns(guessedRowWidth);
            guessedNumColumns = calcNumColumns(guessedRowWidth);
            var _loc_1:* = _loc_20;
            var _loc_2:* = getStyle("horizontalGap");
            var _loc_3:* = getStyle("verticalGap");
            var _loc_4:* = getStyle("indicatorGap");
            var _loc_5:Number = 0;
            var _loc_6:Number = 0;
            var _loc_7:Number = 0;
            var _loc_8:Number = 0;
            var _loc_9:Number = 0;
            _loc_10 = 0;
            var _loc_11:Number = 0;
            _loc_12 = 0;
            var _loc_13:Number = 0;
            var _loc_15:int = 0;
            if (_loc_1 < numChildren)
            {
                _loc_14 = 0;
                while (_loc_14 < numChildren)
                {
                    
                    _loc_16 = IUIComponent(getChildAt(_loc_14));
                    if (!_loc_16.includeInLayout)
                    {
                    }
                    else
                    {
                        _loc_13 = Math.max(_loc_13, _loc_16.getExplicitOrMeasuredWidth());
                    }
                    _loc_14++;
                }
            }
            var _loc_17:int = 0;
            _loc_14 = 0;
            while (_loc_14 < numChildren)
            {
                
                _loc_16 = IUIComponent(getChildAt(_loc_14));
                if (!_loc_16.includeInLayout)
                {
                }
                else
                {
                    _loc_5 = _loc_5 + (!isNaN(_loc_16.percentWidth) ? (_loc_16.minWidth) : (_loc_16.getExplicitOrMeasuredWidth()));
                    _loc_6 = _loc_6 + (_loc_13 > 0 ? (_loc_13) : (_loc_16.getExplicitOrMeasuredWidth()));
                    if (_loc_15 > 0)
                    {
                        _loc_5 = _loc_5 + _loc_2;
                        _loc_6 = _loc_6 + _loc_2;
                    }
                    _loc_7 = Math.max(_loc_7, !isNaN(_loc_16.percentHeight) ? (_loc_16.minHeight) : (_loc_16.getExplicitOrMeasuredHeight()));
                    _loc_8 = Math.max(_loc_8, _loc_16.getExplicitOrMeasuredHeight());
                    _loc_15++;
                    if (_loc_15 >= _loc_1 || _loc_14 == (numChildren - 1))
                    {
                        _loc_9 = Math.max(_loc_9, _loc_5);
                        _loc_11 = Math.max(_loc_11, _loc_6);
                        _loc_10 = _loc_10 + _loc_7;
                        _loc_12 = _loc_12 + _loc_8;
                        if (_loc_17 > 0)
                        {
                            _loc_10 = _loc_10 + _loc_3;
                            _loc_12 = _loc_12 + _loc_3;
                        }
                        _loc_15 = 0;
                        _loc_17++;
                        _loc_5 = 0;
                        _loc_6 = 0;
                        _loc_7 = 0;
                        _loc_8 = 0;
                    }
                }
                _loc_14++;
            }
            var _loc_18:* = calculateLabelWidth() + _loc_4;
            _loc_9 = _loc_9 + _loc_18;
            _loc_11 = _loc_11 + _loc_18;
            if (label != null && label != "")
            {
                _loc_10 = Math.max(_loc_10, labelObj.getExplicitOrMeasuredHeight());
                _loc_12 = Math.max(_loc_12, labelObj.getExplicitOrMeasuredHeight());
            }
            var _loc_19:* = viewMetricsAndPadding;
            _loc_10 = _loc_10 + (_loc_19.top + _loc_19.bottom);
            _loc_9 = _loc_9 + (_loc_19.left + _loc_19.right);
            _loc_12 = _loc_12 + (_loc_19.top + _loc_19.bottom);
            _loc_11 = _loc_11 + (_loc_19.left + _loc_19.right);
            measuredMinWidth = _loc_9;
            measuredMinHeight = _loc_10;
            measuredWidth = _loc_11;
            measuredHeight = _loc_12;
            return;
        }// end function

        public function set required(param1:Boolean) : void
        {
            if (param1 != _required)
            {
                _required = param1;
                invalidateDisplayList();
                dispatchEvent(new Event("requiredChanged"));
            }
            return;
        }// end function

        private function updateDisplayListVerticalChildren(param1:Number, param2:Number) : void
        {
            var _loc_5:IUIComponent = null;
            var _loc_3:* = calculateLabelWidth() + getStyle("indicatorGap");
            if (!isNaN(explicitMinWidth))
            {
                _explicitMinWidth = _explicitMinWidth - _loc_3;
            }
            else if (!isNaN(measuredMinWidth))
            {
                measuredMinWidth = measuredMinWidth - _loc_3;
            }
            verticalLayoutObject.updateDisplayList(param1 - _loc_3, param2);
            if (!isNaN(explicitMinWidth))
            {
                _explicitMinWidth = _explicitMinWidth + _loc_3;
            }
            else if (!isNaN(measuredMinWidth))
            {
                measuredMinWidth = measuredMinWidth + _loc_3;
            }
            var _loc_4:* = numChildren;
            var _loc_6:Number = 0;
            while (_loc_6 < _loc_4)
            {
                
                _loc_5 = IUIComponent(getChildAt(_loc_6));
                IUIComponent(getChildAt(_loc_6)).move(_loc_5.x + _loc_3, _loc_5.y);
                _loc_6 = _loc_6 + 1;
            }
            return;
        }// end function

        private function displayIndicator(param1:Number, param2:Number) : void
        {
            var _loc_3:Class = null;
            if (required)
            {
                if (!indicatorObj)
                {
                    _loc_3 = getStyle("indicatorSkin") as Class;
                    indicatorObj = IFlexDisplayObject(new _loc_3);
                    rawChildren.addChild(DisplayObject(indicatorObj));
                }
                indicatorObj.x = param1 + (getStyle("indicatorGap") - indicatorObj.width) / 2;
                if (labelObj)
                {
                    indicatorObj.y = param2 + (labelObj.getExplicitOrMeasuredHeight() - indicatorObj.measuredHeight) / 2;
                }
            }
            else if (indicatorObj)
            {
                rawChildren.removeChild(DisplayObject(indicatorObj));
                indicatorObj = null;
            }
            return;
        }// end function

        override public function set label(param1:String) : void
        {
            _label = param1;
            labelChanged = true;
            invalidateProperties();
            invalidateSize();
            invalidateDisplayList();
            if (parent is Form)
            {
                Form(parent).invalidateLabelWidth();
            }
            dispatchEvent(new Event("labelChanged"));
            return;
        }// end function

        private function updateDisplayListHorizontalChildren(param1:Number, param2:Number) : void
        {
            var _loc_17:int = 0;
            var _loc_18:IUIComponent = null;
            var _loc_19:Number = NaN;
            var _loc_20:Number = NaN;
            var _loc_27:Number = NaN;
            var _loc_28:Number = NaN;
            var _loc_29:Number = NaN;
            var _loc_30:Number = NaN;
            var _loc_32:Number = NaN;
            var _loc_33:Number = NaN;
            var _loc_34:Number = NaN;
            var _loc_35:Number = NaN;
            var _loc_36:Number = NaN;
            var _loc_37:Number = NaN;
            var _loc_38:Number = NaN;
            var _loc_39:Boolean = false;
            var _loc_40:Array = null;
            var _loc_41:Number = NaN;
            var _loc_42:* = undefined;
            var _loc_43:* = undefined;
            var _loc_44:* = undefined;
            var _loc_3:* = viewMetricsAndPadding;
            var _loc_4:* = calculateLabelWidth();
            var _loc_5:* = getStyle("indicatorGap");
            var _loc_6:* = getStyle("horizontalGap");
            var _loc_7:* = getStyle("verticalGap");
            var _loc_8:* = getStyle("paddingLeft");
            var _loc_9:* = getStyle("paddingTop");
            var _loc_10:* = getHorizontalAlignValue();
            var _loc_11:* = scaleX > 0 && scaleX != 1 ? (minWidth / Math.abs(scaleX)) : (minWidth);
            var _loc_12:* = scaleY > 0 && scaleY != 1 ? (minHeight / Math.abs(scaleY)) : (minHeight);
            var _loc_13:* = Math.max(param1, _loc_11) - _loc_3.left - _loc_3.right;
            var _loc_14:* = Math.max(param2, _loc_12) - _loc_3.top - _loc_3.bottom;
            var _loc_15:Number = 0;
            var _loc_16:* = _loc_13 - _loc_4 - _loc_5;
            if (_loc_13 - _loc_4 - _loc_5 < 0)
            {
                _loc_16 = 0;
            }
            var _loc_21:* = calcNumColumns(_loc_16);
            var _loc_22:int = 0;
            if (_loc_21 != guessedNumColumns && isNaN(explicitWidth))
            {
                if (numberOfGuesses < 2)
                {
                    guessedRowWidth = _loc_16;
                    var _loc_46:* = numberOfGuesses + 1;
                    numberOfGuesses = _loc_46;
                    invalidateSize();
                    return;
                }
                _loc_21 = guessedNumColumns;
                numberOfGuesses = 0;
            }
            else
            {
                numberOfGuesses = 0;
            }
            var _loc_23:* = _loc_8 + _loc_4 + _loc_5;
            var _loc_24:* = _loc_9;
            var _loc_25:* = _loc_23;
            var _loc_26:* = _loc_24;
            var _loc_31:* = numChildren;
            _loc_17 = 0;
            while (_loc_17 < numChildren)
            {
                
                if (!IUIComponent(getChildAt(_loc_17)).includeInLayout)
                {
                    _loc_31 = _loc_31 - 1;
                }
                _loc_17++;
            }
            if (_loc_21 == _loc_31)
            {
                _loc_32 = Flex.flexChildWidthsProportionally(this, _loc_16 - (_loc_31 - 1) * _loc_6, _loc_14);
                _loc_23 = _loc_23 + _loc_32 * _loc_10;
                _loc_17 = 0;
                while (_loc_17 < numChildren)
                {
                    
                    _loc_18 = IUIComponent(getChildAt(_loc_17));
                    if (!_loc_18.includeInLayout)
                    {
                    }
                    else
                    {
                        _loc_18.move(Math.floor(_loc_23), _loc_24);
                        _loc_23 = _loc_23 + (_loc_18.width + _loc_6);
                    }
                    _loc_17++;
                }
            }
            else
            {
                _loc_17 = 0;
                while (_loc_17 < numChildren)
                {
                    
                    _loc_18 = IUIComponent(getChildAt(_loc_17));
                    if (!_loc_18.includeInLayout)
                    {
                    }
                    else
                    {
                        _loc_27 = _loc_18.getExplicitOrMeasuredWidth();
                        _loc_29 = _loc_18.percentWidth;
                        _loc_19 = !isNaN(_loc_29) ? (_loc_29 * _loc_16 / 100) : (_loc_27);
                        _loc_19 = Math.max(_loc_18.minWidth, Math.min(_loc_18.maxWidth, _loc_19));
                        _loc_15 = Math.max(_loc_15, _loc_19);
                    }
                    _loc_17++;
                }
                _loc_15 = Math.min(_loc_15, Math.floor((_loc_16 - (_loc_21 - 1) * _loc_6) / _loc_21));
                _loc_33 = _loc_16 - (_loc_21 * _loc_15 + (_loc_21 - 1) * _loc_6);
                if (_loc_33 < 0)
                {
                    _loc_33 = 0;
                }
                _loc_23 = _loc_23 + _loc_33 * _loc_10;
                _loc_34 = 0;
                _loc_35 = 0;
                _loc_36 = 0;
                _loc_37 = _loc_14;
                _loc_38 = _loc_37;
                _loc_22 = 0;
                _loc_17 = 0;
                while (_loc_17 < numChildren)
                {
                    
                    _loc_18 = IUIComponent(getChildAt(_loc_17));
                    if (!_loc_18.includeInLayout)
                    {
                        if (_loc_17 == (numChildren - 1))
                        {
                            _loc_38 = _loc_38 - _loc_35;
                            if (_loc_17 != (numChildren - 1))
                            {
                                _loc_38 = _loc_38 - _loc_7;
                            }
                            if (_loc_35 > 0 && _loc_34 > 0)
                            {
                                _loc_34 = Math.max(0, _loc_34 - 100 * _loc_35 / _loc_37);
                            }
                            _loc_36 = _loc_36 + _loc_34;
                            _loc_35 = 0;
                            _loc_34 = 0;
                            _loc_22 = 0;
                        }
                    }
                    else
                    {
                        if (!isNaN(_loc_18.percentHeight))
                        {
                            _loc_34 = Math.max(_loc_34, _loc_18.percentHeight);
                        }
                        else
                        {
                            _loc_35 = Math.max(_loc_35, _loc_18.getExplicitOrMeasuredHeight());
                        }
                        if (++_loc_22 >= _loc_21 || _loc_17 == (numChildren - 1))
                        {
                            _loc_38 = _loc_38 - _loc_35;
                            if (_loc_17 != (numChildren - 1))
                            {
                                _loc_38 = _loc_38 - _loc_7;
                            }
                            if (_loc_35 > 0 && _loc_34 > 0)
                            {
                                _loc_34 = Math.max(0, _loc_34 - 100 * _loc_35 / _loc_37);
                            }
                            _loc_36 = _loc_36 + _loc_34;
                            _loc_35 = 0;
                            _loc_34 = 0;
                            ++_loc_22 = 0;
                        }
                    }
                    _loc_17++;
                }
                _loc_39 = false;
                _loc_40 = new Array(numChildren);
                _loc_17 = 0;
                while (_loc_17 < numChildren)
                {
                    
                    _loc_40[_loc_17] = -1;
                    _loc_17++;
                }
                _loc_41 = _loc_38 - _loc_37 * _loc_36 / 100;
                if (_loc_41 > 0)
                {
                    _loc_38 = _loc_38 - _loc_41;
                }
                do
                {
                    
                    _loc_39 = true;
                    _loc_42 = _loc_38 / _loc_36;
                    ++_loc_22 = 0;
                    _loc_25 = _loc_23;
                    _loc_26 = _loc_24;
                    _loc_43 = 0;
                    _loc_17 = 0;
                    while (_loc_17 < numChildren)
                    {
                        
                        _loc_18 = IUIComponent(getChildAt(_loc_17));
                        if (!_loc_18.includeInLayout)
                        {
                        }
                        else
                        {
                            _loc_27 = _loc_18.getExplicitOrMeasuredWidth();
                            _loc_28 = _loc_18.getExplicitOrMeasuredHeight();
                            _loc_29 = _loc_18.percentWidth;
                            _loc_30 = _loc_18.percentHeight;
                            _loc_19 = Math.min(_loc_15, !isNaN(_loc_29) ? (_loc_29 * _loc_16 / 100) : (_loc_27));
                            _loc_19 = Math.max(_loc_18.minWidth, Math.min(_loc_18.maxWidth, _loc_19));
                            if (_loc_40[_loc_17] != -1)
                            {
                                _loc_20 = _loc_40[_loc_17];
                            }
                            else
                            {
                                _loc_20 = !isNaN(_loc_30) ? (_loc_30 * _loc_42) : (_loc_28);
                                if (_loc_20 < _loc_18.minHeight)
                                {
                                    _loc_20 = _loc_18.minHeight;
                                    _loc_36 = _loc_36 - _loc_18.percentHeight;
                                    _loc_38 = _loc_38 - _loc_20;
                                    _loc_40[_loc_17] = _loc_20;
                                    _loc_39 = false;
                                    break;
                                }
                                else if (_loc_20 > _loc_18.maxHeight)
                                {
                                    _loc_20 = _loc_18.maxHeight;
                                    _loc_36 = _loc_36 - _loc_18.percentHeight;
                                    _loc_38 = _loc_38 - _loc_20;
                                    _loc_40[_loc_17] = _loc_20;
                                    _loc_39 = false;
                                    break;
                                }
                            }
                            if (_loc_18.scaleX == 1 && _loc_18.scaleY == 1)
                            {
                                _loc_18.setActualSize(Math.floor(_loc_19), Math.floor(_loc_20));
                            }
                            else
                            {
                                _loc_18.setActualSize(_loc_19, _loc_20);
                            }
                            _loc_44 = (_loc_15 - _loc_18.width) * _loc_10;
                            _loc_18.move(Math.floor(_loc_25 + _loc_44), Math.floor(_loc_26));
                            _loc_43 = Math.max(_loc_43, _loc_18.height);
                            _loc_22 = ++_loc_22 + 1;
                            if (++_loc_22 + 1 >= _loc_21)
                            {
                                _loc_25 = _loc_23;
                                _loc_22 = 0;
                                _loc_26 = _loc_26 + (_loc_43 + _loc_7);
                                _loc_43 = 0;
                            }
                            else
                            {
                                _loc_25 = _loc_25 + (_loc_15 + _loc_6);
                            }
                        }
                        _loc_17++;
                    }
                }while (!_loc_39)
            }
            return;
        }// end function

        override public function get label() : String
        {
            return _label;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_7:IUIComponent = null;
            var _loc_8:Number = NaN;
            if (FlexVersion.compatibilityVersion < FlexVersion.VERSION_3_0)
            {
                previousUpdateDisplayList(param1, param2);
                return;
            }
            super.updateDisplayList(param1, param2);
            if (direction == FormItemDirection.VERTICAL)
            {
                updateDisplayListVerticalChildren(param1, param2);
            }
            else
            {
                updateDisplayListHorizontalChildren(param1, param2);
            }
            var _loc_3:* = viewMetricsAndPadding;
            var _loc_4:* = _loc_3.left;
            var _loc_5:* = _loc_3.top;
            var _loc_6:* = calculateLabelWidth();
            if (numChildren > 0)
            {
                _loc_7 = IUIComponent(getChildAt(0));
                _loc_8 = _loc_7.baselinePosition;
                if (!isNaN(_loc_8))
                {
                    _loc_5 = _loc_5 + (_loc_8 - labelObj.baselinePosition);
                }
            }
            labelObj.setActualSize(_loc_6, labelObj.getExplicitOrMeasuredHeight());
            labelObj.move(_loc_4, _loc_5);
            _loc_4 = _loc_4 + _loc_6;
            displayIndicator(_loc_4, _loc_5);
            return;
        }// end function

        private function calculateLabelWidth() : Number
        {
            var _loc_1:* = getStyle("labelWidth");
            if (_loc_1 == 0)
            {
                _loc_1 = NaN;
            }
            if (isNaN(_loc_1) && parent is Form)
            {
                _loc_1 = Form(parent).calculateLabelWidth();
            }
            if (isNaN(_loc_1))
            {
                _loc_1 = getPreferredLabelWidth();
            }
            return _loc_1;
        }// end function

        private function measureVertical() : void
        {
            var _loc_2:Number = NaN;
            verticalLayoutObject.measure();
            var _loc_1:* = calculateLabelWidth() + getStyle("indicatorGap");
            measuredMinWidth = measuredMinWidth + _loc_1;
            measuredWidth = measuredWidth + _loc_1;
            _loc_2 = labelObj.getExplicitOrMeasuredHeight();
            measuredMinHeight = Math.max(measuredMinHeight, _loc_2);
            measuredHeight = Math.max(measuredHeight, _loc_2);
            return;
        }// end function

        public function set direction(param1:String) : void
        {
            _direction = param1;
            invalidateSize();
            invalidateDisplayList();
            dispatchEvent(new Event("directionChanged"));
            return;
        }// end function

        public function get direction() : String
        {
            return _direction;
        }// end function

    }
}
