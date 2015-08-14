package mx.skins.halo
{
    import flash.display.*;
    import flash.utils.*;
    import mx.containers.*;
    import mx.core.*;
    import mx.skins.*;
    import mx.styles.*;
    import mx.utils.*;

    public class ButtonBarButtonSkin extends Border
    {
        private static var bbars:Object = {};
        private static var cache:Object = {};
        static const VERSION:String = "3.5.0.12683";

        public function ButtonBarButtonSkin()
        {
            return;
        }// end function

        override public function get measuredWidth() : Number
        {
            return UIComponent.DEFAULT_MEASURED_MIN_WIDTH;
        }// end function

        override public function get measuredHeight() : Number
        {
            return UIComponent.DEFAULT_MEASURED_MIN_HEIGHT;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_13:Number = NaN;
            var _loc_22:int = 0;
            var _loc_23:Array = null;
            var _loc_24:Array = null;
            var _loc_25:Array = null;
            var _loc_26:Array = null;
            var _loc_27:Array = null;
            var _loc_28:Array = null;
            super.updateDisplayList(param1, param2);
            var _loc_3:* = getStyle("borderColor");
            var _loc_4:* = getStyle("cornerRadius");
            var _loc_5:* = getStyle("fillAlphas");
            var _loc_6:* = getStyle("fillColors");
            StyleManager.getColorNames(_loc_6);
            var _loc_7:* = getStyle("highlightAlphas");
            var _loc_8:* = getStyle("themeColor");
            var _loc_9:* = calcDerivedStyles(_loc_8, _loc_6[0], _loc_6[1]);
            var _loc_10:* = ColorUtil.adjustBrightness2(_loc_3, -50);
            var _loc_11:* = ColorUtil.adjustBrightness2(_loc_8, -25);
            var _loc_12:Boolean = false;
            if (parent is IButton)
            {
                _loc_12 = (parent as IButton).emphasized;
            }
            var _loc_14:* = parent && parent.parent && isButtonBar(parent.parent) ? (parent.parent) : (null);
            var _loc_15:Boolean = true;
            var _loc_16:int = 0;
            if (_loc_14)
            {
                if (_loc_14.direction == BoxDirection.VERTICAL)
                {
                    _loc_15 = false;
                }
                _loc_22 = _loc_14.getChildIndex(parent);
                _loc_16 = _loc_22 == 0 ? (-1) : (_loc_22 == (_loc_14.numChildren - 1) ? (1) : (0));
            }
            var _loc_17:* = getCornerRadius(_loc_16, _loc_15, _loc_4);
            var _loc_18:* = getCornerRadius(_loc_16, _loc_15, _loc_4);
            var _loc_19:* = getCornerRadius(_loc_16, _loc_15, (_loc_4 - 1));
            var _loc_20:* = getCornerRadius(_loc_16, _loc_15, _loc_4 - 2);
            var _loc_21:* = getCornerRadius(_loc_16, _loc_15, _loc_4 - 3);
            graphics.clear();
            switch(name)
            {
                case "selectedUpSkin":
                case "selectedOverSkin":
                {
                    drawRoundRect(0, 0, param1, param2, _loc_18, [_loc_8, _loc_11], 1, verticalGradientMatrix(0, 0, param1, param2), GradientType.LINEAR, null, {x:2, y:2, w:param1 - 4, h:param2 - 4, r:_loc_20});
                    drawRoundRect(1, 1, param1 - 2, param2 - 2, _loc_19, [_loc_6[1], _loc_6[1]], [_loc_5[0], _loc_5[1]], verticalGradientMatrix(0, 0, param1 - 2, param2 - 2));
                    break;
                }
                case "upSkin":
                {
                    _loc_23 = [_loc_6[0], _loc_6[1]];
                    _loc_24 = [_loc_5[0], _loc_5[1]];
                    if (_loc_12)
                    {
                        drawRoundRect(0, 0, param1, param2, _loc_18, [_loc_8, _loc_11], 1, verticalGradientMatrix(0, 0, param1, param2), GradientType.LINEAR, null, {x:2, y:2, w:param1 - 4, h:param2 - 4, r:_loc_20});
                        drawRoundRect(2, 2, param1 - 4, param2 - 4, _loc_20, _loc_23, _loc_24, verticalGradientMatrix(1, 1, param1 - 2, param2 - 2));
                        if (!(_loc_17 is Number))
                        {
                            var _loc_29:int = 0;
                            _loc_17.br = 0;
                            _loc_17.bl = _loc_29;
                        }
                        drawRoundRect(2, 2, param1 - 4, (param2 - 4) / 2, _loc_17, [16777215, 16777215], _loc_7, verticalGradientMatrix(2, 2, param1 - 2, (param2 - 4) / 2));
                    }
                    else
                    {
                        drawRoundRect(0, 0, param1, param2, _loc_18, [_loc_3, _loc_10], 1, verticalGradientMatrix(0, 0, param1, param2), GradientType.LINEAR, null, {x:1, y:1, w:param1 - 2, h:param2 - 2, r:_loc_19});
                        drawRoundRect(1, 1, param1 - 2, param2 - 2, _loc_19, _loc_23, _loc_24, verticalGradientMatrix(1, 1, param1 - 2, param2 - 2));
                        if (!(_loc_17 is Number))
                        {
                            var _loc_29:int = 0;
                            _loc_17.br = 0;
                            _loc_17.bl = _loc_29;
                        }
                        drawRoundRect(1, 1, param1 - 2, (param2 - 2) / 2, _loc_17, [16777215, 16777215], _loc_7, verticalGradientMatrix(1, 1, param1 - 2, (param2 - 2) / 2));
                    }
                    break;
                }
                case "overSkin":
                {
                    if (_loc_6.length > 2)
                    {
                        _loc_25 = [_loc_6[2], _loc_6[3]];
                    }
                    else
                    {
                        _loc_25 = [_loc_6[0], _loc_6[1]];
                    }
                    if (_loc_5.length > 2)
                    {
                        _loc_26 = [_loc_5[2], _loc_5[3]];
                    }
                    else
                    {
                        _loc_26 = [_loc_5[0], _loc_5[1]];
                    }
                    drawRoundRect(0, 0, param1, param2, _loc_18, [_loc_8, _loc_9.themeColDrk1], 1, verticalGradientMatrix(0, 0, param1, param2), GradientType.LINEAR, null, {x:1, y:1, w:param1 - 2, h:param2 - 2, r:_loc_19});
                    drawRoundRect(1, 1, param1 - 2, param2 - 2, _loc_19, _loc_25, _loc_26, verticalGradientMatrix(0, 0, param1 - 2, param2 - 2));
                    if (!(_loc_17 is Number))
                    {
                        var _loc_29:int = 0;
                        _loc_17.br = 0;
                        _loc_17.bl = _loc_29;
                    }
                    drawRoundRect(1, 1, param1 - 2, (param2 - 2) / 2, _loc_17, [16777215, 16777215], _loc_7, verticalGradientMatrix(1, 1, param1 - 2, (param2 - 2) / 2));
                    break;
                }
                case "downSkin":
                case "selectedDownSkin":
                {
                    drawRoundRect(0, 0, param1, param2, _loc_18, [_loc_8, _loc_9.themeColDrk1], 1, verticalGradientMatrix(0, 0, param1, param2));
                    drawRoundRect(1, 1, param1 - 2, param2 - 2, _loc_19, [_loc_9.fillColorPress1, _loc_9.fillColorPress2], 1, verticalGradientMatrix(0, 0, param1 - 2, param2 - 2));
                    if (!(_loc_17 is Number))
                    {
                        var _loc_29:int = 0;
                        _loc_17.br = 0;
                        _loc_17.bl = _loc_29;
                    }
                    drawRoundRect(1, 1, param1 - 2, (param2 - 2) / 2, _loc_17, [16777215, 16777215], _loc_7, verticalGradientMatrix(1, 1, param1 - 2, (param2 - 2) / 2));
                    break;
                }
                case "disabledSkin":
                case "selectedDisabledSkin":
                {
                    _loc_27 = [_loc_6[0], _loc_6[1]];
                    _loc_28 = [Math.max(0, _loc_5[0] - 0.15), Math.max(0, _loc_5[1] - 0.15)];
                    drawRoundRect(0, 0, param1, param2, _loc_18, [_loc_3, _loc_10], 0.5, verticalGradientMatrix(0, 0, param1, param2), GradientType.LINEAR, null, {x:1, y:1, w:param1 - 2, h:param2 - 2, r:_loc_19});
                    drawRoundRect(1, 1, param1 - 2, param2 - 2, _loc_19, _loc_27, _loc_28, verticalGradientMatrix(0, 0, param1 - 2, param2 - 2));
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        private function getCornerRadius(param1:int, param2:Boolean, param3:Number) : Object
        {
            if (param1 == 0)
            {
                return 0;
            }
            param3 = Math.max(0, param3);
            if (param2)
            {
                if (param1 == -1)
                {
                    return {tl:param3, tr:0, bl:param3, br:0};
                }
                return {tl:0, tr:param3, bl:0, br:param3};
            }
            else
            {
                if (param1 == -1)
                {
                    return {tl:param3, tr:param3, bl:0, br:0};
                }
            }
            return {tl:0, tr:0, bl:param3, br:param3};
        }// end function

        private static function isButtonBar(param1:Object) : Boolean
        {
            var s:String;
            var x:XML;
            var parent:* = param1;
            s = getQualifiedClassName(parent);
            if (bbars[s] == 1)
            {
                return true;
            }
            if (bbars[s] == 0)
            {
                return false;
            }
            if (s == "mx.controls::ButtonBar")
            {
                return true;
            }
            x = describeType(parent);
            var _loc_4:int = 0;
            var _loc_5:* = x.extendsClass;
            var _loc_3:* = new XMLList("");
            for each (_loc_6 in _loc_5)
            {
                
                var _loc_7:* = _loc_5[_loc_4];
                with (_loc_5[_loc_4])
                {
                    if (@type == "mx.controls::ButtonBar")
                    {
                        _loc_3[_loc_4] = _loc_6;
                    }
                }
            }
            var xmllist:* = _loc_3;
            if (xmllist.length() == 0)
            {
                bbars[s] = 0;
                return false;
            }
            bbars[s] = 1;
            return true;
        }// end function

        private static function calcDerivedStyles(param1:uint, param2:uint, param3:uint) : Object
        {
            var _loc_5:Object = null;
            var _loc_4:* = HaloColors.getCacheKey(param1, param2, param3);
            if (!cache[_loc_4])
            {
                var _loc_6:* = {};
                cache[_loc_4] = {};
                _loc_5 = _loc_6;
                HaloColors.addHaloColors(_loc_5, param1, param2, param3);
                _loc_5.innerEdgeColor1 = ColorUtil.adjustBrightness2(param2, -10);
                _loc_5.innerEdgeColor2 = ColorUtil.adjustBrightness2(param3, -25);
            }
            return cache[_loc_4];
        }// end function

    }
}
