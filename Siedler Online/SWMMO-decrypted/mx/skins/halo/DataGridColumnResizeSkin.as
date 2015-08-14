package mx.skins.halo
{
    import flash.display.*;
    import mx.skins.*;

    public class DataGridColumnResizeSkin extends ProgrammaticSkin
    {
        static const VERSION:String = "3.5.0.12683";

        public function DataGridColumnResizeSkin()
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
            _loc_3.beginFill(0, 0.4);
            _loc_3.drawRect(0, 0, param1, param2);
            _loc_3.endFill();
            return;
        }// end function

    }
}
