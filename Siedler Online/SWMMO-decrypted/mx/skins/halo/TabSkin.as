package mx.skins.halo
{
    import flash.display.*;
    import flash.utils.*;
    import mx.core.*;
    import mx.skins.*;
    import mx.styles.*;
    import mx.utils.*;

    public class TabSkin extends Border
    {
        private var _borderMetrics:EdgeMetrics;
        private static var cache:Object = {};
        private static var tabnavs:Object = {};
        static const VERSION:String = "3.5.0.12683";

        public function TabSkin()
        {
            _borderMetrics = new EdgeMetrics(1, 1, 1, 1);
            return;
        }// end function

        override public function get measuredWidth() : Number
        {
            return UIComponent.DEFAULT_MEASURED_MIN_WIDTH;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_19:Array = null;
            var _loc_20:Array = null;
            var _loc_21:Array = null;
            var _loc_22:Array = null;
            var _loc_23:Array = null;
            var _loc_24:Array = null;
            var _loc_25:DisplayObjectContainer = null;
            super.updateDisplayList(param1, param2);
            var _loc_3:* = getStyle("backgroundAlpha");
            var _loc_4:* = getStyle("backgroundColor");
            var _loc_5:* = getStyle("borderColor");
            var _loc_6:* = getStyle("cornerRadius");
            var _loc_7:* = getStyle("fillAlphas");
            var _loc_8:* = getStyle("fillColors");
            StyleManager.getColorNames(_loc_8);
            var _loc_9:* = getStyle("highlightAlphas");
            var _loc_10:* = getStyle("themeColor");
            var _loc_11:Array = [];
            [][0] = ColorUtil.adjustBrightness2(_loc_8[0], -5);
            _loc_11[1] = ColorUtil.adjustBrightness2(_loc_8[1], -5);
            var _loc_12:* = calcDerivedStyles(_loc_10, _loc_5, _loc_11[0], _loc_11[1], _loc_8[0], _loc_8[1]);
            var _loc_13:* = parent != null && parent.parent != null && parent.parent.parent != null && isTabNavigator(parent.parent.parent);
            var _loc_14:Number = 1;
            if (_loc_13)
            {
                _loc_14 = Object(parent.parent.parent).borderMetrics.top;
            }
            var _loc_15:* = _loc_13 && IStyleClient(parent.parent.parent).getStyle("borderStyle") != "none" && _loc_14 >= 0;
            var _loc_16:* = Math.max(_loc_6 - 2, 0);
            var _loc_17:Object = {tl:_loc_6, tr:_loc_6, bl:0, br:0};
            var _loc_18:Object = {tl:_loc_16, tr:_loc_16, bl:0, br:0};
            graphics.clear();
            switch(name)
            {
                case "upSkin":
                {
                    _loc_19 = [_loc_11[0], _loc_11[1]];
                    _loc_20 = [_loc_7[0], _loc_7[1]];
                    drawRoundRect(0, 0, param1, (param2 - 1), _loc_17, [_loc_12.borderColorDrk1, _loc_5], 1, verticalGradientMatrix(0, 0, param1, param2), GradientType.LINEAR, null, {x:1, y:1, w:param1 - 2, h:param2 - 2, r:_loc_18});
                    drawRoundRect(1, 1, param1 - 2, param2 - 2, _loc_18, _loc_19, _loc_20, verticalGradientMatrix(0, 2, param1 - 2, param2 - 6));
                    drawRoundRect(1, 1, param1 - 2, (param2 - 2) / 2, _loc_18, [16777215, 16777215], _loc_9, verticalGradientMatrix(1, 1, param1 - 2, (param2 - 2) / 2));
                    if (_loc_15)
                    {
                        drawRoundRect(0, param2 - _loc_14, param1, _loc_14, 0, _loc_5, _loc_7[1]);
                    }
                    drawRoundRect(0, param2 - 2, param1, 1, 0, 0, 0.09);
                    drawRoundRect(0, param2 - 3, param1, 1, 0, 0, 0.03);
                    break;
                }
                case "overSkin":
                {
                    if (_loc_8.length > 2)
                    {
                        _loc_21 = [_loc_8[2], _loc_8[3]];
                    }
                    else
                    {
                        _loc_21 = [_loc_8[0], _loc_8[1]];
                    }
                    if (_loc_7.length > 2)
                    {
                        _loc_22 = [_loc_7[2], _loc_7[3]];
                    }
                    else
                    {
                        _loc_22 = [_loc_7[0], _loc_7[1]];
                    }
                    drawRoundRect(0, 0, param1, (param2 - 1), _loc_17, [_loc_10, _loc_12.themeColDrk2], 1, verticalGradientMatrix(0, 0, param1, param2 - 6), GradientType.LINEAR, null, {x:1, y:1, w:param1 - 2, h:param2 - 2, r:_loc_18});
                    drawRoundRect(1, 1, param1 - 2, param2 - 2, _loc_18, [_loc_12.falseFillColorBright1, _loc_12.falseFillColorBright2], _loc_22, verticalGradientMatrix(2, 2, param1 - 2, param2 - 2));
                    drawRoundRect(1, 1, param1 - 2, (param2 - 2) / 2, _loc_18, [16777215, 16777215], _loc_9, verticalGradientMatrix(1, 1, param1 - 2, (param2 - 2) / 2));
                    if (_loc_15)
                    {
                        drawRoundRect(0, param2 - _loc_14, param1, _loc_14, 0, _loc_5, _loc_7[1]);
                    }
                    drawRoundRect(0, param2 - 2, param1, 1, 0, 0, 0.09);
                    drawRoundRect(0, param2 - 3, param1, 1, 0, 0, 0.03);
                    break;
                }
                case "disabledSkin":
                {
                    _loc_23 = [_loc_8[0], _loc_8[1]];
                    _loc_24 = [Math.max(0, _loc_7[0] - 0.15), Math.max(0, _loc_7[1] - 0.15)];
                    drawRoundRect(0, 0, param1, (param2 - 1), _loc_17, [_loc_12.borderColorDrk1, _loc_5], 0.5, verticalGradientMatrix(0, 0, param1, param2 - 6));
                    drawRoundRect(1, 1, param1 - 2, param2 - 2, _loc_18, _loc_23, _loc_24, verticalGradientMatrix(0, 2, param1 - 2, param2 - 2));
                    if (_loc_15)
                    {
                        drawRoundRect(0, param2 - _loc_14, param1, _loc_14, 0, _loc_5, _loc_7[1]);
                    }
                    drawRoundRect(0, param2 - 2, param1, 1, 0, 0, 0.09);
                    drawRoundRect(0, param2 - 3, param1, 1, 0, 0, 0.03);
                    break;
                }
                case "downSkin":
                case "selectedUpSkin":
                case "selectedDownSkin":
                case "selectedOverSkin":
                case "selectedDisabledSkin":
                {
                    if (isNaN(_loc_4))
                    {
                        _loc_25 = parent;
                        while (_loc_25)
                        {
                            
                            if (_loc_25 is IStyleClient)
                            {
                                _loc_4 = IStyleClient(_loc_25).getStyle("backgroundColor");
                            }
                            if (!isNaN(_loc_4))
                            {
                                break;
                            }
                            _loc_25 = _loc_25.parent;
                        }
                        if (isNaN(_loc_4))
                        {
                            _loc_4 = 16777215;
                        }
                    }
                    drawRoundRect(0, 0, param1, (param2 - 1), _loc_17, [_loc_12.borderColorDrk1, _loc_5], 1, verticalGradientMatrix(0, 0, param1, param2 - 2), GradientType.LINEAR, null, {x:1, y:1, w:param1 - 2, h:param2 - 2, r:_loc_18});
                    drawRoundRect(1, 1, param1 - 2, param2 - 2, _loc_18, _loc_4, _loc_3);
                    if (_loc_15)
                    {
                        drawRoundRect(1, param2 - _loc_14, param1 - 2, _loc_14, 0, _loc_4, _loc_3);
                    }
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        override public function get measuredHeight() : Number
        {
            return UIComponent.DEFAULT_MEASURED_MIN_HEIGHT;
        }// end function

        override public function get borderMetrics() : EdgeMetrics
        {
            return _borderMetrics;
        }// end function

        private static function calcDerivedStyles(param1:uint, param2:uint, param3:uint, param4:uint, param5:uint, param6:uint) : Object
        {
            var _loc_8:Object = null;
            var _loc_7:* = HaloColors.getCacheKey(param1, param2, param3, param4, param5, param6);
            if (!cache[_loc_7])
            {
                var _loc_9:* = {};
                cache[_loc_7] = {};
                _loc_8 = _loc_9;
                HaloColors.addHaloColors(_loc_8, param1, param5, param6);
                _loc_8.borderColorDrk1 = ColorUtil.adjustBrightness2(param2, 10);
                _loc_8.falseFillColorBright1 = ColorUtil.adjustBrightness(param3, 15);
                _loc_8.falseFillColorBright2 = ColorUtil.adjustBrightness(param4, 15);
            }
            return cache[_loc_7];
        }// end function

        private static function isTabNavigator(param1:Object) : Boolean
        {
            var s:String;
            var x:XML;
            var parent:* = param1;
            s = getQualifiedClassName(parent);
            if (tabnavs[s] == 1)
            {
                return true;
            }
            if (tabnavs[s] == 0)
            {
                return false;
            }
            if (s == "mx.containers::TabNavigator")
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
                    if (@type == "mx.containers::TabNavigator")
                    {
                        _loc_3[_loc_4] = _loc_6;
                    }
                }
            }
            var xmllist:* = _loc_3;
            if (xmllist.length() == 0)
            {
                tabnavs[s] = 0;
                return false;
            }
            tabnavs[s] = 1;
            return true;
        }// end function

    }
}
