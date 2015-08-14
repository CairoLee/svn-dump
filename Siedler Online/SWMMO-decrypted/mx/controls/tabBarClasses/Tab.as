package mx.controls.tabBarClasses
{
    import flash.display.*;
    import flash.text.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.styles.*;

    public class Tab extends Button
    {
        private var focusSkin:IFlexDisplayObject;
        static const VERSION:String = "3.5.0.12683";

        public function Tab()
        {
            focusEnabled = false;
            return;
        }// end function

        override public function drawFocus(param1:Boolean) : void
        {
            var _loc_2:Boolean = false;
            var _loc_3:Class = null;
            if (param1 && !selected && !isEffectStarted)
            {
                if (!focusSkin)
                {
                    _loc_2 = false;
                    _loc_3 = getStyle(overSkinName);
                    if (!_loc_3)
                    {
                        _loc_3 = getStyle(skinName);
                        _loc_2 = true;
                    }
                    if (_loc_3)
                    {
                        focusSkin = new _loc_3;
                        DisplayObject(focusSkin).name = overSkinName;
                        if (focusSkin is ISimpleStyleClient)
                        {
                            ISimpleStyleClient(focusSkin).styleName = this;
                        }
                        addChild(DisplayObject(focusSkin));
                        if (_loc_2 && !(focusSkin is IProgrammaticSkin) && focusSkin is IStateClient)
                        {
                            IStateClient(focusSkin).currentState = "over";
                        }
                    }
                }
                invalidateDisplayList();
                validateNow();
            }
            else if (focusSkin)
            {
                removeChild(DisplayObject(focusSkin));
                focusSkin = null;
            }
            return;
        }// end function

        override function layoutContents(param1:Number, param2:Number, param3:Boolean) : void
        {
            super.layoutContents(param1, param2, param3);
            if (selected)
            {
                var _loc_4:* = textField;
                var _loc_5:* = textField.y + 1;
                _loc_4.y = _loc_5;
                if (currentIcon)
                {
                    var _loc_4:* = currentIcon;
                    var _loc_5:* = currentIcon.y + 1;
                    _loc_4.y = _loc_5;
                }
            }
            if (currentSkin)
            {
                setChildIndex(DisplayObject(currentSkin), (numChildren - 1));
            }
            if (focusSkin && !selected)
            {
                focusSkin.setActualSize(param1, param2);
                setChildIndex(DisplayObject(focusSkin), (numChildren - 1));
            }
            if (currentIcon)
            {
                setChildIndex(DisplayObject(currentIcon), (numChildren - 1));
            }
            if (textField)
            {
                setChildIndex(DisplayObject(textField), (numChildren - 1));
            }
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            if (currentIcon)
            {
                currentIcon.scaleX = 1;
                currentIcon.scaleY = 1;
            }
            viewIcon();
            return;
        }// end function

        override public function measureText(param1:String) : TextLineMetrics
        {
            return textField.styleName == this ? (super.measureText(param1)) : (textField.getUITextFormat().measureText(param1));
        }// end function

        override function viewIcon() : void
        {
            var _loc_1:Number = NaN;
            super.viewIcon();
            if (currentIcon)
            {
                if (height != 0 && currentIcon.height > height - 4)
                {
                    _loc_1 = (height - 4) / currentIcon.height;
                    currentIcon.scaleX = _loc_1;
                    currentIcon.scaleY = _loc_1;
                    invalidateSize();
                    if (height > 0)
                    {
                        layoutContents(width, height, false);
                    }
                }
            }
            return;
        }// end function

    }
}
