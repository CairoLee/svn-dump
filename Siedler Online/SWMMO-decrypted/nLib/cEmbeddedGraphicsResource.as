package nLib
{
    import flash.display.*;
    import flash.geom.*;

    public class cEmbeddedGraphicsResource extends Object
    {
        public var mBitmap:BitmapData = null;

        public function cEmbeddedGraphicsResource(param1:DisplayObject)
        {
            var _loc_2:* = this.createBitmapData(param1);
            var _loc_3:* = this.createAlphaBitmapData(param1);
            this.mBitmap = new BitmapData(_loc_2.width, _loc_2.height, true);
            this.mBitmap.copyPixels(_loc_2, new Rectangle(0, 0, _loc_2.width, _loc_2.height), new Point(0, 0), _loc_3, null, false);
            return;
        }// end function

        protected function createAlphaBitmapData(param1:DisplayObject) : BitmapData
        {
            var _loc_2:* = new BitmapData(param1.width, param1.height);
            _loc_2.draw(param1, null, null, BlendMode.ALPHA);
            return _loc_2;
        }// end function

        protected function createBitmapData(param1:DisplayObject) : BitmapData
        {
            var _loc_2:* = new BitmapData(param1.width, param1.height);
            _loc_2.draw(param1);
            return _loc_2;
        }// end function

    }
}
