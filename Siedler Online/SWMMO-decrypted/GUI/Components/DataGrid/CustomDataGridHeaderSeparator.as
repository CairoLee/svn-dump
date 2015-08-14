package GUI.Components.DataGrid
{
    import flash.display.*;
    import mx.skins.*;

    public class CustomDataGridHeaderSeparator extends ProgrammaticSkin
    {

        public function CustomDataGridHeaderSeparator()
        {
            return;
        }// end function

        override public function get measuredWidth() : Number
        {
            return 1;
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
            _loc_3.lineStyle(1, getStyle("borderColor"));
            _loc_3.moveTo(1, 0);
            _loc_3.lineTo(1, param2);
            return;
        }// end function

    }
}
