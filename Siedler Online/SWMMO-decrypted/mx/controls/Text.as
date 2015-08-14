package mx.controls
{
    import mx.core.*;
    import mx.events.*;

    public class Text extends Label
    {
        private var widthChanged:Boolean = true;
        private var lastUnscaledWidth:Number = NaN;
        static const VERSION:String = "3.5.0.12683";

        public function Text()
        {
            selectable = true;
            truncateToFit = false;
            addEventListener(FlexEvent.UPDATE_COMPLETE, updateCompleteHandler);
            return;
        }// end function

        private function measureUsingWidth(param1:Number) : void
        {
            var _loc_6:Boolean = false;
            var _loc_2:* = getStyle("paddingLeft");
            var _loc_3:* = getStyle("paddingTop");
            var _loc_4:* = getStyle("paddingRight");
            var _loc_5:* = getStyle("paddingBottom");
            textField.validateNow();
            textField.autoSize = "left";
            if (!isNaN(param1))
            {
                textField.width = param1 - _loc_2 - _loc_4;
                measuredWidth = Math.ceil(textField.textWidth) + UITextField.TEXT_WIDTH_PADDING;
                measuredHeight = Math.ceil(textField.textHeight) + UITextField.TEXT_HEIGHT_PADDING;
            }
            else
            {
                _loc_6 = textField.wordWrap;
                textField.wordWrap = false;
                measuredWidth = Math.ceil(textField.textWidth) + UITextField.TEXT_WIDTH_PADDING;
                measuredHeight = Math.ceil(textField.textHeight) + UITextField.TEXT_HEIGHT_PADDING;
                textField.wordWrap = _loc_6;
            }
            textField.autoSize = "none";
            measuredWidth = measuredWidth + (_loc_2 + _loc_4);
            measuredHeight = measuredHeight + (_loc_3 + _loc_5);
            if (isNaN(explicitWidth))
            {
                measuredMinWidth = DEFAULT_MEASURED_MIN_WIDTH;
                measuredMinHeight = DEFAULT_MEASURED_MIN_HEIGHT;
            }
            else
            {
                measuredMinWidth = measuredWidth;
                measuredMinHeight = measuredHeight;
            }
            return;
        }// end function

        override public function set percentWidth(param1:Number) : void
        {
            if (param1 != percentWidth)
            {
                widthChanged = true;
                invalidateProperties();
                invalidateSize();
            }
            super.percentWidth = param1;
            return;
        }// end function

        override public function set explicitWidth(param1:Number) : void
        {
            if (param1 != explicitWidth)
            {
                widthChanged = true;
                invalidateProperties();
                invalidateSize();
            }
            super.explicitWidth = param1;
            return;
        }// end function

        private function updateCompleteHandler(event:FlexEvent) : void
        {
            lastUnscaledWidth = NaN;
            return;
        }// end function

        override protected function childrenCreated() : void
        {
            super.childrenCreated();
            textField.wordWrap = true;
            textField.multiline = true;
            textField.mouseWheelEnabled = false;
            return;
        }// end function

        override protected function commitProperties() : void
        {
            super.commitProperties();
            if (widthChanged)
            {
                textField.wordWrap = !isNaN(explicitWidth) || !isNaN(explicitMaxWidth) || !isNaN(percentWidth);
                widthChanged = false;
            }
            return;
        }// end function

        override public function set maxWidth(param1:Number) : void
        {
            if (param1 != maxWidth)
            {
                widthChanged = true;
                invalidateProperties();
                invalidateSize();
            }
            super.maxWidth = param1;
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_7:Boolean = false;
            if (isSpecialCase())
            {
                _loc_7 = isNaN(lastUnscaledWidth) || lastUnscaledWidth != param1;
                lastUnscaledWidth = param1;
                if (_loc_7)
                {
                    invalidateSize();
                    return;
                }
            }
            var _loc_3:* = getStyle("paddingLeft");
            var _loc_4:* = getStyle("paddingTop");
            var _loc_5:* = getStyle("paddingRight");
            var _loc_6:* = getStyle("paddingBottom");
            textField.setActualSize(param1 - _loc_3 - _loc_5, param2 - _loc_4 - _loc_6);
            textField.x = _loc_3;
            textField.y = _loc_4;
            if (Math.floor(width) < Math.floor(measuredWidth))
            {
                textField.wordWrap = true;
            }
            return;
        }// end function

        override protected function measure() : void
        {
            var _loc_1:Number = NaN;
            if (isSpecialCase())
            {
                if (!isNaN(lastUnscaledWidth))
                {
                    measureUsingWidth(lastUnscaledWidth);
                }
                else
                {
                    measuredWidth = 0;
                    measuredHeight = 0;
                }
                return;
            }
            if (!isNaN(explicitWidth))
            {
                _loc_1 = explicitWidth;
            }
            else if (!isNaN(explicitMaxWidth))
            {
                _loc_1 = explicitMaxWidth;
            }
            measureUsingWidth(_loc_1);
            return;
        }// end function

        private function isSpecialCase() : Boolean
        {
            var _loc_1:* = getStyle("left");
            var _loc_2:* = getStyle("right");
            return (!isNaN(percentWidth) || !isNaN(_loc_1) && !isNaN(_loc_2)) && isNaN(explicitHeight) && isNaN(percentHeight);
        }// end function

    }
}
