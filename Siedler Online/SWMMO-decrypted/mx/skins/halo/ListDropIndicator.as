package mx.skins.halo
{
    import flash.display.*;
    import mx.skins.*;

    public class ListDropIndicator extends ProgrammaticSkin
    {
        public var direction:String = "horizontal";
        static const VERSION:String = "3.5.0.12683";

        public function ListDropIndicator()
        {
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            var _loc_3:* = graphics;
            _loc_3.clear();
            _loc_3.lineStyle(2, 2831164);
            if (direction == "horizontal")
            {
                _loc_3.moveTo(0, 0);
                _loc_3.lineTo(param1, 0);
            }
            else
            {
                _loc_3.moveTo(0, 0);
                _loc_3.lineTo(0, param2);
            }
            return;
        }// end function

    }
}
