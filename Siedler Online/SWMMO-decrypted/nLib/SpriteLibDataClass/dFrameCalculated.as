package nLib.SpriteLibDataClass
{
    import flash.display.*;
    import flash.geom.*;

    public class dFrameCalculated extends Object
    {
        public var frameOffsXScaled:Number;
        public var orginalBitmap:BitmapData = null;
        public var frameOffsX:Number;
        public var frameOffsY:Number;
        public var frameOffsYScaled:Number;
        public var calculatePoint:Point = null;
        public var scaledBitmapRectangle:Rectangle = null;
        public var frameOffsXScaledCache:Number;
        public var scaled:Boolean;
        public var antialiased:Boolean;
        public var frameOffsYScaledCache:Number;
        public var scaledBitmap:BitmapData = null;
        public var calculateRect:Rectangle = null;
        public var zoomMatrix:Matrix;
        public var size_u:int;
        public var size_v:int;

        public function dFrameCalculated()
        {
            this.zoomMatrix = new Matrix();
            return;
        }// end function

    }
}
