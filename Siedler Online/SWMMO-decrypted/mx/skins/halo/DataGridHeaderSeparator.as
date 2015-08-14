package mx.skins.halo
{
    import flash.display.*;
    import mx.skins.*;

    public class DataGridHeaderSeparator extends ProgrammaticSkin
    {
        static const VERSION:String = "3.5.0.12683";

        public function DataGridHeaderSeparator()
        {
            return;
        }// end function

        override public function get measuredWidth() : Number
        {
            return 2;
        }// end function

        override public function get measuredHeight() : Number
        {
            return 10;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            var _loc_3:* = graphics;
            _loc_3.clear();
            _loc_3.lineStyle(1, 16777215, 0.5);
            _loc_3.moveTo(0, 0);
            _loc_3.lineTo(0, param2);
            _loc_3.lineStyle(1, getStyle("borderColor"));
            _loc_3.moveTo(1, 0);
            _loc_3.lineTo(1, param2);
            return;
        }// end function

    }
}
