package mx.skins.halo
{
    import flash.display.*;
    import mx.skins.*;

    public class ProgressMaskSkin extends ProgrammaticSkin
    {
        static const VERSION:String = "3.5.0.12683";

        public function ProgressMaskSkin()
        {
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            var _loc_3:* = graphics;
            _loc_3.clear();
            _loc_3.beginFill(16776960);
            _loc_3.drawRect(1, 1, param1 - 2, param2 - 2);
            _loc_3.endFill();
            return;
        }// end function

    }
}
