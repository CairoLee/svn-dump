package mx.skins.halo
{
    import flash.display.*;
    import mx.skins.*;

    public class DataGridSortArrow extends ProgrammaticSkin
    {
        static const VERSION:String = "3.5.0.12683";

        public function DataGridSortArrow()
        {
            return;
        }// end function

        override public function get measuredWidth() : Number
        {
            return 6;
        }// end function

        override public function get measuredHeight() : Number
        {
            return 6;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            var _loc_3:* = graphics;
            _loc_3.clear();
            _loc_3.beginFill(name == "sortArrowDisabled" ? (getStyle("disabledIconColor")) : (getStyle("iconColor")));
            _loc_3.moveTo(0, 0);
            _loc_3.lineTo(param1, 0);
            _loc_3.lineTo(param1 / 2, param2);
            _loc_3.lineTo(0, 0);
            _loc_3.endFill();
            return;
        }// end function

    }
}
