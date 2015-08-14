package mx.skins.halo
{
    import flash.display.*;
    import flash.filters.*;
    import flash.utils.*;
    import mx.core.*;
    import mx.skins.*;
    import mx.styles.*;
    import mx.utils.*;

    public class ActivatorSkin extends Border
    {
        private static var cache:Object = {};
        private static var acbs:Object = {};
        static const VERSION:String = "3.5.0.12683";

        public function ActivatorSkin()
        {
            return;
        }// end function

        private function drawHaloRect(param1:Number, param2:Number) : void
        {
            var _loc_9:Array = null;
            var _loc_10:Array = null;
            var _loc_3:* = getStyle("fillAlphas");
            var _loc_4:* = getStyle("fillColors");
            var _loc_5:* = getStyle("highlightAlphas");
            var _loc_6:* = getStyle("themeColor");
            var _loc_7:* = ColorUtil.adjustBrightness2(_loc_6, -25);
            var _loc_8:* = calcDerivedStyles(_loc_6, _loc_4[0], _loc_4[1]);
            graphics.clear();
            switch(name)
            {
                case "itemUpSkin":
                {
                    drawRoundRect(x, y, param1, param2, 0, 16777215, 0);
                    break;
                }
                case "itemDownSkin":
                {
                    drawRoundRect((x + 1), (y + 1), param1 - 2, param2 - 2, 0, [_loc_8.fillColorPress1, _loc_8.fillColorPress2], 1, verticalGradientMatrix(0, 0, param1, param2));
                    drawRoundRect((x + 1), (y + 1), param1 - 2, param2 - 2 / 2, 0, [16777215, 16777215], _loc_5, verticalGradientMatrix(0, 0, param1 - 2, param2 - 2));
                    break;
                }
                case "itemOverSkin":
                {
                    if (_loc_4.length > 2)
                    {
                        _loc_9 = [_loc_4[2], _loc_4[3]];
                    }
                    else
                    {
                        _loc_9 = [_loc_4[0], _loc_4[1]];
                    }
                    if (_loc_3.length > 2)
                    {
                        _loc_10 = [_loc_3[2], _loc_3[3]];
                    }
                    else
                    {
                        _loc_10 = [_loc_3[0], _loc_3[1]];
                    }
                    drawRoundRect((x + 1), (y + 1), param1 - 2, param2 - 2, 0, _loc_9, _loc_10, verticalGradientMatrix(0, 0, param1, param2));
                    drawRoundRect((x + 1), (y + 1), param1 - 2, param2 - 2 / 2, 0, [16777215, 16777215], _loc_5, verticalGradientMatrix(0, 0, param1 - 2, param2 - 2));
                    break;
                }
                default:
                {
                    break;
                }
            }
            filters = [new BlurFilter(2, 0)];
            return;
        }// end function

        private function drawTranslucentHaloRect(param1:Number, param2:Number) : void
        {
            var _loc_9:Object = null;
            var _loc_3:* = parent as IStyleClient;
            while (_loc_3 && !isApplicationControlBar(_loc_3))
            {
                
                _loc_3 = DisplayObject(_loc_3).parent as IStyleClient;
            }
            if (!_loc_3)
            {
                return;
            }
            var _loc_4:* = _loc_3.getStyle("fillColor");
            var _loc_5:* = _loc_3.getStyle("backgroundColor");
            var _loc_6:* = _loc_3.getStyle("backgroundAlpha");
            var _loc_7:* = _loc_3.getStyle("cornerRadius");
            var _loc_8:* = _loc_3.getStyle("docked");
            if (_loc_5 == "")
            {
                _loc_5 = null;
            }
            if (_loc_8 && !_loc_5)
            {
                _loc_9 = ApplicationGlobals.application.getStyle("backgroundColor");
                _loc_5 = _loc_9 ? (_loc_9) : (9542041);
            }
            graphics.clear();
            switch(name)
            {
                case "itemUpSkin":
                {
                    drawRoundRect(1, 1, param1 - 2, (param2 - 1), 0, 0, 0);
                    filters = [];
                    break;
                }
                case "itemOverSkin":
                {
                    if (_loc_5)
                    {
                        drawRoundRect(1, 1, param1 - 2, (param2 - 1), 0, _loc_5, _loc_6);
                    }
                    drawRoundRect(1, 1, param1 - 2, (param2 - 1), 0, [_loc_4, _loc_4, _loc_4, _loc_4, _loc_4], [1, 0.75, 0.6, 0.7, 0.9], verticalGradientMatrix(0, 0, param1, param2), GradientType.LINEAR, [0, 95, 127, 191, 255]);
                    filters = [new BlurFilter(0, 4)];
                    break;
                }
                case "itemDownSkin":
                {
                    if (_loc_5)
                    {
                        drawRoundRect(1, 1, param1 - 2, (param2 - 1), 0, _loc_5, _loc_6);
                    }
                    drawRoundRect(1, 1, param1 - 2, (param2 - 1), 0, [_loc_4, _loc_4, _loc_4, _loc_4, _loc_4], [0.85, 0.6, 0.45, 0.55, 0.75], verticalGradientMatrix(0, 0, param1, param2), GradientType.LINEAR, [0, 95, 127, 191, 255]);
                    filters = [new BlurFilter(0, 4)];
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            if (!getStyle("translucent"))
            {
                drawHaloRect(param1, param2);
            }
            else
            {
                drawTranslucentHaloRect(param1, param2);
            }
            return;
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
            }
            return cache[_loc_4];
        }// end function

        private static function isApplicationControlBar(param1:Object) : Boolean
        {
            var s:String;
            var x:XML;
            var parent:* = param1;
            s = getQualifiedClassName(parent);
            if (acbs[s] == 1)
            {
                return true;
            }
            if (acbs[s] == 0)
            {
                return false;
            }
            if (s == "mx.containers::ApplicationControlBar")
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
                    if (@type == "mx.containers::ApplicationControlBar")
                    {
                        _loc_3[_loc_4] = _loc_6;
                    }
                }
            }
            var xmllist:* = _loc_3;
            if (xmllist.length() == 0)
            {
                acbs[s] = 0;
                return false;
            }
            acbs[s] = 1;
            return true;
        }// end function

    }
}
