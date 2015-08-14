package mx.skins.halo
{
    import flash.display.*;
    import mx.skins.*;
    import mx.styles.*;
    import mx.utils.*;

    public class NumericStepperUpSkin extends Border
    {
        static const VERSION:String = "3.5.0.12683";
        private static var cache:Object = {};

        public function NumericStepperUpSkin()
        {
            return;
        }// end function

        override public function get measuredWidth() : Number
        {
            return 19;
        }// end function

        override public function get measuredHeight() : Number
        {
            return 11;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_14:Array = null;
            var _loc_15:Array = null;
            var _loc_16:Array = null;
            var _loc_17:Array = null;
            var _loc_18:Array = null;
            var _loc_19:Array = null;
            super.updateDisplayList(param1, param2);
            var _loc_3:* = getStyle("iconColor");
            var _loc_4:* = getStyle("borderColor");
            var _loc_5:* = getStyle("cornerRadius");
            var _loc_6:* = getStyle("fillAlphas");
            var _loc_7:* = getStyle("fillColors");
            StyleManager.getColorNames(_loc_7);
            var _loc_8:* = getStyle("highlightAlphas");
            var _loc_9:* = getStyle("themeColor");
            var _loc_10:* = calcDerivedStyles(_loc_9, _loc_4, _loc_7[0], _loc_7[1]);
            var _loc_11:Object = {tl:0, tr:_loc_5, bl:0, br:0};
            var _loc_12:Object = {tl:0, tr:Math.max((_loc_5 - 1), 0), bl:0, br:0};
            var _loc_13:* = graphics;
            graphics.clear();
            switch(name)
            {
                case "upArrowUpSkin":
                {
                    _loc_14 = [_loc_7[0], _loc_7[1]];
                    _loc_15 = [_loc_6[0], _loc_6[1]];
                    drawRoundRect(0, 0, param1, param2, _loc_11, [_loc_4, _loc_10.borderColorDrk2], 1, verticalGradientMatrix(0, 0, param1, param2), GradientType.LINEAR, null, {x:1, y:1, w:param1 - 2, h:param2 - 2, r:_loc_12});
                    drawRoundRect(1, 1, param1 - 2, param2 - 2, _loc_12, _loc_14, _loc_15, verticalGradientMatrix(1, 1, param1 - 2, param2 * 2));
                    drawRoundRect(1, 1, param1 - 2, param2 - 3, _loc_12, [16777215, 16777215], _loc_8, verticalGradientMatrix(1, 1, param1 - 2, param2 - 3));
                    break;
                }
                case "upArrowOverSkin":
                {
                    if (_loc_7.length > 2)
                    {
                        _loc_16 = [_loc_7[2], _loc_7[3]];
                    }
                    else
                    {
                        _loc_16 = [_loc_7[0], _loc_7[1]];
                    }
                    if (_loc_6.length > 2)
                    {
                        _loc_17 = [_loc_6[2], _loc_6[3]];
                    }
                    else
                    {
                        _loc_17 = [_loc_6[0], _loc_6[1]];
                    }
                    drawRoundRect(0, 0, param1, param2, _loc_11, [_loc_9, _loc_10.themeColDrk2], 1, verticalGradientMatrix(0, 0, param1, param2), GradientType.LINEAR, null, {x:1, y:1, w:param1 - 2, h:param2 - 2, r:_loc_12});
                    drawRoundRect(1, 1, param1 - 2, param2 - 2, _loc_12, [_loc_10.fillColorBright1, _loc_10.fillColorBright2], 1, verticalGradientMatrix(1, 1, param1 - 2, param2 * 2));
                    drawRoundRect(1, 1, param1 - 2, param2 - 2, _loc_12, [16777215, 16777215], _loc_8, verticalGradientMatrix(0, 0, param1 - 2, param2 * 2));
                    break;
                }
                case "upArrowDownSkin":
                {
                    drawRoundRect(0, 0, param1, param2, _loc_11, [_loc_9, _loc_10.themeColDrk2], 1, verticalGradientMatrix(0, 0, param1, param2));
                    drawRoundRect(1, 1, param1 - 2, param2 - 2, _loc_12, [_loc_10.fillColorPress1, _loc_10.fillColorPress2], 1, verticalGradientMatrix(1, 1, param1 - 2, param2 * 2));
                    drawRoundRect(1, 1, param1 - 2, param2 - 3, _loc_12, [16777215, 16777215], _loc_8, verticalGradientMatrix(1, 1, param1 - 2, param2 - 3));
                    break;
                }
                case "upArrowDisabledSkin":
                {
                    _loc_18 = [_loc_7[0], _loc_7[1]];
                    _loc_19 = [Math.max(0, _loc_6[0] - 0.15), Math.max(0, _loc_6[1] - 0.15)];
                    drawRoundRect(0, 0, param1, param2, _loc_11, [_loc_4, _loc_10.borderColorDrk2], 0.5, verticalGradientMatrix(0, 0, param1, param2), GradientType.LINEAR, null, {x:1, y:1, w:param1 - 2, h:param2 - 2, r:_loc_12});
                    drawRoundRect(1, 1, param1 - 2, param2 - 2, _loc_12, _loc_18, _loc_19, verticalGradientMatrix(1, 1, param1 - 2, param2 * 2));
                    _loc_3 = getStyle("disabledIconColor");
                    break;
                }
                default:
                {
                    break;
                }
            }
            _loc_13.beginFill(_loc_3);
            _loc_13.moveTo(param1 / 2, param2 / 2 - 2.5);
            _loc_13.lineTo(param1 / 2 - 3.5, param2 / 2 + 1.5);
            _loc_13.lineTo(param1 / 2 + 3.5, param2 / 2 + 1.5);
            _loc_13.lineTo(param1 / 2, param2 / 2 - 2.5);
            _loc_13.endFill();
            return;
        }// end function

        private static function calcDerivedStyles(param1:uint, param2:uint, param3:uint, param4:uint) : Object
        {
            var _loc_6:Object = null;
            var _loc_5:* = HaloColors.getCacheKey(param1, param2, param3, param4);
            if (!cache[_loc_5])
            {
                var _loc_7:* = {};
                cache[_loc_5] = {};
                _loc_6 = _loc_7;
                HaloColors.addHaloColors(_loc_6, param1, param3, param4);
                _loc_6.borderColorDrk1 = ColorUtil.adjustBrightness2(param2, -50);
                _loc_6.borderColorDrk2 = ColorUtil.adjustBrightness2(param2, -25);
            }
            return cache[_loc_5];
        }// end function

    }
}
