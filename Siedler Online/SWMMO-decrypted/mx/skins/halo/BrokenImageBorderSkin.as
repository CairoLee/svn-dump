package mx.skins.halo
{
    import flash.display.*;
    import mx.skins.*;

    public class BrokenImageBorderSkin extends ProgrammaticSkin
    {
        static const VERSION:String = "3.5.0.12683";

        public function BrokenImageBorderSkin()
        {
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            var _loc_3:* = graphics;
            _loc_3.clear();
            _loc_3.lineStyle(1, getStyle("borderColor"));
            _loc_3.drawRect(0, 0, param1, param2);
            return;
        }// end function

    }
}
