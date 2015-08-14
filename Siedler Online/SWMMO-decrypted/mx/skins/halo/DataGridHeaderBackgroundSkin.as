package mx.skins.halo
{
    import flash.display.*;
    import flash.geom.*;
    import mx.skins.*;
    import mx.styles.*;

    public class DataGridHeaderBackgroundSkin extends ProgrammaticSkin
    {
        static const VERSION:String = "3.5.0.12683";

        public function DataGridHeaderBackgroundSkin()
        {
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_3:* = graphics;
            _loc_3.clear();
            var _loc_4:* = getStyle("headerColors");
            StyleManager.getColorNames(_loc_4);
            var _loc_5:* = new Matrix();
            new Matrix().createGradientBox(param1, (param2 + 1), Math.PI / 2, 0, 0);
            _loc_4 = [_loc_4[0], _loc_4[0], _loc_4[1]];
            var _loc_6:Array = [0, 60, 255];
            var _loc_7:Array = [1, 1, 1];
            _loc_3.beginGradientFill(GradientType.LINEAR, _loc_4, _loc_7, _loc_6, _loc_5);
            _loc_3.lineStyle(0, 0, 0);
            _loc_3.moveTo(0, 0);
            _loc_3.lineTo(param1, 0);
            _loc_3.lineTo(param1, param2 - 0.5);
            _loc_3.lineStyle(0, getStyle("borderColor"), 100);
            _loc_3.lineTo(0, param2 - 0.5);
            _loc_3.lineStyle(0, 0, 0);
            _loc_3.endFill();
            return;
        }// end function

    }
}
