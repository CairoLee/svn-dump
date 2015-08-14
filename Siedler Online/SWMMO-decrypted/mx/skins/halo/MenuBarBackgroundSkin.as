package mx.skins.halo
{
    import flash.display.*;
    import mx.core.*;
    import mx.skins.*;
    import mx.styles.*;
    import mx.utils.*;

    public class MenuBarBackgroundSkin extends Border
    {
        private var _borderMetrics:EdgeMetrics;
        static const VERSION:String = "3.5.0.12683";
        private static var cache:Object = {};

        public function MenuBarBackgroundSkin()
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
            super.updateDisplayList(param1, param2);
            var _loc_3:* = getStyle("bevel");
            var _loc_4:* = getStyle("borderColor");
            var _loc_5:* = getStyle("cornerRadius");
            var _loc_6:* = getStyle("fillAlphas");
            var _loc_7:* = getStyle("fillColors");
            StyleManager.getColorNames(_loc_7);
            var _loc_8:* = getStyle("themeColor");
            var _loc_9:* = calcDerivedStyles(_loc_8, _loc_7[0], _loc_7[1]);
            var _loc_10:* = ColorUtil.adjustBrightness2(_loc_4, -25);
            var _loc_11:* = Math.max(0, _loc_5);
            var _loc_12:* = Math.max(0, (_loc_5 - 1));
            var _loc_13:Array = [_loc_7[0], _loc_7[1]];
            var _loc_14:Array = [_loc_6[0], _loc_6[1]];
            graphics.clear();
            drawRoundRect(0, 0, param1, param2, _loc_11, [_loc_4, _loc_10], 1, verticalGradientMatrix(0, 0, param1, param2), GradientType.LINEAR, null, {x:1, y:1, w:param1 - 2, h:param2 - 2, r:_loc_12});
            drawRoundRect(1, 1, param1 - 2, param2 - 2, _loc_12, _loc_13, _loc_14, verticalGradientMatrix(1, 1, param1 - 2, param2 - 2));
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

    }
}
