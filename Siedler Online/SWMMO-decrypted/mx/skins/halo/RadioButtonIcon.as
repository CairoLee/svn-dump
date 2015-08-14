package mx.skins.halo
{
    import flash.display.*;
    import mx.skins.*;
    import mx.styles.*;
    import mx.utils.*;

    public class RadioButtonIcon extends Border
    {
        static const VERSION:String = "3.5.0.12683";
        private static var cache:Object = {};

        public function RadioButtonIcon()
        {
            return;
        }// end function

        override public function get measuredWidth() : Number
        {
            return 14;
        }// end function

        override public function get measuredHeight() : Number
        {
            return 14;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_13:Array = null;
            var _loc_14:Array = null;
            var _loc_15:Array = null;
            var _loc_16:Array = null;
            var _loc_18:Array = null;
            var _loc_19:Array = null;
            super.updateDisplayList(param1, param2);
            var _loc_3:* = getStyle("iconColor");
            var _loc_4:* = getStyle("borderColor");
            var _loc_5:* = getStyle("fillAlphas");
            var _loc_6:* = getStyle("fillColors");
            StyleManager.getColorNames(_loc_6);
            var _loc_7:* = getStyle("highlightAlphas");
            var _loc_8:* = getStyle("themeColor");
            var _loc_9:* = calcDerivedStyles(_loc_8, _loc_4, _loc_6[0], _loc_6[1]);
            var _loc_10:* = ColorUtil.adjustBrightness2(_loc_4, -50);
            var _loc_11:* = ColorUtil.adjustBrightness2(_loc_8, -25);
            var _loc_12:* = width / 2;
            var _loc_17:* = graphics;
            graphics.clear();
            switch(name)
            {
                case "upIcon":
                {
                    _loc_13 = [_loc_6[0], _loc_6[1]];
                    _loc_14 = [_loc_5[0], _loc_5[1]];
                    _loc_17.beginGradientFill(GradientType.LINEAR, [_loc_4, _loc_10], [100, 100], [0, 255], verticalGradientMatrix(0, 0, param1, param2));
                    _loc_17.drawCircle(_loc_12, _loc_12, _loc_12);
                    _loc_17.drawCircle(_loc_12, _loc_12, (_loc_12 - 1));
                    _loc_17.endFill();
                    _loc_17.beginGradientFill(GradientType.LINEAR, _loc_13, _loc_14, [0, 255], verticalGradientMatrix(1, 1, param1 - 2, param2 - 2));
                    _loc_17.drawCircle(_loc_12, _loc_12, (_loc_12 - 1));
                    _loc_17.endFill();
                    drawRoundRect(1, 1, param1 - 2, (param2 - 2) / 2, {tl:_loc_12, tr:_loc_12, bl:0, br:0}, [16777215, 16777215], _loc_7, verticalGradientMatrix(0, 0, param1 - 2, (param2 - 2) / 2));
                    break;
                }
                case "overIcon":
                {
                    if (_loc_6.length > 2)
                    {
                        _loc_18 = [_loc_6[2], _loc_6[3]];
                    }
                    else
                    {
                        _loc_18 = [_loc_6[0], _loc_6[1]];
                    }
                    if (_loc_5.length > 2)
                    {
                        _loc_19 = [_loc_5[2], _loc_5[3]];
                    }
                    else
                    {
                        _loc_19 = [_loc_5[0], _loc_5[1]];
                    }
                    _loc_17.beginGradientFill(GradientType.LINEAR, [_loc_8, _loc_11], [100, 100], [0, 255], verticalGradientMatrix(0, 0, param1, param2));
                    _loc_17.drawCircle(_loc_12, _loc_12, _loc_12);
                    _loc_17.drawCircle(_loc_12, _loc_12, (_loc_12 - 1));
                    _loc_17.endFill();
                    _loc_17.beginGradientFill(GradientType.LINEAR, _loc_18, _loc_19, [0, 255], verticalGradientMatrix(1, 1, param1 - 2, param2 - 2));
                    _loc_17.drawCircle(_loc_12, _loc_12, (_loc_12 - 1));
                    _loc_17.endFill();
                    drawRoundRect(1, 1, param1 - 2, (param2 - 2) / 2, {tl:_loc_12, tr:_loc_12, bl:0, br:0}, [16777215, 16777215], _loc_7, verticalGradientMatrix(0, 0, param1 - 2, (param2 - 2) / 2));
                    break;
                }
                case "downIcon":
                {
                    _loc_17.beginGradientFill(GradientType.LINEAR, [_loc_8, _loc_11], [100, 100], [0, 255], verticalGradientMatrix(0, 0, param1, param2));
                    _loc_17.drawCircle(_loc_12, _loc_12, _loc_12);
                    _loc_17.endFill();
                    _loc_17.beginGradientFill(GradientType.LINEAR, [_loc_9.fillColorPress1, _loc_9.fillColorPress2], [100, 100], [0, 255], verticalGradientMatrix(1, 1, param1 - 2, param2 - 2));
                    _loc_17.drawCircle(_loc_12, _loc_12, (_loc_12 - 1));
                    _loc_17.endFill();
                    drawRoundRect(1, 1, param1 - 2, (param2 - 2) / 2, {tl:_loc_12, tr:_loc_12, bl:0, br:0}, [16777215, 16777215], _loc_7, verticalGradientMatrix(0, 0, param1 - 2, (param2 - 2) / 2));
                    break;
                }
                case "disabledIcon":
                {
                    _loc_15 = [_loc_6[0], _loc_6[1]];
                    _loc_16 = [Math.max(0, _loc_5[0] - 0.15), Math.max(0, _loc_5[1] - 0.15)];
                    _loc_17.beginGradientFill(GradientType.LINEAR, [_loc_4, _loc_10], [0.5, 0.5], [0, 255], verticalGradientMatrix(0, 0, param1, param2));
                    _loc_17.drawCircle(_loc_12, _loc_12, _loc_12);
                    _loc_17.drawCircle(_loc_12, _loc_12, (_loc_12 - 1));
                    _loc_17.endFill();
                    _loc_17.beginGradientFill(GradientType.LINEAR, _loc_15, _loc_16, [0, 255], verticalGradientMatrix(1, 1, param1 - 2, param2 - 2));
                    _loc_17.drawCircle(_loc_12, _loc_12, (_loc_12 - 1));
                    _loc_17.endFill();
                    break;
                }
                case "selectedUpIcon":
                case "selectedOverIcon":
                case "selectedDownIcon":
                {
                    _loc_13 = [_loc_6[0], _loc_6[1]];
                    _loc_14 = [_loc_5[0], _loc_5[1]];
                    _loc_17.beginGradientFill(GradientType.LINEAR, [_loc_4, _loc_10], [100, 100], [0, 255], verticalGradientMatrix(0, 0, param1, param2));
                    _loc_17.drawCircle(_loc_12, _loc_12, _loc_12);
                    _loc_17.drawCircle(_loc_12, _loc_12, (_loc_12 - 1));
                    _loc_17.endFill();
                    _loc_17.beginGradientFill(GradientType.LINEAR, _loc_13, _loc_14, [0, 255], verticalGradientMatrix(1, 1, param1 - 2, param2 - 2));
                    _loc_17.drawCircle(_loc_12, _loc_12, (_loc_12 - 1));
                    _loc_17.endFill();
                    drawRoundRect(1, 1, param1 - 2, (param2 - 2) / 2, {tl:_loc_12, tr:_loc_12, bl:0, br:0}, [16777215, 16777215], _loc_7, verticalGradientMatrix(0, 0, param1 - 2, (param2 - 2) / 2));
                    _loc_17.beginFill(_loc_3);
                    _loc_17.drawCircle(_loc_12, _loc_12, 2);
                    _loc_17.endFill();
                    break;
                }
                case "selectedDisabledIcon":
                {
                    _loc_15 = [_loc_6[0], _loc_6[1]];
                    _loc_16 = [Math.max(0, _loc_5[0] - 0.15), Math.max(0, _loc_5[1] - 0.15)];
                    _loc_17.beginGradientFill(GradientType.LINEAR, [_loc_4, _loc_10], [0.5, 0.5], [0, 255], verticalGradientMatrix(0, 0, param1, param2));
                    _loc_17.drawCircle(_loc_12, _loc_12, _loc_12);
                    _loc_17.drawCircle(_loc_12, _loc_12, (_loc_12 - 1));
                    _loc_17.endFill();
                    _loc_17.beginGradientFill(GradientType.LINEAR, _loc_15, _loc_16, [0, 255], verticalGradientMatrix(1, 1, param1 - 2, param2 - 2));
                    _loc_17.drawCircle(_loc_12, _loc_12, (_loc_12 - 1));
                    _loc_17.endFill();
                    _loc_3 = getStyle("disabledIconColor");
                    _loc_17.beginFill(_loc_3);
                    _loc_17.drawCircle(_loc_12, _loc_12, 2);
                    _loc_17.endFill();
                    break;
                }
                default:
                {
                    break;
                }
            }
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
                _loc_6.borderColorDrk1 = ColorUtil.adjustBrightness2(param2, -60);
            }
            return cache[_loc_5];
        }// end function

    }
}
