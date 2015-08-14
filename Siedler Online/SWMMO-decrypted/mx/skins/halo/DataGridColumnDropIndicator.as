package mx.skins.halo
{
    import flash.display.*;
    import mx.skins.*;
    import mx.utils.*;

    public class DataGridColumnDropIndicator extends ProgrammaticSkin
    {
        static const VERSION:String = "3.5.0.12683";

        public function DataGridColumnDropIndicator()
        {
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            var _loc_3:* = graphics;
            _loc_3.clear();
            _loc_3.lineStyle(1, getStyle("rollOverColor"));
            _loc_3.moveTo(0, 0);
            _loc_3.lineTo(0, param2);
            _loc_3.lineStyle(1, ColorUtil.adjustBrightness(getStyle("themeColor"), -75));
            _loc_3.moveTo(1, 0);
            _loc_3.lineTo(1, param2);
            _loc_3.lineStyle(1, getStyle("rollOverColor"));
            _loc_3.moveTo(2, 0);
            _loc_3.lineTo(2, param2);
            return;
        }// end function

    }
}
