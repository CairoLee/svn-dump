package GUI
{
    import flash.display.*;
    import flash.geom.*;
    import mx.controls.*;

    public class cItemRendererTileList extends Label
    {
        private static const IMG_Y:int = 16;
        private static var mMatrix:Matrix = new Matrix();

        public function cItemRendererTileList()
        {
            return;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            var _loc_3:* = data.bitmapData;
            super.updateDisplayList(param1, param2);
            var _loc_4:* = graphics;
            graphics.clear();
            mMatrix.identity();
            var _loc_5:int = 0;
            var _loc_6:* = IMG_Y;
            mMatrix.translate(_loc_5, _loc_6);
            _loc_4.beginBitmapFill(_loc_3, mMatrix, false, true);
            _loc_4.drawRect(0, IMG_Y, param1, param2 - IMG_Y);
            _loc_4.endFill();
            return;
        }// end function

    }
}
